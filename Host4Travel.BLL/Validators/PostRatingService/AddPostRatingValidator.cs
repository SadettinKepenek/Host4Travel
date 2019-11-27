using FluentValidation;
using Host4Travel.Core.DTO.PostRatingDtos;

namespace Host4Travel.BLL.Validators.PostRatingService
{
    public class AddPostRatingValidator:AbstractValidator<PostRatingAddDto>
    {
        public AddPostRatingValidator()
        {
            RuleFor(x => x.ApplicationId).NotNull().NotEmpty().WithMessage("Application Identifier boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Post Rating aktiflik durumu belirtilmelidir");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Rating kime ait olduğu belirtilmelidir");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("Rating hangi posta ait olduğu belirtilmelidir");
            RuleFor(x => x.RatingValue).NotNull().NotEmpty().WithMessage("Rating değeri belirtilmelidir");
            RuleFor(x => x.RatingValue).InclusiveBetween(0,5).WithMessage("Rating değeri 0 ile 5 arasında olabilir");
        }
    }
}