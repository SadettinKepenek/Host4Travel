using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class PostImageValidator:AbstractValidator<PostImage>
    {
        public PostImageValidator()
        {
            RuleFor(x => x.Post).Cascade(CascadeMode.StopOnFirstFailure).SetValidator(new PostValidator());
            RuleFor(x => x.AltText).NotNull().NotEmpty().WithMessage("Resim AltText boş geçilemez");
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty().WithMessage("Resim adresi boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Resim aktiflik durumu boş geçilemez");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("İlan identifier boş geçilemez");
            
        }
    }
}