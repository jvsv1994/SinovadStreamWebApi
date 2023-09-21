using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Menu;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/menus")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;

        public MenuController(IMenuService userService)
        {
            _menuService = userService;
        }
        [HttpGet("GetByUserAsync/{userId}")]
        public async Task<ActionResult<Response<List<MenuDto>>>> GetByUserAsync([FromRoute]int userId)
        {
            var response = await _menuService.GetListMenusByUserAsync(userId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAsync/{menuId:int}")]
        public async Task<ActionResult<Response<MenuDto>>> GetAsync([FromRoute]int menuId)
        {
            var response = await _menuService.GetAsync(menuId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<Response<List<MenuDto>>>> GetAllAsync()
        {
            var response = await _menuService.GetAllAsync();
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<MenuDto>>>> GetAllWithPaginationAsync([FromQuery] int page = 1, [FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _menuService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromBody] MenuCreationDto menuCreationDto)
        {
            var response = await _menuService.CreateAsync(menuCreationDto);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getMenu",new { menuId=response.Data.Id},response.Data);
        }

        [HttpPut("UpdateAsync/{menuId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute]int menuId,[FromBody] MenuCreationDto menuCreationDto)
        {
            var exists = await _menuService.CheckIfExistsAsync(menuId);
            if(!exists)
            {
                return NotFound("El menu no existe");  
            }
            var response = await _menuService.UpdateAsync(menuId, menuCreationDto);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{menuId}")]
        public async Task<ActionResult> DeleteAsync(int menuId)
        {
            var response = await _menuService.DeleteAsync(menuId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteListAsync/{listIds}")]
        public async Task<ActionResult> DeleteListAsync(string listIds)
        {
            var response = await _menuService.DeleteListAsync(listIds);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent() ;
        }

    }

}
