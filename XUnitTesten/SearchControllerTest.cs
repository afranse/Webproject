using System;
using Xunit;
using WEBProject.Data;
using WEBProject.Models;
using WEBProject.Controllers;
using WEBProject.SearchEngine;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTesten
{
    public class SearchControllerTest
    {
        private DatabaseObject EmployeeTest { get; set; }
        private DatabaseObject ProductTest { get; set; }
        private DatabaseObject RecipeTest { get; set; }
        private DatabaseObject NewsTest { get; set; }

        private WebsiteContext GetInMemoryDBWithSeeder()
        {
            WebsiteContext C = GetInMemoryDB();
            SeederInMemoryDB.Seed(C);
            return C;
        }

        private WebsiteContext GetInMemoryDB()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            return C;
        }

        private void FillDatabaseObjects()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);

            DatabaseObject Employee = new EmployeeSearch(C);
            DatabaseObject Product = new ProductSearch(C);
            DatabaseObject Recipe = new RecipeSearch(C);
            DatabaseObject News = new NewsSearch(C);

            Employee.SetObject(C.Employee_Profiles.ToList().ElementAt(0));
            Product.SetObject(C.Products.ToList().ElementAt(0));
            Recipe.SetObject(C.Recipes.ToList().ElementAt(0));
            News.SetObject(C.News_Items.ToList().ElementAt(0));

            EmployeeTest = Employee;
            ProductTest = Product;
            RecipeTest = Recipe;
            NewsTest = News;
        }

        //[Fact]
        //public void IndexSearchController()
        //{
        //    WebsiteContext C = GetInMemoryDBWithSeeder();
        //    SearchController c = new SearchController(C);
        //    var result = c.Index("",null);

        //    //result moet een view zijn
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    Assert.Null(viewResult.ViewName);
        //}

        [Fact]
        public async void SingleProductName()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Ketchup");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("Ketchup", q);
        }

        [Fact]
        public async void SingleRecipeName()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("ChickenWings");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("ChickenWings", q);
        }

        [Fact]
        public async void SingleNewsItemTitle()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("HappyPizza");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("HappyPizza", q);
        }

        [Fact]
        public async void SingleEmployeeName()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Marit");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("Marit", q);
        }

        [Fact]
        public async void DoubleSearchSingleAwnserTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Marit Marit");
            Assert.Equal("Marit", x.ElementAt(0).GetSearchAbleString());
            Assert.Equal(2, x.ElementAt(0).GetCounter());
            //------
            // How to test an exception: https://stackoverflow.com/questions/45017295/assert-an-exception-using-xunit
            Assert.Throws<System.ArgumentOutOfRangeException>(() => x.ElementAt(1));
            //------

        }

        [Fact]
        public async void TotalSearchTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Marit Marit Ketchup ChickenWings HappyPizza");
            Assert.Equal("Marit", x.ElementAt(0).GetSearchAbleString());
            Assert.Equal(2, x.ElementAt(0).GetCounter());
            Assert.Equal(4, x.Count());
            Assert.Equal("Ketchup", x.ElementAt(1).GetSearchAbleString());
            Assert.Equal("ChickenWings", x.ElementAt(2).GetSearchAbleString());
            Assert.Equal("HappyPizza", x.ElementAt(3).GetSearchAbleString());
        }

        [Fact]
        public async void EmployeePartTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("han");
            Assert.Equal("Johan", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void EmployeeNoCapitalsTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("JOHAN");
            Assert.Equal("Johan", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void RecipePartTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Nood");
            Assert.Equal("ChickenNoodles", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void RecipeNoCapitalsTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("CHICKENNOODLES");
            Assert.Equal("ChickenNoodles", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void ProductPartTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Stick");
            Assert.Equal("ChickenSticks", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void ProductNoCapitalsTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("CHICKENSTICKS");
            Assert.Equal("ChickenSticks", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void NewsItemPartTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("appyP");
            Assert.Equal("HappyPizza", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void NewsItemNoCapitalsTest()
        {
            WebsiteContext C = GetInMemoryDBWithSeeder();
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("HAPPYPIZZA");
            Assert.Equal("HappyPizza", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestProduct()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            Product P = new Product();
            P.Name = "Cheese";
            SC.AddDBO(P, new ProductSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestRecipe()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            Recipe P = new Recipe();
            P.Name = "Cheese";
            SC.AddDBO(P, new RecipeSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestNewsItem()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            News_Item P = new News_Item
            {
                Title = "Cheese"
            };
            SC.AddDBO(P, new NewsSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestEmployee()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            Employee_Profile P = new Employee_Profile
            {
                Name = "Cheese"
            };
            SC.AddDBO(P, new EmployeeSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestProductWithCounter()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            Product P0 = new Product
            {
                Name = "Cheese"
            };
            Product P1 = new Product
            {
                Name = "Cheese"
            };
            Product P2 = new Product
            {
                Name = "Cheese"
            };
            SC.AddDBO(P0, new ProductSearch(C));
            SC.AddDBO(P1, new ProductSearch(C));
            SC.AddDBO(P2, new ProductSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
            Assert.Equal(3, SC.DBO.ElementAt(0).GetCounter());
        }

        [Fact]
        public void AddDBOTestRecipeWithCounter()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            Recipe P0 = new Recipe
            {
                Name = "Cheese"
            };
            Recipe P1 = new Recipe
            {
                Name = "Cheese"
            };
            Recipe P2 = new Recipe
            {
                Name = "Cheese"
            };
            SC.AddDBO(P0, new RecipeSearch(C));
            SC.AddDBO(P1, new RecipeSearch(C));
            SC.AddDBO(P2, new RecipeSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
            Assert.Equal(3, SC.DBO.ElementAt(0).GetCounter());
        }

        [Fact]
        public void AddDBOTestNewsItemWithCounter()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            News_Item P0 = new News_Item
            {
                Title = "Cheese"
            };
            News_Item P1 = new News_Item
            {
                Title = "Cheese"
            };
            News_Item P2 = new News_Item
            {
                Title = "Cheese"
            };
            SC.AddDBO(P0, new NewsSearch(C));
            SC.AddDBO(P1, new NewsSearch(C));
            SC.AddDBO(P2, new NewsSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
            Assert.Equal(3, SC.DBO.ElementAt(0).GetCounter());
        }

        [Fact]
        public void AddDBOTestEmployeeWithCounter()
        {
            WebsiteContext C = GetInMemoryDB();
            SearchController SC = new SearchController(C);
            Employee_Profile P0 = new Employee_Profile
            {
                Name = "Cheese"
            };
            Employee_Profile P1 = new Employee_Profile
            {
                Name = "Cheese"
            };
            Employee_Profile P2 = new Employee_Profile
            {
                Name = "Cheese"
            };
            SC.AddDBO(P0, new EmployeeSearch(C));
            SC.AddDBO(P1, new EmployeeSearch(C));
            SC.AddDBO(P2, new EmployeeSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
            Assert.Equal(3, SC.DBO.ElementAt(0).GetCounter());
        }

        [Fact]
        public void GetPhotoURLTest()
        {
            FillDatabaseObjects();
            Assert.Equal("/images/Henk.png", EmployeeTest.GetPhotoURL());
            Assert.Equal("/Img/uknownC.png", ProductTest.GetPhotoURL());
            Assert.Equal("/Img/uknownA.img", RecipeTest.GetPhotoURL());
            Assert.Equal("/Img/uknownA.img", NewsTest.GetPhotoURL());
        }

        [Fact]
        public void GetContentTest()
        {
            FillDatabaseObjects();
            Assert.Equal("Sleeping", EmployeeTest.GetContent());
            Assert.Equal("SaltChicken very small", ProductTest.GetContent());
            Assert.Equal("ChickenEgg", RecipeTest.GetContent());
            Assert.Equal("Mad", NewsTest.GetContent());
        }
    }
}
