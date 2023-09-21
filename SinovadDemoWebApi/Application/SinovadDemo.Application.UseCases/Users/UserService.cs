using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.Authenticate;
using SinovadDemo.Application.DTO.Profile;
using SinovadDemo.Application.DTO.User;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly UserManager<User> _userManager;

        private readonly IEmailSenderService _emalSenderService;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<UserService> _logger;

        public UserService(IUnitOfWork unitOfWork, UserManager<User> userManager, IEmailSenderService emalSenderService, IMapper mapper, IAppLogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _emalSenderService = emalSenderService;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<UserSessionDto>> GetUserByGuid(string userGuid)
        {
            var response = new Response<UserSessionDto>();
            try
            {
                var user = await _unitOfWork.Users.GetUserRelatedData(x => x.Guid.ToString() == userGuid);
                if (user != null)
                {
                    response.Data = GetUserSessionData(user);
                    response.IsSuccess = true;
                }
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<UserSessionDto>> GetUserByMediaServerSecurityIdentifier(string securityIdentifier)
        {
            var response = new Response<UserSessionDto>();
            try
            {
                var mediaServer = await _unitOfWork.MediaServers.GetByExpressionAsync(x => x.SecurityIdentifier == securityIdentifier);
                if (mediaServer != null)
                {
                    var user = await _unitOfWork.Users.GetUserRelatedData(x => x.Id == mediaServer.UserId);
                    if (user != null)
                    {
                        response.Data = GetUserSessionData(user);
                        response.IsSuccess = true;
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

        public async Task<ResponsePagination<List<UserDto>>> GetAllWithPaginationAsync(int page, int take, string sortBy, string sortDirection, string searchText, string searchBy)
        {
            var response = new ResponsePagination<List<UserDto>>();
            try
            {
                var result = await _unitOfWork.Users.GetAllWithPaginationAsync(page, take, sortBy, sortDirection, searchText, searchBy);
                response.Data = _mapper.Map<List<UserDto>>(result.Items);
                if (response.Data != null)
                {
                    response.PageNumber = page;
                    response.TotalCount = result.Total;
                    response.TotalPages = result.Pages;
                    response.IsSuccess = true;
                }
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
                response.Data = _mapper.Map<UserDto>(result);
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }

        public async Task<Response<object>> DeleteAsync(int id)
        {
            var response = new Response<object>();
            try
            {
                _unitOfWork.LinkedAccounts.DeleteByExpression(x => x.UserId == id);
                _unitOfWork.Profiles.DeleteByExpression(x => x.UserId == id);
                _unitOfWork.Users.Delete(id);
                await _unitOfWork.SaveAsync();
                response.IsSuccess = true;
            }catch (Exception ex)
            {
                response.Message = ex.Message;
                _logger.LogError(ex.StackTrace);
            }
            return response;
        }
        public async Task<bool> CheckIfExistAsync(int id)
        {
            return await _unitOfWork.Users.CheckIfExistAsync(user => user.Id == id);
        }

    }
}
