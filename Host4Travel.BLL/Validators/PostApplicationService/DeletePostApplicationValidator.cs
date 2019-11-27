using FluentValidation;
using Host4Travel.Core.DTO.PostApplicationDtos;

namespace Host4Travel.BLL.Validators.PostApplicationService
{
    public class DeletePostApplicationValidator:AbstractValidator<PostApplicationDeleteDto>
    {
        public DeletePostApplicationValidator()
        {
            RuleFor(x => x.PostApplicationId).NotNull().NotEmpty()
                .WithMessage("Post Application Identifier Boş Geçilemez");
        }
    }
}