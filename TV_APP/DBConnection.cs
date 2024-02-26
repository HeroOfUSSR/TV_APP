using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TV_APP
{
    public class DBConnection
    {
        SqlConnection strConnection = new SqlConnection(@"Data Source=DESKTOP-DDO84UQ; Initial Catalog=TV_db; Integrated Security=True");

        public void OpenConnection()
        {
            if (strConnection.State == System.Data.ConnectionState.Closed) 
            { 
                strConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (strConnection.State == System.Data.ConnectionState.Open)
            {
                strConnection.Close();
            }
        }

        public SqlConnection GetConnection()
        {
            return strConnection;
        }
    }
}
