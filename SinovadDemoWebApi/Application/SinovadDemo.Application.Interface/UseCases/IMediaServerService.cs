using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMediaServerService
    {
        Task<Response<MediaServerDto>> GetAsync(int id);
        Task<Response<MediaServerDto>> GetBySecurityIdentifierAsync(string securityIdentifier);
        Task<Response<string>> AuthenticateBySecurityIdentifierAsync(string securityIdentifier);
        Task<Response<MediaServerDto>> GetByGuidAsync(string guid);
        Task<Response<MediaServerDto>> GetByUserAndIpAddressAsync(int userId, string ipAddress);
        Task<Response<List<MediaServerDto>>> GetAllByUserAsync(int userId);
        Task<ResponsePagination<List<MediaServerDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take, string sortBy, string sortDirection, string searchText, string searchBy);
        Response<object> Create(MediaServerDto mediaServerDto);
        Response<object> CreateList(List<MediaServerDto> listMediaServerDto);
        Response<object> Update(MediaServerDto mediaServerDto);
        Task<Response<MediaServerDto>> Save(MediaServerDto mediaServerDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
