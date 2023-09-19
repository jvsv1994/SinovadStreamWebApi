using SinovadDemo.Application.DTO.Season;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ISeasonService
    {
        Task<Response<SeasonDto>> GetTvSeasonAsync(int tvSerieId,int seasonNumber);
        Task<Response<SeasonDto>> GetAsync(int id);
        Task<ResponsePagination<List<SeasonDto>>> GetAllWithPaginationByTvSerieAsync(int tvSerieId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<SeasonDto>> CreateAsync(int tvSerieId,SeasonCreationDto seasonDto);
        Task<Response<object>> UpdateAsync(int seasonId, SeasonCreationDto seasonDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);

    }

}
