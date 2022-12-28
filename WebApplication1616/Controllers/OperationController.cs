using Microsoft.AspNetCore.Mvc;
using WebApplication1616.Models;
using WebApplication1616.BusinessLogic_bl;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Configuration;

namespace WebApplication1616.Controllers
{
	public class OperationController : Controller
	{
        [HttpGet]
        public IActionResult Index()
		{
			return View();
		}
        
       
        [HttpPost]

        public IActionResult Index(calculator3 OBJ)
        {
            if (ModelState.IsValid)
            {
                bool res = Operation_bl.Insert(OBJ);
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
            return View();
        }
    }
}