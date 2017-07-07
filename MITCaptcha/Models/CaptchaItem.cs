using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MITCaptcha.Models
{
    public class CaptchaItem
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "jpg_base64")]
        public string JpegBase64 { get; set; }
    }

    public class CaptchaWrapper
    {
        [JsonProperty(PropertyName = "images")]
        public List<CaptchaItem> Captchas { get; set; }
    }
}
