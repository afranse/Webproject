using System;
using Xunit;
using WEBProject.Models;
using WEBProject.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTesten
{
    public class RecipesControllerTest
    {
        private InMemoryDB DB;
        private WEBProject.Data.WebsiteContext context;
        private RecipesController rc;


        public RecipesControllerTest()
        {
            DB = new InMemoryDB();
            context = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(context);
            rc = new RecipesController(context);
        }
        //[Fact]
        //public void IndexInRecipesController()
        //{
        //    RecipesController c = new RecipesController();
        //    var result = c.Index();

        //    //result moet een view zijn
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    Assert.Null(viewResult.ViewName);
        //}

        [Fact]
        public void TestGetRecipes()
        {
            var result = rc.GetRecipes(1);
            Assert.Equal(context.Recipes.ToList()[0], result.ToList()[0]);
            Assert.Equal(context.Recipes.ToList()[1], result.ToList()[1]);
            Assert.Equal(context.Recipes.ToList()[2], result.ToList()[2]);
        }
    }
}
