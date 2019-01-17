using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.Models;
using WEBProject.Data;

namespace WEBProject.SearchEngine
{
    public class NewsSearch : DatabaseObject
    {
        private News_Item N;

        public NewsSearch(WebsiteContext DB) : base(DB) { }

        public override void SetObject(object Uknown)
        {
            if (N == null)
            {
                N = (News_Item)Uknown;
                base.Count();
            }
            else
            {
                new ArgumentException("Object already set");
            }
        }

        public override string GetSearchAbleString()
        {
            return N.Title;
        }

        public News_Item GetNews()
        {
            return N;
        }

        public override bool Check(object Uknown)
        {
            if (Uknown.GetType() == typeof(News_Item))
            {
                News_Item NeedsCheck = (News_Item)Uknown;
                if (NeedsCheck.Title == N.Title && NeedsCheck.NewsID == N.NewsID)
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
            Photo_News NI = DB.Photo_News.Where(y => y.NewsID == N.NewsID).FirstOrDefault();
            if (NI == null) return null;
            Photo temp =  DB.Photos.Where(x => x.PhotoID == NI.PhotoID).FirstOrDefault();
            if (temp == null) return null;
            else
            {
                return temp.PhotoPath;
            }
        }

        public override string GetContent()
        {
            return N.News_Category.Category;
        }

        public override string GetRedirectURL()
        {
            return null;
        }
    }
}
