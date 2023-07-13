using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITranscoderSettingsService
    {
        Task<Response<TranscoderSettingsDto>> GetAsync(int id);
        Task<Response<TranscoderSettingsDto>> GetByMediaServerAsync(int mediaServerId);
        Task<ResponsePagination<List<TranscoderSettingsDto>>> GetAllWithPaginationByMediaServerAsync(int mediaServerId, int page, int take);
        Response<object> Create(TranscoderSettingsDto transcoderSettingsDto);
        Response<object> CreateList(List<TranscoderSettingsDto> listTranscoderSettingsDto);
        Response<object> Update(TranscoderSettingsDto transcoderSettingsDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
