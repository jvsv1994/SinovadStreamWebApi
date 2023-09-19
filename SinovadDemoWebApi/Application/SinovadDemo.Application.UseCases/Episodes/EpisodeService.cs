using AutoMapper;
using MySqlX.XDevAPI;
using SinovadDemo.Application.DTO.Episode;
using SinovadDemo.Application.DTO.Season;
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
                var result = await _unitOfWork.Episodes.SearchEpisode(tvSerieId, seasonNumber, episodeNumber);
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

        public async Task<Response<EpisodeDto>> CreateAsync(int seasonId,EpisodeCreationDto episodeCreationDto)
        {
            var response = new Response<EpisodeDto>();
            try
            {
                var episode = _mapper.Map<Episode>(episodeCreationDto);
                episode.SeasonId=seasonId;
                await _unitOfWork.Episodes.AddAsync(episode);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<EpisodeDto>(episode);
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

        public async Task<Response<object>> CreateListAsync(int seasonId, List<EpisodeCreationDto> list)
        {
            var response = new Response<object>();
            try
            {
                var listEpisodes = _mapper.Map<List<Episode>>(list);
                foreach (var episode in listEpisodes)
                {
                    episode.SeasonId = seasonId;    
                }
                await _unitOfWork.Episodes.AddListAsync(listEpisodes);
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

        public async Task<Response<object>> UpdateAsync(int episodeId, EpisodeCreationDto episodeCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var episodeFinded = await _unitOfWork.Episodes.GetAsync(episodeId);
                episodeFinded = _mapper.Map(episodeCreationDto, episodeFinded);
                _unitOfWork.Episodes.Update(episodeFinded);
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
                _unitOfWork.Episodes.Delete(id);
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
                _unitOfWork.Episodes.DeleteByExpression(x => listIds.Contains(x.Id));
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
            return await _unitOfWork.Episodes.CheckExist(x => x.Id == id);
        }

    }
}
