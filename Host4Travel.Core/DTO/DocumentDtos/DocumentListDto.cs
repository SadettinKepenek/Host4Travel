using System;

namespace Host4Travel.Core.DTO.DocumentDtos
{
    public class DocumentListDto
    {
        public Guid DocumentId { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime DocumentUploadDate { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerSurname { get; set; }
        public string OwnerUserName { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}