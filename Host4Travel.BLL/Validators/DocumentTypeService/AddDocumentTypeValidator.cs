using FluentValidation;
using Host4Travel.Core.DTO.DocumentTypeService;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.BLL.Validators.DocumentTypeService
{
    public class AddDocumentTypeValidator:AbstractValidator<DocumentTypeAddDto>
    {
        public AddDocumentTypeValidator()
        {
            RuleFor(x => x.DocumentTypeName).NotNull().NotEmpty().WithMessage("Document Type Name boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Document Type Aktiflik durumu boş geçilemez");
        }
    }
}