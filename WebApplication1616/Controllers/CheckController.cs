using Microsoft.AspNetCore.Mvc;
using WebApplication1616.BusinessLogic_bl;
using WebApplication1616.Models;
using System;
namespace WebApplication1616.Controllers
{
    public class CheckController : Controller
    {
        [HttpGet]
        public IActionResult Checking()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checking(Check OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = Checking_bl.Insertdata(OBJ);
                if (res == true)
                {

                    return View("Homepage");
                }
                else
                {
                    return View(OBJ);
                }
            }
            else
            {
                return View(OBJ);
            }
        }
        public IActionResult Homepage()
        {
            return View();
        }
    }
}
