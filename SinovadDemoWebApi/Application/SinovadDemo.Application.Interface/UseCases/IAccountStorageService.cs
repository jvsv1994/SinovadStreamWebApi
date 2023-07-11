using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IAccountStorageService
    {
        Task<Response<AccountStorageDto>> GetAsync(int id);
        Task<ResponsePagination<List<AccountStorageDto>>> GetAllWithPaginationByAccountServerAsync(int accountServerId, int page, int take);
        Response<object> Create(AccountStorageDto accountStorageDto);
        Response<object> CreateList(List<AccountStorageDto> listAccountStorageDto);
        Response<object> Update(AccountStorageDto accountStorageDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
