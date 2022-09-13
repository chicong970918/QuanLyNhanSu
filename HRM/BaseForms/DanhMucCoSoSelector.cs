using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.Forms;
using Syncfusion.Windows.Forms.Tools;
using HRM.Entities;
using HRM.DataAccess;
using HRM.DataAccess.Catalogs;


namespace HRM.DanhMuc
{
    public partial class DanhMucCoSoSelector : System.Windows.Forms.UserControl
    {
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private Syncfusion.Windows.Forms.Tools.MultiColumnComboBox multiColumnBoundCombo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private MultiColumnComboBox multiColumnComboBox1;
        internal TextBox textLog;

        public DanhMucCoSoSelector()
        {
            InitializeComponent();
        }


        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            
            this.multiColumnBoundCombo = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.multiColumnComboBox1 = new Syncfusion.Windows.Forms.Tools.MultiColumnComboBox();
            
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnBoundCombo)).BeginInit();
          
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnComboBox1)).BeginInit();
            this.SuspendLayout();
           
           
            //this.multiColumnBoundCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //            | System.Windows.Forms.AnchorStyles.Left)
            //            | System.Windows.Forms.AnchorStyles.Right)));
            //this.multiColumnBoundCombo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            //this.multiColumnBoundCombo.DisplayMember = "TenCoSo";
            //this.multiColumnBoundCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            //this.multiColumnBoundCombo.Location = new System.Drawing.Point(16, 96);
            //this.multiColumnBoundCombo.Name = "multiColumnBoundCombo";
            //this.multiColumnBoundCombo.Size = new System.Drawing.Size(229, 21);
            //this.multiColumnBoundCombo.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            //this.multiColumnBoundCombo.TabIndex = 0;
            //this.multiColumnBoundCombo.ValueMember = "MaCoSo";
            //this.multiColumnBoundCombo.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
            //this.multiColumnBoundCombo.SelectionChangeCommitted += new System.EventHandler(this.combo_SelectionChangeCommitted);
            //this.multiColumnBoundCombo.Validated += new System.EventHandler(this.combo_Validated);
            //// 
            
            // 
            // propertyGrid1
            // 
            //this.propertyGrid1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            //this.propertyGrid1.CommandsBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(219)))));
            //this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            //this.propertyGrid1.HelpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(200)))), ((int)(((byte)(219)))));
            //this.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar;
            //this.propertyGrid1.Location = new System.Drawing.Point(3, 16);
            //this.propertyGrid1.Name = "propertyGrid1";
            //this.propertyGrid1.Size = new System.Drawing.Size(194, 269);
            //this.propertyGrid1.TabIndex = 0;
            // 
            // multiColumnComboBox1
            // 
            this.multiColumnComboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.multiColumnComboBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            this.multiColumnComboBox1.CaseSensitiveAutocomplete = true;
            this.multiColumnComboBox1.DisplayMember = "TenCoSo";
            this.multiColumnComboBox1.Location = new System.Drawing.Point(3, 3);
            this.multiColumnComboBox1.Name = "multiColumnComboBox1";
            this.multiColumnComboBox1.Size = new System.Drawing.Size(198, 21);
            this.multiColumnComboBox1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            this.multiColumnComboBox1.TabIndex = 1;
            this.multiColumnComboBox1.ValueMember = "MaCoSo";
            DanhMucPhongBanBLL _buss = new DanhMucPhongBanBLL();
            this.multiColumnComboBox1.DataSource = _buss.LoadData();
               
          
            // 
            // DanhMucCoSoSelector
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.Controls.Add(this.multiColumnComboBox1);
            this.Name = "DanhMucCoSoSelector";
            this.Size = new System.Drawing.Size(217, 31);
            this.Load += new System.EventHandler(this.ComboBoxAdvSampleControl_Load);
           
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnBoundCombo)).EndInit();
            
            ((System.ComponentModel.ISupportInitialize)(this.multiColumnComboBox1)).EndInit();
            this.ResumeLayout(false);

        }
        private void ComboBoxAdvSampleControl_Load(object sender, System.EventArgs e)
        {
            //string connectionstring = "Data Source = ..\\..\\..\\..\\..\\..\\..\\..\\..\\Common\\Data\\NorthwindIO.sdf";
            //DataTable table = new DataTable();
            //SqlCeConnection conn = new SqlCeConnection(connectionstring);
            //conn.Open();
            //SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT CompanyName, ContactName, City, Country, CustomerID FROM Customers ORDER BY CompanyName ", conn);
            //adapter.Fill(table);
            //Bind the Data Table with the MultiColumnBoundCombobox DataSource
            //DanhMucCoSoBLL _buss=new DanhMucCoSoBLL();
            //this.multiColumnBoundCombo.DataSource = _buss.LoadData();
            //this.propertyGrid1.SelectedObject = this.multiColumnBoundCombo;
            //adapter.Dispose();
            //conn.Close();
        }
        public Control GetPrimaryItem()
        {
            return this.multiColumnBoundCombo;
        }

        #region TRACE_NOTIFICATIONS
        private void combo_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (this.textLog == null)
                return;
            ComboBoxBaseDataBound c = sender as ComboBoxBaseDataBound;
            this.textLog.Text += c.Name + "'s SelectedIndexChanged to:" + c.SelectedIndex + "\r\n";
        }

        private void combo_SelectionChangeCommitted(object sender, System.EventArgs e)
        {
            if (this.textLog == null)
                return;
            ComboBoxBaseDataBound c = sender as ComboBoxBaseDataBound;
            this.textLog.Text += c.Name + "'s SelectionChangeCommitted. New index is:" + c.SelectedIndex + "\r\n";
        }

        private void combo_Validated(object sender, System.EventArgs e)
        {
            if (this.textLog == null)
                return;

            ComboBoxBaseDataBound c = sender as ComboBoxBaseDataBound;
            if (c.SelectedItem != null)
                this.textLog.Text += c.Name + "has validated the new entry. New entry is:" + c.SelectedItem.ToString() + "\r\n";
            else
                this.textLog.Text += c.Name + "has validated the new entry. New entry is:" + c.Text + "\r\n";
        }

        private void combo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.textLog == null)
                return;
            ComboBoxBaseDataBound c = sender as ComboBoxBaseDataBound;
            if (c.SelectedItem != null)
                this.textLog.Text += c.Name + "is validating the new entry:" + c.SelectedItem.ToString() + "\r\n";
            else
                this.textLog.Text += c.Name + "is validating the new entry:" + c.Text + "\r\n";
        }
        #endregion TRACE_NOTIFICATIONS

    }
}
