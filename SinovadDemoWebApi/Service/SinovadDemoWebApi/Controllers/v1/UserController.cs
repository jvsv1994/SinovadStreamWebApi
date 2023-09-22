using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;
using System.Security.Claims;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiVersion("1.0",Deprecated = false)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetUserData")]
        public async Task<ActionResult<Response<UserSessionDto>>> GetUserData()
        {
            var claim = HttpContext.User.Claims.Where(claim => claim.Type == ClaimTypes.NameIdentifier || claim.Type== ClaimTypes.Sid).FirstOrDefault();
            if (claim != null)
            {
                Response<UserSessionDto> response = null;
                if (claim.Type == ClaimTypes.NameIdentifier)
                {
                    response = await _userService.GetUserByGuid(claim.Value);
                }
                if (claim.Type == ClaimTypes.Sid)
                {
                    response = await _userService.GetUserByMediaServerSecurityIdentifier(claim.Value);
                }
                if (!response.IsSuccess)
                {
                    return BadRequest(response.Message);
                }
                return response;
            }else{
                return BadRequest();
            }
        }

        [HttpPost("ValidateConfirmEmailToken")]
        [AllowAnonymous]
        public async Task<ActionResult> ValidateConfirmEmailToken([FromBody] ValidateConfirmEmailTokenDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.ValidateConfirmEmailToken(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("RecoverPassword")]
        [AllowAnonymous]
        public async Task<ActionResult> RecoverPassword([FromBody] RecoverPasswordDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.RecoverPassword(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpPost("ValidateResetPasswordToken")]
        [AllowAnonymous]
        public async Task<ActionResult> ValidateResetPasswordToken([FromBody] ValidateResetPasswordTokenDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.ValidateResetPasswordToken(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("ResetPassword")]
        [AllowAnonymous]
        public async Task<ActionResult> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.ResetPassword(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("ChangeNames")]
        public async Task<ActionResult> ChangeNames([FromBody] ChangeNamesDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.ChangeNames(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("ChangeUserName")]
        public async Task<ActionResult> ChangeUserName([FromBody] ChangeUserNameDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.ChangeUserName(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.ChangePassword(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpPost("SetPassword")]
        public async Task<ActionResult> SetPassword([FromBody] SetPasswordDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.SetPassword(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


        [HttpGet("GetAsync/{userId}")]
        public async Task<ActionResult<Response<UserDto>>> GetAsync([FromRoute] int userId)
        {
            var response = await _userService.GetAsync(userId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpGet("GetUserWithRolesAsync/{userId}")]
        public async Task<ActionResult<Response<UserWithRolesDto>>> GetUserWithRolesAsync([FromRoute] int userId)
        {
            var response = await _userService.GetUserWithRolesAsync(userId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPut("UpdateUserRolesAsync/{userId}")]
        public async Task<ActionResult> UpdateUserRolesAsync([FromRoute] int userId,[FromBody] List<UserRoleDto> userRoles)
        {
            var exists= await _userService.CheckIfExistAsync(userId);
            if(!exists)
            {
                return NotFound("Usuario no encontrado");
            }
            var response = await _userService.UpdateUserRolesAsync(userId, userRoles);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult<ResponsePagination<List<UserDto>>>> GetAllWithPaginationAsync(int page = 1, int take = 1000, string sortBy = "Id", string sortDirection = "asc", string searchText = "", string searchBy = "")
        {
            var response = await _userService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpDelete("DeleteAsync/{userId}")]
        public async Task<ActionResult> DeleteAsync([FromRoute]int userId)
        {
            var response = await _userService.DeleteAsync(userId);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

    }

}
