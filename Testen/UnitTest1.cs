using System;
using Xunit;
using WEBProject.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace Testen
{
    public class UnitTest1
    {
        [Fact]
        public void IndexInHomeController()
        {
            HomeController c = new HomeController();
            var result = c.Index();

        }
    }
}
