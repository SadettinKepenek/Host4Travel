using System;
using Host4Travel.Core.DTO.AuthService;
using Host4Travel.Core.DTO.DocumentTypeService;
using Host4Travel.Entities.Concrete;

namespace Host4Travel.Core.DTO.DocumentService
{
    public class DocumentListDto
    {
        public Guid DocumentId { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime DocumentUploadDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public virtual DocumentTypeListDto DocumentType { get; set; }
        public virtual ApplicationIdentityUserListDto Owner { get; set; }
    }
}