using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Product
    {
        [Key]
        public int ArtikelNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contents { get; set; }
        public virtual List<Product_Details> Details { get; set; }
    }
}
