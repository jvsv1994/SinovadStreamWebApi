using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IStorageService
    {
        Task<Response<StorageDto>> GetAsync(int id);
        Task<ResponsePagination<List<StorageDto>>> GetAllWithPaginationByMediaServerAsync(int mediaServerId, int page, int take);
        Response<object> Create(StorageDto storageDto);
        Response<object> CreateList(List<StorageDto> listStorageDto);
        Response<object> Update(StorageDto storageDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
