
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace WebApplication1616.Models
{
    public class OrdersModel
    {
         public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public int ShipVia { get; set; }
      
        public int Freight { get; set; }
        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }
        public string ShipPostalCode { get; set; }
        public string ShipCountry { get; set; }
        public int SNO { get; set; }

    }
}
