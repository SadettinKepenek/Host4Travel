using System;
using System.Collections.Generic;

namespace Host4Travel.UI
{
    public partial class PostImage
    {
        public Guid ImageId { get; set; }
        public Guid PostId { get; set; }
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
        public bool IsActive { get; set; }

        public virtual Post Post { get; set; }
    }
}
