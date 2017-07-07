using System;
using System.Collections.Generic;
using System.Text;
using MITCaptcha.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace MITCaptcha.Tests
{
    [TestClass]
    public class TheCaptchaController
    {
        [TestMethod]
        public async Task HasAnIndex()
        {
            CaptchaController controller = new CaptchaController();
            //var result = await controller.Index();
        }

    }
}
