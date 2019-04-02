using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Swapp.Models.ViewModels;

namespace Swapp.Models
{

    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public int? PvalueId { get; set; }
        public int? PconditionId { get; set; }
        public string AspNetUserId { get; set; }

        public ICollection<Image> Images { get; set; }
        public AppUser AspNetUser { get; set; }
        public Category Category { get; set; }


        public Product() { }
    }
}
