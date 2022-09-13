namespace HRM.DanhMuc
{
    partial class SF003
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaDanToc = new Library.Controls.HRMTextBoxUpper();
            this.lblMaChuyenNganh = new Library.Controls.HRMLabel();
            this.lblTenChuyenNganh = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtTenDanToc = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanToc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanToc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1315, 102);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 136);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1315, 405);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1315, 405);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã dân tộc";
            gridColumnDescriptor1.MappingName = "MaDanToc";
            gridColumnDescriptor1.Width = 178;
            gridColumnDescriptor2.HeaderText = "Tên dân tộc";
            gridColumnDescriptor2.MappingName = "TenDanToc";
            gridColumnDescriptor2.Width = 283;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 421;
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
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1315, 102);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 112F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMaDanToc, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaChuyenNganh, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenChuyenNganh, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenDanToc, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1305, 73);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMaDanToc
            // 
            this.txtMaDanToc.BeforeTouchSize = new System.Drawing.Size(737, 26);
            this.txtMaDanToc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaDanToc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaDanToc.Location = new System.Drawing.Point(350, 7);
            this.txtMaDanToc.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaDanToc.MaxLength = 20;
            this.txtMaDanToc.Name = "txtMaDanToc";
            this.txtMaDanToc.Size = new System.Drawing.Size(223, 26);
            this.txtMaDanToc.TabIndex = 0;
            // 
            // lblMaChuyenNganh
            // 
            this.lblMaChuyenNganh.AutoSize = true;
            this.lblMaChuyenNganh.BackColor = System.Drawing.Color.Transparent;
            this.lblMaChuyenNganh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaChuyenNganh.IsRequired = true;
            this.lblMaChuyenNganh.Location = new System.Drawing.Point(242, 6);
            this.lblMaChuyenNganh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaChuyenNganh.Name = "lblMaChuyenNganh";
            this.lblMaChuyenNganh.Size = new System.Drawing.Size(102, 31);
            this.lblMaChuyenNganh.TabIndex = 1;
            this.lblMaChuyenNganh.Text = "Mã dân tộc";
            this.lblMaChuyenNganh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenChuyenNganh
            // 
            this.lblTenChuyenNganh.AutoSize = true;
            this.lblTenChuyenNganh.BackColor = System.Drawing.Color.Transparent;
            this.lblTenChuyenNganh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenChuyenNganh.IsRequired = true;
            this.lblTenChuyenNganh.Location = new System.Drawing.Point(579, 6);
            this.lblTenChuyenNganh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenChuyenNganh.Name = "lblTenChuyenNganh";
            this.lblTenChuyenNganh.Size = new System.Drawing.Size(109, 31);
            this.lblTenChuyenNganh.TabIndex = 2;
            this.lblTenChuyenNganh.Text = "Tên dân tộc";
            this.lblTenChuyenNganh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(242, 37);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(102, 36);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenDanToc
            // 
            this.txtTenDanToc.BeforeTouchSize = new System.Drawing.Size(737, 26);
            this.txtTenDanToc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenDanToc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenDanToc.Location = new System.Drawing.Point(694, 7);
            this.txtTenDanToc.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenDanToc.Name = "txtTenDanToc";
            this.txtTenDanToc.Size = new System.Drawing.Size(373, 26);
            this.txtTenDanToc.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(737, 26);
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(350, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(717, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // SF003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 541);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "SF003";
            this.Text = "DANH MỤC DÂN TỘC";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaDanToc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDanToc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaDanToc;
        private Library.Controls.HRMLabel lblMaChuyenNganh;
        private Library.Controls.HRMLabel lblTenChuyenNganh;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMTextBox txtTenDanToc;
        private Library.Controls.HRMTextBox txtGhiChu;
    }
}