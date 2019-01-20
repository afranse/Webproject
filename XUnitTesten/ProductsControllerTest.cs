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

        private InMemoryDB DB;
        private WEBProject.Data.WebsiteContext context;
        private ProductsController c;

        public ProductsControllerTest()
        {
            DB = new InMemoryDB();
            context = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(context);
            c = new ProductsController(context);
        }

        [Fact]
        public void TestIndexInProductsController()
        {
            string[] array1 = new string[0];
            string[] array2 = new string[0];
            var result = c.Index(0, array1, array2);

            //result moet een view zijn
            var viewResult = Assert.IsType<ViewResult>(result);
            Assert.Null(viewResult.ViewName);
        }

        [Fact]
        public void TestGetSelectedTypes()
        {
            //Test #1
            int i = context.Type_Categories.ToList()[0].TypeID;
            string[] array = new string[] { "T " + i };
            var result = c.getTypes(array);

            Assert.Equal(i, result.ToList()[0].TypeID);


            //Test #2
            context = DB.GetInMemoryDB(true);

            array = new string[] { "SKJHGD" };
            var result1 = c.getTypes(array);

            Assert.Empty(result1.ToList());
        }

        [Fact]
        public void TestGetSelectedCats()
        {
            //Test #1
            int i = context.Normal_Categories.ToList()[0].CategoryID;
            string[] array = new string[] { "C " + i};
            var result = c.GetCategories(array);

            Assert.Equal(i, result.ToList()[0].CategoryID);


            //Test #2
            context = DB.GetInMemoryDB(true);

            array = new string[] { "SKJHGD" };
            var result1 = c.GetCategories(array);

            Assert.Empty(result1.ToList());
        }



        [Fact]
        public void TestGetBranches()
        {
            var result = c.getBranches();

            Assert.Equal(context.Branch_Categories.ToList()[0], result.ToList()[0]);
            Assert.Equal(context.Branch_Categories.ToList()[1], result.ToList()[1]);
            Assert.Equal(context.Branch_Categories.ToList()[2], result.ToList()[2]);
        }

        [Fact]
        public void TestgetAllCategorie()
        {
            //Test #1
            List<WEBProject.Models.Type_Category> list = new List<Type_Category>
            {
                context.Type_Categories.ToList()[0],
                context.Type_Categories.ToList()[1]
            };

            var result = c.getAllCategorie(list);

            Assert.Equal(result.ToList()[0], context.Normal_Categories.ToList()[0]);
            Assert.Equal(result.ToList()[1], context.Normal_Categories.ToList()[1]);
            Assert.Equal(result.ToList()[2], context.Normal_Categories.ToList()[2]);
            Assert.Equal(result.ToList()[3], context.Normal_Categories.ToList()[3]);

            //Test #2
            list = new List<Type_Category>
            {
                context.Type_Categories.ToList()[0]
            };

            var result1 = c.getAllCategorie(list);

            Assert.Equal(result1.ToList()[0], context.Normal_Categories.ToList()[0]);
            Assert.Equal(result1.ToList()[1], context.Normal_Categories.ToList()[1]);
            Assert.Equal(result1.ToList()[2], context.Normal_Categories.ToList()[2]);

            //Test #3
            list = new List<Type_Category>();

            var result2 = c.getAllCategorie(list);

            Assert.Empty(result2.ToList());

            //Test #4
            list = new List<Type_Category>
            {
                context.Type_Categories.ToList()[1]
            };

            var result4 = c.getAllCategorie(list);

            Assert.Equal(result4.ToList()[0], context.Normal_Categories.ToList()[3]);
        }

        [Fact]
        public void TestgetAllTypes()
        {
            //Test #1
            int BranchID = context.Branch_Categories.ToList()[0].BranchID;

            var result = c.getAllTypes(BranchID);

            Assert.Equal(result.ToList()[0], context.Type_Categories.ToList()[0]);
            Assert.Equal(result.ToList()[1], context.Type_Categories.ToList()[1]);

            //Test #2
            BranchID = -1;

            var result1 = c.getAllTypes(BranchID);

            Assert.Empty(result1);
        }

        [Fact]
        public void TestGetProducts()
        {
            //Test #1
            int BranchID = context.Branch_Categories.ToList()[0].BranchID;
            List<Type_Category> Types = new List<Type_Category>
            {
                context.Type_Categories.ToList()[0],
                context.Type_Categories.ToList()[1]
            };
            List<Normal_Category> Categories = new List<Normal_Category>
            {
                context.Normal_Categories.ToList()[0],
                context.Normal_Categories.ToList()[1],
                context.Normal_Categories.ToList()[2],
                context.Normal_Categories.ToList()[3],
            };

            var result = c.GetProducts(BranchID, Types, Categories);

            Assert.Equal(context.Products.ToList()[0], result.ToList()[0]);
            Assert.Equal(context.Products.ToList()[1], result.ToList()[1]);
            Assert.Equal(context.Products.ToList()[3], result.ToList()[2]);

            //Test #2
            BranchID = context.Branch_Categories.ToList()[0].BranchID;
            Types = new List<Type_Category>
            {
                context.Type_Categories.ToList()[0],
                context.Type_Categories.ToList()[1]
            };
            Categories = new List<Normal_Category>();

            var result2 = c.GetProducts(BranchID, Types, Categories);

            Assert.Empty(result2.ToList());

            //Test #3
            BranchID = context.Branch_Categories.ToList()[0].BranchID;
            Types = new List<Type_Category>
            {
                context.Type_Categories.ToList()[0],
            };
            Categories = new List<Normal_Category>
            {
                context.Normal_Categories.ToList()[2],
            };

            var result3 = c.GetProducts(BranchID, Types, Categories);

            Assert.Equal(context.Products.ToList()[0], result.ToList()[0]);
        }

        //[Fact]
        //public void TestSpecificProductInProductsController()
        //{
        //    var result = c.SpecificProduct(1);
        //    Employee_Profile contact = context.Employee_Profiles.ToList()[0];

        //    //result moet een view zijn
        //    var viewResult = Assert.IsType<ViewResult>(result);
        //    Assert.Null(viewResult.ViewName);
        //}

        [Fact]
        public void TestFoutmeldingInProductsController()
        {
            var result = c.SpecificProduct(10);
            // result moet een foutmelding zijn
            var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
            
        }
        
        //[Fact]
        //public void TestRelatedProducts()
        //{
        //    DB = new InMemoryDB();
        //    context = DB.GetInMemoryDB(true);
        //    SeederInMemoryDB.Seed(context);
        //    context.SaveChanges();
        //    //when there are no other products with the same category
        //    var result = c.RelatedProduct(context.Products.ToList()[0]);
        //    Assert.Empty(result.ToList());
        //}
        

        [Fact]
        public void TestInspirationRecipe()
        {
            //test the right amount
            var result = c.InspirationRecipe();
            Assert.Equal(2, result.Count);

            //test when context.recipy is empty            
            context.Recipes = null;
            var result2 = c.InspirationRecipe();
            Assert.Empty(result2);
        }
    }
}
