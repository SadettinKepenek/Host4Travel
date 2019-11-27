using System;
using Host4Travel.Core.DTO.DocumentTypeDtos;
using Host4Travel.Core.DTO.UserDtos;

namespace Host4Travel.Core.DTO.DocumentDtos
{
    public class DocumentDetailDto
    {
        public Guid DocumentId { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime DocumentUploadDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public virtual DocumentTypeDetailDto DocumentType { get; set; }
        public virtual UserDetailDto Owner { get; set; }
    }
}