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
    public class SubscriptionControllerTest
    {
        private InMemoryDB DB;
        private WEBProject.Data.WebsiteContext context;
        private SubscriptionController c;

        public SubscriptionControllerTest()
        {
            DB = new InMemoryDB();
            context = DB.GetInMemoryDB(true);
            SeederInMemoryDB.Seed(context);
            c = new SubscriptionController(context);
        }

        [Fact]
        public void subscribeTest()
        {
            context = DB.GetInMemoryDB(true);
            string mail = "Test@Testmail.Test";
            c.subscribe(mail);
            Assert.Equal(context.Subscribers.ToList()[0].Email, mail);
        }
        [Fact]
        public void unsubscribeTest()
        {
            string mail = "Test@Testmail.Test";
            c.Unsubscribe(mail);
            Assert.Empty(context.Subscribers.ToList());
        }
    }
}
