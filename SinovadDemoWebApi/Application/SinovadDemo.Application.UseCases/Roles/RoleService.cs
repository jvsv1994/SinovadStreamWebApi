using Generic.Core.Models;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Roles
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;

        private readonly IAppLogger<RoleService> _logger;

        private readonly IOptions<MyConfig> _config;

        public RoleService(IUnitOfWork unitOfWork, IAppLogger<RoleService> logger, IOptions<MyConfig> config)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
        }
     
        public async Task<ResponsePagination<List<RoleDto>>> GetAllWithPaginationAsync(int page, int take)
        {
            var response = new ResponsePagination<List<RoleDto>>();
            try
            {
                var result = await _unitOfWork.Roles.GetAllWithPaginationAsync(page, take, "Id", false);
                response.Data = result.Items.MapTo<List<RoleDto>>();
                response.PageNumber = page;
                response.TotalPages = result.Pages;
                response.TotalCount = result.Total;
                response.IsSuccess = true;
                response.Message = "Successful";
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Create(RoleDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = dto.MapTo<Role>();
                _unitOfWork.Roles.Add(entity);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Update(RoleDto dto)
        {
            var response = new Response<object>();
            try
            {
                var entity = dto.MapTo<Role>();
                _unitOfWork.Roles.Update(entity);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }



    }
}
