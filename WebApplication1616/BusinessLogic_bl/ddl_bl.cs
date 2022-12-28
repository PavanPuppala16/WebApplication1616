using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WebApplication1616.Models;
namespace WebApplication1616.BusinessLogic_bl
{
    public class ddl_bl
    {
        public static List<OrdersModel> GETProductListbyID(string? CustomerID)
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd= new SqlCommand("select * from Orders where CustomerID=@CustomerID",con);
                cmd.Parameters.AddWithValue("@CustomerID",CustomerID);
                con.Open();
                SqlDataReader pdr = cmd.ExecuteReader();
                List<OrdersModel> customers = new List<OrdersModel>();
                if (pdr.HasRows)
                {
                    while(pdr.Read())
                    {
                        customers.Add(new OrdersModel
                        {
                            OrderID = Convert.ToInt32(pdr["OrderID"]),
                            CustomerID = Convert.ToString(pdr["CustomerID"]),
                            EmployeeID = Convert.ToInt32(pdr["EmployeeID"]),
                            OrderDate = Convert.ToDateTime(pdr["OrderDate"]),
                            RequiredDate = Convert.ToDateTime(pdr["RequiredDate"]),
                            ShippedDate = Convert.ToDateTime(pdr["ShippedDate"]),
                            ShipVia = Convert.ToInt32(pdr["OrderID"]),
                            Freight = Convert.ToInt32(pdr["OrderID"]),
                            ShipName = Convert.ToString(pdr["CustomerID"]),
                            ShipAddress = Convert.ToString(pdr["CustomerID"]),
                            ShipCity = Convert.ToString(pdr["CustomerID"]),
                            ShipRegion = Convert.ToString(pdr["CustomerID"]),
                            ShipPostalCode = Convert.ToString(pdr["CustomerID"]),
                            ShipCountry = Convert.ToString(pdr["CustomerID"]),
                            SNO = Convert.ToInt32(pdr["OrderID"])
                        });
                    }
                    con.Close();
                }
                return customers;
            }
            
        }
       
        public static List<DdlModel> PopulateData()
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            
                List<DdlModel> customers = new List<DdlModel>();
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                string query = "SP_GETDISTCUST";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            customers.Add(new DdlModel
                            {
                                CustomerID = Convert.ToString(sdr["CustomerID"])
                            });
                        }
                    }
                    con.Close();
                }
                return customers;
            }
        }
    }


}
