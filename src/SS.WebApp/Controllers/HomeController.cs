using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DemoProject.Common;
using SS.Models;
using Newtonsoft.Json;

namespace DemoProject.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
            var a = new HttpClientapi();
            var k = a.Get<List<UserModel>>("api/user/getAll");
            ViewData["Message"] = JsonConvert.SerializeObject(k).ToString();
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
