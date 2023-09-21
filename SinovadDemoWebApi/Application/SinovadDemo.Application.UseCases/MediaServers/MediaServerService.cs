using AutoMapper;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.MediaServers
{
    public class MediaServerService : IMediaServerService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<MediaServerService> _logger;

        public MediaServerService(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<MediaServerService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<MediaServerDto>> GetAsync(int id)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var mediaServer = await _unitOfWork.MediaServers.GetAsync(id);
                response.Data = _mapper.Map<MediaServerDto>(mediaServer);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MediaServerDto>> GetByGuidAsync(string guid)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.Guid.ToString()==guid);
                response.Data = _mapper.Map<MediaServerDto>(result);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MediaServerDto>> GetBySecurityIdentifierAsync(string securityIdentifier)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.SecurityIdentifier.ToString() == securityIdentifier);
                if(result!=null)
                {
                    response.Data = _mapper.Map<MediaServerDto>(result);
                }
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MediaServerDto>> GetByUserAndIpAddressAsync(int userId, string ipAddress)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.IpAddress == ipAddress && x.UserId == userId);
                response.Data = _mapper.Map<MediaServerDto>(result);
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<List<MediaServerDto>>> GetAllByUserAsync(int userId)
        {
            var response = new Response<List<MediaServerDto>>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetAllByExpressionAsync(x => x.UserId == userId);
                response.Data = _mapper.Map<List<MediaServerDto>>(result);
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }


        public async Task<ResponsePagination<List<MediaServerDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<MediaServerDto>>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetAllWithPaginationByExpressionAsync(page, take, sortBy, sortDirection, searchText, searchBy, x => x.UserId == userId);
                response.Data = _mapper.Map<List<MediaServerDto>>(result.Items);
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MediaServerDto>> CreateAsync(MediaServerCreationDto mediaServerCreationDto)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var mediaServer = _mapper.Map<MediaServer>(mediaServerCreationDto);
                mediaServer = await _unitOfWork.MediaServers.AddAsync(mediaServer);
                await _unitOfWork.SaveAsync();
                response.Data= _mapper.Map<MediaServerDto>(mediaServer);
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int mediaServerId,MediaServerCreationDto mediaServerCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var mediaServer = await _unitOfWork.MediaServers.GetAsync(mediaServerId);
                mediaServer = _mapper.Map(mediaServerCreationDto, mediaServer);
                _unitOfWork.MediaServers.Update(mediaServer);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception ex){
               response.Message = ex.StackTrace;
               _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.MediaServers.Delete(id);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception ex){
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<bool> CheckIfExistsAsync(int mediaServerId)
        {
            return await _unitOfWork.Menus.CheckIfExistAsync(mediaServer=>mediaServer.Id==mediaServerId);
        }
    }
}
