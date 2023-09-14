using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMovieService
    {
        Task<Response<List<MovieDto>>> GetAllAsync();
        Task<ResponsePagination<List<MovieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<MovieDto>> GetAsync(int id);
        Task<Response<object>> Create(MovieDto movieDto);
        Task<Response<object>> Update(MovieDto movieDto);
        Task<Response<object>> Delete(int id);
        Task<Response<object>> DeleteList(string ids);
    }

}
