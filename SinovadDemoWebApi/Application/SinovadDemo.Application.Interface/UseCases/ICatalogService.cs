using SinovadDemo.Application.DTO.Catalog;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ICatalogService
    {
        #region catalogs
        Task<Response<CatalogDto>> GetAsync(int id);
        Task<ResponsePagination<List<CatalogDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<CatalogDto>> CreateAsync(CatalogCreationDto catalogDto);
        Task<Response<object>> UpdateAsync(int catalogId,CatalogCreationDto catalogDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckIfExistsAsync(int catalogId);


        #endregion

        #region catalog details
        Task<Response<CatalogDetailDto>> GetCatalogDetailAsync(int catalogId, int catalogDetailId);
        Task<Response<List<CatalogDetailDto>>> GetDetailsByCatalogAsync(int catalogId);
        Task<Response<List<CatalogDetailDto>>> GetAllCatalogDetailsByCatalogIds(string catalogIds);
        Task<ResponsePagination<List<CatalogDetailDto>>> GetAllCatalogDetailsWithPaginationByCatalogIdsAsync(string catalogIds, int page, int take);

        #endregion

    }
}
