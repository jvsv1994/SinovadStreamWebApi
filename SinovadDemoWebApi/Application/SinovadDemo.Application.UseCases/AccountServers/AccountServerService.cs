using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Shared;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.AccountServers
{

    public class AccountServerService : IAccountServerService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SharedService _sharedService;

        public AccountServerService(IUnitOfWork unitOfWork, SharedService sharedService)
        {
            _unitOfWork = unitOfWork;
            _sharedService = sharedService;
        }

        public async Task<Response<AccountServerDto>> GetAsync(int id)
        {
            var response = new Response<AccountServerDto>();
            try
            {
                var accountServer = await _unitOfWork.AccountServers.GetAsync(id);
                response.Data = accountServer.MapTo<AccountServerDto>();
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

        public async Task<Response<AccountServerDto>> GetByAccountAndIpAddressAsync(string accountId, string ipAddress)
        {
            var response = new Response<AccountServerDto>();
            try
            {
                var result = await _unitOfWork.AccountServers.GetByExpressionAsync(x => x.IpAddress == ipAddress && x.AccountId == accountId);
                response.Data = result.MapTo<AccountServerDto>();
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


        public async Task<ResponsePagination<List<AccountServerDto>>> GetAllWithPaginationByAccountAsync(string accountId, int page, int take)
        {
            var response = new ResponsePagination<List<AccountServerDto>>();
            try
            {
                var result = await _unitOfWork.AccountServers.GetAllWithPaginationByExpressionAsync(page, take, "Id", true, x => x.AccountId == accountId);
                response.Data = result.Items.MapTo<List<AccountServerDto>>();
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

        public Response<object> Create(AccountServerDto accountServerDto)
        {
            var response = new Response<object>();
            try
            {
                var accountServer = accountServerDto.MapTo<AccountServer>();
                _unitOfWork.AccountServers.Add(accountServer);
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

        public Response<object> CreateList(List<AccountServerDto> listAccountServerDto)
        {
            var response = new Response<object>();
            try
            {
                var accountServers = listAccountServerDto.MapTo<List<AccountServer>>();
                _unitOfWork.AccountServers.AddList(accountServers);
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

        public Response<object> Update(AccountServerDto accountServerDto)
        {
            var response = new Response<object>();
            try
            {
                var accountServer = accountServerDto.MapTo<AccountServer>();
                _unitOfWork.AccountServers.Update(accountServer);
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
                _unitOfWork.AccountServers.Delete(id);
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
                _unitOfWork.AccountServers.DeleteByExpression(x => listIds.Contains(x.Id));
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
