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
namespace XUnitTesten
{
    class SeederInMemoryDB
    {
        public static void Seeder_Chicken(WebsiteContext C)
        {
            Branch_Category Chicken = new Branch_Category
            {
                Name = "Chicken"
            };

            Branch_Category Pork = new Branch_Category
            {
                Name = "Pork"
            };

            Branch_Category Fruit = new Branch_Category
            {
                Name = "Fruit"
            };

            Type_Category ChickenSoup = new Type_Category
            {
                Name = "ChickenSoup",
                BranchCategory = Chicken,
            };

            Type_Category ChickenEgg = new Type_Category
            {
                Name = "ChickenEgg",
                BranchCategory = Chicken,
            };

            Chicken.TypeCategory = new List<Type_Category>();
            Chicken.TypeCategory.Add(ChickenSoup);
            Chicken.TypeCategory.Add(ChickenEgg);
            ChickenSoup.BranchCategory = Chicken;
            ChickenEgg.BranchCategory = Chicken;

            Normal_Category SaltChicken = new Normal_Category
            {
                Name = "SaltChicken"
            };

            Normal_Category SweetChicken = new Normal_Category
            {
                Name = "SweetChicken"
            };

            Normal_Category NoChicken = new Normal_Category
            {
                Name = "NoChicken"
            };

            Normal_Category GingerChicken = new Normal_Category
            {
                Name = "GingerChicken"
            };

            ChickenSoup.NormalCategory = new List<Normal_Category>();
            ChickenEgg.NormalCategory = new List<Normal_Category>();
            ChickenSoup.NormalCategory.Add(SaltChicken);
            ChickenSoup.NormalCategory.Add(SweetChicken);
            ChickenSoup.NormalCategory.Add(NoChicken);
            ChickenEgg.NormalCategory.Add(GingerChicken);
            SaltChicken.TypeCategory = ChickenSoup;
            SweetChicken.TypeCategory = ChickenSoup;
            NoChicken.TypeCategory = ChickenSoup;
            GingerChicken.TypeCategory = ChickenEgg;

            Recipe ChickenWings = new Recipe
            {
                Name = "ChickenWings"
            };

            Recipe ChickenNoodles = new Recipe
            {
                Name = "ChickenNoodles"
            };

            Recipe Spinach = new Recipe
            {
                Name = "Spinach"
            };

            TypeCategory_Recipe SpinachSoup = new TypeCategory_Recipe
            {
                Type_Category = ChickenSoup,
                Recipe = Spinach,
                Percent = 10,
                Weight = 0.5
            };

            TypeCategory_Recipe ChickenRecipe = new TypeCategory_Recipe
            {
                Type_Category = ChickenEgg,
                Recipe = ChickenWings,
                Percent = 15,
                Weight = 2.6
            };

            TypeCategory_Recipe ChickenRecipe2 = new TypeCategory_Recipe
            {
                Type_Category = ChickenEgg,
                Recipe = Spinach,
                Percent = 80,
                Weight = 2.56
            };

            Product ChickenSticks = new Product
            {
                Name = "ChickenSticks",
                Description = "small",
                Contents = "very small",
            };

            Product Ketchup = new Product
            {
                Name = "Ketchup",
                Description = "big",
                Contents = "very big",
            };

            Product Curry = new Product
            {
                Name = "Curry",
                Description = "Scary",
                Contents = "thing",
            };

            Product Bread = new Product
            {
                Name = "Bread",
                Description = "Useless",
                Contents = "thing",
            };

            NormalCategory_Product ZeroChickenGiven = new NormalCategory_Product
            {
                Product = ChickenSticks,
                Normal_Category = NoChicken
            };

            NormalCategory_Product BreadChicken = new NormalCategory_Product
            {
                Product = Bread,
                Normal_Category = SaltChicken
            };

            NormalCategory_Product SaltyChicken = new NormalCategory_Product
            {
                Product = Ketchup,
                Normal_Category = SaltChicken
            };

            Product_Details PD0 = new Product_Details
            {
                Product = Curry,
                ProductDetails = "Tastes bad"
            };

            Product_Details PD1 = new Product_Details
            {
                Product = Bread,
                ProductDetails = "White"
            };

            Curry.Details = new List<Product_Details>();
            Bread.Details = new List<Product_Details>();
            Curry.Details.Add(PD0);
            Bread.Details.Add(PD1);
            PD0.Product = Curry;
            PD1.Product = Bread;

            Text CurryText = new Text
            {
                Content = "Bla Bla Pizza"
            };

            Text KetchupText = new Text
            {
                Content = "Hi Hi Hi"
            };

            Text Important = new Text
            {
                Content = "No Live"
            };

            Text Important2 = new Text
            {
                Content = "Oh No"
            };

            Product_Text PT0 = new Product_Text
            {
                Product = Bread,
                Text = Important
            };

            Product_Text PT1 = new Product_Text
            {
                Product = Bread,
                Text = Important2
            };

            Product_Text PT2 = new Product_Text
            {
                Product = ChickenSticks,
                Text = CurryText
            };

            Recipe_Text RT0 = new Recipe_Text
            {
                Recipe = Spinach,
                Text = KetchupText
            };

            Recipe_Text RT1 = new Recipe_Text
            {
                Recipe = ChickenNoodles,
                Text = KetchupText
            };

            Recipe_Text RT2 = new Recipe_Text
            {
                Recipe = ChickenNoodles,
                Text = Important2
            };

            News_Item MadPizza = new News_Item
            {
                Event_Date = new DateTime().AddYears(2020).AddMonths(11).AddDays(2),
                Title = "MadPizza",
                Last_Modified_Date = new DateTime().AddYears(1996).AddMonths(1).AddDays(5)
            };

            News_Item HappyPizza = new News_Item
            {
                Event_Date = new DateTime().AddYears(2020).AddMonths(11).AddDays(3),
                Title = "HappyPizza",
                Last_Modified_Date = new DateTime().AddYears(1996).AddMonths(1).AddDays(5)
            };

            Text_News TN0 = new Text_News
            {
                News = MadPizza,
                Text = CurryText
            };

            Text_News TN1 = new Text_News
            {
                News = MadPizza,
                Text = KetchupText
            };

            Text_News TN2 = new Text_News
            {
                News = HappyPizza,
                Text = CurryText
            };

            Language NL = new Language
            {
                LangTag = "nl"
            };

            Language EN = new Language
            {
                LangTag = "en"
            };

            Language DE = new Language
            {
                LangTag = "de"
            };

            CurryText.Language = NL;
            Important.Language = NL;
            Important2.Language = EN;
            KetchupText.Language = DE;

            NL.Texts = new List<Text>();
            EN.Texts = new List<Text>();
            DE.Texts = new List<Text>();
            NL.Texts.Add(CurryText);
            NL.Texts.Add(Important);
            EN.Texts.Add(Important2);
            DE.Texts.Add(KetchupText);

            News_Category Mad = new News_Category
            {
                Category = "Mad"
            };

            News_Category Happy = new News_Category
            {
                Category = "Happy"
            };

            MadPizza.News_Category = Mad;
            HappyPizza.News_Category = Happy;
            Mad.Items = new List<News_Item>();
            Happy.Items = new List<News_Item>();
            Mad.Items.Add(MadPizza);
            Happy.Items.Add(HappyPizza);

            Photo AA = new Photo
            {
                PhotoPath = "/Img/uknownA.img"
            };

            Photo BB = new Photo
            {
                PhotoPath = "/Img/uknownB.img"
            };

            Photo CC = new Photo
            {
                PhotoPath = "/Img/uknownC.png"
            };

            Product_Photo AAA = new Product_Photo
            {
                Product = Ketchup,
                Photo = AA
            };

            Product_Photo BBB = new Product_Photo
            {
                Product = Curry,
                Photo = BB
            };

            Product_Photo CCC = new Product_Photo
            {
                Product = ChickenSticks,
                Photo = CC
            };

            Recipe_Photo RP0 = new Recipe_Photo
            {
                Recipe = ChickenWings,
                Photo = AA
            };

            Recipe_Photo RP1 = new Recipe_Photo
            {
                Recipe = ChickenWings,
                Photo = BB
            };

            Recipe_Photo RP2 = new Recipe_Photo
            {
                Recipe = ChickenNoodles,
                Photo = CC
            };

            Recipe_Photo RP3 = new Recipe_Photo
            {
                Recipe = ChickenNoodles,
                Photo = AA
            };

            Photo_News PN0 = new Photo_News
            {
                Photo = AA,
                News = MadPizza
            };

            Photo_News PN1 = new Photo_News
            {
                Photo = BB,
                News = HappyPizza
            };

            Employee_Profile Henk = new Employee_Profile
            {
                Name = "Henk",
                Job = "Sleeping",
            };

            Employee_Profile Johan = new Employee_Profile
            {
                Name = "Johan",
                Job = "Sales",
            };

            Employee_Profile Marit = new Employee_Profile
            {
                Name = "Marit",
                Job = "ICT",
            };

            Employee_Profile_Email EHenk = new Employee_Profile_Email
            {
                Email = "z@zzzz.com"
            };

            Employee_Profile_Email EJohan = new Employee_Profile_Email
            {
                Email = "Johan@sales.nl"
            };

            Employee_Profile_Email EMarit = new Employee_Profile_Email
            {
                Email = "Marit@ICTDesk.net"
            };

            Employee_Profile_Email EMarit2 = new Employee_Profile_Email
            {
                Email = "Marit@ICTDesk.eu",
            };

            EMarit.Employee = Marit;
            EMarit2.Employee = Marit;
            EHenk.Employee = Henk;
            EJohan.Employee = Johan;
            Marit.Emails = new List<Employee_Profile_Email>();
            Henk.Emails = new List<Employee_Profile_Email>();
            Johan.Emails = new List<Employee_Profile_Email>();
            Marit.Emails.Add(EMarit);
            Marit.Emails.Add(EMarit2);
            Henk.Emails.Add(EHenk);
            Johan.Emails.Add(EJohan);

            Employee_Profile_Phone_Number N0 = new Employee_Profile_Phone_Number
            {
                Number = "3160000000000"
            };

            Employee_Profile_Phone_Number N1 = new Employee_Profile_Phone_Number
            {
                Number = "3160000000001"
            };

            N0.Employee = Henk;
            N1.Employee = Henk;
            Henk.Phone_Numbers = new List<Employee_Profile_Phone_Number>();
            Henk.Phone_Numbers.Add(N0);
            Henk.Phone_Numbers.Add(N1);

            Subscriber Sleep = new Subscriber
            {
                Email = "z@zzzz.com"
            };

            Subscriber Pizza = new Subscriber
            {
                Email = "pizza@mad.nl"
            };

            C.Branch_Categories.Add(Chicken);
            C.Branch_Categories.Add(Pork);
            C.Branch_Categories.Add(Fruit);
            C.Type_Categories.Add(ChickenSoup);
            C.Type_Categories.Add(ChickenEgg);
            C.Normal_Categories.Add(SaltChicken);
            C.Normal_Categories.Add(SweetChicken);
            C.Normal_Categories.Add(NoChicken);
            C.Normal_Categories.Add(GingerChicken);
            C.Recipes.Add(ChickenWings);
            C.Recipes.Add(ChickenNoodles);
            C.Recipes.Add(Spinach);
            C.TypeCategory_Recipes.Add(SpinachSoup);
            C.TypeCategory_Recipes.Add(ChickenRecipe);
            C.TypeCategory_Recipes.Add(ChickenRecipe2);
            C.Products.Add(ChickenSticks);
            C.Products.Add(Ketchup);
            C.Products.Add(Curry);
            C.Products.Add(Bread);
            C.NormalCategory_Products.Add(ZeroChickenGiven);
            C.NormalCategory_Products.Add(BreadChicken);
            C.NormalCategory_Products.Add(SaltyChicken);
            C.Product_Details.Add(PD0);
            C.Product_Details.Add(PD1);
            C.Text.Add(CurryText);
            C.Text.Add(KetchupText);
            C.Text.Add(Important);
            C.Text.Add(Important2);
            C.Product_Texts.Add(PT0);
            C.Product_Texts.Add(PT1);
            C.Product_Texts.Add(PT2);
            C.Recipe_Texts.Add(RT0);
            C.Recipe_Texts.Add(RT1);
            C.Recipe_Texts.Add(RT2);
            C.News_Items.Add(MadPizza);
            C.News_Items.Add(HappyPizza);
            C.Text_News.Add(TN0);
            C.Text_News.Add(TN1);
            C.Text_News.Add(TN2);
            C.Languages.Add(NL);
            C.Languages.Add(EN);
            C.Languages.Add(DE);
            C.News_Categories.Add(Mad);
            C.News_Categories.Add(Happy);
            C.Photos.Add(AA);
            C.Photos.Add(BB);
            C.Photos.Add(CC);
            C.Product_Photos.Add(AAA);
            C.Product_Photos.Add(BBB);
            C.Product_Photos.Add(CCC);
            C.Recipe_Photos.Add(RP0);
            C.Recipe_Photos.Add(RP1);
            C.Recipe_Photos.Add(RP2);
            C.Recipe_Photos.Add(RP3);
            C.Photo_News.Add(PN0);
            C.Photo_News.Add(PN1);
            C.Employee_Profiles.Add(Henk);
            C.Employee_Profiles.Add(Johan);
            C.Employee_Profiles.Add(Marit);
            C.Employee_Profile_Emails.Add(EHenk);
            C.Employee_Profile_Emails.Add(EJohan);
            C.Employee_Profile_Emails.Add(EMarit);
            C.Employee_Profile_Emails.Add(EMarit2);
            C.Employee_Profile_Phone_Numbers.Add(N0);
            C.Employee_Profile_Phone_Numbers.Add(N1);
            C.Subscribers.Add(Sleep);
            C.Subscribers.Add(Pizza);

            C.SaveChanges();
        }
    }
}
