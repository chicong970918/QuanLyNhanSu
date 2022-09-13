using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.Entities;
using HRM.DataAccess;
using HRM.BaseForms;
using HRM.Forms;
using HRM.DataAccess.Catalogs;
using HRM.DanhMuc;
using HRM.Class;

namespace HRM
{
    public partial class Form1 : BaseForm
    {
        private System.Windows.Forms.TextBox textLog;
        private Library.HRMCheckBoxColumn chkHocPhi;
        public Form1()
        {
            InitializeComponent();
            this.danhMucCoSoSelector1.textLog = this.textLog;
            DanhMucPhongBanBLL _buss = new DanhMucPhongBanBLL();
            hrmGrigouping1.DataSource = _buss.LoadData();
            cbocoso.DataSource = _buss.LoadData();
            cbocoso.DisplayMember = "TenCapTuyenDung";
            chkHocPhi = new Library.HRMCheckBoxColumn(this.hrmGrigouping1, string.Empty, 0) { UniqueProperty = "Id" };
            UICommon.StartLoading();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DanhMucPhongBanBLL _buss = new DanhMucPhongBanBLL();
            //danhMucCoSoSelector1.DataBindings.Add("Text",_buss.LoadData(),"TenCoSo");
            // dataGridView1.DataSource = _buss.dsdsds();
           // SF001 frm = new SF001();
          //  frm.Show();
        }
        interface IChildSampleControls
        {
            Control GetPrimaryItem();
        }
    }
}
