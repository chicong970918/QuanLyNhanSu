namespace HRM.Forms.ChamCong_Luong
{
    partial class SF312
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
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNhanVien = new Library.Controls.HRMLabel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.hrmLabel2 = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.btnChon = new Library.Controls.HRMButton(this.components);
            this.btnHuy = new Library.Controls.HRMButton(this.components);
            this.txtMaNhanVien = new Library.Controls.HRMTextBox();
            this.txtHoDem = new Library.Controls.HRMTextBox();
            this.txtTen = new Library.Controls.HRMTextBox();
            this.txtSoTien = new Library.Controls.HRMIntergerTextBox(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.gradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.tableLayoutPanel2);
            this.gradientPanel1.Controls.Add(this.panel3);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(0, 0);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(323, 171);
            this.gradientPanel1.TabIndex = 201;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 114F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaNhanVien, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel1, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel2, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel3, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.btnChon, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.btnHuy, 2, 5);
            this.tableLayoutPanel2.Controls.Add(this.txtMaNhanVien, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtHoDem, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtTen, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtSoTien, 1, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 30);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 7;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(321, 139);
            this.tableLayoutPanel2.TabIndex = 159;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNhanVien.IsRequired = false;
            this.lblMaNhanVien.Location = new System.Drawing.Point(3, 6);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(108, 25);
            this.lblMaNhanVien.TabIndex = 0;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            this.lblMaNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(3, 31);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(108, 25);
            this.hrmLabel1.TabIndex = 1;
            this.hrmLabel1.Text = "Họ đệm";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel2
            // 
            this.hrmLabel2.AutoSize = true;
            this.hrmLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel2.IsRequired = false;
            this.hrmLabel2.Location = new System.Drawing.Point(3, 56);
            this.hrmLabel2.Name = "hrmLabel2";
            this.hrmLabel2.Size = new System.Drawing.Size(108, 25);
            this.hrmLabel2.TabIndex = 2;
            this.hrmLabel2.Text = "Tên";
            this.hrmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(3, 81);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(108, 25);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Số tiền giảm trừ";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChon
            // 
            this.btnChon.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnChon.BeforeTouchSize = new System.Drawing.Size(98, 28);
            this.btnChon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnChon.Image = global::HRM.Properties.Resources.checked1;
            this.btnChon.Location = new System.Drawing.Point(115, 107);
            this.btnChon.Margin = new System.Windows.Forms.Padding(1);
            this.btnChon.Name = "btnChon";
            this.btnChon.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnChon.Size = new System.Drawing.Size(98, 28);
            this.btnChon.TabIndex = 4;
            this.btnChon.ThemeName = "Office2007";
            this.btnChon.UseVisualStyle = true;
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnHuy.BeforeTouchSize = new System.Drawing.Size(98, 28);
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuy.Image = global::HRM.Properties.Resources.closeShutdown;
            this.btnHuy.Location = new System.Drawing.Point(215, 107);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(1);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnHuy.Size = new System.Drawing.Size(98, 28);
            this.btnHuy.TabIndex = 5;
            this.btnHuy.ThemeName = "Office2007";
            this.btnHuy.UseVisualStyle = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.BeforeTouchSize = new System.Drawing.Size(117, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtMaNhanVien, 2);
            this.txtMaNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNhanVien.Enabled = false;
            this.txtMaNhanVien.Location = new System.Drawing.Point(115, 7);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(198, 26);
            this.txtMaNhanVien.TabIndex = 6;
            // 
            // txtHoDem
            // 
            this.txtHoDem.BeforeTouchSize = new System.Drawing.Size(117, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtHoDem, 2);
            this.txtHoDem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoDem.Enabled = false;
            this.txtHoDem.Location = new System.Drawing.Point(115, 32);
            this.txtHoDem.Margin = new System.Windows.Forms.Padding(1);
            this.txtHoDem.Name = "txtHoDem";
            this.txtHoDem.Size = new System.Drawing.Size(198, 26);
            this.txtHoDem.TabIndex = 7;
            // 
            // txtTen
            // 
            this.txtTen.BeforeTouchSize = new System.Drawing.Size(117, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtTen, 2);
            this.txtTen.Enabled = false;
            this.txtTen.Location = new System.Drawing.Point(115, 57);
            this.txtTen.Margin = new System.Windows.Forms.Padding(1);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(198, 26);
            this.txtTen.TabIndex = 8;
            // 
            // txtSoTien
            // 
            this.txtSoTien.BeforeTouchSize = new System.Drawing.Size(117, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtSoTien, 2);
            this.txtSoTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoTien.IntegerValue = ((long)(1));
            this.txtSoTien.Location = new System.Drawing.Point(115, 82);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(1);
            this.txtSoTien.MaxValue = ((long)(2147483647));
            this.txtSoTien.MinValue = ((long)(0));
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(198, 26);
            this.txtSoTien.TabIndex = 9;
            this.txtSoTien.Text = "1";
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(321, 30);
            this.panel3.TabIndex = 158;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 30);
            this.label2.TabIndex = 170;
            this.label2.Text = "Chi tiết";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SF312
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 171);
            this.Controls.Add(this.gradientPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF312";
            this.Text = "GIẢM TRỪ KHÁC";
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Library.Controls.HRMLabel lblMaNhanVien;
        private Library.Controls.HRMLabel hrmLabel1;
        private Library.Controls.HRMLabel hrmLabel2;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMButton btnChon;
        private Library.Controls.HRMButton btnHuy;
        private Library.Controls.HRMTextBox txtMaNhanVien;
        private Library.Controls.HRMTextBox txtHoDem;
        private Library.Controls.HRMTextBox txtTen;
        private Library.Controls.HRMIntergerTextBox txtSoTien;
    }
}