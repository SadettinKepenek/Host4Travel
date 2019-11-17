using FluentValidation;
using Host4Travel.Entities.Concrete;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class PostCheckInValidator:AbstractValidator<PostCheckIn>
    {
        public PostCheckInValidator()
        {
            RuleFor(x => x.Application).Cascade(CascadeMode.StopOnFirstFailure).SetValidator(new PostApplicationValidator());
            RuleFor(x => x.ApplicationId).NotNull().NotEmpty()
                .WithMessage("CheckIn hangi başvuru için yapıldığı girilmedi.");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("CheckIn aktiflik durumu belirtilmelidir");
            RuleFor(x => x.CheckInStartDate).Equal(y => y.Application.ApplicationStartDate)
                .WithMessage("CheckIn başlama tarihi veya Başvuru başlama tarihi eşit olmalıdır");
            RuleFor(x => x.CheckInEndDate).Equal(y => y.Application.ApplicationEndDate)
                .WithMessage("CheckIn bitiş tarihi veya Başvuru bitiş tarihi eşit olmalıdır");
            
        }
    }
}