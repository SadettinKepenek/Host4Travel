using FluentValidation;
using Host4Travel.Core.DTO.AuthService;

namespace Host4Travel.BLL.Validators.AuthService
{
    public class RegisterValidator:AbstractValidator<ApplicationIdentityUserAddDto>
    {
        public RegisterValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username boş geçilemez");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password boş geçilemez");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresi geçersiz.");
            RuleFor(x => x.Ssn).NotNull().NotEmpty().WithMessage("SSN Boş geçilemez.");
            RuleFor(x => x.CookieAcceptIpAddress).NotNull().NotEmpty().WithMessage("CookieAcceptIpAddress Boş geçilemez.");
        }
    }
}