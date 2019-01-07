using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Photo
    {
        [Key]
        public int PhotoID { get; set; }
        public string PhotoPath { get; set; }
        public virtual List<Photo_News> PhotoNews { get; set; }
        public virtual List<Recipe_Photo> PhotoRecipes { get; set; }
        public virtual List<Product_Photo> PhotoProducts { get; set; }
    }
}
