namespace EmailSqlResults
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dtpScheduledTime = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.lblEmailSubject = new System.Windows.Forms.Label();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtBody = new System.Windows.Forms.TextBox();
            this.lblEmailBody = new System.Windows.Forms.Label();
            this.btnAddQuery = new System.Windows.Forms.Button();
            this.lblCC = new System.Windows.Forms.Label();
            this.txtCC = new System.Windows.Forms.TextBox();
            this.tmrNow = new System.Windows.Forms.Timer(this.components);
            this.lblCurrentTime = new System.Windows.Forms.Label();
            this.lblFolderPath = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.txtYourEmail = new System.Windows.Forms.TextBox();
            this.lblYourEmail = new System.Windows.Forms.Label();
            this.gbWeekDays = new System.Windows.Forms.GroupBox();
            this.ckbSunday = new System.Windows.Forms.CheckBox();
            this.ckbSaturday = new System.Windows.Forms.CheckBox();
            this.ckbFriday = new System.Windows.Forms.CheckBox();
            this.ckbThursday = new System.Windows.Forms.CheckBox();
            this.ckbWednesday = new System.Windows.Forms.CheckBox();
            this.ckbTuesday = new System.Windows.Forms.CheckBox();
            this.ckbMonday = new System.Windows.Forms.CheckBox();
            this.cmbMonth = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnServerSetUp = new System.Windows.Forms.Button();
            this.btnViewLog = new System.Windows.Forms.Button();
            this.ckbEmail = new System.Windows.Forms.CheckBox();
            this.btnExecute = new System.Windows.Forms.Button();
            this.gbWeekDays.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpScheduledTime
            // 
            this.dtpScheduledTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpScheduledTime.Location = new System.Drawing.Point(117, 19);
            this.dtpScheduledTime.Name = "dtpScheduledTime";
            this.dtpScheduledTime.ShowUpDown = true;
            this.dtpScheduledTime.Size = new System.Drawing.Size(90, 20);
            this.dtpScheduledTime.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Time To Execute";
            // 
            // lblEmailSubject
            // 
            this.lblEmailSubject.AutoSize = true;
            this.lblEmailSubject.Location = new System.Drawing.Point(40, 191);
            this.lblEmailSubject.Name = "lblEmailSubject";
            this.lblEmailSubject.Size = new System.Drawing.Size(71, 13);
            this.lblEmailSubject.TabIndex = 3;
            this.lblEmailSubject.Text = "Email Subject";
            // 
            // txtSubject
            // 
            this.txtSubject.Enabled = false;
            this.txtSubject.Location = new System.Drawing.Point(117, 187);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(472, 20);
            this.txtSubject.TabIndex = 4;
            // 
            // txtTo
            // 
            this.txtTo.Enabled = false;
            this.txtTo.Location = new System.Drawing.Point(117, 135);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(472, 20);
            this.txtTo.TabIndex = 6;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(91, 139);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 5;
            this.lblTo.Text = "To";
            // 
            // txtBody
            // 
            this.txtBody.Enabled = false;
            this.txtBody.Location = new System.Drawing.Point(117, 218);
            this.txtBody.Multiline = true;
            this.txtBody.Name = "txtBody";
            this.txtBody.Size = new System.Drawing.Size(571, 119);
            this.txtBody.TabIndex = 8;
            // 
            // lblEmailBody
            // 
            this.lblEmailBody.AutoSize = true;
            this.lblEmailBody.Location = new System.Drawing.Point(52, 218);
            this.lblEmailBody.Name = "lblEmailBody";
            this.lblEmailBody.Size = new System.Drawing.Size(59, 13);
            this.lblEmailBody.TabIndex = 7;
            this.lblEmailBody.Text = "Email Body";
            // 
            // btnAddQuery
            // 
            this.btnAddQuery.Location = new System.Drawing.Point(607, 184);
            this.btnAddQuery.Name = "btnAddQuery";
            this.btnAddQuery.Size = new System.Drawing.Size(81, 23);
            this.btnAddQuery.TabIndex = 9;
            this.btnAddQuery.Text = "Add Query";
            this.btnAddQuery.UseVisualStyleBackColor = true;
            this.btnAddQuery.Click += new System.EventHandler(this.btnAddQuery_Click);
            // 
            // lblCC
            // 
            this.lblCC.AutoSize = true;
            this.lblCC.Location = new System.Drawing.Point(90, 166);
            this.lblCC.Name = "lblCC";
            this.lblCC.Size = new System.Drawing.Size(21, 13);
            this.lblCC.TabIndex = 10;
            this.lblCC.Text = "CC";
            // 
            // txtCC
            // 
            this.txtCC.Enabled = false;
            this.txtCC.Location = new System.Drawing.Point(117, 161);
            this.txtCC.Name = "txtCC";
            this.txtCC.Size = new System.Drawing.Size(472, 20);
            this.txtCC.TabIndex = 11;
            // 
            // tmrNow
            // 
            this.tmrNow.Tick += new System.EventHandler(this.tmrNow_Tick);
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.AutoSize = true;
            this.lblCurrentTime.Location = new System.Drawing.Point(662, 22);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(26, 13);
            this.lblCurrentTime.TabIndex = 12;
            this.lblCurrentTime.Text = "time";
            // 
            // lblFolderPath
            // 
            this.lblFolderPath.AutoSize = true;
            this.lblFolderPath.Location = new System.Drawing.Point(50, 87);
            this.lblFolderPath.Name = "lblFolderPath";
            this.lblFolderPath.Size = new System.Drawing.Size(61, 13);
            this.lblFolderPath.TabIndex = 13;
            this.lblFolderPath.Text = "Folder Path";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(117, 83);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(472, 20);
            this.txtFilePath.TabIndex = 14;
            this.txtFilePath.Leave += new System.EventHandler(this.txtFilePath_Leave);
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "notifyIcon1";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // txtYourEmail
            // 
            this.txtYourEmail.Enabled = false;
            this.txtYourEmail.Location = new System.Drawing.Point(117, 109);
            this.txtYourEmail.Name = "txtYourEmail";
            this.txtYourEmail.Size = new System.Drawing.Size(472, 20);
            this.txtYourEmail.TabIndex = 15;
            // 
            // lblYourEmail
            // 
            this.lblYourEmail.AutoSize = true;
            this.lblYourEmail.Location = new System.Drawing.Point(54, 112);
            this.lblYourEmail.Name = "lblYourEmail";
            this.lblYourEmail.Size = new System.Drawing.Size(57, 13);
            this.lblYourEmail.TabIndex = 16;
            this.lblYourEmail.Text = "Your Email";
            // 
            // gbWeekDays
            // 
            this.gbWeekDays.Controls.Add(this.ckbSunday);
            this.gbWeekDays.Controls.Add(this.ckbSaturday);
            this.gbWeekDays.Controls.Add(this.ckbFriday);
            this.gbWeekDays.Controls.Add(this.ckbThursday);
            this.gbWeekDays.Controls.Add(this.ckbWednesday);
            this.gbWeekDays.Controls.Add(this.ckbTuesday);
            this.gbWeekDays.Controls.Add(this.ckbMonday);
            this.gbWeekDays.Location = new System.Drawing.Point(224, 2);
            this.gbWeekDays.Name = "gbWeekDays";
            this.gbWeekDays.Size = new System.Drawing.Size(365, 40);
            this.gbWeekDays.TabIndex = 17;
            this.gbWeekDays.TabStop = false;
            this.gbWeekDays.Text = "Week Day";
            // 
            // ckbSunday
            // 
            this.ckbSunday.AutoSize = true;
            this.ckbSunday.Location = new System.Drawing.Point(312, 16);
            this.ckbSunday.Name = "ckbSunday";
            this.ckbSunday.Size = new System.Drawing.Size(39, 17);
            this.ckbSunday.TabIndex = 6;
            this.ckbSunday.Text = "Su";
            this.ckbSunday.UseVisualStyleBackColor = true;
            // 
            // ckbSaturday
            // 
            this.ckbSaturday.AutoSize = true;
            this.ckbSaturday.Location = new System.Drawing.Point(263, 16);
            this.ckbSaturday.Name = "ckbSaturday";
            this.ckbSaturday.Size = new System.Drawing.Size(39, 17);
            this.ckbSaturday.TabIndex = 5;
            this.ckbSaturday.Text = "Sa";
            this.ckbSaturday.UseVisualStyleBackColor = true;
            // 
            // ckbFriday
            // 
            this.ckbFriday.AutoSize = true;
            this.ckbFriday.Location = new System.Drawing.Point(218, 16);
            this.ckbFriday.Name = "ckbFriday";
            this.ckbFriday.Size = new System.Drawing.Size(35, 17);
            this.ckbFriday.TabIndex = 4;
            this.ckbFriday.Text = "Fr";
            this.ckbFriday.UseVisualStyleBackColor = true;
            // 
            // ckbThursday
            // 
            this.ckbThursday.AutoSize = true;
            this.ckbThursday.Location = new System.Drawing.Point(169, 16);
            this.ckbThursday.Name = "ckbThursday";
            this.ckbThursday.Size = new System.Drawing.Size(39, 17);
            this.ckbThursday.TabIndex = 3;
            this.ckbThursday.Text = "Th";
            this.ckbThursday.UseVisualStyleBackColor = true;
            // 
            // ckbWednesday
            // 
            this.ckbWednesday.AutoSize = true;
            this.ckbWednesday.Location = new System.Drawing.Point(116, 16);
            this.ckbWednesday.Name = "ckbWednesday";
            this.ckbWednesday.Size = new System.Drawing.Size(43, 17);
            this.ckbWednesday.TabIndex = 2;
            this.ckbWednesday.Text = "We";
            this.ckbWednesday.UseVisualStyleBackColor = true;
            // 
            // ckbTuesday
            // 
            this.ckbTuesday.AutoSize = true;
            this.ckbTuesday.Location = new System.Drawing.Point(67, 16);
            this.ckbTuesday.Name = "ckbTuesday";
            this.ckbTuesday.Size = new System.Drawing.Size(39, 17);
            this.ckbTuesday.TabIndex = 1;
            this.ckbTuesday.Text = "Tu";
            this.ckbTuesday.UseVisualStyleBackColor = true;
            // 
            // ckbMonday
            // 
            this.ckbMonday.AutoSize = true;
            this.ckbMonday.Location = new System.Drawing.Point(16, 16);
            this.ckbMonday.Name = "ckbMonday";
            this.ckbMonday.Size = new System.Drawing.Size(41, 17);
            this.ckbMonday.TabIndex = 0;
            this.ckbMonday.Text = "Mo";
            this.ckbMonday.UseVisualStyleBackColor = true;
            // 
            // cmbMonth
            // 
            this.cmbMonth.FormattingEnabled = true;
            this.cmbMonth.Items.AddRange(new object[] {
            "",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "22",
            "23",
            "24",
            "25",
            "26",
            "27",
            "28",
            "29",
            "30",
            "31"});
            this.cmbMonth.Location = new System.Drawing.Point(595, 16);
            this.cmbMonth.Name = "cmbMonth";
            this.cmbMonth.Size = new System.Drawing.Size(37, 21);
            this.cmbMonth.TabIndex = 18;
            this.cmbMonth.SelectedIndexChanged += new System.EventHandler(this.cmbMonth_SelectedIndexChanged);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(595, 104);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 25);
            this.lblStatus.TabIndex = 19;
            // 
            // btnServerSetUp
            // 
            this.btnServerSetUp.Location = new System.Drawing.Point(279, 50);
            this.btnServerSetUp.Name = "btnServerSetUp";
            this.btnServerSetUp.Size = new System.Drawing.Size(147, 24);
            this.btnServerSetUp.TabIndex = 20;
            this.btnServerSetUp.Text = "Server Set Up";
            this.btnServerSetUp.UseVisualStyleBackColor = true;
            this.btnServerSetUp.Click += new System.EventHandler(this.btnServerSetUp_Click);
            // 
            // btnViewLog
            // 
            this.btnViewLog.Location = new System.Drawing.Point(441, 50);
            this.btnViewLog.Name = "btnViewLog";
            this.btnViewLog.Size = new System.Drawing.Size(147, 24);
            this.btnViewLog.TabIndex = 21;
            this.btnViewLog.Text = "View Log";
            this.btnViewLog.UseVisualStyleBackColor = true;
            this.btnViewLog.Click += new System.EventHandler(this.btnViewLog_Click);
            // 
            // ckbEmail
            // 
            this.ckbEmail.AutoSize = true;
            this.ckbEmail.BackColor = System.Drawing.Color.Transparent;
            this.ckbEmail.Location = new System.Drawing.Point(32, 55);
            this.ckbEmail.Name = "ckbEmail";
            this.ckbEmail.Size = new System.Drawing.Size(79, 17);
            this.ckbEmail.TabIndex = 22;
            this.ckbEmail.Text = "Allow Email";
            this.ckbEmail.UseVisualStyleBackColor = false;
            this.ckbEmail.CheckedChanged += new System.EventHandler(this.ckbEmail_CheckedChanged);
            // 
            // btnExecute
            // 
            this.btnExecute.BackColor = System.Drawing.Color.Transparent;
            this.btnExecute.Enabled = false;
            this.btnExecute.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnExecute.Location = new System.Drawing.Point(117, 50);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(147, 24);
            this.btnExecute.TabIndex = 23;
            this.btnExecute.Text = "Execute Now !";
            this.btnExecute.UseVisualStyleBackColor = false;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(756, 367);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.ckbEmail);
            this.Controls.Add(this.btnViewLog);
            this.Controls.Add(this.btnServerSetUp);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbMonth);
            this.Controls.Add(this.gbWeekDays);
            this.Controls.Add(this.lblYourEmail);
            this.Controls.Add(this.txtYourEmail);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFolderPath);
            this.Controls.Add(this.lblCurrentTime);
            this.Controls.Add(this.txtCC);
            this.Controls.Add(this.lblCC);
            this.Controls.Add(this.btnAddQuery);
            this.Controls.Add(this.txtBody);
            this.Controls.Add(this.lblEmailBody);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.lblEmailSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpScheduledTime);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "SQL Data Sender";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbWeekDays.ResumeLayout(false);
            this.gbWeekDays.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpScheduledTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmailSubject;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.TextBox txtBody;
        private System.Windows.Forms.Label lblEmailBody;
        private System.Windows.Forms.Button btnAddQuery;
        private System.Windows.Forms.Label lblCC;
        private System.Windows.Forms.TextBox txtCC;
        private System.Windows.Forms.Timer tmrNow;
        private System.Windows.Forms.Label lblCurrentTime;
        private System.Windows.Forms.Label lblFolderPath;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.TextBox txtYourEmail;
        private System.Windows.Forms.Label lblYourEmail;
        private System.Windows.Forms.GroupBox gbWeekDays;
        private System.Windows.Forms.CheckBox ckbSunday;
        private System.Windows.Forms.CheckBox ckbSaturday;
        private System.Windows.Forms.CheckBox ckbFriday;
        private System.Windows.Forms.CheckBox ckbThursday;
        private System.Windows.Forms.CheckBox ckbWednesday;
        private System.Windows.Forms.CheckBox ckbTuesday;
        private System.Windows.Forms.CheckBox ckbMonday;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnServerSetUp;
        private System.Windows.Forms.Button btnViewLog;
        private System.Windows.Forms.CheckBox ckbEmail;
        private System.Windows.Forms.Button btnExecute;
    }
}

