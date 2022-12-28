using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using WebApplication1616.Models;

namespace WebApplication1616.BusinessLogic_bl
{
    public class STDLogics
    {

        public static bool Insertdata(STDMODEL obj)
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


                    SqlCommand cmd = new SqlCommand("SP_INSERT_TBL_STD", con);
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
        public static DataTable login(STDMODELlogin obj)
        {
            var dbconfig = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlCommand cmd = new SqlCommand("SP_LOGINSTDDATA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@emailid", obj.emailid);
                cmd.Parameters.AddWithValue("@password", obj.password);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
        public static bool GetDataByROLLNO(String ROLLNO)
        {
            bool res = false;
            STDMODEL OBJ = null;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_GETDATA_TBL_STD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", ROLLNO);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        OBJ = new STDMODEL();
                        OBJ.name = ds.Tables[0].Rows[i]["NAME"].ToString();
                        OBJ.Emailid = ds.Tables[0].Rows[i]["ENAILID"].ToString();
                        OBJ.Password = ds.Tables[0].Rows[i]["PASSWORD"].ToString();
                        OBJ.DOB = Convert.ToDateTime(ds.Tables[0].Rows[i]["DOB"].ToString());
                        OBJ.GENDER = ds.Tables[0].Rows[i]["GENDER"].ToString();
                        OBJ.MOBILE = ds.Tables[0].Rows[i]["MOBILE"].ToString();
                        OBJ.FEE = Convert.ToInt32(ds.Tables[0].Rows[i]["FEE"].ToString());
                        OBJ.Role = ds.Tables[0].Rows[i]["ROLE"].ToString();
                        OBJ.BRANCH = ds.Tables[0].Rows[i]["BRANCH"].ToString();
                        OBJ.Status = Convert.ToBoolean(ds.Tables[0].Rows[i]["STATUS"].ToString());
                        OBJ.rollno = ds.Tables[0].Rows[i]["ROLLNO"].ToString();
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

        public static bool UPDATEDATABYROLLNO(STDMODEL obj)
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
                    SqlCommand cmd = new SqlCommand("SP_UPDATE_TBL_STD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                   
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
                    cmd.Parameters.AddWithValue("@ROLLNO", obj.rollno);

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
        public static bool DELETEDataByROLLNO(String ROLLNO)
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
                    SqlCommand cmd = new SqlCommand("SP_DELETEDATA_TBL_STD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ROLLNO", ROLLNO);
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
        public static bool GetPOPUPMSG(STDMODEL obj)
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
                    SqlCommand cmd = new SqlCommand("SP_INSERT_TBL_STD", con);
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


        public static bool GetDataByEMAILID(String EMAILID)
        {
            bool res = false;
            STDMODEL OBJ = null;
            var dbconfig = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SP_GETDATA_TBL_STD", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EMAILID", EMAILID);
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        OBJ = new STDMODEL();
                       
                        OBJ.Emailid = ds.Tables[0].Rows[i]["ENAILID"].ToString();
                        OBJ.Password = ds.Tables[0].Rows[i]["PASSWORD"].ToString();
                       
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
        public static bool UPDATEDATABYEMAILID(ForgetPasswordModel OBJ)
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
                    SqlCommand cmd = new SqlCommand("sp_ResetPassword",con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ENAILID", OBJ.Emailid);
                    cmd.Parameters.AddWithValue("@PASSWORD", OBJ.Password);
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
