using Microsoft.AspNetCore.Mvc;

namespace WebApplication1616.Controllers
{
    public class PartialpostController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
