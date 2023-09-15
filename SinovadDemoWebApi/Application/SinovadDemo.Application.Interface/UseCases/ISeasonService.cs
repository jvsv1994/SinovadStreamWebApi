using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ISeasonService
    {
        Task<Response<SeasonDto>> GetTvSeasonAsync(int tvSerieId,int seasonNumber);
        Task<Response<SeasonDto>> GetAsync(int id);
        Task<ResponsePagination<List<SeasonDto>>> GetAllWithPaginationByTvSerieAsync(int tvSerieId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<object>> CreateAsync(SeasonDto seasonDto);
        Task<Response<object>> UpdateAsync(SeasonDto seasonDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);

    }

}
