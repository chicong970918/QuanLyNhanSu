namespace HRM.DanhMuc
{
    partial class SF010
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
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor4 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor5 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor6 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaChucDanh = new Library.Controls.HRMLabel();
            this.hrmLabel5 = new Library.Controls.HRMLabel();
            this.lblTenChucDanh = new Library.Controls.HRMLabel();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.txtTenChuDanh = new Library.Controls.HRMTextBox();
            this.txtMaChucDanh = new Library.Controls.HRMTextBoxUpper();
            this.chkTruongPhong = new Library.Controls.HRMCheckBox();
            this.lblHeSoTrachNhiem = new Library.Controls.HRMLabel();
            this.lblLuong = new Library.Controls.HRMLabel();
            this.txtHeSoChucVu = new Library.Controls.HRMDoubleTextBox(this.components);
            this.lblHeSoChucDanh = new Library.Controls.HRMLabel();
            this.txtHSTrachNhiem = new Library.Controls.HRMDoubleTextBox(this.components);
            this.txtLuongCoBan = new Library.Controls.HRMDoubleTextBox(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChucDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTruongPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSTrachNhiem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongCoBan)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Size = new System.Drawing.Size(1094, 120);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Size = new System.Drawing.Size(1094, 230);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1094, 230);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã chức danh";
            gridColumnDescriptor1.MappingName = "MaChucDanh";
            gridColumnDescriptor1.Width = 192;
            gridColumnDescriptor2.HeaderText = "Tên chức danh";
            gridColumnDescriptor2.MappingName = "TenChucDanh";
            gridColumnDescriptor2.Width = 218;
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor3.HeaderText = "Lương cơ bản";
            gridColumnDescriptor3.MappingName = "LuongCanBan";
            gridColumnDescriptor3.Width = 107;
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor4.HeaderText = "Hệ số chức vụ";
            gridColumnDescriptor4.MappingName = "HeSoChucVu";
            gridColumnDescriptor4.Width = 100;
            gridColumnDescriptor5.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor5.HeaderText = "Hệ số trách nhiệm";
            gridColumnDescriptor5.MappingName = "HeSoTrachNhiem";
            gridColumnDescriptor5.Width = 122;
            gridColumnDescriptor6.HeaderText = "Ghi chú";
            gridColumnDescriptor6.MappingName = "GhiChu";
            gridColumnDescriptor6.Width = 265;
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
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1094, 120);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1088, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 8;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 132F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaChucDanh, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel5, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblTenChucDanh, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtGhiChu, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtTenChuDanh, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMaChucDanh, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.chkTruongPhong, 5, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblHeSoTrachNhiem, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblLuong, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtHeSoChucVu, 6, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblHeSoChucDanh, 5, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtHSTrachNhiem, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtLuongCoBan, 2, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1082, 87);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // lblMaChucDanh
            // 
            this.lblMaChucDanh.AutoSize = true;
            this.lblMaChucDanh.BackColor = System.Drawing.Color.Transparent;
            this.lblMaChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaChucDanh.IsRequired = true;
            this.lblMaChucDanh.Location = new System.Drawing.Point(141, 5);
            this.lblMaChucDanh.Name = "lblMaChucDanh";
            this.lblMaChucDanh.Size = new System.Drawing.Size(144, 25);
            this.lblMaChucDanh.TabIndex = 0;
            this.lblMaChucDanh.Text = "Mã chức danh";
            this.lblMaChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel5
            // 
            this.hrmLabel5.AutoSize = true;
            this.hrmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel5.IsRequired = false;
            this.hrmLabel5.Location = new System.Drawing.Point(141, 55);
            this.hrmLabel5.Name = "hrmLabel5";
            this.hrmLabel5.Size = new System.Drawing.Size(144, 25);
            this.hrmLabel5.TabIndex = 2;
            this.hrmLabel5.Text = "Ghi chú";
            this.hrmLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenChucDanh
            // 
            this.lblTenChucDanh.AutoSize = true;
            this.lblTenChucDanh.BackColor = System.Drawing.Color.Transparent;
            this.lblTenChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenChucDanh.IsRequired = true;
            this.lblTenChucDanh.Location = new System.Drawing.Point(465, 5);
            this.lblTenChucDanh.Name = "lblTenChucDanh";
            this.lblTenChucDanh.Size = new System.Drawing.Size(126, 25);
            this.lblTenChucDanh.TabIndex = 3;
            this.lblTenChucDanh.Text = "Tên chức danh";
            this.lblTenChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtGhiChu, 5);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(289, 56);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(654, 23);
            this.txtGhiChu.TabIndex = 6;
            // 
            // txtTenChuDanh
            // 
            this.txtTenChuDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenChuDanh.Location = new System.Drawing.Point(595, 6);
            this.txtTenChuDanh.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenChuDanh.Name = "txtTenChuDanh";
            this.txtTenChuDanh.Size = new System.Drawing.Size(173, 23);
            this.txtTenChuDanh.TabIndex = 1;
            // 
            // txtMaChucDanh
            // 
            this.txtMaChucDanh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaChucDanh.Location = new System.Drawing.Point(289, 6);
            this.txtMaChucDanh.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaChucDanh.MaxLength = 20;
            this.txtMaChucDanh.Name = "txtMaChucDanh";
            this.txtMaChucDanh.Size = new System.Drawing.Size(172, 23);
            this.txtMaChucDanh.TabIndex = 0;
            // 
            // chkTruongPhong
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.chkTruongPhong, 2);
            this.chkTruongPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkTruongPhong.Location = new System.Drawing.Point(772, 8);
            this.chkTruongPhong.Name = "chkTruongPhong";
            this.chkTruongPhong.Size = new System.Drawing.Size(169, 19);
            this.chkTruongPhong.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2007;
            this.chkTruongPhong.TabIndex = 2;
            this.chkTruongPhong.Text = "Trưởng phòng";
            this.chkTruongPhong.ThemesEnabled = false;
            // 
            // lblHeSoTrachNhiem
            // 
            this.lblHeSoTrachNhiem.AutoSize = true;
            this.lblHeSoTrachNhiem.BackColor = System.Drawing.Color.Transparent;
            this.lblHeSoTrachNhiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeSoTrachNhiem.IsRequired = true;
            this.lblHeSoTrachNhiem.Location = new System.Drawing.Point(465, 30);
            this.lblHeSoTrachNhiem.Name = "lblHeSoTrachNhiem";
            this.lblHeSoTrachNhiem.Size = new System.Drawing.Size(126, 25);
            this.lblHeSoTrachNhiem.TabIndex = 5;
            this.lblHeSoTrachNhiem.Text = "Hệ số trách nhiệm";
            this.lblHeSoTrachNhiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLuong
            // 
            this.lblLuong.AutoSize = true;
            this.lblLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLuong.IsRequired = true;
            this.lblLuong.Location = new System.Drawing.Point(141, 30);
            this.lblLuong.Name = "lblLuong";
            this.lblLuong.Size = new System.Drawing.Size(144, 25);
            this.lblLuong.TabIndex = 6;
            this.lblLuong.Text = "Lương cơ bản";
            this.lblLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHeSoChucVu
            // 
            this.txtHeSoChucVu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHeSoChucVu.DoubleValue = 0D;
         //   this.txtHeSoChucVu.IsNullValue = true;
            this.txtHeSoChucVu.Location = new System.Drawing.Point(876, 31);
            this.txtHeSoChucVu.Margin = new System.Windows.Forms.Padding(1);
            this.txtHeSoChucVu.MaxLength = 5;
            this.txtHeSoChucVu.MaxValue = 10D;
            this.txtHeSoChucVu.MinValue = 0D;
            this.txtHeSoChucVu.Name = "txtHeSoChucVu";
            this.txtHeSoChucVu.NullString = "";
            this.txtHeSoChucVu.Size = new System.Drawing.Size(67, 23);
            this.txtHeSoChucVu.TabIndex = 5;
            this.txtHeSoChucVu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHeSoChucVu.UseNullString = true;
            // 
            // lblHeSoChucDanh
            // 
            this.lblHeSoChucDanh.AutoSize = true;
            this.lblHeSoChucDanh.BackColor = System.Drawing.Color.Transparent;
            this.lblHeSoChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeSoChucDanh.IsRequired = true;
            this.lblHeSoChucDanh.Location = new System.Drawing.Point(772, 30);
            this.lblHeSoChucDanh.Name = "lblHeSoChucDanh";
            this.lblHeSoChucDanh.Size = new System.Drawing.Size(100, 25);
            this.lblHeSoChucDanh.TabIndex = 4;
            this.lblHeSoChucDanh.Text = "Hệ số chức vụ";
            this.lblHeSoChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHSTrachNhiem
            // 
            this.txtHSTrachNhiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHSTrachNhiem.DoubleValue = 0D;
           // this.txtHSTrachNhiem.IsNullValue = true;
            this.txtHSTrachNhiem.Location = new System.Drawing.Point(595, 31);
            this.txtHSTrachNhiem.Margin = new System.Windows.Forms.Padding(1);
            this.txtHSTrachNhiem.MaxLength = 5;
            this.txtHSTrachNhiem.MaxValue = 10D;
            this.txtHSTrachNhiem.MinValue = 0D;
            this.txtHSTrachNhiem.Name = "txtHSTrachNhiem";
            this.txtHSTrachNhiem.NullString = "";
            this.txtHSTrachNhiem.Size = new System.Drawing.Size(173, 23);
            this.txtHSTrachNhiem.TabIndex = 4;
            this.txtHSTrachNhiem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtHSTrachNhiem.UseNullString = true;
            // 
            // txtLuongCoBan
            // 
            this.txtLuongCoBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLuongCoBan.DoubleValue = 0D;
         //   this.txtLuongCoBan.IsNullValue = true;
            this.txtLuongCoBan.Location = new System.Drawing.Point(289, 31);
            this.txtLuongCoBan.Margin = new System.Windows.Forms.Padding(1);
            this.txtLuongCoBan.MaxLength = 12;
            this.txtLuongCoBan.MaxValue = 1.7976931348623158E+307D;
            this.txtLuongCoBan.MinValue = 0D;
            this.txtLuongCoBan.Name = "txtLuongCoBan";
            this.txtLuongCoBan.NullString = "";
            this.txtLuongCoBan.Size = new System.Drawing.Size(172, 23);
            this.txtLuongCoBan.TabIndex = 3;
            this.txtLuongCoBan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtLuongCoBan.UseNullString = true;
            // 
            // SF010
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1094, 384);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SF010";
            this.Text = "DANH MỤC CHỨC DANH";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChucDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkTruongPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHSTrachNhiem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLuongCoBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Library.Controls.HRMLabel lblMaChucDanh;
        private Library.Controls.HRMLabel hrmLabel5;
        private Library.Controls.HRMLabel lblTenChucDanh;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMTextBox txtTenChuDanh;
        private Library.Controls.HRMTextBoxUpper txtMaChucDanh;
        private Library.Controls.HRMCheckBox chkTruongPhong;
        private Library.Controls.HRMLabel lblHeSoChucDanh;
        private Library.Controls.HRMDoubleTextBox txtHeSoChucVu;
        private Library.Controls.HRMLabel lblHeSoTrachNhiem;
        private Library.Controls.HRMLabel lblLuong;
        private Library.Controls.HRMDoubleTextBox txtHSTrachNhiem;
        private Library.Controls.HRMDoubleTextBox txtLuongCoBan;
    }
}