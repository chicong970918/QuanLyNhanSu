namespace HRM.Forms.NhanVien
{
    partial class SF215
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF215));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.hrmLabel7 = new Library.Controls.HRMLabel();
            this.txtSoQuyetDinh = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.lblTuNgay = new Library.Controls.HRMLabel();
            this.dtpNgayBatDau = new Library.Controls.HRMDateTimePicker();
            this.lblDenNgay = new Library.Controls.HRMLabel();
            this.dtpNgayKetThuc = new Library.Controls.HRMDateTimePicker();
            this.lblNgayKy = new Library.Controls.HRMLabel();
            this.dtpNgayKy = new Library.Controls.HRMDateTimePicker();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBatDau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBatDau.Calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKetThuc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKetThuc.Calendar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKy.Calendar)).BeginInit();
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
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1148, 145);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 179);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1148, 372);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1148, 372);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            this.GrdData.TableDescriptor.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor1.HeaderText = "Số hợp đồng";
            gridColumnDescriptor1.MappingName = "SoHopDong";
            gridColumnDescriptor1.Width = 96;
            gridColumnDescriptor2.HeaderText = "Ngày ký";
            gridColumnDescriptor2.MappingName = "NgayKy";
            gridColumnDescriptor2.Width = 113;
            gridColumnDescriptor3.HeaderText = "Ngày bắt đầu";
            gridColumnDescriptor3.MappingName = "NgayBatDau";
            gridColumnDescriptor3.Width = 108;
            gridColumnDescriptor4.HeaderText = "Ngày kết thúc";
            gridColumnDescriptor4.MappingName = "NgayKetThuc";
            gridColumnDescriptor4.Width = 103;
            gridColumnDescriptor5.HeaderText = "Ghi chú";
            gridColumnDescriptor5.MappingName = "GhiChu";
            gridColumnDescriptor5.Width = 313;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3,
            gridColumnDescriptor4,
            gridColumnDescriptor5});
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.GrdData.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableDescriptor.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("SoHopDong"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NgayKy"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NgayBatDau"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("NgayKetThuc"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("GhiChu")});
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
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1148, 145);
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
            this.gradientPanel1.Location = new System.Drawing.Point(4, 4);
            this.gradientPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.gradientPanel1.Name = "gradientPanel1";
            this.gradientPanel1.Size = new System.Drawing.Size(1140, 173);
            this.gradientPanel1.TabIndex = 200;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel7, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtSoQuyetDinh, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtGhiChu, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTuNgay, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayBatDau, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblDenNgay, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayKetThuc, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblNgayKy, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.dtpNgayKy, 4, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 31);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1138, 140);
            this.tableLayoutPanel2.TabIndex = 159;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = true;
            this.hrmLabel1.Location = new System.Drawing.Point(209, 6);
            this.hrmLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(142, 31);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Số hợp đồng";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel7
            // 
            this.hrmLabel7.AutoSize = true;
            this.hrmLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel7.IsRequired = false;
            this.hrmLabel7.Location = new System.Drawing.Point(209, 68);
            this.hrmLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrmLabel7.Name = "hrmLabel7";
            this.hrmLabel7.Size = new System.Drawing.Size(142, 31);
            this.hrmLabel7.TabIndex = 6;
            this.hrmLabel7.Text = "Ghi chú";
            this.hrmLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoQuyetDinh
            // 
            this.txtSoQuyetDinh.BeforeTouchSize = new System.Drawing.Size(492, 26);
            this.txtSoQuyetDinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoQuyetDinh.Location = new System.Drawing.Point(356, 7);
            this.txtSoQuyetDinh.Margin = new System.Windows.Forms.Padding(1);
            this.txtSoQuyetDinh.Name = "txtSoQuyetDinh";
            this.txtSoQuyetDinh.ReadOnly = true;
            this.txtSoQuyetDinh.Size = new System.Drawing.Size(214, 26);
            this.txtSoQuyetDinh.TabIndex = 7;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(492, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(356, 69);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(576, 26);
            this.txtGhiChu.TabIndex = 3;
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.AutoSize = true;
            this.lblTuNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblTuNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTuNgay.IsRequired = true;
            this.lblTuNgay.Location = new System.Drawing.Point(209, 37);
            this.lblTuNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(142, 31);
            this.lblTuNgay.TabIndex = 4;
            this.lblTuNgay.Text = "Ngày bắt đầu";
            this.lblTuNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayBatDau
            // 
            this.dtpNgayBatDau.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayBatDau.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayBatDau.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayBatDau.Calendar.AllowMultipleSelection = false;
            this.dtpNgayBatDau.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dtpNgayBatDau.Calendar.BottomHeight = 27;
            this.dtpNgayBatDau.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgayBatDau.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayBatDau.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayBatDau.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayBatDau.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayBatDau.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayBatDau.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayBatDau.Calendar.HeaderHeight = 25;
            this.dtpNgayBatDau.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayBatDau.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayBatDau.Calendar.HeadGradient = true;
            this.dtpNgayBatDau.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.dtpNgayBatDau.Calendar.Iso8601CalenderFormat = false;
            this.dtpNgayBatDau.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayBatDau.Calendar.Name = "monthCalendar";
            this.dtpNgayBatDau.Calendar.ScrollButtonSize = new System.Drawing.Size(30, 30);
            this.dtpNgayBatDau.Calendar.Size = new System.Drawing.Size(198, 174);
            this.dtpNgayBatDau.Calendar.SizeToFit = true;
            this.dtpNgayBatDau.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayBatDau.Calendar.TabIndex = 0;
            this.dtpNgayBatDau.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayBatDau.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayBatDau.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayBatDau.Calendar.NoneButton.AutoSize = true;
            this.dtpNgayBatDau.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayBatDau.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayBatDau.Calendar.NoneButton.Location = new System.Drawing.Point(158, 0);
            this.dtpNgayBatDau.Calendar.NoneButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayBatDau.Calendar.NoneButton.Size = new System.Drawing.Size(90, 34);
            this.dtpNgayBatDau.Calendar.NoneButton.Text = "None";
            this.dtpNgayBatDau.Calendar.NoneButton.ThemeName = "Office2007";
            this.dtpNgayBatDau.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayBatDau.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayBatDau.Calendar.TodayButton.AutoSize = true;
            this.dtpNgayBatDau.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayBatDau.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayBatDau.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayBatDau.Calendar.TodayButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayBatDau.Calendar.TodayButton.Size = new System.Drawing.Size(158, 34);
            this.dtpNgayBatDau.Calendar.TodayButton.Text = "Today";
            this.dtpNgayBatDau.Calendar.TodayButton.ThemeName = "Office2007";
            this.dtpNgayBatDau.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayBatDau.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayBatDau.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpNgayBatDau.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayBatDau.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayBatDau.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayBatDau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayBatDau.DropDownImage = null;
            this.dtpNgayBatDau.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpNgayBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayBatDau.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayBatDau.Location = new System.Drawing.Point(356, 38);
            this.dtpNgayBatDau.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayBatDau.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpNgayBatDau.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayBatDau.Name = "dtpNgayBatDau";
            this.dtpNgayBatDau.NullString = "Chưa chọn";
            this.dtpNgayBatDau.ShowCheckBox = false;
            this.dtpNgayBatDau.Size = new System.Drawing.Size(214, 29);
            this.dtpNgayBatDau.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayBatDau.TabIndex = 1;
            this.dtpNgayBatDau.ThemesEnabled = true;
            this.dtpNgayBatDau.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.AutoSize = true;
            this.lblDenNgay.BackColor = System.Drawing.Color.Transparent;
            this.lblDenNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDenNgay.IsRequired = true;
            this.lblDenNgay.Location = new System.Drawing.Point(575, 37);
            this.lblDenNgay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(136, 31);
            this.lblDenNgay.TabIndex = 8;
            this.lblDenNgay.Text = "Ngày kết thúc";
            this.lblDenNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayKetThuc
            // 
            this.dtpNgayKetThuc.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayKetThuc.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayKetThuc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayKetThuc.Calendar.AllowMultipleSelection = false;
            this.dtpNgayKetThuc.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dtpNgayKetThuc.Calendar.BottomHeight = 27;
            this.dtpNgayKetThuc.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgayKetThuc.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayKetThuc.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayKetThuc.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKetThuc.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayKetThuc.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayKetThuc.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayKetThuc.Calendar.HeaderHeight = 25;
            this.dtpNgayKetThuc.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayKetThuc.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKetThuc.Calendar.HeadGradient = true;
            this.dtpNgayKetThuc.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.dtpNgayKetThuc.Calendar.Iso8601CalenderFormat = false;
            this.dtpNgayKetThuc.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayKetThuc.Calendar.Name = "monthCalendar";
            this.dtpNgayKetThuc.Calendar.ScrollButtonSize = new System.Drawing.Size(30, 30);
            this.dtpNgayKetThuc.Calendar.Size = new System.Drawing.Size(198, 174);
            this.dtpNgayKetThuc.Calendar.SizeToFit = true;
            this.dtpNgayKetThuc.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayKetThuc.Calendar.TabIndex = 0;
            this.dtpNgayKetThuc.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayKetThuc.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayKetThuc.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayKetThuc.Calendar.NoneButton.AutoSize = true;
            this.dtpNgayKetThuc.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayKetThuc.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKetThuc.Calendar.NoneButton.Location = new System.Drawing.Point(158, 0);
            this.dtpNgayKetThuc.Calendar.NoneButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayKetThuc.Calendar.NoneButton.Size = new System.Drawing.Size(90, 34);
            this.dtpNgayKetThuc.Calendar.NoneButton.Text = "None";
            this.dtpNgayKetThuc.Calendar.NoneButton.ThemeName = "Office2007";
            this.dtpNgayKetThuc.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayKetThuc.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayKetThuc.Calendar.TodayButton.AutoSize = true;
            this.dtpNgayKetThuc.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayKetThuc.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKetThuc.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayKetThuc.Calendar.TodayButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayKetThuc.Calendar.TodayButton.Size = new System.Drawing.Size(158, 34);
            this.dtpNgayKetThuc.Calendar.TodayButton.Text = "Today";
            this.dtpNgayKetThuc.Calendar.TodayButton.ThemeName = "Office2007";
            this.dtpNgayKetThuc.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayKetThuc.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKetThuc.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpNgayKetThuc.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayKetThuc.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKetThuc.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKetThuc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayKetThuc.DropDownImage = null;
            this.dtpNgayKetThuc.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpNgayKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayKetThuc.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKetThuc.Location = new System.Drawing.Point(716, 38);
            this.dtpNgayKetThuc.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayKetThuc.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpNgayKetThuc.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayKetThuc.Name = "dtpNgayKetThuc";
            this.dtpNgayKetThuc.NullString = "Chưa chọn";
            this.dtpNgayKetThuc.ShowCheckBox = false;
            this.dtpNgayKetThuc.Size = new System.Drawing.Size(216, 29);
            this.dtpNgayKetThuc.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayKetThuc.TabIndex = 2;
            this.dtpNgayKetThuc.ThemesEnabled = true;
            this.dtpNgayKetThuc.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // lblNgayKy
            // 
            this.lblNgayKy.AutoSize = true;
            this.lblNgayKy.BackColor = System.Drawing.Color.Transparent;
            this.lblNgayKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNgayKy.IsRequired = true;
            this.lblNgayKy.Location = new System.Drawing.Point(575, 6);
            this.lblNgayKy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNgayKy.Name = "lblNgayKy";
            this.lblNgayKy.Size = new System.Drawing.Size(136, 31);
            this.lblNgayKy.TabIndex = 9;
            this.lblNgayKy.Text = "Ngày ký";
            this.lblNgayKy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayKy
            // 
            this.dtpNgayKy.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayKy.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayKy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayKy.Calendar.AllowMultipleSelection = false;
            this.dtpNgayKy.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dtpNgayKy.Calendar.BottomHeight = 27;
            this.dtpNgayKy.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgayKy.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayKy.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayKy.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKy.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayKy.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayKy.Calendar.HeaderFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.dtpNgayKy.Calendar.HeaderHeight = 25;
            this.dtpNgayKy.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayKy.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKy.Calendar.HeadGradient = true;
            this.dtpNgayKy.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.dtpNgayKy.Calendar.Iso8601CalenderFormat = false;
            this.dtpNgayKy.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayKy.Calendar.Name = "monthCalendar";
            this.dtpNgayKy.Calendar.ScrollButtonSize = new System.Drawing.Size(30, 30);
            this.dtpNgayKy.Calendar.Size = new System.Drawing.Size(198, 174);
            this.dtpNgayKy.Calendar.SizeToFit = true;
            this.dtpNgayKy.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayKy.Calendar.TabIndex = 0;
            this.dtpNgayKy.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayKy.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayKy.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayKy.Calendar.NoneButton.AutoSize = true;
            this.dtpNgayKy.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayKy.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKy.Calendar.NoneButton.Location = new System.Drawing.Point(158, 0);
            this.dtpNgayKy.Calendar.NoneButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayKy.Calendar.NoneButton.Size = new System.Drawing.Size(90, 34);
            this.dtpNgayKy.Calendar.NoneButton.Text = "None";
            this.dtpNgayKy.Calendar.NoneButton.ThemeName = "Office2007";
            this.dtpNgayKy.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayKy.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayKy.Calendar.TodayButton.AutoSize = true;
            this.dtpNgayKy.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayKy.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKy.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayKy.Calendar.TodayButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpNgayKy.Calendar.TodayButton.Size = new System.Drawing.Size(158, 34);
            this.dtpNgayKy.Calendar.TodayButton.Text = "Today";
            this.dtpNgayKy.Calendar.TodayButton.ThemeName = "Office2007";
            this.dtpNgayKy.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayKy.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayKy.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpNgayKy.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayKy.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayKy.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayKy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayKy.DropDownImage = null;
            this.dtpNgayKy.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpNgayKy.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayKy.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayKy.Location = new System.Drawing.Point(716, 7);
            this.dtpNgayKy.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayKy.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpNgayKy.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayKy.Name = "dtpNgayKy";
            this.dtpNgayKy.NullString = "Chưa chọn";
            this.dtpNgayKy.ShowCheckBox = false;
            this.dtpNgayKy.Size = new System.Drawing.Size(216, 29);
            this.dtpNgayKy.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayKy.TabIndex = 0;
            this.dtpNgayKy.ThemesEnabled = true;
            this.dtpNgayKy.Value = new System.DateTime(2011, 5, 21, 17, 2, 34, 968);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1138, 31);
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
            this.label2.Size = new System.Drawing.Size(1138, 31);
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
            this.hrmCombobox2.BeforeTouchSize = new System.Drawing.Size(194, 24);
            this.hrmCombobox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmCombobox2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.hrmCombobox2.Location = new System.Drawing.Point(287, 56);
            this.hrmCombobox2.Margin = new System.Windows.Forms.Padding(1);
            this.hrmCombobox2.Name = "hrmCombobox2";
            this.hrmCombobox2.Size = new System.Drawing.Size(194, 24);
            this.hrmCombobox2.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.hrmCombobox2.TabIndex = 11;
            this.hrmCombobox2.ThemeName = "Office2007Outlook";
            // 
            // hrmInputNumberTextBox1
            // 
            this.hrmInputNumberTextBox1.BeforeTouchSize = new System.Drawing.Size(492, 26);
            this.hrmInputNumberTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmInputNumberTextBox1.Location = new System.Drawing.Point(573, 31);
            this.hrmInputNumberTextBox1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmInputNumberTextBox1.Name = "hrmInputNumberTextBox1";
            this.hrmInputNumberTextBox1.Size = new System.Drawing.Size(289, 22);
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
            this.hrmDateTimePicker1.Calendar.BottomHeight = 27;
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
            this.hrmDateTimePicker1.Calendar.NoneButton.AutoSize = true;
            this.hrmDateTimePicker1.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.hrmDateTimePicker1.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.NoneButton.Location = new System.Drawing.Point(128, 0);
            this.hrmDateTimePicker1.Calendar.NoneButton.Size = new System.Drawing.Size(72, 27);
            this.hrmDateTimePicker1.Calendar.NoneButton.Text = "None";
            this.hrmDateTimePicker1.Calendar.NoneButton.ThemeName = "Office2007";
            this.hrmDateTimePicker1.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.hrmDateTimePicker1.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.hrmDateTimePicker1.Calendar.TodayButton.AutoSize = true;
            this.hrmDateTimePicker1.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.hrmDateTimePicker1.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.hrmDateTimePicker1.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.hrmDateTimePicker1.Calendar.TodayButton.Size = new System.Drawing.Size(128, 27);
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
            this.hrmDateTimePicker1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
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
            // SF215
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1148, 551);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF215";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "HỢP ĐỒNG CHÍNH THỨC";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBatDau.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayBatDau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKetThuc.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKetThuc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKy.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayKy)).EndInit();
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
        private Library.Controls.HRMTextBox txtSoQuyetDinh;
        private Library.Controls.HRMDateTimePicker dtpNgayKetThuc;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Library.Controls.HRMLabel lblTuNgay;
        private Library.Controls.HRMLabel lblDenNgay;
        private Library.Controls.HRMDateTimePicker dtpNgayBatDau;
        private Library.Controls.HRMLabel hrmLabel7;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMLabel lblNgayKy;
        private Library.Controls.HRMDateTimePicker dtpNgayKy;
    }
}