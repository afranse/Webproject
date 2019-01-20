using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Recipe_Details
    {
        [Key]
        public int DetailID { get; set; }
        [Required]
        public string RecipeDetails { get; set; }
        [ForeignKey("RecipeID")]
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
    }
}
