using Library.Controls;
namespace HRM.BaseForms
{
    partial class frmReportBase
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReportBase));
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.formulaBar1 = new SpreadsheetGear.Windows.Forms.FormulaBar();
            this.workbookView = new SpreadsheetGear.Windows.Forms.WorkbookView();
            this.pnlMain = new Library.Controls.HRMPanel();
            this.tollstripButton = new Syncfusion.Windows.Forms.Tools.ToolStripEx();
            this.btnProcess = new System.Windows.Forms.ToolStripButton();
            this.btnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAdd = new System.Windows.Forms.ToolStripButton();
            this.btnDelete = new System.Windows.Forms.ToolStripButton();
            this.btnEditExcel = new System.Windows.Forms.ToolStripButton();
            this.btnExcel = new System.Windows.Forms.ToolStripButton();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.btnExcelTemplate = new System.Windows.Forms.ToolStripButton();
            this.btnPrintTemplate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.hrmPanel1 = new Library.Controls.HRMPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.hrmPanel3 = new Library.Controls.HRMPanel();
            this.hrmPanel2 = new Library.Controls.HRMPanel();
            this.pnlMain.SuspendLayout();
            this.tollstripButton.SuspendLayout();
            this.hrmPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.hrmPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 6);
            // 
            // formulaBar1
            // 
            this.formulaBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaBar1.Location = new System.Drawing.Point(0, 0);
            this.formulaBar1.Name = "formulaBar1";
            this.formulaBar1.Size = new System.Drawing.Size(998, 27);
            this.formulaBar1.TabIndex = 0;
            this.formulaBar1.TabStop = false;
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.Location = new System.Drawing.Point(0, 27);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(998, 241);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Controls.Add(this.workbookView);
            this.pnlMain.Controls.Add(this.formulaBar1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 106);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(998, 268);
            this.pnlMain.TabIndex = 5;
            // 
            // tollstripButton
            // 
            this.tollstripButton.AutoSize = false;
            this.tollstripButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tollstripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tollstripButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tollstripButton.Image = null;
            this.tollstripButton.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnProcess,
            this.btnSearch,
            this.toolStripSeparator1,
            this.btnAdd,
            this.btnDelete,
            this.btnEditExcel,
            this.btnExcel,
            this.btnPrint,
            this.toolStripSeparator4,
            this.btnExcelTemplate,
            this.btnPrintTemplate,
            this.toolStripSeparator5,
            this.btnClose});
            this.tollstripButton.Location = new System.Drawing.Point(0, 0);
            this.tollstripButton.Name = "tollstripButton";
            this.tollstripButton.ShowCaption = false;
            this.tollstripButton.ShowItemToolTips = true;
            this.tollstripButton.Size = new System.Drawing.Size(998, 43);
            this.tollstripButton.TabIndex = 1;
            // 
            // btnProcess
            // 
            this.btnProcess.Image = global::HRM.Properties.Resources.Process;
            this.btnProcess.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnProcess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(91, 40);
            this.btnProcess.Text = " Process";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::HRM.Properties.Resources.search;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 40);
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // btnAdd
            // 
            this.btnAdd.Image = global::HRM.Properties.Resources.AddItem;
            this.btnAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(76, 40);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.ToolTipText = "Thêm|Ctr+N";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::HRM.Properties.Resources.delete1;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 40);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.ToolTipText = "Xóa|Ctr+D";
            // 
            // btnEditExcel
            // 
            this.btnEditExcel.Image = global::HRM.Properties.Resources.Excel_edit;
            this.btnEditExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnEditExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditExcel.Name = "btnEditExcel";
            this.btnEditExcel.Size = new System.Drawing.Size(97, 40);
            this.btnEditExcel.Text = "Edit Excel";
            this.btnEditExcel.ToolTipText = "Lưu|Ctr+S";
            // 
            // btnExcel
            // 
            this.btnExcel.Image = global::HRM.Properties.Resources.excel;
            this.btnExcel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(101, 40);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.ToolTipText = "Xuất excel|Ctr+E";
            this.btnExcel.Visible = false;
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::HRM.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(57, 40);
            this.btnPrint.Text = "In";
            this.btnPrint.ToolTipText = "In|Ctr+P";
            this.btnPrint.Visible = false;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 43);
            this.toolStripSeparator4.Visible = false;
            // 
            // btnExcelTemplate
            // 
            this.btnExcelTemplate.Image = global::HRM.Properties.Resources.Excel_48;
            this.btnExcelTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnExcelTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnExcelTemplate.Name = "btnExcelTemplate";
            this.btnExcelTemplate.Size = new System.Drawing.Size(159, 40);
            this.btnExcelTemplate.Text = "Xuất Excel Template";
            // 
            // btnPrintTemplate
            // 
            this.btnPrintTemplate.Image = global::HRM.Properties.Resources.Printer6;
            this.btnPrintTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintTemplate.Name = "btnPrintTemplate";
            this.btnPrintTemplate.Size = new System.Drawing.Size(110, 40);
            this.btnPrintTemplate.Text = "In Template";
            this.btnPrintTemplate.ToolTipText = "In Template";
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 43);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(76, 40);
            this.btnClose.Text = "Đóng";
            this.btnClose.ToolTipText = "Đóng|Esc";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // hrmPanel1
            // 
            this.hrmPanel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmPanel1.Controls.Add(this.pnlMain);
            this.hrmPanel1.Controls.Add(this.panel1);
            this.hrmPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmPanel1.Location = new System.Drawing.Point(0, 0);
            this.hrmPanel1.Name = "hrmPanel1";
            this.hrmPanel1.Size = new System.Drawing.Size(998, 374);
            this.hrmPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.hrmPanel3);
            this.panel1.Controls.Add(this.hrmPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(998, 106);
            this.panel1.TabIndex = 6;
            // 
            // hrmPanel3
            // 
            this.hrmPanel3.BackColor = System.Drawing.Color.Transparent;
            this.hrmPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmPanel3.Location = new System.Drawing.Point(0, 43);
            this.hrmPanel3.Name = "hrmPanel3";
            this.hrmPanel3.Size = new System.Drawing.Size(998, 63);
            this.hrmPanel3.TabIndex = 3;
            // 
            // hrmPanel2
            // 
            this.hrmPanel2.BackColor = System.Drawing.Color.Transparent;
            this.hrmPanel2.Controls.Add(this.tollstripButton);
            this.hrmPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.hrmPanel2.Location = new System.Drawing.Point(0, 0);
            this.hrmPanel2.Name = "hrmPanel2";
            this.hrmPanel2.Size = new System.Drawing.Size(998, 43);
            this.hrmPanel2.TabIndex = 2;
            // 
            // frmReportBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(998, 374);
            this.Controls.Add(this.hrmPanel1);
            this.Name = "frmReportBase";
            this.pnlMain.ResumeLayout(false);
            this.tollstripButton.ResumeLayout(false);
            this.tollstripButton.PerformLayout();
            this.hrmPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.hrmPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected HRMPanel pnlMain;
        protected Syncfusion.Windows.Forms.Tools.ToolStripEx tollstripButton;
        protected System.Windows.Forms.ToolStripButton btnSearch;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripButton btnAdd;
        protected System.Windows.Forms.ToolStripButton btnDelete;
        protected System.Windows.Forms.ToolStripButton btnEditExcel;
        protected System.Windows.Forms.ToolStripButton btnExcel;
        protected System.Windows.Forms.ToolStripButton btnPrint;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        protected System.Windows.Forms.ToolStripButton btnClose;
        protected HRMPanel hrmPanel1;
        protected System.Windows.Forms.Panel panel1;
        protected HRMPanel hrmPanel3;
        protected HRMPanel hrmPanel2;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.ToolStripButton btnExcelTemplate;
        protected System.Windows.Forms.ToolStripButton btnPrintTemplate;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        protected System.Windows.Forms.ToolStripButton btnProcess;
        private SpreadsheetGear.Windows.Forms.WorkbookView workbookView;
        private SpreadsheetGear.Windows.Forms.FormulaBar formulaBar1;
    }
}
