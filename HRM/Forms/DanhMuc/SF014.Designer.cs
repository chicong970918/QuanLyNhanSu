namespace HRM.DanhMuc
{
    partial class SF014
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblTinh = new Library.Controls.HRMLabel();
            this.lblmaHuyen = new Library.Controls.HRMLabel();
            this.lblTenHuyen = new Library.Controls.HRMLabel();
            this.txtTenHuyen = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.hrmLabel5 = new Library.Controls.HRMLabel();
            this.txtMaHuyen = new Library.Controls.HRMTextBoxUpper();
            this.cboTinh = new Library.Controls.HRMCombobox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenHuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTinh)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1320, 114);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 148);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1320, 253);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1320, 253);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Tên huyện";
            gridColumnDescriptor1.MappingName = "TenHuyen";
            gridColumnDescriptor1.Width = 299;
            gridColumnDescriptor2.HeaderText = "Mã huyện";
            gridColumnDescriptor2.MappingName = "MaHuyen";
            gridColumnDescriptor2.Width = 167;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 383;
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
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1320, 114);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1312, 101);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 272F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 164F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblTinh, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblmaHuyen, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTenHuyen, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtTenHuyen, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtGhiChu, 4, 2);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel5, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtMaHuyen, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.cboTinh, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1304, 74);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblTinh
            // 
            this.lblTinh.AutoSize = true;
            this.lblTinh.BackColor = System.Drawing.Color.Transparent;
            this.lblTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTinh.IsRequired = true;
            this.lblTinh.Location = new System.Drawing.Point(186, 6);
            this.lblTinh.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTinh.Name = "lblTinh";
            this.lblTinh.Size = new System.Drawing.Size(120, 31);
            this.lblTinh.TabIndex = 0;
            this.lblTinh.Text = "Tỉnh";
            this.lblTinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblmaHuyen
            // 
            this.lblmaHuyen.AutoSize = true;
            this.lblmaHuyen.BackColor = System.Drawing.Color.Transparent;
            this.lblmaHuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblmaHuyen.IsRequired = true;
            this.lblmaHuyen.Location = new System.Drawing.Point(186, 37);
            this.lblmaHuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblmaHuyen.Name = "lblmaHuyen";
            this.lblmaHuyen.Size = new System.Drawing.Size(120, 31);
            this.lblmaHuyen.TabIndex = 1;
            this.lblmaHuyen.Text = "Mã huyện";
            this.lblmaHuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenHuyen
            // 
            this.lblTenHuyen.AutoSize = true;
            this.lblTenHuyen.BackColor = System.Drawing.Color.Transparent;
            this.lblTenHuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenHuyen.IsRequired = true;
            this.lblTenHuyen.Location = new System.Drawing.Point(586, 6);
            this.lblTenHuyen.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenHuyen.Name = "lblTenHuyen";
            this.lblTenHuyen.Size = new System.Drawing.Size(156, 31);
            this.lblTenHuyen.TabIndex = 3;
            this.lblTenHuyen.Text = "Tên huyện";
            this.lblTenHuyen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenHuyen
            // 
            this.txtTenHuyen.BeforeTouchSize = new System.Drawing.Size(305, 26);
            this.txtTenHuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenHuyen.Location = new System.Drawing.Point(747, 7);
            this.txtTenHuyen.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenHuyen.Name = "txtTenHuyen";
            this.txtTenHuyen.Size = new System.Drawing.Size(373, 26);
            this.txtTenHuyen.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(305, 26);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(747, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(373, 26);
            this.txtGhiChu.TabIndex = 3;
            // 
            // hrmLabel5
            // 
            this.hrmLabel5.AutoSize = true;
            this.hrmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel5.IsRequired = false;
            this.hrmLabel5.Location = new System.Drawing.Point(586, 37);
            this.hrmLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrmLabel5.Name = "hrmLabel5";
            this.hrmLabel5.Size = new System.Drawing.Size(156, 31);
            this.hrmLabel5.TabIndex = 2;
            this.hrmLabel5.Text = "Ghi chú";
            this.hrmLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMaHuyen
            // 
            this.txtMaHuyen.BeforeTouchSize = new System.Drawing.Size(305, 26);
            this.txtMaHuyen.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaHuyen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaHuyen.Location = new System.Drawing.Point(311, 38);
            this.txtMaHuyen.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaHuyen.MaxLength = 20;
            this.txtMaHuyen.Name = "txtMaHuyen";
            this.txtMaHuyen.Size = new System.Drawing.Size(270, 26);
            this.txtMaHuyen.TabIndex = 2;
            // 
            // cboTinh
            // 
            this.cboTinh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cboTinh.BeforeTouchSize = new System.Drawing.Size(270, 26);
            this.cboTinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboTinh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboTinh.Location = new System.Drawing.Point(311, 7);
            this.cboTinh.Margin = new System.Windows.Forms.Padding(1);
            this.cboTinh.Name = "cboTinh";
            this.cboTinh.Size = new System.Drawing.Size(270, 26);
            this.cboTinh.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboTinh.TabIndex = 0;
            this.cboTinh.Text = " ";
            this.cboTinh.ThemeName = "Office2007Outlook";
            // 
            // SF014
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 401);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SF014";
            this.Text = "DANH MỤC HUYỆN";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenHuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaHuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTinh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Library.Controls.HRMLabel lblTinh;
        private Library.Controls.HRMLabel lblmaHuyen;
        private Library.Controls.HRMLabel lblTenHuyen;
        private Library.Controls.HRMTextBox txtTenHuyen;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMLabel hrmLabel5;
        private Library.Controls.HRMTextBoxUpper txtMaHuyen;
        private Library.Controls.HRMCombobox cboTinh;
    }
}