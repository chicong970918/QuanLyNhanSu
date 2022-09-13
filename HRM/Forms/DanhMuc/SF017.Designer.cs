namespace HRM.Forms.DanhMuc
{
    partial class SF017
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaNgayLe = new Library.Controls.HRMTextBoxUpper();
            this.lblMaNgayLe = new Library.Controls.HRMLabel();
            this.lblTenNgayLe = new Library.Controls.HRMLabel();
            this.txtTenNgayLe = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.dtpNgay = new Library.Controls.HRMLabel();
            this.dtpNgayLe = new Library.Controls.HRMDateTimePicker();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNgayLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNgayLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayLe.Calendar)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1315, 106);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 140);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1315, 401);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1315, 401);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã ngày lễ";
            gridColumnDescriptor1.MappingName = "MaNgayLe";
            gridColumnDescriptor1.Width = 129;
            gridColumnDescriptor2.HeaderText = "Tên ngày lễ";
            gridColumnDescriptor2.MappingName = "TenNgayLe";
            gridColumnDescriptor2.Width = 219;
            gridColumnDescriptor3.HeaderText = "Ngày";
            gridColumnDescriptor3.MappingName = "NgayLe";
            gridColumnDescriptor3.Width = 176;
            gridColumnDescriptor4.HeaderText = "Ghi chú";
            gridColumnDescriptor4.MappingName = "GhiChu";
            gridColumnDescriptor4.Width = 322;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3,
            gridColumnDescriptor4});
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1315, 106);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 284F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMaNgayLe, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaNgayLe, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenNgayLe, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTenNgayLe, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpNgay, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpNgayLe, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1305, 77);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMaNgayLe
            // 
            this.txtMaNgayLe.BeforeTouchSize = new System.Drawing.Size(363, 26);
            this.txtMaNgayLe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNgayLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaNgayLe.Location = new System.Drawing.Point(293, 7);
            this.txtMaNgayLe.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNgayLe.MaxLength = 20;
            this.txtMaNgayLe.Name = "txtMaNgayLe";
            this.txtMaNgayLe.Size = new System.Drawing.Size(282, 26);
            this.txtMaNgayLe.TabIndex = 0;
            // 
            // lblMaNgayLe
            // 
            this.lblMaNgayLe.AutoSize = true;
            this.lblMaNgayLe.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNgayLe.IsRequired = true;
            this.lblMaNgayLe.Location = new System.Drawing.Point(187, 6);
            this.lblMaNgayLe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaNgayLe.Name = "lblMaNgayLe";
            this.lblMaNgayLe.Size = new System.Drawing.Size(100, 32);
            this.lblMaNgayLe.TabIndex = 1;
            this.lblMaNgayLe.Text = "Mã ngày lễ";
            this.lblMaNgayLe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenNgayLe
            // 
            this.lblTenNgayLe.AutoSize = true;
            this.lblTenNgayLe.BackColor = System.Drawing.Color.Transparent;
            this.lblTenNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNgayLe.IsRequired = true;
            this.lblTenNgayLe.Location = new System.Drawing.Point(581, 6);
            this.lblTenNgayLe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenNgayLe.Name = "lblTenNgayLe";
            this.lblTenNgayLe.Size = new System.Drawing.Size(161, 32);
            this.lblTenNgayLe.TabIndex = 2;
            this.lblTenNgayLe.Text = "Tên ngày lễ";
            this.lblTenNgayLe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenNgayLe
            // 
            this.txtTenNgayLe.BeforeTouchSize = new System.Drawing.Size(363, 26);
            this.txtTenNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNgayLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenNgayLe.Location = new System.Drawing.Point(748, 7);
            this.txtTenNgayLe.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenNgayLe.Name = "txtTenNgayLe";
            this.txtTenNgayLe.Size = new System.Drawing.Size(373, 26);
            this.txtTenNgayLe.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(363, 26);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(748, 39);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(373, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(581, 38);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(161, 30);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgay
            // 
            this.dtpNgay.AutoSize = true;
            this.dtpNgay.BackColor = System.Drawing.Color.Transparent;
            this.dtpNgay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgay.IsRequired = true;
            this.dtpNgay.Location = new System.Drawing.Point(187, 38);
            this.dtpNgay.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.dtpNgay.Name = "dtpNgay";
            this.dtpNgay.Size = new System.Drawing.Size(100, 30);
            this.dtpNgay.TabIndex = 4;
            this.dtpNgay.Text = "Ngày";
            this.dtpNgay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtpNgayLe
            // 
            this.dtpNgayLe.Border3DStyle = System.Windows.Forms.Border3DStyle.Flat;
            this.dtpNgayLe.BorderColor = System.Drawing.Color.Empty;
            this.dtpNgayLe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            // 
            // 
            // 
            this.dtpNgayLe.Calendar.AllowMultipleSelection = false;
            this.dtpNgayLe.Calendar.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(211)))), ((int)(((byte)(212)))));
            this.dtpNgayLe.Calendar.BottomHeight = 32;
            this.dtpNgayLe.Calendar.Culture = new System.Globalization.CultureInfo("en-NZ");
            this.dtpNgayLe.Calendar.DayNamesFont = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLe.Calendar.DayNamesHeight = 20;
            this.dtpNgayLe.Calendar.DaysFont = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayLe.Calendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayLe.Calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayLe.Calendar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayLe.Calendar.GridLines = Syncfusion.Windows.Forms.Grid.GridBorderStyle.None;
            this.dtpNgayLe.Calendar.HeaderEndColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            this.dtpNgayLe.Calendar.HeaderFont = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpNgayLe.Calendar.HeaderHeight = 41;
            this.dtpNgayLe.Calendar.HeaderStartColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayLe.Calendar.HeadForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayLe.Calendar.HeadGradient = true;
            this.dtpNgayLe.Calendar.HighlightColor = System.Drawing.Color.Black;
            this.dtpNgayLe.Calendar.Iso8601CalenderFormat = false;
            this.dtpNgayLe.Calendar.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayLe.Calendar.Name = "monthCalendar";
            this.dtpNgayLe.Calendar.ScrollButtonSize = new System.Drawing.Size(30, 28);
            this.dtpNgayLe.Calendar.Size = new System.Drawing.Size(231, 174);
            this.dtpNgayLe.Calendar.SizeToFit = true;
            this.dtpNgayLe.Calendar.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayLe.Calendar.TabIndex = 0;
            this.dtpNgayLe.Calendar.WeekFont = new System.Drawing.Font("Verdana", 8F);
            this.dtpNgayLe.Calendar.WeekInterior = new Syncfusion.Drawing.BrushInfo(Syncfusion.Drawing.GradientStyle.Vertical, System.Drawing.Color.PeachPuff, System.Drawing.Color.AntiqueWhite);
            // 
            // 
            // 
            this.dtpNgayLe.Calendar.NoneButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayLe.Calendar.NoneButton.AutoSize = true;
            this.dtpNgayLe.Calendar.NoneButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayLe.Calendar.NoneButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayLe.Calendar.NoneButton.Location = new System.Drawing.Point(119, 0);
            this.dtpNgayLe.Calendar.NoneButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpNgayLe.Calendar.NoneButton.Size = new System.Drawing.Size(112, 32);
            this.dtpNgayLe.Calendar.NoneButton.Text = "None";
            this.dtpNgayLe.Calendar.NoneButton.ThemeName = "Office2007";
            this.dtpNgayLe.Calendar.NoneButton.UseVisualStyle = true;
            // 
            // 
            // 
            this.dtpNgayLe.Calendar.TodayButton.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.dtpNgayLe.Calendar.TodayButton.AutoSize = true;
            this.dtpNgayLe.Calendar.TodayButton.BackColor = System.Drawing.SystemColors.Window;
            this.dtpNgayLe.Calendar.TodayButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayLe.Calendar.TodayButton.Location = new System.Drawing.Point(0, 0);
            this.dtpNgayLe.Calendar.TodayButton.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.dtpNgayLe.Calendar.TodayButton.Size = new System.Drawing.Size(119, 32);
            this.dtpNgayLe.Calendar.TodayButton.Text = "Today";
            this.dtpNgayLe.Calendar.TodayButton.ThemeName = "Office2007";
            this.dtpNgayLe.Calendar.TodayButton.UseVisualStyle = true;
            this.dtpNgayLe.CalendarSize = new System.Drawing.Size(189, 176);
            this.dtpNgayLe.CalendarTitleBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(179)))), ((int)(((byte)(209)))), ((int)(((byte)(252)))));
            this.dtpNgayLe.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dtpNgayLe.CustomFormat = "dd/MM/yyyy";
            this.dtpNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpNgayLe.DropDownImage = null;
            this.dtpNgayLe.DropDownNormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(181)))), ((int)(((byte)(203)))), ((int)(((byte)(232)))));
            this.dtpNgayLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.dtpNgayLe.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNgayLe.IsNullDate = true;
            this.dtpNgayLe.Location = new System.Drawing.Point(293, 39);
            this.dtpNgayLe.Margin = new System.Windows.Forms.Padding(1);
            this.dtpNgayLe.MetroColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(165)))), ((int)(((byte)(220)))));
            this.dtpNgayLe.MinValue = new System.DateTime(((long)(0)));
            this.dtpNgayLe.Name = "dtpNgayLe";
            this.dtpNgayLe.NullString = "Chưa chọn";
            this.dtpNgayLe.ShowCheckBox = false;
            this.dtpNgayLe.Size = new System.Drawing.Size(282, 28);
            this.dtpNgayLe.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.dtpNgayLe.TabIndex = 5;
            this.dtpNgayLe.ThemesEnabled = true;
            this.dtpNgayLe.Value = null;
            // 
            // SF017
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 541);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SF017";
            this.Text = "DANH MỤC KHEN THƯỞNG LỂ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNgayLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNgayLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayLe.Calendar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpNgayLe)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaNgayLe;
        private Library.Controls.HRMLabel lblMaNgayLe;
        private Library.Controls.HRMLabel lblTenNgayLe;
        private Library.Controls.HRMTextBox txtTenNgayLe;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMLabel dtpNgay;
        private Library.Controls.HRMDateTimePicker dtpNgayLe;
    }
}