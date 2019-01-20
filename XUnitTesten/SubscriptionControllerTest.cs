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
            //Test #1
            string mail = "Test@Testmail.Test";
            bool b = c.canAdd(mail);
            Assert.True(b);

            //Test #2
            mail = "";
            b = c.canAdd(mail);
            Assert.False(b);

            //Test #3
            mail = null;
            b = c.canAdd(mail);
            Assert.False(b);
        }
        [Fact]
        public void unsubscribeTest()
        {
            //Test #1
            string mail = "Test@Testmail.Test";
            bool b = c.canRemove(mail);
            Assert.False(b);

            //Test #2
            mail = "Test@Testmail.Test";
            context.Subscribers.Add(new Subscriber { Email = "Test@Testmail.Test" });
            context.SaveChanges();
            b = c.canRemove(mail);
            Assert.True(b);

            //Test #3
            mail = "";
            b = c.canRemove(mail);
            Assert.False(b);

            //Test #4
            mail = null;
            b = c.canRemove(mail);
            Assert.False(b);
        }
    }
}
