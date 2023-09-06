using AutoMapper;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Episodes
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly AutoMapper.IMapper _mapper;
        private readonly IAppLogger<EpisodeService> _logger;

        public EpisodeService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<EpisodeService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<EpisodeDto>> GetTvEpisodeAsync(int tvSerieId,int seasonNumber,int episodeNumber)
        {
            var response = new Response<EpisodeDto>();
            try
            {
                var result = _unitOfWork.Episodes.GetEpisode(tvSerieId, seasonNumber, episodeNumber);
                response.Data = _mapper.Map<EpisodeDto>(result);
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

        public async Task<Response<EpisodeDto>> GetAsync(int id)
        {
            var response = new Response<EpisodeDto>();
            try
            {
                var result = await _unitOfWork.Episodes.GetAsync(id);
                response.Data = _mapper.Map<EpisodeDto>(result);
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

        public async Task<Response<List<EpisodeDto>>> GetAllAsync()
        {
            var response = new Response<List<EpisodeDto>>();
            try
            {
                var result = await _unitOfWork.Episodes.GetAllAsync();
                response.Data = _mapper.Map<List<EpisodeDto>>(result);
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


        public async Task<ResponsePagination<List<EpisodeDto>>> GetAllWithPaginationBySeasonAsync(int seasonId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<EpisodeDto>>();
            try
            {
                var result = await _unitOfWork.Episodes.GetAllWithPaginationByExpressionAsync(page, take, sortBy, sortDirection, searchText, searchBy, x => x.SeasonId == seasonId);
                response.Data = _mapper.Map<List<EpisodeDto>>(result.Items);
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

        public Response<object> Create(EpisodeDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = _mapper.Map<Episode>(dto);
                _unitOfWork.Episodes.Add(entity);
                _unitOfWork.Save();
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

        public Response<object> CreateList(List<EpisodeDto> list)
        {
            var response = new Response<object>();
            try
            {
                var listEntities = _mapper.Map<List<Episode>>(list);
                _unitOfWork.Episodes.AddList(listEntities);
                _unitOfWork.Save();
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

        public Response<object> Update(EpisodeDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = _mapper.Map<Episode>(dto);
                _unitOfWork.Episodes.Update(entity);
                _unitOfWork.Save();
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

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Episodes.Delete(id);
                _unitOfWork.Save();
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
                _unitOfWork.Episodes.DeleteByExpression(x => listIds.Contains(x.Id));
                _unitOfWork.Save();
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

    }
}
