namespace HRM.DanhMuc
{
    partial class SF001
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.hrmTextBox1 = new Library.Controls.HRMTextBox();
            this.hrmLabel2 = new Library.Controls.HRMLabel();
            this.hrmTextBox2 = new Library.Controls.HRMTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaPhongBan = new Library.Controls.HRMLabel();
            this.lblTruongPhong = new Library.Controls.HRMLabel();
            this.hrmLabel5 = new Library.Controls.HRMLabel();
            this.lblTenPhongBan = new Library.Controls.HRMLabel();
            this.hrmLabel7 = new Library.Controls.HRMLabel();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.txtTruongPhong = new Library.Controls.HRMTextBox();
            this.txtTenPhongBan = new Library.Controls.HRMTextBox();
            this.txtMaPhongBan = new Library.Controls.HRMTextBoxUpper();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chkNhanSu = new Library.Controls.HRMCheckBox();
            this.dtpNgayThanhLap = new Library.Controls.HRMDateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruongPhong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhongBan)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkNhanSu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayThanhLap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayThanhLap.Calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1222, 142);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 176);
            this.panel2.Margin = new System.Windows.Forms.Padding(45, 39, 45, 39);
            this.panel2.Size = new System.Drawing.Size(1222, 524);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.SelectionMode = Library.HRMGrigouping.SelectionType.None;
            this.GrdData.Size = new System.Drawing.Size(1222, 524);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã phòng ban";
            gridColumnDescriptor1.MappingName = "MaPhongBan";
            gridColumnDescriptor1.Width = 120;
            gridColumnDescriptor2.HeaderText = "Tên phòng ban";
            gridColumnDescriptor2.MappingName = "TenPhongBan";
            gridColumnDescriptor2.Width = 197;
            gridColumnDescriptor3.HeaderText = "Trưởng phòng";
            gridColumnDescriptor3.MappingName = "TruongPhongBan";
            gridColumnDescriptor3.Width = 217;
            gridColumnDescriptor4.HeaderText = "Ngày thành lập";
            gridColumnDescriptor4.MappingName = "NgayThanhLap";
            gridColumnDescriptor4.Width = 148;
            gridColumnDescriptor5.HeaderText = "Ghi chú";
            gridColumnDescriptor5.MappingName = "GhiChu";
            gridColumnDescriptor5.Width = 303;
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
            this.GrdData.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.None;
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.42177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.57823F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel1);
            this.tableLayoutPanel1.Controls.Add(this.hrmTextBox1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel2);
            this.tableLayoutPanel1.Controls.Add(this.hrmTextBox2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(3, 0);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(310, 15);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Tên phòng ban";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmTextBox1
            // 
            this.hrmTextBox1.BeforeTouchSize = new System.Drawing.Size(769, 26);
            this.hrmTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmTextBox1.Location = new System.Drawing.Point(317, 1);
            this.hrmTextBox1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmTextBox1.Name = "hrmTextBox1";
            this.hrmTextBox1.Size = new System.Drawing.Size(262, 22);
            this.hrmTextBox1.TabIndex = 1;
            this.hrmTextBox1.Text = "hrmTextBox1";
            // 
            // hrmLabel2
            // 
            this.hrmLabel2.AutoSize = true;
            this.hrmLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel2.IsRequired = false;
            this.hrmLabel2.Location = new System.Drawing.Point(583, 0);
            this.hrmLabel2.Name = "hrmLabel2";
            this.hrmLabel2.Size = new System.Drawing.Size(176, 15);
            this.hrmLabel2.TabIndex = 2;
            this.hrmLabel2.Text = "Mã phòng ban ";
            this.hrmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmTextBox2
            // 
            this.hrmTextBox2.BeforeTouchSize = new System.Drawing.Size(769, 26);
            this.hrmTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmTextBox2.Location = new System.Drawing.Point(763, 1);
            this.hrmTextBox2.Margin = new System.Windows.Forms.Padding(1);
            this.hrmTextBox2.Name = "hrmTextBox2";
            this.hrmTextBox2.Size = new System.Drawing.Size(276, 22);
            this.hrmTextBox2.TabIndex = 1;
            this.hrmTextBox2.Text = "hrmTextBox1";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1222, 142);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1214, 129);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaPhongBan, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTruongPhong, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel5, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblTenPhongBan, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel7, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtGhiChu, 2, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtTruongPhong, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtTenPhongBan, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMaPhongBan, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.panel3, 4, 2);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 5;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1206, 102);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaPhongBan
            // 
            this.lblMaPhongBan.AutoSize = true;
            this.lblMaPhongBan.BackColor = System.Drawing.Color.Transparent;
            this.lblMaPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaPhongBan.IsRequired = true;
            this.lblMaPhongBan.Location = new System.Drawing.Point(137, 6);
            this.lblMaPhongBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaPhongBan.Name = "lblMaPhongBan";
            this.lblMaPhongBan.Size = new System.Drawing.Size(167, 31);
            this.lblMaPhongBan.TabIndex = 0;
            this.lblMaPhongBan.Text = "Mã phòng ban";
            this.lblMaPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTruongPhong
            // 
            this.lblTruongPhong.AutoSize = true;
            this.lblTruongPhong.BackColor = System.Drawing.Color.Transparent;
            this.lblTruongPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTruongPhong.IsRequired = false;
            this.lblTruongPhong.Location = new System.Drawing.Point(137, 37);
            this.lblTruongPhong.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTruongPhong.Name = "lblTruongPhong";
            this.lblTruongPhong.Size = new System.Drawing.Size(167, 31);
            this.lblTruongPhong.TabIndex = 1;
            this.lblTruongPhong.Text = "Trưởng phòng";
            this.lblTruongPhong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel5
            // 
            this.hrmLabel5.AutoSize = true;
            this.hrmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel5.IsRequired = false;
            this.hrmLabel5.Location = new System.Drawing.Point(137, 68);
            this.hrmLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrmLabel5.Name = "hrmLabel5";
            this.hrmLabel5.Size = new System.Drawing.Size(167, 31);
            this.hrmLabel5.TabIndex = 2;
            this.hrmLabel5.Text = "Ghi chú";
            this.hrmLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenPhongBan
            // 
            this.lblTenPhongBan.AutoSize = true;
            this.lblTenPhongBan.BackColor = System.Drawing.Color.Transparent;
            this.lblTenPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenPhongBan.IsRequired = true;
            this.lblTenPhongBan.Location = new System.Drawing.Point(537, 6);
            this.lblTenPhongBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenPhongBan.Name = "lblTenPhongBan";
            this.lblTenPhongBan.Size = new System.Drawing.Size(156, 31);
            this.lblTenPhongBan.TabIndex = 3;
            this.lblTenPhongBan.Text = "Tên phòng ban";
            this.lblTenPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel7
            // 
            this.hrmLabel7.AutoSize = true;
            this.hrmLabel7.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel7.IsRequired = false;
            this.hrmLabel7.Location = new System.Drawing.Point(537, 37);
            this.hrmLabel7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrmLabel7.Name = "hrmLabel7";
            this.hrmLabel7.Size = new System.Drawing.Size(156, 31);
            this.hrmLabel7.TabIndex = 4;
            this.hrmLabel7.Text = "Ngày thành lập";
            this.hrmLabel7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(769, 26);
            this.tableLayoutPanel3.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(309, 69);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(762, 26);
            this.txtGhiChu.TabIndex = 4;
            // 
            // txtTruongPhong
            // 
            this.txtTruongPhong.BeforeTouchSize = new System.Drawing.Size(769, 26);
            this.txtTruongPhong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTruongPhong.Location = new System.Drawing.Point(309, 38);
            this.txtTruongPhong.Margin = new System.Windows.Forms.Padding(1);
            this.txtTruongPhong.Name = "txtTruongPhong";
            this.txtTruongPhong.Size = new System.Drawing.Size(223, 26);
            this.txtTruongPhong.TabIndex = 2;
            // 
            // txtTenPhongBan
            // 
            this.txtTenPhongBan.BeforeTouchSize = new System.Drawing.Size(769, 26);
            this.txtTenPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenPhongBan.Location = new System.Drawing.Point(698, 7);
            this.txtTenPhongBan.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenPhongBan.Name = "txtTenPhongBan";
            this.txtTenPhongBan.Size = new System.Drawing.Size(373, 26);
            this.txtTenPhongBan.TabIndex = 1;
            // 
            // txtMaPhongBan
            // 
            this.txtMaPhongBan.BeforeTouchSize = new System.Drawing.Size(769, 26);
            this.txtMaPhongBan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaPhongBan.Location = new System.Drawing.Point(309, 7);
            this.txtMaPhongBan.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaPhongBan.MaxLength = 20;
            this.txtMaPhongBan.Name = "txtMaPhongBan";
            this.txtMaPhongBan.Size = new System.Drawing.Size(223, 26);
            this.txtMaPhongBan.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chkNhanSu);
            this.panel3.Controls.Add(this.dtpNgayThanhLap);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(698, 38);
            this.panel3.Margin = new System.Windows.Forms.Padding(1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 29);
            this.panel3.TabIndex = 6;
            // 
            // chkNhanSu
            // 
            this.chkNhanSu.BeforeTouchSize = new System.Drawing.Size(183, 29);
            this.chkNhanSu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkNhanSu.ImageCheckBoxSize = new System.Drawing.Size(16, 16);
            this.chkNhanSu.Location = new System.Drawing.Point(190, 0);
            this.chkNhanSu.Margin = new System.Windows.Forms.Padding(1);
            this.chkNhanSu.Name = "chkNhanSu";
            this.chkNhanSu.Size = new System.Drawing.Size(183, 29);
            this.chkNhanSu.Style = Syncfusion.Windows.Forms.Tools.CheckBoxAdvStyle.Office2007;
            this.chkNhanSu.TabIndex = 6;
            this.chkNhanSu.Text = "Phòng nhân sự";
            this.chkNhanSu.TextContentAlignment = System.Drawing.ContentAlignment.MiddleRight;
            this.chkNhanSu.ThemeName = "Office2007";
            // 
            // dtpNgayThanhLap
            // 
            this.dtpNgayThanhLap.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayThanhLap.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayThanhLap.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayThanhLap.Calendar.AllowMultipleSelection = false;
            this.dtpNgayThanhLap.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dtpNgayThanhLap.Calendar.BottomHeight = 32;
            this.dtpNgayThanhLap.Calendar.Culture = new System.Globalization.CultureInfo("en-US");
            this.dtpNgayThanhLap.Calendar.DayNamesFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayThanhLap.Calendar.DayNamesHeight = 20;
            this.dtpNgayThanhLap.Calendar.DaysFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayThanhLap.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayThanhLap.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayThanhLap.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayThanhLap.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayThanhLap.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayThanhLap.Calendar.HeaderFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayThanhLap.Calendar.HeaderHeight = 41;
            this.dtpNgayThanhLap.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayThanhLap.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayThanhLap.Calendar.HeadGradient = true;
            this.dtpNgayThanhLap.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.dtpNgayThanhLap.Calendar.Iso8601CalenderFormat = false;
            this.dtpNgayThanhLap.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayThanhLap.Calendar.Name = "monthCalendar";
            this.dtpNgayThanhLap.Calendar.ScrollButtonSize = new System.Drawing.Size(30, 28);
            this.dtpNgayThanhLap.Calendar.Size = new System.Drawing.Size(231, 174);
            this.dtpNgayThanhLap.Calendar.SizeToFit = true;
            this.dtpNgayThanhLap.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayThanhLap.Calendar.TabIndex = 0;
            this.dtpNgayThanhLap.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayThanhLap.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayThanhLap.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayThanhLap.Calendar.NoneButton.AutoSize = true;
            this.dtpNgayThanhLap.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayThanhLap.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayThanhLap.Calendar.NoneButton.Location = new System.Drawing.Point(119, 0);
            this.dtpNgayThanhLap.Calendar.NoneButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpNgayThanhLap.Calendar.NoneButton.Size = new System.Drawing.Size(112, 32);
            this.dtpNgayThanhLap.Calendar.NoneButton.Text = "None";
            this.dtpNgayThanhLap.Calendar.NoneButton.ThemeName = "Office2007";
            this.dtpNgayThanhLap.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayThanhLap.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayThanhLap.Calendar.TodayButton.AutoSize = true;
            this.dtpNgayThanhLap.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayThanhLap.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayThanhLap.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayThanhLap.Calendar.TodayButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpNgayThanhLap.Calendar.TodayButton.Size = new System.Drawing.Size(119, 32);
            this.dtpNgayThanhLap.Calendar.TodayButton.Text = "Today";
            this.dtpNgayThanhLap.Calendar.TodayButton.ThemeName = "Office2007";
            this.dtpNgayThanhLap.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayThanhLap.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpNgayThanhLap.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayThanhLap.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayThanhLap.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayThanhLap.Dock = System.Windows.Forms.DockStyle.Left;
            this.dtpNgayThanhLap.DropDownImage = null;
            this.dtpNgayThanhLap.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpNgayThanhLap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayThanhLap.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayThanhLap.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayThanhLap.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayThanhLap.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpNgayThanhLap.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayThanhLap.Name = "dtpNgayThanhLap";
            this.dtpNgayThanhLap.NullString = "Chưa chọn";
            this.dtpNgayThanhLap.ShowCheckBox = false;
            this.dtpNgayThanhLap.Size = new System.Drawing.Size(190, 29);
            this.dtpNgayThanhLap.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayThanhLap.TabIndex = 5;
            this.dtpNgayThanhLap.ThemesEnabled = true;
            this.dtpNgayThanhLap.Value = new System.DateTime(2011, 5, 20, 12, 49, 14, 700);
            // 
            // SF001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 700);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SF001";
            this.Text = "DANH MỤC PHÒNG BAN";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTruongPhong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhongBan)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkNhanSu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayThanhLap.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayThanhLap)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMLabel hrmLabel1;
        private Library.Controls.HRMTextBox hrmTextBox1;
        private Library.Controls.HRMLabel hrmLabel2;
        private Library.Controls.HRMTextBox hrmTextBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Library.Controls.HRMLabel lblMaPhongBan;
        private Library.Controls.HRMLabel lblTruongPhong;
        private Library.Controls.HRMLabel hrmLabel5;
        private Library.Controls.HRMLabel lblTenPhongBan;
        private Library.Controls.HRMLabel hrmLabel7;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMTextBox txtTruongPhong;
        private Library.Controls.HRMTextBox txtTenPhongBan;
        private Library.Controls.HRMTextBoxUpper txtMaPhongBan;
        private Library.Controls.HRMDateTimePicker dtpNgayThanhLap;
        private System.Windows.Forms.Panel panel3;
        private Library.Controls.HRMCheckBox chkNhanSu;
    }
}
