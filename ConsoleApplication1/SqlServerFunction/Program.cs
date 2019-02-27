using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlServerFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection Conn = new SqlConnection("server=120.77.154.192;database=NewShoppingMall;user=sa;pwd=mnbvc@123");
            SqlCommand cmd = new SqlCommand("TestFunction", Conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            Conn.Open();
            var dr = cmd;
            cmd.Parameters.Add("@returnString", SqlDbType.Int);
            cmd.Parameters["@returnString"].Direction = ParameterDirection.ReturnValue; //返回参数
            SqlDataAdapter sql = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sql.Fill(dt);
            var aa = dt;
            var aaa = cmd.Parameters["@returnString"].Value.ToString();
            Conn.Close();
        }
    }
}
