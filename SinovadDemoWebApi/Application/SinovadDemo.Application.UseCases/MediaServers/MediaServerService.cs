using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Helpers;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.MediaServers
{
    public class MediaServerService : IMediaServerService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        private readonly IOptions<MyConfig> _config;


        public MediaServerService(IUnitOfWork unitOfWork, SharedService sharedService, IOptions<MyConfig> config)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
            _config = config;
        }

        public async Task<Response<MediaServerDto>> GetAsync(int id)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var mediaServer = await _unitOfWork.MediaServers.GetAsync(id);
                response.Data = mediaServer.MapTo<MediaServerDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MediaServerDto>> GetByGuidAsync(string guid)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.Guid.ToString()==guid);
                response.Data = result.MapTo<MediaServerDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
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
                    response.Data = result.MapTo<MediaServerDto>();
                }
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<string>> AuthenticateBySecurityIdentifierAsync(string securityIdentifier)
        {
            var response = new Response<string>();
            try
            {
                var result =  await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.SecurityIdentifier == securityIdentifier);
                if(result != null)
                {
                    var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                    var token = jwtHelper.CreateTokenWithSecurityIdentifier(securityIdentifier);
                    response.Data = token;
                }
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<MediaServerDto>> GetByUserAndIpAddressAsync(int userId, string ipAddress)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.IpAddress == ipAddress && x.UserId == userId);
                response.Data = result.MapTo<MediaServerDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<List<MediaServerDto>>> GetAllByUserAsync(int userId)
        {
            var response = new Response<List<MediaServerDto>>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetAllByExpressionAsync(x => x.UserId == userId);
                response.Data = result.MapTo<List<MediaServerDto>>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }


        public async Task<ResponsePagination<List<MediaServerDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take)
        {
            var response = new ResponsePagination<List<MediaServerDto>>();
            try
            {
                var result = await _unitOfWork.MediaServers.GetAllWithPaginationByExpressionAsync(page, take, "Id", "desc", "", "", x => x.UserId == userId);
                response.Data = result.Items.MapTo<List<MediaServerDto>>();
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Create(MediaServerDto mediaServerDto)
        {
            var response = new Response<object>();
            try
            {
                var mediaServer = mediaServerDto.MapTo<MediaServer>();
                _unitOfWork.MediaServers.Add(mediaServer);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> CreateList(List<MediaServerDto> listMediaServerDto)
        {
            var response = new Response<object>();
            try
            {
                var mediaServers = listMediaServerDto.MapTo<List<MediaServer>>();
                _unitOfWork.MediaServers.AddList(mediaServers);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }


        public async Task<Response<MediaServerDto>> Save(MediaServerDto mediaServerDto)
        {
            var response = new Response<MediaServerDto>();
            try
            {
                var ms= await _unitOfWork.MediaServers.GetByExpressionAsync(x=>x.SecurityIdentifier==mediaServerDto.SecurityIdentifier);
                if(ms != null)
                {
                    ms.UserId = mediaServerDto.UserId;
                    ms.IpAddress= mediaServerDto.IpAddress;
                    ms.PublicIpAddress = mediaServerDto.PublicIpAddress;
                    ms.Port = mediaServerDto.Port;
                    ms.Url=mediaServerDto.Url;
                    ms.DeviceName = mediaServerDto.DeviceName;
                    _unitOfWork.MediaServers.Update(ms);
                }else
                {
                    var mediaServer = mediaServerDto.MapTo<MediaServer>();
                    ms = await _unitOfWork.MediaServers.AddAsync(mediaServer);
                }
                await _unitOfWork.SaveAsync();
                response.Data = ms.MapTo<MediaServerDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Update(MediaServerDto mediaServerDto)
        {
            var response = new Response<object>();
            try
            {
                var mediaServer = mediaServerDto.MapTo<MediaServer>();
                _unitOfWork.MediaServers.Update(mediaServer);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.MediaServers.Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
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
                _unitOfWork.MediaServers.DeleteByExpression(x => listIds.Contains(x.Id));
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

    }
}
