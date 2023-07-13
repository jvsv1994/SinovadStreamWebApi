﻿using SinovadDemo.Application.DTO;
using SinovadDemo.Transversal.Collection;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.Interface.UseCases
{
    public interface IMediaServerService
    {
        Task<Response<MediaServerDto>> GetAsync(int id);
        Task<Response<MediaServerDto>> GetByUserAndIpAddressAsync(int userId, string ipAddress);
        Task<ResponsePagination<List<MediaServerDto>>> GetAllWithPaginationByUserAsync(int userId, int page, int take);
        Response<object> Create(MediaServerDto mediaServerDto);
        Response<object> CreateList(List<MediaServerDto> listMediaServerDto);
        Response<object> Update(MediaServerDto mediaServerDto);
        Response<object> Delete(int id);
        Response<object> DeleteList(string ids);
    }

}
