using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Role;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/roles")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0",Deprecated = false)]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAsync/{roleId:int}",Name = "getRole")]
        public async Task<ActionResult<Response<RoleDto>>> GetAsync([FromRoute]int roleId)
        {
            var response = await _roleService.GetAsync(roleId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<RoleDto>>>> GetAllWithPaginationAsync(int page = 1, int take = 1000,string sortBy = "Id",string sortDirection = "asc", string searchText = "", string searchBy = "")
        {
            var response = await _roleService.GetAllWithPaginationAsync(page,take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] RoleCreationDto dto)
        {
            var response = await _roleService.CreateAsync(dto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getRole", new { roleId = response.Data.Id }, response.Data);
        }

        [HttpPut("UpdateAsync/{roleId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int roleId,[FromBody] RoleCreationDto roleDto)
        {
            var exists=await _roleService.CheckIfExistAsync(roleId);
            if(!exists)
            {
                return NotFound("El rol no existe");
            }
            var response = await _roleService.UpdateAsync(roleId, roleDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{roleId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int roleId)
        {
            var response = await _roleService.DeleteAsync(roleId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync([FromRoute] string listIds)
        {
            var response = await _roleService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }


        [HttpGet("GetRoleWithMenusAsync/{roleId}")]
        public async Task<ActionResult<Response<RoleWithMenusDto>>> GetRoleWithMenusAsync([FromRoute] int roleId)
        {
            var response = await _roleService.GetRoleWithMenusAsync(roleId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPut("UpdateRoleMenusAsync/{roleId}")]
        public async Task<ActionResult> UpdateRoleMenusAsync([FromRoute] int roleId, [FromBody] List<RoleMenuDto> roleMenus)
        {
            var exists = await _roleService.CheckIfExistAsync(roleId);
            if (!exists)
            {
                return NotFound("Usuario no encontrado");
            }
            var response = await _roleService.UpdateRoleMenusAsync(roleId, roleMenus);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }
    }

}
