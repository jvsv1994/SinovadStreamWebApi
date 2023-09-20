using FluentValidation;
using SinovadDemo.Application.DTO.Authenticate;

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