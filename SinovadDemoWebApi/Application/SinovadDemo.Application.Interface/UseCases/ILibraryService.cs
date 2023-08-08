using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ILibraryService
    {
        Task<Response<LibraryDto>> GetAsync(int id);
        Task<ResponseGeneric<List<LibraryDto>>> GetAllLibrariesByUserAsync(int userId);
        Task<ResponsePagination<List<LibraryDto>>> GetAllWithPaginationByMediaServerAsync(int mediaServerId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(LibraryDto libraryDto);
        Response<object> CreateList(List<LibraryDto> listLibraryDto);
        Response<object> Update(LibraryDto libraryDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
