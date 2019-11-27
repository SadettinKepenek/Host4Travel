using FluentValidation;
using Host4Travel.Core.DTO.DocumentDtos;

namespace Host4Travel.BLL.Validators.DocumentService
{
    public class DeleteDocumentValidator:AbstractValidator<DocumentDeleteDto>
    {
        public DeleteDocumentValidator()
        {
            RuleFor(x => x.DocumentId).NotNull().NotEmpty();
        }
    }
}