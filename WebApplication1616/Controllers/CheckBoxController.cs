using Microsoft.AspNetCore.Mvc;
using WebApplication1616.Models;
using WebApplication1616.Controllers;
using WebApplication1616.BusinessLogic_bl;
namespace WebApplication1616.Controllers
{
    public class CheckBoxController : Controller
    {
        [HttpGet]

        public IActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public IActionResult login2()
        {
            return View();
        }


      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(TASK1 obj)
        {
            if (ModelState.IsValid)
            {
                bool res = CheckBoxCURD.Data(obj);
                if (res == true)
                {
                    return View("Register");
                }
                else
                {
                    return View();
                }

            }
            else
            {
                return View();
            }

        }
        public IActionResult homepage()
        {
            return View();

        }
    }
}
