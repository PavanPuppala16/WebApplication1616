using System.Data.SqlClient;
using WebApplication1616.Models;
using System.Data;

namespace WebApplication1616.BusinessLogic_bl
{
    public class CheckBoxCURD
    {
        public static bool Data(TASK1 obj)
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
                    SqlCommand cmd = new SqlCommand("SP_tbl_insertdata", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", obj.Name);

                    cmd.Parameters.AddWithValue("@Emailud", obj.Emailid);
                    cmd.Parameters.AddWithValue("@Password", obj.password);

                    cmd.Parameters.AddWithValue("@Gender", obj.Gender);
                    cmd.Parameters.AddWithValue("@Department", obj.Department);
                    cmd.Parameters.AddWithValue("@Collegename", obj.collegename);
                    cmd.Parameters.AddWithValue("@University", obj.University);
                    cmd.Parameters.AddWithValue("@Location", obj.location);
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
 