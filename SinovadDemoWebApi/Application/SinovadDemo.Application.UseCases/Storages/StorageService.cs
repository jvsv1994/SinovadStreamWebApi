using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Storages
{
    public class StorageService : IStorageService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public StorageService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<StorageDto>> GetAsync(int id)
        {
            var response = new Response<StorageDto>();
            try
            {
                var result = await _unitOfWork.Storages.GetAsync(id);
                response.Data = result.MapTo<StorageDto>();
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

        public async Task<ResponsePagination<List<StorageDto>>> GetAllWithPaginationByMediaServerAsync(int mediaServerId, int page, int take)
        {
            var response = new ResponsePagination<List<StorageDto>>();
            try
            {
                var result = await _unitOfWork.Storages.GetAllWithPaginationByExpressionAsync(page, take, "Id", true, x => x.MediaServerId == mediaServerId);
                response.Data = result.Items.MapTo<List<StorageDto>>();
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


        public Response<object> Create(StorageDto storageDto)
        {
            var response = new Response<object>();
            try
            {
                var storage = storageDto.MapTo<Storage>();
                _unitOfWork.Storages.Add(storage);
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

        public Response<object> CreateList(List<StorageDto> list)
        {
            var response = new Response<object>();
            try
            {
                var mediaServers = list.MapTo<List<Storage>>();
                _unitOfWork.Storages.AddList(mediaServers);
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

        public Response<object> Update(StorageDto storageDto)
        {
            var response = new Response<object>();
            try
            {
                var storage = storageDto.MapTo<Storage>();
                _unitOfWork.Storages.Update(storage);
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
                _unitOfWork.VideoProfiles.DeleteByExpression(it=>it.Video.StorageId==id);
                _unitOfWork.Videos.DeleteByExpression(it => it.StorageId == id);
                _unitOfWork.Storages.Delete(id);
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
                _unitOfWork.Storages.DeleteByExpression(x => listIds.Contains(x.Id));
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
