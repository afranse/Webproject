using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Branch_Category
    {
        [Key]
        public int BranchID { get; set; }
        [Required]
        public string Name { get; set; } // BranchName: What is there inside this branch?
        public virtual List<Type_Category> TypeCategory { get; set; }

    }
}
