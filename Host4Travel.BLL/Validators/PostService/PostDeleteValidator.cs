using FluentValidation;
using Host4Travel.Core.DTO.PostService;

namespace Host4Travel.BLL.Validators.PostService
{
    public class PostDeleteValidator:AbstractValidator<PostDeleteDto>
    {
        public PostDeleteValidator()
        {
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("PostIdentifier boş geçilemez");
        }
    }
}