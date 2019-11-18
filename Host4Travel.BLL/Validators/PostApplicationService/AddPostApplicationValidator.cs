using System;
using FluentValidation;
using Host4Travel.Core.DTO.PostApplicationService;

namespace Host4Travel.BLL.Validators.PostApplicationService
{
    public class AddPostApplicationValidator:AbstractValidator<PostApplicationAddDto>
    {
        public AddPostApplicationValidator()
        {
            RuleFor(x => x.ApplicationDate).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty()
                .WithMessage("Başvuru tarihi boş geçilemez");
            RuleFor(x => x.ApplicationDate).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Başvuru tarihi bugün veya daha ileri bir tarih için olmalıdır");
            RuleFor(x => x.ApplicentId).NotNull().NotEmpty().WithMessage("Applicent Identifier boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Başvuru aktiflik durumu belirtilmelidir");
            RuleFor(x => x.PostId).NotNull().NotEmpty().WithMessage("Başvuru yapılan ilan belirtilmelidir");
            RuleFor(x => x.ApplicationStartDate).NotNull().NotEmpty()
                .WithMessage("Başvuru başlangıç aralığı girilmelidir");
            RuleFor(x => x.ApplicationStartDate).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Başvuru başlangıç tarihi bugüne eşit veya daha ilerisi için olmalıdır");
            RuleFor(x => x.ApplicationStartDate).LessThanOrEqualTo(x => x.ApplicationEndDate)
                .WithMessage("Başvuru başlangıç tarihi,başvuru bitiş tarihine eşit veya daha küçük olmalıdır");
            RuleFor(x => x.ApplicationEndDate).NotNull().NotEmpty()
                .WithMessage("Başvuru bitiş aralığı girilmelidir");
            RuleFor(x => x.ApplicationEndDate).GreaterThanOrEqualTo(DateTime.Now)
                .WithMessage("Başvuru bitiş tarihi bugüne eşit veya daha ilerisi için olmalıdır");
            RuleFor(x => x.ApplicationEndDate).GreaterThanOrEqualTo(x => x.ApplicationStartDate)
                .WithMessage("Başvuru bitiş tarihi,başvuru başlangıç tarihine eşit veya daha büyük olmalıdır");
        }
    }
}