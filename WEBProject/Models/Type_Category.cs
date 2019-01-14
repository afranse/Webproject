using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Type_Category
    {
        [Key]
        public int TypeID { get; set; }
        [Required]
        public string Name { get; set; } // TypeName: What is there inside this branch?
        [ForeignKey("BranchID")]
        public int BranchID { get; set; }
        public virtual Branch_Category BranchCategory { get; set; }
        public virtual List<Normal_Category> NormalCategory { get; set; }
        public virtual List<TypeCategory_Recipe> Recipes { get; set; }
    }
}
