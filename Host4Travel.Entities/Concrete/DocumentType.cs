using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Host4Travel.Entities.Concrete
{
    public class DocumentType
    {
        public DocumentType()
        {
            Documents=new HashSet<Document>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DocumentTypeId { get; set; }
        public string DocumentTypeName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
    }
}