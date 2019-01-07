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
        public int ArticleNumber { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; } // For management only. Not for the customer website.
        public string Contents { get; set; }
        public virtual List<Product_Details> Details { get; set; }
        public virtual List<NormalCategory_Product> NormalCategory { get; set; }
        public virtual List<Product_Text> ProductText { get; set; }
        public virtual List<Product_Photo> ProductPhoto { get; set; }
    }
}
