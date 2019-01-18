//using System;
//using Xunit;
//using WEBProject.Models;
//using WEBProject.Controllers;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;

//namespace XUnitTesten
//{
//    public class HomeControllerTest
//    {

//        /// in memory database

//        //private string databaseName; // zonder deze property kun je geen clean context maken.

//        //private WebsiteContext GetInMemoryDBMetData()
//        //{
//        //    WebsiteContext context = GetNewInMemoryDatabase(true);
//        //    //nieuwe instance van context
//        //    context.SaveChanges();
//        //    return GetNewMemoryDatabase(false); // gebruik een nieuw (clean) object voor de context
//        //}

//        //private WebsiteContext GetNewInMemoryDatabase(bool NewDb)
//        //{
//        //    if (NewDb) this.databaseName = Guid.NewGuid().ToString(); // unieke naam

//        //    var options = new DbContextOptionsBuilder<WebsiteContext>()
//        //        .UseInMemoryDatabase(this.databaseName)
//        //        .Options;

//        //    return new WebsiteContext(options);
//        //}

//        //..........................................

//        [Fact]
//        public void IndexInHomeController()
//        {
//            HomeController c = new HomeController();
//            var result = c.Index();

//            //result moet een view zijn
//            var viewResult = Assert.IsType<ViewResult>(result);
//            Assert.Null(viewResult.ViewName);
//        }
//    }
//}
