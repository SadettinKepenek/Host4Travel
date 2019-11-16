using FluentValidation;
using Host4Travel.Core.DTO.RewardService;

namespace Host4Travel.BLL.Validators.RewardService
{
    public class UpdateRewardValidator:AbstractValidator<RewardUpdateDto>
    {
        public UpdateRewardValidator()
        {
            RuleFor(x => x.RewardId).NotNull().NotEmpty().WithMessage("Reward Identifier boş geçilemez");
            RuleFor(x => x.IsActive).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty().WithMessage("Reward aktif alanı boş geçilemez");
            RuleFor(x => x.RewardDescription).NotNull().NotEmpty().WithMessage("Reward açıklama alanı boş geçilemez");
            RuleFor(x => x.RewardDescription).MinimumLength(10)
                .WithMessage("Ödül açıklama alanı en az 10 karakter olmaldıır.");
            RuleFor(x => x.RewardDescription).MaximumLength(1000)
                .WithMessage("Ödül açıklama alanı en fazla 1000 karakter olmaldıır.");
            RuleFor(x => x.RewardName).NotNull().NotEmpty().WithMessage("Reward ismi boş geçilemez");
            RuleFor(x => x.RewardName).MinimumLength(10)
                .WithMessage("Ödül ismi en az 10 karakter olmaldıır.");
            RuleFor(x => x.RewardName).MaximumLength(1000)
                .WithMessage("Ödül ismi en fazla 1000 karakter olmaldıır.");
        }
    }
}