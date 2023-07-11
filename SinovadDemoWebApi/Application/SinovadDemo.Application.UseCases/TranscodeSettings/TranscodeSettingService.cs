using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.TranscodeSettings
{
    public class TranscodeSettingService : ITranscodeSettingService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public TranscodeSettingService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }
        public async Task<Response<TranscodeSettingDto>> GetAsync(int id)
        {
            var response = new Response<TranscodeSettingDto>();
            try
            {
                var result = await _unitOfWork.TranscodeSettings.GetAsync(id);
                response.Data = result.MapTo<TranscodeSettingDto>();
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
        public async Task<Response<TranscodeSettingDto>> GetByAccountServerAsync(int accountServerId)
        {
            var response = new Response<TranscodeSettingDto>();
            try
            {
                var result = await _unitOfWork.TranscodeSettings.GetByExpressionAsync(x => x.AccountServerId == accountServerId);
                if(result!=null)
                {
                    response.Data = result.MapTo<TranscodeSettingDto>();
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

        public async Task<ResponsePagination<List<TranscodeSettingDto>>> GetAllWithPaginationByAccountServerAsync(int accountServerId, int page, int take)
        {
            var response = new ResponsePagination<List<TranscodeSettingDto>>();
            try
            {
                var result = await _unitOfWork.TranscodeSettings.GetAllWithPaginationByExpressionAsync(page, take, "Id", true, x => x.AccountServerId == accountServerId);
                response.Data = result.Items.MapTo<List<TranscodeSettingDto>>();
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

        public Response<object> Create(TranscodeSettingDto transcodeSettingDto)
        {
            var response = new Response<object>();
            try
            {
                var transcodeSetting = transcodeSettingDto.MapTo<TranscodeSetting>();
                _unitOfWork.TranscodeSettings.Add(transcodeSetting);
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

        public Response<object> CreateList(List<TranscodeSettingDto> listTranscodeSettingDto)
        {
            var response = new Response<object>();
            try
            {
                var transcodeSettings = listTranscodeSettingDto.MapTo<List<TranscodeSetting>>();
                _unitOfWork.TranscodeSettings.AddList(transcodeSettings);
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

        public Response<object> Update(TranscodeSettingDto transcodeSettingDto)
        {
            var response = new Response<object>();
            try
            {
                var transcodeSetting = transcodeSettingDto.MapTo<TranscodeSetting>();
                _unitOfWork.TranscodeSettings.Update(transcodeSetting);
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
                _unitOfWork.TranscodeSettings.Delete(id);
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
                _unitOfWork.TranscodeSettings.DeleteByExpression(x => listIds.Contains(x.Id));
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
