using FluentValidation;
using Host4Travel.Core.DTO.PostImageService;

namespace Host4Travel.BLL.Validators.PostImageService
{
    public class AddPostImageValidator:AbstractValidator<PostImageAddDto>
    {
        public AddPostImageValidator()
        {
            RuleFor(x => x.ImageId).NotNull().NotEmpty().When(x => x.IsPhotoNew==false).WithMessage("Güncellemek için Resim IDsi gönderilmedi");
            RuleFor(x => x.AltText).NotNull().NotEmpty().WithMessage("AltText boş geçilemez");
            RuleFor(x => x.ImageUrl).NotNull().NotEmpty().WithMessage("ImageUrl boş geçilemez");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("PostId boş geçilemez");
            RuleFor(x => x.IsPhotoNew).NotNull().NotEmpty().WithMessage("IsPhotoNew boş geçilemez");
        }
    }
}