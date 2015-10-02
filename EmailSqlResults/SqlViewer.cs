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
    public partial class Sqlviewer : Form
    {
        TextBox txtBox;
        public Sqlviewer(TextBox TxtSender)
        {
            InitializeComponent();
            this.Show();
            txtBox = TxtSender;
            txtSqlViewer.Text = TxtSender.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            txtBox.Text = txtSqlViewer.Text;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
     
    }
}
