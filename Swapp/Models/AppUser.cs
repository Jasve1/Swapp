using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Swapp.Models
{
    public class AppUser : IdentityUser
    {
        public string LastName { get; set; }
        public string ProfilePic { get; set; }
        public string City { get; set; }

    }
}
