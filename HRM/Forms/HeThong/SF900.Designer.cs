namespace HRM.Forms.HeThong
{
    partial class SF900
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
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor4 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor5 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor6 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF900));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNhanVien = new Library.Controls.HRMLabel();
            this.lblTenDAngNhap = new Library.Controls.HRMLabel();
            this.txtTenDangNhap = new Library.Controls.HRMTextBox();
            this.cbxHoatDong = new Library.Controls.HRMCheckBox();
            this.txtMaNhanVien = new Library.Controls.HRMTextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel4 = new Library.Controls.HRMLabel();
            this.hrmLabel5 = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtHoDem = new Library.Controls.HRMTextBox();
            this.txtTen = new Library.Controls.HRMTextBox();
            this.txtPhongBan = new Library.Controls.HRMTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxHoatDong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoDem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhongBan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1161, 119);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1161, 439);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1161, 439);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            this.GrdData.TableDescriptor.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor1.HeaderText = "Tên đăng nhập";
            gridColumnDescriptor1.MappingName = "TenDangNhap";
            gridColumnDescriptor1.Width = 145;
            gridColumnDescriptor2.HeaderText = "Họ đệm";
            gridColumnDescriptor2.MappingName = "HoDem";
            gridColumnDescriptor2.Width = 141;
            gridColumnDescriptor3.HeaderText = "Tên";
            gridColumnDescriptor3.MappingName = "Ten";
            gridColumnDescriptor3.Width = 114;
            gridColumnDescriptor4.HeaderText = "Tên phòng ban";
            gridColumnDescriptor4.MappingName = "TenPhongBan";
            gridColumnDescriptor4.Width = 157;
            gridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor5.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor5.HeaderText = "Hoạt động";
            gridColumnDescriptor5.MappingName = "HoatDong";
            gridColumnDescriptor5.Width = 178;
            gridColumnDescriptor6.HeaderText = "Mã nhân viên";
            gridColumnDescriptor6.MappingName = "MaNhanVien";
            gridColumnDescriptor6.Width = 139;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3,
            gridColumnDescriptor4,
            gridColumnDescriptor5,
            gridColumnDescriptor6});
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.GrdData.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableDescriptor.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TenDangNhap"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("MaNhanVien"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HoDem"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Ten"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TenPhongBan"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HoatDong")});
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 510F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 548F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1161, 119);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(55, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(502, 98);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông tin tài khoản";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.7324F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.2676F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaNhanVien, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTenDAngNhap, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtTenDangNhap, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.cbxHoatDong, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtMaNhanVien, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 71);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblMaNhanVien
            // 
            this.lblMaNhanVien.AutoSize = true;
            this.lblMaNhanVien.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNhanVien.IsRequired = true;
            this.lblMaNhanVien.Location = new System.Drawing.Point(1, 32);
            this.lblMaNhanVien.Margin = new System.Windows.Forms.Padding(1);
            this.lblMaNhanVien.Name = "lblMaNhanVien";
            this.lblMaNhanVien.Size = new System.Drawing.Size(133, 29);
            this.lblMaNhanVien.TabIndex = 3;
            this.lblMaNhanVien.Text = "Mã nhân viên";
            this.lblMaNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenDAngNhap
            // 
            this.lblTenDAngNhap.AutoSize = true;
            this.lblTenDAngNhap.BackColor = System.Drawing.Color.Transparent;
            this.lblTenDAngNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenDAngNhap.IsRequired = true;
            this.lblTenDAngNhap.Location = new System.Drawing.Point(1, 1);
            this.lblTenDAngNhap.Margin = new System.Windows.Forms.Padding(1);
            this.lblTenDAngNhap.Name = "lblTenDAngNhap";
            this.lblTenDAngNhap.Size = new System.Drawing.Size(133, 29);
            this.lblTenDAngNhap.TabIndex = 0;
            this.lblTenDAngNhap.Text = "Tên đăng nhập";
            this.lblTenDAngNhap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenDangNhap
            // 
            this.txtTenDangNhap.BeforeTouchSize = new System.Drawing.Size(175, 26);
            this.txtTenDangNhap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenDangNhap.Location = new System.Drawing.Point(136, 1);
            this.txtTenDangNhap.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenDangNhap.Name = "txtTenDangNhap";
            this.txtTenDangNhap.Size = new System.Drawing.Size(212, 26);
            this.txtTenDangNhap.TabIndex = 0;
            // 
            // cbxHoatDong
            // 
            this.cbxHoatDong.BeforeTouchSize = new System.Drawing.Size(143, 29);
            this.cbxHoatDong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbxHoatDong.ImageCheckBoxSize = new System.Drawing.Size(16, 16);
            this.cbxHoatDong.Location = new System.Drawing.Point(350, 1);
            this.cbxHoatDong.Margin = new System.Windows.Forms.Padding(1);
            this.cbxHoatDong.Name = "cbxHoatDong";
            this.cbxHoatDong.Size = new System.Drawing.Size(143, 29);
            this.cbxHoatDong.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2007;
            this.cbxHoatDong.TabIndex = 1;
            this.cbxHoatDong.Text = "Hoạt động";
            this.cbxHoatDong.ThemeName = "Office2007";
            // 
            // txtMaNhanVien
            // 
            this.txtMaNhanVien.BeforeTouchSize = new System.Drawing.Size(175, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtMaNhanVien, 2);
            this.txtMaNhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNhanVien.Location = new System.Drawing.Point(136, 32);
            this.txtMaNhanVien.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNhanVien.MaxLength = 12;
            this.txtMaNhanVien.Name = "txtMaNhanVien";
            this.txtMaNhanVien.Size = new System.Drawing.Size(357, 26);
            this.txtMaNhanVien.TabIndex = 4;
            this.txtMaNhanVien.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaNhanVien_KeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(565, 10);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(540, 98);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin người dùng";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 4;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47.18615F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 52.81385F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel5, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel3, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtHoDem, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTen, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtPhongBan, 1, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 3;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(532, 71);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // hrmLabel4
            // 
            this.hrmLabel4.AutoSize = true;
            this.hrmLabel4.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel4.IsRequired = false;
            this.hrmLabel4.Location = new System.Drawing.Point(1, 1);
            this.hrmLabel4.Margin = new System.Windows.Forms.Padding(1);
            this.hrmLabel4.Name = "hrmLabel4";
            this.hrmLabel4.Size = new System.Drawing.Size(145, 29);
            this.hrmLabel4.TabIndex = 5;
            this.hrmLabel4.Text = "Họ đệm";
            this.hrmLabel4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel5
            // 
            this.hrmLabel5.AutoSize = true;
            this.hrmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel5.IsRequired = false;
            this.hrmLabel5.Location = new System.Drawing.Point(312, 1);
            this.hrmLabel5.Margin = new System.Windows.Forms.Padding(1);
            this.hrmLabel5.Name = "hrmLabel5";
            this.hrmLabel5.Size = new System.Drawing.Size(42, 29);
            this.hrmLabel5.TabIndex = 6;
            this.hrmLabel5.Text = "Tên";
            this.hrmLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(1, 32);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(1);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(145, 29);
            this.hrmLabel3.TabIndex = 4;
            this.hrmLabel3.Text = "Tên phòng ban";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHoDem
            // 
            this.txtHoDem.BeforeTouchSize = new System.Drawing.Size(175, 26);
            this.txtHoDem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHoDem.Location = new System.Drawing.Point(148, 1);
            this.txtHoDem.Margin = new System.Windows.Forms.Padding(1);
            this.txtHoDem.Name = "txtHoDem";
            this.txtHoDem.ReadOnly = true;
            this.txtHoDem.Size = new System.Drawing.Size(162, 26);
            this.txtHoDem.TabIndex = 0;
            // 
            // txtTen
            // 
            this.txtTen.BeforeTouchSize = new System.Drawing.Size(175, 26);
            this.txtTen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTen.Location = new System.Drawing.Point(356, 1);
            this.txtTen.Margin = new System.Windows.Forms.Padding(1);
            this.txtTen.Name = "txtTen";
            this.txtTen.ReadOnly = true;
            this.txtTen.Size = new System.Drawing.Size(175, 26);
            this.txtTen.TabIndex = 1;
            // 
            // txtPhongBan
            // 
            this.txtPhongBan.BeforeTouchSize = new System.Drawing.Size(175, 26);
            this.tableLayoutPanel3.SetColumnSpan(this.txtPhongBan, 3);
            this.txtPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtPhongBan.Location = new System.Drawing.Point(148, 32);
            this.txtPhongBan.Margin = new System.Windows.Forms.Padding(1);
            this.txtPhongBan.Name = "txtPhongBan";
            this.txtPhongBan.ReadOnly = true;
            this.txtPhongBan.Size = new System.Drawing.Size(383, 26);
            this.txtPhongBan.TabIndex = 2;
            // 
            // SF900
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1161, 592);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SF900";
            this.Text = "DANH MỤC NGƯỜI DÙNG";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDangNhap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbxHoatDong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhanVien)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoDem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhongBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Library.Controls.HRMLabel lblMaNhanVien;
        private Library.Controls.HRMLabel lblTenDAngNhap;
        private Library.Controls.HRMTextBox txtTenDangNhap;
        private Library.Controls.HRMCheckBox cbxHoatDong;
        private Library.Controls.HRMLabel hrmLabel4;
        private Library.Controls.HRMLabel hrmLabel5;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMTextBox txtHoDem;
        private Library.Controls.HRMTextBox txtTen;
        private Library.Controls.HRMTextBox txtPhongBan;
        private Library.Controls.HRMTextBox txtMaNhanVien;
    }
}