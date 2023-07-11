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
using SinovadDemo.Transversal.Common;
using SinovadDemo.Transversal.Mapping;

namespace SinovadDemo.Application.UseCases.Accounts
{
    public class AccountService : IAccountService
    {
        private IUnitOfWork _unitOfWork;

        private readonly UserManager<IdentityUser> _userManager;

        private readonly IEmailSenderService _emalSenderService;

        private readonly SignInManager<IdentityUser> _signInManager;

        private readonly AccessUserDtoValidator _accessUserDtoValidator;

        private readonly IAppLogger<AccountService> _logger;

        private readonly IOptions<MyConfig> _config;

        public AccountService(IUnitOfWork unitOfWork, IAppLogger<AccountService> logger, IOptions<MyConfig> config, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IEmailSenderService emalSenderService, AccessUserDtoValidator accessUserDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _config = config;
            _userManager = userManager;
            _signInManager = signInManager;
            _emalSenderService = emalSenderService;
            _accessUserDtoValidator = accessUserDtoValidator;
        }

        public async Task<ResponsePagination<List<AccountDto>>> GetAllAsync(int page, int take)
        {
            var response = new ResponsePagination<List<AccountDto>>();
            try
            {
                var result = await _unitOfWork.Accounts.GetAllWithPaginationAsync(page, take, "Id", false);
                response.Data = result.Items.MapTo<List<AccountDto>>();
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

        public async Task<Response<AccountDto>> GetAsync(string username)
        {
            var response = new Response<AccountDto>();
            try
            {
                _logger.LogInformation("Getting account data from " + username);
                var result = await _unitOfWork.Accounts.GetByExpressionAsync(x => x.UserName == username);
                response.Data = result.MapTo<AccountDto>();
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

        public async Task<Response<AccountDto>> GetAsync(int id)
        {
            var response = new Response<AccountDto>();
            try
            {
                var result = await _unitOfWork.Accounts.GetAsync(id);
                response.Data = result.MapTo<AccountDto>();
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
                var user = await _userManager.FindByIdAsync(dto.UserId);
                var appUser = (AppUser)user;
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

        public async Task<Response<bool>> ValidateResetPasswordToken(ValidateResetPasswordTokenDto dto)
        {
            var response = new Response<bool>();
            try
            {
                var user = await _userManager.FindByIdAsync(dto.UserId);
                var purpose = UserManager<AppUser>.ResetPasswordTokenPurpose;
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
                    var res = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, true, true);
                    if (res.Succeeded)
                    {
                        var user = await _userManager.FindByNameAsync(dto.UserName);
                        var appUser = user.MapTo<AppUser>();
                        if (appUser.Active)
                        {
                            _logger.LogInformation("Successful autentication for the user " + dto.UserName);
                            var jwtHelper = new JWTHelper(_config.Value.JwtSettings.Secret, _config.Value.JwtSettings.Issuer, _config.Value.JwtSettings.Audience);
                            var token = jwtHelper.CreateToken(dto.UserName);
                            _logger.LogInformation("Token generated for the user " + dto.UserName + " : " + token);
                            response.Data = token;
                            response.IsSuccess = true;
                            response.Message = "Successful";
                        }
                        else
                        {
                            response.Message = "Inactive user, please confirm your email";
                        }
                    }
                    else
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
                AppUser user = (AppUser)await _userManager.FindByIdAsync(dto.UserId);
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
                var appUser = dto.MapTo<AppUser>();
                appUser.Created = DateTime.Now;
                appUser.LastModified = DateTime.Now;
                var mainProfile = new Profile();
                mainProfile.FullName = dto.FirstName.Split(" ")[0];
                mainProfile.Main = true;
                appUser.Profiles.Add(mainProfile);
                var result = await _userManager.CreateAsync(appUser, dto.Password);
                var user = await _userManager.FindByNameAsync(dto.UserName);
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
                    response.Message = "Account registered successfully";
                }
                else
                {
                    response.Message = string.Join("\n", result.Errors.Select(err => err.Description));
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                response.Message = ex.Message;
            }
            return response;
        }

        public Response<object> Create(AccountDto accountDto)
        {
            var response = new Response<object>();
            try
            {
                var account = accountDto.MapTo<AppUser>();
                _unitOfWork.Accounts.Add(account);
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

        public Response<object> Update(AccountDto accountDto)
        {
            var response = new Response<object>();
            try
            {
                var account = accountDto.MapTo<AppUser>();
                _unitOfWork.Accounts.Update(account);
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
                _unitOfWork.Accounts.Delete(id);
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
                _unitOfWork.Accounts.DeleteByExpression(x => listIds.Contains(x.Id));
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
