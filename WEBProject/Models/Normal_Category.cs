using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Normal_Category
    {
        [Key]
        public int CategoryID { get; set; }
        [Required]
        public string Name { get; set; } // Name: What is there inside this branch?
        [ForeignKey("TypeID")]
        public int TypeID { get; set; }
        public virtual Type_Category TypeCategory { get; set; }
        public virtual List<NormalCategory_Product> Products { get; set; }
    }
}
