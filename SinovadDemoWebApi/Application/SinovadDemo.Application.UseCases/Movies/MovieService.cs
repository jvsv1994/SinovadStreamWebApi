using Microsoft.Extensions.Caching.Distributed;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;
using System.Text;
using System.Text.Json;

namespace SinovadDemo.Application.UseCases.Movies
{

    public class MovieService : IMovieService
    {
        private IUnitOfWork _unitOfWork;
        private readonly SharedService _sharedService;
        private readonly IDistributedCache _distributedCache;


        public MovieService(IUnitOfWork unitOfWork, SharedService sharedService, IDistributedCache distributedCache)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
            _distributedCache = distributedCache;
        }

        public async Task<Response<List<MovieDto>>> GetAllAsync()
        {
            var response = new Response<List<MovieDto>>();
            var cacheKey = "moviesList";
            try
            {
                var redisMovies = await _distributedCache.GetAsync(cacheKey);
                if (redisMovies != null)
                {
                    response.Data = JsonSerializer.Deserialize<List<MovieDto>>(redisMovies);
                }
                else
                {
                    var result = await _unitOfWork.Movies.GetAllAsync();
                    response.Data = result.MapTo<List<MovieDto>>();
                    if (response.Data != null)
                    {
                        var serializedCategories = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(response.Data));
                        var options = new DistributedCacheEntryOptions()
                            .SetAbsoluteExpiration(DateTime.Now.AddHours(8))
                            .SetSlidingExpiration(TimeSpan.FromMinutes(60));
                        await _distributedCache.SetAsync(cacheKey, serializedCategories, options);
                    }
                }
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<MovieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<MovieDto>>();
            try
            {
                var result = await _unitOfWork.Movies.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = result.Items.MapTo<List<MovieDto>>();
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MovieDto>> GetAsync(int id)
        {
            var response = new Response<MovieDto>();
            try
            {
                var movie = await _unitOfWork.Movies.GetAsync(id);
                var mdto = movie.MapTo<MovieDto>();
                var movieGenres = await _unitOfWork.MovieGenres.GetAllAsync();
                var genres = await _unitOfWork.Genres.GetAllAsync();
                var listItemGenres = (from mg in movieGenres
                                      join g in genres on mg.GenreId equals g.Id
                                      where mg.MovieId == id
                                      select new MovieGenreDto
                                      {
                                          MovieId = id,
                                          GenreId = g.Id,
                                          GenreName = g.Name
                                      }).ToList();
                mdto.ListItemGenres = listItemGenres;
                response.Data = mdto;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Create(MovieDto movieDto)
        {
            var response = new Response<object>();
            try
            {
                var movie = movieDto.MapTo<Movie>();
                MapMovieGenres(movieDto, movie);
                _unitOfWork.Movies.Add(movie);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Update(MovieDto movieDto)
        {
            var response = new Response<object>();
            try
            {
                var movie = movieDto.MapTo<Movie>();
                MapMovieGenres(movieDto, movie);
                var listMovieGenres = _unitOfWork.MovieGenres.GetAllByExpressionAsync(c => c.MovieId == movie.Id).Result.ToList();
                if (listMovieGenres != null && listMovieGenres.Count > 0)
                {
                    _unitOfWork.MovieGenres.DeleteList(listMovieGenres);
                }
                _unitOfWork.Movies.Update(movie);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Movies.Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> DeleteList(string ids)
        {
            var response = new Response<object>();
            try
            {
                List<int> listIds = new List<int>();
                if (!string.IsNullOrEmpty(ids))
                {
                    listIds = ids.Split(",").Select(x => Convert.ToInt32(x)).ToList();
                }
                _unitOfWork.MovieGenres.DeleteByExpression(x => listIds.Contains(x.MovieId));
                _unitOfWork.Movies.DeleteByExpression(x => listIds.Contains(x.Id));
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        private void MapMovieGenres(MovieDto movieDto, Movie movie)
        {
            if (movieDto.ListItemGenres != null && movieDto.ListItemGenres.Count > 0)
            {
                var list = movieDto.ListItemGenres.AsEnumerable();
                List<MovieGenre> movieGenres = (from mg in list
                                                select new MovieGenre
                                                {
                                                    GenreId = mg.GenreId,
                                                }).ToList();
                movie.MovieGenres = movieGenres;
            }
        }
    }
}
