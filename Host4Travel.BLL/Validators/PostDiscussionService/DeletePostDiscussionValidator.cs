using FluentValidation;
using Host4Travel.Core.DTO.PostDiscussionService;

namespace Host4Travel.BLL.Validators.PostDiscussionService
{
    public class DeletePostDiscussionValidator:AbstractValidator<PostDiscussionDeleteDto>
    {
        public DeletePostDiscussionValidator()
        {
            RuleFor(x => x.PostDiscussionId).NotNull().NotEmpty().WithMessage("PostDiscussionId alanı boş geçilemez");

        }
    }
}