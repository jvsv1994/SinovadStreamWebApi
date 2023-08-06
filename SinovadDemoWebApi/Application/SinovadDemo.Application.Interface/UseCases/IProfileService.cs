using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IProfileService {
    
        Task<Response<ProfileDto>> GetAsync(int id);
        Task<Response<ProfileDto>> GetByGuidAsync(string guid);
        Task<ResponsePagination<List<ProfileDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(ProfileDto profileDto);
        Response<object> CreateList(List<ProfileDto> listProfileDto);
        Response<object> Update(ProfileDto profileDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
