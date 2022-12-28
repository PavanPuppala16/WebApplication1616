using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using WebApplication1616.Models;
namespace WebApplication1616.BusinessLogic_bl
{
	public class Operation_bl
	{
        public static bool Insert(calculator3 obj)
        {

            string result = obj.result;
            string operation = "";
            int length = 0;
            int number1 = 0;
            int number2 = 0;
            float result2 = 0;
            if (result.Contains("+"))
            {
                operation = "+";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 + number2;
            }
            if (result.Contains("-"))
            {
                operation = "-";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 - number2;
            }
            if (result.Contains("*"))
            {
                operation = "*";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 * number2;
            }
            if (result.Contains("/"))
            {
                operation = "/";
                length = result.Length - result.IndexOf(operation) - 1;
                number1 = Convert.ToInt32(result.Substring(0, result.IndexOf(operation)));
                number2 = Convert.ToInt32(result.Substring(result.IndexOf(operation) + 1, length));
                result2 = number1 / number2;

            }

            bool res = false;
            var dbconfig = new ConfigurationBuilder()
                      .SetBasePath(Directory.GetCurrentDirectory())
                      .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {


                    con.Open();
                    SqlCommand cmd = new SqlCommand("insert into Calculators values(@number1,@number2,@operation,@result)", con);
                    // cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@number1", number1);
                    cmd.Parameters.AddWithValue("@number2", number2);
                    cmd.Parameters.AddWithValue("@operation", operation);
                    cmd.Parameters.AddWithValue("@result", result2);

                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        return res = true;
                    }
                    else
                    {
                        return res = false;
                    }

                }
                catch (Exception ex)
                {

                }
                finally
                {
                    con.Close();
                }
                return res = true;
            }
        }
    }
}
	