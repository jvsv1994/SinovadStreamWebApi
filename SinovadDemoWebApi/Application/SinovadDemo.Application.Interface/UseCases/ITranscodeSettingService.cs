using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITranscodeSettingService
    {
        Task<Response<TranscodeSettingDto>> GetAsync(int id);
        Task<Response<TranscodeSettingDto>> GetByAccountServerAsync(int accountServerid);
        Task<ResponsePagination<List<TranscodeSettingDto>>> GetAllWithPaginationByAccountServerAsync(int accountServerId, int page, int take);
        Response<object> Create(TranscodeSettingDto transcodeSettingDto);
        Response<object> CreateList(List<TranscodeSettingDto> listTranscodeSettingDto);
        Response<object> Update(TranscodeSettingDto transcodeSettingDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
