namespace HRM.Forms.TuyenDung
{
    partial class SF115
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SF115));
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Size = new System.Drawing.Size(379, 135);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(379, 156);
            // 
            // GrdData
            // 
            this.GrdData.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
            this.GrdData.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.GrdData.ChildGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrdData.Size = new System.Drawing.Size(379, 156);
            this.GrdData.TableDescriptor.Appearance.AlternateRecordFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.MintCream);
            this.GrdData.TableDescriptor.Name = "";
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaption = true;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            // 
            // SF110
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 325);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "SF110";
            this.Text = "LÀM HỢP ĐỒNG";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GrdData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.brscGrdData)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}