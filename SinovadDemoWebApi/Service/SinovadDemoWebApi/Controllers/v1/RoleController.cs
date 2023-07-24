using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/roles")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0",Deprecated = true)]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult> GetAllWithPaginationAsync(int page = 1, int take = 1000)
        {
            var response = await _roleService.GetAllWithPaginationAsync(page, take);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("Create")]
        public ActionResult Create([FromBody] RoleDto dto)
        {
            var response = _roleService.Create(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPut("Update")]
        public ActionResult Update([FromBody] RoleDto dto)
        {
            var response = _roleService.Update(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

    }

}
