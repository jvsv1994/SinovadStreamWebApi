using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
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

namespace SinovadDemo.Application.UseCases.Users
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        private readonly UserManager<User> _userManager;

        private readonly IEmailSenderService _emalSenderService;

        private readonly SignInManager<User> _signInManager;

        private readonly AccessUserDtoValidator _accessUserDtoValidator;

        private readonly IAppLogger<UserService> _logger;

        private readonly IOptions<MyConfig> _config;

        public UserService(IUnitOfWork unitOfWork, IAppLogger<UserService> logger, IOptions<MyConfig> config, UserManager<User> userManager, SignInManager<User> signInManager, IEmailSenderService emalSenderService, AccessUserDtoValidator accessUserDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _emalSenderService = emalSenderService;
            _accessUserDtoValidator = accessUserDtoValidator;
        }

        public async Task<ResponsePagination<List<UserDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<UserDto>>();
            try
            {
                var result = await _unitOfWork.Users.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = result.Items.MapTo<List<UserDto>>();
                if (response.Data != null)
                {
                    response.PageNumber = page;
                    response.TotalCount = result.Total;
                    response.TotalPages = result.Pages;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<UserDto>> GetUserByGuid(string userGuid)
        {
            var response = new Response<UserDto>();
            try
            {
                _logger.LogInformation("Getting user data from user with Guid " + userGuid);
                var user = await _unitOfWork.Users.GetByExpressionAsync(x => x.Guid.ToString() == userGuid);
                if(user!=null)
                {
                    var userDto = user.MapTo<UserDto>();
                    userDto.IsPasswordSetted = user.PasswordHash != null ? true : false;
                    response.Data = userDto;
                    response.Message = "Successful";
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

        public async Task<Response<UserDto>> GetUserByMediaServerSecurityIdentifier(string securityIdentifier)
        {
            var response = new Response<UserDto>();
            try
            {
                var mediaServer = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.SecurityIdentifier == securityIdentifier);
                if(mediaServer!=null)
                {
                    var user = await _unitOfWork.Users.GetByExpressionAsync(x => x.Id == mediaServer.UserId);
                    if(user!=null)
                    {
                        user.MediaServers = null;
                        var userDto = user.MapTo<UserDto>();
                        userDto.IsPasswordSetted = user.PasswordHash != null ? true : false;
                        response.Data = userDto;
                        response.Message = "Successful";
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


        public async Task<Response<UserDto>> GetUserByLinkedAccountEmail(string email, LinkedAccountProvider LinkedAccountProvider)
        {
            var response = new Response<UserDto>();
            try
            {
                var list= await _unitOfWork.LinkedAccounts.GetAllAsync();
                var ele = list.ToList()[0];
                var token = ele.AccessToken;
                var linkedAccountList = await _unitOfWork.LinkedAccounts.GetAllByExpressionAsync(x => x.Email.ToLower().Equals(email.ToLower()) && x.LinkedAccountProviderCatalogDetailId== (int)LinkedAccountProvider);
                var linkedAccount = linkedAccountList.FirstOrDefault();
                if (linkedAccount != null)
                {
                    var user = await _unitOfWork.Users.GetByExpressionAsync(x => x.Id == linkedAccount.UserId);
                    if (user != null)
                    {
                        user.LinkedAccounts = null;
                        user.Profiles = null;
                        user.MediaServers = null;
                        var userDto= user.MapTo<UserDto>();
                        userDto.IsPasswordSetted = user.PasswordHash!=null?true:false;
                        response.Data = userDto;
                        response.Message = "Successful";
                    }
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

        public async Task<Response<UserDto>> GetAsync(int id)
        {
            var response = new Response<UserDto>();
            try
            {
                var result = await _unitOfWork.Users.GetAsync(id);
                response.Data = result.MapTo<UserDto>();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> ResetPassword(ResetPasswordDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
                var appUser = (User)user;
                appUser.Active = true;
                var res = await _userManager.ResetPasswordAsync(appUser, dto.ResetPasswordToken, dto.Password);
                if (res.Succeeded)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
                else
                {
                    response.Message = string.Join("\n", res.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> ChangeNames(ChangeNamesDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
                user.FirstName = dto.FirstName;
                user.LastName=dto.LastName;
                var res = await _userManager.UpdateAsync(user);
                if (res.Succeeded)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }else
                {
                    response.Message = string.Join("\n", res.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> ChangeUserName(ChangeUserNameDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
                var appUser = (User)user;
                var res = await _userManager.SetUserNameAsync(appUser, dto.UserName);
                if (res.Succeeded)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
                else
                {
                    response.Message = string.Join("\n", res.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> ChangePassword(ChangePasswordDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
                var appUser = (User)user;
                var res = await _userManager.ChangePasswordAsync(appUser, dto.CurrentPassword, dto.Password);
                if (res.Succeeded)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }else
                {
                    response.Message = string.Join("\n", res.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> SetPassword(SetPasswordDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
                var appUser = (User)user; 
                var res = await _userManager.AddPasswordAsync(appUser,dto.Password);
                if (res.Succeeded)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
                else
                {
                    response.Message = string.Join("\n", res.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> ValidateResetPasswordToken(ValidateResetPasswordTokenDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
                var purpose = UserManager<User>.ResetPasswordTokenPurpose;
                var isValidToken = await _userManager.VerifyUserTokenAsync(user, TokenOptions.DefaultProvider, purpose, dto.ResetPasswordToken);
                if (isValidToken)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
                else
                {
                    response.Message = "Invalid Token";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> RecoverPassword(RecoverPasswordDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByEmailAsync(dto.Email);
                if (user == null)
                {
                    response.Message = "There is no user registered with this email.";
                }
                else
                {
                    var restPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var mailRequest = new MailRequest();
                    mailRequest.Email = dto.Email;
                    mailRequest.Subject = "Recuperar contraseña - Sinovad";
                    string body = "" +
                        "<div style='width: 100%; height: 100%; display: flex; align-items: center; justify-content: center; background-color: black; position: absolute;'>" +
                            "<div style='width: 100%; height: 100%; background: linear-gradient(196.06deg,#212121,#080808); color: white; padding: 40px;'>" +
                                    "<div style = 'display: block; text-align: center; justify-content: center; color: red; font-weight: bold; font-size: 30px; margin-bottom: 20px;'>" +
                                        "Sinovad" +
                                    "</div>" +
                                    "<div style='font-size: 23px; text-align: left; margin-bottom: 20px;color:white;'>" +
                                        "Siga el enlace a continuación para cambiar su contraseña:" +
                                    "</div>" +
                                    "<div style='font-size: 20px; text-align: left; margin-bottom: 20px;'>" +
                                        "<a href='{url}' style='color: #5E83EE; font-size: 20px; cursor: pointer;'>" +
                                        "Enlace de Confirmación" +
                                        "</a>" +
                                    "</div>" +
                             "</div>" +
                        "</div>";

                    var validateTokenDto = new ValidateResetPasswordTokenDto();
                    validateTokenDto.ResetPasswordToken = restPasswordToken;
                    validateTokenDto.UserId = user.Id;
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(validateTokenDto));
                    var base64 = Convert.ToBase64String(plainTextBytes);
                    var urlRedirect = dto.ResetPasswordUrl + "/" + base64;
                    body = body.Replace("{url}", urlRedirect);
                    mailRequest.Body = body;
                    await _emalSenderService.SendEmailAsync(mailRequest);
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<string>> Login(AccessUserDto dto)
        {
            var response = new Response<string>();
            try
            {
                var validation = _accessUserDtoValidator.Validate(dto);
                if (!validation.IsValid)
                {
                    response.Message = "Validation errors";
                    response.Errors = validation.Errors;
                }
                else
                {
                    var user = await _unitOfWork.Users.GetByExpressionAsync(u=>u.UserName== dto.UserName);
                    if(user==null)
                    {
                        response.Message = "Invalid user";
                    }else
                    {
                        var res = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
                        if (res.Succeeded)
                        {
                            if (user.Active)
                            {
                                _logger.LogInformation("Successful autentication for the user " + dto.UserName);
                                var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                                var token = jwtHelper.CreateTokenWithUserGuid(user.Guid);
                                _logger.LogInformation("Token generated for the user " + dto.UserName + " : " + token);
                                response.Data = token;
                                response.IsSuccess = true;
                                response.Message = "Successful";
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
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<AuthenticationUserResponseDto>> ValidateUser(AccessUserDto dto)
        {
            var response = new Response<AuthenticationUserResponseDto>();
            try
            {
                var validation = _accessUserDtoValidator.Validate(dto);
                if (!validation.IsValid)
                {
                    response.Message = "Validation errors";
                    response.Errors = validation.Errors;
                }
                else
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
                                data.User= user.MapTo<UserDto>();
                                var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                                var token = jwtHelper.CreateTokenWithUserGuid(user.Guid);
                                data.ApiToken = token;
                                response.Data = data;
                            }else{
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
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> ValidateConfirmEmailToken(ValidateConfirmEmailTokenDto dto)
        {
            var response = new Response<bool>();
            try
            {
                User user = (User)await _userManager.FindByIdAsync(dto.UserId.ToString());
                user.Active = true;
                var result = await _userManager.ConfirmEmailAsync(user, dto.ConfirmEmailToken);
                if (result.Succeeded)
                {
                    response.Data = true;
                    response.IsSuccess = true;
                    response.Message = "Successful";
                }
                else
                {
                    response.Message = string.Join("\n", result.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<bool>> Register(RegisterUserDto dto)
        {
            var response = new Response<bool>();
            try
            {
               var user= await _userManager.FindByEmailAsync(dto.Email);
                if(user != null)
                {
                  response.Message = "Exist an account with this email";
                }else{
                    user = await _userManager.FindByNameAsync(dto.UserName);
                    if (user != null)
                    {
                        response.Message = "Exist an account with this username";
                    }else{
                        var appUser = dto.MapTo<User>();
                        appUser.Created = DateTime.Now;
                        appUser.LastModified = DateTime.Now;
                        var mainProfile = new Profile();
                        mainProfile.FullName = dto.FirstName.Split(" ")[0];
                        mainProfile.Main = true;
                        appUser.Profiles.Add(mainProfile);
                        var result = await _userManager.CreateAsync(appUser, dto.Password);
                        user = await _userManager.FindByNameAsync(dto.UserName);
                        var confirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                        var mailRequest = new MailRequest();
                        mailRequest.Email = dto.Email;
                        mailRequest.Subject = "Confirmación de registro";
                        string body = "" +
                            "<div style='width: 100%; height: 100%; display: flex; align-items: center; justify-content: center; background-color: black; position: absolute;'>" +
                                "<div style='width: 100%; height: 100%; background: linear-gradient(196.06deg,#212121,#080808); color: white; padding: 40px;'>" +
                                        "<div style = 'display: block; text-align: center; justify-content: center; color: red; font-weight: bold; font-size: 30px; margin-bottom: 20px;'>" +
                                            "Sinovad" +
                                        "</div>" +
                                        "<div style='font-size: 23px; text-align: left; margin-bottom: 20px; font-weight: bold;'>" +
                                            "Gracias por registrarte en Sinovad Stream" +
                                        "</div>" +
                                        "<div style='font-size: 23px; text-align: left; margin-bottom: 20px;color:white;'>" +
                                            "Siga el enlace a continuación para activar su cuenta:" +
                                        "</div>" +
                                        "<div style='font-size: 20px; text-align: left; margin-bottom: 20px;'>" +
                                            "<a href='{urlconfirmemail}' style='color: #5E83EE; font-size: 20px; cursor: pointer;'>" +
                                            "Enlace de Confirmación" +
                                            "</a>" +
                                        "</div>" +
                                 "</div>" +
                            "</div>";

                        var validateConfirmEmailTokenData = new ValidateConfirmEmailTokenDto();
                        validateConfirmEmailTokenData.ConfirmEmailToken = confirmationToken;
                        validateConfirmEmailTokenData.UserId = user.Id;
                        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(validateConfirmEmailTokenData));
                        var base64 = Convert.ToBase64String(plainTextBytes);
                        var urlRedirect = dto.ConfirmEmailUrl + "/" + base64;
                        body = body.Replace("{urlconfirmemail}", urlRedirect);
                        mailRequest.Body = body;
                        await _emalSenderService.SendEmailAsync(mailRequest);
                        if (result.Succeeded)
                        {
                            response.Data = true;
                            response.IsSuccess = true;
                            response.Message = "User registered successfully";
                        }
                        else
                        {
                            response.Message = string.Join("\n", result.Errors.Select(err => err.Description));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<object> Create(UserDto userDto)
        {
            var response = new Response<object>();
            try
            {
                var user = userDto.MapTo<User>();
                _unitOfWork.Users.Add(user);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Update(UserDto userDto)
        {
            var response = new Response<object>();
            try
            {
                var user = userDto.MapTo<User>();
                _unitOfWork.Users.Update(user);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> Delete(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.LinkedAccounts.DeleteByExpression(x => x.UserId == id);
                _unitOfWork.Profiles.DeleteByExpression(x=>x.UserId==id);
                _unitOfWork.Users.Delete(id);
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public Response<object> DeleteList(string ids)
        {
            var response = new Response<object>();
            try
            {
                List<string> listIds = new List<string>();
                if (!string.IsNullOrEmpty(ids))
                {
                    listIds = ids.Split(",").ToList();
                }
                _unitOfWork.Users.DeleteByExpression(x => listIds.Contains(x.Id.ToString()));
                _unitOfWork.Save();
                response.IsSuccess = true;
                response.Message = "Successful";
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

    }
}
