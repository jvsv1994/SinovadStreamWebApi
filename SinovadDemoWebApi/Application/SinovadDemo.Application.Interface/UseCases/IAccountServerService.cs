using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IAccountServerService
    {
        Task<Response<AccountServerDto>> GetAsync(int id);
        Task<Response<AccountServerDto>> GetByAccountAndIpAddressAsync(string accountId, string ipAddress);
        Task<ResponsePagination<List<AccountServerDto>>> GetAllWithPaginationByAccountAsync(string accountId, int page, int take);
        Response<object> Create(AccountServerDto accountServerDto);
        Response<object> CreateList(List<AccountServerDto> listAccountServerDto);
        Response<object> Update(AccountServerDto accountServerDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
