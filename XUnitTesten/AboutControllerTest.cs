﻿//using System;
//using Xunit;
//using WEBProject.Models;
//using WEBProject.Controllers;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.AspNetCore.Mvc;
//using System.Collections.Generic;
//using System.Linq;

//namespace XUnitTesten
//{
    
//    public class AboutControllerTest
//    {
//        [Fact]
//        public void IndexInAboutController()
//        {
//            AboutController c = new AboutController();
//            var result = c.Index();

//            //result moet een view zijn
//            var viewResult = Assert.IsType<ViewResult>(result);
//            Assert.Null(viewResult.ViewName);
//        }
//    }
//}
