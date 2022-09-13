namespace HRM.Forms.NhanVien
{
    partial class SF210
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF210));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.GrdData = new Library.HRMGrigouping();
            this.treeInfo = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.CTMNCacLoaiQD = new Library.Controls.HRMContextMenustrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.kỷLuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tăngHsLươngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thăngCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nângHscmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thôiViệcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            this.CTMNCacLoaiQD.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Size = new System.Drawing.Size(927, 408);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.53398F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.46602F));
            this.tableLayoutPanel1.Controls.Add(this.GrdData, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.treeInfo, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(927, 408);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.BackColor = System.Drawing.Color.White;
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.GrdData.Location = new System.Drawing.Point(146, 3);
            this.GrdData.Name = "GrdData";
            this.tableLayoutPanel1.SetRowSpan(this.GrdData, 2);
            this.GrdData.ShowOrdinalNumber = true;
            this.GrdData.Size = new System.Drawing.Size(778, 402);
            this.GrdData.TabIndex = 1;
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            gridColumnDescriptor1.HeaderText = "Mã nhân viên";
            gridColumnDescriptor1.MappingName = "MaNhanVien";
            gridColumnDescriptor1.Width = 109;
            gridColumnDescriptor2.HeaderText = "Họ đệm";
            gridColumnDescriptor2.MappingName = "HoDem";
            gridColumnDescriptor2.Width = 146;
            gridColumnDescriptor3.HeaderText = "Tên";
            gridColumnDescriptor3.MappingName = "Ten";
            gridColumnDescriptor3.Width = 108;
            gridColumnDescriptor4.HeaderText = "Ngày sinh";
            gridColumnDescriptor4.MappingName = "NgaySinh";
            gridColumnDescriptor4.Width = 155;
            gridColumnDescriptor5.HeaderText = "Giới tính";
            gridColumnDescriptor5.MappingName = "GioiTinhText";
            gridColumnDescriptor5.Width = 202;
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3,
            gridColumnDescriptor4,
            gridColumnDescriptor5});
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.GrdData.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaptionPlusMinus = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaptionSummaryCells = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.Text = "hrmGrigouping1";
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.VersionInfo = "1.0.0.0";
            // 
            // treeInfo
            // 
            this.treeInfo.BackColor = System.Drawing.Color.AliceBlue;
            this.treeInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeInfo.Location = new System.Drawing.Point(3, 3);
            this.treeInfo.Name = "treeInfo";
            this.tableLayoutPanel1.SetRowSpan(this.treeInfo, 2);
            this.treeInfo.Size = new System.Drawing.Size(137, 402);
            this.treeInfo.TabIndex = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "phongbannhansu.jpg");
            this.imageList1.Images.SetKeyName(1, "room.jpg");
            this.imageList1.Images.SetKeyName(2, "phongban1.jpg");
            this.imageList1.Images.SetKeyName(3, "phongban2.jpg");
            // 
            // CTMNCacLoaiQD
            // 
            this.CTMNCacLoaiQD.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.kỷLuậtToolStripMenuItem,
            this.tăngHsLươngToolStripMenuItem,
            this.thăngCấpToolStripMenuItem,
            this.nângHscmToolStripMenuItem,
            this.thôiViệcToolStripMenuItem});
            this.CTMNCacLoaiQD.Name = "CTMNCacLoaiQD";
            this.CTMNCacLoaiQD.Size = new System.Drawing.Size(151, 136);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(150, 22);
            this.toolStripMenuItem2.Text = "Khen thưởng";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // kỷLuậtToolStripMenuItem
            // 
            this.kỷLuậtToolStripMenuItem.Name = "kỷLuậtToolStripMenuItem";
            this.kỷLuậtToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.kỷLuậtToolStripMenuItem.Text = "Kỷ luật";
            this.kỷLuậtToolStripMenuItem.Click += new System.EventHandler(this.kỷLuậtToolStripMenuItem_Click);
            // 
            // tăngHsLươngToolStripMenuItem
            // 
            this.tăngHsLươngToolStripMenuItem.Name = "tăngHsLươngToolStripMenuItem";
            this.tăngHsLươngToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.tăngHsLươngToolStripMenuItem.Text = "Tăng hs lương";
            this.tăngHsLươngToolStripMenuItem.Click += new System.EventHandler(this.tăngHsLươngToolStripMenuItem_Click);
            // 
            // thăngCấpToolStripMenuItem
            // 
            this.thăngCấpToolStripMenuItem.Name = "thăngCấpToolStripMenuItem";
            this.thăngCấpToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.thăngCấpToolStripMenuItem.Text = "Thăng cấp";
            this.thăngCấpToolStripMenuItem.Click += new System.EventHandler(this.thăngCấpToolStripMenuItem_Click);
            // 
            // nângHscmToolStripMenuItem
            // 
            this.nângHscmToolStripMenuItem.Name = "nângHscmToolStripMenuItem";
            this.nângHscmToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.nângHscmToolStripMenuItem.Text = "Nâng hscm";
            this.nângHscmToolStripMenuItem.Click += new System.EventHandler(this.nângHscmToolStripMenuItem_Click);
            // 
            // thôiViệcToolStripMenuItem
            // 
            this.thôiViệcToolStripMenuItem.Name = "thôiViệcToolStripMenuItem";
            this.thôiViệcToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.thôiViệcToolStripMenuItem.Text = "Thôi việc";
            this.thôiViệcToolStripMenuItem.Click += new System.EventHandler(this.thôiViệcToolStripMenuItem_Click);
            // 
            // SF210
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 442);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "SF210";
            this.Text = "CÁC LOẠI QUYẾT ĐỊNH";
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            this.CTMNCacLoaiQD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TreeView treeInfo;
        private System.Windows.Forms.ImageList imageList1;
        private Library.HRMGrigouping GrdData;
        private Library.Controls.HRMContextMenustrip CTMNCacLoaiQD;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem kỷLuậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tăngHsLươngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thăngCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nângHscmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thôiViệcToolStripMenuItem;
    }
}