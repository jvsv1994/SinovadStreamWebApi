using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ISeasonService
    {
        Task<Response<SeasonDto>> GetTvSeasonAsync(int tvSerieId,int seasonNumber);
        Task<Response<SeasonDto>> GetAsync(int id);
        Task<ResponsePagination<List<SeasonDto>>> GetAllWithPaginationByTvSerieAsync(int tvSerieId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(SeasonDto seasonDto);
        Response<object> Update(SeasonDto seasonDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
