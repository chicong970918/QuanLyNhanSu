namespace HRM.Forms.DanhMuc
{
    partial class SF019
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
            this.lblMaBieuMau = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.lblTenBieuMau = new Library.Controls.HRMLabel();
            this.lblLoaiFile = new Library.Controls.HRMLabel();
            this.btnLoaifile = new Library.Controls.HRMButton(this.components);
            this.txtMaBieuMau = new Library.Controls.HRMTextBoxUpper();
            this.txtTenBieuMau = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.txtLoaiFile = new Library.Controls.HRMTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaBieuMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenBieuMau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiFile)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1594, 119);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 153);
            this.panel2.Margin = new System.Windows.Forms.Padding(45, 39, 45, 39);
            this.panel2.Size = new System.Drawing.Size(1594, 505);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1594, 505);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã biểu ";
            gridColumnDescriptor1.MappingName = "MaBieuMau";
            gridColumnDescriptor1.Width = 200;
            gridColumnDescriptor2.HeaderText = "Tên biểu mẫu";
            gridColumnDescriptor2.MappingName = "TenBieuMau";
            gridColumnDescriptor2.Width = 200;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 234;
            gridColumnDescriptor4.HeaderText = "Loại tập tin";
            gridColumnDescriptor4.MappingName = "LoaiFile";
            gridColumnDescriptor4.Width = 298;
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
            this.GrdData.TableDescriptor.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("MaBieuMau"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TenBieuMau"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("LoaiFile"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("GhiChu")});
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(1584, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 139F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 255F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 101F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 84F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lblMaBieuMau, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblTenBieuMau, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblLoaiFile, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnLoaifile, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtMaBieuMau, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTenBieuMau, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 4, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtLoaiFile, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1574, 72);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblMaBieuMau
            // 
            this.lblMaBieuMau.AutoSize = true;
            this.lblMaBieuMau.BackColor = System.Drawing.Color.Transparent;
            this.lblMaBieuMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaBieuMau.IsRequired = true;
            this.lblMaBieuMau.Location = new System.Drawing.Point(357, 6);
            this.lblMaBieuMau.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaBieuMau.Name = "lblMaBieuMau";
            this.lblMaBieuMau.Size = new System.Drawing.Size(129, 31);
            this.lblMaBieuMau.TabIndex = 1;
            this.lblMaBieuMau.Text = "Mã biểu mẫu";
            this.lblMaBieuMau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(751, 37);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(67, 20);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenBieuMau
            // 
            this.lblTenBieuMau.AutoSize = true;
            this.lblTenBieuMau.BackColor = System.Drawing.Color.Transparent;
            this.lblTenBieuMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenBieuMau.IsRequired = true;
            this.lblTenBieuMau.Location = new System.Drawing.Point(357, 37);
            this.lblTenBieuMau.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenBieuMau.Name = "lblTenBieuMau";
            this.lblTenBieuMau.Size = new System.Drawing.Size(129, 35);
            this.lblTenBieuMau.TabIndex = 2;
            this.lblTenBieuMau.Text = "Tên biểu mẫu";
            this.lblTenBieuMau.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLoaiFile
            // 
            this.lblLoaiFile.AutoSize = true;
            this.lblLoaiFile.BackColor = System.Drawing.Color.Transparent;
            this.lblLoaiFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoaiFile.IsRequired = true;
            this.lblLoaiFile.Location = new System.Drawing.Point(751, 6);
            this.lblLoaiFile.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblLoaiFile.Name = "lblLoaiFile";
            this.lblLoaiFile.Size = new System.Drawing.Size(91, 31);
            this.lblLoaiFile.TabIndex = 4;
            this.lblLoaiFile.Text = "Loại file";
            this.lblLoaiFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnLoaifile
            // 
            this.btnLoaifile.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
            this.btnLoaifile.BeforeTouchSize = new System.Drawing.Size(82, 29);
            this.btnLoaifile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLoaifile.Location = new System.Drawing.Point(1139, 7);
            this.btnLoaifile.Margin = new System.Windows.Forms.Padding(1);
            this.btnLoaifile.Name = "btnLoaifile";
            this.btnLoaifile.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            this.btnLoaifile.Size = new System.Drawing.Size(82, 29);
            this.btnLoaifile.TabIndex = 5;
            this.btnLoaifile.Text = "File";
            this.btnLoaifile.ThemeName = "Office2007";
            this.btnLoaifile.UseVisualStyle = true;
            this.btnLoaifile.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // txtMaBieuMau
            // 
            this.txtMaBieuMau.BeforeTouchSize = new System.Drawing.Size(259, 26);
            this.txtMaBieuMau.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaBieuMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaBieuMau.Enabled = false;
            this.txtMaBieuMau.Location = new System.Drawing.Point(492, 7);
            this.txtMaBieuMau.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaBieuMau.MaxLength = 20;
            this.txtMaBieuMau.Name = "txtMaBieuMau";
            this.txtMaBieuMau.Size = new System.Drawing.Size(253, 26);
            this.txtMaBieuMau.TabIndex = 6;
            // 
            // txtTenBieuMau
            // 
            this.txtTenBieuMau.BeforeTouchSize = new System.Drawing.Size(259, 26);
            this.txtTenBieuMau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenBieuMau.Location = new System.Drawing.Point(492, 38);
            this.txtTenBieuMau.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenBieuMau.Name = "txtTenBieuMau";
            this.txtTenBieuMau.Size = new System.Drawing.Size(253, 26);
            this.txtTenBieuMau.TabIndex = 7;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(259, 26);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(848, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(289, 26);
            this.txtGhiChu.TabIndex = 8;
            // 
            // txtLoaiFile
            // 
            this.txtLoaiFile.BeforeTouchSize = new System.Drawing.Size(259, 26);
            this.txtLoaiFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLoaiFile.Location = new System.Drawing.Point(848, 7);
            this.txtLoaiFile.Margin = new System.Windows.Forms.Padding(1);
            this.txtLoaiFile.Name = "txtLoaiFile";
            this.txtLoaiFile.ReadOnly = true;
            this.txtLoaiFile.Size = new System.Drawing.Size(289, 26);
            this.txtLoaiFile.TabIndex = 9;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1594, 119);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // SF019
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 658);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SF019";
            this.Text = "DANH MỤC BIỂU MẪU";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaBieuMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenBieuMau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLoaiFile)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMLabel lblMaBieuMau;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMLabel lblTenBieuMau;
        private Library.Controls.HRMLabel lblLoaiFile;
        private Library.Controls.HRMButton btnLoaifile;
        private Library.Controls.HRMTextBoxUpper txtMaBieuMau;
        private Library.Controls.HRMTextBox txtTenBieuMau;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMTextBox txtLoaiFile;
     
  
    }
}