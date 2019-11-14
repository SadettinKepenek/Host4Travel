using System;
using System.Data;
using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class PostDiscussionValidator:AbstractValidator<PostDiscussion>
    {
        public PostDiscussionValidator()
        {
            RuleFor(x => x.Comment).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty().WithMessage("Yorum boş olamaz");
            RuleFor(x => x.Post).SetValidator(new PostValidator());
            RuleFor(x => x.CommentDate).NotNull().NotEmpty().WithMessage("Yorum tarihi boş geçilemez");
            RuleFor(x => x.CommentDate).InclusiveBetween(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(10))
                .WithMessage("Yorum tarihi hatalı aralıkta");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Yorum aktiflik durumu belirtilmelidir");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Yorum sahibi belirtilmelidir");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("İlan belirtilmelidir");

        }
    }
}