using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using SinovadDemo.Application.DTO;
using SinovadDemo.Application.DTO.SignUp;
using SinovadDemo.Application.Interface.Infrastructure;
using SinovadDemo.Application.Interface.Persistence;
using SinovadDemo.Application.Interface.UseCases;
using SinovadDemo.Domain.Entities;
using SinovadDemo.Domain.Enums;
using SinovadDemo.Transversal.Common;

namespace SinovadDemo.Application.UseCases.SignUp
{
    public class SignUpService : ISignUpService
    {

        private readonly UserManager<User> _userManager;

        private readonly IEmailSenderService _emalSenderService;

        private readonly AutoMapper.IMapper _mapper;

        private readonly IAppLogger<SignUpService> _logger;

        private readonly IUnitOfWork _unitOfWork;

        public SignUpService(UserManager<User> userManager, IEmailSenderService emalSenderService, AutoMapper.IMapper mapper, IAppLogger<SignUpService> logger, IUnitOfWork unitOfWork)
        {
            _userManager = userManager;
            _emalSenderService = emalSenderService;
            _mapper = mapper;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public async Task<Response<bool>> Register(RegisterUserDto dto)
        {
            var response = new Response<bool>();
            try
            {
               var user= await _userManager.FindByEmailAsync(dto.Email);
                if(user != null)
                {
                  response.Message = "Ya existe una cuenta registrada con este email";
                }else{
                    user = await _userManager.FindByNameAsync(dto.UserName);
                    if (user != null)
                    {
                        response.Message = "Ya existe una cuenta registrada con este username";
                    }else{
                        var appUser = _mapper.Map<User>(dto);
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
                            response.Message = "Usuario registrado satisfactoriamente";
                        }else
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

        public async Task RegisterWithLinkedAccount(RegisterUserFromProviderDto registerUserFromProviderDto)
        {
            try
            {
                var appUser = _mapper.Map<User>(registerUserFromProviderDto);
                appUser.Created = DateTime.Now;
                appUser.LastModified = DateTime.Now;
                appUser.Active = true;
                var mainProfile = new Profile();
                mainProfile.FullName = appUser.FirstName.Split(" ")[0];
                mainProfile.Main = true;
                var aleatoryUsername = (registerUserFromProviderDto.FirstName + registerUserFromProviderDto.LastName + "_" + Guid.NewGuid()).Replace(" ", "");
                appUser.UserName = aleatoryUsername.ToLower();
                appUser.Profiles.Add(mainProfile);
                var linkedAccount = new LinkedAccount();
                linkedAccount.Email = appUser.Email;
                linkedAccount.AccessToken = registerUserFromProviderDto.AccessToken;
                linkedAccount.LinkedAccountProviderCatalogId = (int)CatalogEnum.LinkedAccountProvider;
                linkedAccount.LinkedAccountProviderCatalogDetailId = (int)registerUserFromProviderDto.LinkedAccountProviderCatalogDetailId;
                appUser.LinkedAccounts.Add(linkedAccount);
                var user = await _unitOfWork.Users.AddAsync(appUser);
                await _unitOfWork.SaveAsync();
            }catch(Exception ex)
            {
                _logger.LogError(ex.StackTrace);
                throw new Exception(ex.Message);
            }
        }

    }
}
