using AutoMapper;
using Microsoft.Extensions.Caching.Distributed;
using SinovadDemo.Application.DTO.Movie;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using System.Text;
using System.Text.Json;

namespace SinovadDemo.Application.UseCases.Movies
{

    public class MovieService : IMovieService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDistributedCache _distributedCache;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IAppLogger<MovieService> _logger;
        public MovieService(IUnitOfWork unitOfWork, IDistributedCache distributedCache, IMapper mapper, IAppLogger<MovieService> logger)
        {
            _unitOfWork = unitOfWork;
            _distributedCache = distributedCache;
            _mapper = mapper;
            _logger = logger;
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
                    response.Data = _mapper.Map<List<MovieDto>>(result);
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
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<MovieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<MovieDto>>();
            try
            {
                var result = await _unitOfWork.Movies.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<MovieDto>>(result.Items);
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MovieWithGenresDto>> GetAsync(int id)
        {
            var response = new Response<MovieWithGenresDto>();
            try
            {
                var movie = await _unitOfWork.Movies.GetMovie(id);
                var mdto = _mapper.Map<MovieWithGenresDto>(movie);
                response.Data = mdto;
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MovieDto>> CreateAsync(MovieCreationDto movieCreationDto)
        {
            var response = new Response<MovieDto>();
            try
            {
                if(movieCreationDto.GenresIds==null || movieCreationDto.GenresIds.Count == 0)
                {
                    throw new Exception("No se puede crear una película sin géneros");
                }
                var genresIds=await _unitOfWork.Genres.GetIdsByExpression(genre=> movieCreationDto.GenresIds.Contains(genre.Id));
                if(movieCreationDto.GenresIds.Count!=genresIds.Count)
                {
                    throw new Exception("No existe uno de los géneros enviados");
                }
                var movie = _mapper.Map<Movie>(movieCreationDto);
                await _unitOfWork.Movies.AddAsync(movie);
                await _unitOfWork.SaveAsync();
                response.Data=_mapper.Map<MovieDto>(movie);
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int id, MovieCreationDto movieCreationDto)
        {
            var response = new Response<object>();
            try
            {
                if (movieCreationDto.GenresIds == null || movieCreationDto.GenresIds.Count==0)
                {
                    throw new Exception("No se puede guardar una película sin géneros");
                }
                var genresIds = await _unitOfWork.Genres.GetIdsByExpression(genre => movieCreationDto.GenresIds.Contains(genre.Id));
                if (movieCreationDto.GenresIds.Count != genresIds.Count)
                {
                    throw new Exception("No existe uno de los géneros enviados");
                }

                var movieFinded=await _unitOfWork.Movies.GetMovie(id);
                movieFinded = _mapper.Map(movieCreationDto, movieFinded);
                _unitOfWork.Movies.Update(movieFinded);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.MovieGenres.DeleteByExpression(x => x.MovieId == id);
                _unitOfWork.Movies.Delete(id);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteListAsync(string ids)
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
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<bool> CheckExistAsync(int id)
        {
            return await _unitOfWork.Movies.CheckExist(x => x.Id == id);
        }

    }
}
