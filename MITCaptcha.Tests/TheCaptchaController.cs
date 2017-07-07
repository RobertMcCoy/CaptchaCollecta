using System;
using System.Collections.Generic;
using System.Text;
using MITCaptcha.Controllers;
using MITCaptcha.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FakeItEasy;
using Microsoft.AspNetCore.Hosting;

namespace MITCaptcha.Tests
{
    [TestClass]
    public class TheCaptchaController
    {
        [TestMethod]
        public void HasAnIndex()
        {
            HomeController controller = new HomeController(A.Fake<IHostingEnvironment>());
            var result = controller.Index() as ViewResult;
            Assert.IsInstanceOfType(result.Model, typeof(SolverViewModel));
        }
    }
}
