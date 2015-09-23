using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmailSqlResults
{
    public static class Connection
    {
        //accepts a connection string then tests it
        public static string ErrMessage { get; private set; }
        public static bool isWorkingConnection { get; private set; }
        public static string ConnectionString { get; private set; }
        public static string ConnectionTestString { get; private set; }

        //this class is also a publisher static calss that publishes when the connection status has changed
        public delegate void ConnectionTestEventHandler(EventArgs args); //holds a reference to a function that looks like the delegate signature
        public static event ConnectionTestEventHandler ConnectionTested;
      

        public static void SetValues(string serverName, string userName, string passWord)
        {
           //set values creates two connection strings, one to test and one to execute
            string connection = "Server={0}; Database=Master; User Id={1}; Password={2}; Connection Timeout={3}";
            ConnectionString = String.Format(connection, serverName, userName, passWord, "2000");
            ConnectionTestString = String.Format(connection, serverName, userName, passWord, "5");
            testConnectionString();
        }

        private static void testConnectionString()
        {
            using (SqlConnection conn = new SqlConnection(Connection.ConnectionTestString)) //checks whether the connection string is valid
            {
                try
                {
                    conn.Open();
                    isWorkingConnection = true;
                    OnConnectionTested();
                }
                catch (Exception ex)
                {
                    ErrMessage = ex.Message;
                    isWorkingConnection = false;
                    OnConnectionTested(); //triggers event that pushes to subscribers
                }
                finally
                {
                    conn.Close();
                    conn.Dispose();
                }
            }
        }

        private static void OnConnectionTested()
        {
            if (ConnectionTested != null)
            {
                ConnectionTested(EventArgs.Empty);
            }
        }
       


    }
}
