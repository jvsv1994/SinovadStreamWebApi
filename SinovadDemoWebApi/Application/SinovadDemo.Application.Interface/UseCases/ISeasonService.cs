using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ISeasonService
    {
        Task<Response<SeasonDto>> GetAsync(int id);
        Task<ResponsePagination<List<SeasonDto>>> GetAllWithPaginationByTvSerieAsync(int tvSerieId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(SeasonDto seasonDto);
        Response<object> Update(SeasonDto seasonDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
