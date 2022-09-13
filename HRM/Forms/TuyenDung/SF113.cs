using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.Entities;
using HRM.DataAccess.TuyenDung;
using HRM.DataAccess.Catalogs;
using Library;

namespace HRM.Forms.TuyenDung
{
    public partial class SF113 : GridBaseForm
    {
        #region Variable and Constructor

        private TD_KeHoachThuViec _keHoach = null;
        private TD_NhanVienBLL _busNhanVien = null;
        private DanhMucPhongBanBLL _busPhongBan = null;
        private TD_YeuCauCongViecBLL _busYeuCau= null;
        private TD_ChiTietKeHoachThuViecBLL _busChiTiet = null;
        private TD_UngVienBLL _busUngVien = null;
        private HRMCheckBoxColumn _colCheckDangQuanLy;
        private HRMCheckBoxColumn _colCheckChuaQuanLy;
        private int _IdPhieuYeuCau = -1;
 
        /// <summary>
        /// Initializes a new instance of the <see cref="SF113"/> class.
        /// </summary>
        public SF113(TD_KeHoachThuViec pKeHoach, bool pIsPNhanSu,int pIdPYC)
        {
            InitializeComponent();
            _keHoach = new TD_KeHoachThuViec();
            _keHoach = pKeHoach;
            _IdPhieuYeuCau = pIdPYC;
            InitForm();
            EnableControl(pIsPNhanSu);
        }

        #endregion

        #region ---- Properties ----


        /// <summary>
        /// Gets or sets the id phieu yeu cau.
        /// </summary>
        /// <value>The id phieu yeu cau.</value>
        ///  26/07/11
        /// PC
        public int IdPhieuYeuCau
        {
            get { return _IdPhieuYeuCau; }
            set { _IdPhieuYeuCau = value; }
        }

        

        #endregion

        #region Private Methods

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            _busNhanVien = new TD_NhanVienBLL();
            _busNhanVien = new TD_NhanVienBLL();
            _busYeuCau = new TD_YeuCauCongViecBLL();
            _busPhongBan = new DanhMucPhongBanBLL();
            _busUngVien = new TD_UngVienBLL();
            _busChiTiet = new TD_ChiTietKeHoachThuViecBLL();
            _colCheckDangQuanLy = new HRMCheckBoxColumn(this.grdUngVienDangQuanLy, string.Empty, 0) { UniqueProperty = "Id" };
            _colCheckChuaQuanLy = new HRMCheckBoxColumn(this.grdDanhSachUngVien, string.Empty, 0) { UniqueProperty = "Id" };
            btnThemUngVien.Click += new EventHandler(btnThemUngVien_Click);
            btnXoaUngVien.Click += new EventHandler(btnXoaUngVien_Click);

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnSave.Visible = false;
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;

            LoadData();
           
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            SetDataToForm();
            LoadUngVien();
        }

        /// <summary>
        /// Sets the data to form.
        /// </summary>
        private void SetDataToForm()
        {
            NV_NhanVien nhanVien = _busNhanVien.GetNhanVienByIdNhanVien(_keHoach.IdNhanVien);
            DM_PhongBan phongBan = _busPhongBan.GetPhongBanByID(_keHoach.IdPhongBan);

            if (nhanVien != null)
            {
                txtHoDem.Text = nhanVien.HoDem;
                txtNam.Text = _keHoach.Nam.ToString();
                txtQuy.Text = _keHoach.Quy.ToString();
                txtTen.Text = nhanVien.Ten;
                txtPhongBan.Text = phongBan.TenPhongBan;
            }
        }

        /// <summary>
        /// Loads the ung vien.
        /// </summary>
        private void LoadUngVien()
        {
            grdUngVienDangQuanLy.DataSource = _busChiTiet.GetUngVienByIdKeHoachThuViec(_keHoach);
            grdDanhSachUngVien.DataSource = _busChiTiet.GetUngVienChuaCoKHThuViec(_keHoach,_IdPhieuYeuCau);

        }

        /// <summary>
        /// Gets the ung vien them selected.
        /// </summary>
        /// <returns></returns>
        private List<int> GetUngVienThemSelected()
        {
            // Get ung vien duoc chon
            List<int> idNguoiDung = _colCheckChuaQuanLy.GetCheckedRow();

            return idNguoiDung;
        }

        /// <summary>
        /// Getungs the vien delete.
        /// </summary>
        /// <returns></returns>
        private List<int> GetungVienDelete()
        {
            // Get Ung vien buoc duoc chon
            List<int> idNguoiDung = _colCheckDangQuanLy.GetCheckedRow();

            return idNguoiDung;
        }

        /// <summary>
        /// Enables the control.
        /// </summary>
        /// <param name="pIsEnable">if set to <c>true</c> [p is enable].</param>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        private void EnableControl(bool pIsEnable)
        {
            btnThemUngVien.Enabled = pIsEnable;
            btnXoaUngVien.Enabled = pIsEnable;
        }
        #endregion

        #region Event

        /// <summary>
        /// Handles the Click event of the btnThemUngVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnThemUngVien_Click(object sender, EventArgs e)
        {
            List<int> plist = GetUngVienThemSelected();
            if (plist.Count > 0)
            {
                _busChiTiet.ThemUngVienChoChiTietThuViec(plist, _keHoach.Id);
                UICommon.ShowSplashPanelUpdateMsg();
                _colCheckChuaQuanLy.ResetToNoCheck();
                _colCheckDangQuanLy.ResetToNoCheck();
                LoadUngVien();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnXoaUngVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnXoaUngVien_Click(object sender, EventArgs e)
        {
            List<int> plist = GetungVienDelete();
            if (plist.Count > 0 && CheckUngVienDaLenKeHoach(plist))
            {
                _busChiTiet.DeleteUngVienTuChiTiet(plist);
                UICommon.ShowSplashPanelUpdateMsg();
                _colCheckDangQuanLy.ResetToNoCheck();
                _colCheckDangQuanLy.ResetToNoCheck();
                LoadUngVien();
            }
        }

        /// <summary>
        /// Checks the ung vien da len ke hoach.
        /// </summary>
        /// <param name="pListUngVien">The p list ung vien.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        private bool CheckUngVienDaLenKeHoach(List<int> pListUngVien)
        {
            string pName = string.Empty;
            foreach (int Id in pListUngVien)
            {
                TD_UngVien ungVien = _busUngVien.GetUngVienById(Id);
                if (ungVien != null)
                {
                    TD_YeuCauCongViec yeuCau = _busYeuCau.GetYeuCauByIdUngVien(Id);
                    if (yeuCau != null)
                    {
                        pName = ungVien.HoDem + " " + ungVien.Ten;
                        UICommon.ShowMsgInfo("MSG028", pName.Trim());
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion

    }
}
