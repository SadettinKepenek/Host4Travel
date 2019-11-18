using System;
using System.ComponentModel.DataAnnotations;
using Host4Travel.UI;

namespace Host4Travel.Entities.Concrete
{
    public partial class PostImage
    {
        [Key]
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
    }
}
