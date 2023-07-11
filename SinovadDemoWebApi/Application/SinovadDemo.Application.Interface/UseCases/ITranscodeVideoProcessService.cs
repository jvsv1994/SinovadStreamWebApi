using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITranscodeVideoProcessService
    {
        Task<Response<TranscodeVideoProcessDto>> GetAsync(int id);
        Task<Response<List<TranscodeVideoProcessDto>>> GetAllByAccountServerAsync(int accountServerId);
        Task<Response<List<TranscodeVideoProcessDto>>> GetAllByListGuidsAsync(string guids);
        Response<object> Create(TranscodeVideoProcessDto transcodeVideoProcessDto);
        Response<object> CreateList(List<TranscodeVideoProcessDto> listTranscodeVideoProcessDto);
        Response<object> Update(TranscodeVideoProcessDto transcodeVideoProcessDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
        Response<object> DeleteByListGuids(string guids);

    }

}
