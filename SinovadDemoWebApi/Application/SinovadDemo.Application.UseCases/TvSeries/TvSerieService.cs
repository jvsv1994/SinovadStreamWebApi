using AutoMapper;
using SinovadDemo.Application.DTO.TvSerie;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.TvSeries
{

    public class TvSerieService : ITvSerieService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<TvSerieService> _logger;
        public TvSerieService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<TvSerieService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<List<TvSerieDto>>> GetAllAsync()
        {
            var response = new Response<List<TvSerieDto>>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetAllAsync();
                response.Data = _mapper.Map<List<TvSerieDto>>(result);
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

        public async Task<ResponsePagination<List<TvSerieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<TvSerieDto>>();
            try
            {
                var result = await _unitOfWork.TvSeries.GetAllWithPaginationAsync(page, take,sortBy,sortDirection,searchText, searchBy);
                response.Data = _mapper.Map<List<TvSerieDto>>(result.Items);
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

        public async Task<Response<TvSerieWithGenresDto>> SearchAsync(string query)
        {
            var response = new Response<TvSerieWithGenresDto>();
            try
            {
                var tvSerieFinded = await _unitOfWork.TvSeries.SearchTvSerie(query);
                var tvSerie = _mapper.Map<TvSerieWithGenresDto>(tvSerieFinded);
                response.Data = tvSerie;
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<TvSerieWithGenresDto>> GetAsync(int id)
        {
            var response = new Response<TvSerieWithGenresDto>();
            try
            {
                var tvSerie = await _unitOfWork.TvSeries.GetTvSerie(id);
                var mdto = _mapper.Map<TvSerieWithGenresDto>(tvSerie);          
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

        public async Task<Response<TvSerieDto>> CreateAsync(TvSerieCreationDto tvSerieCreationDto)
        {
            var response = new Response<TvSerieDto>();
            try
            {
                if (tvSerieCreationDto.GenresIds == null || tvSerieCreationDto.GenresIds.Count == 0)
                {
                    throw new Exception("No se puede guardar una serie sin géneros");
                }
                var genresIds = await _unitOfWork.Genres.GetIdsByExpression(genre => tvSerieCreationDto.GenresIds.Contains(genre.Id));
                if (tvSerieCreationDto.GenresIds.Count != genresIds.Count)
                {
                    throw new Exception("No existe uno de los géneros enviados");
                }
                var tvSerie = _mapper.Map<TvSerie>(tvSerieCreationDto);
                await _unitOfWork.TvSeries.AddAsync(tvSerie);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<TvSerieDto>(tvSerie);
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

        public async Task<Response<object>> UpdateAsync(int id, TvSerieCreationDto tvSerieCreationDto)
        {
            var response = new Response<object>();
            try
            {
                if (tvSerieCreationDto.GenresIds == null || tvSerieCreationDto.GenresIds.Count == 0)
                {
                    throw new Exception("No se puede guardar una serie sin géneros");
                }
                var genresIds = await _unitOfWork.Genres.GetIdsByExpression(genre => tvSerieCreationDto.GenresIds.Contains(genre.Id));
                if (tvSerieCreationDto.GenresIds.Count != genresIds.Count)
                {
                    throw new Exception("No existe uno de los géneros enviados");
                }

                var tvSerieFinded = await _unitOfWork.TvSeries.GetTvSerie(id);
                tvSerieFinded = _mapper.Map(tvSerieCreationDto, tvSerieFinded);
                _unitOfWork.TvSeries.Update(tvSerieFinded);
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

        public async Task<Response<object>> DeleteAsync(int id)
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
            return await _unitOfWork.TvSeries.CheckIfExistAsync(x => x.Id == id);
        }

    }
}
