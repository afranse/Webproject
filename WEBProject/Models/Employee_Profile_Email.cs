using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WEBProject.Models
{
    public class Employee_Profile_Email
    {
        [Key]
        public string Email { get; set; }
        [ForeignKey("ProfileID")]
        public int ProfileID { get; set; }
        public virtual Employee_Profile Employee { get; set; }
    }
}
