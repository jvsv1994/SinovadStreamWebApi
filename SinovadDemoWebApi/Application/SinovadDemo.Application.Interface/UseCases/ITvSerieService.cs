using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITvSerieService
    {
        Task<Response<List<TvSerieDto>>> GetAllAsync();
        Task<ResponsePagination<List<TvSerieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<TvSerieDto>> GetAsync(int id);
        Task<Response<TvSerieDto>> SearchAsync(string query);
        Task<Response<object>> CreateAsync(TvSerieDto tvSerieDto);
        Task<Response<object>> UpdateAsync(TvSerieDto tvSerieDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);


    }

}
