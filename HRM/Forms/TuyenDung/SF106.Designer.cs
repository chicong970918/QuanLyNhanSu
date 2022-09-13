namespace HRM.Forms.TuyenDung
{
    partial class SF106
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF106));
            this.workbookView = new SpreadsheetGear.Windows.Forms.WorkbookView();
            this.formulaBar1 = new SpreadsheetGear.Windows.Forms.FormulaBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.hrmLabel1 = new Library.Controls.HRMLabel();
            this.hrmLabel2 = new Library.Controls.HRMLabel();
            this.cboQuy = new Library.Controls.HRMCombobox();
            this.txtNam = new Library.Controls.HRMIntergerTextBox(this.components);
            this.pnlMain.SuspendLayout();
            this.hrmPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.hrmPanel3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Location = new System.Drawing.Point(0, 108);
            this.pnlMain.Size = new System.Drawing.Size(779, 282);
            // 
            // hrmPanel1
            // 
            this.hrmPanel1.Size = new System.Drawing.Size(779, 390);
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(779, 108);
            // 
            // hrmPanel3
            // 
            this.hrmPanel3.Controls.Add(this.groupBox1);
            this.hrmPanel3.Size = new System.Drawing.Size(779, 65);
            // 
            // hrmPanel2
            // 
            this.hrmPanel2.Size = new System.Drawing.Size(779, 43);
            // 
            // workbookView
            // 
            this.workbookView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workbookView.Location = new System.Drawing.Point(0, 27);
            this.workbookView.Name = "workbookView";
            this.workbookView.Size = new System.Drawing.Size(779, 255);
            this.workbookView.TabIndex = 1;
            this.workbookView.WorkbookSetState = resources.GetString("workbookView.WorkbookSetState");
            // 
            // formulaBar1
            // 
            this.formulaBar1.Dock = System.Windows.Forms.DockStyle.Top;
            this.formulaBar1.Location = new System.Drawing.Point(0, 0);
            this.formulaBar1.Name = "formulaBar1";
            this.formulaBar1.Size = new System.Drawing.Size(779, 27);
            this.formulaBar1.TabIndex = 0;
            this.formulaBar1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(779, 65);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Chi tiết";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 42F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 147F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 46F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 141F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.hrmLabel2, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboQuy, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNam, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 18);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 44);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // hrmLabel1
            // 
            this.hrmLabel1.AutoSize = true;
            this.hrmLabel1.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel1.IsRequired = true;
            this.hrmLabel1.Location = new System.Drawing.Point(199, 10);
            this.hrmLabel1.Margin = new System.Windows.Forms.Padding(1);
            this.hrmLabel1.Name = "hrmLabel1";
            this.hrmLabel1.Size = new System.Drawing.Size(40, 24);
            this.hrmLabel1.TabIndex = 0;
            this.hrmLabel1.Text = "Quý";
            this.hrmLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // hrmLabel2
            // 
            this.hrmLabel2.AutoSize = true;
            this.hrmLabel2.BackColor = System.Drawing.Color.Transparent;
            this.hrmLabel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hrmLabel2.IsRequired = true;
            this.hrmLabel2.Location = new System.Drawing.Point(388, 10);
            this.hrmLabel2.Margin = new System.Windows.Forms.Padding(1);
            this.hrmLabel2.Name = "hrmLabel2";
            this.hrmLabel2.Size = new System.Drawing.Size(44, 24);
            this.hrmLabel2.TabIndex = 1;
            this.hrmLabel2.Text = "Năm";
            this.hrmLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboQuy
            // 
            this.cboQuy.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.cboQuy.Border3DStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.cboQuy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboQuy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuy.DropDownWidth = 150;
            this.cboQuy.Location = new System.Drawing.Point(240, 9);
            this.cboQuy.Margin = new System.Windows.Forms.Padding(0);
            this.cboQuy.Name = "cboQuy";
            this.cboQuy.Size = new System.Drawing.Size(147, 24);
            this.cboQuy.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.cboQuy.TabIndex = 2;
            // 
            // txtNam
            // 
            this.txtNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNam.IntegerValue = ((long)(2000));
            this.txtNam.Location = new System.Drawing.Point(434, 10);
            this.txtNam.Margin = new System.Windows.Forms.Padding(1);
            this.txtNam.MaxLength = 4;
            this.txtNam.MaxValue = ((long)(9999));
            this.txtNam.MinValue = ((long)(2000));
            this.txtNam.Multiline = true;
            this.txtNam.Name = "txtNam";
            this.txtNam.NullString = "";
            this.txtNam.Size = new System.Drawing.Size(139, 24);
            this.txtNam.TabIndex = 3;
            this.txtNam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNam.UseNullString = true;
            // 
            // SF106
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 390);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SF106";
            this.Text = "IN THÔNG BÁO TUYỂN DỤNG";
            this.pnlMain.ResumeLayout(false);
            this.hrmPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.hrmPanel3.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SpreadsheetGear.Windows.Forms.WorkbookView workbookView;
        private SpreadsheetGear.Windows.Forms.FormulaBar formulaBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Library.Controls.HRMLabel hrmLabel1;
        private Library.Controls.HRMLabel hrmLabel2;
        private Library.Controls.HRMCombobox cboQuy;
        private Library.Controls.HRMIntergerTextBox txtNam;
    }
}