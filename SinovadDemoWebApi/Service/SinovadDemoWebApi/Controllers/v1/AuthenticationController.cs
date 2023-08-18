using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Interface.UseCases;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    [Authorize]
    [ApiVersion("1.0",Deprecated = true)]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;


        public AuthenticationController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("AuthenticatePasswordAndConfirmLinkAccountToUser")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticatePasswordAndConfirmLinkAccountToUser([FromBody] ConfirmLinkAccountDto confirmLinkAccount)
        {
            if (confirmLinkAccount == null)
            {
                return BadRequest();
            }
            var response = await _authenticationService.AuthenticatePasswordAndConfirmLinkAccountToUser(confirmLinkAccount);
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

        [HttpPost("AuthenticateLinkedAccount")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateLinkedAccount([FromBody] AuthenticateLinkedAccountRequestDto linkedAccount)
        {
            if (linkedAccount == null)
            {
                return BadRequest();
            }
            var response = await _authenticationService.AuthenticateLinkedAccount(linkedAccount);
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

        [HttpPost("AuthenticateMediaServer")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateMediaServer([FromBody] string sid)
        {
            if (sid == null)
            {
                return BadRequest();
            }
            var response = await _authenticationService.AuthenticateMediaServer(sid);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    return Ok(response);
                }else{
                    return NotFound(response);
                }
            }
            return BadRequest(response);
        }

        [HttpPost("AuthenticateUser")]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticateUser([FromBody] AccessUserDto dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }
            var response = await _authenticationService.AuthenticateUser(dto);
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

        [HttpPost("ValidateUser")]
        [AllowAnonymous]
        public async Task<ActionResult> ValidateUser([FromBody] AccessUserDto dto)
        {
            var response = await _authenticationService.ValidateUser(dto.UserName);
            if (response.IsSuccess)
            {
                if (response.Data==true)
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
    }

}
