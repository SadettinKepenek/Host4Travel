using System.Data;
using FluentValidation;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.BLL.Validators
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(x => x.Firstname).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x => x.Firstname).MinimumLength(2).WithMessage("İsim alanı 2 karakterden büyük olmalıdır");
            RuleFor(x => x.Lastname).NotNull().NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x => x.Lastname).MinimumLength(2).WithMessage("Soyisim alanı 2 karakterden büyük olmalıdır");
            RuleFor(x => x.SSN).NotNull().NotEmpty().WithMessage("Id alanı boş geçilemez (SSN)");
            RuleFor(x => x.SSN).MinimumLength(9).WithMessage("Id alanı minimum 9 karakterden oluşmalıdır");
            RuleFor(x => x.Email).NotNull().NotEmpty().WithMessage("Mail adresi alanı boş geçilemez");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail adresi doğru girilmemiş");
         
        }
    }
}