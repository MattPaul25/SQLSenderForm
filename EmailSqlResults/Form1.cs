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
        #region Attributes
        public string lblOutput { get; private set; }
        public string txtQueryName { get; private set; }
        public string txtSql { get; private set; }
        private List<string[]> FormDataList;
        private string btnDel;
        private string iTag;
        private string iTag_end;
        private string vTag;
        private string vTag_end;
        private string pnlRbs;
        private int sqlBoxIndexer;
        private int qryIndex;
        private string FormDataFile;
        private int sqlBoxIncrementer;
        private string FormType;
        #endregion

        #region Constructor | Attribute Assignments | Enums
        public Form1()
        {
            constructForm();
        }
        private void constructForm()
        {
            assignAttributes();
            InitializeComponent();
            FormDataList = new List<string[]>();
            Connection.ConnectionTested += ConnectionTestEventHandler;
            if (File.Exists(FormDataFile))
            {
                FormDataRead();
            }
            lblStatus.Text = "Dormant";
        }
        enum RbType
        {
            Excel, CSV, Command
        }
        private void assignAttributes()
        {
            
            FormDataFile = "FormData.txt";
            pnlRbs = "panelRbs_";
            btnDel = "btnDel_";
            lblOutput = "lblOutput_";
            txtQueryName = "txtQueryName_";
            txtSql = "txtSql_";
            iTag = "<item>";
            iTag_end = "</item>";
            vTag = "<value>";
            vTag_end = "</value>";
            qryIndex = 0;
            sqlBoxIncrementer = 150;
            sqlBoxIndexer = sqlBoxIncrementer;
            FormType = "System.Windows.Forms.TextBox";
        }
        #endregion

        #region Events
        private void ConnectionTestEventHandler(EventArgs args)
        {
            if (Connection.isWorkingConnection)
            {
                this.Text = "Sql Data Sender: Connection is Working";
                btnExecute.Enabled = true;
                btnExecute.BackColor = Color.LightGreen;
                lblStatus.Text = "Live Connection";
                lblStatus.ForeColor = Color.DarkGreen;
                Update();
            }
            else
            {
                this.Text = "Sql Data Sender: No Connection";
                btnExecute.Enabled = false;
                btnExecute.BackColor = Color.Transparent;
                lblStatus.Text = "No Connection";
                lblStatus.ForeColor = Color.DarkRed;
                Update();
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
            AddQuery();
        }
        private void txtFilePath_Leave(object sender, EventArgs e)
        {
            var filePathArr = txtFilePath.Text.ToArray();
            //making path legitimate by adding on slash
            if (filePathArr[filePathArr.Length - 1] != '\\' && filePathArr[filePathArr.Length - 1] != '/')
            {
                txtFilePath.Text = txtFilePath.Text + "/";
            }
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
        private void btnServerSetUp_Click(object sender, EventArgs e)
        {
            var serverSetUp = new ServerSetUp();
            serverSetUp.Show();
        }
        private void btnExecute_Click(object sender, EventArgs e)
        {
            PrepareToExecute();
        }
        private void txtSql_DoubleClick(object sender, EventArgs e)
        {
            var senderText = ((TextBox)sender); //down casting the object allows me to access its members
            var sqlview = new Sqlviewer(senderText);
        }
        private void rb_Click(object sender, EventArgs e)
        {
            var rb = (RadioButton)sender;
            int rbSpaceIndex = rb.Name.Search("_") + 1;
            string rbQryIndex = rb.Name.Substring(rbSpaceIndex, rb.Name.Length - rbSpaceIndex);

            foreach (Control c in this.Controls)
            {
                var controlType = c.GetType().ToString();
                if (c.Name.Length > lblOutput.Length)
                {
                    if (controlType == "System.Windows.Forms.Label" && c.Name.Substring(0, lblOutput.Length) == lblOutput)
                    {
                        int lblSpaceIndex = c.Name.Search("_") + 1;
                        string lblQryIndex = c.Name.Substring(lblSpaceIndex, c.Name.Length - lblSpaceIndex);
                        if (lblQryIndex == rbQryIndex)
                            c.Text = rb.Text;
                    }
                }
            }
        }
        private void lblOutput_DoubleClick(object sender, EventArgs e)
        {
            MessageBox.Show("Options: \n Excel will output as an excel file \n CSV will output as a pipe delimited csv or text file "
                            + "\n Command will not output any data but will run against the DB", "Output Types");
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormDataWrite();
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            var myButton = (Button)sender;
            string index = myButton.Name.Substring(myButton.Name.Search("_"));
            DeleteControls(index);
            FormDataWriteList(FormType);
            DeleteControls("_");
            var height = txtBody.Location.Y + txtBody.Height + 60;
            this.Height = height;
            assignAttributes();
            FormDataReadList();
        }
        #endregion

        #region Dynamic Control Methods
        private TextBox createSQLBox()
        {
            TextBox txtSqlBox = new TextBox();
            txtSqlBox.Name = txtSql + qryIndex.ToString();
            txtSqlBox.Multiline = true;
            txtSqlBox.Location = new Point(txtBody.Location.X, txtBody.Location.Y + sqlBoxIndexer);
            txtSqlBox.Height = txtBody.Height;
            txtSqlBox.Width = txtBody.Width;
            txtSqlBox.DoubleClick += new EventHandler(txtSql_DoubleClick);
            return txtSqlBox;
        }
        private TextBox createNameBox()
        {
            TextBox qryName = new TextBox();
            qryName.Name = txtQueryName + qryIndex.ToString();
            qryName.Text = qryName.Name;
            qryName.Multiline = false;
            qryName.Height = 15;
            qryName.Width = 90;
            qryName.Location = new Point(txtBody.Location.X, txtBody.Location.Y + sqlBoxIndexer - qryName.Height);
            return qryName;
        }
        private Button createDeleteButton()
        {
            Button btnDelete = new Button();
            btnDelete.Name = btnDel + qryIndex.ToString();
            btnDelete.Text = "Delete";
            btnDelete.Location = new Point(txtBody.Location.X + txtBody.Size.Width - btnDelete.Width, txtBody.Location.Y + sqlBoxIndexer - btnDelete.Height);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            return btnDelete;
        }
        private Label OutputTypes()
        {
            Label lb = new Label();
            lb.Name = lblOutput + qryIndex.ToString();
            lb.Text = "Output Types:";
            lb.Font = new Font("Arial", 10, FontStyle.Bold);
            lb.Location = new Point(txtBody.Location.X - 100, txtBody.Location.Y + sqlBoxIndexer - 15);
            lb.Width = 80;
            lb.DoubleClick += new EventHandler(lblOutput_DoubleClick);
            return lb;
        }
        private FlowLayoutPanel createPanel()
        {
            FlowLayoutPanel panelRbs = new FlowLayoutPanel();
            panelRbs.Name = pnlRbs + qryIndex.ToString();
            panelRbs.Location = new Point(txtBody.Location.X - 100, txtBody.Location.Y + sqlBoxIndexer + 10);
            int boxSize = 100;
            panelRbs.Height = boxSize;
            panelRbs.Width = boxSize;
            panelRbs.BringToFront();
            RadioButton rb1 = createRb(RbType.Excel);
            RadioButton rb2 = createRb(RbType.CSV);
            RadioButton rb3 = createRb(RbType.Command);
            panelRbs.Controls.AddRange(new Control[] { rb1, rb2, rb3 });
            return panelRbs;
        }
        private RadioButton createRb(RbType rbt)
        {
            RadioButton rb = new RadioButton();
            rb.Name = "rb" + rbt.ToString() + "_" + qryIndex;
            rb.Text = rbt.ToString();
            rb.Margin = new Padding(0, 0, 0, 0);
            rb.Click += new EventHandler(rb_Click);
            return rb;
        }
        #endregion

        #region Methods
        private void AddQuery()
        {
            
            lblStatus.ForeColor = Color.Black;
            this.Height += sqlBoxIncrementer;
            //order matters here
            this.Controls.Add(createSQLBox());
            this.Controls.Add(createNameBox());
            this.Controls.Add(createPanel());
            this.Controls.Add(OutputTypes());
            this.Controls.Add(createDeleteButton());
            qryIndex++;
            sqlBoxIndexer += sqlBoxIncrementer;
        }
        private void PrepareToExecute()
        {
            //running checks
            if (Connection.ConnectionString != null) //check if server is set up
            {
                if (qryIndex > 0) //check if a query has been set up
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
                else if (qryIndex == 0)
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
            FormDataWrite();
            lblStatus.Text = "Executing....."; lblStatus.ForeColor = Color.DarkBlue; Update();
            ErrorHandler.AllIssues = "";
            var findSql = new FindSQL(this);
            var qryNames = findSql.QryNames;
            var sqlStrings = findSql.SqlStatements;
            var outputTypes = findSql.OutputTypes;
            //looping through all found queries
            for (int i = 0; i < qryNames.Count; i++)
            {
                string qryName = qryNames[i];
                string sqlString = sqlStrings[i];
                string outputType = outputTypes[i];
                var sqlData = new RunQuery(sqlString, qryName).sqlData;
                if (sqlData.Rows.Count > 0)
                {
                    var push = new PushData(sqlData, txtFilePath.Text + qryName);
                    switch (outputType)
                    {
                        case "Excel":
                            push.WriteToExcel();
                            break;
                        case "CSV":
                            push.WriteToCsv("|");
                            break;
                        case "Command":
                            break;
                        default:
                            push.WriteToExcel();
                            break;
                    }
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
                    lblStatus.ForeColor = Color.Red;
                    lblStatus.Text = "Sending Errors!";
                    Update();
                    var errMail = new EmailObject()  //create error email object;
                    {
                        To = txtYourEmail.Text,
                        Subject = "SQL Sender Errors",
                        Body = ErrorHandler.AllIssues,
                        CC = txtCC.Text
                    };
                    var mail = new GenerateEmail(errMail);
                }
            }
            lblStatus.Text = "Ready";
            lblStatus.ForeColor = Color.Black;
            Update();
        }
        public void DeleteControls(string marker)
        {
            var cntrls = this.Controls;
            var cntrlCount = cntrls.Count;
            for (int i = 0; i < cntrlCount; i++)
            {
                var cntrl = cntrls[i];
                string name = cntrl.Name;
                int start = name.Search(marker);
                if (start > -1)
                {
                    string cntrlIndex = name.Substring(start, marker.Length);
                    if (cntrlIndex == marker)
                    {
                        this.Controls.Remove(cntrl);
                        i--;
                        cntrlCount--;
                    }
                }
            }
        }
        public void FormDataWriteList(string ControlType)
        {
            Predicate<string[]> myPred = (string[] myString) => { return myString[0] != "";};
            FormDataList.RemoveAll(myPred);
            foreach (Control c in this.Controls)
            {
                var controlType = c.GetType().ToString();
                if (controlType == ControlType)
                {
                    FormDataList.Add(new string[] { c.Name, c.Text });
                }
            }
        }   
        private void FormDataReadList()
        {
            for (int i = 0; i < FormDataList.Count; i++)
            {
                var FormData = FormDataList[i];
                ApplyValues(FormData[0], FormData[1]);
            }
        }
        public void FormDataWrite()
        {
            FormDataWriteList(FormType);
            using (StreamWriter sw = new StreamWriter(FormDataFile, false))
            {
                foreach (var item in FormDataList)
                {
                    sw.WriteLine(iTag + item[0] + iTag_end + vTag + item[1] + vTag_end);
                }
            }
        }
        private void FormDataRead()
        {
            //reads stire data and pushes it to form
            using (StreamReader sr = new StreamReader(FormDataFile))
            {
                string doc = sr.ReadToEnd();
                while (doc.Length > 0)
                {
                    if (doc.Search(iTag) > -1)
                    {
                        //getting values in the item tag
                        int key_startIndex = doc.Search(iTag) + iTag.Length;
                        int key_endIndex = doc.Search(iTag_end) - key_startIndex;
                        string key = doc.Substring(key_startIndex, key_endIndex);

                        //getting values in the value tags
                        int value_startIndex = doc.Search(vTag) + vTag.Length;
                        int value_endIndex = doc.Search(vTag_end) - value_startIndex;
                        string value = doc.Substring(value_startIndex, value_endIndex);
                        ApplyValues(key, value);
                        doc = doc.Substring(doc.Search(vTag_end) + vTag_end.Length);
                    }
                    else
                    {
                        break;
                    }
                }
            }
        }
        private void ApplyValues(string key, string val)
        {         
            if (key.Length > txtSql.Length)
            {
                string newKeyVal = key.Substring(0, txtSql.Length);
                if (newKeyVal == txtSql)
                {
                    key = newKeyVal + qryIndex.ToString();
                    AddQuery();
                }
            }
            foreach (Control c in this.Controls)
            {
                if (c.Name == key)
                {
                    c.Text = val;
                    break;
                }
            }
        }
        #endregion

       
    }
   
}
   


