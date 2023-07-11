using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IGenreService
    {
        Task<Response<GenreDto>> GetAsync(int id);
        Task<Response<List<GenreDto>>> GetAllAsync();
        Task<ResponsePagination<List<GenreDto>>> GetAllWithPaginationAsync(int page, int take);
        Response<object> Create(GenreDto genreDto);
        Response<object> CreateList(List<GenreDto> listGenreDto);
        Response<object> Update(GenreDto genreDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
        Response<object> CheckAndRegisterGenres();
    }

}
