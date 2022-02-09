using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LABDB2
{
    class DB
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source = WIN-8NSR3MHIUSK\SQLEXPRESS; Initial Catalog=LAB; Integrated Security = True");
        public void OpenConnection() {
            if (sqlConnection.State == System.Data.ConnectionState.Closed) {
                sqlConnection.Open();
            }

        }
        public void ClosedConnection() {
            if (sqlConnection.State == System.Data.ConnectionState.Open) {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection() {
            return sqlConnection;
        }
    }
}
