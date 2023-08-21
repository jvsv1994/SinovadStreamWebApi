using Generic.Core.Models;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Roles
{
    public class RoleService : IRoleService
    {
        private IUnitOfWork _unitOfWork;

        private readonly IAppLogger<RoleService> _logger;

        private readonly IOptions<MyConfig> _config;

        private readonly AutoMapper.IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IAppLogger<RoleService> logger, IOptions<MyConfig> config, AutoMapper.IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
            _mapper = mapper;
        }
     
        public async Task<ResponsePagination<List<RoleDto>>> GetAllWithPaginationAsync(int page, int take,string sortBy,string sortDirection,string searchText,string searchBy)
        {
            var response = new ResponsePagination<List<RoleDto>>();
            try
            {
                var result = await _unitOfWork.Roles.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<RoleDto>>(result.Items);
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
                var entity = _mapper.Map<Role>(dto);
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
                var entity = _mapper.Map<Role>(dto);
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

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Roles.Delete(id);
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

        public Response<object> DeleteList(string ids)
        {
            var response = new Response<object>();
            try
            {
                List<int> listIds = new List<int>();
                if (!string.IsNullOrEmpty(ids))
                {
                    listIds = ids.Split(",").Select(x => Convert.ToInt32(x)).ToList();
                }
                _unitOfWork.Roles.DeleteByExpression(x => listIds.Contains(x.Id));
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
