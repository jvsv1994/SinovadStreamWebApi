using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.TranscoderSetting
{
    public class TranscoderSettingsService : ITranscoderSettingsService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public TranscoderSettingsService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }
        public async Task<Response<TranscoderSettingsDto>> GetAsync(int id)
        {
            var response = new Response<TranscoderSettingsDto>();
            try
            {
                var result = await _unitOfWork.TranscoderSettings.GetAsync(id);
                response.Data = result.MapTo<TranscoderSettingsDto>();
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

        public async Task<Response<TranscoderSettingsDto>> GetByMediaServerGuidAsync(string guid)
        {
            var response = new Response<TranscoderSettingsDto>();
            try
            {
                var result = await _unitOfWork.TranscoderSettings.GetByExpressionAsync(x=>x.MediaServer.Guid.ToString()==guid);
                response.Data = result.MapTo<TranscoderSettingsDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<TranscoderSettingsDto>> GetByMediaServerAsync(int mediaServerId)
        {
            var response = new Response<TranscoderSettingsDto>();
            try
            {
                var result = await _unitOfWork.TranscoderSettings.GetByExpressionAsync(x => x.MediaServerId == mediaServerId);
                if(result!=null)
                {
                    response.Data = result.MapTo<TranscoderSettingsDto>();
                    response.Message = "Successful";
                }
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _sharedService._tracer.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<ResponsePagination<List<TranscoderSettingsDto>>> GetAllWithPaginationByMediaServerAsync(int mediaServerId, int page, int take)
        {
            var response = new ResponsePagination<List<TranscoderSettingsDto>>();
            try
            {
                var result = await _unitOfWork.TranscoderSettings.GetAllWithPaginationByExpressionAsync(page, take, "Id", "desc", "", "", x => x.MediaServerId == mediaServerId);
                response.Data = result.Items.MapTo<List<TranscoderSettingsDto>>();
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

        public Response<object> Create(TranscoderSettingsDto transcoderSettingsDto)
        {
            var response = new Response<object>();
            try
            {
                var transcoderSettings = transcoderSettingsDto.MapTo<TranscoderSettings>();
                _unitOfWork.TranscoderSettings.Add(transcoderSettings);
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

        public Response<object> CreateList(List<TranscoderSettingsDto> listTranscoderSettingsDto)
        {
            var response = new Response<object>();
            try
            {
                var transcoderSettings = listTranscoderSettingsDto.MapTo<List<TranscoderSettings>>();
                _unitOfWork.TranscoderSettings.AddList(transcoderSettings);
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

        public Response<object> Update(TranscoderSettingsDto transcoderSettingsDto)
        {
            var response = new Response<object>();
            try
            {
                var transcoderSettings = transcoderSettingsDto.MapTo<TranscoderSettings>();
                _unitOfWork.TranscoderSettings.Update(transcoderSettings);
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

        public async Task<Response<TranscoderSettingsDto>> Save(TranscoderSettingsDto transcoderSettingsDto)
        {
            var response = new Response<TranscoderSettingsDto>();
            try
            {
                var ts = await _unitOfWork.TranscoderSettings.GetByExpressionAsync(x => x.MediaServerId == transcoderSettingsDto.MediaServerId);
                if (ts != null)
                { 
                    _unitOfWork.TranscoderSettings.Update(ts);
                }else
                {
                    var transcoderSettings = transcoderSettingsDto.MapTo<TranscoderSettings>();
                    ts = await _unitOfWork.TranscoderSettings.AddAsync(transcoderSettings);
                }
                await _unitOfWork.SaveAsync();
                response.Data = ts.MapTo<TranscoderSettingsDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
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
                _unitOfWork.TranscoderSettings.Delete(id);
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
                _unitOfWork.TranscoderSettings.DeleteByExpression(x => listIds.Contains(x.Id));
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
