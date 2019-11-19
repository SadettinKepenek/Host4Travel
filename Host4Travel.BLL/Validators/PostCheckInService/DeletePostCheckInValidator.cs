using FluentValidation;
using Host4Travel.Core.DTO.PostCheckInService;

namespace Host4Travel.BLL.Validators.PostCheckInService
{
    public class DeletePostCheckInValidator:AbstractValidator<PostCheckInDeleteDto>
    {
        public DeletePostCheckInValidator()
        {
            RuleFor(x => x.PostCheckInId).NotNull().NotEmpty().WithMessage("PostCheckInId Boş geçilemez");

        }
    }
}