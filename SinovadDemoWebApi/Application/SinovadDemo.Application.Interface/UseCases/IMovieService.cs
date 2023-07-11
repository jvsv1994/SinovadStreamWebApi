using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMovieService
    {
        Task<Response<List<MovieDto>>> GetAllAsync();
        Task<ResponsePagination<List<MovieDto>>> GetAllWithPaginationAsync(int page, int take);
        Task<Response<MovieDto>> GetAsync(int id);
        Response<object> Create(MovieDto movieDto);
        Response<object> Update(MovieDto movieDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
