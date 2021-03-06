﻿namespace EmailSqlResults
{
    partial class ServerSetUp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerSetUp));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassWord = new System.Windows.Forms.TextBox();
            this.btnSetServer = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblConnectionCheck = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(49, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(89, 36);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(396, 20);
            this.txtServer.TabIndex = 3;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(89, 67);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(396, 20);
            this.txtUserName.TabIndex = 4;
            // 
            // txtPassWord
            // 
            this.txtPassWord.Location = new System.Drawing.Point(89, 95);
            this.txtPassWord.Name = "txtPassWord";
            this.txtPassWord.Size = new System.Drawing.Size(396, 20);
            this.txtPassWord.TabIndex = 5;
            // 
            // btnSetServer
            // 
            this.btnSetServer.Location = new System.Drawing.Point(246, 125);
            this.btnSetServer.Name = "btnSetServer";
            this.btnSetServer.Size = new System.Drawing.Size(110, 23);
            this.btnSetServer.TabIndex = 6;
            this.btnSetServer.Text = "Set Server";
            this.btnSetServer.UseVisualStyleBackColor = true;
            this.btnSetServer.Click += new System.EventHandler(this.btnSetServer_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(375, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblConnectionCheck
            // 
            this.lblConnectionCheck.AutoSize = true;
            this.lblConnectionCheck.Location = new System.Drawing.Point(86, 9);
            this.lblConnectionCheck.Name = "lblConnectionCheck";
            this.lblConnectionCheck.Size = new System.Drawing.Size(0, 13);
            this.lblConnectionCheck.TabIndex = 8;
            // 
            // ServerSetUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(508, 158);
            this.Controls.Add(this.lblConnectionCheck);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSetServer);
            this.Controls.Add(this.txtPassWord);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ServerSetUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ServerSetUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassWord;
        private System.Windows.Forms.Button btnSetServer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblConnectionCheck;
    }
}