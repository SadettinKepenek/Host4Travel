using FluentValidation;
using Host4Travel.Core.DTO.AuthService;

namespace Host4Travel.BLL.Validators.AuthService
{
    public class LoginRequestValidator:AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username boş geçilemez");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password boş geçilemez");
        }
    }
}