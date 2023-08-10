﻿using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IEpisodeService
    {
        Task<Response<EpisodeDto>> GetTvEpisodeAsync(int tvSerieId, int seasonNumber, int episodeNumber);
        Task<Response<EpisodeDto>> GetAsync(int id);
        Task<Response<List<EpisodeDto>>> GetAllAsync();
        Task<ResponsePagination<List<EpisodeDto>>> GetAllWithPaginationBySeasonAsync(int seasonId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(EpisodeDto episodeDto);
        Response<object> CreateList(List<EpisodeDto> listEpisodeDto);
        Response<object> Update(EpisodeDto episodeDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
