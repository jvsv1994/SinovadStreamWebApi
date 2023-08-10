using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Episodes
{
    public class EpisodeService : IEpisodeService
    {
        private IUnitOfWork _unitOfWork;
        private readonly SharedService _sharedService;

        public EpisodeService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<EpisodeDto>> GetTvEpisodeAsync(int tvSerieId,int seasonNumber,int episodeNumber)
        {
            var response = new Response<EpisodeDto>();
            try
            {
                var result = _unitOfWork.Episodes.GetEpisode(tvSerieId, seasonNumber, episodeNumber);
                response.Data = result.MapTo<EpisodeDto>();
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

        public async Task<Response<EpisodeDto>> GetAsync(int id)
        {
            var response = new Response<EpisodeDto>();
            try
            {
                var result = await _unitOfWork.Episodes.GetAsync(id);
                response.Data = result.MapTo<EpisodeDto>();
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

        public async Task<Response<List<EpisodeDto>>> GetAllAsync()
        {
            var response = new Response<List<EpisodeDto>>();
            try
            {
                var result =  _unitOfWork.Episodes.GetEpisodesFromOwnDataBase();
                response.Data = result.MapTo<List<EpisodeDto>>();
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


        public async Task<ResponsePagination<List<EpisodeDto>>> GetAllWithPaginationBySeasonAsync(int seasonId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<EpisodeDto>>();
            try
            {
                var result = await _unitOfWork.Episodes.GetAllWithPaginationByExpressionAsync(page, take, sortBy, sortDirection, searchText, searchBy, x => x.SeasonId == seasonId);
                response.Data = result.Items.MapTo<List<EpisodeDto>>();
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

        public Response<object> Create(EpisodeDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = dto.MapTo<Episode>();
                _unitOfWork.Episodes.Add(entity);
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

        public Response<object> CreateList(List<EpisodeDto> list)
        {
            var response = new Response<object>();
            try
            {
                var listEntities = list.MapTo<List<Episode>>();
                _unitOfWork.Episodes.AddList(listEntities);
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

        public Response<object> Update(EpisodeDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = dto.MapTo<Episode>();
                _unitOfWork.Episodes.Update(entity);
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
                _unitOfWork.Episodes.Delete(id);
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
                _unitOfWork.Episodes.DeleteByExpression(x => listIds.Contains(x.Id));
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

    }
}
