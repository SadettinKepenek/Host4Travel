using FluentValidation;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class CategoryRewardValidator:AbstractValidator<CategoryReward>
    {
        public CategoryRewardValidator()
        {
            RuleFor(x => x.Category).Cascade(CascadeMode.StopOnFirstFailure).SetValidator(new CategoryValidator());
            RuleFor(x => x.Reward).SetValidator(new RewardValidator());
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Category Identifier boş geçilemez");
            RuleFor(x => x.RewardId).NotNull().NotEmpty().WithMessage("Reward Identifier boş geçilemez");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category Identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.RewardId).GreaterThan(0).WithMessage("Reward Identifier 0 dan büyük olmalıdır");

        }
    }
}