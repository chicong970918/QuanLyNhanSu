namespace HRM.BaseForms
{
    partial class GridBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GridBaseForm));
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.brscGrdData = new System.Windows.Forms.BindingSource(this.components);
            this.tollstripButton.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.SuspendLayout();
            // 
            // tollstripButton
            // 
            this.tollstripButton.AutoSize = false;
            this.tollstripButton.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tollstripButton.ForeColor = System.Drawing.Color.MidnightBlue;
            this.tollstripButton.Image = null;
            this.tollstripButton.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.btnProcess.Size = new System.Drawing.Size(81, 31);
            this.btnProcess.Text = "Xử lý";
            // 
            // btnSearch
            // 
            this.btnSearch.Image = global::HRM.Properties.Resources.search;
            this.btnSearch.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(72, 31);
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
            this.btnAdd.Size = new System.Drawing.Size(105, 31);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.ToolTipText = "Thêm|Ctr+N";
            // 
            // btnDelete
            // 
            this.btnDelete.Image = global::HRM.Properties.Resources.delete1;
            this.btnDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(73, 31);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.ToolTipText = "Xóa|Ctr+D";
            // 
            // btnSave
            // 
            this.btnSave.Image = global::HRM.Properties.Resources.save4;
            this.btnSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 31);
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
            this.btnExcel.Size = new System.Drawing.Size(122, 31);
            this.btnExcel.Text = "Xuất excel";
            this.btnExcel.ToolTipText = "Xuất excel|Ctr+E";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::HRM.Properties.Resources.printer;
            this.btnPrint.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(64, 31);
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
            this.btnExcelTemplate.Size = new System.Drawing.Size(199, 31);
            this.btnExcelTemplate.Text = "Xuất Excel Biểu mẫu";
            this.btnExcelTemplate.ToolTipText = "Xuất Excel Template";
            // 
            // btnPrintTemplate
            // 
            this.btnPrintTemplate.Image = global::HRM.Properties.Resources.Printer6;
            this.btnPrintTemplate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnPrintTemplate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintTemplate.Name = "btnPrintTemplate";
            this.btnPrintTemplate.Size = new System.Drawing.Size(136, 31);
            this.btnPrintTemplate.Text = "In Biểu mẫu";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 34);
            // 
            // btnClose
            // 
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 36);
            this.btnClose.Text = "Đóng";
            this.btnClose.ToolTipText = "Đóng|Esc";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 34);
            this.panel2.Margin = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1053, 400);
            this.panel2.TabIndex = 3;
            // 
            // GridBaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionForeColor = System.Drawing.Color.Transparent;
            this.ClientSize = new System.Drawing.Size(1053, 434);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tollstripButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.Name = "GridBaseForm";
            this.Text = "DanhMucBase";
            this.tollstripButton.ResumeLayout(false);
            this.tollstripButton.PerformLayout();
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

        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.BindingSource brscGrdData;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.ToolStripButton btnExcelTemplate;
        protected System.Windows.Forms.ToolStripButton btnPrintTemplate;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        protected System.Windows.Forms.ToolStripButton btnProcess;
         

    }
}
