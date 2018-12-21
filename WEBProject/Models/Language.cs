using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Language
    {
        [Key]
        public int LangID { get; set; }
        [MaxLength(4)]
        [Required]
        public string LangTag { get; set; }

        public Language(int langID, string langTag)
        {
            LangID = langID;
            LangTag = langTag;
        }
    }
}
