using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace EmailSqlResults
{
    class RunQuery
    {
        public DataTable sqlData { get; set; }
        private string sql;
        private string qryName;

        public RunQuery(string Sql, string QryName)
        {
           sql = Sql;
           qryName = QryName;
           connect();
        }

        private void connect()
        {
            sqlData = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(Connection.ConnectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandTimeout = 2000;
                    sqlData.Load(cmd.ExecuteReader());
                }
            }
            catch (Exception x)
            {
                ErrorHandler.Handle(x);
            }

        }

    }

  
}
