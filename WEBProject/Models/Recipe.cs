using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }
        public string Name { get; set; }
        public virtual List<Recipe_Photo> RecipePhotos { get; set; }
        public virtual List<Recipe_Text> RecipeTexts { get; set; }
        public virtual List<TypeCategory_Recipe> TypeCategories { get; set; }
    }
}
