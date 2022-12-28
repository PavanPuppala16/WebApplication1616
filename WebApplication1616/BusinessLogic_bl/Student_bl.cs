using System.Data.SqlClient;
using System.Data;

using System.Configuration;

using WebApplication1616.Models;


namespace WebApplication1616.BusinessLogic_bl
{
    public class Student_bl
    {
        public static bool InsertData(Model obj)
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
                    SqlCommand cmd = new SqlCommand("SP_INSERT_STUDENTDATA", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", obj.ROLLNO);
                    cmd.Parameters.AddWithValue("@NAME", obj.NAME);
                    cmd.Parameters.AddWithValue("@EMAILID", obj.EMAILID);
                    cmd.Parameters.AddWithValue("@PASSWORD", obj.PASSWORD);
                    cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
                    cmd.Parameters.AddWithValue("@GRNDER", obj.GENDER);
                    cmd.Parameters.AddWithValue("@BRANCH", obj.BRANCH);
                    cmd.Parameters.AddWithValue("@STATUS", obj.status);
                    cmd.Parameters.AddWithValue("@MOBILE", obj.MOBILE);
                    cmd.Parameters.AddWithValue("@FEE", obj.Fee);
                    int x = cmd.ExecuteNonQuery();
                    if (x > 0)
                    {
                        res = true;
                    }
                    else
                    {
                        res = false;
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
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
