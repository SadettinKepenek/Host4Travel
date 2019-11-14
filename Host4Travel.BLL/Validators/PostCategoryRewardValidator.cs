using System.Data;
using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class PostCategoryRewardValidator:AbstractValidator<PostCategoryReward>
    {
        public PostCategoryRewardValidator()
        {
            RuleFor(x => x.Category).Cascade(CascadeMode.StopOnFirstFailure).SetValidator(new CategoryValidator());
            RuleFor(x => x.Post).SetValidator(new PostValidator());
            RuleFor(x => x.Reward).SetValidator(new RewardValidator());
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Kategori identifier belirtilmelidir.");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.RewardId).NotNull().NotEmpty().WithMessage("Reward identifier belirtilmelidir");
            RuleFor(x => x.RewardId).GreaterThan(0).WithMessage("Reward identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.RewardValue).NotNull().NotEmpty().WithMessage("Verilecek hizmetin değeri belirtilmelidir");

        }
    }
}