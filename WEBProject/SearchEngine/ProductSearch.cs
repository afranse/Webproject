using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBProject.Models;
using WEBProject.Data;

namespace WEBProject.SearchEngine
{
    public class ProductSearch : DatabaseObject
    {
        private Product P;

        public ProductSearch(WebsiteContext DB) : base(DB) { }

        public override void SetObject(object Uknown)
        {
            if (P== null)
            {
                P = (Product)Uknown;
                base.Count();
            } else
            {
                new ArgumentException("Object already set");
            }
        }

        public override string GetSearchAbleString()
        {
            return P.Name;
        }

        public Product GetProduct()
        {
            return P;
        }

        public override bool Check(object Uknown)
        {
            if (Uknown.GetType() == typeof(Product))
            {
                Product NeedsCheck = (Product)Uknown;
                if (NeedsCheck.Name == P.Name && NeedsCheck.ArticleNumber == P.ArticleNumber)
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
            Product_Photo PP = DB.Product_Photos.Where(y => y.ArticleNumber == P.ArticleNumber).FirstOrDefault();
            if (PP == null)
            {
                return null;
            }
            Photo temp = DB.Photos.Where(x => x.PhotoID == PP.PhotoID).FirstOrDefault();
            if (temp == null)
            {
                return null;
            }
            else
            {
                return temp.PhotoPath;
            }
        }

        public override string GetContent()
        {
            WebsiteContext DB = base.GetDB();
            IQueryable<int> B = DB.NormalCategory_Products.Where(x => x.ArticleNumber == P.ArticleNumber).Select(q => q.ArticleNumber);
            List<Normal_Category> NC = DB.Normal_Categories.Where(y => B.Contains(y.CategoryID)).ToList();
            string Content = null;
            for (int i = 0; i < NC.Count(); i++)
            {
                if (Content != null)
                {
                    Content += " ";
                }
                Content += NC.ElementAt(i).Name;
            }
            return Content + " " + P.Contents;
        }

        public override string GetRedirectURL()
        {
            return "/Products/SpecificProduct/" + P.ArticleNumber;
        }
    }
}
