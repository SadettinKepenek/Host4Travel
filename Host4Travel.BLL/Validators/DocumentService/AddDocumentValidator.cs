using FluentValidation;
using Host4Travel.Core.DTO.DocumentService;

namespace Host4Travel.BLL.Validators.DocumentService
{
    public class AddDocumentValidator:AbstractValidator<DocumentAddDto>
    {
        public AddDocumentValidator()
        {
            RuleFor(x => x.DocumentUrl).NotNull().NotEmpty();
            RuleFor(x => x.IsActive).NotNull().NotEmpty();
            RuleFor(x => x.OwnerId).NotNull().NotEmpty();
            RuleFor(x => x.DocumentTypeId).NotNull().NotEmpty();
            RuleFor(x => x.DocumentUploadDate).NotNull().NotEmpty();
        }
    }
}