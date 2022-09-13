namespace HRM.DanhMuc
{
    partial class SF016
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
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.hrmTextBox1 = new Library.Controls.HRMTextBox();
            this.hrmLabel2 = new Library.Controls.HRMLabel();
            this.hrmTextBox2 = new Library.Controls.HRMTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblMaTrinhDo = new Library.Controls.HRMLabel();
            this.lblTenTrinhDo = new Library.Controls.HRMLabel();
            this.txtTenTrinhDo = new Library.Controls.HRMTextBox();
            this.txtMaTrinhDo = new Library.Controls.HRMTextBoxUpper();
            this.lblHeSoChuyenMon = new Library.Controls.HRMLabel();
            this.txtHeSoChuyenMon = new Library.Controls.HRMDoubleTextBox(this.components);
            this.hrmLabel5 = new Library.Controls.HRMLabel();
            this.txtGhiChu = new Library.Controls.HRMTextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox2)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTrinhDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTrinhDo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoChuyenMon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Size = new System.Drawing.Size(1222, 120);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 154);
            this.panel2.Margin = new System.Windows.Forms.Padding(45, 39, 45, 39);
            this.panel2.Size = new System.Drawing.Size(1222, 546);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.SelectionMode = Library.HRMGrigouping.SelectionType.None;
            this.GrdData.Size = new System.Drawing.Size(1222, 546);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã trình độ";
            gridColumnDescriptor1.MappingName = "MaTrinhDo";
            gridColumnDescriptor1.Width = 168;
            gridColumnDescriptor2.HeaderText = "Tên trình độ";
            gridColumnDescriptor2.MappingName = "TenTrinhDo";
            gridColumnDescriptor2.Width = 278;
            gridColumnDescriptor3.HeaderText = "Ghi chú";
            gridColumnDescriptor3.MappingName = "GhiChu";
            gridColumnDescriptor3.Width = 364;
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right;
            gridColumnDescriptor4.HeaderText = "Hệ số chuyên môn";
            gridColumnDescriptor4.MappingName = "HeSoChuyenMon";
            gridColumnDescriptor4.Width = 127;
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
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("MaTrinhDo"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TenTrinhDo"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HeSoChuyenMon"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("GhiChu")});
            this.GrdData.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.None;
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.42177F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.57823F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 182F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel1);
            this.tableLayoutPanel1.Controls.Add(this.hrmTextBox1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel2);
            this.tableLayoutPanel1.Controls.Add(this.hrmTextBox2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 87);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = false;
            this.hrmLabel1.Location = new System.Drawing.Point(3, 0);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(310, 15);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Tên phòng ban";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmTextBox1
            // 
            this.hrmTextBox1.BeforeTouchSize = new System.Drawing.Size(148, 26);
            this.hrmTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmTextBox1.Location = new System.Drawing.Point(317, 1);
            this.hrmTextBox1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmTextBox1.Name = "hrmTextBox1";
            this.hrmTextBox1.Size = new System.Drawing.Size(262, 22);
            this.hrmTextBox1.TabIndex = 1;
            this.hrmTextBox1.Text = "hrmTextBox1";
            // 
            // hrmLabel2
            // 
            this.hrmLabel2.AutoSize = true;
            this.hrmLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel2.IsRequired = false;
            this.hrmLabel2.Location = new System.Drawing.Point(583, 0);
            this.hrmLabel2.Name = "hrmLabel2";
            this.hrmLabel2.Size = new System.Drawing.Size(176, 15);
            this.hrmLabel2.TabIndex = 2;
            this.hrmLabel2.Text = "Mã phòng ban ";
            this.hrmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmTextBox2
            // 
            this.hrmTextBox2.BeforeTouchSize = new System.Drawing.Size(148, 26);
            this.hrmTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmTextBox2.Location = new System.Drawing.Point(763, 1);
            this.hrmTextBox2.Margin = new System.Windows.Forms.Padding(1);
            this.hrmTextBox2.Name = "hrmTextBox2";
            this.hrmTextBox2.Size = new System.Drawing.Size(276, 22);
            this.hrmTextBox2.TabIndex = 1;
            this.hrmTextBox2.Text = "hrmTextBox1";
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1222, 120);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(4, 4);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1214, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 6;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 175F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 225F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 174F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 365F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lblMaTrinhDo, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblTenTrinhDo, 3, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtTenTrinhDo, 4, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtMaTrinhDo, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblHeSoChuyenMon, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtHeSoChuyenMon, 2, 2);
            this.tableLayoutPanel3.Controls.Add(this.hrmLabel5, 3, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtGhiChu, 4, 2);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1206, 80);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblMaTrinhDo
            // 
            this.lblMaTrinhDo.AutoSize = true;
            this.lblMaTrinhDo.BackColor = System.Drawing.Color.Transparent;
            this.lblMaTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaTrinhDo.IsRequired = true;
            this.lblMaTrinhDo.Location = new System.Drawing.Point(137, 6);
            this.lblMaTrinhDo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMaTrinhDo.Name = "lblMaTrinhDo";
            this.lblMaTrinhDo.Size = new System.Drawing.Size(167, 31);
            this.lblMaTrinhDo.TabIndex = 0;
            this.lblMaTrinhDo.Text = "Mã trình độ";
            this.lblMaTrinhDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenTrinhDo
            // 
            this.lblTenTrinhDo.AutoSize = true;
            this.lblTenTrinhDo.BackColor = System.Drawing.Color.Transparent;
            this.lblTenTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenTrinhDo.IsRequired = true;
            this.lblTenTrinhDo.Location = new System.Drawing.Point(537, 6);
            this.lblTenTrinhDo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTenTrinhDo.Name = "lblTenTrinhDo";
            this.lblTenTrinhDo.Size = new System.Drawing.Size(166, 31);
            this.lblTenTrinhDo.TabIndex = 3;
            this.lblTenTrinhDo.Text = "Tên trình độ";
            this.lblTenTrinhDo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenTrinhDo
            // 
            this.txtTenTrinhDo.BeforeTouchSize = new System.Drawing.Size(148, 26);
            this.txtTenTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenTrinhDo.Location = new System.Drawing.Point(708, 7);
            this.txtTenTrinhDo.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenTrinhDo.Name = "txtTenTrinhDo";
            this.txtTenTrinhDo.Size = new System.Drawing.Size(363, 26);
            this.txtTenTrinhDo.TabIndex = 1;
            // 
            // txtMaTrinhDo
            // 
            this.txtMaTrinhDo.BeforeTouchSize = new System.Drawing.Size(148, 26);
            this.txtMaTrinhDo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaTrinhDo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaTrinhDo.Location = new System.Drawing.Point(309, 7);
            this.txtMaTrinhDo.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaTrinhDo.MaxLength = 20;
            this.txtMaTrinhDo.Name = "txtMaTrinhDo";
            this.txtMaTrinhDo.Size = new System.Drawing.Size(223, 26);
            this.txtMaTrinhDo.TabIndex = 0;
            // 
            // lblHeSoChuyenMon
            // 
            this.lblHeSoChuyenMon.AutoSize = true;
            this.lblHeSoChuyenMon.BackColor = System.Drawing.Color.Transparent;
            this.lblHeSoChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHeSoChuyenMon.IsRequired = true;
            this.lblHeSoChuyenMon.Location = new System.Drawing.Point(137, 37);
            this.lblHeSoChuyenMon.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeSoChuyenMon.Name = "lblHeSoChuyenMon";
            this.lblHeSoChuyenMon.Size = new System.Drawing.Size(167, 31);
            this.lblHeSoChuyenMon.TabIndex = 5;
            this.lblHeSoChuyenMon.Text = "Hệ số chuyên môn";
            this.lblHeSoChuyenMon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHeSoChuyenMon
            // 
            this.txtHeSoChuyenMon.BeforeTouchSize = new System.Drawing.Size(148, 26);
            this.txtHeSoChuyenMon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtHeSoChuyenMon.DoubleValue = 0D;
            this.txtHeSoChuyenMon.Location = new System.Drawing.Point(309, 38);
            this.txtHeSoChuyenMon.Margin = new System.Windows.Forms.Padding(1);
            this.txtHeSoChuyenMon.MaxValue = 10D;
            this.txtHeSoChuyenMon.MinValue = 0D;
            this.txtHeSoChuyenMon.Name = "txtHeSoChuyenMon";
            this.txtHeSoChuyenMon.Size = new System.Drawing.Size(223, 26);
            this.txtHeSoChuyenMon.TabIndex = 2;
            this.txtHeSoChuyenMon.Text = "0.00";
            this.txtHeSoChuyenMon.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // hrmLabel5
            // 
            this.hrmLabel5.AutoSize = true;
            this.hrmLabel5.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel5.IsRequired = false;
            this.hrmLabel5.Location = new System.Drawing.Point(537, 37);
            this.hrmLabel5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.hrmLabel5.Name = "hrmLabel5";
            this.hrmLabel5.Size = new System.Drawing.Size(166, 31);
            this.hrmLabel5.TabIndex = 2;
            this.hrmLabel5.Text = "Ghi chú";
            this.hrmLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.BeforeTouchSize = new System.Drawing.Size(148, 26);
            this.txtGhiChu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGhiChu.Location = new System.Drawing.Point(708, 38);
            this.txtGhiChu.Margin = new System.Windows.Forms.Padding(1);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(363, 26);
            this.txtGhiChu.TabIndex = 3;
            // 
            // SF016
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1222, 700);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "SF016";
            this.Text = "DANH MỤC TRÌNH ĐỘ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmTextBox2)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenTrinhDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaTrinhDo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHeSoChuyenMon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMLabel hrmLabel1;
        private Library.Controls.HRMTextBox hrmTextBox1;
        private Library.Controls.HRMLabel hrmLabel2;
        private Library.Controls.HRMTextBox hrmTextBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private Library.Controls.HRMLabel lblMaTrinhDo;
        private Library.Controls.HRMLabel hrmLabel5;
        private Library.Controls.HRMLabel lblTenTrinhDo;
        private Library.Controls.HRMTextBox txtGhiChu;
        private Library.Controls.HRMTextBox txtTenTrinhDo;
        private Library.Controls.HRMTextBoxUpper txtMaTrinhDo;
        private Library.Controls.HRMLabel lblHeSoChuyenMon;
        private Library.Controls.HRMDoubleTextBox txtHeSoChuyenMon;
    }
}
