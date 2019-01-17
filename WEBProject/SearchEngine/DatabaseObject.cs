using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.Data;

namespace WEBProject.SearchEngine
{
    public abstract class DatabaseObject
    // This is the parent class of:
    // EmployeeSearch, NewsSearch, ProductSearch and RecipeSearch.
    {
        private readonly WebsiteContext DB;

        public DatabaseObject(WebsiteContext DB)
        {
            this.DB = DB;
        }

        public WebsiteContext GetDB()
        {
            return DB;
        }

        // The amount of hits a certain word gets.
        private int Counter;

        // This returns the Content from a child. This Method is needed for the tests.
        public abstract string GetSearchAbleString();

        public abstract string GetPhotoURL();

        public abstract string GetContent();

        public abstract string GetRedirectURL();

        // Sets the object in the private of the child.
        public abstract void SetObject(object Uknown);

        // This method compares the Uknown object with the private of the child.
        public abstract bool Check(object Uknown);

        protected void Count() {
            Counter++;
        }

        public int GetCounter()
        {
            return Counter;
        }
    }
}
