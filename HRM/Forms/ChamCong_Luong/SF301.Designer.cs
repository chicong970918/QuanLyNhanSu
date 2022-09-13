namespace HRM.Forms.ChamCong_Luong
{
    partial class SF301
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbThang = new Library.Controls.HRMLabel();
            this.lblNam = new Library.Controls.HRMLabel();
            this.txtThang = new Library.Controls.HRMIntergerTextBox(this.components);
            this.lblPhongBan = new Library.Controls.HRMLabel();
            this.cboPhongBan = new Library.Controls.HRMCombobox();
            this.GrdData = new Library.HRMGrigouping();
            this.txtNam = new Library.Controls.HRMInputNumberTextBox();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Margin = new System.Windows.Forms.Padding(34, 31, 34, 31);
            this.panel2.Size = new System.Drawing.Size(1408, 517);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 119F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbThang, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblNam, 5, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtThang, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblPhongBan, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.cboPhongBan, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.GrdData, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtNam, 6, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 6F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1408, 517);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbThang
            // 
            this.lbThang.AutoSize = true;
            this.lbThang.BackColor = System.Drawing.Color.Transparent;
            this.lbThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbThang.IsRequired = true;
            this.lbThang.Location = new System.Drawing.Point(679, 6);
            this.lbThang.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbThang.Name = "lbThang";
            this.lbThang.Size = new System.Drawing.Size(73, 31);
            this.lbThang.TabIndex = 2;
            this.lbThang.Text = "Tháng";
            this.lbThang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNam
            // 
            this.lblNam.AutoSize = true;
            this.lblNam.BackColor = System.Drawing.Color.Transparent;
            this.lblNam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNam.IsRequired = true;
            this.lblNam.Location = new System.Drawing.Point(879, 6);
            this.lblNam.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNam.Name = "lblNam";
            this.lblNam.Size = new System.Drawing.Size(68, 31);
            this.lblNam.TabIndex = 3;
            this.lblNam.Text = "Năm";
            this.lblNam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtThang
            // 
            this.txtThang.BeforeTouchSize = new System.Drawing.Size(120, 26);
            this.txtThang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtThang.IntegerValue = ((long)(1));
            this.txtThang.Location = new System.Drawing.Point(757, 7);
            this.txtThang.Margin = new System.Windows.Forms.Padding(1);
            this.txtThang.MaxValue = ((long)(12));
            this.txtThang.MinValue = ((long)(1));
            this.txtThang.Name = "txtThang";
            this.txtThang.Size = new System.Drawing.Size(117, 26);
            this.txtThang.TabIndex = 4;
            this.txtThang.Text = "1";
            this.txtThang.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPhongBan
            // 
            this.lblPhongBan.AutoSize = true;
            this.lblPhongBan.BackColor = System.Drawing.Color.Transparent;
            this.lblPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPhongBan.IsRequired = true;
            this.lblPhongBan.Location = new System.Drawing.Point(341, 6);
            this.lblPhongBan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhongBan.Name = "lblPhongBan";
            this.lblPhongBan.Size = new System.Drawing.Size(114, 31);
            this.lblPhongBan.TabIndex = 7;
            this.lblPhongBan.Text = "Phòng ban";
            this.lblPhongBan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboPhongBan
            // 
            this.cboPhongBan.BeforeTouchSize = new System.Drawing.Size(214, 26);
            this.cboPhongBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cboPhongBan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPhongBan.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboPhongBan.Location = new System.Drawing.Point(460, 7);
            this.cboPhongBan.Margin = new System.Windows.Forms.Padding(1);
            this.cboPhongBan.Name = "cboPhongBan";
            this.cboPhongBan.Size = new System.Drawing.Size(214, 26);
            this.cboPhongBan.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007Outlook;
            this.cboPhongBan.TabIndex = 8;
            this.cboPhongBan.ThemeName = "Office2007Outlook";
            // 
            // GrdData
            // 
            this.GrdData.AlphaBlendSelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.BackColor = System.Drawing.Color.White;
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.tableLayoutPanel1.SetColumnSpan(this.GrdData, 8);
            this.GrdData.DataSource = this.brscGrdData;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.GrdData.Location = new System.Drawing.Point(4, 41);
            this.GrdData.Margin = new System.Windows.Forms.Padding(4);
            this.GrdData.Name = "GrdData";
            this.tableLayoutPanel1.SetRowSpan(this.GrdData, 2);
            this.GrdData.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.GrdData.ShowOrdinalNumber = true;
            this.GrdData.Size = new System.Drawing.Size(1400, 472);
            this.GrdData.TabIndex = 6;
            this.GrdData.TableDescriptor.AllowEdit = false;
            this.GrdData.TableDescriptor.AllowNew = false;
            this.GrdData.TableDescriptor.AllowRemove = false;
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            this.GrdData.TableDescriptor.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.UseRightToLeftCompatibleTextBox = true;
            // 
            // txtNam
            // 
            this.txtNam.BeforeTouchSize = new System.Drawing.Size(120, 26);
            this.txtNam.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNam.Location = new System.Drawing.Point(952, 7);
            this.txtNam.Margin = new System.Windows.Forms.Padding(1);
            this.txtNam.MaxLength = 4;
            this.txtNam.Name = "txtNam";
            this.txtNam.Size = new System.Drawing.Size(115, 26);
            this.txtNam.TabIndex = 9;
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // SF301
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1408, 551);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "SF301";
            this.Text = "TỔNG HỢP CHẤM CÔNG THEO PHÒNG BAN";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtThang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhongBan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ImageList imageList1;
        private Library.Controls.HRMLabel lbThang;
        private Library.Controls.HRMLabel lblNam;
        private Library.Controls.HRMIntergerTextBox txtThang;
        private Library.HRMGrigouping GrdData;
        private Library.Controls.HRMLabel lblPhongBan;
        private Library.Controls.HRMCombobox cboPhongBan;
        private Library.Controls.HRMInputNumberTextBox txtNam;
    }
}