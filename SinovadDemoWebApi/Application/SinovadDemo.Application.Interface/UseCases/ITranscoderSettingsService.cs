using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;
using System.Threading.Tasks;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITranscoderSettingsService
    {
        Task<Response<TranscoderSettingsDto>> GetAsync(int id);
        Task<Response<TranscoderSettingsDto>> GetByMediaServerGuidAsync(string guid);
        Task<Response<TranscoderSettingsDto>> GetByMediaServerAsync(int mediaServerId);
        Task<ResponsePagination<List<TranscoderSettingsDto>>> GetAllWithPaginationByMediaServerAsync(int mediaServerId, int page, int take);
        Response<object> Create(TranscoderSettingsDto transcoderSettingsDto);
        Response<object> CreateList(List<TranscoderSettingsDto> listTranscoderSettingsDto);
        Response<object> Update(TranscoderSettingsDto transcoderSettingsDto);
        Task<Response<TranscoderSettingsDto>> Save(TranscoderSettingsDto transcoderSettingsDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
