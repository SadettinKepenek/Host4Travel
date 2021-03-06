﻿using System.Data;
using FluentValidation;
using Host4Travel.Core.DTO.PostDiscussionDtos;

namespace Host4Travel.BLL.Validators.PostDiscussionService
{
    public class AddPostDiscussionValidator:AbstractValidator<PostDiscussionAddDto>
    {
        public AddPostDiscussionValidator()
        {
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("PostId alanı boş geçilemez");
            RuleFor(x => x.Comment).NotNull().NotEmpty().WithMessage("Comment alanı boş geçilemez");
            RuleFor(x => x.Comment).MinimumLength(10).WithMessage("Yorum minimum 10 karakter içermelidir");
            RuleFor(x => x.Comment).MaximumLength(250).WithMessage("Yorum maksimum 250 karakter içermelidir");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("IsActive alanı boş geçilemez");
            RuleFor(x => x.IsVerified).NotNull().NotEmpty().WithMessage("IsVerified alanı boş geçilemez");
            RuleFor(x => x.CommentDate).NotNull().NotEmpty().WithMessage("CommentDate alanı boş geçilemez");

        }
    }
}