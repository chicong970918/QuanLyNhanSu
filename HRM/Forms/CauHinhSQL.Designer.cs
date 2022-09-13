namespace HRM.Forms
{
    partial class CauHinhSQL
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenSerVer = new Library.Controls.HRMLabel();
            this.cboSever = new Library.Controls.HRMCombobox();
            this.chkboxchungthuc = new Library.Controls.HRMCheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTenDangNhap = new Library.Controls.HRMLabel();
            this.lblMatKhau = new Library.Controls.HRMLabel();
            this.txtusername = new Library.Controls.HRMTextBox();
            this.txtpass = new Library.Controls.HRMTextBox();
            this.lbltenCoSoDuLieu = new Library.Controls.HRMLabel();
            this.cboTenCSDL = new Library.Controls.HRMCombobox();
            this.btnthuketnoi = new Library.Controls.HRMButton(this.components);
            this.btnketnoi = new Library.Controls.HRMButton(this.components);
            this.btnDong = new Library.Controls.HRMButton(this.components);
            this.btnHuy = new Library.Controls.HRMButton(this.components);
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSever)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkboxchungthuc)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTenCSDL)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 123F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel1.Controls.Add(this.lblTenSerVer, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboSever, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.chkboxchungthuc, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnthuketnoi, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnketnoi, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnDong, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnHuy, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel1, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 133F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(475, 284);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblTenSerVer
            // 
            this.lblTenSerVer.AutoSize = true;
            this.lblTenSerVer.BackColor = System.Drawing.Color.Transparent;
            this.lblTenSerVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenSerVer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenSerVer.IsRequired = true;
            this.lblTenSerVer.Location = new System.Drawing.Point(1, 7);
            this.lblTenSerVer.Margin = new System.Windows.Forms.Padding(1);
            this.lblTenSerVer.Name = "lblTenSerVer";
            this.lblTenSerVer.Size = new System.Drawing.Size(105, 29);
            this.lblTenSerVer.TabIndex = 0;
            this.lblTenSerVer.Text = "Tên server";
            this.lblTenSerVer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSever
            // 
            this.cboSever.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cboSever.BeforeTouchSize = new System.Drawing.Size(369, 26);
            this.tableLayoutPanel1.SetColumnSpan(this.cboSever, 3);
            this.cboSever.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboSever.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSever.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboSever.Location = new System.Drawing.Point(108, 7);
            this.cboSever.Margin = new System.Windows.Forms.Padding(1);
            this.cboSever.MaxDropDownItems = 10;
            this.cboSever.Name = "cboSever";
            this.cboSever.ShowImageInTextBox = true;
            this.cboSever.Size = new System.Drawing.Size(369, 26);
            this.cboSever.Sorted = true;
            this.cboSever.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboSever.TabIndex = 1;
            this.cboSever.ThemeName = "Office2007Outlook";
            // 
            // chkboxchungthuc
            // 
            this.chkboxchungthuc.BeforeTouchSize = new System.Drawing.Size(476, 29);
            this.chkboxchungthuc.Checked = true;
            this.chkboxchungthuc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tableLayoutPanel1.SetColumnSpan(this.chkboxchungthuc, 4);
            this.chkboxchungthuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkboxchungthuc.Enabled = false;
            this.chkboxchungthuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkboxchungthuc.ImageCheckBoxSize = new System.Drawing.Size(16, 16);
            this.chkboxchungthuc.Location = new System.Drawing.Point(1, 38);
            this.chkboxchungthuc.Margin = new System.Windows.Forms.Padding(1);
            this.chkboxchungthuc.Name = "chkboxchungthuc";
            this.chkboxchungthuc.Size = new System.Drawing.Size(476, 29);
            this.chkboxchungthuc.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2007;
            this.chkboxchungthuc.TabIndex = 2;
            this.chkboxchungthuc.Text = "Chứng thực kiểu SQL";
            this.chkboxchungthuc.ThemeName = "Office2007";
            // 
            // groupBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.groupBox1, 4);
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(1, 69);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(476, 131);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin đăng nhập SQL";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.61538F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.38462F));
            this.tableLayoutPanel2.Controls.Add(this.lblTenDangNhap, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblMatKhau, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtusername, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtpass, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lbltenCoSoDuLieu, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.cboTenCSDL, 1, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(468, 104);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblTenDangNhap
            // 
            this.lblTenDangNhap.AutoSize = true;
            this.lblTenDangNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenDangNhap.IsRequired = true;
            this.lblTenDangNhap.Location = new System.Drawing.Point(4, 6);
            this.lblTenDangNhap.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenDangNhap.Name = "lblTenDangNhap";
            this.lblTenDangNhap.Size = new System.Drawing.Size(153, 31);
            this.lblTenDangNhap.TabIndex = 0;
            this.lblTenDangNhap.Text = "Tên đăng nhập";
            this.lblTenDangNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.AutoSize = true;
            this.lblMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMatKhau.IsRequired = true;
            this.lblMatKhau.Location = new System.Drawing.Point(4, 37);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(153, 31);
            this.lblMatKhau.TabIndex = 1;
            this.lblMatKhau.Text = "Mật khẩu";
            this.lblMatKhau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtusername
            // 
            this.txtusername.BeforeTouchSize = new System.Drawing.Size(319, 26);
            this.txtusername.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtusername.Location = new System.Drawing.Point(162, 7);
            this.txtusername.Margin = new System.Windows.Forms.Padding(1);
            this.txtusername.Name = "txtusername";
            this.txtusername.Size = new System.Drawing.Size(305, 26);
            this.txtusername.TabIndex = 2;
            // 
            // txtpass
            // 
            this.txtpass.BeforeTouchSize = new System.Drawing.Size(319, 26);
            this.txtpass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtpass.Location = new System.Drawing.Point(162, 38);
            this.txtpass.Margin = new System.Windows.Forms.Padding(1);
            this.txtpass.Name = "txtpass";
            this.txtpass.PasswordChar = '●';
            this.txtpass.Size = new System.Drawing.Size(305, 26);
            this.txtpass.TabIndex = 3;
            this.txtpass.UseSystemPasswordChar = true;
            // 
            // lbltenCoSoDuLieu
            // 
            this.lbltenCoSoDuLieu.AutoSize = true;
            this.lbltenCoSoDuLieu.BackColor = System.Drawing.Color.Transparent;
            this.lbltenCoSoDuLieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltenCoSoDuLieu.IsRequired = true;
            this.lbltenCoSoDuLieu.Location = new System.Drawing.Point(1, 69);
            this.lbltenCoSoDuLieu.Margin = new System.Windows.Forms.Padding(1);
            this.lbltenCoSoDuLieu.Name = "lbltenCoSoDuLieu";
            this.lbltenCoSoDuLieu.Size = new System.Drawing.Size(159, 29);
            this.lbltenCoSoDuLieu.TabIndex = 4;
            this.lbltenCoSoDuLieu.Text = "Tên cơ sở dữ liệu";
            this.lbltenCoSoDuLieu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboTenCSDL
            // 
            this.cboTenCSDL.BeforeTouchSize = new System.Drawing.Size(305, 26);
            this.cboTenCSDL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTenCSDL.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTenCSDL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboTenCSDL.Location = new System.Drawing.Point(162, 69);
            this.cboTenCSDL.Margin = new System.Windows.Forms.Padding(1);
            this.cboTenCSDL.Name = "cboTenCSDL";
            this.cboTenCSDL.Size = new System.Drawing.Size(305, 26);
            this.cboTenCSDL.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboTenCSDL.TabIndex = 5;
            this.cboTenCSDL.ThemeName = "Office2007Outlook";
            // 
            // btnthuketnoi
            // 
            this.btnthuketnoi.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnthuketnoi.BeforeTouchSize = new System.Drawing.Size(105, 39);
            this.btnthuketnoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnthuketnoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthuketnoi.Location = new System.Drawing.Point(1, 235);
            this.btnthuketnoi.Margin = new System.Windows.Forms.Padding(1);
            this.btnthuketnoi.Name = "btnthuketnoi";
            this.btnthuketnoi.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnthuketnoi.Size = new System.Drawing.Size(105, 39);
            this.btnthuketnoi.TabIndex = 4;
            this.btnthuketnoi.Text = "Thử kết nối";
            this.btnthuketnoi.ThemeName = "Office2007";
            this.btnthuketnoi.UseVisualStyle = true;
            this.btnthuketnoi.Click += new System.EventHandler(this.hrmButton1_Click);
            // 
            // btnketnoi
            // 
            this.btnketnoi.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnketnoi.BeforeTouchSize = new System.Drawing.Size(129, 39);
            this.btnketnoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnketnoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnketnoi.Location = new System.Drawing.Point(108, 235);
            this.btnketnoi.Margin = new System.Windows.Forms.Padding(1);
            this.btnketnoi.Name = "btnketnoi";
            this.btnketnoi.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnketnoi.Size = new System.Drawing.Size(129, 39);
            this.btnketnoi.TabIndex = 5;
            this.btnketnoi.Text = "Kết nối";
            this.btnketnoi.ThemeName = "Office2007";
            this.btnketnoi.UseVisualStyle = true;
            // 
            // btnDong
            // 
            this.btnDong.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnDong.BeforeTouchSize = new System.Drawing.Size(121, 39);
            this.btnDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDong.Location = new System.Drawing.Point(239, 235);
            this.btnDong.Margin = new System.Windows.Forms.Padding(1);
            this.btnDong.Name = "btnDong";
            this.btnDong.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnDong.Size = new System.Drawing.Size(121, 39);
            this.btnDong.TabIndex = 6;
            this.btnDong.Text = "Thoát";
            this.btnDong.ThemeName = "Office2007";
            this.btnDong.UseVisualStyle = true;
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnHuy.BeforeTouchSize = new System.Drawing.Size(115, 39);
            this.btnHuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuy.Location = new System.Drawing.Point(362, 235);
            this.btnHuy.Margin = new System.Windows.Forms.Padding(1);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnHuy.Size = new System.Drawing.Size(115, 39);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.ThemeName = "Office2007";
            this.btnHuy.UseVisualStyle = true;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.SetColumnSpan(this.hrmLabel1, 4);
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hrmLabel1.ForeColor = System.Drawing.Color.Red;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(1, 202);
            this.hrmLabel1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(476, 31);
            this.hrmLabel1.TabIndex = 8;
            this.hrmLabel1.Text = "Sau khi kết nối thành công vui lòng khởi động lại.";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CauHinhSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 284);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CauHinhSQL";
            this.Text = "CẤU HÌNH SQL";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboSever)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkboxchungthuc)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtusername)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtpass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTenCSDL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMLabel lblTenSerVer;
        private Library.Controls.HRMCombobox cboSever;
        private Library.Controls.HRMCheckBox chkboxchungthuc;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Library.Controls.HRMLabel lblTenDangNhap;
        private Library.Controls.HRMLabel lblMatKhau;
        private Library.Controls.HRMTextBox txtusername;
        private Library.Controls.HRMTextBox txtpass;
        private Library.Controls.HRMButton btnthuketnoi;
        private Library.Controls.HRMButton btnketnoi;
        private Library.Controls.HRMButton btnDong;
        private Library.Controls.HRMLabel lbltenCoSoDuLieu;
        private Library.Controls.HRMCombobox cboTenCSDL;
        private Library.Controls.HRMButton btnHuy;
        private Library.Controls.HRMLabel hrmLabel1;
    }
}