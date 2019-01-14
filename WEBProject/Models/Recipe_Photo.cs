using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Recipe_Photo
    {
        public int RecipeID { get; set; }
        public virtual Recipe Recipe { get; set; }
        public int PhotoID { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
