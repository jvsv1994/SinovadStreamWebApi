using AutoMapper;
using Generic.Core.Models;
using SinovadDemo.Application.DTO.Role;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Roles
{
    public class RoleService : IRoleService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IAppLogger<RoleService> _logger;

        private readonly AutoMapper.IMapper _mapper;

        public RoleService(IUnitOfWork unitOfWork, IAppLogger<RoleService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<RoleDto>> GetAsync(int roleId)
        {
            var response = new Response<RoleDto>();
            try
            {
                var result = await _unitOfWork.Roles.GetAsync(roleId);
                response.Data = _mapper.Map<RoleDto>(result);
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
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

        public async Task<Response<RoleDto>> CreateAsync(RoleCreationDto dto)
        {
            var response = new Response<RoleDto>();
            try
            {
                var entity = _mapper.Map<Role>(dto);
                var role=await _unitOfWork.Roles.AddAsync(entity);
                await _unitOfWork.SaveAsync();
                response.Data = _mapper.Map<RoleDto>(role);
                response.IsSuccess = true;
            } catch (Exception ex){
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateAsync(int roleId,RoleCreationDto roleCreationDto)
        {
            var response = new Response<object>();
            try
            {
                var role =await _unitOfWork.Roles.GetAsync(roleId);
                role = _mapper.Map(roleCreationDto, role);
                _unitOfWork.Roles.Update(role);
                await _unitOfWork.SaveAsync();
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

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.Roles.Delete(id);
                await _unitOfWork.SaveAsync();
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

        public async Task<Response<object>> DeleteListAsync(string ids)
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
                await _unitOfWork.SaveAsync();
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

        public async Task<bool> CheckIfExistAsync(int roleId)
        {
            return await _unitOfWork.Roles.CheckIfExistAsync(role=>role.Id==roleId);
        }


        public async Task<Response<RoleWithMenusDto>> GetRoleWithMenusAsync(int roleId)
        {
            var response = new Response<RoleWithMenusDto>();
            try
            {
                var role = await _unitOfWork.Roles.GetRoleWithMenusAsync(role => role.Id == roleId);
                var roleWithMenus = _mapper.Map<RoleWithMenusDto>(role);
                var menuIds = roleWithMenus.RoleMenus.Select(roleMenu => roleMenu.MenuId);
                var menusToAdd = await _unitOfWork.Menus.GetAllByExpressionAsync(menu => !menuIds.Contains(menu.Id));
                foreach (var menu in menusToAdd)
                {
                    roleWithMenus.RoleMenus.Add(new RoleMenuDto() { MenuId = menu.Id, MenuTitle = menu.Title, Enabled = false ,AllowCreate = false ,AllowRead =false, AllowUpdate =false, AllowDelete=false });
                }
                response.Data = roleWithMenus;
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> UpdateRoleMenusAsync(int roleId, List<RoleMenuDto> roleMenus)
        {
            var response = new Response<object>();
            try
            {
                var role = await _unitOfWork.Roles.GetRoleWithMenusAsync(role => role.Id == roleId);
                role.RoleMenus = _mapper.Map<List<RoleMenu>>(roleMenus);
                _unitOfWork.Roles.Update(role);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }


    }
}
