using System.Data.SqlClient;
using System.Data;
using WebApplication1616.Models;

namespace WebApplication1616.BusinessLogic_bl
{
    public class DISPLAYDATA { 
    public static List<STDMODEL> GetALLData()
        {
            List<STDMODEL> obj = new List<STDMODEL>();
            var dbconfig = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json").Build();
            string dbconnectionstr = dbconfig["ConnectionStrings:DefaultConnection"];
            using (SqlConnection con = new SqlConnection(dbconnectionstr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SP_GETALLDATA", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                foreach (DataRow dr in dt.Rows)
                {
                    obj.Add(
                        new STDMODEL
                        {
                            rollno = dr["ROLLNO"].ToString(),
                            name = dr["NAME"].ToString(),
                            Emailid = dr["ENAILID"].ToString(),
                            Password = dr["PASSWORD"].ToString(),
                            DOB = Convert.ToDateTime(dr["DOB"].ToString()),
                            GENDER = dr["GENDER"].ToString(),
                            MOBILE = dr["MOBILE"].ToString(),
                            FEE = Convert.ToInt32(dr["FEE"].ToString()),
                            Role = dr["ROLE"].ToString(),
                            BRANCH = dr["BRANCH"].ToString(),
                            Status = Convert.ToBoolean(dr["STATUS"].ToString())
                        }
                        );
                }
                return obj;
            }
        }
    }
}
