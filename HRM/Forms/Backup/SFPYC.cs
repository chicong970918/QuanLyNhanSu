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

namespace HRM.Forms.TuyenDung
{
    public partial class SFPYC : GridBaseForm
    {
        #region  Variable

        private TD_PhieuYeuCauTuyenDungBLL _busYeuCauTuyenDung;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF104"/> class.
        /// </summary>
        public SFPYC()
        {
            InitializeComponent();
            this.InitLayout();
            InitForm();
        }

        #endregion

        #region Protected Mothods

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            if (CheckInput())
            {
                if (txtNam.IntegerValue < 1900)
                {
                    UICommon.ShowMsgInfo("MSG015", lblNam.Text);
                    return;
                }
                // New instance 
                TD_PhieuYeuCauTuyenDung yeuCau = new TD_PhieuYeuCauTuyenDung();

                yeuCau.DaDuyet = false;
                yeuCau.KhongDuyet = false;

                yeuCau.IdPhongBan = ((DM_PhongBan)cboPhongBan.SelectedItem).Id;
                yeuCau.Quy = ((DM_Quy)cboQuy.SelectedItem).Ten;
                yeuCau.Nam = (int)txtNam.IntegerValue;

                // set enable controls
                EnableControls(true);

                // Add to the binding source
                brscGrdData.Add(yeuCau);

                // Set forcus the control
                txtMaPhieuYeuCau.Focus();
                base.GetNewData();
            }
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {

            TD_PhieuYeuCauTuyenDung item = brscGrdData.Current as TD_PhieuYeuCauTuyenDung;

            if (item != null)
            {
                // Confirm delete
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)
                {
                    brscGrdData.RemoveCurrent();
                    if (item.Id != 0)
                    {
                        _busYeuCauTuyenDung.DeleteData(item.Id);

                        // Show Suceed panel
                        UICommon.ShowSplashPanelUpdateMsg();

                        if (grdData.Table.Records.Count == 0)
                        {
                            EnableControls(false);
                        }
                    }
                }
            }
            base.Deletedata();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            base.SaveData();
            List<TD_PhieuYeuCauTuyenDung> yc = brscGrdData.DataSource as List<TD_PhieuYeuCauTuyenDung>;

            if (yc.Count > 0)
            {
                // Check the Validate
                if (ValidateData(yc))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _busYeuCauTuyenDung.UpdateDataList(yc);
                    UICommon.StopUpdate();
                    // Show suceed panel
                    UICommon.ShowSplashPanelUpdateMsg();
                }
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
            txtNam.IntegerValue = CacheData.Context.GetSystemDate().Year;
            UICommon.GridFormatDate(grdData.TableDescriptor.Columns, false, "NgayCanNhanSu");
            UICommon.GridFormatNumber(grdData.TableDescriptor.Columns, true, "SoLuong", "SoLuongNam", "TuoiTu", "DenTuoi", "SoNamKinhNghiem");
            btnSearch.Visible = false;

            LoadData();
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

            cboTrinhDo.DataSource = CacheData.GetDanhMucTrinhDo();
            cboTrinhDo.DisplayMember = "TenTrinhDo";
            cboTrinhDo.ValueMember = "Id";

            cboChuyenNganh.DataSource = CacheData.GetDanhMucChuyenNganh();
            cboChuyenNganh.DisplayMember = "TenChuyenNganh";
            cboChuyenNganh.ValueMember = "Id";

            cboTrinhDoTinHoc.DataSource = CacheData.GetDanhMucTrinhDoTinHoc();
            cboTrinhDoTinHoc.DisplayMember = "TenTrinhDoTinHoc"; ;
            cboTrinhDoTinHoc.ValueMember = "Id";

            cboTrinhDoNgoaiNgu.DataSource = CacheData.GetDanhMucNgoaiNgu();
            cboTrinhDoNgoaiNgu.DisplayMember = "TenNgoaiNgu";
            cboTrinhDoNgoaiNgu.ValueMember = "Id";

            cboTinhTrangHonNhan.DataSource = CacheData.GetDanhMucTinhTrangHonNhan();
            cboTinhTrangHonNhan.DisplayMember = "TenTinhTrang";
            cboTinhTrangHonNhan.ValueMember = "Id";

            cboLyDo.DataSource = CacheData.GetDanhMucLyDo();
            cboLyDo.DisplayMember = "TenLyDo";
            cboLyDo.ValueMember = "Id";


        }

        /// <summary>
        /// Loads the phieu yeu cau tuyen dung.
        /// </summary>
        private void LoadPhieuYeuCauTuyenDung()
        {
            if (cboPhongBan.SelectedIndex >= 0 && cboQuy.SelectedIndex >= 0 && txtNam.IntegerValue > 0)
            {
                int IdPhongBan = ((DM_PhongBan)(cboPhongBan.SelectedItem)).Id;
                int Quy = Library.Class.CommonUtil.IsInt(cboQuy.Text);
                int Nam = (int)txtNam.IntegerValue;
                brscGrdData.DataSource = _busYeuCauTuyenDung.GetPhieuYeuCauTDByCondition(IdPhongBan, Quy, Nam);
                if (brscGrdData.Count > 0)
                {
                    grdData.DataSource = brscGrdData;
                    AddDatabinding();
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


            cboTrinhDo.DataBindings.Add("SelectedValue", brscGrdData, "IdTrinhDo", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChuyenNganh.DataBindings.Add("SelectedValue", brscGrdData, "IdChuyenNganh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChucDanh.DataBindings.Add("SelectedValue", brscGrdData, "IdChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTrinhDoNgoaiNgu.DataBindings.Add("SelectedValue", brscGrdData, "IdTrinhDoNgoaiNgu", true, DataSourceUpdateMode.OnPropertyChanged);
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
            txtSoLuong.Enabled = IsEnable;
            txtSoLuongNam.Enabled = IsEnable;
            txtSoNamKinhNghiem.Enabled = IsEnable;
            txtTenPhieuYeuCau.Enabled = IsEnable;
            txtTuoiTu.Enabled = IsEnable;
            txtYeuCauCanThiet.Enabled = IsEnable;
            txtYeuCauKhac.Enabled = IsEnable;
            txtYeuCauSucKhoe.Enabled = IsEnable;
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
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<TD_PhieuYeuCauTuyenDung> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (TD_PhieuYeuCauTuyenDung td in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(td);

                // Check MaPhongBan Not null
                if (string.IsNullOrEmpty(td.MaPhieuYeuCau))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaPhieuYC.Text);
                    // Set forcus control
                    txtMaPhieuYeuCau.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(td.TenPhieuYeuCau))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenPhieuYC.Text);

                    // Set forcus control
                    txtTenPhieuYeuCau.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (td.IdChucDanh <= 0)
                {
                    UICommon.ShowMsgInfo("MSG005", lblChucDanh.Text);

                    // Set forcus control
                    cboChucDanh.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }


                // Get the existed Phong ban
                List<TD_PhieuYeuCauTuyenDung> listIndex = pList.Where(p => p.MaPhieuYeuCau == td.MaPhieuYeuCau).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaPhieuYeuCau == td.MaPhieuYeuCau).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (TD_PhieuYeuCauTuyenDung index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaPhieuYC.Text);
                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
            }
            return true;
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

            if (((DM_PhongBan)cboPhongBan.SelectedItem).Id != nhanVien.IdPhongBan
                || Library.Class.CommonUtil.IsInt(txtNam.Text) < date.Year
                || Library.Class.CommonUtil.IsInt(cboQuy.Text) < quy)
            {
                EnableControls(false);

                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnSave.Enabled = false;
            }
            else
            {
                EnableControls(true);

                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
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
            UserInfo user = LayerCommon.CurrentUser;
            if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            {
                CheckUser(user);
            }

        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadPhieuYeuCauTuyenDung();
            UserInfo user = LayerCommon.CurrentUser;
            if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            {
                CheckUser(user);
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNam_TextChanged(object sender, EventArgs e)
        {

            LoadPhieuYeuCauTuyenDung();
            UserInfo user = LayerCommon.CurrentUser;
            if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            {
                CheckUser(user);
            }
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

        #endregion
    }
}
