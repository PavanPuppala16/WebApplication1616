using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApplication1616.Models;
using WebApplication1616.BusinessLogic_bl;

namespace WebApplication1616.Controllers
{
    public class RoleBasedController : Controller
    {
        [HttpGet]
        public IActionResult Access()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Access(RoleBaseLoginModel obj)
        {

            if (string.IsNullOrEmpty(obj.EmailID) && string.IsNullOrEmpty(obj.Password))
            {
                return RedirectToAction("Login");
            }
            ClaimsIdentity identity = null;
            bool isAuthentic = false;
            if (obj.EmailID == "admin@yahoo.com" && obj.Password == "Admin@123")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.EmailID),
                    new Claim(ClaimTypes.Role,"Admin")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (obj.EmailID == "user@yahoo.com" && obj.Password == "User@123")
            {
                identity = new ClaimsIdentity(new[]
                    {
                    new Claim(ClaimTypes.Name,obj.EmailID),
                    new Claim(ClaimTypes.Role,"User")
                    },
                     CookieAuthenticationDefaults.AuthenticationScheme);
                isAuthentic = true;
            }
            if (isAuthentic)
            {
                var principals = new ClaimsPrincipal(identity);
                var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principals);
                return RedirectToAction("Display", "RoleBased");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Display()
        {
            return View(DISPLAYDATA.GetALLData());
        }
    }
}
