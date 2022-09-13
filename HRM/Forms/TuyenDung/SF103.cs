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
using Library.Class;
using Library;

namespace HRM.Forms.TuyenDung
{
    public partial class SF103 : GridBaseForm
    {
        #region  Variable
        private HRMCheckBoxColumn chkKeHoach;
        private List<int> hardlist = new List<int>();
        private TD_PhieuYeuCauTuyenDungBLL _busYeuCauTuyenDung;
        private List<int> _listError = null;
        private List<int> _listKhongduyet = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF104"/> class.
        /// </summary>
        public SF103()
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
                 
                // New instance 
                TD_PhieuYeuCauTuyenDung yeuCau = new TD_PhieuYeuCauTuyenDung();

                yeuCau.DaDuyet = false;
                yeuCau.KhongDuyet = false;

                yeuCau.IdPhongBan = ((DM_PhongBan)cboPhongBan.SelectedItem).Id;
                yeuCau.Quy = ((DM_Quy)cboQuy.SelectedItem).Ten;
                yeuCau.Nam = int.Parse(txtNam.Text) ;

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

            int a = -1;
            if (item != null)
            {
                if (!_busYeuCauTuyenDung.CheckedIsUsing(((TD_PhieuYeuCauTuyenDung)item).Id))
                {
                    UICommon.ShowMsgInfo("MSG026");
                    return;
                }
                // Confirm delete
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)
                {
                    a = brscGrdData.IndexOf(item);
                    brscGrdData.RemoveCurrent();
                    _listError.Remove(a);
                    if (item.Id != 0)
                    {
                        _busYeuCauTuyenDung.DeleteData(item.Id);

                        // Show Suceed panel
                        UICommon.ShowSplashPanelUpdateMsg();

                        if (grdData.Table.Records.Count == 0)
                        {
                            EnableControls(_busYeuCauTuyenDung.CheckedIsUsing(((TD_PhieuYeuCauTuyenDung)item).Id));
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
            this.grdData.TableDescriptor.SortedColumns.Clear(); 
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
                    // Clear and reset all
                    chkKeHoach.HardValue.Clear();
                    hardlist = new List<int>();
                    chkKeHoach.ResetToNoCheck();
                    chkKeHoach.ReadOnly = false;
                    this.btnSearch.Enabled = true;
                    LoadPhieuYeuCauTuyenDung();
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
            chkKeHoach = new HRMCheckBoxColumn(grdKeHoach, string.Empty, 0) { UniqueProperty = "Id"};
            _busYeuCauTuyenDung = new TD_PhieuYeuCauTuyenDungBLL();
            _listError = new List<int>();
            _listKhongduyet = new List<int>();

            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString(); 
            UICommon.GridFormatDate(grdData.TableDescriptor.Columns, false, "NgayCanNhanSu");
            UICommon.GridFormatNumber(grdData.TableDescriptor.Columns, true, "SoLuong", "SoLuongNam", "TuoiTu", "DenTuoi", "SoNamKinhNghiem");
            this.chkKeHoach.EventCheckBoxClick += new HRMCheckBoxColumn.OnCheckBoxClicked(chkKeHoach_EventCheckBoxClick);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            this.brscGrdData.PositionChanged += new EventHandler(brscGrdData_PositionChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.grdData.QueryCellStyleInfo+=new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(grdData_QueryCellStyleInfo);
            btnSearch.Enabled = false;
            this.btnSearch.Text = "Sinh phiếu";
            LoadData();
            AddDatabinding();
            ToolStripItem mnuItem = null;
            for (int i = hrmContextMenustrip1.Items.Count - 1; i >= 0; i--)
            {
                mnuItem = hrmContextMenustrip1.Items[i];
                this.grdKeHoach.InternalContextMenuStripEx.Items.Insert(0, mnuItem);
            }
        }
 
        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            LoadCombobox();
            LoadPhieuYeuCauTuyenDung();

            EnableControls(false);

        }

        /// <summary>
        /// Loads the combobox.
        /// </summary>
        private void LoadCombobox()
        {
            cboPhongBan.DataSource = _busYeuCauTuyenDung.GetPhongBan();
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";
            //cboPhongBan.SelectedIndex = -1;

            cboQuy.DataSource = _busYeuCauTuyenDung.GetQuy();
            cboQuy.DisplayMember = "Ten";
            cboQuy.ValueMember = "Id";
           // cboQuy.SelectedIndex = -1;

            cboChucDanh.DataSource = CacheData.GetDanhMucChucDanh();
            cboChucDanh.DisplayMember = "TenChucDanh";
            cboChucDanh.ValueMember = "Id";
            cboChucDanh.SelectedIndex = -1;

            cboTrinhDo.DataSource = CacheData.GetDanhMucTrinhDo();
            cboTrinhDo.DisplayMember = "TenTrinhDo";
            cboTrinhDo.ValueMember = "Id";
            cboTrinhDo.SelectedIndex = -1;

            cboChuyenNganh.DataSource = CacheData.GetDanhMucChuyenNganh();
            cboChuyenNganh.DisplayMember = "TenChuyenNganh";
            cboChuyenNganh.ValueMember = "Id";
            cboChuyenNganh.SelectedIndex = -1;

            cboTrinhDoTinHoc.DataSource = CacheData.GetDanhMucTrinhDoTinHoc();
            cboTrinhDoTinHoc.DisplayMember = "TenTrinhDoTinHoc"; ;
            cboTrinhDoTinHoc.ValueMember = "Id";
            cboTrinhDoTinHoc.SelectedIndex = -1;

            cboTrinhDoNgoaiNgu.DataSource = CacheData.GetDanhMucNgoaiNgu();
            cboTrinhDoNgoaiNgu.DisplayMember = "TenNgoaiNgu";
            cboTrinhDoNgoaiNgu.ValueMember = "Id";
            cboTrinhDoNgoaiNgu.SelectedIndex = -1;

            cboTinhTrangHonNhan.DataSource = CacheData.GetDanhMucTinhTrangHonNhan();
            cboTinhTrangHonNhan.DisplayMember = "TenTinhTrang";
            cboTinhTrangHonNhan.ValueMember = "Id";
            cboTinhTrangHonNhan.SelectedIndex = -1;

            cboLyDo.DataSource = CacheData.GetDanhMucLyDo();
            cboLyDo.DisplayMember = "TenLyDo";
            cboLyDo.ValueMember = "Id";
            cboLyDo.SelectedIndex = -1;



        }

        /// <summary>
        /// Loads the phieu yeu cau tuyen dung.
        /// </summary>
        private void LoadPhieuYeuCauTuyenDung()
        {
            _listKhongduyet.Clear();
            if (cboPhongBan.SelectedIndex >= 0 && cboQuy.SelectedIndex >= 0 && int.Parse(txtNam.Text.ToString()) > 0)
            {
                int IdPhongBan = ((DM_PhongBan)(cboPhongBan.SelectedItem)).Id;
                int Quy = Library.Class.CommonUtil.IsInt(cboQuy.Text);
                int Nam = int.Parse(txtNam.Text.ToString());
                brscGrdData.DataSource = _busYeuCauTuyenDung.GetPhieuYeuCauTDByCondition(IdPhongBan, Quy, Nam);
                if (brscGrdData.Count > 0)
                {
                    grdData.DataSource = brscGrdData;
                    foreach (TD_PhieuYeuCauTuyenDung td in (List<TD_PhieuYeuCauTuyenDung>)(brscGrdData.DataSource))
                    {
                        int a = brscGrdData.IndexOf(td);
                        if (td.KhongDuyet.Value)
                        {
                            _listKhongduyet.Add(a);
                        }
                    }
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
            TD_PhieuYeuCauTuyenDung item = brscGrdData.Current as TD_PhieuYeuCauTuyenDung;

            if (item != null)
            {
                EnableControls(_busYeuCauTuyenDung.CheckedIsUsing(((TD_PhieuYeuCauTuyenDung)item).Id));
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
            dtpNgayCanNhanSu.Enabled = IsEnable;
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

                // Check  MaPhieuYeuCau Not null
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

                // Check TenPhieuYeuCau Not null
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

                // Check chucdanh  Not null
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

                if (td.IdTrinhDo <= 0)
                {
                    UICommon.ShowMsgInfo("MSG005", lblTrinhDo.Text);

                    // Set forcus control
                    cboTrinhDo.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (td.IdChuyenNganh <= 0)
                {
                    UICommon.ShowMsgInfo("MSG005", lblChuyenNganh.Text);

                    // Set forcus control
                    cboChuyenNganh.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (td.SoLuong <= 0)
                {
                    UICommon.ShowMsgInfo("MSG020", lblSoLuong.Text, "0");
                    txtSoLuong.Focus();
                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (td.SoLuongNam > td.SoLuong)
                {
                    UICommon.ShowMsgInfo("MSG025", lblSpLuongNam.Text, lblSoLuong.Text);

                    txtSoLuongNam.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Get the existed Phong ban
                List<TD_PhieuYeuCauTuyenDung> listIndex = pList.Where(p => p.MaPhieuYeuCau == td.MaPhieuYeuCau).Select(p => p).ToList();
                List<TD_PhieuYeuCauTuyenDung> listIndex1 = pList.Where(p => p.IdChucDanh == td.IdChucDanh && p.IdTrinhDo == td.IdTrinhDo && p.IdChuyenNganh == p.IdChuyenNganh).Select(p => p).ToList();
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

                if (pList.Where(p => p.IdChucDanh == td.IdChucDanh && p.IdChuyenNganh == td.IdChuyenNganh && p.IdTrinhDo == td.IdTrinhDo).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (TD_PhieuYeuCauTuyenDung index in listIndex1)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG052", lblMaPhieuYC.Text);
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
                brscGrdKeHoach.DataSource= _busYeuCauTuyenDung.GetKeHoachTuyenDung(((DM_PhongBan)cboPhongBan.SelectedItem).Id, (int)cboQuy.SelectedValue, CommonUtil.IsInt(txtNam.Text));
                grdKeHoach.DataSource = brscGrdKeHoach;
                 TD_PhieuYeuCauTuyenDung item = brscGrdData.Current as TD_PhieuYeuCauTuyenDung;
                 if (item != null)
                 {
                     EnableControls(_busYeuCauTuyenDung.CheckedIsUsing(((TD_PhieuYeuCauTuyenDung)item).Id));
                 }
                btnAdd.Enabled = false;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            }

            //EnableControls(!(brscGrdData.Count <= 0));

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
            e.Style.TextColor = Color.Black;
            foreach (int item in _listError)
            {
                if (e.TableCellIdentity.RowIndex == item + 2)
                {
                    e.Style.BackColor = Color.Orange;
                    e.Style.CellTipText = UICommon.GetString("MSG011");
                    break;
                }
            }
            foreach (int khongduyet in _listKhongduyet)
            {
                if (e.TableCellIdentity.RowIndex == khongduyet + 2)
                {
                    e.Style.TextColor = Color.Red;
                }
            }
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the xemChiTiếtToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TD_BangKeHoachTuyenDung item = grdKeHoach.CurrencyManager.Current as TD_BangKeHoachTuyenDung;

            if (item != null)
            {
                TD_BangKeHoachTuyenDungBLL _bussnew = new TD_BangKeHoachTuyenDungBLL();

                if (_bussnew.CheckedIsHasValue(item.Id))
                {
                    SF101 frm = new SF101();
                    frm.KeHoach = item;
                    frm.InputPhanQuyen = false;
                    MngForms.ShowDialog(frm);
                }
                else
                {
                    UICommon.ShowMsgWarning("MSG018");
                    return;
                }

            }
        }

        /// <summary>
        /// CHKs the ke hoach_ event check box click.
        /// </summary>
        /// <param name="RowIndex">Index of the row.</param>
        /// <param name="currentRecord">The current record.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        private void chkKeHoach_EventCheckBoxClick(int RowIndex, object currentRecord, bool value)
        {
            this.btnSearch.Enabled =chkKeHoach.GetCheckedRow().Count > 0;
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Get kehoach checked  grdkehoach
            List<int> list = this.chkKeHoach.GetCheckedRow();

            // Compare
            foreach (int value in hardlist)
            {
                if (list.Contains(value))
                {
                    list.Remove(value);
                }
            }
            UICommon.StartProcess();

            foreach (int item in list)
            {
                //add hard checked for item process
                chkKeHoach.HardValue.Add(item, true);

                List<TD_ChiTietKeHoachTuyenDung> listkh = _busYeuCauTuyenDung.GetChiTietKeHoachTuyenDungById(item);
                TD_BangKeHoachTuyenDung kehoach = _busYeuCauTuyenDung.GetKeHoachTuyenDungById(item);
                var stt = 1;
               foreach (TD_ChiTietKeHoachTuyenDung kh in listkh)
               {
                   //add hard list
                   hardlist.Add(item);

                   //Creat item for PYC
                   TD_PhieuYeuCauTuyenDung subitemPYC = new TD_PhieuYeuCauTuyenDung();
                   subitemPYC.MaPhieuYeuCau = kehoach.MaKeHoach + stt.ToString();
                   subitemPYC.TenPhieuYeuCau = kehoach.TenKeHoach + stt.ToString();
                   stt++;
                   subitemPYC.IdPhongBan = ((DM_PhongBan)cboPhongBan.SelectedItem).Id;
                   subitemPYC.Quy = (int)cboQuy.SelectedValue;
                   subitemPYC.Nam = CommonUtil.IsInt(txtNam.Text);
                   subitemPYC.IdChucDanh = kh.IdChucDanh;
                   subitemPYC.TenChucDanh = CacheData.GetTenChucDanh(kh.IdChucDanh);
                   subitemPYC.SoLuong = kh.SoLuong;
                   subitemPYC.NgayCanNhanSu = kh.ThoiGianCanNhanSu;
                   subitemPYC.IdLyDo = kh.IdLyDo;
                   subitemPYC.TenLyDo = CacheData.GetTenLyDo(kh.IdLyDo.Value);
                   subitemPYC.GhiChu = kh.GhiChu;
                   subitemPYC.DaDuyet = false;
                   subitemPYC.KhongDuyet = false;
                   subitemPYC.SoLuong = kh.SoLuong == null ? 0 : kh.SoLuong.Value;

                   brscGrdData.Add(subitemPYC);
                   
               }
               UICommon.StopProcess();
                 
            }
            this.brscGrdData.MoveLast();
            if (chkKeHoach.GetCheckedRow().Count == brscGrdKeHoach.Count)
            {
                chkKeHoach.ReadOnly = true;
            }
            this.btnSearch.Enabled = false;

            //TD_PhieuYeuCauTuyenDung item = brscGrdData.Current as TD_PhieuYeuCauTuyenDung;

            //if (item != null)
            //{
            //    EnableControls(_busYeuCauTuyenDung.CheckedIsUsing(((TD_PhieuYeuCauTuyenDung)item).Id));
            //}
        }

        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  20/08/11
        /// PC
        void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Handles the PositionChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  20/08/11
        /// PC
        void brscGrdData_PositionChanged(object sender, EventArgs e)
        {
            TD_PhieuYeuCauTuyenDung item = brscGrdData.Current as TD_PhieuYeuCauTuyenDung;

            if (item != null)
            {
                EnableControls(_busYeuCauTuyenDung.CheckedIsUsing(((TD_PhieuYeuCauTuyenDung)item).Id));
            }
        }
 
    }
}
