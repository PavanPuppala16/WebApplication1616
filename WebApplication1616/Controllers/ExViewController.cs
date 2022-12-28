using Microsoft.AspNetCore.Mvc;
using WebApplication1616.Models;

namespace WebApplication1616.Controllers
{
    public class ExViewController : Controller
    {
        public IActionResult ExonViewData()
        {
            ViewData["vd"] = "I Am Storing somedata using Viewdata Prop";
            ViewBag.vb = "I Am Storing somedata using ViewBag Prop";
            TempData["td"] = "I Am Storing somedata using TempData Prop";
            return RedirectToAction("StoreData","SecondExView");
        }
        public ActionResult ViewDataEx()
        {
            List<viewDataModel> emplist = new List<Models.viewDataModel>();
            emplist.Add(
                new viewDataModel
                {
                    Eid = 1,
                    Name = "Xyz",
                    Address = "Hyd"
                });
            emplist.Add(
                new viewDataModel { Eid = 2, Name = "Anu", Address = "Banglore" });
            emplist.Add(
                new viewDataModel { Eid = 3, Name = "Sam", Address = "Delhi" });
            TempData["EmpList"] = emplist;
            return View();
        }
    }
}
