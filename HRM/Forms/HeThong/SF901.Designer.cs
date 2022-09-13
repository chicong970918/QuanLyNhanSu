namespace HRM.DanhMuc
{
    partial class SF901
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF901));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.grbNhomNguoiDung = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaNhom = new Library.Controls.HRMLabel();
            this.lblTenNhom = new Library.Controls.HRMLabel();
            this.txtTenNhom = new Library.Controls.HRMTextBox();
            this.lblGhiChu = new Library.Controls.HRMLabel();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.txtMaNhom = new Library.Controls.HRMTextBoxUpper();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.grbNhomNguoiDung.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhom)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Margin = new System.Windows.Forms.Padding(5);
            this.panel1.Size = new System.Drawing.Size(1151, 124);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 158);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1151, 330);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1151, 330);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã nhóm";
            gridColumnDescriptor1.MappingName = "MaNhom";
            gridColumnDescriptor1.Width = 184;
            gridColumnDescriptor2.HeaderText = "Tên nhóm";
            gridColumnDescriptor2.MappingName = "TenNhom";
            gridColumnDescriptor2.Width = 297;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 330;
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
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.grbNhomNguoiDung, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1151, 124);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // grbNhomNguoiDung
            // 
            this.grbNhomNguoiDung.Controls.Add(this.tableLayoutPanel2);
            this.grbNhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNhomNguoiDung.Location = new System.Drawing.Point(4, 10);
            this.grbNhomNguoiDung.Margin = new System.Windows.Forms.Padding(4);
            this.grbNhomNguoiDung.Name = "grbNhomNguoiDung";
            this.grbNhomNguoiDung.Padding = new System.Windows.Forms.Padding(4);
            this.grbNhomNguoiDung.Size = new System.Drawing.Size(1143, 104);
            this.grbNhomNguoiDung.TabIndex = 0;
            this.grbNhomNguoiDung.TabStop = false;
            this.grbNhomNguoiDung.Text = "Thông tin  nhóm người dùng";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.lblMaNhom, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblTenNhom, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtTenNhom, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblGhiChu, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtGhiChu, 2, 2);
            this.tableLayoutPanel2.Controls.Add(this.txtMaNhom, 2, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(4, 23);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1135, 77);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblMaNhom
            // 
            this.lblMaNhom.AutoSize = true;
            this.lblMaNhom.BackColor = System.Drawing.Color.Transparent;
            this.lblMaNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaNhom.IsRequired = true;
            this.lblMaNhom.Location = new System.Drawing.Point(153, 7);
            this.lblMaNhom.Margin = new System.Windows.Forms.Padding(1);
            this.lblMaNhom.Name = "lblMaNhom";
            this.lblMaNhom.Size = new System.Drawing.Size(148, 29);
            this.lblMaNhom.TabIndex = 0;
            this.lblMaNhom.Text = "Mã nhóm ";
            this.lblMaNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenNhom
            // 
            this.lblTenNhom.AutoSize = true;
            this.lblTenNhom.BackColor = System.Drawing.Color.Transparent;
            this.lblTenNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenNhom.IsRequired = false;
            this.lblTenNhom.Location = new System.Drawing.Point(506, 6);
            this.lblTenNhom.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenNhom.Name = "lblTenNhom";
            this.lblTenNhom.Size = new System.Drawing.Size(172, 31);
            this.lblTenNhom.TabIndex = 1;
            this.lblTenNhom.Text = "Tên nhóm";
            this.lblTenNhom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenNhom
            // 
            this.txtTenNhom.BeforeTouchSize = new System.Drawing.Size(198, 26);
            this.txtTenNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenNhom.Location = new System.Drawing.Point(683, 7);
            this.txtTenNhom.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenNhom.Name = "txtTenNhom";
            this.txtTenNhom.Size = new System.Drawing.Size(298, 26);
            this.txtTenNhom.TabIndex = 1;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.AutoSize = true;
            this.lblGhiChu.BackColor = System.Drawing.Color.Transparent;
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGhiChu.IsRequired = false;
            this.lblGhiChu.Location = new System.Drawing.Point(153, 38);
            this.lblGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(148, 29);
            this.lblGhiChu.TabIndex = 5;
            this.lblGhiChu.Text = "Ghi chú";
            this.lblGhiChu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(198, 26);
            this.tableLayoutPanel2.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(303, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(678, 26);
            this.txtGhiChu.TabIndex = 2;
            // 
            // txtMaNhom
            // 
            this.txtMaNhom.BeforeTouchSize = new System.Drawing.Size(198, 26);
            this.txtMaNhom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaNhom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaNhom.Location = new System.Drawing.Point(303, 7);
            this.txtMaNhom.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaNhom.MaxLength = 20;
            this.txtMaNhom.Name = "txtMaNhom";
            this.txtMaNhom.Size = new System.Drawing.Size(198, 26);
            this.txtMaNhom.TabIndex = 0;
            // 
            // SF901
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 488);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SF901";
            this.Text = "DANH MỤC NHÓM NGƯỜI DÙNG";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.grbNhomNguoiDung.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNhom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNhom)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox grbNhomNguoiDung;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Library.Controls.HRMLabel lblMaNhom;
        private Library.Controls.HRMLabel lblTenNhom;
        private Library.Controls.HRMTextBox txtTenNhom;
        private Library.Controls.HRMLabel lblGhiChu;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMTextBoxUpper txtMaNhom;
    }
}