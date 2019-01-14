using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class NormalCategory_Product
    {
        public int CategoryID { get; set; }
        public virtual Normal_Category Normal_Category { get; set; }
        public int ArticleNumber { get; set; }
        public virtual Product Product { get; set; }
    }
}
