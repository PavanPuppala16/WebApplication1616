using Microsoft.AspNetCore.Mvc;
using WebApplication1616.Models;
using WebApplication1616.BusinessLogic_bl;

namespace WebApplication1616.Controllers
{
    public class DDLController : Controller
    {
        [HttpGet]
        public IActionResult ViewDropDownVal()
        {
            ViewBag.data = ddl_bl.PopulateData();
            return View();
        }
        [HttpPost]
        public IActionResult ViewDropDownVal(string x)
        {
            ViewBag.data = Request.Form["test"].ToString();
            return View();
        }

        [HttpGet]
        public IActionResult GetDataonDDL()
        {
            ViewBag.data = ddl_bl.PopulateData();
            return View();
        }
        [HttpPost]
        public IActionResult GetDataonDDL(string customers)
        {
            ViewData["Val"] = ddl_bl.GETProductListbyID(Request.Form["test"].ToString());
            ViewBag.data = ddl_bl.PopulateData();
            return View();
        }
    }
}
