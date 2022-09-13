namespace HRM.Forms.NhanVien
{
    partial class SF209
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
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor7 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF209));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.lblTenQuyetDinh = new Library.Controls.HRMLabel();
            this.hrmLabel7 = new Library.Controls.HRMLabel();
            this.txtSoQuyetDinh = new Library.Controls.HRMTextBox();
            this.txtTenQuyetDinh = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.lblNgayQuyetDinh = new Library.Controls.HRMLabel();
            this.dtpNgauQuyetDinh = new Library.Controls.HRMDateTimePicker();
            this.lblNgayHieuLuc = new Library.Controls.HRMLabel();
            this.dtpNgayHieuLuc = new Library.Controls.HRMDateTimePicker();
            this.lblSoLuong = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtNoiDung = new Library.Controls.HRMTextBox();
            this.cboTrinhDo = new Library.Controls.HRMCombobox();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtSoQuyetDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQuyetDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgauQuyetDinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayHieuLuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTrinhDo)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmInputNumberTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmDateTimePicker1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Size = new System.Drawing.Size(920, 145);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Size = new System.Drawing.Size(920, 262);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(920, 262);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            this.GrdData.TableDescriptor.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor1.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor1.HeaderText = "Số quyết định";
            gridColumnDescriptor1.MappingName = "SoQuyetDinh";
            gridColumnDescriptor1.Width = 114;
            gridColumnDescriptor2.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor2.HeaderText = "Tên quyết định";
            gridColumnDescriptor2.MappingName = "TenQuyetDinh";
            gridColumnDescriptor2.Width = 112;
            gridColumnDescriptor3.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor3.HeaderText = "Ngày quyết định";
            gridColumnDescriptor3.MappingName = "NgayQuyetDinh";
            gridColumnDescriptor3.Width = 114;
            gridColumnDescriptor4.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor4.HeaderText = "Ngày hiệu lực";
            gridColumnDescriptor4.MappingName = "NgayHieuLuc";
            gridColumnDescriptor4.Width = 105;
            gridColumnDescriptor5.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor5.HeaderText = "Nội dung";
            gridColumnDescriptor5.MappingName = "NoiDung";
            gridColumnDescriptor5.Width = 255;
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor6.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor6.HeaderText = "Trình độ";
            gridColumnDescriptor6.MappingName = "TenTrinhDo";
            gridColumnDescriptor6.Width = 93;
            gridColumnDescriptor7.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor7.HeaderText = "Ghi chú";
            gridColumnDescriptor7.MappingName = "GhiChu";
            gridColumnDescriptor7.Width = 314;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3,
            gridColumnDescriptor4,
            gridColumnDescriptor5,
            gridColumnDescriptor6,
            gridColumnDescriptor7});
            this.GrdData.TableDescriptor.ForceEmptyRelations = true;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(920, 145);
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
            this.gradientPanel1.Size = new System.Drawing.Size(914, 139);
            this.gradientPanel1.TabIndex = 200;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 117F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 176F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 162F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTenQuyetDinh, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel7, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtSoQuyetDinh, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTenQuyetDinh, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtGhiChu, 2, 4);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayQuyetDinh, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgauQuyetDinh, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayHieuLuc, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayHieuLuc, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblSoLuong, 5, 2);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel3, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtNoiDung, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.cboTrinhDo, 6, 2);
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(912, 112);
            this.tableLayoutPanel2.TabIndex = 159;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = true;
            this.hrmLabel1.Location = new System.Drawing.Point(83, 5);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(111, 25);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Số quyết định";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenQuyetDinh
            // 
            this.lblTenQuyetDinh.AutoSize = true;
            this.lblTenQuyetDinh.BackColor = System.Drawing.Color.Transparent;
            this.lblTenQuyetDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenQuyetDinh.IsRequired = true;
            this.lblTenQuyetDinh.Location = new System.Drawing.Point(376, 5);
            this.lblTenQuyetDinh.Name = "lblTenQuyetDinh";
            this.lblTenQuyetDinh.Size = new System.Drawing.Size(104, 25);
            this.lblTenQuyetDinh.TabIndex = 2;
            this.lblTenQuyetDinh.Text = "Tên quyết định";
            this.lblTenQuyetDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel7
            // 
            this.hrmLabel7.AutoSize = true;
            this.hrmLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel7.IsRequired = false;
            this.hrmLabel7.Location = new System.Drawing.Point(83, 80);
            this.hrmLabel7.Name = "hrmLabel7";
            this.hrmLabel7.Size = new System.Drawing.Size(111, 25);
            this.hrmLabel7.TabIndex = 6;
            this.hrmLabel7.Text = "Ghi chú";
            this.hrmLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoQuyetDinh
            // 
            this.txtSoQuyetDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoQuyetDinh.Location = new System.Drawing.Point(198, 6);
            this.txtSoQuyetDinh.Margin = new System.Windows.Forms.Padding(1);
            this.txtSoQuyetDinh.Name = "txtSoQuyetDinh";
            this.txtSoQuyetDinh.ReadOnly = true;
            this.txtSoQuyetDinh.Size = new System.Drawing.Size(174, 23);
            this.txtSoQuyetDinh.TabIndex = 7;
            // 
            // txtTenQuyetDinh
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtTenQuyetDinh, 3);
            this.txtTenQuyetDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenQuyetDinh.Location = new System.Drawing.Point(484, 6);
            this.txtTenQuyetDinh.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenQuyetDinh.Name = "txtTenQuyetDinh";
            this.txtTenQuyetDinh.Size = new System.Drawing.Size(346, 23);
            this.txtTenQuyetDinh.TabIndex = 0;
            // 
            // txtGhiChu
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtGhiChu, 5);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(198, 81);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(632, 23);
            this.txtGhiChu.TabIndex = 5;
            // 
            // lblNgayQuyetDinh
            // 
            this.lblNgayQuyetDinh.AutoSize = true;
            this.lblNgayQuyetDinh.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayQuyetDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayQuyetDinh.IsRequired = false;
            this.lblNgayQuyetDinh.Location = new System.Drawing.Point(83, 30);
            this.lblNgayQuyetDinh.Name = "lblNgayQuyetDinh";
            this.lblNgayQuyetDinh.Size = new System.Drawing.Size(111, 25);
            this.lblNgayQuyetDinh.TabIndex = 4;
            this.lblNgayQuyetDinh.Text = "Ngày quyết định";
            this.lblNgayQuyetDinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgauQuyetDinh
            // 
            this.dtpNgauQuyetDinh.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgauQuyetDinh.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgauQuyetDinh.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgauQuyetDinh.Calendar.AllowMultipleSelection = false;
            this.dtpNgauQuyetDinh.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgauQuyetDinh.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgauQuyetDinh.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgauQuyetDinh.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgauQuyetDinh.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgauQuyetDinh.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgauQuyetDinh.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgauQuyetDinh.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgauQuyetDinh.Calendar.HeaderHeight = 20;
            this.dtpNgauQuyetDinh.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgauQuyetDinh.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgauQuyetDinh.Calendar.HeadGradient = true;
            this.dtpNgauQuyetDinh.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgauQuyetDinh.Calendar.Name = "monthCalendar";
            this.dtpNgauQuyetDinh.Calendar.ScrollButtonSize = new System.Drawing.Size(24, 24);
            this.dtpNgauQuyetDinh.Calendar.SelectedDates = new System.DateTime[0];
            this.dtpNgauQuyetDinh.Calendar.Size = new System.Drawing.Size(206, 174);
            this.dtpNgauQuyetDinh.Calendar.SizeToFit = true;
            this.dtpNgauQuyetDinh.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgauQuyetDinh.Calendar.TabIndex = 0;
            this.dtpNgauQuyetDinh.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgauQuyetDinh.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgauQuyetDinh.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgauQuyetDinh.Calendar.NoneButton.Location = new System.Drawing.Point(134, 0);
            this.dtpNgauQuyetDinh.Calendar.NoneButton.Size = new System.Drawing.Size(72, 20);
            this.dtpNgauQuyetDinh.Calendar.NoneButton.Text = "None";
            this.dtpNgauQuyetDinh.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgauQuyetDinh.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgauQuyetDinh.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgauQuyetDinh.Calendar.TodayButton.Size = new System.Drawing.Size(134, 20);
            this.dtpNgauQuyetDinh.Calendar.TodayButton.Text = "Today";
            this.dtpNgauQuyetDinh.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgauQuyetDinh.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgauQuyetDinh.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgauQuyetDinh.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgauQuyetDinh.CustomFormat = "dd/MM/yyyy";
            this.dtpNgauQuyetDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgauQuyetDinh.DropDownImage = null;
            this.dtpNgauQuyetDinh.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgauQuyetDinh.Location = new System.Drawing.Point(198, 31);
            this.dtpNgauQuyetDinh.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgauQuyetDinh.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgauQuyetDinh.Name = "dtpNgauQuyetDinh";
            this.dtpNgauQuyetDinh.NullString = "Chưa chọn";
            this.dtpNgauQuyetDinh.ShowCheckBox = false;
            this.dtpNgauQuyetDinh.Size = new System.Drawing.Size(174, 23);
            this.dtpNgauQuyetDinh.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgauQuyetDinh.TabIndex = 1;
            this.dtpNgauQuyetDinh.ThemesEnabled = true;
            this.dtpNgauQuyetDinh.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // lblNgayHieuLuc
            // 
            this.lblNgayHieuLuc.AutoSize = true;
            this.lblNgayHieuLuc.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayHieuLuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayHieuLuc.IsRequired = true;
            this.lblNgayHieuLuc.Location = new System.Drawing.Point(376, 30);
            this.lblNgayHieuLuc.Name = "lblNgayHieuLuc";
            this.lblNgayHieuLuc.Size = new System.Drawing.Size(104, 25);
            this.lblNgayHieuLuc.TabIndex = 8;
            this.lblNgayHieuLuc.Text = "Ngày hiệu lực";
            this.lblNgayHieuLuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayHieuLuc
            // 
            this.dtpNgayHieuLuc.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayHieuLuc.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayHieuLuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayHieuLuc.Calendar.AllowMultipleSelection = false;
            this.dtpNgayHieuLuc.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgayHieuLuc.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayHieuLuc.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayHieuLuc.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHieuLuc.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayHieuLuc.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayHieuLuc.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayHieuLuc.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayHieuLuc.Calendar.HeaderHeight = 20;
            this.dtpNgayHieuLuc.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayHieuLuc.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayHieuLuc.Calendar.HeadGradient = true;
            this.dtpNgayHieuLuc.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayHieuLuc.Calendar.Name = "monthCalendar";
            this.dtpNgayHieuLuc.Calendar.ScrollButtonSize = new System.Drawing.Size(24, 24);
            this.dtpNgayHieuLuc.Calendar.SelectedDates = new System.DateTime[0];
            this.dtpNgayHieuLuc.Calendar.Size = new System.Drawing.Size(206, 174);
            this.dtpNgayHieuLuc.Calendar.SizeToFit = true;
            this.dtpNgayHieuLuc.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayHieuLuc.Calendar.TabIndex = 0;
            this.dtpNgayHieuLuc.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayHieuLuc.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayHieuLuc.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayHieuLuc.Calendar.NoneButton.Location = new System.Drawing.Point(134, 0);
            this.dtpNgayHieuLuc.Calendar.NoneButton.Size = new System.Drawing.Size(72, 20);
            this.dtpNgayHieuLuc.Calendar.NoneButton.Text = "None";
            this.dtpNgayHieuLuc.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayHieuLuc.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayHieuLuc.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayHieuLuc.Calendar.TodayButton.Size = new System.Drawing.Size(134, 20);
            this.dtpNgayHieuLuc.Calendar.TodayButton.Text = "Today";
            this.dtpNgayHieuLuc.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayHieuLuc.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayHieuLuc.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayHieuLuc.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayHieuLuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayHieuLuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayHieuLuc.DropDownImage = null;
            this.dtpNgayHieuLuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayHieuLuc.Location = new System.Drawing.Point(484, 31);
            this.dtpNgayHieuLuc.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayHieuLuc.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayHieuLuc.Name = "dtpNgayHieuLuc";
            this.dtpNgayHieuLuc.NullString = "Chưa chọn";
            this.dtpNgayHieuLuc.ShowCheckBox = false;
            this.dtpNgayHieuLuc.Size = new System.Drawing.Size(110, 23);
            this.dtpNgayHieuLuc.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayHieuLuc.TabIndex = 2;
            this.dtpNgayHieuLuc.ThemesEnabled = true;
            this.dtpNgayHieuLuc.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.BackColor = System.Drawing.Color.Transparent;
            this.lblSoLuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSoLuong.IsRequired = true;
            this.lblSoLuong.Location = new System.Drawing.Point(598, 30);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(68, 25);
            this.lblSoLuong.TabIndex = 3;
            this.lblSoLuong.Text = "Trình độ";
            this.lblSoLuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(83, 55);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(111, 25);
            this.hrmLabel3.TabIndex = 10;
            this.hrmLabel3.Text = "Nội dung";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNoiDung
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtNoiDung, 5);
            this.txtNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNoiDung.Location = new System.Drawing.Point(198, 56);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(1);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.Size = new System.Drawing.Size(632, 23);
            this.txtNoiDung.TabIndex = 4;
            // 
            // cboTrinhDo
            // 
            this.cboTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTrinhDo.Location = new System.Drawing.Point(670, 31);
            this.cboTrinhDo.Margin = new System.Windows.Forms.Padding(1);
            this.cboTrinhDo.Name = "cboTrinhDo";
            this.cboTrinhDo.Size = new System.Drawing.Size(160, 24);
            this.cboTrinhDo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboTrinhDo.TabIndex = 11;
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
            this.hrmCombobox1.Location = new System.Drawing.Point(0, 0);
            this.hrmCombobox1.Name = "hrmCombobox1";
            this.hrmCombobox1.Size = new System.Drawing.Size(121, 21);
            this.hrmCombobox1.TabIndex = 0;
            // 
            // hrmCombobox2
            // 
            this.hrmCombobox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmCombobox2.Location = new System.Drawing.Point(287, 56);
            this.hrmCombobox2.Margin = new System.Windows.Forms.Padding(1);
            this.hrmCombobox2.Name = "hrmCombobox2";
            this.hrmCombobox2.Size = new System.Drawing.Size(194, 21);
            this.hrmCombobox2.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.hrmCombobox2.TabIndex = 11;
            // 
            // hrmInputNumberTextBox1
            // 
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
            this.hrmDateTimePicker1.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.hrmDateTimePicker1.Calendar.DaysFont = new System.Drawing.Font("Verdana", 8F);
            this.hrmDateTimePicker1.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmDateTimePicker1.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hrmDateTimePicker1.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.hrmDateTimePicker1.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.hrmDateTimePicker1.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.hrmDateTimePicker1.Calendar.HeaderHeight = 20;
            this.hrmDateTimePicker1.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.hrmDateTimePicker1.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.HeadGradient = true;
            this.hrmDateTimePicker1.Calendar.Location = new System.Drawing.Point(0, 0);
            this.hrmDateTimePicker1.Calendar.Name = "monthCalendar";
            this.hrmDateTimePicker1.Calendar.ScrollButtonSize = new System.Drawing.Size(24, 24);
            this.hrmDateTimePicker1.Calendar.SelectedDates = new System.DateTime[0];
            this.hrmDateTimePicker1.Calendar.Size = new System.Drawing.Size(206, 174);
            this.hrmDateTimePicker1.Calendar.SizeToFit = true;
            this.hrmDateTimePicker1.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.hrmDateTimePicker1.Calendar.TabIndex = 0;
            this.hrmDateTimePicker1.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.hrmDateTimePicker1.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.hrmDateTimePicker1.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.hrmDateTimePicker1.Calendar.NoneButton.Location = new System.Drawing.Point(134, 0);
            this.hrmDateTimePicker1.Calendar.NoneButton.Size = new System.Drawing.Size(72, 20);
            this.hrmDateTimePicker1.Calendar.NoneButton.Text = "None";
            this.hrmDateTimePicker1.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.hrmDateTimePicker1.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.hrmDateTimePicker1.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.hrmDateTimePicker1.Calendar.TodayButton.Size = new System.Drawing.Size(134, 20);
            this.hrmDateTimePicker1.Calendar.TodayButton.Text = "Today";
            this.hrmDateTimePicker1.Calendar.TodayButton.UseVisualStyle = true;
            this.hrmDateTimePicker1.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hrmDateTimePicker1.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.hrmDateTimePicker1.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.CustomFormat = "dd/MM/yyyy";
            this.hrmDateTimePicker1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmDateTimePicker1.DropDownImage = null;
            this.hrmDateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.hrmDateTimePicker1.Location = new System.Drawing.Point(573, 56);
            this.hrmDateTimePicker1.Margin = new System.Windows.Forms.Padding(1);
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
            // SF209
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 441);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF209";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "QUYẾT ĐỊNH NÂNG GIẢM HỆ SỐ CHUYÊN MÔN";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gradientPanel1)).EndInit();
            this.gradientPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoQuyetDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenQuyetDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgauQuyetDinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayHieuLuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTrinhDo)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmCombobox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmInputNumberTextBox1)).EndInit();
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
        private Library.Controls.HRMLabel lblTenQuyetDinh;
        private Library.Controls.HRMTextBox txtSoQuyetDinh;
        private Library.Controls.HRMTextBox txtTenQuyetDinh;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMDateTimePicker dtpNgayHieuLuc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Library.Controls.HRMLabel hrmLabel7;
        private Library.Controls.HRMLabel lblNgayQuyetDinh;
        private Library.Controls.HRMLabel lblNgayHieuLuc;
        private Library.Controls.HRMDateTimePicker dtpNgauQuyetDinh;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMTextBox txtNoiDung;
        private Library.Controls.HRMLabel lblSoLuong;
        private Library.Controls.HRMCombobox cboTrinhDo;
    }
}