using SinovadDemo.Application.DTO.Episode;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IEpisodeService
    {
        Task<Response<EpisodeDto>> GetTvEpisodeAsync(int tvSerieId, int seasonNumber, int episodeNumber);
        Task<Response<EpisodeDto>> GetAsync(int id);
        Task<Response<List<EpisodeDto>>> GetAllAsync();
        Task<ResponsePagination<List<EpisodeDto>>> GetAllWithPaginationBySeasonAsync(int seasonId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<EpisodeDto>> CreateAsync(int seasonId, EpisodeCreationDto episodeDto);
        Task<Response<object>> CreateListAsync(int seasonId,List<EpisodeCreationDto> listEpisodeDto);
        Task<Response<object>> UpdateAsync(int episodeId,EpisodeCreationDto episodeDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<Response<object>> DeleteListAsync(string ids);
        Task<bool> CheckExistAsync(int id);
    }

}
