namespace HRM.Forms.HeThong
{
    partial class SF903
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtMaManHinh = new Library.Controls.HRMTextBoxUpper();
            this.lblMaManHinh = new Library.Controls.HRMLabel();
            this.lblTenManHinh = new Library.Controls.HRMLabel();
            this.txtTenManHinh = new Library.Controls.HRMTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaManHinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenManHinh)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Margin = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(1594, 90);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 124);
            this.panel2.Margin = new System.Windows.Forms.Padding(45, 39, 45, 39);
            this.panel2.Size = new System.Drawing.Size(1594, 534);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(1594, 534);
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã màn hình";
            gridColumnDescriptor1.MappingName = "MaManHinh";
            gridColumnDescriptor1.Width = 200;
            gridColumnDescriptor2.HeaderText = "Tên màn hình";
            gridColumnDescriptor2.MappingName = "TenManHinh";
            gridColumnDescriptor2.Width = 200;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2});
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
            this.tableLayoutPanel1.Controls.Add(this.txtMaManHinh, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblMaManHinh, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblTenManHinh, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtTenManHinh, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(5, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1574, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtMaManHinh
            // 
            this.txtMaManHinh.BeforeTouchSize = new System.Drawing.Size(373, 26);
            this.txtMaManHinh.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtMaManHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMaManHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtMaManHinh.Location = new System.Drawing.Point(487, 7);
            this.txtMaManHinh.Margin = new System.Windows.Forms.Padding(1);
            this.txtMaManHinh.MaxLength = 20;
            this.txtMaManHinh.Name = "txtMaManHinh";
            this.txtMaManHinh.Size = new System.Drawing.Size(223, 26);
            this.txtMaManHinh.TabIndex = 0;
            // 
            // lblMaManHinh
            // 
            this.lblMaManHinh.AutoSize = true;
            this.lblMaManHinh.BackColor = System.Drawing.Color.Transparent;
            this.lblMaManHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaManHinh.IsRequired = true;
            this.lblMaManHinh.Location = new System.Drawing.Point(322, 6);
            this.lblMaManHinh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblMaManHinh.Name = "lblMaManHinh";
            this.lblMaManHinh.Size = new System.Drawing.Size(159, 31);
            this.lblMaManHinh.TabIndex = 1;
            this.lblMaManHinh.Text = "Mã màn hình";
            this.lblMaManHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTenManHinh
            // 
            this.lblTenManHinh.AutoSize = true;
            this.lblTenManHinh.BackColor = System.Drawing.Color.Transparent;
            this.lblTenManHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTenManHinh.IsRequired = true;
            this.lblTenManHinh.Location = new System.Drawing.Point(716, 6);
            this.lblTenManHinh.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblTenManHinh.Name = "lblTenManHinh";
            this.lblTenManHinh.Size = new System.Drawing.Size(161, 31);
            this.lblTenManHinh.TabIndex = 2;
            this.lblTenManHinh.Text = "Tên màn hình";
            this.lblTenManHinh.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtTenManHinh
            // 
            this.txtTenManHinh.BeforeTouchSize = new System.Drawing.Size(373, 26);
            this.txtTenManHinh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTenManHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtTenManHinh.Location = new System.Drawing.Point(883, 7);
            this.txtTenManHinh.Margin = new System.Windows.Forms.Padding(1);
            this.txtTenManHinh.Name = "txtTenManHinh";
            this.txtTenManHinh.Size = new System.Drawing.Size(373, 26);
            this.txtTenManHinh.TabIndex = 1;
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
            this.groupBox1.Size = new System.Drawing.Size(1584, 72);
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
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(5);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1594, 90);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // SF903
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1594, 658);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SF903";
            this.Text = "DANH MỤC MÀN HÌNH";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaManHinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenManHinh)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMTextBoxUpper txtMaManHinh;
        private Library.Controls.HRMLabel lblMaManHinh;
        private Library.Controls.HRMLabel lblTenManHinh;
        private Library.Controls.HRMTextBox txtTenManHinh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}