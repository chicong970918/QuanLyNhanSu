namespace HRM.Forms 
{
    partial class SF001
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
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor4 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            this.comboDropDown1 = new Syncfusion.Windows.Forms.Tools.ComboDropDown();
            this.gridListControl1 = new Syncfusion.Windows.Forms.Grid.GridListControl();
            this.hrmGrigouping1 = new Library.HRMGrigouping();
            this.hrmAutoCompleteTextBox1 = new Library.Controls.HRMAutoCompleteTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.comboDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmGrigouping1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmAutoCompleteTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comboDropDown1
            // 
            this.comboDropDown1.Location = new System.Drawing.Point(68, 56);
            this.comboDropDown1.Name = "comboDropDown1";
            this.comboDropDown1.PopupControl = this.gridListControl1;
            this.comboDropDown1.Size = new System.Drawing.Size(212, 21);
            this.comboDropDown1.TabIndex = 2;
            // 
            // gridListControl1
            // 
            this.gridListControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.gridListControl1.DisplayMember = "LongName";
            this.gridListControl1.FillLastColumn = true;
            this.gridListControl1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.gridListControl1.ItemHeight = 17;
            this.gridListControl1.Location = new System.Drawing.Point(68, 83);
            this.gridListControl1.MultiColumn = true;
            this.gridListControl1.Name = "gridListControl1";
            this.gridListControl1.Properties.BackgroundColor = System.Drawing.SystemColors.Window;
            this.gridListControl1.SelectedIndex = -1;
            this.gridListControl1.Size = new System.Drawing.Size(212, 176);
            this.gridListControl1.TabIndex = 3;
            this.gridListControl1.ThemesEnabled = true;
            this.gridListControl1.TopIndex = 0;
            this.gridListControl1.ValueMember = "TenCoSo";
            // 
            // hrmGrigouping1
            // 
            this.hrmGrigouping1.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.hrmGrigouping1.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.hrmGrigouping1.BackColor = System.Drawing.Color.White;
            this.hrmGrigouping1.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.hrmGrigouping1.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.hrmGrigouping1.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.hrmGrigouping1.Location = new System.Drawing.Point(546, 12);
            this.hrmGrigouping1.Name = "hrmGrigouping1";
            this.hrmGrigouping1.ShowOrdinalNumber = true;
            this.hrmGrigouping1.Size = new System.Drawing.Size(212, 188);
            this.hrmGrigouping1.TabIndex = 0;
            this.hrmGrigouping1.TableDescriptor.AllowEdit = false;
            this.hrmGrigouping1.TableDescriptor.AllowNew = false;
            this.hrmGrigouping1.TableDescriptor.AllowRemove = false;
            this.hrmGrigouping1.TableDescriptor.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor3.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor3.HeaderText = "Tên cơ sở";
            gridColumnDescriptor3.MappingName = "TenCoSo";
            gridColumnDescriptor3.Width = 104;
            gridColumnDescriptor4.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor4.HeaderText = "MaCoSo";
            gridColumnDescriptor4.Width = 89;
            this.hrmGrigouping1.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor3,
            gridColumnDescriptor4});
            this.hrmGrigouping1.TableDescriptor.ForceEmptyRelations = true;
            this.hrmGrigouping1.TableDescriptor.Name = "";
            this.hrmGrigouping1.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.ShowCaptionPlusMinus = false;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.ShowCaptionSummaryCells = false;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.ShowColumnHeaders = true;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.ShowGroupFooter = false;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.ShowGroupHeader = false;
            this.hrmGrigouping1.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.hrmGrigouping1.TableDescriptor.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("TenCoSo"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Column1")});
            this.hrmGrigouping1.TableOptions.RowHeaderWidth = 40;
            this.hrmGrigouping1.TableOptions.ShowRowHeader = true;
            this.hrmGrigouping1.TableOptions.SummaryRowHeight = 23;
            this.hrmGrigouping1.Text = "hrmGrigouping1";
            this.hrmGrigouping1.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.hrmGrigouping1.VersionInfo = "1.0.0.0";
            this.hrmGrigouping1.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(this.hrmGrigouping1_TableControlCellClick);
            // 
            // hrmAutoCompleteTextBox1
            // 
            this.hrmAutoCompleteTextBox1.AutoCompleteDataSource = null;
            this.hrmAutoCompleteTextBox1.AutoCompleteMode = Syncfusion.Windows.Forms.Tools.AutoCompleteModes.MultiSuggestExtended;
            this.hrmAutoCompleteTextBox1.Location = new System.Drawing.Point(355, 213);
            this.hrmAutoCompleteTextBox1.Name = "hrmAutoCompleteTextBox1";
            this.hrmAutoCompleteTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.hrmAutoCompleteTextBox1.Size = new System.Drawing.Size(100, 20);
            this.hrmAutoCompleteTextBox1.TabIndex = 4;
            this.hrmAutoCompleteTextBox1.Text = "hrmAutoCompleteTextBox1";
            // 
            // SF001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 472);
            this.Controls.Add(this.hrmAutoCompleteTextBox1);
            this.Controls.Add(this.gridListControl1);
            this.Controls.Add(this.comboDropDown1);
            this.Controls.Add(this.hrmGrigouping1);
            this.Name = "SF001";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SF001_Load);
            ((System.ComponentModel.ISupportInitialize)(this.comboDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridListControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmGrigouping1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hrmAutoCompleteTextBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Library.HRMGrigouping hrmGrigouping1;
        private Syncfusion.Windows.Forms.Tools.ComboDropDown comboDropDown1;
        private Syncfusion.Windows.Forms.Grid.GridListControl gridListControl1;
        private Library.Controls.HRMAutoCompleteTextBox hrmAutoCompleteTextBox1;
    }
}