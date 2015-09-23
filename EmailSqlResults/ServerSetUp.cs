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
            lblConnectionCheck.Text = "Checking Server Connection"; Update();
            if (txtServer.Text != "" && txtPassWord.Text != "" && txtUserName.Text != "")
            {
                Connection.SetValues(txtServer.Text, txtUserName.Text, txtPassWord.Text);
                if (Connection.isWorkingConnection)
                {
                    MessageBox.Show("Connection is Successfull!");
                    this.Close();
                }
                else if (!Connection.isWorkingConnection)
                {
                    MessageBox.Show("Incorrect Parameters: " + Connection.ErrMessage);
                }
            }
            else
            {
                MessageBox.Show("Please fill out all required fields");
            }
            lblConnectionCheck.Text = ""; Update();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

   
}
