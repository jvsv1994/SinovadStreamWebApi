using SinovadDemo.Application.DTO.Genre;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IGenreService
    {
        Task<Response<GenreDto>> GetAsync(int id);
        Task<Response<List<GenreDto>>> GetAllAsync();
        Task<ResponsePagination<List<GenreDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<GenreDto>> CreateAsync(GenreCreationDto genreDto);
        Task<Response<object>> CreateListAsync(List<GenreCreationDto> listGenreDto);
        Task<Response<object>> UpdateAsync(int genreId,GenreCreationDto genreDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);

    }

}
