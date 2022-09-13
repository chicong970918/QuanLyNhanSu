using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.TuyenDung;
using HRM.Entities;
using HRM.DataAccess.Common;
using System.Data.Linq;
using Library.Class;
using HRM.Class;
using HRM.DataAccess;
using HRM.DataAccess.NguoiDung;


namespace HRM.Forms.HeThong
{
    public partial class SF904 : GridBaseForm
    {
        #region ---- Variables ----

        private QL_NhomNguoiDungBLL _busNhomNguoiDung = null;
        private DM_ManHinhBLL _busManHinh = null;
        private int _iDNhomNguoiDung = -1; 

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF904"/> class.
        /// </summary>
        public SF904()
        {
            InitializeComponent();
            InitForm();
        } 

        #endregion

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            base.SaveData();
            UICommon.StartUpdate();
            grdManHinh.EndEdit();
            bingdingManHinh.EndEdit();

            List<SP_PhanQuyenResult> PhanQuyen = this.bingdingManHinh.DataSource as List<SP_PhanQuyenResult>;

            _busManHinh.CapNhatQuyen(PhanQuyen, _iDNhomNguoiDung);

            UICommon.StopUpdate();

            UICommon.ShowSplashPanelUpdateMsg();


        }

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            this.btnAdd.Visible = false;
            this.btnSearch.Visible = false;
            this.btnDelete.Visible = false;
            this.btnExcel.Visible = false;
            this.btnExcelTemplate.Visible = false;
            this.btnPrint.Visible = false;
            this.btnPrintTemplate.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.toolStripSeparator3.Visible = false;

            _busNhomNguoiDung = new QL_NhomNguoiDungBLL();
            _busManHinh = new DM_ManHinhBLL();
            this.Load += new EventHandler(SF904_Load);
            this.bindingNhomNguoiDung.PositionChanged += new EventHandler(bindingNhomNguoiDung_PositionChanged);

        } 

        #endregion

        #region ---- Events ----

        /// <summary>
        /// Handles the PositionChanged event of the bindingNhomNguoiDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void bindingNhomNguoiDung_PositionChanged(object sender, EventArgs e)
        {
            QL_NhomNguoiDung nguoidung = bindingNhomNguoiDung.Current as QL_NhomNguoiDung;
            _iDNhomNguoiDung = ((QL_NhomNguoiDung)nguoidung).Id;
            bingdingManHinh.DataSource = _busManHinh.GetManHinhByIDNhom(nguoidung.Id);
        }

        /// <summary>
        /// Handles the Load event of the SF904 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF904_Load(object sender, EventArgs e)
        {
            bindingNhomNguoiDung.DataSource = _busNhomNguoiDung.GetAll();
            bindingNhomNguoiDung.MoveFirst();
            if (grbNhomNguoiDung.Table.Records.Count > 0)
            {
                grbNhomNguoiDung.Table.CurrentRecord = grbNhomNguoiDung.Table.Records[0];
            }
        } 

        #endregion

    }
}
