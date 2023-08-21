using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Seasons
{

    public class SeasonService : ISeasonService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        private readonly AutoMapper.IMapper _mapper;

        public SeasonService(IUnitOfWork unitOfWork, SharedService sharedService, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
            _mapper = mapper;
        }

        public async Task<Response<SeasonDto>> GetTvSeasonAsync(int tvSerieId,int seasonNumber)
        {
            var response = new Response<SeasonDto>();
            try
            {
                var result = await _unitOfWork.Seasons.GetByExpressionAsync(x=>x.TvSerieId==tvSerieId && x.SeasonNumber==seasonNumber);
                response.Data = _mapper.Map<SeasonDto>(result);
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

        public async Task<Response<SeasonDto>> GetAsync(int id)
        {
            var response = new Response<SeasonDto>();
            try
            {
                var result = await _unitOfWork.Seasons.GetAsync(id);
                response.Data = _mapper.Map<SeasonDto>(result);
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


        public async Task<ResponsePagination<List<SeasonDto>>> GetAllWithPaginationByTvSerieAsync(int tvSerieId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<SeasonDto>>();
            try
            {
                var result = await _unitOfWork.Seasons.GetAllWithPaginationByExpressionAsync(page, take, sortBy, sortDirection, searchText, searchBy, x => x.TvSerieId == tvSerieId);
                response.Data = _mapper.Map<List<SeasonDto>>(result.Items);
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

        public Response<object> Create(SeasonDto seasonDto)
        {
            var response = new Response<object>();
            try
            {
                var season = _mapper.Map<Season>(seasonDto);
                _unitOfWork.Seasons.Add(season);
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

        public Response<object> Update(SeasonDto seasonDto)
        {
            var response = new Response<object>();
            try
            {
                var season = _mapper.Map<Season>(seasonDto);
                _unitOfWork.Seasons.Update(season);
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
                _unitOfWork.Seasons.Delete(id);
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
                _unitOfWork.Seasons.DeleteByExpression(x => listIds.Contains(x.Id));
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
