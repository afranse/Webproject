using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class TypeCategory_Recipe
    {
        public int TypeID { get; set; }
        public virtual Type_Category Type_Category { get; set; }
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        public double Weight { get; set; }
        public int Percent { get; set; }
    }
}
