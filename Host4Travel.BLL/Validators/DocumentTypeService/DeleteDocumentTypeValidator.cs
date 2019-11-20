using FluentValidation;
using Host4Travel.Core.DTO.DocumentTypeService;

namespace Host4Travel.BLL.Validators.DocumentTypeService
{
    public class DeleteDocumentTypeValidator:AbstractValidator<DocumentTypeDeleteDto>
    {
        public DeleteDocumentTypeValidator()
        {
            RuleFor(x => x.DocumentTypeId).NotNull().NotEmpty();
        }
    }
}