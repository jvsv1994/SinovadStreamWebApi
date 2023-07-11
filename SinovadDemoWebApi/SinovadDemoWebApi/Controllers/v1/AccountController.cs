using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;
using System.Security.Claims;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/accounts")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0",Deprecated = true)]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _accountService.Register(dto);
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
            var response = await _accountService.GetAsync(username);
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
            var response = await _accountService.ValidateConfirmEmailToken(dto);
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
            var response = await _accountService.Login(dto);
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
            var response = await _accountService.RecoverPassword(dto);
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
            var response = await _accountService.ValidateResetPasswordToken(dto);
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
            var response = await _accountService.ResetPassword(dto);
            if (response.IsSuccess)
            {
                return Ok(response);
            }
            return BadRequest(response.Message);
        }


    }

}
