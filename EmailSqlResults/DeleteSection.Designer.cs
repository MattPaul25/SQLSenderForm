namespace EmailSqlResults
{
    partial class DeleteSection
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
            this.lblDelet = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnNo = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblDelet
            // 
            this.lblDelet.AutoSize = true;
            this.lblDelet.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDelet.Location = new System.Drawing.Point(32, 49);
            this.lblDelet.Name = "lblDelet";
            this.lblDelet.Size = new System.Drawing.Size(206, 31);
            this.lblDelet.TabIndex = 0;
            this.lblDelet.Text = "Delete Section?";
            // 
            // btnYes
            // 
            this.btnYes.Location = new System.Drawing.Point(254, 123);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(106, 23);
            this.btnYes.TabIndex = 1;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.Location = new System.Drawing.Point(132, 123);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(106, 23);
            this.btnNo.TabIndex = 2;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // DeleteSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 158);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.lblDelet);
            this.Name = "DeleteSection";
            this.Text = "DeleteSection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDelet;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnNo;
    }
}