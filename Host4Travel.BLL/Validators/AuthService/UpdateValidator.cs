using FluentValidation;
using Host4Travel.Core.DTO.AuthService;

namespace Host4Travel.BLL.Validators.AuthService
{
    public class UpdateValidator:AbstractValidator<UserUpdateDto>
    {
        public UpdateValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username boş geçilemez");
            RuleFor(x => x.Password).NotNull().NotEmpty().WithMessage("Password boş geçilemez");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Email boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email adresi geçersiz.");
            RuleFor(x => x.IsActive).NotNull().NotEmpty();
            RuleFor(x => x.Firstname).NotNull().NotEmpty();
            RuleFor(x => x.Lastname).NotNull().NotEmpty();
        }
    }
}