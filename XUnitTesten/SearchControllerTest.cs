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
        [Fact]
        public void IndexSearchController()
        {
            //HomeController c = new HomeController();
            //var result = c.Index();

            ////result moet een view zijn
            //var viewResult = Assert.IsType<ViewResult>(result);
            //Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public async void SingleProductName()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Ketchup");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("Ketchup", q);
        }

        [Fact]
        public async void SingleRecipeName()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("ChickenWings");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("ChickenWings", q);
        }

        [Fact]
        public async void SingleNewsItemTitle()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("HappyPizza");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("HappyPizza", q);
        }

        [Fact]
        public async void SingleEmployeeName()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Marit");
            string q = x.ElementAt(0).GetSearchAbleString();
            Assert.Equal("Marit", q);
        }

        [Fact]
        public async void DoubleSearchSingleAwnserTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("han");
            Assert.Equal("Johan", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void EmployeeNoCapitalsTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("JOHAN");
            Assert.Equal("Johan", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void RecipePartTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Nood");
            Assert.Equal("ChickenNoodles", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void RecipeNoCapitalsTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("CHICKENNOODLES");
            Assert.Equal("ChickenNoodles", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void ProductPartTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("Stick");
            Assert.Equal("ChickenSticks", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void ProductNoCapitalsTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("CHICKENSTICKS");
            Assert.Equal("ChickenSticks", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void NewsItemPartTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("appyP");
            Assert.Equal("HappyPizza", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public async void NewsItemNoCapitalsTest()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(C);
            SearchController SC = new SearchController(C);
            var x = await SC.SearchEngine("HAPPYPIZZA");
            Assert.Equal("HappyPizza", x.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestProduct()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SearchController SC = new SearchController(C);
            Product P = new Product();
            P.Name = "Cheese";
            SC.AddDBO(P, new ProductSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestRecipe()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SearchController SC = new SearchController(C);
            Recipe P = new Recipe();
            P.Name = "Cheese";
            SC.AddDBO(P, new RecipeSearch(C));
            Assert.Equal("Cheese", SC.DBO.ElementAt(0).GetSearchAbleString());
        }

        [Fact]
        public void AddDBOTestNewsItem()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
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
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
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
    }
}
