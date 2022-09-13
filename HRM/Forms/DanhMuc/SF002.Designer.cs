namespace HRM.Forms.DanhMuc
{
    partial class SF002
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaChuyenNganh = new Library.Controls.HRMTextBoxUpper();
            this.lblMaChuyenNganh = new Library.Controls.HRMLabel();
            this.lblTenChuyenNganh = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtTenChuyeNganh = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChuyenNganh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuyeNganh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            gridColumnDescriptor1.HeaderText = "Mã chuyên ngành";
            gridColumnDescriptor1.MappingName = "MaChuyenNganh";
            gridColumnDescriptor1.Width = 200;
            gridColumnDescriptor2.HeaderText = "Tên chuyên ngành";
            gridColumnDescriptor2.MappingName = "TenChuyenNganh";
            gridColumnDescriptor2.Width = 200;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 400;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 171F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMaChuyenNganh, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaChuyenNganh, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenChuyenNganh, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenChuyeNganh, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 2, 2);
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
            // txtMaChuyenNganh
            // 
            this.txtMaChuyenNganh.BeforeTouchSize = new System.Drawing.Size(717, 26);
            this.txtMaChuyenNganh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaChuyenNganh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaChuyenNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaChuyenNganh.Location = new System.Drawing.Point(487, 7);
            this.txtMaChuyenNganh.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaChuyenNganh.MaxLength = 20;
            this.txtMaChuyenNganh.Name = "txtMaChuyenNganh";
            this.txtMaChuyenNganh.Size = new System.Drawing.Size(223, 26);
            this.txtMaChuyenNganh.TabIndex = 0;
            // 
            // lblMaChuyenNganh
            // 
            this.lblMaChuyenNganh.AutoSize = true;
            this.lblMaChuyenNganh.BackColor = System.Drawing.Color.Transparent;
            this.lblMaChuyenNganh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaChuyenNganh.IsRequired = true;
            this.lblMaChuyenNganh.Location = new System.Drawing.Point(322, 6);
            this.lblMaChuyenNganh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaChuyenNganh.Name = "lblMaChuyenNganh";
            this.lblMaChuyenNganh.Size = new System.Drawing.Size(159, 31);
            this.lblMaChuyenNganh.TabIndex = 1;
            this.lblMaChuyenNganh.Text = "Mã chuyên ngành";
            this.lblMaChuyenNganh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenChuyenNganh
            // 
            this.lblTenChuyenNganh.AutoSize = true;
            this.lblTenChuyenNganh.BackColor = System.Drawing.Color.Transparent;
            this.lblTenChuyenNganh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenChuyenNganh.IsRequired = true;
            this.lblTenChuyenNganh.Location = new System.Drawing.Point(716, 6);
            this.lblTenChuyenNganh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenChuyenNganh.Name = "lblTenChuyenNganh";
            this.lblTenChuyenNganh.Size = new System.Drawing.Size(161, 31);
            this.lblTenChuyenNganh.TabIndex = 2;
            this.lblTenChuyenNganh.Text = "Tên chuyên ngành";
            this.lblTenChuyenNganh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(322, 37);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(159, 35);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenChuyeNganh
            // 
            this.txtTenChuyeNganh.BeforeTouchSize = new System.Drawing.Size(717, 26);
            this.txtTenChuyeNganh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenChuyeNganh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenChuyeNganh.Location = new System.Drawing.Point(883, 7);
            this.txtTenChuyeNganh.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenChuyeNganh.Name = "txtTenChuyeNganh";
            this.txtTenChuyeNganh.Size = new System.Drawing.Size(373, 26);
            this.txtTenChuyeNganh.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(717, 26);
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(487, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(769, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.groupBox1, 2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(1584, 101);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1594, 119);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // SF002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 658);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SF002";
            this.Text = "DANH MỤC CHUYÊN NGÀNH";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaChuyenNganh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenChuyeNganh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaChuyenNganh;
        private Library.Controls.HRMLabel lblMaChuyenNganh;
        private Library.Controls.HRMLabel lblTenChuyenNganh;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMTextBox txtTenChuyeNganh;
        private Library.Controls.HRMTextBox txtGhiChu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}