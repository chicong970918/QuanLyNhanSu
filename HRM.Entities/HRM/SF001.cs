using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.Entities;
using HRM.DataAccess;
using HRM.DataAccess.Catalogs;
using Syncfusion.Windows.Forms;

namespace HRM.Forms
{
    public partial class SF001 : BaseForm
    {
        DanhMucPhongBanBLL _buss = null;
        private BannerTextProvider bannerTextProvider1;
        public SF001()
        {
            InitializeComponent();
             // bannerTextProvider1 = new BannerTextProvider(); 
            //Syncfusion.Windows.Forms.BannerTextInfo bannerTextInfo1 = new Syncfusion.Windows.Forms.BannerTextInfo();
            //this.comboDropDown1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(242)))), ((int)(((byte)(251)))));
            //bannerTextInfo1.Text = "[Select]";
            //bannerTextInfo1.Visible = true;
            //this.bannerTextProvider1.SetBannerText(this.comboDropDown1, bannerTextInfo1);
            //this.comboDropDown1.Location = new System.Drawing.Point(233, 126);
            //this.comboDropDown1.Name = "comboDropDown2";
            //this.comboDropDown1.PopupControl = this.gridListControl1;
            //this.comboDropDown1.Size = new System.Drawing.Size(175, 21);
            //this.comboDropDown1.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
            //this.comboDropDown1.TabIndex = 4;
            this.gridListControl1.Grid.CellClick += new Syncfusion.Windows.Forms.Grid.GridCellClickEventHandler(Grid_CellClick);
          
        }

        private void SF001_Load(object sender, EventArgs e)
        {
            _buss = new DanhMucPhongBanBLL();
            hrmGrigouping1.DataSource = _buss.GetAll();
            gridListControl1.DataSource = _buss.GetAll();
            hrmAutoCompleteTextBox1.AutoCompleteDataSource = _buss.GetAll(); 
        }

        private void hrmGrigouping1_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            
        }

        void Grid_CellClick(object sender, Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs e)
        {
            if (this.gridListControl1.SelectedIndex != -1)
                this.comboDropDown1.TextBox.Text = this.gridListControl1.SelectedItem.ToString();
            else
                this.comboDropDown1.TextBox.Text = String.Empty;

            this.comboDropDown1.PopupContainer.HidePopup(PopupCloseType.Done);
        }
    }
}
