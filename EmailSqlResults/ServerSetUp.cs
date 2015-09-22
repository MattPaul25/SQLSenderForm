using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSqlResults
{
    public partial class ServerSetUp : Form
    {
        public ServerSetUp()
        {
            InitializeComponent();           
        }

        private void btnSetServer_Click(object sender, EventArgs e)
        {
            if (txtServer.Text != "" && txtPassWord.Text != "" && txtUserName.Text != "")
            {
                Connection.SetValues(txtServer.Text, txtPassWord.Text, txtUserName.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please fill out all required fields");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public static class Connection
    {
        public static void SetValues(string serverName, string userName, string passWord)
        {
            string connection = "Server={0}; Database=Master; User Id={1}; Password={2}; Connection Timeout=2000";
            ConnectionString = String.Format(connection, serverName, userName, passWord);
        }
        public static string ConnectionString { get; private set; }
    }
}
