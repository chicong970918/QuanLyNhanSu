namespace HRM.DanhMuc
{
    partial class SF015
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaPhuCap = new Library.Controls.HRMTextBoxUpper();
            this.lblMaPhuCap = new Library.Controls.HRMLabel();
            this.lblTenPhuCap = new Library.Controls.HRMLabel();
            this.hrmLabel3 = new Library.Controls.HRMLabel();
            this.txtTenPhuCap = new Library.Controls.HRMTextBox();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.txtSoTien = new Library.Controls.HRMIntergerTextBox(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhuCap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
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
            gridColumnDescriptor1.HeaderText = "Mã phụ cấp";
            gridColumnDescriptor1.MappingName = "MaPhuCap";
            gridColumnDescriptor1.Width = 130;
            gridColumnDescriptor2.HeaderText = "Tên phụ cấp";
            gridColumnDescriptor2.MappingName = "TenPhuCap";
            gridColumnDescriptor2.Width = 178;
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor3.HeaderText = "Mức phụ cấp";
            gridColumnDescriptor3.MappingName = "MucPhuCap";
            gridColumnDescriptor3.Width = 143;
            gridColumnDescriptor4.HeaderText = "Ghi chú";
            gridColumnDescriptor4.MappingName = "GhiChu";
            gridColumnDescriptor4.Width = 427;
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1315, 126);
            this.tableLayoutPanel2.TabIndex = 8;
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
            this.groupBox1.Size = new System.Drawing.Size(1305, 108);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 281F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 79F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.txtMaPhuCap, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaPhuCap, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenPhuCap, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel3, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTenPhuCap, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtGhiChu, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel1, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtSoTien, 6, 1);
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
            // txtMaPhuCap
            // 
            this.txtMaPhuCap.BeforeTouchSize = new System.Drawing.Size(373, 26);
            this.txtMaPhuCap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaPhuCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaPhuCap.Location = new System.Drawing.Point(303, 7);
            this.txtMaPhuCap.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaPhuCap.MaxLength = 20;
            this.txtMaPhuCap.Name = "txtMaPhuCap";
            this.txtMaPhuCap.Size = new System.Drawing.Size(172, 26);
            this.txtMaPhuCap.TabIndex = 0;
            // 
            // lblMaPhuCap
            // 
            this.lblMaPhuCap.AutoSize = true;
            this.lblMaPhuCap.BackColor = System.Drawing.Color.Transparent;
            this.lblMaPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaPhuCap.IsRequired = true;
            this.lblMaPhuCap.Location = new System.Drawing.Point(187, 6);
            this.lblMaPhuCap.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaPhuCap.Name = "lblMaPhuCap";
            this.lblMaPhuCap.Size = new System.Drawing.Size(110, 31);
            this.lblMaPhuCap.TabIndex = 1;
            this.lblMaPhuCap.Text = "Mã phụ cấp";
            this.lblMaPhuCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenPhuCap
            // 
            this.lblTenPhuCap.AutoSize = true;
            this.lblTenPhuCap.BackColor = System.Drawing.Color.Transparent;
            this.lblTenPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenPhuCap.IsRequired = true;
            this.lblTenPhuCap.Location = new System.Drawing.Point(481, 6);
            this.lblTenPhuCap.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenPhuCap.Name = "lblTenPhuCap";
            this.lblTenPhuCap.Size = new System.Drawing.Size(116, 31);
            this.lblTenPhuCap.TabIndex = 2;
            this.lblTenPhuCap.Text = "Tên phụ cấp";
            this.lblTenPhuCap.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel3
            // 
            this.hrmLabel3.AutoSize = true;
            this.hrmLabel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel3.IsRequired = false;
            this.hrmLabel3.Location = new System.Drawing.Point(187, 37);
            this.hrmLabel3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel3.Name = "hrmLabel3";
            this.hrmLabel3.Size = new System.Drawing.Size(110, 31);
            this.hrmLabel3.TabIndex = 3;
            this.hrmLabel3.Text = "Ghi chú";
            this.hrmLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenPhuCap
            // 
            this.txtTenPhuCap.BeforeTouchSize = new System.Drawing.Size(373, 26);
            this.txtTenPhuCap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenPhuCap.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenPhuCap.Location = new System.Drawing.Point(603, 7);
            this.txtTenPhuCap.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenPhuCap.Name = "txtTenPhuCap";
            this.txtTenPhuCap.Size = new System.Drawing.Size(279, 26);
            this.txtTenPhuCap.TabIndex = 1;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(373, 26);
            this.tableLayoutPanel1.SetColumnSpan(this.txtGhiChu, 5);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtGhiChu.Location = new System.Drawing.Point(303, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(808, 26);
            this.txtGhiChu.TabIndex = 3;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(888, 6);
            this.hrmLabel1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(69, 31);
            this.hrmLabel1.TabIndex = 4;
            this.hrmLabel1.Text = "Số tiền";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSoTien
            // 
            this.txtSoTien.BeforeTouchSize = new System.Drawing.Size(373, 26);
            this.txtSoTien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSoTien.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtSoTien.IntegerValue = ((long)(0));
            this.txtSoTien.Location = new System.Drawing.Point(963, 7);
            this.txtSoTien.Margin = new System.Windows.Forms.Padding(1);
            this.txtSoTien.MaxValue = ((long)(2147483647));
            this.txtSoTien.MinValue = ((long)(0));
            this.txtSoTien.Name = "txtSoTien";
            this.txtSoTien.Size = new System.Drawing.Size(148, 26);
            this.txtSoTien.TabIndex = 2;
            this.txtSoTien.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // SF015
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1315, 541);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SF015";
            this.Text = "DANH MỤC PHỤ CẤP";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenPhuCap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSoTien)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaPhuCap;
        private Library.Controls.HRMLabel lblMaPhuCap;
        private Library.Controls.HRMLabel lblTenPhuCap;
        private Library.Controls.HRMLabel hrmLabel3;
        private Library.Controls.HRMTextBox txtTenPhuCap;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMLabel hrmLabel1;
        private Library.Controls.HRMIntergerTextBox txtSoTien;
    }
}