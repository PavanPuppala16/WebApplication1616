using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using WebApplication1616.BusinessLogic_bl;
using WebApplication1616.Models;

namespace WebApplication1616.Controllers
{
    public class OrdersDROPDOWNController : Controller
    {
        [HttpGet]
        public IActionResult OrdersDROPDOWN()
        {
            return View();
        }
        [HttpPost]
        public IActionResult OrdersDROPDOWN(Orders obj)
        {

            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {

                string query = "select OrderID,CustomerID from Orders ";

                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@OrderID", obj.OrderID);
                    cmd.Parameters.AddWithValue("@CustomerID", obj.CustomerID);
                    obj.CustomerID = Convert.ToString(cmd.ExecuteScalar());
                    con.Close();
                }
            }

            return View(obj);
        }

    }
}
