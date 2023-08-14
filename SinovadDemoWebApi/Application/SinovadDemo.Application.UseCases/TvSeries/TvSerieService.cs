using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.TvSeries
{

    public class TvSerieService : ITvSerieService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public TvSerieService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<List<TvSerieDto>>> GetAllAsync()
        {
            var response = new Response<List<TvSerieDto>>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetAllAsync();
                response.Data = result.MapTo<List<TvSerieDto>>();
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

        public async Task<ResponsePagination<List<TvSerieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<TvSerieDto>>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetAllWithPaginationAsync(page, take,sortBy,sortDirection,searchText, searchBy);
                response.Data = result.Items.MapTo<List<TvSerieDto>>();
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

        public async Task<Response<TvSerieDto>> SearchAsync(string query)
        {
            var response = new Response<TvSerieDto>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetByExpressionAsync(x => x.Name.ToLower().Trim().Contains(query.ToLower().Trim()));
                var tvSerie = result.MapTo<TvSerieDto>();
                var listGenres = _unitOfWork.Genres.GetGenresByTvSerieId(tvSerie.Id);
                tvSerie.ListGenres= listGenres.MapTo<List<GenreDto>>();
                response.Data = tvSerie;
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<TvSerieDto>> GetAsync(int id)
        {
            var response = new Response<TvSerieDto>();
            try
            {
                var tvSerie = await _unitOfWork.TvSeries.GetAsync(id);
                var mdto = tvSerie.MapTo<TvSerieDto>();
                var tvSerieGenres = await _unitOfWork.TvSerieGenres.GetAllAsync();
                var genres = await _unitOfWork.Genres.GetAllAsync();
                var listItemGenres = (from mg in tvSerieGenres
                                      join g in genres on mg.GenreId equals g.Id
                                      where mg.TvSerieId == id
                                      select new TvSerieGenreDto
                                      {
                                          TvSerieId = id,
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

        public Response<object> Create(TvSerieDto tvSerieDto)
        {
            var response = new Response<object>();
            try
            {
                var tvSerie = tvSerieDto.MapTo<TvSerie>();
                MapTvSerieGenres(tvSerieDto, tvSerie);
                _unitOfWork.TvSeries.Add(tvSerie);
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

        public Response<object> Update(TvSerieDto tvSerieDto)
        {
            var response = new Response<object>();
            try
            {
                var tvSerie = tvSerieDto.MapTo<TvSerie>();
                MapTvSerieGenres(tvSerieDto, tvSerie);
                var listtvSerieGenres = _unitOfWork.TvSerieGenres.GetAllByExpressionAsync(x => x.TvSerieId == tvSerie.Id).Result.ToList();
                if (listtvSerieGenres != null && listtvSerieGenres.Count > 0)
                {
                    _unitOfWork.TvSerieGenres.DeleteList(listtvSerieGenres);
                }
                _unitOfWork.TvSeries.Update(tvSerie);
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
                //var seasons = _unitOfWork.Seasons.GetAllByExpression(x => x.TvSerieId==id);
                //if (seasons != null && seasons.Count() > 0)
                //{
                //    var listSeasonsIds = seasons.Select(x => x.Id);
                //    var episodes = _unitOfWork.Episodes.GetAllByExpression(x => listSeasonsIds.Contains(x.SeasonId));
                //    if (episodes != null && episodes.Count() > 0)
                //    {
                //        _unitOfWork.Episodes.DeleteList(episodes.ToList());
                //    }
                //    _unitOfWork.Seasons.DeleteList(seasons.ToList());
                //}
                _unitOfWork.TvSerieGenres.DeleteByExpression(x =>x.TvSerieId==id);
                _unitOfWork.TvSeries.Delete(id);
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
                //var seasons = _unitOfWork.Seasons.GetAllByExpression(x=> listIds.Contains(x.TvSerieId));
                //if (seasons != null && seasons.Count() > 0)
                //{
                //    var listSeasonsIds = seasons.Select(x => x.Id);
                //    var episodes = _unitOfWork.Episodes.GetAllByExpression(x => listSeasonsIds.Contains(x.SeasonId));
                //    if(episodes != null && episodes.Count() > 0)
                //    {
                //        _unitOfWork.Episodes.DeleteList(episodes.ToList());
                //    }
                //    _unitOfWork.Seasons.DeleteList(seasons.ToList());
                //}
                _unitOfWork.TvSerieGenres.DeleteByExpression(x => listIds.Contains(x.TvSerieId));
                _unitOfWork.TvSeries.DeleteByExpression(x => listIds.Contains(x.Id));
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

        private void MapTvSerieGenres(TvSerieDto tvSerieDto, TvSerie tvSerie)
        {
            if (tvSerieDto.ListItemGenres != null && tvSerieDto.ListItemGenres.Count > 0)
            {
                var list = tvSerieDto.ListItemGenres.AsEnumerable();
                List<TvSerieGenre> tvSerieGenres = (from mg in list
                                                    select new TvSerieGenre
                                                    {
                                                        GenreId = mg.GenreId,
                                                    }).ToList();
                tvSerie.TvSerieGenres = tvSerieGenres;
            }
        }

    }
}
