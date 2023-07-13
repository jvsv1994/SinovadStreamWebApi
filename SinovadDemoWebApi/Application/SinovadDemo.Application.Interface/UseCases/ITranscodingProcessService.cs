﻿using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface ITranscodingProcessService
    {
        Task<Response<TranscodingProcessDto>> GetAsync(int id);
        Task<Response<List<TranscodingProcessDto>>> GetAllByMediaServerAsync(int mediaServerId);
        Task<Response<List<TranscodingProcessDto>>> GetAllByListGuidsAsync(string guids);
        Response<object> Create(TranscodingProcessDto transcodingProcessDto);
        Response<object> CreateList(List<TranscodingProcessDto> listTranscodingProcessDto);
        Response<object> Update(TranscodingProcessDto transcodingProcessDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
        Response<object> DeleteByListGuids(string guids);

    }

}
