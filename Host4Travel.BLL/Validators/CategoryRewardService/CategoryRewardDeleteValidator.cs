using FluentValidation;
using Host4Travel.Core.DTO.CategoryRewardDtos;

namespace Host4Travel.BLL.Validators.CategoryRewardService
{
    public class CategoryRewardDeleteValidator:AbstractValidator<CategoryRewardDeleteDto>
    {
        public CategoryRewardDeleteValidator()
        {
            RuleFor(x => x.CategoryRewardId).NotNull().NotEmpty().WithMessage("CategoryReward Identifier boş geçilemez");
            
        }
    }
}