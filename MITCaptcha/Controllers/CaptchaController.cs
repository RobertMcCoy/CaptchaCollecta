using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using MITCaptcha.Services;
using MITCaptcha.Models;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace MITCaptcha.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _env;

        public HomeController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult Index()
        {
            CaptchaRequester requester = new CaptchaRequester();
            var captchaResults = requester.ParseJson(_env.ContentRootPath + "/captchas.json");
            SolverViewModel viewModel = new SolverViewModel
            {
                CaptchaItem = captchaResults.Captchas[0],
                CaptchaSolution = new CaptchaSolution()
                {
                    Name = captchaResults.Captchas[0].Name
                }
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Post(SolverViewModel solution)
        {
            var alreadyDone = false;
            if (!string.IsNullOrWhiteSpace(solution.CaptchaSolution.Name) && !string.IsNullOrWhiteSpace(solution.CaptchaSolution.Solution))
            {
                var jsonFile = _env.ContentRootPath + "/solutions.json";
                var jsonData = System.IO.File.ReadAllText(jsonFile);
                var captchaSolutions = JsonConvert.DeserializeObject<CaptchaSolutionWrapper>(jsonData);
                foreach (CaptchaSolution solutions in captchaSolutions.Solutions)
                {
                    if (solutions.Name == solution.CaptchaItem.Name)
                    {
                        alreadyDone = true;
                    }
                }
                if (!alreadyDone)
                {
                    captchaSolutions.Solutions.Add(solution.CaptchaSolution);
                    jsonData = JsonConvert.SerializeObject(captchaSolutions);
                    System.IO.File.WriteAllText(jsonFile, jsonData);
                }
                DeleteCaptchaFromCaptchasJson(solution.CaptchaSolution.Name);
            }
            return RedirectToAction("Index");
        }

        private void DeleteCaptchaFromCaptchasJson(string name)
        {
            var jsonFile = _env.ContentRootPath + "/captchas.json";
            var jsonData = System.IO.File.ReadAllText(jsonFile);
            var captchaProblems = JsonConvert.DeserializeObject<CaptchaWrapper>(jsonData);
            var solved = captchaProblems.Captchas.Single(i => i.Name == name);
            captchaProblems.Captchas.Remove(solved);
            jsonData = JsonConvert.SerializeObject(captchaProblems);
            System.IO.File.WriteAllText(jsonFile, jsonData);
        }
    }
}