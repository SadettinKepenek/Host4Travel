using System;
using System.Collections.Generic;
using Host4Travel.UI;
using Microsoft.AspNetCore.Identity;

namespace Host4Travel.Entities.Concrete
{
    public class ApplicationIdentityUser:IdentityUser
    {
        public virtual ICollection<Post> Post { get; set; }
        public virtual ICollection<PostApplication> PostApplication { get; set; }
        public virtual ICollection<PostRating> PostRating { get; set; }
        public virtual ICollection<Document> Documents { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string CookieAcceptIpAddress { get; set; }
        public DateTime CookieAcceptDate { get; set; }
        public bool IsCookieAccepted { get; set; }
        public bool IsVerified { get; set; }
        public bool IsActive { get; set; }
    }
}