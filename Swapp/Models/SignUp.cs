using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Swapp.Models
{
    public class SignUp
    {
        [Required]
        [Display(Name = "first name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "last name")]
        public string LastName { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Upload File")]
        [Required(ErrorMessage = "Please choose file to upload.")]
        public IFormFile ProfilePic { get; set; }

        [Required]
        [Display(Name = "city")]
        public string City { get; set; }

        [Required]
        [Display(Name = "email")]
        [Remote("ValidateEmail", "StartPage")]
        public string Email { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "password")]
        public string Password { get; set; }
    }
}
