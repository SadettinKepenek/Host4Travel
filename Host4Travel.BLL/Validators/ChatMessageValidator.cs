using System;
using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class ChatMessageValidator:AbstractValidator<ChatMessage>
    {
        public ChatMessageValidator()
        {
            RuleFor(x => x.Chat).Cascade(CascadeMode.StopOnFirstFailure).SetValidator(new ChatValidator());
            RuleFor(x => x.Message).NotNull().NotEmpty().WithMessage("Chat Mesajı boş geçilemez");
            RuleFor(x => x.ChatId).NotNull().NotEmpty().WithMessage("Chat Identifier boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Mesaj aktiflik durumu boş geçilemez");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Mesaj göndericisi boş geçilemez");
            RuleFor(x => x.SendDate).NotNull().NotEmpty().WithMessage("Mesaj gönderim tarihi boş geçilemez");
            RuleFor(x => x.SendDate).InclusiveBetween(DateTime.Now.AddMinutes(-10), DateTime.Now.AddMinutes(10)).WithMessage("Mesaj gönderim tarihi hatalı aralıkta.");
        }
    }
}