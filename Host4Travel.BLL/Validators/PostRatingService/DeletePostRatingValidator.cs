using FluentValidation;
using Host4Travel.Core.DTO.PostRatingDtos;

namespace Host4Travel.BLL.Validators.PostRatingService
{
    public class DeletePostRatingValidator:AbstractValidator<PostRatingDeleteDto>
    {
        public DeletePostRatingValidator()
        {
            RuleFor(x => x.PostRatingId).NotNull().NotEmpty().WithMessage("PostRatingId Boş geçilemez");
        }
    }
}