using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.MediaServer;
using SinovadDemo.Application.DTO.Profile;
using SinovadDemo.Application.DTO.SignUp;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Application.Helpers;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Validator;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Domain.Enums;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Authentication
{
    public  class AuthenticationService : IAuthenticationService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly SignInManager<User> _signInManager;

        private readonly AccessUserDtoValidator _accessUserDtoValidator;

        private readonly IAppLogger<AuthenticationService> _logger;

        private readonly IOptions<MyConfig> _config;

        private readonly AutoMapper.IMapper _mapper;

        private readonly ISignUpService _signUpService;

        public AuthenticationService(IUnitOfWork unitOfWork, SignInManager<User> signInManager, AccessUserDtoValidator accessUserDtoValidator, IAppLogger<AuthenticationService> logger, IOptions<MyConfig> config, AutoMapper.IMapper mapper, ISignUpService signUpService)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
            _accessUserDtoValidator = accessUserDtoValidator;
            _logger = logger;
            _config = config;
            _mapper = mapper;
            _signUpService = signUpService;
        }

        public async Task<Response<bool>> ValidateUser(string username)
        {
            var response = new Response<bool>();
            try
            {
                var exists = await _unitOfWork.Users.CheckIfExistAsync(x=>x.UserName==username);
                if(exists){
                    response.Data = exists;
                    response.IsSuccess = true;
                }else{
                    response.Message = "Usuario inválido";
                }
            }catch (Exception ex){
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<AuthenticationUserResponseDto>> AuthenticateUser(AuthenticateUserDto dto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                var validation = _accessUserDtoValidator.Validate(dto);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de validación";
                    response.Errors = validation.Errors;
                }else
                {
                    var user = await _unitOfWork.Users.GetUserRelatedData(u => u.UserName == dto.UserName);
                    if (user == null)
                    {
                        response.Message = "Usuario inválido";
                    }else
                    {
                        var res = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
                        if (res.Succeeded)
                        {
                            if (user.Active)
                            {
                                var data = new AuthenticationUserResponseDto();                   
                                data.UserData = GetUserSessionData(user);
                                var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                                var token = jwtHelper.CreateTokenWithUserGuid(user.Guid);
                                data.ApiToken = token;
                                response.Data = data;
                                response.IsSuccess = true;
                            }else
                            {
                                response.Message = "Usuario inactivo, por favor confirma tu correo electrónico";
                            }
                        }else
                        {
                            if (res.IsLockedOut)
                            {
                                response.Message = "El usuario ha excedido el máximo número de intentos permitido, por favor intente más tarde";
                            }else{
                                response.Message = "Contraseña incorrecta";
                            }
                        }
                    }
                }
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<AuthenticationUserResponseDto>> AuthenticateLinkedAccount(RegisterUserFromProviderDto registerUserFromProviderDto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                var linkedAccountFinded = await _unitOfWork.LinkedAccounts.GetByExpressionAsync(linkedAccount => linkedAccount.Email == registerUserFromProviderDto.Email &&
                linkedAccount.LinkedAccountProviderCatalogDetailId == (int)registerUserFromProviderDto.LinkedAccountProviderCatalogDetailId);
                if (linkedAccountFinded!=null)
                {
                    var user = await _unitOfWork.Users.GetUserRelatedData(user=>user.Id == linkedAccountFinded.UserId);
                    var authenticateUserResponse = new AuthenticationUserResponseDto();
                    authenticateUserResponse.UserData = GetUserSessionData(user);
                    authenticateUserResponse.ApiToken = CreateWebToken(user);
                    response.Data = authenticateUserResponse;
                }else{
                    var user = await _unitOfWork.Users.GetUserRelatedData(user => user.Email == registerUserFromProviderDto.Email);   
                    if(user!=null)
                    {
                        var confirmLinkAccountData = new ConfirmLinkAccountDto();
                        confirmLinkAccountData.UserId = user.Id;
                        confirmLinkAccountData.Email = registerUserFromProviderDto.Email;
                        confirmLinkAccountData.AccessToken = registerUserFromProviderDto.AccessToken;
                        confirmLinkAccountData.LinkedAccountProvider = registerUserFromProviderDto.LinkedAccountProviderCatalogDetailId;
                        var authenticateUserResponse = new AuthenticationUserResponseDto();
                        authenticateUserResponse.ConfirmLinkAccountData = confirmLinkAccountData;
                        response.Data = authenticateUserResponse;
                    }else{
                        var userId=await _signUpService.RegisterWithLinkedAccount(registerUserFromProviderDto);
                        user = await _unitOfWork.Users.GetUserRelatedData(user => user.Id == userId);
                        var authenticateUserResponse = new AuthenticationUserResponseDto();
                        authenticateUserResponse.UserData = GetUserSessionData(user);
                        authenticateUserResponse.ApiToken = CreateWebToken(user);
                        response.Data = authenticateUserResponse;
                    }
                }
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<AuthenticationUserResponseDto>> AuthenticatePasswordAndConfirmLinkAccountToUser(ConfirmLinkAccountDto confirmLinkAccountDto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                var user=await _unitOfWork.Users.GetUserRelatedData(x=>x.Id== confirmLinkAccountDto.UserId);
                var res = await _signInManager.CheckPasswordSignInAsync(user, confirmLinkAccountDto.Password, true);
                if(res.Succeeded)
                {
                    var linkedAccount = new LinkedAccount();
                    linkedAccount.UserId = user.Id;
                    linkedAccount.Email = user.Email;
                    linkedAccount.AccessToken = confirmLinkAccountDto.AccessToken;
                    linkedAccount.LinkedAccountProviderCatalogId = (int)CatalogEnum.LinkedAccountProvider;
                    linkedAccount.LinkedAccountProviderCatalogDetailId = (int)confirmLinkAccountDto.LinkedAccountProvider;
                    linkedAccount = await _unitOfWork.LinkedAccounts.AddAsync(linkedAccount);
                    await _unitOfWork.SaveAsync();
                    var authenticateUserResponse = new AuthenticationUserResponseDto();
                    authenticateUserResponse.UserData = GetUserSessionData(user);       
                    authenticateUserResponse.ApiToken = CreateWebToken(user);
                    response.Data = authenticateUserResponse;
                    response.IsSuccess = true;
                }
            }catch (Exception ex)
            {
                response.Message = ex.StackTrace;
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
                    authenticateMediaServerResponse.MediaServer = _mapper.Map<MediaServerDto>(mediaServer);
                    if (mediaServer.UserId != null)
                    {
                        var user = await _unitOfWork.Users.GetByExpressionAsync(x => x.Id == mediaServer.UserId);
                        authenticateMediaServerResponse.User = _mapper.Map<UserDto>(user);
                    }
                    var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                    var token = jwtHelper.CreateTokenWithSecurityIdentifier(securityIdentifier);
                    authenticateMediaServerResponse.ApiToken = token;
                    response.Data = authenticateMediaServerResponse;
                    response.IsSuccess = true;
                }
                else
                {
                    response.Message = "No existe un servidor registrado con ese identificador";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.StackTrace;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        private string CreateWebToken(User user)
        {
            var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
            var token = jwtHelper.CreateTokenWithUserGuid(user.Guid);
            return token;
        }

        private UserSessionDto GetUserSessionData(User user)
        {
            var userDto = _mapper.Map<UserDto>(user);
            userDto.IsPasswordSetted = user.PasswordHash != null ? true : false;
            var userSessionDto = new UserSessionDto();
            userSessionDto.User = userDto;
            userSessionDto.MediaServers = _mapper.Map<List<MediaServerDto>>(user.MediaServers);
            userSessionDto.Profiles = _mapper.Map<List<ProfileDto>>(user.Profiles);
            userSessionDto.LinkedAccounts = _mapper.Map<List<LinkedAccountDto>>(user.LinkedAccounts);
            return userSessionDto;
        }
    }
}
