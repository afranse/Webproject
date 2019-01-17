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
    public class ProductsControllerTest
    {

        private InMemoryDB IMDB = new InMemoryDB();
        private WEBProject.Data.WebsiteContext context;
        private ProductsController c;

        public ProductsControllerTest()
        {
            context = IMDB.GetInMemoryDB(true);
            SeederInMemoryDB.Seeder_Chicken(context);
            c = new ProductsController(context);
        }

        [Fact]
        public void IndexInProductsController()
        {
            string[] array1 = new string[0];
            string[] array2 = new string[0]; 
            var result = c.Index(0, array1, array2);

            //result moet een view zijn
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void getSelectedTypes()
        {
            string[] array = new string[] {"A", "B 2", "C987"};
            var result = c.getTypes(array);



        }


    }
}
