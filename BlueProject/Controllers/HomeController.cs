using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlueProject.Models;

namespace BlueProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Test(List<int> x, string y )
        {
            return View();
        }
        
        public IActionResult Test2()  
        { 
            var model = new TestModel();
            model.X = 7;
            model.Y = "Yera";
            return Json(model);
            // return (new {X =7, Y="Yera"}) 
            // return File("filePath", "applicaiton/octet-stream/", "filename") 
        }
        
        public IActionResult Test3(string x, string y)
        {
            ViewBag.x = x;
            ViewBag.y = y;
            List<TestModel> list = new List<TestModel>();
            list.Add(new TestModel(){X=1, Y="A"});
            list.Add(new TestModel(){X=2, Y="A"});
            list.Add(new TestModel(){X=3, Y="C"});
            list.Add(new TestModel(){X=7, Y="K"});
            ViewBag.list = list;
            return View(list);
        }
    }
}