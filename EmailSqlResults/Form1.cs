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
    public partial class Form1 : Form
    {
        static int sqlBoxIndexer;
        static int qryIndex;

        public Form1()
        {
            sqlBoxIndexer = 100;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tmrNow.Tick += new EventHandler(tmrNow_Tick);
            tmrNow.Enabled = true;
            lblCurrentTime.Text = DateTime.Now.ToString("h:mm:ss tt");
        }

        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            this.Height += 100;
            TextBox sqlTxt = createSQLBox();
            TextBox sqlName = createNameBox();
            this.Controls.Add(sqlName);
            this.Controls.Add(sqlTxt);
            qryIndex++;
            sqlBoxIndexer += 100;
        }

        private TextBox createSQLBox()
        {
            TextBox sqlTxt = new TextBox();
            sqlTxt.Name = "sqlbox" + qryIndex;
            Point sqlTxtLocation = new Point(txtBody.Location.X, txtBody.Location.Y + sqlBoxIndexer);
            sqlTxt.Multiline = true;
            sqlTxt.Location = sqlTxtLocation;
            sqlTxt.Height = txtBody.Height;
            sqlTxt.Width = txtBody.Width;
            return sqlTxt;
        }
        private TextBox createNameBox()
        {
            TextBox qryName = new TextBox();
            qryName.Name = "qryName" + qryIndex;
            Point sqlTxtLocation = new Point(txtBody.Location.X - 90, txtBody.Location.Y + sqlBoxIndexer);
            qryName.Text = qryName.Name;
            qryName.Multiline = false;
            qryName.Location = sqlTxtLocation;
            qryName.Height = 15;
            qryName.Width = 90;
            return qryName;
        }

        private void tmrNow_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            if (lblCurrentTime.Text == dtpScheduledTime.Text)
            {
                var x = new ExecuteSQL(this);
            }
        }
    }


}
