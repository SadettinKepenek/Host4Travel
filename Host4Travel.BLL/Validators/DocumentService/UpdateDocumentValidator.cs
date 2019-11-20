using FluentValidation;
using Host4Travel.Core.DTO.DocumentService;

namespace Host4Travel.BLL.Validators.DocumentService
{
    public class UpdateDocumentValidator:AbstractValidator<DocumentUpdateDto>
    {
        public UpdateDocumentValidator()
        {
            RuleFor(x => x.DocumentId).NotNull().NotEmpty();
            RuleFor(x => x.DocumentUrl).NotNull().NotEmpty();
            RuleFor(x => x.IsActive).NotNull().NotEmpty();
            RuleFor(x => x.OwnerId).NotNull().NotEmpty();
            RuleFor(x => x.DocumentTypeId).NotNull().NotEmpty();
            RuleFor(x => x.DocumentUploadDate).NotNull().NotEmpty();
        }
    }
}