using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using MITCaptcha.Models;
using Newtonsoft.Json;
using System.Text;

namespace MITCaptcha.Services
{
    public class CaptchaRequester
    {
        //const string CAPTCHA_URL = @"https://captcha.delorean.codes/u/RobertMcCoy/challenge";

        //public async Task<string> GetJsonAsync()
        //{
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(CAPTCHA_URL);
        //    HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;

        //    using (Stream stream = response.GetResponseStream())
        //    {
        //        using (StreamReader reader = new StreamReader(stream))
        //        {
        //            return reader.ReadToEnd();
        //        }
        //    }
        //}

        public CaptchaWrapper ParseJson(string location)
        {
            var jsonData = File.ReadAllText(location);
            var captchaProblems = JsonConvert.DeserializeObject<CaptchaWrapper>(jsonData);
            return captchaProblems;
        }

        public string DecodeCaptchaRequest(CaptchaItem captchaItem)
        {
            var base64EncodedBytes = Convert.FromBase64String(captchaItem.JpegBase64.Replace("\\",""));
            return Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}