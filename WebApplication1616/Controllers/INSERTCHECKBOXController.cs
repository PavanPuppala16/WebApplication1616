using Microsoft.AspNetCore.Mvc;
using WebApplication1616.BusinessLogic_bl;
using WebApplication1616.Models;
using System.Data.SqlClient;

namespace WebApplication1616.Controllers
{
    public class INSERTCHECKBOXController : Controller
    {
        [HttpGet]
        public IActionResult DESIGN()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DESIGN(INSERTCHECKBOX OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = INSERTCHECKBOX_BL.InsertData(OBJ);
                if (res == true)
                {
                    return View("Happy");
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
    }
}