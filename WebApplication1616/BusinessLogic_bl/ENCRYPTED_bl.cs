using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication1616.Models;
using WebApplication1616.encrypteddata;
using WebApplication1616.Controllers;
using Microsoft.AspNetCore.Mvc;


namespace WebApplication1616.BusinessLogic_bl
{
    public class ENCRYPTED_bl
    {
        public static bool Insertdata(EncryptionModel obj)
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
                    SqlCommand cmd = new SqlCommand("SP_TB_ENCRYPTIONS", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmailID", EncryptionLibraryController.EncryptText(obj.EMAILID));
                    cmd.Parameters.AddWithValue("@Password", EncryptionLibraryController.EncryptText(obj.PASSWORD));
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
        public static bool EncryptionDsplay(EncryptionModel obj)
        {
            bool res = false;
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
                    cmd.Parameters.AddWithValue("@REFID", obj.REFID);
                    cmd.Parameters.AddWithValue("@EMAILID", obj.EMAILID);
                    cmd.Parameters.AddWithValue("@PASSWOORD", obj.PASSWORD);
                    cmd.ExecuteScalar();
                    con.Close();
                }
            }

            return res = true;
        }
        public static bool DispalyEncryption(String EMAILID)
        {
            bool res = false;
            EncryptionModel OBJ = null;
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
                        OBJ = new EncryptionModel();
                        OBJ.EMAILID = ds.Tables[0].Rows[i]["EMAILID"].ToString();
                        OBJ.PASSWORD = ds.Tables[0].Rows[i]["PASSWORD"].ToString();

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

    }
}