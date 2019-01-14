using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Product_Photo
    {
        public int ArticleNumber { get; set; }
        public virtual Product Product { get; set; }
        public int PhotoID { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
