using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMovieService
    {
        Task<Response<List<MovieDto>>> GetAllAsync();
        Task<ResponsePagination<List<MovieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<MovieDto>> GetAsync(int id);
        Task<Response<object>> CreateAsync(MovieDto movieDto);
        Task<Response<object>> UpdateAsync(MovieDto movieDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);
    }

}
