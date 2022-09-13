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
using HRM.DataAccess.Common;
using HRM.Entities;
using HRM.Class;
using Library;

namespace HRM.Forms.TuyenDung
{
    public partial class SF105 : GridBaseForm
    {
        #region  Variable

        private TD_PhieuYeuCauTuyenDungBLL _busYeuCauTuyenDung;
        private List<int> _listError = null;
        private HRMCheckBoxColumn _colCheckPhieuYeuCau;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF104"/> class.
        /// </summary>
        public SF105()
        {
            InitializeComponent();

            InitForm();
        }

        #endregion

        #region Protected Mothods

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            base.SaveData();
            List<int> yc = PhieuYeuCauSelected();
            List<TD_PhieuYeuCauTuyenDung> khongDuyet = brscGrdData.DataSource as List<TD_PhieuYeuCauTuyenDung>;
            List<int> listKhongDuyet = khongDuyet.Where(k => k.KhongDuyet == true).Select(t => t.Id).ToList();
            if (yc.Count > 0 || listKhongDuyet.Count>0)
            {

                UICommon.StartUpdate();
                // Update data
                _busYeuCauTuyenDung.UpDateXetDuyetPhieuYeuCau(yc, listKhongDuyet);
                UICommon.StopUpdate();
                // Show suceed panel
                UICommon.ShowSplashPanelUpdateMsg();
                // Refesh list data
                grdData.EndEdit();
                grdData.RefreshData();
                grdData.Refresh();
            }
            
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        protected override void ExportExcel()
        {
            ExcelExport excel = new ExcelExport();
            if (brscGrdData.Count > 0)
            {
                excel.AutoExportToExcel(grdData, "PHIẾU YÊU CẦU TUYỂN DỤNG", false);
            }
        }

        /// <summary>
        /// Prints the documents.
        /// </summary>
        protected override void PrintDocuments()
        {
            ExcelExport excel = new ExcelExport();
            if (brscGrdData.Count > 0)
            {
                string path = excel.AutoExportToExcel(grdData, "PHIẾU YÊU CẦU TUYỂN DỤNG", true);
                Print(path);
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            _busYeuCauTuyenDung = new TD_PhieuYeuCauTuyenDungBLL();
            _listError = new List<int>();
            txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();
            UICommon.GridFormatDate(grdData.TableDescriptor.Columns, false, "NgayCanNhanSu");
            UICommon.GridFormatNumber(grdData.TableDescriptor.Columns, true, "SoLuong", "SoLuongNam", "TuoiTu", "DenTuoi", "SoNamKinhNghiem");
            btnSearch.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            this.toolStripSeparator1.Visible = false;
            // Insert check box in grid
            _colCheckPhieuYeuCau = new HRMCheckBoxColumn(this.grdData, string.Empty, 0) { UniqueProperty = "Id" };

            _colCheckPhieuYeuCau.EventCheckBoxClick += new HRMCheckBoxColumn.OnCheckBoxClicked(_colCheckPhieuYeuCau_EventCheckBoxClick);

            LoadData();

            EnableControls(false);
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            LoadCombobox();
            LoadPhieuYeuCauTuyenDung();
        }

        /// <summary>
        /// Loads the combobox.
        /// </summary>
        private void LoadCombobox()
        {
            cboPhongBan.DataSource = _busYeuCauTuyenDung.GetPhongBan();
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";

          

            cboQuy.DataSource = _busYeuCauTuyenDung.GetQuy();
            cboQuy.DisplayMember = "Ten";
            cboQuy.ValueMember = "Id";


            cboChucDanh.DataSource = CacheData.GetDanhMucChucDanh();
            cboChucDanh.DisplayMember = "TenChucDanh";
            cboChucDanh.ValueMember = "Id";

            this.cboChucDanh.SelectedIndex = -1;

            cboTrinhDo.DataSource = CacheData.GetDanhMucTrinhDo();
            cboTrinhDo.DisplayMember = "TenTrinhDo";
            cboTrinhDo.ValueMember = "Id";
            this.cboTrinhDo.SelectedIndex = -1;

            cboChuyenNganh.DataSource = CacheData.GetDanhMucChuyenNganh();
            cboChuyenNganh.DisplayMember = "TenChuyenNganh";
            cboChuyenNganh.ValueMember = "Id";
            this.cboChuyenNganh.SelectedIndex = -1;

            cboTrinhDoTinHoc.DataSource = CacheData.GetDanhMucTrinhDoTinHoc();
            cboTrinhDoTinHoc.DisplayMember = "TenTrinhDoTinHoc"; ;
            cboTrinhDoTinHoc.ValueMember = "Id";
            this.cboTrinhDoTinHoc.SelectedIndex = -1;
            cboTrinhDoNgoaiNgu.DataSource = CacheData.GetDanhMucNgoaiNgu();
            cboTrinhDoNgoaiNgu.DisplayMember = "TenNgoaiNgu";
            cboTrinhDoNgoaiNgu.ValueMember = "Id";
            this.cboTrinhDoNgoaiNgu.SelectedIndex = -1;

            cboTinhTrangHonNhan.DataSource = CacheData.GetDanhMucTinhTrangHonNhan();
            cboTinhTrangHonNhan.DisplayMember = "TenTinhTrang";
            cboTinhTrangHonNhan.ValueMember = "Id";
            this.cboTinhTrangHonNhan.SelectedIndex = -1;
            cboLyDo.DataSource = CacheData.GetDanhMucLyDo();
            cboLyDo.DisplayMember = "TenLyDo";
            cboLyDo.ValueMember = "Id";
            this.cboLyDo.SelectedIndex = -1;

        }

        /// <summary>
        /// Loads the phieu yeu cau tuyen dung.
        /// </summary>
        private void LoadPhieuYeuCauTuyenDung()
        {
            if (cboPhongBan.SelectedIndex >= 0 && cboQuy.SelectedIndex >= 0 && int.Parse(txtNam.Text) > 0)
            {
                int IdPhongBan = ((DM_PhongBan)(cboPhongBan.SelectedItem)).Id;
                int Quy = Library.Class.CommonUtil.IsInt(cboQuy.Text);
                int Nam = int.Parse(txtNam.Text);
                brscGrdData.DataSource = _busYeuCauTuyenDung.GetPhieuYeuCauTDByCondition(IdPhongBan, Quy, Nam);
                if (brscGrdData.Count > 0)
                {
                    grdData.DataSource = brscGrdData;
                    AddDatabinding();
                    List<TD_PhieuYeuCauTuyenDung> listDS = brscGrdData.DataSource as List<TD_PhieuYeuCauTuyenDung>;

                    _colCheckPhieuYeuCau.HardValue.Clear();

                    foreach (TD_PhieuYeuCauTuyenDung td in listDS)
                    {
                        if (td.DaDuyet == true)
                        {
                            _colCheckPhieuYeuCau.HardValue.Add(td.Id, true);
                        }
                    }
                }
                else
                {
                    brscGrdData.DataSource = new List<TD_PhieuYeuCauTuyenDung>();
                    grdData.DataSource = brscGrdData;
                }
            }
            else
            {
                brscGrdData.DataSource = new List<TD_PhieuYeuCauTuyenDung>();
                grdData.DataSource = brscGrdData;
            }
            ///
            if (brscGrdData.Count > 0)
            {
                TD_PhieuYeuCauTuyenDung yeuCau = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                List<int> chek = _colCheckPhieuYeuCau.GetCheckedRow();
                bool flag = false;
                if (!(chek.Count == brscGrdData.Count))
                {
                    foreach (int i in chek)
                    {
                        if (i == yeuCau.Id)
                        {

                            //chkKhongDuyet.Checked = false;
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        yeuCau.KhongDuyet = false;
                        chkKhongDuyet.Enabled = false;
                        chkKhongDuyet.Checked = false;
                    }
                    else
                    {
                        chkKhongDuyet.Enabled = true;
                    }
                }
                else
                {
                    chkKhongDuyet.Enabled = false;
                    chkKhongDuyet.Checked = false;
                }
            }

        }

        /// <summary>
        /// Adds the databinding.
        /// </summary>
        private void AddDatabinding()
        {
            // Clear binding 
            txtMaPhieuYeuCau.DataBindings.Clear();
            txtTenPhieuYeuCau.DataBindings.Clear();
            txtSoNamKinhNghiem.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            txtSoLuongNam.DataBindings.Clear();
            txtTuoiTu.DataBindings.Clear();
            txtDenTuoi.DataBindings.Clear();
            txtYeuCauCanThiet.DataBindings.Clear();
            txtYeuCauKhac.DataBindings.Clear();
            txtYeuCauSucKhoe.DataBindings.Clear();
            dtpNgayCanNhanSu.DataBindings.Clear();

            chkKhongDuyet.DataBindings.Clear();

            cboTrinhDo.DataBindings.Clear();
            cboChuyenNganh.DataBindings.Clear();
            cboChucDanh.DataBindings.Clear();
            cboTrinhDoNgoaiNgu.DataBindings.Clear();
            cboTrinhDoTinHoc.DataBindings.Clear();
            cboTinhTrangHonNhan.DataBindings.Clear();
            cboLyDo.DataBindings.Clear();

            txtMaPhieuYeuCau.DataBindings.Add("Text", brscGrdData, "MaPhieuYeuCau", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenPhieuYeuCau.DataBindings.Add("Text", brscGrdData, "TenPhieuYeuCau", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoNamKinhNghiem.DataBindings.Add("Text", brscGrdData, "SoNamKinhNghiem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLuong.DataBindings.Add("Text", brscGrdData, "SoLuong", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLuongNam.DataBindings.Add("Text", brscGrdData, "SoLuongNam", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTuoiTu.DataBindings.Add("Text", brscGrdData, "TuoiTu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDenTuoi.DataBindings.Add("Text", brscGrdData, "DenTuoi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtYeuCauCanThiet.DataBindings.Add("Text", brscGrdData, "YeuCauCanThiet", true, DataSourceUpdateMode.OnPropertyChanged);
            txtYeuCauKhac.DataBindings.Add("Text", brscGrdData, "YeuCauKhac", true, DataSourceUpdateMode.OnPropertyChanged);
            txtYeuCauSucKhoe.DataBindings.Add("Text", brscGrdData, "YeuCauSucKhoe", true, DataSourceUpdateMode.OnPropertyChanged);

            dtpNgayCanNhanSu.DataBindings.Add("Value", brscGrdData, "NgayCanNhanSu", true, DataSourceUpdateMode.OnPropertyChanged);
            chkKhongDuyet.DataBindings.Add("Checked", brscGrdData, "KhongDuyet", true, DataSourceUpdateMode.OnPropertyChanged);


            cboTrinhDo.DataBindings.Add("SelectedValue", brscGrdData, "IdTrinhDo", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChuyenNganh.DataBindings.Add("SelectedValue", brscGrdData, "IdChuyenNganh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChucDanh.DataBindings.Add("SelectedValue", brscGrdData, "IdChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTrinhDoNgoaiNgu.DataBindings.Add("SelectedValue", brscGrdData, "IdNgoaiNgu", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTrinhDoTinHoc.DataBindings.Add("SelectedValue", brscGrdData, "IdTrinhDoTinHoc", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTinhTrangHonNhan.DataBindings.Add("SelectedValue", brscGrdData, "IdTinhTrangHonNhan", true, DataSourceUpdateMode.OnPropertyChanged);
            cboLyDo.DataBindings.Add("SelectedValue", brscGrdData, "IdLyDo", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Enables the controls.
        /// </summary>
        /// <param name="IsEnable">if set to <c>true</c> [is enable].</param>
        private void EnableControls(bool IsEnable)
        {
            bool readOnly = true;

            txtGhiChu.Enabled = IsEnable;
            txtDenTuoi.Enabled = IsEnable;
            txtGhiChu.Enabled = IsEnable;
            txtMaPhieuYeuCau.Enabled = IsEnable;
            //txtSoLuong.Enabled = IsEnable;
            txtSoLuongNam.Enabled = IsEnable;
            txtSoNamKinhNghiem.Enabled = IsEnable;
            txtTenPhieuYeuCau.Enabled = IsEnable;
            txtTuoiTu.Enabled = IsEnable;
            txtYeuCauCanThiet.Enabled = IsEnable;
            txtYeuCauKhac.Enabled = IsEnable;
            txtYeuCauSucKhoe.Enabled = IsEnable;
            dtpNgayCanNhanSu.Enabled = IsEnable;
            if (IsEnable)
            {
                readOnly = false;
            }

            cboChucDanh.ReadOnly = readOnly;
            cboChuyenNganh.ReadOnly = readOnly;
            cboLyDo.ReadOnly = readOnly;
            cboTinhTrangHonNhan.ReadOnly = readOnly;
            cboTrinhDo.ReadOnly = readOnly;
            cboTrinhDoNgoaiNgu.ReadOnly = readOnly;
            cboTrinhDoTinHoc.ReadOnly = readOnly;

        }

        /// <summary>
        /// Checks the user.
        /// </summary>
        /// <param name="user">The user.</param>
        private void CheckUser(UserInfo user)
        {
            NV_NhanVien nhanVien = _busYeuCauTuyenDung.GetNhanVienByID(user.IdNhanVien.Value);

            DateTime date = CacheData.Context.GetSystemDate();

            int quy = (int)((date.Month - 1) / 3) + 1;

            if (user.IsPhongNhanSu.Value && Library.Class.CommonUtil.IsInt(txtNam.Text) >= date.Year
                    && Library.Class.CommonUtil.IsInt(cboQuy.Text) >= quy && brscGrdData.Count > 0)
            {
                chkKhongDuyet.Enabled = false;
                btnSave.Enabled = true;
            }
            else
            {
                if (((DM_PhongBan)cboPhongBan.SelectedItem).Id != nhanVien.IdPhongBan
                    || Library.Class.CommonUtil.IsInt(txtNam.Text) < date.Year
                    || Library.Class.CommonUtil.IsInt(cboQuy.Text) < quy)
                {
                    chkKhongDuyet.Enabled = false;
                    btnSave.Enabled = false;
                }
                else
                {
                    btnSave.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            DateTime date = CacheData.Context.GetSystemDate();

            int quy = (int)((date.Month - 1) / 3) + 1;

            if (Library.Class.CommonUtil.IsInt(txtNam.Text) < date.Year)
            {
                UICommon.ShowMsgInfo("MSG020", lblNam.Text, txtNam.Text);
                return false;
            }
            if (Library.Class.CommonUtil.IsInt(cboQuy.Text) < quy)
            {
                UICommon.ShowMsgInfo("MSG020", lblQuy.Text, cboQuy.Text);
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the nguoi dung selected.
        /// </summary>
        /// <returns></returns>
        private List<int> PhieuYeuCauSelected()
        {
            // Get Nguoi dung buoc duoc chon
            List<int> idPhieuYeuCau = _colCheckPhieuYeuCau.GetCheckedRow();

            return idPhieuYeuCau;
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboChucDanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboChucDanh.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenChucDanh = CacheData.GetTenChucDanh(((DM_ChucDanh)cboChucDanh.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTrinhDo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTrinhDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboTrinhDo.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenTrinhDo = CacheData.GettenTrinhDo(((DM_TrinhDo)cboTrinhDo.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboChuyenNganh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboChuyenNganh.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenChuyenNganh = CacheData.GetTenChuyenNgah(((DM_ChuyenNganh)cboChuyenNganh.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTrinhDoTinHoc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTrinhDoTinHoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboTrinhDoTinHoc.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenTrinhDoTinHoc = CacheData.GetTenTrinhDoTinHoc(((DM_TrinhDoTinHoc)cboTrinhDoTinHoc.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTrinhDoNgoaiNgu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTrinhDoNgoaiNgu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboTrinhDoNgoaiNgu.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenTrinhDoNgoaiNgu = CacheData.GetTenTrinhDoNgoaiNgu(((DM_NgoaiNgu)cboTrinhDoNgoaiNgu.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTinhTrangHonNhan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTinhTrangHonNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboTinhTrangHonNhan.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenTinhTrangHonNhan = CacheData.GetTenTinhTrangHonNhan(((DM_TinhTrangHonNhan)cboTinhTrangHonNhan.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboLyDo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0 && cboLyDo.SelectedIndex >= 0)
            {
                TD_PhieuYeuCauTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                tuyenDung.TenLyDo = CacheData.GetTenLyDo(((DM_LyDo)cboLyDo.SelectedItem).Id);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPhieuYeuCauTuyenDung();
            //UserInfo user = LayerCommon.CurrentUser;
            //if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            //{
            //    CheckUser(user);
            //}

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPhieuYeuCauTuyenDung();
            //UserInfo user = LayerCommon.CurrentUser;
            //if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            //{
            //    CheckUser(user);
            //}
        }

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNam_TextChanged(object sender, EventArgs e)
        {

            LoadPhieuYeuCauTuyenDung();
            //UserInfo user = LayerCommon.CurrentUser;
            //if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            //{
            //    CheckUser(user);
            //}
        }

        /// <summary>
        /// Handles the QueryCellStyleInfo event of the grdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs"/> instance containing the event data.</param>
        private void grdData_QueryCellStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.RowIndex % 2 == 0)
            {
                e.Style.BackColor = Color.White;
            }
            else
            {
                e.Style.BackColor = Color.MintCream;
            }
            foreach (int item in _listError)
            {
                if (e.TableCellIdentity.RowIndex == item + 2)
                {
                    e.Style.BackColor = Color.Orange;
                    e.Style.CellTipText = UICommon.GetString("MSG011");
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the chkKhongDuyet control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkKhongDuyet_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                TD_PhieuYeuCauTuyenDung yeuCau = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                if (yeuCau != null)
                {
                    yeuCau.KhongDuyet = true;
                    yeuCau.DaDuyet = false;

                }

            }
        }

        /// <summary>
        /// Handles the PositionChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdData_PositionChanged(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                TD_PhieuYeuCauTuyenDung yeuCau = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                if ((yeuCau.DaDuyet.HasValue && !yeuCau.DaDuyet.Value))
                {
                    DateTime date = CacheData.Context.GetSystemDate();

                    int quy = (int)((date.Month - 1) / 3) + 1;

                    if (brscGrdData.Count > 0)
                    {
                        if (yeuCau.DaDuyet == false && Library.Class.CommonUtil.IsInt(txtNam.Text) >= date.Year
                            && Library.Class.CommonUtil.IsInt(cboQuy.Text) >= quy)
                        {

                            List<int> chek = _colCheckPhieuYeuCau.GetCheckedRow();
                            foreach (int i in chek)
                            {
                                if (i == yeuCau.Id)
                                {
                                    yeuCau.KhongDuyet = false;
                                    chkKhongDuyet.Enabled = false;
                                }
                                else
                                {
                                    chkKhongDuyet.Enabled = true;
                                }
                            }
                        }
                        else
                        {
                            chkKhongDuyet.Enabled = false;
                           
                        }
                    }
                }
                else
                {
                    chkKhongDuyet.Enabled = false; 
                }
            }

            
        }

        /// <summary>
        /// _cols the check phieu yeu cau_ event check box click.
        /// </summary>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="currentRecord">The current record.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void _colCheckPhieuYeuCau_EventCheckBoxClick(int RowIndex, object currentRecord, bool value)
        {
            if (brscGrdData.Count > 0)
            {
                TD_PhieuYeuCauTuyenDung yeuCau = brscGrdData.CurrencyManager.Current as TD_PhieuYeuCauTuyenDung;
                List<int> chek= _colCheckPhieuYeuCau.GetCheckedRow();
                bool flag = false;
                if (!(chek.Count == brscGrdData.Count))
                {
                    foreach (int i in chek)
                    {
                        if (i == yeuCau.Id)
                        {
                           
                            //chkKhongDuyet.Checked = false;
                            flag = true;
                        }
                    }
                    if (flag)
                    {
                        yeuCau.KhongDuyet = false;
                        chkKhongDuyet.Enabled = false;
                        chkKhongDuyet.Checked = false;
                    }
                    else
                    {
                        chkKhongDuyet.Enabled = true;
                    }
                }
                else
                {
                    chkKhongDuyet.Enabled = false;
                    chkKhongDuyet.Checked = false;
                }
            }
        }

        #endregion
 
    }
}