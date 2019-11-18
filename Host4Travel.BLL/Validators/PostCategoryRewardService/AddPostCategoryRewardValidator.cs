using FluentValidation;
using Host4Travel.Core.DTO.PostCategoryRewardService;

namespace Host4Travel.BLL.Validators.PostCategoryRewardService
{
    public class AddPostCategoryRewardValidator:AbstractValidator<PostCategoryRewardAddDto>
    {
        public AddPostCategoryRewardValidator()
        {
            RuleFor(x => x.PostCategoryRewardId).NotNull().NotEmpty().When(x=>x.IsNew==false).WithMessage("Güncelleme için id belirtilmelidir.");
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Kategori identifier belirtilmelidir.");
            RuleFor(x => x.CategoryId).GreaterThan(0).WithMessage("Kategori identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.RewardId).NotNull().NotEmpty().WithMessage("Reward identifier belirtilmelidir");
            RuleFor(x => x.RewardId).GreaterThan(0).WithMessage("Reward identifier 0 dan büyük olmalıdır");
            RuleFor(x => x.RewardValue).NotNull().NotEmpty().WithMessage("Verilecek hizmetin değeri belirtilmelidir");
        }
    }
}