using System.Data.SqlClient;
using System.Data;
using WebApplication1616.Models;

namespace WebApplication1616.BusinessLogic_bl
{
    public class Calculator_bl
    {
        public static bool Insertdata(AdditionViewModel obj)
        {
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


                    SqlCommand cmd = new SqlCommand("sp_tbl_calculator", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@number1", obj.number1);
                    cmd.Parameters.AddWithValue("@number2", obj.number2);
                    cmd.Parameters.AddWithValue("@action", obj.action);
                    cmd.Parameters.AddWithValue("@result", obj.result);
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
                catch (Exception)
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
