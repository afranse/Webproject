using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class News_Item
    {
        [Key]
        public int NewsID { get; set; }
        public DateTime Event_Date { get; set; }
        [Required]
        public DateTime Last_Modified_Date { get; set; }
        [Required]
        public string Title { get; set; }

        [ForeignKey("CategoryID")]
        public int CategoryID { get; set; }
        public virtual News_Category News_Category { get; set; }

        public virtual List<Text_News> TextNews { get; set; }
        public virtual List<Photo_News> PhotoNews { get; set; }
    }
}
