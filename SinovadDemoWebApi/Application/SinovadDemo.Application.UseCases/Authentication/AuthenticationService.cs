using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SinovadDemo.Application.Configuration;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.Helpers;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Application.Validator;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Domain.Enums;
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

        private readonly IFirebaseAuthService _firebaseAuthService;

        public AuthenticationService(IUnitOfWork unitOfWork, IAppLogger<AuthenticationService> logger, IOptions<MyConfig> config, SignInManager<User> signInManager, AccessUserDtoValidator accessUserDtoValidator,IFirebaseAuthService firebaseAuthService)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
            _signInManager = signInManager;
            _accessUserDtoValidator = accessUserDtoValidator;
            _firebaseAuthService = firebaseAuthService;
        }

        public async Task<Response<bool>> ValidateUser(string username)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _unitOfWork.Users.GetByExpressionAsync(x=>x.UserName==username);
                if(user != null)
                {
                    response.Data = true;
                    response.Message = "Valid user";
                }else{
                    response.Message = "Invalid user";
                }
                response.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
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

        public async Task<Response<AuthenticationUserResponseDto>> AuthenticateLinkedAccount(AuthenticateLinkedAccountRequestDto linkedAccountDto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                UserDto userDataFinded=null;
                if(linkedAccountDto.LinkedAccountTypeCatalogDetailId==LinkedAccountType.Google)
                {
                    userDataFinded = await _firebaseAuthService.ValidateGoogleCredentials(linkedAccountDto.AccessToken);
                }
                if (userDataFinded != null)
                {
                    var authenticateUserResponse = new AuthenticationUserResponseDto();
                    User user = null;
                    var linkedAccountList = await _unitOfWork.LinkedAccounts.GetAllByExpressionAsync(x => x.Email == userDataFinded.Email);
                    var linkedAccount = linkedAccountList != null && linkedAccountList.Count() > 0 ? linkedAccountList.ToList()[0] : null;
                    if (linkedAccount != null)
                    {
                        user = await _unitOfWork.Users.GetAsync(linkedAccount.UserId);
                    }else
                    {
                        var userList = await _unitOfWork.Users.GetAllByExpressionAsync(x => x.Email == userDataFinded.Email);
                        user= userList!=null && userList.Count() > 0 ? userList.ToList()[0] : null;
                        if (user==null)
                        {
                            //register account
                            var appUser = userDataFinded.MapTo<User>();
                            appUser.Created = DateTime.Now;
                            appUser.LastModified = DateTime.Now;
                            appUser.Active = true;
                            var mainProfile = new Profile();
                            mainProfile.FullName = appUser.FirstName.Split(" ")[0];
                            mainProfile.Main = true;
                            appUser.Profiles.Add(mainProfile);
                            linkedAccount = new LinkedAccount();
                            linkedAccount.Email = appUser.Email;
                            linkedAccount.AccessToken = linkedAccountDto.AccessToken;
                            linkedAccount.LinkedAccountTypeCatalogId = (int)CatalogEnum.LinkedAccountType;
                            linkedAccount.LinkedAccountTypeCatalogDetailId = (int)linkedAccountDto.LinkedAccountTypeCatalogDetailId;
                            appUser.LinkedAccounts.Add(linkedAccount);
                            user = await _unitOfWork.Users.AddAsync(appUser);
                            await _unitOfWork.SaveAsync();
                        }else {
                            var confirmLinkAccountData = new ConfirmLinkAccountDto();
                            confirmLinkAccountData.UserId = user.Id;
                            confirmLinkAccountData.Email = userDataFinded.Email;
                            confirmLinkAccountData.AccessToken = linkedAccountDto.AccessToken;
                            confirmLinkAccountData.LinkedAccountType = linkedAccountDto.LinkedAccountTypeCatalogDetailId;
                            authenticateUserResponse.ConfirmLinkAccountData = confirmLinkAccountData;
                        }
                    }
                    if(linkedAccount!=null && user!=null)
                    {
                        user.LinkedAccounts = null;
                        user.Profiles = null;
                        authenticateUserResponse.User = user.MapTo<UserDto>();
                        var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                        var token = jwtHelper.CreateTokenWithLinkedAccountEmail(userDataFinded.Email, linkedAccountDto.LinkedAccountTypeCatalogDetailId);
                        authenticateUserResponse.ApiToken = token;
                    }
                    response.Data = authenticateUserResponse;
                    response.Message = "Successful";
                }
                else{
                    response.Message = "Invalid credentials";
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

        public async Task<Response<AuthenticationUserResponseDto>> AuthenticatePasswordAndConfirmLinkAccountToUser(ConfirmLinkAccountDto confirmLinkAccountDto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                var user=await _unitOfWork.Users.GetByExpressionAsync(x=>x.Id== confirmLinkAccountDto.UserId);
                var res = await _signInManager.CheckPasswordSignInAsync(user, confirmLinkAccountDto.Password, true);
                if(res.Succeeded)
                {
                    var linkedAccount = new LinkedAccount();
                    linkedAccount.UserId = user.Id;
                    linkedAccount.Email = user.Email;
                    linkedAccount.AccessToken = confirmLinkAccountDto.AccessToken;
                    linkedAccount.LinkedAccountTypeCatalogId = (int)CatalogEnum.LinkedAccountType;
                    linkedAccount.LinkedAccountTypeCatalogDetailId = (int)confirmLinkAccountDto.LinkedAccountType;
                    linkedAccount = await _unitOfWork.LinkedAccounts.AddAsync(linkedAccount);
                    await _unitOfWork.SaveAsync();
                    response.Message = "Success";
                    var authenticateUserResponse = new AuthenticationUserResponseDto();
                    user.LinkedAccounts = null;
                    user.Profiles = null;
                    authenticateUserResponse.User = user.MapTo<UserDto>();
                    var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                    var token = jwtHelper.CreateTokenWithLinkedAccountEmail(confirmLinkAccountDto.Email,(LinkedAccountType) confirmLinkAccountDto.LinkedAccountType);
                    authenticateUserResponse.ApiToken = token;
                    response.Data = authenticateUserResponse;
                }else{
                    response.Message = "Invalid Password";
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
