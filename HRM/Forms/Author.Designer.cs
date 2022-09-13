namespace HRM.Forms
{
    partial class Author
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtabout = new Library.Controls.HRMTextBox();
            this.btnOk = new Library.Controls.HRMButton(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtabout)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(441, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(235, 227);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtabout
            // 
            this.txtabout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtabout.BeforeTouchSize = new System.Drawing.Size(428, 227);
            this.txtabout.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtabout.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtabout.Location = new System.Drawing.Point(6, 12);
            this.txtabout.Multiline = true;
            this.txtabout.Name = "txtabout";
            this.txtabout.ReadOnly = true;
            this.txtabout.Size = new System.Drawing.Size(428, 227);
            this.txtabout.TabIndex = 1;
            this.txtabout.Text = "Mọi ý kiến góp ý xin vui lòng liên hệ:\r\n\r\n       Xin tiếp nhận và cảm ơn  tất cả " +
    "những ý kiến đóng góp của các bạn.";
            // 
            // btnOk
            // 
            this.btnOk.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnOk.BeforeTouchSize = new System.Drawing.Size(82, 30);
            this.btnOk.Location = new System.Drawing.Point(594, 245);
            this.btnOk.Name = "btnOk";
            this.btnOk.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnOk.Size = new System.Drawing.Size(82, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.ThemeName = "Office2007";
            this.btnOk.UseVisualStyle = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // Author
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 279);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtabout);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Author";
            this.Text = "TÁC GIẢ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtabout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private Library.Controls.HRMTextBox txtabout;
        private Library.Controls.HRMButton btnOk;
    }
}