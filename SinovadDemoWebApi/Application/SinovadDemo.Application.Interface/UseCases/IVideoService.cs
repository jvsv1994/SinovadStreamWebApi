using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IVideoService
    {
        Response<object> UpdateVideoProfile(VideoProfileDto videoProfileDto);
        Response<object> UpdateVideosInListStorages(UpdateStorageVideosDto dto);
        Response<List<ItemsGroupDto>> GetVideosOrganized(string accountId, int profileId, bool searchMovies, bool searchTvSeries);
        Response<List<ItemDto>> GetVideosByFilters(string accountId, bool searchMovies, bool searchTvSeries, string searchText);
        Task<Response<ItemDetailDto>> GetMovieDetail(int movieId);
        Task<Response<ItemDetailDto>> GetMovieDataByAccount(string accountId,int movieId);
        Task<Response<ItemDetailDto>> GetTvSerieDetail(string accountId, int tvSerieId);
        Task<Response<ItemDetailDto>> GetTvSerieDataByAccount(string accountId, int tvSerieId);

    }
}
