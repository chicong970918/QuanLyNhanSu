namespace HRM.Forms.TuyenDung
{
    partial class SF101
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF101));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.lblChucDanh = new Library.Controls.HRMLabel();
            this.lblChiTiet = new Library.Controls.HRMLabel();
            this.lblSoLuong = new Library.Controls.HRMLabel();
            this.hrmLabel7 = new Library.Controls.HRMLabel();
            this.lblNgayCan = new Library.Controls.HRMLabel();
            this.hrmLabel6 = new Library.Controls.HRMLabel();
            this.txtMaKeHoach = new Library.Controls.HRMTextBox();
            this.txtMaChiTiet = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.cboChucDanh = new Library.Controls.HRMCombobox();
            this.cboLyDo = new Library.Controls.HRMCombobox();
            this.txtSoLuong = new Library.Controls.HRMInputNumberTextBox();
            this.dtpNgayCan = new Library.Controls.HRMDateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.hrmCombobox1 = new Library.Controls.HRMCombobox();
            this.hrmCombobox2 = new Library.Controls.HRMCombobox();
            this.hrmInputNumberTextBox1 = new Library.Controls.HRMInputNumberTextBox();
            this.hrmDateTimePicker1 = new Library.Controls.HRMDateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).BeginInit();
            this.gradientPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKeHoach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLyDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayCan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayCan.Calendar)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmInputNumberTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDateTimePicker1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDateTimePicker1.Calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Size = new System.Drawing.Size(920, 150);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.Size = new System.Drawing.Size(920, 257);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(920, 257);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã chi tiết";
            gridColumnDescriptor1.MappingName = "MaChiTietTD";
            gridColumnDescriptor1.Width = 118;
            gridColumnDescriptor2.HeaderText = "Chức danh";
            gridColumnDescriptor2.MappingName = "TenChucDanh";
            gridColumnDescriptor2.Width = 130;
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor3.HeaderText = "Số lượng";
            gridColumnDescriptor3.MappingName = "SoLuong";
            gridColumnDescriptor3.Width = 85;
            gridColumnDescriptor4.HeaderText = "Ngày cần";
            gridColumnDescriptor4.MappingName = "ThoiGianCanNhanSu";
            gridColumnDescriptor4.Width = 160;
            gridColumnDescriptor5.HeaderText = "Lý do";
            gridColumnDescriptor5.MappingName = "TenLyDo";
            gridColumnDescriptor5.Width = 174;
            gridColumnDescriptor6.HeaderText = "Ghi chú";
            gridColumnDescriptor6.MappingName = "GhiChu";
            gridColumnDescriptor6.Width = 194;
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
            this.tableLayoutPanel1.Controls.Add(this.gradientPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 150);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // gradientPanel1
            // 
            this.gradientPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(241)))), ((int)(((byte)(253)))));
            this.gradientPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.gradientPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gradientPanel1.Controls.Add(this.tableLayoutPanel2);
            this.gradientPanel1.Controls.Add(this.panel3);
            this.gradientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gradientPanel1.Location = new System.Drawing.Point(3, 3);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(914, 144);
            this.gradientPanel1.TabIndex = 200;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblChucDanh, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblChiTiet, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblSoLuong, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel7, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayCan, 3, 3);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel6, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtMaKeHoach, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtMaChiTiet, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtGhiChu, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.cboChucDanh, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.cboLyDo, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtSoLuong, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayCan, 4, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(912, 117);
            this.tableLayoutPanel2.TabIndex = 159;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(120, 5);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(94, 25);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Mã kế hoạch";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChucDanh
            // 
            this.lblChucDanh.AutoSize = true;
            this.lblChucDanh.BackColor = System.Drawing.Color.Transparent;
            this.lblChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChucDanh.IsRequired = true;
            this.lblChucDanh.Location = new System.Drawing.Point(120, 30);
            this.lblChucDanh.Name = "lblChucDanh";
            this.lblChucDanh.Size = new System.Drawing.Size(94, 25);
            this.lblChucDanh.TabIndex = 1;
            this.lblChucDanh.Text = "Chức danh";
            this.lblChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChiTiet
            // 
            this.lblChiTiet.AutoSize = true;
            this.lblChiTiet.BackColor = System.Drawing.Color.Transparent;
            this.lblChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChiTiet.IsRequired = true;
            this.lblChiTiet.Location = new System.Drawing.Point(416, 5);
            this.lblChiTiet.Name = "lblChiTiet";
            this.lblChiTiet.Size = new System.Drawing.Size(84, 25);
            this.lblChiTiet.TabIndex = 2;
            this.lblChiTiet.Text = "Mã chi tiết";
            this.lblChiTiet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLuong.IsRequired = true;
            this.lblSoLuong.Location = new System.Drawing.Point(416, 30);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(84, 25);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Số lượng";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel7
            // 
            this.hrmLabel7.AutoSize = true;
            this.hrmLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel7.IsRequired = false;
            this.hrmLabel7.Location = new System.Drawing.Point(120, 80);
            this.hrmLabel7.Name = "hrmLabel7";
            this.hrmLabel7.Size = new System.Drawing.Size(94, 25);
            this.hrmLabel7.TabIndex = 6;
            this.hrmLabel7.Text = "Ghi chú";
            this.hrmLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNgayCan
            // 
            this.lblNgayCan.AutoSize = true;
            this.lblNgayCan.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayCan.IsRequired = true;
            this.lblNgayCan.Location = new System.Drawing.Point(416, 55);
            this.lblNgayCan.Name = "lblNgayCan";
            this.lblNgayCan.Size = new System.Drawing.Size(84, 25);
            this.lblNgayCan.TabIndex = 4;
            this.lblNgayCan.Text = "Ngày cần";
            this.lblNgayCan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel6
            // 
            this.hrmLabel6.AutoSize = true;
            this.hrmLabel6.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel6.IsRequired = false;
            this.hrmLabel6.Location = new System.Drawing.Point(120, 55);
            this.hrmLabel6.Name = "hrmLabel6";
            this.hrmLabel6.Size = new System.Drawing.Size(94, 25);
            this.hrmLabel6.TabIndex = 5;
            this.hrmLabel6.Text = "Lý do";
            this.hrmLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaKeHoach
            // 
            this.txtMaKeHoach.BeforeTouchSize = new System.Drawing.Size(289, 23);
            this.txtMaKeHoach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKeHoach.Location = new System.Drawing.Point(218, 6);
            this.txtMaKeHoach.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaKeHoach.Name = "txtMaKeHoach";
            this.txtMaKeHoach.ReadOnly = true;
            this.txtMaKeHoach.Size = new System.Drawing.Size(194, 23);
            this.txtMaKeHoach.TabIndex = 7;
            // 
            // txtMaChiTiet
            // 
            this.txtMaChiTiet.BeforeTouchSize = new System.Drawing.Size(289, 23);
            this.txtMaChiTiet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaChiTiet.Location = new System.Drawing.Point(504, 6);
            this.txtMaChiTiet.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaChiTiet.Name = "txtMaChiTiet";
            this.txtMaChiTiet.Size = new System.Drawing.Size(289, 23);
            this.txtMaChiTiet.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(289, 23);
            this.tableLayoutPanel2.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(218, 81);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(575, 23);
            this.txtGhiChu.TabIndex = 5;
            // 
            // cboChucDanh
            // 
            this.cboChucDanh.BeforeTouchSize = new System.Drawing.Size(194, 22);
            this.cboChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboChucDanh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboChucDanh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboChucDanh.Location = new System.Drawing.Point(218, 31);
            this.cboChucDanh.Margin = new System.Windows.Forms.Padding(1);
            this.cboChucDanh.Name = "cboChucDanh";
            this.cboChucDanh.Size = new System.Drawing.Size(194, 22);
            this.cboChucDanh.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboChucDanh.TabIndex = 1;
            this.cboChucDanh.ThemeName = "Office2007Outlook";
            // 
            // cboLyDo
            // 
            this.cboLyDo.BeforeTouchSize = new System.Drawing.Size(194, 22);
            this.cboLyDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboLyDo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLyDo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboLyDo.Location = new System.Drawing.Point(218, 56);
            this.cboLyDo.Margin = new System.Windows.Forms.Padding(1);
            this.cboLyDo.Name = "cboLyDo";
            this.cboLyDo.Size = new System.Drawing.Size(194, 22);
            this.cboLyDo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboLyDo.TabIndex = 3;
            this.cboLyDo.ThemeName = "Office2007Outlook";
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.BeforeTouchSize = new System.Drawing.Size(289, 23);
            this.txtSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoLuong.Location = new System.Drawing.Point(504, 31);
            this.txtSoLuong.Margin = new System.Windows.Forms.Padding(1);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(289, 23);
            this.txtSoLuong.TabIndex = 2;
            this.txtSoLuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dtpNgayCan
            // 
            this.dtpNgayCan.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayCan.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayCan.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayCan.Calendar.AllowMultipleSelection = false;
            this.dtpNgayCan.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dtpNgayCan.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgayCan.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayCan.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayCan.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayCan.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayCan.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayCan.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayCan.Calendar.HeaderHeight = 20;
            this.dtpNgayCan.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayCan.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayCan.Calendar.HeadGradient = true;
            this.dtpNgayCan.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.dtpNgayCan.Calendar.Iso8601CalenderFormat = false;
            this.dtpNgayCan.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayCan.Calendar.Name = "monthCalendar";
            this.dtpNgayCan.Calendar.ScrollButtonSize = new System.Drawing.Size(24, 24);
            this.dtpNgayCan.Calendar.Size = new System.Drawing.Size(198, 174);
            this.dtpNgayCan.Calendar.SizeToFit = true;
            this.dtpNgayCan.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayCan.Calendar.TabIndex = 0;
            this.dtpNgayCan.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayCan.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayCan.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayCan.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayCan.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayCan.Calendar.NoneButton.Location = new System.Drawing.Point(126, 0);
            this.dtpNgayCan.Calendar.NoneButton.Size = new System.Drawing.Size(72, 20);
            this.dtpNgayCan.Calendar.NoneButton.Text = "None";
            this.dtpNgayCan.Calendar.NoneButton.ThemeName = "Office2007";
            this.dtpNgayCan.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayCan.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayCan.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayCan.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayCan.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayCan.Calendar.TodayButton.Size = new System.Drawing.Size(126, 20);
            this.dtpNgayCan.Calendar.TodayButton.Text = "Today";
            this.dtpNgayCan.Calendar.TodayButton.ThemeName = "Office2007";
            this.dtpNgayCan.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayCan.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayCan.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpNgayCan.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayCan.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayCan.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayCan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayCan.DropDownImage = null;
            this.dtpNgayCan.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpNgayCan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayCan.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayCan.Location = new System.Drawing.Point(504, 56);
            this.dtpNgayCan.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayCan.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpNgayCan.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayCan.Name = "dtpNgayCan";
            this.dtpNgayCan.NullString = "Chưa chọn";
            this.dtpNgayCan.ShowCheckBox = false;
            this.dtpNgayCan.Size = new System.Drawing.Size(289, 23);
            this.dtpNgayCan.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayCan.TabIndex = 4;
            this.dtpNgayCan.ThemesEnabled = true;
            this.dtpNgayCan.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(912, 25);
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
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(912, 25);
            this.label2.TabIndex = 170;
            this.label2.Text = "Chi tiết";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmCombobox1
            // 
            this.hrmCombobox1.BackColor = System.Drawing.SystemColors.Control;
            this.hrmCombobox1.BeforeTouchSize = new System.Drawing.Size(121, 21);
            this.hrmCombobox1.Location = new System.Drawing.Point(0, 0);
            this.hrmCombobox1.Name = "hrmCombobox1";
            this.hrmCombobox1.Size = new System.Drawing.Size(121, 21);
            this.hrmCombobox1.TabIndex = 0;
            // 
            // hrmCombobox2
            // 
            this.hrmCombobox2.BeforeTouchSize = new System.Drawing.Size(194, 21);
            this.hrmCombobox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmCombobox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hrmCombobox2.Location = new System.Drawing.Point(287, 56);
            this.hrmCombobox2.Margin = new System.Windows.Forms.Padding(1);
            this.hrmCombobox2.Name = "hrmCombobox2";
            this.hrmCombobox2.Size = new System.Drawing.Size(194, 21);
            this.hrmCombobox2.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.hrmCombobox2.TabIndex = 11;
            this.hrmCombobox2.ThemeName = "Office2007Outlook";
            // 
            // hrmInputNumberTextBox1
            // 
            this.hrmInputNumberTextBox1.BeforeTouchSize = new System.Drawing.Size(289, 23);
            this.hrmInputNumberTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmInputNumberTextBox1.Location = new System.Drawing.Point(573, 31);
            this.hrmInputNumberTextBox1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmInputNumberTextBox1.Name = "hrmInputNumberTextBox1";
            this.hrmInputNumberTextBox1.Size = new System.Drawing.Size(289, 20);
            this.hrmInputNumberTextBox1.TabIndex = 12;
            // 
            // hrmDateTimePicker1
            // 
            this.hrmDateTimePicker1.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.hrmDateTimePicker1.BorderColor = System.Drawing.Color.Empty;
            this.hrmDateTimePicker1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.hrmDateTimePicker1.Calendar.AllowMultipleSelection = false;
            this.hrmDateTimePicker1.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.hrmDateTimePicker1.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.hrmDateTimePicker1.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmDateTimePicker1.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hrmDateTimePicker1.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.hrmDateTimePicker1.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.hrmDateTimePicker1.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hrmDateTimePicker1.Calendar.HeaderHeight = 20;
            this.hrmDateTimePicker1.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.hrmDateTimePicker1.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.HeadGradient = true;
            this.hrmDateTimePicker1.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.hrmDateTimePicker1.Calendar.Iso8601CalenderFormat = false;
            this.hrmDateTimePicker1.Calendar.Location = new System.Drawing.Point(0, 0);
            this.hrmDateTimePicker1.Calendar.Name = "monthCalendar";
            this.hrmDateTimePicker1.Calendar.ScrollButtonSize = new System.Drawing.Size(24, 24);
            this.hrmDateTimePicker1.Calendar.Size = new System.Drawing.Size(200, 174);
            this.hrmDateTimePicker1.Calendar.SizeToFit = true;
            this.hrmDateTimePicker1.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.hrmDateTimePicker1.Calendar.TabIndex = 0;
            this.hrmDateTimePicker1.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.hrmDateTimePicker1.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.hrmDateTimePicker1.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.hrmDateTimePicker1.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.hrmDateTimePicker1.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.NoneButton.Location = new System.Drawing.Point(128, 0);
            this.hrmDateTimePicker1.Calendar.NoneButton.Size = new System.Drawing.Size(72, 20);
            this.hrmDateTimePicker1.Calendar.NoneButton.Text = "None";
            this.hrmDateTimePicker1.Calendar.NoneButton.ThemeName = "Office2007";
            this.hrmDateTimePicker1.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.hrmDateTimePicker1.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.hrmDateTimePicker1.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.hrmDateTimePicker1.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.hrmDateTimePicker1.Calendar.TodayButton.Size = new System.Drawing.Size(128, 20);
            this.hrmDateTimePicker1.Calendar.TodayButton.Text = "Today";
            this.hrmDateTimePicker1.Calendar.TodayButton.ThemeName = "Office2007";
            this.hrmDateTimePicker1.Calendar.TodayButton.UseVisualStyle = true;
            this.hrmDateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hrmDateTimePicker1.CalendarSize = new System.Drawing.Size(189, 176);
            this.hrmDateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.hrmDateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.hrmDateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmDateTimePicker1.DropDownImage = null;
            this.hrmDateTimePicker1.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.hrmDateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hrmDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hrmDateTimePicker1.Location = new System.Drawing.Point(573, 56);
            this.hrmDateTimePicker1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmDateTimePicker1.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.hrmDateTimePicker1.MinValue = new System.DateTime(((long)(0)));
            this.hrmDateTimePicker1.Name = "hrmDateTimePicker1";
            this.hrmDateTimePicker1.NullString = "Chưa chọn";
            this.hrmDateTimePicker1.ShowCheckBox = false;
            this.hrmDateTimePicker1.Size = new System.Drawing.Size(289, 23);
            this.hrmDateTimePicker1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.hrmDateTimePicker1.TabIndex = 13;
            this.hrmDateTimePicker1.ThemesEnabled = true;
            this.hrmDateTimePicker1.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // SF101
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 441);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF101";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CHI TIẾT KẾ HOẠCH TUYỂN DỤNG";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaKeHoach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLyDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoLuong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayCan.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayCan)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmInputNumberTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDateTimePicker1.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDateTimePicker1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
   
 
   
 
        private Library.Controls.HRMCombobox hrmCombobox1;
        private Library.Controls.HRMCombobox hrmCombobox2;
        private Library.Controls.HRMInputNumberTextBox hrmInputNumberTextBox1;
        private Library.Controls.HRMDateTimePicker hrmDateTimePicker1;
        private Syncfusion.Windows.Forms.Tools.GradientPanel gradientPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Library.Controls.HRMLabel hrmLabel1;
        private Library.Controls.HRMLabel lblChucDanh;
        private Library.Controls.HRMLabel lblChiTiet;
        private Library.Controls.HRMLabel lblSoLuong;
        private Library.Controls.HRMLabel hrmLabel7;
        private Library.Controls.HRMLabel lblNgayCan;
        private Library.Controls.HRMLabel hrmLabel6;
        private Library.Controls.HRMTextBox txtMaKeHoach;
        private Library.Controls.HRMTextBox txtMaChiTiet;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMCombobox cboChucDanh;
        private Library.Controls.HRMCombobox cboLyDo;
        private Library.Controls.HRMInputNumberTextBox txtSoLuong;
        private Library.Controls.HRMDateTimePicker dtpNgayCan;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
    }
}