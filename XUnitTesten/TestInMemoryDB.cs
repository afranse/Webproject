using System;
using Xunit;
using WEBProject.Data;
using WEBProject.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace XUnitTesten
{
    public class TestInMemoryDB
    {
        [Fact]
        public void TestSeeder()
        {
            InMemoryDB DB = new InMemoryDB();
            WebsiteContext C = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seeder_Chicken(C);
            Assert.Equal("Chicken", C.Branch_Categories.ToList().ElementAt(0).Name);
            Assert.Equal("ChickenSoup", C.Type_Categories.ToList().ElementAt(0).Name);
            Assert.Equal("SaltChicken", C.Normal_Categories.ToList().ElementAt(0).Name);
            Assert.Equal(2,C.Type_Categories.ToList().Count());
            Assert.Equal(4, C.Normal_Categories.ToList().Count());
            Assert.Equal(3, C.Recipes.ToList().Count());
            Assert.Equal(3, C.TypeCategory_Recipes.ToList().Count());
            Assert.Equal((double)2.56, C.TypeCategory_Recipes.ToList().ElementAt(2).Weight);
        }
    }
}
