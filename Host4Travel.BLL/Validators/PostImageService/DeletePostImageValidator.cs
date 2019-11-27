using System.Data;
using FluentValidation;
using Host4Travel.Core.DTO.PostImageDtos;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators.PostImageService
{
    public class DeletePostImageValidator:AbstractValidator<PostImageDeleteDto>
    {
        public DeletePostImageValidator()
        {
            RuleFor(x => x.ImageId).NotNull().NotEmpty().WithMessage("Image Identifier boş geçilemez");
        }
    }
}