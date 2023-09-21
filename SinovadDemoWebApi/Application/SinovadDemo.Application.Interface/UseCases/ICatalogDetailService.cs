using SinovadDemo.Application.DTO.Catalog;
using SinovadDemo.Application.DTO.CatalogDetail;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ICatalogDetailService
    {
        Task<Response<CatalogDetailDto>> GetAsync(int catalogId, int catalogDetailId);
        Task<ResponsePagination<List<CatalogDetailDto>>> GetAllWithPaginationAsync(int catalogId,int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<CatalogDetailDto>> CreateAsync(int catalogId,CatalogDetailCreationDto catalogDetaiLCreationDto);
        Task<Response<object>> UpdateAsync(int catalogId,int catalogDetailId, CatalogDetailCreationDto catalogDetaiLCreationDto);
        Task<Response<object>> DeleteAsync(int catalogId,int catalogDetailId);
        Task<Response<object>> DeleteListAsync(int catalogId,string ids);
        Task<bool> CheckIfExistsAsync(int catalogId, int catalogDetailId);
    }
}
