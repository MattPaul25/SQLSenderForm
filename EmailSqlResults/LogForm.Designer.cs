namespace EmailSqlResults
{
    partial class LogForm
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
            this.txtLogFile = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtLogFile
            // 
            this.txtLogFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogFile.Location = new System.Drawing.Point(0, 0);
            this.txtLogFile.Multiline = true;
            this.txtLogFile.Name = "txtLogFile";
            this.txtLogFile.Size = new System.Drawing.Size(577, 447);
            this.txtLogFile.TabIndex = 0;
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 447);
            this.Controls.Add(this.txtLogFile);
            this.Name = "LogForm";
            this.Text = "LogForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtLogFile;
    }
}