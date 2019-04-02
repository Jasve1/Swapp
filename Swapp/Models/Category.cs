using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Swapp.Models
{
    [Table("Category")]
    public class Category
    {
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
    }
}
