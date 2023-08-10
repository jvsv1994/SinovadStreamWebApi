using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITvSerieService
    {
        Task<Response<List<TvSerieDto>>> GetAllAsync();
        Task<ResponsePagination<List<TvSerieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<TvSerieDto>> GetAsync(int id);
        Task<Response<TvSerieDto>> SearchAsync(string query);
        Response<object> Create(TvSerieDto tvSerieDto);
        Response<object> Update(TvSerieDto tvSerieDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);

    }

}
