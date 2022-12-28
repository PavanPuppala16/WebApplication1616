using System.Data.SqlClient;
using System.Data;
using WebApplication1616.Models;
using System.Configuration;


namespace WebApplication1616.BusinessLogic_bl
    {
        public class Checking_bl
        {
            public static bool Insertdata(Check obj)
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
                    
                            string msg = "";

                            if (obj.Qualification == true)
                            {
                                msg = msg + "BTECH" + "";
                            }

                            if (obj.Qualification == true)
                            {
                                msg = msg + "MTECH" + "";
                            }
                            if (obj.Qualification == true)
                            {
                                msg = msg + "DEGREE" + "";
                            }


                            con.Open();


                        SqlCommand cmd = new SqlCommand("SP_INSERT_TBL_NEW", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ROLLNO", obj.rollno);
                        cmd.Parameters.AddWithValue("@NAME", obj.name);
                        cmd.Parameters.AddWithValue("@ENAILID", obj.Emailid);
                        cmd.Parameters.AddWithValue("@PASSWORD", obj.Password);
                        cmd.Parameters.AddWithValue("@DOB", Convert.ToDateTime(obj.DOB));
                        cmd.Parameters.AddWithValue("@GENDER", obj.GENDER);
                        cmd.Parameters.AddWithValue("@MOBILE", obj.MOBILE);
                        cmd.Parameters.AddWithValue("@FEE", obj.FEE);
                        cmd.Parameters.AddWithValue("@ROLE", obj.Role);

                        cmd.Parameters.AddWithValue("@BRANCH", obj.BRANCH);
                        cmd.Parameters.AddWithValue("@STATUS", obj.Status);
                        cmd.Parameters.AddWithValue("@Qualification", msg);


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
