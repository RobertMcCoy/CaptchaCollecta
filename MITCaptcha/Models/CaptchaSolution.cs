using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITCaptcha.Models
{
    public class CaptchaSolution
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "solution")]
        public string Solution { get; set; }
    }

    public class CaptchaSolutionWrapper
    {
        [JsonProperty(PropertyName = "solutions")]
        public List<CaptchaSolution> Solutions { get; set; }
    }
}
