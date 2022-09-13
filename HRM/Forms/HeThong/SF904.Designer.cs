namespace HRM.Forms.HeThong
{
    partial class SF904
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
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor5 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdManHinh = new Library.HRMGrigouping();
            this.bingdingManHinh = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grbNhomNguoiDung = new Library.HRMGrigouping();
            this.bindingNhomNguoiDung = new System.Windows.Forms.BindingSource(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdManHinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bingdingManHinh)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grbNhomNguoiDung)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNhomNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.87559F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.1244F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1053, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdManHinh);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.groupBox2.Location = new System.Drawing.Point(285, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(765, 394);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách quyền trên màn hình";
            // 
            // grdManHinh
            // 
            this.grdManHinh.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.grdManHinh.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.grdManHinh.BackColor = System.Drawing.Color.White;
            this.grdManHinh.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.grdManHinh.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.grdManHinh.DataSource = this.bingdingManHinh;
            this.grdManHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdManHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grdManHinh.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grdManHinh.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.grdManHinh.Location = new System.Drawing.Point(3, 19);
            this.grdManHinh.Name = "grdManHinh";
            this.grdManHinh.ShowOrdinalNumber = true;
            this.grdManHinh.Size = new System.Drawing.Size(759, 372);
            this.grdManHinh.TabIndex = 1;
            this.grdManHinh.TableDescriptor.AllowNew = false;
            this.grdManHinh.TableDescriptor.AllowRemove = false;
            this.grdManHinh.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã màn hình";
            gridColumnDescriptor1.MappingName = "MaManHinh";
            gridColumnDescriptor1.ReadOnly = true;
            gridColumnDescriptor1.Width = 133;
            gridColumnDescriptor2.HeaderText = "Tên màn hình";
            gridColumnDescriptor2.MappingName = "TenManHinh";
            gridColumnDescriptor2.ReadOnly = true;
            gridColumnDescriptor2.Width = 370;
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor3.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor3.HeaderText = "Có quyền";
            gridColumnDescriptor3.MappingName = "CoQuyen";
            gridColumnDescriptor3.Width = 143;
            this.grdManHinh.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3});
            this.grdManHinh.TableDescriptor.Name = "";
            this.grdManHinh.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.grdManHinh.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.grdManHinh.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.grdManHinh.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.grdManHinh.TableOptions.RowHeaderWidth = 40;
            this.grdManHinh.TableOptions.ShowRowHeader = true;
            this.grdManHinh.TableOptions.SummaryRowHeight = 23;
            this.grdManHinh.Text = "hrmGrigouping2";
            this.grdManHinh.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.grdManHinh.VersionInfo = "1.0.0.0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grbNhomNguoiDung);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(65)))), ((int)(((byte)(120)))));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 394);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách nhóm người dùng";
            // 
            // grbNhomNguoiDung
            // 
            this.grbNhomNguoiDung.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.grbNhomNguoiDung.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.grbNhomNguoiDung.BackColor = System.Drawing.Color.White;
            this.grbNhomNguoiDung.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.grbNhomNguoiDung.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.grbNhomNguoiDung.DataSource = this.bindingNhomNguoiDung;
            this.grbNhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grbNhomNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.grbNhomNguoiDung.ForeColor = System.Drawing.SystemColors.WindowText;
            this.grbNhomNguoiDung.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.grbNhomNguoiDung.Location = new System.Drawing.Point(3, 19);
            this.grbNhomNguoiDung.Name = "grbNhomNguoiDung";
            this.grbNhomNguoiDung.ShowOrdinalNumber = true;
            this.grbNhomNguoiDung.Size = new System.Drawing.Size(270, 372);
            this.grbNhomNguoiDung.TabIndex = 0;
            this.grbNhomNguoiDung.TableDescriptor.AllowEdit = false;
            this.grbNhomNguoiDung.TableDescriptor.AllowNew = false;
            this.grbNhomNguoiDung.TableDescriptor.AllowRemove = false;
            this.grbNhomNguoiDung.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor4.HeaderText = "Mã nhóm";
            gridColumnDescriptor4.MappingName = "MaNhom";
            gridColumnDescriptor4.Width = 103;
            gridColumnDescriptor5.HeaderText = "Tên nhóm";
            gridColumnDescriptor5.MappingName = "TenNhom";
            gridColumnDescriptor5.Width = 142;
            this.grbNhomNguoiDung.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor4,
            gridColumnDescriptor5});
            this.grbNhomNguoiDung.TableDescriptor.Name = "";
            this.grbNhomNguoiDung.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.grbNhomNguoiDung.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.grbNhomNguoiDung.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.grbNhomNguoiDung.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.grbNhomNguoiDung.TableOptions.RowHeaderWidth = 40;
            this.grbNhomNguoiDung.TableOptions.ShowRowHeader = true;
            this.grbNhomNguoiDung.TableOptions.SummaryRowHeight = 23;
            this.grbNhomNguoiDung.Text = "hrmGrigouping1";
            this.grbNhomNguoiDung.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.grbNhomNguoiDung.VersionInfo = "1.0.0.0";
            // 
            // SF904
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 434);
            this.Name = "SF904";
            this.Text = "DANH MỤC PHÂN QUYỀN";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdManHinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bingdingManHinh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grbNhomNguoiDung)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNhomNguoiDung)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private Library.HRMGrigouping grbNhomNguoiDung;
        private Library.HRMGrigouping grdManHinh;
        private System.Windows.Forms.BindingSource bindingNhomNguoiDung;
        private System.Windows.Forms.BindingSource bingdingManHinh;
    }
}