using FluentValidation;
using SinovadDemo.Application.DTO;

namespace SinovadDemo.Application.Validator
{
    public class AccessUserDtoValidator:AbstractValidator<AccessUserDto>
    {
        public AccessUserDtoValidator() { 
            RuleFor(u=>u.UserName).NotNull().NotEmpty();
            RuleFor(u => u.Password).NotNull().NotEmpty();
        }
    }
}