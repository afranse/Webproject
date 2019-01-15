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
// Used documents: https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory

namespace XUnitTesten
{
    class InMemoryDB
    {
        private WebsiteContext _Context {get; set; }

        public WebsiteContext GetInMemoryDB(bool NewDB)
        {
            if (NewDB == true)
            {
                var options = new DbContextOptionsBuilder<WebsiteContext>()
                    .UseInMemoryDatabase(Guid.NewGuid().ToString()).UseLazyLoadingProxies()
                    .Options;
                _Context = new WebsiteContext(options);
            }

            return _Context;
        }
    }
}
