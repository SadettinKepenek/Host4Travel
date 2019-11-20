using FluentValidation;
using Host4Travel.Core.DTO.DocumentService;
using Host4Travel.Core.DTO.DocumentTypeService;

namespace Host4Travel.BLL.Validators.DocumentTypeService
{
    public class UpdateDocumentTypeValidator:AbstractValidator<DocumentTypeUpdateDto>
    {
        public UpdateDocumentTypeValidator()
        {
            RuleFor(x => x.DocumentTypeId).NotNull().NotEmpty();
            RuleFor(x => x.DocumentTypeName).NotNull().NotEmpty().WithMessage("Document Type Name boş geçilemez");
            RuleFor(x => x.IsActive).NotNull().NotEmpty().WithMessage("Document Type Aktiflik durumu boş geçilemez");
        }
    }
}