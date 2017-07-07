using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MITCaptcha.Models
{
    public class SolverViewModel
    {
        public CaptchaItem CaptchaItem { get; set; }
        public CaptchaSolution CaptchaSolution { get; set; }
    }
}
