using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.TranscodeVideoProcesses
{
    public class TranscodeVideoProcessService : ITranscodeVideoProcessService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public TranscodeVideoProcessService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<TranscodeVideoProcessDto>> GetAsync(int id)
        {
            var response = new Response<TranscodeVideoProcessDto>();
            try
            {
                var result = await _unitOfWork.TranscodeVideoProcesses.GetAsync(id);
                response.Data = result.MapTo<TranscodeVideoProcessDto>();
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

        public async Task<Response<List<TranscodeVideoProcessDto>>> GetAllByAccountServerAsync(int accountServerId)
        {
            var response = new Response<List<TranscodeVideoProcessDto>>();
            try
            {
                var result = await _unitOfWork.TranscodeVideoProcesses.GetAllByExpressionAsync(x => x.AccountServerId == accountServerId);
                response.Data = result.MapTo<List<TranscodeVideoProcessDto>>();
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

        public async Task<Response<List<TranscodeVideoProcessDto>>> GetAllByListGuidsAsync(string guids)
        {
            var response = new Response<List<TranscodeVideoProcessDto>>();
            try
            {
                List<string> listGuids = new List<string>();
                if (!string.IsNullOrEmpty(guids))
                {
                    listGuids = guids.Split(",").Select(x => x.ToString()).ToList();
                }
                var result = await _unitOfWork.TranscodeVideoProcesses.GetAllByExpressionAsync(x => listGuids.Contains(x.Guid));
                response.Data = result.MapTo<List<TranscodeVideoProcessDto>>();
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

        public Response<object> Create(TranscodeVideoProcessDto transcodeVideoProcessDto)
        {
            var response = new Response<object>();
            try
            {
                var transcodeVideoProcess = transcodeVideoProcessDto.MapTo<TranscodeVideoProcess>();
                _unitOfWork.TranscodeVideoProcesses.Add(transcodeVideoProcess);
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

        public Response<object> CreateList(List<TranscodeVideoProcessDto> listTranscodeVideoProcessDto)
        {
            var response = new Response<object>();
            try
            {
                var transcodeVideoProcess = listTranscodeVideoProcessDto.MapTo<List<TranscodeVideoProcess>>();
                _unitOfWork.TranscodeVideoProcesses.AddList(transcodeVideoProcess);
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

        public Response<object> Update(TranscodeVideoProcessDto transcodeVideoProcessDto)
        {
            var response = new Response<object>();
            try
            {
                var transcodeVideoProcess = transcodeVideoProcessDto.MapTo<TranscodeVideoProcess>();
                _unitOfWork.TranscodeVideoProcesses.Update(transcodeVideoProcess);
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
                _unitOfWork.TranscodeVideoProcesses.Delete(id);
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
                _unitOfWork.TranscodeVideoProcesses.DeleteByExpression(x => listIds.Contains(x.Id));
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

        public Response<object> DeleteByListGuids(string guids)
        {
            var response = new Response<object>();
            try
            {
                List<string> listGuids = new List<string>();
                if (!string.IsNullOrEmpty(guids))
                {
                    listGuids = guids.Split(",").Select(x => x.ToString()).ToList();
                }
                _unitOfWork.TranscodeVideoProcesses.DeleteByExpression(x => listGuids.Contains(x.Guid));
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
