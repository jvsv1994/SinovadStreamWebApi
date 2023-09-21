using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO.Catalog;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ICatalogService
    {
        #region catalogs
        Task<Response<CatalogDto>> GetAsync(int id);
        Task<ResponsePagination<List<CatalogDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(CatalogDto catalogDto);
        Response<object> Update(CatalogDto catalogDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);

        #endregion

        #region catalog details
        Task<Response<CatalogDetailDto>> GetCatalogDetailAsync(int catalogId, int catalogDetailId);
        Task<Response<List<CatalogDetailDto>>> GetDetailsByCatalogAsync(int catalogId);
        Task<Response<List<CatalogDetailDto>>> GetAllCatalogDetailsByCatalogIds(string catalogIds);
        Task<ResponsePagination<List<CatalogDetailDto>>> GetAllCatalogDetailsWithPaginationByCatalogIdsAsync(string catalogIds, int page, int take);

        #endregion

    }
}
