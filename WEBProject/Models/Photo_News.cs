using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Photo_News
    {
        public int NewsID { get; set; }
        public virtual News_Item News { get; set; }
        public int PhotoID { get; set; }
        public virtual Photo Photo { get; set; }
    }
}
