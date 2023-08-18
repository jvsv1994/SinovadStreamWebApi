using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.UseCases.Movies;
using SinovadDemo.Domain.Enums;
using SinovadDemo.Transversal.Common;
using System.Security.Claims;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/users")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0",Deprecated = true)]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.Register(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPaginationAsync")]
        public async Task<ActionResult> GetAllWithPaginationAsync(int page = 1, int take = 1000, string sortBy = "Id", string sortDirection = "asc", string searchText = "", string searchBy = "")
        {
            var response = await _userService.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetUserData")]
        public async Task<ActionResult> GetUserData()
        {
            Response<UserDto> response = null;
            var claimUser = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claimUser != null)
            {
                response = await _userService.GetAsync(claimUser.Value);
            }else
            {
                var claimSID = User.FindFirst(ClaimTypes.Sid);
                if(claimSID != null)
                {
                  response = await _userService.GetUserByMediaServerSecurityIdentifier(claimSID.Value);
                }else{
                    var claimEmail = User.FindFirst(ClaimTypes.Email);
                    var LinkedAccountProvider = User.FindFirst("LinkedAccountProvider");
                    if (claimEmail != null && LinkedAccountProvider!=null)
                    {
                        response = await _userService.GetUserByLinkedAccountEmail(claimEmail.Value, Enum.Parse<LinkedAccountProvider>(LinkedAccountProvider.Value));
                    }
                }
            }
            if (response==null)
            {
                return BadRequest();
            }
            if (response.IsSuccess && response.Data!=null)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }

        [HttpGet("GetByIdAsync/{id}")]
        public async Task<ActionResult> GetByIdAsync([FromRoute] int id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            var response = await _userService.GetAsync(id);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
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

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] AccessUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _userService.Login(dto);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            return BadRequest(response);
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

        [HttpDelete("Delete/{userId}")]
        public ActionResult Delete(int userId)
        {
            var response = _userService.Delete(userId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


    }

}
