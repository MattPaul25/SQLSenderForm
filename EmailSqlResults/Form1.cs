using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            Connection.ConnectionTested += ConnectionTestEventHandler;
        }

        private void ConnectionTestEventHandler (EventArgs args)
        {
            if (Connection.isWorkingConnection)
            {
                this.Text = "Sql Data Sender: Connection is Working";
                btnExecute.Enabled = true;
                btnExecute.BackColor = Color.LightGreen; Update();
                lblStatus.Text = "Live Connection"; Update();
                lblStatus.ForeColor = Color.DarkGreen; Update();
            }
            else
            {
                this.Text = "Sql Data Sender: No Connection";
                btnExecute.Enabled = false;
                btnExecute.BackColor = Color.Transparent; Update();
                lblStatus.Text = "No Connection"; Update();
                lblStatus.ForeColor = Color.DarkRed; Update();
            }
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
            //if month is selected it blocks out weekdays
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
            //on timer ticl this code executes -right now its set to one a minute
            lblCurrentTime.Text = DateTime.Now.ToString("h:mm:ss tt");
            if (lblCurrentTime.Text == dtpScheduledTime.Text)
            {
                if (DateTime.Now.Day.ToString() == cmbMonth.Text)
                {
                    PrepareToExecute();
                }
                else
                {
                    var chckboxes = gbWeekDays.Controls.OfType<CheckBox>();
                    foreach (var item in chckboxes)
                    {
                        string myDay = DateTime.Today.DayOfWeek.ToString();
                        if (item.Checked && item.Name == "ckb" + myDay)
                        {
                            PrepareToExecute();
                            break;
                        }
                    }
                }
            }
        }

        private void ckbEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbEmail.Checked)
            {
                txtBody.Enabled = true;
                txtCC.Enabled = true;
                txtSubject.Enabled = true;
                txtTo.Enabled = true;
                txtYourEmail.Enabled = true;
            }
            else if (!ckbEmail.Checked)
            {
                txtBody.Enabled = false;
                txtCC.Enabled = false;
                txtSubject.Enabled = false;
                txtTo.Enabled = false;
                txtYourEmail.Enabled = false;
            }
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            LogForm log = new LogForm();
            log.Show();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            PrepareToExecute();           
        } 

        private void PrepareToExecute()
        {
            //running checks
            if (Connection.ConnectionString != null) //check if server is set up
            {
                if (lblStatus.Text == "Ready") //check if a query has been set up
                {
                    if (Directory.Exists(txtFilePath.Text)) //check if directory exists
                    {
                        if (ckbEmail.Checked) //is this query meant to be emailed
                        {
                            if (txtSubject.Text != "" && txtTo.Text != "") //are mail sections filled out completely
                            {
                                Execute(true);
                            }
                            else if (txtSubject.Text == "" || txtTo.Text == "")
                            {
                                var ex = new Exception("Email requires subject and To: to be completed");
                                ErrorHandler.Handle(ex);
                                MessageBox.Show(ex.Message);
                            }
                        }
                        else if (!ckbEmail.Checked)
                        {
                            Execute(false);
                        }
                    }
                    else if (!Directory.Exists(txtFilePath.Text))
                    {
                        var ex = new Exception("Unacceptable Folder");
                        ErrorHandler.Handle(ex);
                        MessageBox.Show(ex.Message);
                    }
                }
                else if (lblStatus.Text != "Ready")
                {
                    var ex = new Exception("No Query Created");
                    ErrorHandler.Handle(ex);
                    MessageBox.Show(ex.Message);
                }
            }
            else if (Connection.ConnectionString == null)
            {
                var ex = new Exception("Server is not set up");
                ErrorHandler.Handle(ex);
                MessageBox.Show(ex.Message);
            }
        }
       
        private void Execute(bool ToBeEmailed)
        {
            //runs the process to execute queries and send results
            lblStatus.Text = "Executing....."; Update();
            lblStatus.ForeColor = Color.DarkBlue; Update();
            ErrorHandler.AllIssues = "";
            var findSql = new FindSQL(this);
            var qryNames = findSql.QryNames;
            var sqlStrings = findSql.SqlStatements;
            for (int i = 0; i < qryNames.Count; i++)
            {
                string qryName = qryNames[i];
                string sqlString = sqlStrings[i];
                lblStatus.Text = "Running Query.."; Update();
                lblStatus.ForeColor = Color.IndianRed; Update();
                var sqlData = new RunQuery(sqlString, qryName).sqlData;
                if (sqlData.Rows.Count > 0)
                {
                    lblStatus.Text = "Sending Data";
                    var excelPush = new ExcelPush(sqlData, txtFilePath.Text + qryName);
                }
                else if (sqlData.Rows.Count <= 0)
                {
                    var ex = new Exception("The query resulted in no data");
                    ErrorHandler.Handle(ex);
                }
            }
            if (ToBeEmailed) //if the email is needs to be emailed run the rest of the code
            {
                var EmlObj = new EmailObject() { To = txtTo.Text, Body = txtBody.Text, CC = txtCC.Text, Subject = txtSubject.Text };
                var GenerateEmail = new GenerateEmail(EmlObj, qryNames, txtFilePath.Text);
                if (ErrorHandler.AllIssues != "")
                {
                    lblStatus.ForeColor = Color.Red; Update();
                    lblStatus.Text = "Sending Errors!"; Update();
                    var errMail = new EmailObject()  //Create Email Object;
                    {
                        To = txtYourEmail.Text,
                        Subject = "SQL Sender Errors",
                        Body = ErrorHandler.AllIssues,
                        CC = txtCC.Text
                    };
                    var mail = new GenerateEmail(errMail);
                }
            }
            lblStatus.Text = "Ready"; Update();
            lblStatus.ForeColor = Color.Black; Update();
        }

        private void btnServerSetUp_Click(object sender, EventArgs e)
        {
            var serverSetUp = new ServerSetUp();
            serverSetUp.Show();
           
        }

        
      
    }

}
