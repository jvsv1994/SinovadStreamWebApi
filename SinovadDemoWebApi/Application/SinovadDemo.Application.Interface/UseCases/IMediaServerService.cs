using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMediaServerService
    {
        Task<Response<MediaServerDto>> GetAsync(int id);
        Task<Response<MediaServerDto>> GetBySecurityIdentifierAsync(string securityIdentifier);
        Task<Response<MediaServerDto>> GetByGuidAsync(string guid);
        Task<Response<MediaServerDto>> GetByUserAndIpAddressAsync(int userId, string ipAddress);
        Task<Response<List<MediaServerDto>>> GetAllByUserAsync(int userId);
        Task<ResponsePagination<List<MediaServerDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Task<Response<MediaServerDto>> CreateAsync(MediaServerCreationDto mediaServerDto);
        Task<Response<MediaServerDto>> UpdateAsync(int mediaServerId,MediaServerCreationDto mediaServerCreationDto);
        Task<Response<object>> DeleteAsync(int id);
        Task<bool> CheckIfExistsAsync(int mediaServerId);
    }

}
