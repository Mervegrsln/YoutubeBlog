using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YoutubeBlog.Entity.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Guid? ImageId { get; set; } // <-- Düzeltme: Nullable yapıldı!
        public Image? Image { get; set; }  // <-- Düzeltme: İlişkili nesne de nullable yapılmalı!
        public ICollection<Article> Articles { get; set; }
    }
}