using FluentValidation;
using Host4Travel.Core.DTO.RewardService;

namespace Host4Travel.BLL.Validators.RewardService
{
    public class DeleteRewardValidator:AbstractValidator<RewardDeleteDto>
    {
        public DeleteRewardValidator()
        {
            RuleFor(x => x.RewardId).NotNull().NotEmpty().WithMessage("Reward Identifier boş geçilemez");

        }
    }
}