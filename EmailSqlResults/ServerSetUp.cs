using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmailSqlResults
{
    public partial class ServerSetUp : Form
    {
        private string credentialFile;
        public ServerSetUp()
        {
            InitializeComponent();
            //load credentials (except password)
            credentialFile = "xCredentials.txt";
            if (File.Exists(credentialFile))
            {
                //if the credentialfile exists read from it to place information in it
                using (StreamReader sr = new StreamReader(credentialFile))
                {
                    txtServer.Text = sr.ReadLine();
                    txtUserName.Text = sr.ReadLine();
                    sr.Close();
                }
            }
        
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
                    //log credentials (except password)
                    using (StreamWriter sw = new StreamWriter(credentialFile, false)) 
                    {
                        sw.WriteLine(txtServer.Text + "\n" + txtUserName.Text);
                        sw.Close();
                    }
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
