using FluentValidation;
using Host4Travel.Core.DTO.CategoryDtos;

namespace Host4Travel.BLL.Validators.CategoryService
{
    public class DeleteCategoryValidator:AbstractValidator<CategoryDeleteDto>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.CategoryId).NotNull().NotEmpty().WithMessage("Kategori Identifier Boş geçilemez");
        }
    }
}