using System;
using MITCaptcha.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MITCaptcha.Tests
{
    [TestClass]
    public class ThePrompter
    {
        private static CaptchaRequester _requester;

        [ClassInitialize()]
        public static void Setup(TestContext testContext)
        {
            _requester = new CaptchaRequester();
        }

        [TestMethod]
        public void HasAJsonParserClass()
        {
            var captchaWrapper = _requester.ParseJson();
            Assert.IsNotNull(captchaWrapper);
        }

        [TestMethod]
        public void HasADecoderForBase64()
        {
            var captchaWrapper = _requester.ParseJson();
            var base64Strings = _requester.DecodeCaptchaRequest(captchaWrapper.Captchas[0]);
            Assert.IsNotNull(base64Strings);
        }
    }
}
