using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Helpers;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Validator;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Authentication
{
    public  class AuthenticationService : IAuthenticationService
    {
        private IUnitOfWork _unitOfWork;

        private readonly SignInManager<User> _signInManager;

        private readonly AccessUserDtoValidator _accessUserDtoValidator;

        private readonly IAppLogger<AuthenticationService> _logger;

        private readonly IOptions<MyConfig> _config;


        public AuthenticationService(IUnitOfWork unitOfWork, IAppLogger<AuthenticationService> logger, IOptions<MyConfig> config, SignInManager<User> signInManager, AccessUserDtoValidator accessUserDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
            _signInManager = signInManager;
            _accessUserDtoValidator = accessUserDtoValidator;
        }

        public async Task<Response<AuthenticationUserResponseDto>> AuthenticateUser(AccessUserDto dto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                var validation = _accessUserDtoValidator.Validate(dto);
                if (!validation.IsValid)
                {
                    response.Message = "Validation errors";
                    response.Errors = validation.Errors;
                }else
                {
                    var user = await _unitOfWork.Users.GetByExpressionAsync(u => u.UserName == dto.UserName);
                    if (user == null)
                    {
                        response.Message = "Invalid user";
                    }else
                    {
                        var res = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
                        if (res.Succeeded)
                        {
                            if (user.Active)
                            {
                                var data = new AuthenticationUserResponseDto();
                                data.User = user.MapTo<UserDto>();
                                var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                                var token = jwtHelper.CreateToken(dto.UserName);
                                data.ApiToken = token;
                                response.Data = data;
                            }else
                            {
                                response.Message = "Inactive user, please confirm your email";
                            }
                        }else
                        {
                            if (res.IsLockedOut)
                            {
                                response.Message = "The user has exceeded the maximum number of attempts, please try again later";
                            }
                            else
                            {
                                response.Message = "Invalid access";
                            }
                        }
                    }
                }
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<AuthenticationMediaServerResponseDto>> AuthenticateMediaServer(string securityIdentifier)
        {
            var response = new Response<AuthenticationMediaServerResponseDto>();
            try
            {
                var mediaServer = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.SecurityIdentifier == securityIdentifier);
                if (mediaServer != null)
                {
                    var authenticateMediaServerResponse = new AuthenticationMediaServerResponseDto();
                    authenticateMediaServerResponse.MediaServer = mediaServer.MapTo<MediaServerDto>();
                    if(mediaServer.UserId!=null)
                    {
                        var user = await _unitOfWork.Users.GetByExpressionAsync(x => x.Id == mediaServer.UserId);
                        user.MediaServers = null;
                        authenticateMediaServerResponse.User = user.MapTo<UserDto>();
                    }
                    var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                    var token = jwtHelper.CreateTokenWithSecurityIdentifier(securityIdentifier);
                    authenticateMediaServerResponse.ApiToken = token;
                    response.Data = authenticateMediaServerResponse;
                    response.Message = "Successful";
                }else{
                    response.Message = "Server not found";
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }
    }
}
