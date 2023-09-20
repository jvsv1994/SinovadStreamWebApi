using AutoMapper;
using SinovadDemo.Application.DTO.Season;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Seasons
{

    public class SeasonService : ISeasonService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<SeasonService> _logger;

        public SeasonService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<SeasonService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
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
                _logger.LogError(ex.StackTrace);
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
                _logger.LogError(ex.StackTrace);
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
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<SeasonDto>> CreateAsync(int tvSerieId,SeasonCreationDto seasonCreationDto)
        {
            var response = new Response<SeasonDto>();
            try
            {
                var season = _mapper.Map<Season>(seasonCreationDto);
                season.TvSerieId = tvSerieId;
                await _unitOfWork.Seasons.AddAsync(season);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<SeasonDto>(season);
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

        public async Task<Response<object>> UpdateAsync(int seasonId,SeasonCreationDto seasonCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var seasonFinded = await _unitOfWork.Seasons.GetAsync(seasonId);
                seasonFinded = _mapper.Map(seasonCreationDto, seasonFinded);
                _unitOfWork.Seasons.Update(seasonFinded);
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
                _unitOfWork.Seasons.Delete(id);
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
                _unitOfWork.Seasons.DeleteByExpression(x => listIds.Contains(x.Id));
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
            return await _unitOfWork.Seasons.CheckIfExistAsync(x => x.Id == id);
        }

    }
}
