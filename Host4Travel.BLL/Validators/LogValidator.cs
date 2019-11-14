using System;
using System.Data;
using FluentValidation;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.BLL.Validators
{
    public class LogValidator:AbstractValidator<Log>
    {
        public LogValidator()
        {
            RuleFor(x => x.LogLevel).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty().WithMessage("Log Seviyesi belirtilmelidir");
            RuleFor(x => x.LogMessage).NotNull().NotEmpty().WithMessage("Log Mesajı boş geçilemez");
            RuleFor(x => x.LogDate).NotNull().NotEmpty().WithMessage("Log tarihi boş geçilemez");
            RuleFor(x => x.LogDate).InclusiveBetween(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(10))
                .WithMessage("Log tarihi hatalı aralıkta");
        }
    }
}