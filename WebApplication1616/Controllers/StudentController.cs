using Microsoft.AspNetCore.Mvc;
using WebApplication1616.Models;
using WebApplication1616.Controllers;
using WebApplication1616.BusinessLogic_bl;

namespace WebApplication1616.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Login()
        {

            return View();
        }
        [HttpGet]
        public IActionResult Register()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(Model obj)
        {
            if (ModelState.IsValid)
            {
                bool res = Student_bl.InsertData(obj);
                if (res == true)
                {
                    return View();
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
        public IActionResult forgotpassword()
        {
            return View();
        }


    }
}
