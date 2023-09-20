using FluentValidation;
using SinovadDemo.Application.DTO.User;

namespace SinovadDemo.Application.Validator
{
    public class AccessUserDtoValidator:AbstractValidator<AuthenticateUserDto>
    {
        public AccessUserDtoValidator() { 
            RuleFor(u=>u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}