namespace HRM.BaseForms
{
    partial class TuyenDungDetailBaseForm
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
            this.tollstripButton = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnProcess = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcelTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnPrintTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.panelIner = new System.Windows.Forms.Panel();
            this.paneChiTiet = new System.Windows.Forms.Panel();
            this.panelLuoi = new System.Windows.Forms.Panel();
            this.GrdData = new Library.HRMGrigouping();
            this.brscGrdData = new System.Windows.Forms.BindingSource(this.components);
            this.panelLoc = new System.Windows.Forms.Panel();
            this.tollstripButton.SuspendLayout();
            this.panelIner.SuspendLayout();
            this.panelLuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.SuspendLayout();
            // 
            // tollstripButton
            // 
            this.tollstripButton.AutoSize = false;
            this.tollstripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tollstripButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tollstripButton.Image = null;
            this.tollstripButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProcess,
            this.btnSearch,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnDelete,
            this.btnSave,
            this.toolStripSeparator2,
            this.btnExcel,
            this.btnPrint,
            this.toolStripSeparator4,
            this.btnExcelTemplate,
            this.btnPrintTemplate,
            this.toolStripSeparator3,
            this.btnClose});
            this.tollstripButton.Location = new System.Drawing.Point(0, 0);
            this.tollstripButton.Name = "tollstripButton";
            this.tollstripButton.ShowCaption = false;
            this.tollstripButton.ShowItemToolTips = true;
            this.tollstripButton.Size = new System.Drawing.Size(1053, 34);
            this.tollstripButton.TabIndex = 0;
            // 
            // btnProcess
            // 
            this.btnProcess.Image = global::HRM.Properties.Resources.Process;
            this.btnProcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(71, 31);
            this.btnProcess.Text = "Xử lý";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::HRM.Properties.Resources.search;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 31);
            this.btnSearch.Text = "Tìm";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 34);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::HRM.Properties.Resources.AddItem;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 31);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.ToolTipText = "Thêm|Ctr+N";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::HRM.Properties.Resources.delete1;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 31);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.ToolTipText = "Xóa|Ctr+D";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::HRM.Properties.Resources.save4;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(65, 31);
            this.btnSave.Text = "Lưu";
            this.btnSave.ToolTipText = "Lưu|Ctr+S";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 34);
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::HRM.Properties.Resources.excel;
            this.btnExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(101, 31);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.ToolTipText = "Xuất excel|Ctr+E";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::HRM.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 31);
            this.btnPrint.Text = "In";
            this.btnPrint.ToolTipText = "In|Ctr+P";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 34);
            // 
            // btnExcelTemplate
            // 
            this.btnExcelTemplate.Image = global::HRM.Properties.Resources.Excel_48;
            this.btnExcelTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcelTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcelTemplate.Name = "btnExcelTemplate";
            this.btnExcelTemplate.Size = new System.Drawing.Size(158, 31);
            this.btnExcelTemplate.Text = "Xuất Excel Biểu mẫu";
            // 
            // btnPrintTemplate
            // 
            this.btnPrintTemplate.Image = global::HRM.Properties.Resources.Printer6;
            this.btnPrintTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintTemplate.Name = "btnPrintTemplate";
            this.btnPrintTemplate.Size = new System.Drawing.Size(109, 31);
            this.btnPrintTemplate.Text = "In Biểu mẫu";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::HRM.Properties.Resources.exit;
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 31);
            this.btnClose.Text = "Đóng";
            this.btnClose.ToolTipText = "Đóng|Esc";
            // 
            // panelIner
            // 
            this.panelIner.BackColor = System.Drawing.Color.Transparent;
            this.panelIner.Controls.Add(this.paneChiTiet);
            this.panelIner.Controls.Add(this.panelLuoi);
            this.panelIner.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelIner.Location = new System.Drawing.Point(149, 34);
            this.panelIner.Margin = new System.Windows.Forms.Padding(4);
            this.panelIner.Name = "panelIner";
            this.panelIner.Size = new System.Drawing.Size(904, 400);
            this.panelIner.TabIndex = 2;
            // 
            // paneChiTiet
            // 
            this.paneChiTiet.Location = new System.Drawing.Point(0, 0);
            this.paneChiTiet.Name = "paneChiTiet";
            this.paneChiTiet.Size = new System.Drawing.Size(904, 141);
            this.paneChiTiet.TabIndex = 4;
            // 
            // panelLuoi
            // 
            this.panelLuoi.BackColor = System.Drawing.Color.Transparent;
            this.panelLuoi.Controls.Add(this.GrdData);
            this.panelLuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLuoi.Location = new System.Drawing.Point(0, 141);
            this.panelLuoi.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panelLuoi.Name = "panelLuoi";
            this.panelLuoi.Size = new System.Drawing.Size(904, 259);
            this.panelLuoi.TabIndex = 3;
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.BackColor = System.Drawing.Color.White;
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.GrdData.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.GrdData.Location = new System.Drawing.Point(0, 0);
            this.GrdData.Margin = new System.Windows.Forms.Padding(1);
            this.GrdData.Name = "GrdData";
            this.GrdData.ShowOrdinalNumber = true;
            this.GrdData.Size = new System.Drawing.Size(904, 259);
            this.GrdData.TabIndex = 0;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.GrdData.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaption = true;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.Text = "hrmGrigouping1";
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.VersionInfo = "1.0.0.0";
            // 
            // panelLoc
            // 
            this.panelLoc.BackColor = System.Drawing.Color.Transparent;
            this.panelLoc.Location = new System.Drawing.Point(0, 34);
            this.panelLoc.Name = "panelLoc";
            this.panelLoc.Size = new System.Drawing.Size(149, 400);
            this.panelLoc.TabIndex = 4;
            // 
            // TuyenDungDetailBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 434);
            this.Controls.Add(this.panelLoc);
            this.Controls.Add(this.panelIner);
            this.Controls.Add(this.tollstripButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TuyenDungDetailBaseForm";
            this.Text = "TUYENDUNGBASEFORM";
            this.tollstripButton.ResumeLayout(false);
            this.tollstripButton.PerformLayout();
            this.panelIner.ResumeLayout(false);
            this.panelLuoi.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected Syncfusion.Windows.Forms.Tools.ToolStripEx tollstripButton;
        protected System.Windows.Forms.ToolStripButton btnSearch;
        protected System.Windows.Forms.ToolStripButton btnAdd;
        protected System.Windows.Forms.ToolStripButton btnDelete;
        protected System.Windows.Forms.ToolStripButton btnSave;
        protected System.Windows.Forms.ToolStripButton btnExcel;
        protected System.Windows.Forms.ToolStripButton btnPrint;
        protected System.Windows.Forms.ToolStripButton btnClose;
        protected System.Windows.Forms.Panel panelIner;

        protected System.Windows.Forms.Panel panelLuoi;
        protected Library.HRMGrigouping GrdData;
        protected System.Windows.Forms.BindingSource brscGrdData;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.Panel paneChiTiet;
        protected System.Windows.Forms.Panel panelLoc;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        protected System.Windows.Forms.ToolStripButton btnExcelTemplate;
        protected System.Windows.Forms.ToolStripButton btnPrintTemplate;
        protected System.Windows.Forms.ToolStripButton btnProcess;
         
    }
}