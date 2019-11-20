using System;
using System.ComponentModel.DataAnnotations;

namespace Host4Travel.Entities.Concrete
{
    public class Document
    {
        [Key]
        public Guid DocumentId { get; set; }
        public string DocumentUrl { get; set; }
        public DateTime DocumentUploadDate { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
        public string OwnerId { get; set; }
        public int DocumentTypeId { get; set; }
        
        public virtual DocumentType DocumentType { get; set; }
        public virtual ApplicationIdentityUser Owner { get; set; }
    }
}