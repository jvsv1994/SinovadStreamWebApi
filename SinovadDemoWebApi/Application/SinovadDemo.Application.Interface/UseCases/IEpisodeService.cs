using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IEpisodeService
    {
        Task<Response<EpisodeDto>> GetAsync(int id);
        Task<ResponsePagination<List<EpisodeDto>>> GetAllWithPaginationBySeasonAsync(int seasonId, int page, int take);
        Response<object> Create(EpisodeDto episodeDto);
        Response<object> CreateList(List<EpisodeDto> listEpisodeDto);
        Response<object> Update(EpisodeDto episodeDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
