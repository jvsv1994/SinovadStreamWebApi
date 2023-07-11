using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.AccountStorages
{
    public class AccountStorageService : IAccountStorageService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public AccountStorageService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<AccountStorageDto>> GetAsync(int id)
        {
            var response = new Response<AccountStorageDto>();
            try
            {
                var result = await _unitOfWork.AccountStorages.GetAsync(id);
                response.Data = result.MapTo<AccountStorageDto>();
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

        public async Task<ResponsePagination<List<AccountStorageDto>>> GetAllWithPaginationByAccountServerAsync(int accountServerId, int page, int take)
        {
            var response = new ResponsePagination<List<AccountStorageDto>>();
            try
            {
                var result = await _unitOfWork.AccountStorages.GetAllWithPaginationByExpressionAsync(page, take, "Id", true, x => x.AccountServerId == accountServerId);
                response.Data = result.Items.MapTo<List<AccountStorageDto>>();
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


        public Response<object> Create(AccountStorageDto accountStorageDto)
        {
            var response = new Response<object>();
            try
            {
                var accountStorage = accountStorageDto.MapTo<AccountStorage>();
                _unitOfWork.AccountStorages.Add(accountStorage);
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

        public Response<object> CreateList(List<AccountStorageDto> list)
        {
            var response = new Response<object>();
            try
            {
                var accountServers = list.MapTo<List<AccountStorage>>();
                _unitOfWork.AccountStorages.AddList(accountServers);
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

        public Response<object> Update(AccountStorageDto accountStorageDto)
        {
            var response = new Response<object>();
            try
            {
                var accountStorage = accountStorageDto.MapTo<AccountStorage>();
                _unitOfWork.AccountStorages.Update(accountStorage);
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
                _unitOfWork.VideoProfiles.DeleteByExpression(it=>it.Video.AccountStorageId==id);
                _unitOfWork.Videos.DeleteByExpression(it => it.AccountStorageId == id);
                _unitOfWork.AccountStorages.Delete(id);
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
                _unitOfWork.AccountStorages.DeleteByExpression(x => listIds.Contains(x.Id));
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
