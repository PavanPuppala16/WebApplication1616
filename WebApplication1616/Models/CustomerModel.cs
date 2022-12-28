using System.Configuration;
using System.Data.SqlClient;
namespace WebApplication1616.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
