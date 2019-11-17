using FluentValidation;
using Host4Travel.Core.DTO.AuthService;

namespace Host4Travel.BLL.Validators.AuthService
{
    public class DeleteValidator:AbstractValidator<ApplicationIdentityUserDeleteDto>
    {
        public DeleteValidator()
        {
            RuleFor(x => x.Username).NotNull().NotEmpty().WithMessage("Username boş geçilemez");

        }
    }
}