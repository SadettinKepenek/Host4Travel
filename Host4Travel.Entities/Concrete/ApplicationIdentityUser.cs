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

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SSN { get; set; }
        public string CookieAcceptIpAddress { get; set; }
    }
}