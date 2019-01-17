using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using WEBProject.Models;
using WEBProject.Controllers;
using WEBProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
// Used documents: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory

namespace XUnitTesten
{
    class InMemoryDB
    {
        private WebsiteContext C {get; set; }

        public WebsiteContext GetInMemoryDB(bool NewDB)
        {
            if (NewDB == true)
            {
                var options = new DbContextOptionsBuilder<WebsiteContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).UseLazyLoadingProxies()
                    .Options;
                C = new WebsiteContext(options);
            }

            return C;
        }

        public int BranchCategoryPKConvert(int i)
        {
            int min = C.Branch_Categories.ToList().ElementAt(0).BranchID;
            int current = C.Branch_Categories.ToList().ElementAt(i).BranchID;
            return (current - min + 1);
        }

        public int TypeCategoryPKConvert(int i)
        {
            int min = C.Type_Categories.ToList().ElementAt(0).TypeID;
            int current = C.Type_Categories.ToList().ElementAt(i).TypeID;
            return (current - min + 1);
        }

        public int NormalCategoryPKConvert(int i)
        {
            int min = C.Normal_Categories.ToList().ElementAt(0).CategoryID;
            int current = C.Normal_Categories.ToList().ElementAt(i).CategoryID;
            return (current - min + 1);
        }

        public int ProductPKConvert(int i)
        {
            int min = C.Products.ToList().ElementAt(0).ArticleNumber;
            int current = C.Products.ToList().ElementAt(i - min).ArticleNumber;
            return (current - min + 1);
        }

        public int ProductDetailsPKConvert(int i)
        {
            int min = C.Product_Details.ToList().ElementAt(0).DetailID;
            int current = C.Product_Details.ToList().ElementAt(i - min).DetailID;
            return (current - min + 1);
        }

        public int RecipePKConvert(int i)
        {
            int min = C.Recipes.ToList().ElementAt(0).RecipeID;
            int current = C.Recipes.ToList().ElementAt(i - min).RecipeID;
            return (current - min + 1);
        }

        public int NewsItemPKConvert(int i)
        {
            int min = C.News_Items.ToList().ElementAt(0).NewsID;
            int current = C.News_Items.ToList().ElementAt(i - min).NewsID;
            return (current - min + 1);
        }

        public int NewsCategoryPKConvert(int i)
        {
            int min = C.News_Categories.ToList().ElementAt(0).CategoryID;
            int current = C.News_Categories.ToList().ElementAt(i - min).CategoryID;
            return (current - min + 1);
        }

        public int LanguagePKConvert(int i)
        {
            int min = C.Languages.ToList().ElementAt(0).LangID;
            int current = C.Languages.ToList().ElementAt(i - min).LangID;
            return (current - min + 1);
        }

        public int PhotoPKConvert(int i)
        {
            int min = C.Photos.ToList().ElementAt(0).PhotoID;
            int current = C.Photos.ToList().ElementAt(i - min).PhotoID;
            return (current - min + 1);
        }

        public int SubscriberPKConvert(int i)
        {
            int min = C.Subscribers.ToList().ElementAt(0).SubscriberID;
            int current = C.Subscribers.ToList().ElementAt(i - min).SubscriberID;
            return (current - min + 1);
        }

        public int EmployeeProfilePKConvert(int i)
        {
            int min = C.Employee_Profiles.ToList().ElementAt(0).Employee_ProfileID;
            int current = C.Employee_Profiles.ToList().ElementAt(i - min).Employee_ProfileID;
            return (current - min + 1);
        }
    }
}
