namespace HRM.Forms.TuyenDung
{
    partial class SF117
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF117));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gradientPanel1 = new Syncfusion.Windows.Forms.Tools.GradientPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.lblTrachNhiem = new Library.Controls.HRMLabel();
            this.lblTenCongViec = new Library.Controls.HRMLabel();
            this.lblTiTrong = new Library.Controls.HRMLabel();
            this.hrmLabel6 = new Library.Controls.HRMLabel();
            this.txtMaKeHoach = new Library.Controls.HRMTextBox();
            this.txtTenCongViec = new Library.Controls.HRMTextBox();
            this.txtTiTrong = new Library.Controls.HRMInputNumberTextBox();
            this.txtKetQua = new Library.Controls.HRMTextBox();
            this.txtTrachNhiem = new Library.Controls.HRMTextBox();
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCongViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiTrong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKetQua)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrachNhiem)).BeginInit();
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
            this.panel1.Size = new System.Drawing.Size(932, 121);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 155);
            this.panel2.Size = new System.Drawing.Size(932, 229);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(932, 229);
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Công việc";
            gridColumnDescriptor1.MappingName = "TenCongViec";
            gridColumnDescriptor1.ReadOnly = true;
            gridColumnDescriptor1.Width = 174;
            gridColumnDescriptor2.HeaderText = "Trách nhiệm";
            gridColumnDescriptor2.MappingName = "TrachNhiem";
            gridColumnDescriptor2.ReadOnly = true;
            gridColumnDescriptor2.Width = 164;
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor3.HeaderText = "Tỉ trọng";
            gridColumnDescriptor3.MappingName = "TiTrong";
            gridColumnDescriptor3.ReadOnly = true;
            gridColumnDescriptor3.Width = 63;
            gridColumnDescriptor4.HeaderText = "Kết quả";
            gridColumnDescriptor4.MappingName = "KetQua";
            gridColumnDescriptor4.ReadOnly = true;
            gridColumnDescriptor4.Width = 177;
            gridColumnDescriptor5.HeaderText = "Đánh giá";
            gridColumnDescriptor5.MappingName = "DanhGia";
            gridColumnDescriptor5.Width = 152;
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.MaxLength = 2;
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.ValidateValue.Maximum = 1.7976931348623158E+307D;
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.ValidateValue.Minimum = -1.7976931348623158E+307D;
            gridColumnDescriptor6.HeaderText = "Điểm số";
            gridColumnDescriptor6.MappingName = "DiemSo";
            gridColumnDescriptor6.Width = 147;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(932, 121);
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
            this.gradientPanel1.Size = new System.Drawing.Size(926, 115);
            this.gradientPanel1.TabIndex = 200;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 196F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 275F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel1, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTrachNhiem, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblTenCongViec, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTiTrong, 3, 2);
            this.tableLayoutPanel2.Controls.Add(this.hrmLabel6, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtMaKeHoach, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTenCongViec, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTiTrong, 4, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtKetQua, 2, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtTrachNhiem, 2, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(924, 88);
            this.tableLayoutPanel2.TabIndex = 159;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(126, 5);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(94, 25);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Mã kế hoạch";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTrachNhiem
            // 
            this.lblTrachNhiem.AutoSize = true;
            this.lblTrachNhiem.BackColor = System.Drawing.Color.Transparent;
            this.lblTrachNhiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTrachNhiem.IsRequired = false;
            this.lblTrachNhiem.Location = new System.Drawing.Point(126, 30);
            this.lblTrachNhiem.Name = "lblTrachNhiem";
            this.lblTrachNhiem.Size = new System.Drawing.Size(94, 25);
            this.lblTrachNhiem.TabIndex = 1;
            this.lblTrachNhiem.Text = "Trách nhiệm";
            this.lblTrachNhiem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenCongViec
            // 
            this.lblTenCongViec.AutoSize = true;
            this.lblTenCongViec.BackColor = System.Drawing.Color.Transparent;
            this.lblTenCongViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenCongViec.IsRequired = true;
            this.lblTenCongViec.Location = new System.Drawing.Point(422, 5);
            this.lblTenCongViec.Name = "lblTenCongViec";
            this.lblTenCongViec.Size = new System.Drawing.Size(100, 25);
            this.lblTenCongViec.TabIndex = 2;
            this.lblTenCongViec.Text = "Tên công việc";
            this.lblTenCongViec.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTiTrong
            // 
            this.lblTiTrong.AutoSize = true;
            this.lblTiTrong.BackColor = System.Drawing.Color.Transparent;
            this.lblTiTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTiTrong.IsRequired = false;
            this.lblTiTrong.Location = new System.Drawing.Point(422, 30);
            this.lblTiTrong.Name = "lblTiTrong";
            this.lblTiTrong.Size = new System.Drawing.Size(100, 25);
            this.lblTiTrong.TabIndex = 3;
            this.lblTiTrong.Text = "Tỉ trọng";
            this.lblTiTrong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel6
            // 
            this.hrmLabel6.AutoSize = true;
            this.hrmLabel6.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel6.IsRequired = false;
            this.hrmLabel6.Location = new System.Drawing.Point(126, 55);
            this.hrmLabel6.Name = "hrmLabel6";
            this.hrmLabel6.Size = new System.Drawing.Size(94, 25);
            this.hrmLabel6.TabIndex = 5;
            this.hrmLabel6.Text = "Kết quả ";
            this.hrmLabel6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaKeHoach
            // 
            this.txtMaKeHoach.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaKeHoach.Location = new System.Drawing.Point(224, 6);
            this.txtMaKeHoach.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaKeHoach.Name = "txtMaKeHoach";
            this.txtMaKeHoach.ReadOnly = true;
            this.txtMaKeHoach.Size = new System.Drawing.Size(194, 23);
            this.txtMaKeHoach.TabIndex = 0;
            // 
            // txtTenCongViec
            // 
            this.txtTenCongViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenCongViec.Location = new System.Drawing.Point(526, 6);
            this.txtTenCongViec.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenCongViec.Name = "txtTenCongViec";
            this.txtTenCongViec.Size = new System.Drawing.Size(273, 23);
            this.txtTenCongViec.TabIndex = 1;
            // 
            // txtTiTrong
            // 
            this.txtTiTrong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTiTrong.Location = new System.Drawing.Point(526, 31);
            this.txtTiTrong.Margin = new System.Windows.Forms.Padding(1);
            this.txtTiTrong.MaxLength = 2;
            this.txtTiTrong.Name = "txtTiTrong";
            this.txtTiTrong.Size = new System.Drawing.Size(273, 23);
            this.txtTiTrong.TabIndex = 3;
            this.txtTiTrong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKetQua
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.txtKetQua, 3);
            this.txtKetQua.Location = new System.Drawing.Point(224, 56);
            this.txtKetQua.Margin = new System.Windows.Forms.Padding(1);
            this.txtKetQua.Name = "txtKetQua";
            this.txtKetQua.Size = new System.Drawing.Size(575, 23);
            this.txtKetQua.TabIndex = 4;
            // 
            // txtTrachNhiem
            // 
            this.txtTrachNhiem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTrachNhiem.Location = new System.Drawing.Point(224, 31);
            this.txtTrachNhiem.Margin = new System.Windows.Forms.Padding(1);
            this.txtTrachNhiem.Name = "txtTrachNhiem";
            this.txtTrachNhiem.Size = new System.Drawing.Size(194, 23);
            this.txtTrachNhiem.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(223)))), ((int)(((byte)(236)))), ((int)(((byte)(254)))));
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(924, 25);
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
            this.label2.Size = new System.Drawing.Size(924, 25);
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
            // SF117
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 384);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF117";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " CHI TIẾT ĐÁNH GIÁ THỬ VIỆC ";
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
            ((System.ComponentModel.ISupportInitialize)(this.txtTenCongViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTiTrong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKetQua)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTrachNhiem)).EndInit();
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
        private Library.Controls.HRMLabel lblTrachNhiem;
        private Library.Controls.HRMLabel lblTenCongViec;
        private Library.Controls.HRMLabel lblTiTrong;
        private Library.Controls.HRMLabel hrmLabel6;
        private Library.Controls.HRMTextBox txtMaKeHoach;
        private Library.Controls.HRMTextBox txtTenCongViec;
        private Library.Controls.HRMTextBox txtKetQua;
        private Library.Controls.HRMInputNumberTextBox txtTiTrong;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private Library.Controls.HRMTextBox txtTrachNhiem;
    }
}