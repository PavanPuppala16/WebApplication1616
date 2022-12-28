using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Xml.Linq;
using WebApplication1616.Models;

namespace WebApplication1616.Controllers
{
    public class ALERTController : Controller
    {
        [HttpGet]
        public IActionResult ALERTMSG()
        {
            return View();
     
       }
        [HttpPost]
        public ActionResult ALERTMSG(CustomerModel customer)
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "INSERT INTO Customer1(Name, Country) VALUES(@Name, @Country)";
                query += " SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@Name", customer.Name);
                    cmd.Parameters.AddWithValue("@Country", customer.Country);
                    customer.CustomerId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }

            return View(customer);
        }

        [HttpGet]
        public IActionResult HIMSG()
        {
            return View();
        }
        [HttpPost]
        public IActionResult HIMSG(string name)
        {

            ViewBag.Message = string.Format("WELCOME TO MY PAVANPUPPALA1616 WORLD {0}.\\nCurrent Date and Time: {1}", name, DateTime.Now.ToString());
            return View();
        }


    }
}

