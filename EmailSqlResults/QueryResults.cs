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
    class GenerateQueryResults
    {
        public DataTable sqlData { get; set; }
        private string sql;
        private string qryName;

        public GenerateQueryResults(string Sql, string QryName, string directory)
        {
           sql = Sql;
           qryName = QryName;
           connect();
           var expush = new ExcelPush(sqlData, directory + qryName + ".xlsx");
        }

        private void connect()
        {
            sqlData = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.CommandTimeout = 2000;
                    sqlData.Load(cmd.ExecuteReader());
                }
            }
            catch (Exception x)
            {
                 MessageBox.Show(x.Message);
            }

        }

    }

  
}
