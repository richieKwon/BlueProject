using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BlueProject.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
        public IActionResult Login(string msg)
        {
            ViewData["msg"] = msg;
            return View();
        } 
        
        [HttpPost]
        [Route("login/login")]
        public async Task<IActionResult> LoginProc([FromForm] UserModel input)
        {
            try
            {
                var user = input.GetLoginUser();

                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name,
                    ClaimTypes.Role);
                identity.AddClaim(new Claim(ClaimTypes.Name, user.User_name.ToString()));
                identity.AddClaim(new Claim(ClaimTypes.Email, user.Email.ToString()));
                identity.AddClaim(new Claim("LastCheckDateTime", DateTime.UtcNow.ToString("yyyyMMddHHmmss")));

                if (user.User_name == "Yera")
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role,"ADMIN"));
                }

                var principal = new ClaimsPrincipal(identity);

                await  HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties
                    {
                        IsPersistent = false, ExpiresUtc = DateTime.UtcNow.AddHours(4), AllowRefresh = true
                    });

                return Redirect("/");
            }
            catch (Exception e)
            {
                return Redirect($"/login/loing?msg={HttpUtility.UrlEncode(e.Message)}");
            }
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
                input.ConvertPassword();
                input.Register();
                return Redirect("/Login/Login");
            }
            catch (Exception e)
            {
                return Redirect($"Login/Register?msg={HttpUtility.UrlEncode(e.Message)}");
            }
            
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}    