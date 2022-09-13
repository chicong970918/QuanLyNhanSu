namespace HRM.DanhMuc
{
    partial class SF008
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaTinHoc = new Library.Controls.HRMTextBoxUpper();
            this.lblMaTinHoc = new Library.Controls.HRMLabel();
            this.lblTenTinHoc = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtTenTinHoc = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTinHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTinHoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.panel1.Size = new System.Drawing.Size(1315, 126);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1315, 381);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1315, 381);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã tin học";
            gridColumnDescriptor1.MappingName = "MaTinHoc";
            gridColumnDescriptor1.Width = 156;
            gridColumnDescriptor2.HeaderText = "Tên trình độ";
            gridColumnDescriptor2.MappingName = "TenTrinhDoTinHoc";
            gridColumnDescriptor2.Width = 304;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 418;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1315, 126);
            this.tableLayoutPanel2.TabIndex = 7;
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
            this.groupBox1.Size = new System.Drawing.Size(1305, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 134F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 375F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMaTinHoc, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaTinHoc, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenTinHoc, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenTinHoc, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 2, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1295, 79);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMaTinHoc
            // 
            this.txtMaTinHoc.BeforeTouchSize = new System.Drawing.Size(289, 26);
            this.txtMaTinHoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaTinHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaTinHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaTinHoc.Location = new System.Drawing.Point(340, 7);
            this.txtMaTinHoc.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaTinHoc.MaxLength = 20;
            this.txtMaTinHoc.Name = "txtMaTinHoc";
            this.txtMaTinHoc.Size = new System.Drawing.Size(223, 26);
            this.txtMaTinHoc.TabIndex = 0;
            // 
            // lblMaTinHoc
            // 
            this.lblMaTinHoc.AutoSize = true;
            this.lblMaTinHoc.BackColor = System.Drawing.Color.Transparent;
            this.lblMaTinHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaTinHoc.IsRequired = true;
            this.lblMaTinHoc.Location = new System.Drawing.Point(210, 6);
            this.lblMaTinHoc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaTinHoc.Name = "lblMaTinHoc";
            this.lblMaTinHoc.Size = new System.Drawing.Size(124, 31);
            this.lblMaTinHoc.TabIndex = 1;
            this.lblMaTinHoc.Text = "Mã tin học";
            this.lblMaTinHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenTinHoc
            // 
            this.lblTenTinHoc.AutoSize = true;
            this.lblTenTinHoc.BackColor = System.Drawing.Color.Transparent;
            this.lblTenTinHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenTinHoc.IsRequired = true;
            this.lblTenTinHoc.Location = new System.Drawing.Point(569, 6);
            this.lblTenTinHoc.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenTinHoc.Name = "lblTenTinHoc";
            this.lblTenTinHoc.Size = new System.Drawing.Size(141, 31);
            this.lblTenTinHoc.TabIndex = 2;
            this.lblTenTinHoc.Text = "Trình độ tin học";
            this.lblTenTinHoc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(210, 37);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(124, 31);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenTinHoc
            // 
            this.txtTenTinHoc.BeforeTouchSize = new System.Drawing.Size(289, 26);
            this.txtTenTinHoc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenTinHoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenTinHoc.Location = new System.Drawing.Point(716, 7);
            this.txtTenTinHoc.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenTinHoc.Name = "txtTenTinHoc";
            this.txtTenTinHoc.Size = new System.Drawing.Size(373, 26);
            this.txtTenTinHoc.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(289, 26);
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(340, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(749, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // SF008
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 541);
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "SF008";
            this.Text = "DANH MỤC TRÌNH ĐỘ TIN HỌC";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTinHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTinHoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaTinHoc;
        private Library.Controls.HRMLabel lblMaTinHoc;
        private Library.Controls.HRMLabel lblTenTinHoc;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMTextBox txtTenTinHoc;
        private Library.Controls.HRMTextBox txtGhiChu;
    }
}