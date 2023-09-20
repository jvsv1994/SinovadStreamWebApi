using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.Profile;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;
using System.ComponentModel.DataAnnotations;

namespace SinovadDemoWebApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/users/{userId:int}/profiles")]
    [Authorize]
    [ApiVersion("1.0", Deprecated = false)]
    public class ProfileController : Controller
    {
        private readonly IProfileService _profileService;
        private readonly IUserService _userService;

        public ProfileController(IProfileService profileService, IUserService userService)
        {
            _profileService = profileService;
            _userService = userService;
        }

        [HttpGet("GetAsync/{profileId}",Name ="getProfile")]
        public async Task<ActionResult<Response<ProfileDto>>> GetAsync([FromRoute] int userId,[FromRoute]int profileId)
        {
            var exists = await _userService.CheckIfExistAsync(userId);
            if (!exists)
            {
                return NotFound("El usuario no existe");
            }
            var response = await _profileService.GetAsync(profileId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetByGuidAsync/{guid}")]
        public async Task<ActionResult<Response<ProfileDto>>> GetByGuidAsync([FromRoute] int userId,[FromRoute][Required] string guid)
        {
            var exists = await _userService.CheckIfExistAsync(userId);
            if (!exists)
            {
                return NotFound("El usuario no existe");
            }
            var response = await _profileService.GetByGuidAsync(guid);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message); ;
            }
            return response;
        }


        [HttpGet("GetAllAsync")]
        public async Task<ActionResult<Response<List<ProfileDto>>>> GetAllAsync([FromRoute] int userId)
        {
            var response = await _profileService.GetAllAsync(userId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<ProfileDto>>>> GetAllWithPaginationAsync([FromRoute]int userId,[FromQuery] int page = 1,[FromQuery] int take = 1000, [FromQuery] string sortBy = "Id", 
            [FromQuery] string sortDirection = "asc", [FromQuery] string searchText = "", [FromQuery] string searchBy = "")
        {
            var response = await _profileService.GetAllWithPaginationAsync(userId, page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("CreateAsync")]
        public async Task<ActionResult> CreateAsync([FromRoute] int userId,[FromBody] ProfileCreationDto profileCreationDto)
        {
            var exists = await _userService.CheckIfExistAsync(userId);
            if (!exists)
            {
                return NotFound("El usuario no existe");
            }
            var response = await _profileService.CreateAsync(userId,profileCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return CreatedAtRoute("getProfile", new {userId=response.Data.UserId,profileId = response.Data.Id }, response.Data);
        }

        [HttpPut("UpdateAsync/{profileId:int}")]
        public async Task<ActionResult> UpdateAsync([FromRoute] int userId, [FromRoute] int profileId, [FromBody] ProfileCreationDto profileCreationDto)
        {
            var existsUser = await _userService.CheckIfExistAsync(userId);
            if (!existsUser)
            {
                return NotFound("El usuario no existe");
            }
            var exists=await _profileService.CheckIfExistAsync(profileId);
            if(!exists)
            {
                return NotFound("El perfil no existe");
            }
            var response =await _profileService.UpdateAsync(profileId, profileCreationDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpDelete("DeleteAsync/{profileId:int}")]
        public async Task<ActionResult> DeleteAsync([FromRoute] int userId, [FromRoute] int profileId)
        {
            var existsUser = await _userService.CheckIfExistAsync(userId);
            if (!existsUser)
            {
                return NotFound("El usuario no existe");
            }
            var response = await _profileService.DeleteAsync(profileId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }
}
