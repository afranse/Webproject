using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.Models;
using WEBProject.Data;

namespace WEBProject.SearchEngine
{
    public class RecipeSearch : DatabaseObject
    {
        private Recipe R;

        public RecipeSearch(WebsiteContext DB) : base(DB) { }

        public override void SetObject(object Uknown)
        {
            if (R == null)
            {
                R = (Recipe)Uknown;
                base.Count();
            }
            else
            {
                new ArgumentException("Object already set");
            }
        }

        public override string GetSearchAbleString()
        {
            return R.Name;
        }

        public override bool Check(object Uknown)
        {
            if (Uknown.GetType() == typeof(Recipe))
            {
                Recipe NeedsCheck = (Recipe)Uknown;
                if (NeedsCheck.Name == R.Name && NeedsCheck.RecipeID == R.RecipeID)
                {
                    base.Count();
                    return true;
                }
            }
            return false;
        }

        public override string GetPhotoURL()
        {
            WebsiteContext DB = base.GetDB();
            Recipe_Photo RP = DB.Recipe_Photos.Where(y => y.RecipeID == R.RecipeID).FirstOrDefault();
            if (RP == null) return null;
            Photo temp = DB.Photos.Where(x => x.PhotoID == RP.PhotoID).FirstOrDefault();
            if (temp == null) return null;
            else
            {
                return temp.PhotoPath;
            }
        }

        public override string GetContent()
        {
            WebsiteContext DB = base.GetDB();
            IQueryable<int> B = DB.TypeCategory_Recipes.Where(x => x.RecipeID == R.RecipeID).Select(q => q.TypeID);
            List<Type_Category> TC = DB.Type_Categories.Where(y => B.Contains(y.TypeID)).ToList();
            string Content = null;
            for (int i = 0; i < TC.Count(); i++)
            {
                if (Content != null)
                {
                    Content += " ";
                }
                Content += TC.ElementAt(i).Name;
            }
            return Content;
        }

        public override string GetRedirectURL()
        {
            return null;
        }
    }
}
