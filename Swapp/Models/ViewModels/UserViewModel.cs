using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swapp.Models;

namespace Swapp.Models.ViewModels
{
    public class UserViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public AppUser AppUser { get; set; }
    }
}
