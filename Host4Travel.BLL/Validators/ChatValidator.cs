using System;
using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class ChatValidator:AbstractValidator<Chat>
    {
        public ChatValidator()
        {
            RuleFor(x => x.Side1).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty().WithMessage("Gönderici belirleyicisi boş geçilemez");
            RuleFor(x => x.Side2).NotNull().NotEmpty().WithMessage("Alıcı belirleyicisi boş geçilemez");
            RuleFor(x => x.StartDate).NotNull().NotNull().WithMessage("Sohbet başlama tarihi boş geçilemez");
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(DateTime.Now);
        }
    }
}