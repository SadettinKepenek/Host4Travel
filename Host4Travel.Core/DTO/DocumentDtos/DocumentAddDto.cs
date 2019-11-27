using System;

namespace Host4Travel.Core.DTO.DocumentDtos
{
    public class DocumentAddDto
    {
        public string DocumentUrl { get; set; }
        public DateTime DocumentUploadDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public int DocumentTypeId { get; set; }
    }
}