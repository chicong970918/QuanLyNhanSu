namespace HRM.DanhMuc
{
    partial class SF012
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
            this.lblMaPhongBan = new Library.Controls.HRMLabel();
            this.hrmLabel5 = new Library.Controls.HRMLabel();
            this.lblTenPhongBan = new Library.Controls.HRMLabel();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.txtTenYeuCauCongViec = new Library.Controls.HRMTextBox();
            this.txtMaYeuCauCongViec = new Library.Controls.HRMTextBoxUpper();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenYeuCauCongViec)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaYeuCauCongViec)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Size = new System.Drawing.Size(1053, 93);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 127);
            this.panel2.Size = new System.Drawing.Size(1053, 307);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1053, 307);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã yêu cầu công việc";
            gridColumnDescriptor1.MappingName = "MaYeuCauCongViec";
            gridColumnDescriptor1.Width = 207;
            gridColumnDescriptor2.HeaderText = "Tên yêu cầu công việc";
            gridColumnDescriptor2.MappingName = "TenYeuCauCongViec";
            gridColumnDescriptor2.Width = 289;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 408;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3});
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
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
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 4F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1053, 93);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1047, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 180F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 131F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaPhongBan, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel5, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblTenPhongBan, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtGhiChu, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtTenYeuCauCongViec, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMaYeuCauCongViec, 2, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 4;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 5F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1041, 61);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaPhongBan
            // 
            this.lblMaPhongBan.AutoSize = true;
            this.lblMaPhongBan.BackColor = System.Drawing.Color.Transparent;
            this.lblMaPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaPhongBan.IsRequired = true;
            this.lblMaPhongBan.Location = new System.Drawing.Point(148, 5);
            this.lblMaPhongBan.Name = "lblMaPhongBan";
            this.lblMaPhongBan.Size = new System.Drawing.Size(134, 25);
            this.lblMaPhongBan.TabIndex = 0;
            this.lblMaPhongBan.Text = "Mã công việc";
            this.lblMaPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel5
            // 
            this.hrmLabel5.AutoSize = true;
            this.hrmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel5.IsRequired = false;
            this.hrmLabel5.Location = new System.Drawing.Point(148, 30);
            this.hrmLabel5.Name = "hrmLabel5";
            this.hrmLabel5.Size = new System.Drawing.Size(134, 25);
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
            this.lblTenPhongBan.Location = new System.Drawing.Point(468, 5);
            this.lblTenPhongBan.Name = "lblTenPhongBan";
            this.lblTenPhongBan.Size = new System.Drawing.Size(125, 25);
            this.lblTenPhongBan.TabIndex = 3;
            this.lblTenPhongBan.Text = "Tên công việc";
            this.lblTenPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.tableLayoutPanel3.SetColumnSpan(this.txtGhiChu, 3);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(286, 31);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(609, 23);
            this.txtGhiChu.TabIndex = 4;
            // 
            // txtTenYeuCauCongViec
            // 
            this.txtTenYeuCauCongViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenYeuCauCongViec.Location = new System.Drawing.Point(597, 6);
            this.txtTenYeuCauCongViec.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenYeuCauCongViec.Name = "txtTenYeuCauCongViec";
            this.txtTenYeuCauCongViec.Size = new System.Drawing.Size(298, 23);
            this.txtTenYeuCauCongViec.TabIndex = 2;
            // 
            // txtMaYeuCauCongViec
            // 
            this.txtMaYeuCauCongViec.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaYeuCauCongViec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaYeuCauCongViec.Location = new System.Drawing.Point(286, 6);
            this.txtMaYeuCauCongViec.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaYeuCauCongViec.MaxLength = 20;
            this.txtMaYeuCauCongViec.Name = "txtMaYeuCauCongViec";
            this.txtMaYeuCauCongViec.Size = new System.Drawing.Size(178, 23);
            this.txtMaYeuCauCongViec.TabIndex = 0;
            // 
            // SF012
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 434);
            this.Name = "SF012";
            this.Text = "DANH MỤC YÊU CẦU CÔNG VIỆC";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenYeuCauCongViec)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaYeuCauCongViec)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Library.Controls.HRMLabel lblMaPhongBan;
        private Library.Controls.HRMLabel hrmLabel5;
        private Library.Controls.HRMLabel lblTenPhongBan;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMTextBox txtTenYeuCauCongViec;
        private Library.Controls.HRMTextBoxUpper txtMaYeuCauCongViec;
    }
}