using FluentValidation;
using Host4Travel.Core.DTO.PostCheckInDtos;

namespace Host4Travel.BLL.Validators.PostCheckInService
{
    public class AddPostCheckInValidator:AbstractValidator<PostCheckInAddDto>
    {
        public AddPostCheckInValidator()
        {
            RuleFor(x => x.ApplicationId).NotNull().NotEmpty()
                .WithMessage("CheckIn hangi başvuru için yapıldığı girilmedi.");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("CheckIn aktiflik durumu belirtilmelidir");
            RuleFor(x => x.CheckInStartDate).Equal(y => y.CheckInStartDate)
                .WithMessage("CheckIn başlama tarihi veya Başvuru başlama tarihi eşit olmalıdır");
            RuleFor(x => x.CheckInEndDate).Equal(y => y.CheckInEndDate)
                .WithMessage("CheckIn bitiş tarihi veya Başvuru bitiş tarihi eşit olmalıdır");
        }
    }
}