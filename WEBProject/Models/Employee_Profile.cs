using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WEBProject.Models
{
    public class Employee_Profile
    {
        [Key]
        public int Employee_ProfileID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Job { get; set; }
        public virtual List<Employee_Profile_Email> Emails { get; set; }
        public virtual List<Employee_Profile_Phone_Number> Phone_Numbers { get; set; }

        public Employee_Profile(int employee_ProfileID, string name, string job)
        {
            Employee_ProfileID = employee_ProfileID;
            Name = name;
            Job = job;
        }
        public Employee_Profile()
        {

        }
    }
}
