using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
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

        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpGet("GetUserData")]
        public async Task<ActionResult> GetUserData()
        {
            var claim = User.FindFirst(ClaimTypes.NameIdentifier);
            if (claim == null)
            {
                return BadRequest();
            }
            var username = claim.Value;
            var response = await _userService.GetAsync(username);
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


    }

}
