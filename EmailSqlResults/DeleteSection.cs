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
    public partial class DeleteSection : Form
    {
        private Form1 form1;
        private string index;

        public DeleteSection(Form1 form1, string index)
        {
            InitializeComponent();
            this.form1 = form1;
            this.index = index;
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            form1.DeleteControls(index);
            form1.FormDataWrite();
            Application.Restart();
            Environment.Exit(0);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
