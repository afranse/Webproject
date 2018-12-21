using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Text
    {
        [Key]
        public int TextID { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual List<Text_News> TextNews { get; set; }

    }
}
