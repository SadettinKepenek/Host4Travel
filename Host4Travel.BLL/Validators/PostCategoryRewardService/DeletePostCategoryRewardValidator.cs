using FluentValidation;
using Host4Travel.Core.DTO.PostCategoryRewardService;

namespace Host4Travel.BLL.Validators.PostCategoryRewardService
{
    public class DeletePostCategoryRewardValidator:AbstractValidator<PostCategoryRewardDeleteDto>
    {
        public DeletePostCategoryRewardValidator()
        {
            RuleFor(x => x.PostCategoryRewardId).NotNull().NotEmpty().WithMessage("PostCategoryRewardId Boş geçilemez");
        }
    }
}