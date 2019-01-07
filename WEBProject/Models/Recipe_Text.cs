using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Recipe_Text
    {
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int TextID { get; set; }
        public virtual Text Text { get; set; }
    }
}
