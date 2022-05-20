using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlueProject.Models;
using MySqlConnector;

namespace BlueProject.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return Redirect("/Login/Login");
        }
        
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        [Route("login/login")]
        public IActionResult LoginProc([FromForm] UserModel input)
        {
            return Json(new {});
        }
        
        public IActionResult Register(string msg)     
        {
            ViewData["msg"] = msg;
            return View();
        }
        
        [HttpPost]
        [Route("login/register")]
        public IActionResult RegisterProc([FromForm] UserModel input)
        {
            try
            {
                input.Register();
                return Redirect("/Login/Login");
            }
            catch (Exception e)
            {
                return Redirect($"Login/Register?msg={HttpUtility.UrlEncode(e.Message)}");
            }
            
        }
    }
}    