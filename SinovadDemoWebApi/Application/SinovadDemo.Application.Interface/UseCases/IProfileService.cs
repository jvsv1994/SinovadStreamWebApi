using SinovadDemo.Application.DTO.Profile;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IProfileService {
    
        Task<Response<ProfileDto>> GetAsync(int id);
        Task<Response<ProfileDto>> GetByGuidAsync(string guid);
        Task<Response<List<ProfileDto>>> GetAllAsync(int userId);
        Task<ResponsePagination<List<ProfileDto>>> GetAllWithPaginationAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<ProfileDto>> CreateAsync(int userId,ProfileCreationDto profileDto);
        Task<Response<object>> UpdateAsync(int profileId,ProfileCreationDto profileDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<bool> CheckIfExistAsync(int id);

    }

}
