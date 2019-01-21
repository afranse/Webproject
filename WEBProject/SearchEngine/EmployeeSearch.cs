using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.Models;
using WEBProject.Data;

namespace WEBProject.SearchEngine
{
    public class EmployeeSearch : DatabaseObject
    {
        private Employee_Profile E;

        public EmployeeSearch(WebsiteContext DB) : base(DB) { }

        public override void SetObject(object Uknown)
        {
            if (E == null)
            {
                E = (Employee_Profile)Uknown;
                base.Count();
            }
            else
            {
                new ArgumentException("Object already set");
            }
        }

        public override string GetSearchAbleString()
        {
            return E.Name;
        }

        public Employee_Profile GetEmployee()
        {
            return E;
        }

        public override bool Check(object Uknown)
        {
            if (Uknown.GetType() == typeof(Employee_Profile))
            {
                Employee_Profile NeedsCheck = (Employee_Profile)Uknown;
                if (NeedsCheck.Name == E.Name && NeedsCheck.Employee_ProfileID == E.Employee_ProfileID)
                {
                    base.Count();
                    return true;
                }
            }
            return false;
        }

        public override string GetPhotoURL()
        {
            return E.Profile_PhotoPath;
        }

        public override string GetContent()
        {
            return E.Job;
        }

        public override string GetRedirectURL()
        {
            return "/contact/SpecificContact/" + E.Employee_ProfileID;
        }
    }
}
