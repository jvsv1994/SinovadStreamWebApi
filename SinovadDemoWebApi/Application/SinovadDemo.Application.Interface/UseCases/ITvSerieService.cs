using SinovadDemo.Application.DTO.TvSerie;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITvSerieService
    {
        Task<Response<List<TvSerieDto>>> GetAllAsync();
        Task<ResponsePagination<List<TvSerieDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<TvSerieWithGenresDto>> GetAsync(int id);
        Task<Response<TvSerieWithGenresDto>> SearchAsync(string query);
        Task<Response<TvSerieDto>> CreateAsync(TvSerieCreationDto tvSerieDto);
        Task<Response<object>> UpdateAsync(int id,TvSerieCreationDto tvSerieDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);

    }

}
