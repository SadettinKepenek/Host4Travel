using FluentValidation;
using Host4Travel.Core.DTO.CategoryRewardService;

namespace Host4Travel.BLL.Validators.CategoryRewardService
{
    public class CategoryRewardUpdateValidator:AbstractValidator<CategoryRewardUpdateDto>
    {
        public CategoryRewardUpdateValidator()
        {

            RuleFor(x => x.CategoryRewardId).NotNull().NotEmpty().WithMessage("CategoryReward Identifier boş geçilemez");
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Category Identifier boş geçilemez");
            RuleFor(x => x.RewardId).NotNull().NotEmpty().WithMessage("Reward Identifier boş geçilemez");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Category Identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.RewardId).GreaterThan(0).WithMessage("Reward Identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("CategoryReward Aktiflik durumu belirtilmelidir");


        }
    }
}