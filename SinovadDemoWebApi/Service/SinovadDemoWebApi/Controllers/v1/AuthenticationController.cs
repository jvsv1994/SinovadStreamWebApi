using Microsoft.AspNetCore.Mvc;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Transversal.Common;

namespace SinovadDemoWebApi.Controllers.v1
{
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    [ApiVersion("1.0",Deprecated = false)]
    public class AuthenticationController : ControllerBase
    {

        private readonly IAuthenticationService _authenticationService;

        private readonly IFirebaseAuthService _firebaseAuthService;

        public AuthenticationController(IAuthenticationService authenticationService, IFirebaseAuthService firebaseAuthService)
        {
            _authenticationService = authenticationService;
            _firebaseAuthService = firebaseAuthService;
        }

        [HttpPost("ValidateUser")]
        public async Task<ActionResult> ValidateUser([FromBody] ValidateUserDto dto)
        {
            var response = await _authenticationService.ValidateUser(dto.UserName);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return NoContent();
        }

        [HttpPost("AuthenticateUser")]
        public async Task<ActionResult<Response<AuthenticationUserResponseDto>>> AuthenticateUser([FromBody] AuthenticateUserDto dto)
        {
            var response = await _authenticationService.AuthenticateUser(dto);
            if(!response.IsSuccess)
            { 
               return BadRequest(response);    
            }
            return response;
        }

        [HttpPost("AuthenticateLinkedAccount")]
        public async Task<ActionResult<Response<AuthenticationUserResponseDto>>> AuthenticateLinkedAccount([FromBody] AuthenticateLinkedAccountRequestDto linkedAccount)
        {
            var registerUserFromProviderDto=await _firebaseAuthService.ValidateCredentials(linkedAccount.AccessToken, linkedAccount.LinkedAccountProviderCatalogDetailId);
            if(registerUserFromProviderDto == null)
            {
                return BadRequest("Credenciales inválidas");
            }
            var response = await _authenticationService.AuthenticateLinkedAccount(registerUserFromProviderDto);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);     
            }
            return response;
        }

        [HttpPost("AuthenticatePasswordAndConfirmLinkAccountToUser")]
        public async Task<ActionResult<Response<AuthenticationUserResponseDto>>> AuthenticatePasswordAndConfirmLinkAccountToUser([FromBody] ConfirmLinkAccountDto confirmLinkAccount)
        {
            var response = await _authenticationService.AuthenticatePasswordAndConfirmLinkAccountToUser(confirmLinkAccount);
            if (!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }

        [HttpPost("AuthenticateMediaServer")]
        public async Task<ActionResult<Response<AuthenticationMediaServerResponseDto>>> AuthenticateMediaServer([FromBody] string sid)
        {
            var response = await _authenticationService.AuthenticateMediaServer(sid);
            if(!response.IsSuccess)
            {
                return BadRequest(response.Message);
            }
            return response;
        }


    }

}
