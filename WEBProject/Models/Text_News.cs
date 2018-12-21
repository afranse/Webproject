using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Text_News
    {
        public int NewsID { get; set; }
        public virtual News_Item News { get; set; }
        public int TextID { get; set; }
        public virtual Text Text { get; set; }
    }
}
