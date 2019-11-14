using System.Data;
using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Latitude).Cascade(CascadeMode.StopOnFirstFailure).NotNull().NotEmpty()
                .WithMessage("Latitude alanı boş geçilemez.");
            RuleFor(x => x.Longitude).NotNull().NotEmpty().WithMessage("Longitude alanı boş geçilemez");
            RuleFor(x => x.StartDate).NotNull().NotEmpty().WithMessage("Başlama tarihi boş geçilemez");
            RuleFor(x => x.StartDate).LessThanOrEqualTo(y => y.EndDate)
                .WithMessage("Başlama tarihi bitiş tarihinden küçük yada eşit olmalıdır.");
            RuleFor(x => x.EndDate).NotNull().NotEmpty().WithMessage("Bitiş tarihi boş geçilemez.");
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(y => y.StartDate)
                .WithMessage("Bitiş tarihi,başlama tarihinden büyük yada eşit olmaldıır.");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Post Aktif durumu belirtilmelidir.");
            RuleFor(x => x.OwnerId).NotNull().NotEmpty().WithMessage("Post Sahibi alanı belirtilmelidir.");
            RuleFor(x => x.PostDescription).NotNull().NotEmpty().WithMessage("Post Açıklaması belirtilmelidir.");
            RuleFor(x => x.PostTitle).NotNull().NotEmpty().WithMessage("Post Başlığı belirtilmelidir.");
            RuleFor(x => x.PostType).NotNull().NotEmpty().WithMessage("Post Türü Seçilmelidir");
            
        }
    }
}