using FluentValidation;
using Host4Travel.UI;

namespace Host4Travel.BLL.Validators
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması belirtilmelidir.");
            RuleFor(x => x.CategoryDescription).MinimumLength(10)
                .WithMessage("Kategori açıklaması minimum 10 karakterden oluşmalıdır");
            RuleFor(x => x.CategoryDescription).MaximumLength(150)
                .WithMessage("Kategori açıklaması Maximum 150 karakterden oluşmalıdır");
            RuleFor(x => x.CategoryLevel).NotEmpty().WithMessage("Kategori seviyesi belirtilmelidir.");
            RuleFor(x => x.CategoryLevel).GreaterThanOrEqualTo(0)
                .WithMessage("Kategori seviyesi 0 veya 0 dan büyük olmalıdır");
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori ismi belirtilmelidir.");
            RuleFor(x => x.CategoryName).MinimumLength(10)
                .WithMessage("Kategori ismi minimum 10 karakterden oluşmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(150)
                .WithMessage("Kategori ismi Maximum 150 karakterden oluşmalıdır");
            RuleFor(x => x.CategoryUrl).NotEmpty().WithMessage("Kategori URL Adresi belirtilmelidir.");
            RuleFor(x => x.IsActive).NotEmpty().WithMessage("Kategorinin aktiflik durumu belirtilmelidir");
            

        }
    }
}