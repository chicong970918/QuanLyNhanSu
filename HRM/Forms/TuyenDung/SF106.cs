using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.Class;
using HRM.DataAccess.TuyenDung;
using HRM.Entities;

namespace HRM.Forms.TuyenDung
{
    /// <summary>
    /// 
    /// </summary>
    /// <Author>LONG LY</Author>
    /// <Date>09/06/2011</Date>
    public partial class SF106 : frmReportBase
    {

        #region  Variable and Constructor
        ThongBaoTuyenDungBLL _busThongBao = null;

        public SF106()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Mades the report.
        /// </summary>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>09/06/2011</Date>
        protected override frmReportBase.MadeReportResults MadeReport()
        {

            MadeReportResults result = new MadeReportResults();
            ExcelExport excel = new ExcelExport();
            List<IGrouping<int, TD_PhieuYeuCauTuyenDung>> list = new List<IGrouping<int, TD_PhieuYeuCauTuyenDung>>();

            string path = string.Empty;

            if (Library.Class.CommonUtil.IsInt(txtNam.Text) > 0 && cboQuy.SelectedItem != null)
            {
                list = _busThongBao.GetPhieuYeuCauTuyenDungByCondition(((DM_Quy)cboQuy.SelectedItem).Ten, Library.Class.CommonUtil.IsInt(txtNam.Text));
            }
            excel.ExportThongBaoTuyenDung(list, ref path, false);
            result.FileName = path;
            result.FreezeColumn = -1;
            result.FreezeRow = -1;
            return result;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Inits the form.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>09/06/2011</Date>
        private void InitForm()
        {
            _busThongBao = new ThongBaoTuyenDungBLL();
            this.btnProcess.Visible = false;
            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();
            // Load data
            LoadComboBox();
        }

       

        /// <summary>
        /// Loads the da ta.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>09/06/2011</Date>
        private void LoadDaTa()
        {



        }
        /// <summary>
        /// Loads the combo box.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>09/06/2011</Date>
        private void LoadComboBox()
        {

            cboQuy.DataSource = _busThongBao.GetAllQuy();
            cboQuy.DisplayMember = "Ten";
            cboQuy.ValueMember = "Id";

        }

        #endregion

        #region Event
        
        #endregion
    }
}
