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
            lblStatus.Text = "Dormant";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtpScheduledTime.Text = DateTime.Now.AddHours(1).ToString("h:mm:ss tt");
            lblCurrentTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            tmrNow.Tick += new EventHandler(tmrNow_Tick);
            tmrNow.Enabled = true;
        }

        protected override void OnResize(EventArgs e)
        {
            try
            {
                base.OnResize(e);
                //Determines whether the cursor is in the taskbar
                bool cursorNotInBar = Screen.GetWorkingArea(this).Contains(Cursor.Position);
                if (this.WindowState == FormWindowState.Minimized && cursorNotInBar)
                {
                    this.ShowInTaskbar = false;
                    notifyIcon.Visible = true;
                    this.Hide();
                }
                else if (FormWindowState.Normal == this.WindowState)
                {
                    notifyIcon.Visible = false;
                    this.ShowInTaskbar = true;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        } 

        private void btnAddQuery_Click(object sender, EventArgs e)
        {
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Black;
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

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            var chckboxes = gbWeekDays.Controls.OfType<CheckBox>();

            if (cmbMonth.Text != "")
            {
                foreach (var ckbox in chckboxes)
                {
                    ckbox.Checked = false;
                    ckbox.Enabled = false;
                }
            }
            else if (cmbMonth.Text == "")
            {
                foreach (var ckbox in chckboxes)
                {
                    ckbox.Checked = false;
                    ckbox.Enabled = true;
                }
            }
        }

        private void tmrNow_Tick(object sender, EventArgs e)
        {
            lblCurrentTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            if (lblCurrentTime.Text == dtpScheduledTime.Text)
            {

                if (DateTime.Now.Day.ToString() == cmbMonth.Text)
                {
                    Execute();
                }
                else
                {
                    var chckboxes = gbWeekDays.Controls.OfType<CheckBox>();
                    foreach (var item in chckboxes)
                    {
                        string myDay = DateTime.Today.DayOfWeek.ToString();
                        if (item.Checked && item.Name == "ckb" + myDay)
                        {
                            Execute();
                            break;
                        }
                    }
                }
            }
        }     

        private void Execute()
        {
            //runs the process to execute queries and send results
            lblStatus.Text = "Executing.....";
            lblStatus.ForeColor =Color.DarkBlue;
            ErrorHandler.AllIssues = "";
            var findSql = new FindSQL(this);
            var qryNames = findSql.QryNames;
            var sqlStrings = findSql.SqlStatements;
            for (int i = 0; i < qryNames.Count; i++)
            {
                string qryName = qryNames[i];
                string sqlString = sqlStrings[i];
                lblStatus.Text = "Running Query..";
                lblStatus.ForeColor = Color.IndianRed;
                var sqlData = new RunQuery(sqlString, qryName).sqlData;
                if (sqlData.Rows.Count > 0)
                {
                    lblStatus.Text = "Sending Data";
                    var excelPush = new ExcelPush(sqlData, txtFilePath.Text + qryName);
                }

            }
            var EmlObj = new EmailObject() { To = txtTo.Text, Body = txtBody.Text, CC = txtCC.Text, Subject = txtSubject.Text };
            var GenerateEmail = new GenerateEmail(EmlObj, qryNames, txtFilePath.Text);
            if (ErrorHandler.AllIssues != "")
            {
                lblStatus.ForeColor = Color.Red;
                lblStatus.Text = "Sending Errors!";
                var errMail = new EmailObject()
                {
                    To = txtYourEmail.Text,
                    Subject = "SQL Sender Errors",
                    Body = ErrorHandler.AllIssues,
                    CC = txtCC.Text
                };
                var mail = new GenerateEmail(errMail);
            }
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Black;
        }

        


    }

    class EmailObject
    {
        public string To { get; set; }
        public string CC { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
    


}
