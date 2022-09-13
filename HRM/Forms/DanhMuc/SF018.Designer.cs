namespace HRM.Forms.DanhMuc
{
    partial class SF018
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaNgayLe = new Library.Controls.HRMTextBoxUpper();
            this.lblMaNgayLe = new Library.Controls.HRMLabel();
            this.lblChucDanh = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.lblMucThuong = new Library.Controls.HRMLabel();
            this.cboChucDanh = new Library.Controls.HRMCombobox();
            this.txtMucThuong = new Library.Controls.HRMIntergerTextBox(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNgayLe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucDanh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMucThuong)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1084, 132);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 166);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1084, 374);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1084, 374);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Tên chức danh";
            gridColumnDescriptor1.MappingName = "TenChucDanh";
            gridColumnDescriptor1.Width = 204;
            gridColumnDescriptor2.HeaderText = "Mức thưởng";
            gridColumnDescriptor2.MappingName = "MucThuong";
            gridColumnDescriptor2.Width = 230;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 341;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3});
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
            this.groupBox1.Size = new System.Drawing.Size(1084, 132);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 249F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 261F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMaNgayLe, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaNgayLe, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblChucDanh, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblMucThuong, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.cboChucDanh, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtMucThuong, 4, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1074, 103);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMaNgayLe
            // 
            this.txtMaNgayLe.BeforeTouchSize = new System.Drawing.Size(100, 22);
            this.txtMaNgayLe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNgayLe.Enabled = false;
            this.txtMaNgayLe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaNgayLe.Location = new System.Drawing.Point(278, 7);
            this.txtMaNgayLe.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNgayLe.MaxLength = 20;
            this.txtMaNgayLe.Name = "txtMaNgayLe";
            this.txtMaNgayLe.Size = new System.Drawing.Size(247, 26);
            this.txtMaNgayLe.TabIndex = 0;
            // 
            // lblMaNgayLe
            // 
            this.lblMaNgayLe.AutoSize = true;
            this.lblMaNgayLe.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNgayLe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNgayLe.IsRequired = true;
            this.lblMaNgayLe.Location = new System.Drawing.Point(172, 6);
            this.lblMaNgayLe.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaNgayLe.Name = "lblMaNgayLe";
            this.lblMaNgayLe.Size = new System.Drawing.Size(100, 31);
            this.lblMaNgayLe.TabIndex = 1;
            this.lblMaNgayLe.Text = "Mã ngày lễ";
            this.lblMaNgayLe.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblChucDanh
            // 
            this.lblChucDanh.AutoSize = true;
            this.lblChucDanh.BackColor = System.Drawing.Color.Transparent;
            this.lblChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblChucDanh.IsRequired = true;
            this.lblChucDanh.Location = new System.Drawing.Point(172, 37);
            this.lblChucDanh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblChucDanh.Name = "lblChucDanh";
            this.lblChucDanh.Size = new System.Drawing.Size(100, 31);
            this.lblChucDanh.TabIndex = 2;
            this.lblChucDanh.Text = "Chức danh";
            this.lblChucDanh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(172, 68);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(100, 31);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(100, 22);
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(278, 69);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(627, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // lblMucThuong
            // 
            this.lblMucThuong.AutoSize = true;
            this.lblMucThuong.BackColor = System.Drawing.Color.Transparent;
            this.lblMucThuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMucThuong.IsRequired = true;
            this.lblMucThuong.Location = new System.Drawing.Point(531, 37);
            this.lblMucThuong.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMucThuong.Name = "lblMucThuong";
            this.lblMucThuong.Size = new System.Drawing.Size(109, 31);
            this.lblMucThuong.TabIndex = 4;
            this.lblMucThuong.Text = "Mức thưởng";
            this.lblMucThuong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboChucDanh
            // 
            this.cboChucDanh.BeforeTouchSize = new System.Drawing.Size(247, 26);
            this.cboChucDanh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboChucDanh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboChucDanh.Location = new System.Drawing.Point(278, 38);
            this.cboChucDanh.Margin = new System.Windows.Forms.Padding(1);
            this.cboChucDanh.Name = "cboChucDanh";
            this.cboChucDanh.Size = new System.Drawing.Size(247, 26);
            this.cboChucDanh.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboChucDanh.TabIndex = 5;
            this.cboChucDanh.ThemeName = "Office2007Outlook";
            // 
            // txtMucThuong
            // 
            this.txtMucThuong.BeforeTouchSize = new System.Drawing.Size(100, 22);
            this.txtMucThuong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMucThuong.IntegerValue = ((long)(1));
            this.txtMucThuong.Location = new System.Drawing.Point(646, 38);
            this.txtMucThuong.Margin = new System.Windows.Forms.Padding(1);
            this.txtMucThuong.MaxValue = ((long)(2147483647));
            this.txtMucThuong.MinValue = ((long)(0));
            this.txtMucThuong.Name = "txtMucThuong";
            this.txtMucThuong.Size = new System.Drawing.Size(259, 26);
            this.txtMucThuong.TabIndex = 6;
            this.txtMucThuong.Text = "1";
            this.txtMucThuong.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SF018
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 540);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SF018";
            this.Text = "DANH MỤC CHI TIẾT THƯỞNG LỄ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNgayLe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucDanh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMucThuong)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaNgayLe;
        private Library.Controls.HRMLabel lblMaNgayLe;
        private Library.Controls.HRMLabel lblChucDanh;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMLabel lblMucThuong;
        private Library.Controls.HRMCombobox cboChucDanh;
        private Library.Controls.HRMIntergerTextBox txtMucThuong;
    }
}