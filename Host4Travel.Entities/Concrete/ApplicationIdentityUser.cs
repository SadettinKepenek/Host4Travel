using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Host4Travel.UI.Identity
{
    public class ApplicationIdentityUser:IdentityUser
    {
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<PostApplication> PostApplication { get; set; }
        public virtual ICollection<PostRating> PostRating { get; set; }
    }
}