using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Product_Details
    {
        [Key]
        public int DetailID {get; set;}
        [Required]
        public string ProductDetails { get; set; }
        [ForeignKey("ArtikelNumber")]
        public int ArtikelNumber { get; set; }
        public virtual Product Product { get; set; }
    }
}
