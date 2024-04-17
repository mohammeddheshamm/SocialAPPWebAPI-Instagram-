using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Entity.Identity
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }

    }
}
