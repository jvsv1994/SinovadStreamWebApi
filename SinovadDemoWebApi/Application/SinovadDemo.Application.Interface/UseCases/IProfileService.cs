using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IProfileService {
    
        Task<Response<ProfileDto>> GetAsync(int id);
        Task<ResponsePagination<List<ProfileDto>>> GetAllWithPaginationByAccountAsync(string accountId, int page, int take);
        Response<object> Create(ProfileDto profileDto);
        Response<object> CreateList(List<ProfileDto> listProfileDto);
        Response<object> Update(ProfileDto profileDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
