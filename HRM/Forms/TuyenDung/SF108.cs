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

namespace HRM.Forms.TuyenDung
{
    public partial class SF108 : GridBaseForm
    {
        #region ---- Variables ----

        private TD_KeHoachThuViecBLL _bussKeHoach = null;
        private TD_ChiTietKeHoachThuViecBLL _busChiTietKHTD = null;
        private TD_YeuCauCongViecBLL _busYeuCauCongViec = null;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF108()
        {
            InitializeComponent();
          
            this.InitForm();
        }

        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {

            if (CheckInput())
            {
               
                // New instance 
                TD_KeHoachThuViec thuViec = new TD_KeHoachThuViec();

                thuViec.IdPhongBan = ((DM_PhongBan)cboPhongBan.SelectedItem).Id;
                thuViec.Quy = ((DM_Quy)cboQuy.SelectedItem).Ten;
                thuViec.Nam = int.Parse(txtNam.Text);
                thuViec.IdPhieuYeuCauTuyenDung=((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id;
                //thuViec.IdNhanVien = 2;


                // set enable controls
                //  EnableControls(AllowDeleteData());

                // Add to the binding source
                brscGrdData.Add(thuViec);

                // Set forcus the control
                txtMaKeHoach.Focus();
                base.GetNewData();
                EnableControls(true);
            }

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>


        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {

            if (!SearchNhanVien())
            {
                return;
            }
            base.SaveData();
            List<TD_KeHoachThuViec> yc = brscGrdData.DataSource as List<TD_KeHoachThuViec>;
            if (yc.Count > 0)
            {
                // Check the Validate
                if (ValidateData(yc))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _bussKeHoach.UpdateDataList(yc);
                    UICommon.StopUpdate();
                    // Show suceed panel
                    UICommon.ShowSplashPanelUpdateMsg();
                }
                // Refesh list data
                GrdData.EndEdit();
                GrdData.RefreshData();
                GrdData.Refresh();
            }
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            TD_KeHoachThuViec item = brscGrdData.Current as TD_KeHoachThuViec;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("TD_KeHoachThuViec"))
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
                        _bussKeHoach.DeleteData(item.Id);

                        // Show Suceed panel
                        UICommon.ShowSplashPanelUpdateMsg();

                        if (GrdData.Table.Records.Count == 0)
                        {
                            EnableControls(false);
                        }
                    }
                }
            }
            base.Deletedata();
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        protected override void ExportExcel()
        {
            //ExcelExport excel = new ExcelExport();
            //SaveFileDialog saveFile = new SaveFileDialog();
            //Dictionary<string, string> pThongTin = new Dictionary<string, string>();

            //if (brscGrdData.Count == 0)
            //{
            //    UICommon.ShowMsgInfo("MSG022");
            //    return;
            //}
            //TD_BangKeHoachTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_BangKeHoachTuyenDung;
            //List<TD_ChiTietKeHoachTuyenDung> dataSource = _busChiTiet.LoadAllData(tuyenDung.Id).ToList();
            //if (tuyenDung == null || dataSource.Count == 0)
            //{
            //    UICommon.ShowMsgInfo("MSG022");
            //}
            //else
            //{
            //    pThongTin.Add("PhongBan", CacheData.GetTenPhongBan(tuyenDung.IdPhongBan));
            //    pThongTin.Add("Quy", tuyenDung.Quy.ToString());
            //    pThongTin.Add("Nam", tuyenDung.Nam.ToString());
            //    string path = string.Empty;
            //    excel.ExportKeHoachTuyenDung(dataSource, pThongTin, ref path, false);

            //    // Confirm for open file was exported
            //    if (!string.IsNullOrEmpty(path) && UICommon.ShowMessage("MSG023", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            //    {
            //        System.Diagnostics.Process.Start(path);
            //    }
            //}
        }

        /// <summary>
        /// Prints the documents.
        /// </summary>
        protected override void PrintDocuments()
        {
            //ExcelExport excel = new ExcelExport();

            //Dictionary<string, string> pThongTin = new Dictionary<string, string>();
            //if (brscGrdData.Count == 0)
            //{
            //    UICommon.ShowMsgInfo("MSG022");
            //    return;
            //}
            //TD_BangKeHoachTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_BangKeHoachTuyenDung;
            //List<TD_ChiTietKeHoachTuyenDung> dataSource = _busChiTiet.LoadAllData(tuyenDung.Id).ToList();
            //if (tuyenDung == null || dataSource.Count == 0)
            //{
            //    UICommon.ShowMsgInfo("MSG022");

            //}
            //else
            //{
            //    pThongTin.Add("PhongBan", CacheData.GetTenPhongBan(tuyenDung.IdPhongBan));
            //    pThongTin.Add("Quy", tuyenDung.Quy.ToString());
            //    pThongTin.Add("Nam", tuyenDung.Nam.ToString());
            //    string path = string.Empty;
            //    excel.ExportKeHoachTuyenDung(dataSource, pThongTin, ref path, true);
            //}
        }

        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
        }
        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            this.btnSearch.Text = "Chi tiết thử việc";
            // Get data
            _bussKeHoach = new TD_KeHoachThuViecBLL();
            _busChiTietKHTD = new TD_ChiTietKeHoachThuViecBLL();
            _busYeuCauCongViec = new TD_YeuCauCongViecBLL();
            _listError = new List<int>();
            LoadCombobox();
            cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            cboPhieuYeuCau.SelectedIndexChanged += new EventHandler(cboPhieuYeuCau_SelectedIndexChanged);    
            txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            txtMaNhanVien.KeyDown += new KeyEventHandler(txtMaNhanVien_KeyDown);
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, false, "ThuViecTuNgay", "ThuViecDenNgay");
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);

            //this.btnExcelTemplate.Visible = true;
            //this.btnPrintTemplate.Visible = true;
            this.btnPrint.Visible = true;
            this.btnExcel.Visible = true;
            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);

            LoadData();
            
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);

        }
   
        /// <summary>
        /// Loads the combobox.
        /// </summary>
        private void LoadCombobox()
        {
            cboPhongBan.DataSource = _bussKeHoach.GetPhongBan();
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";

            cboQuy.DataSource = _bussKeHoach.GetQuy();
            cboQuy.DisplayMember = "Ten";
            cboQuy.ValueMember = "Id";

            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();

        }

        /// <summary>
        /// Loadcomboes the PYC.
        /// </summary>
        ///  26/07/11
        /// PC
        private void LoadcomboPYC()
        {
            cboPhieuYeuCau.DataSource = _bussKeHoach.GetPhieuYCByPhongBanQuyNam(((DM_PhongBan)cboPhongBan.SelectedItem).Id,((DM_Quy)cboQuy.SelectedItem).Id,int.Parse(txtNam.Text));
            cboPhieuYeuCau.DisplayMember = "MaPhieuYeuCau";
            cboPhieuYeuCau.ValueMember = "Id";
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaKeHoach.DataBindings.Clear();
            txtHoDem.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            dtpTuNgay.DataBindings.Clear();
            dtpDenNgay.DataBindings.Clear();

            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaKeHoach.DataBindings.Add("Text", brscGrdData, "MaKeHoachThuViec", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHoDem.DataBindings.Add("Text", brscGrdData, "HoDemQuanLy", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaNhanVien.DataBindings.Add("Text", brscGrdData, "MaNhanVienQuanLy", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", brscGrdData, "TenQuanLy", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpTuNgay.DataBindings.Add("Value", brscGrdData, "ThuViecTuNgay", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpDenNgay.DataBindings.Add("Value", brscGrdData, "ThuViecDenNgay", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            LoadCombobox();
         
            LoadKeHoachThuViec();
        }

        /// <summary>
        /// Loads the phieu yeu cau tuyen dung.
        /// </summary>
        private void LoadKeHoachThuViec()
        {
            _listError.Clear();

            if (cboPhongBan.SelectedIndex >= 0 && cboQuy.SelectedIndex >= 0 && int.Parse(txtNam.Text)> 0)
            {
                int IdPhongBan = ((DM_PhongBan)(cboPhongBan.SelectedItem)).Id;
                int Quy = Library.Class.CommonUtil.IsInt(cboQuy.Text);
                int Nam = int.Parse(txtNam.Text);
                try
                {
                    brscGrdData.DataSource = _bussKeHoach.GetDataByIDPYC(((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id);
                }
                catch
                {

                }
                if (brscGrdData.Count > 0)
                {
                    GrdData.DataSource = brscGrdData;

                    AddDataBinding();
                }
                else
                {
                    brscGrdData.DataSource = new List<TD_KeHoachThuViec>();
                    GrdData.DataSource = brscGrdData;
                    AddDataBinding();
                }
            }
            else
            {
                brscGrdData.DataSource = new List<TD_KeHoachThuViec>();
                GrdData.DataSource = brscGrdData;
                AddDataBinding();
            }
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
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
        /// Enables the controls.
        /// </summary>
        /// <param name="IsEnable">if set to <c>true</c> [is enable].</param>
        private void EnableControls(bool IsEnable)
        {
            txtGhiChu.Enabled = IsEnable;
            txtHoDem.Enabled = IsEnable;
            txtMaKeHoach.Enabled = IsEnable;
            txtMaNhanVien.Enabled = IsEnable;
            txtTen.Enabled = IsEnable;

            dtpDenNgay.Enabled = IsEnable;
            dtpTuNgay.Enabled = IsEnable;
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        private bool ValidateData(List<TD_KeHoachThuViec> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (TD_KeHoachThuViec td in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(td);
                //UICommon.ShowMsgInfo("MSG005", lblHoDem.Text);
                //this.txtHoDem.Focus();
                //brscGrdData.Position = a;
                //_listError.Add(a);
                //  return false;
                // Check MaPhongBan Not null
                if (string.IsNullOrEmpty(td.MaKeHoachThuViec))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaKeHoach.Text);
                    // Set forcus control
                    txtMaKeHoach.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check MaPhongBan Not null
                if (td.IdNhanVien <= 0)
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaNhanVien.Text);
                    // Set forcus control
                    txtMaNhanVien.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (!td.ThuViecTuNgay.HasValue)
                {
                    UICommon.ShowMsgInfo("MSG005", lblTuNgay.Text);
                    // Set forcus control
                    dtpTuNgay.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (!td.ThuViecDenNgay.HasValue)
                {
                    UICommon.ShowMsgInfo("MSG005", lblDenNgay.Text);
                    // Set forcus control
                    dtpDenNgay.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
                // Get the existed Phong ban
                List<TD_KeHoachThuViec> listIndex = pList.Where(p => p.MaKeHoachThuViec == td.MaKeHoachThuViec).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaKeHoachThuViec == td.MaKeHoachThuViec).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (TD_KeHoachThuViec index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaKeHoach.Text);
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
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        private void CheckUser(UserInfo user)
        {
            NV_NhanVien nhanVien = _bussKeHoach.GetNhanVienByID(user.IdNhanVien.Value);

            DateTime date = CacheData.Context.GetSystemDate();

            int quy = (int)((date.Month - 1) / 3) + 1;

            if (((DM_PhongBan)cboPhongBan.SelectedItem).Id != nhanVien.IdPhongBan
                || Library.Class.CommonUtil.IsInt(txtNam.Text) < date.Year
               || (Library.Class.CommonUtil.IsInt(txtNam.Text) == date.Year
                && Library.Class.CommonUtil.IsInt(cboQuy.Text) < quy))
            {

                EnableControls(AllowDeleteData("TD_KeHoachThuViec"));

                btnAdd.Enabled = false;
                btnDelete.Enabled = false;

            }
            else
            {
                EnableControls(AllowDeleteData("TD_KeHoachThuViec"));

                btnAdd.Enabled = true;
                btnDelete.Enabled = true;
                btnSave.Enabled = true;
            }

        }

        #endregion

        #region ---- Event----

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadKeHoachThuViec();
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
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
            //LoadKeHoachThuViec();
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
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
            //LoadKeHoachThuViec();
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
            UserInfo user = LayerCommon.CurrentUser;
            if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            {
                CheckUser(user);
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhieuYeuCau control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  26/07/11
        /// PC
        void cboPhieuYeuCau_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadKeHoachThuViec();
        }


        /// <summary>
        /// Handles the KeyDown event of the txtMaNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NV_NhanVien nhanVien = _bussKeHoach.GetNhanVienByMaNhanVien(txtMaNhanVien.Text, ((DM_PhongBan)cboPhongBan.SelectedItem).Id);
                if (nhanVien != null)
                {
                    txtHoDem.Text = nhanVien.HoDem;
                    txtTen.Text = nhanVien.Ten;
                    TD_KeHoachThuViec thuViec = brscGrdData.CurrencyManager.Current as TD_KeHoachThuViec;
                    thuViec.IdNhanVien = nhanVien.Id;
                }
                else
                {
                    UICommon.ShowMsgInfo("MSG027");
                    txtMaNhanVien.Focus();
                }
            }
        }

        /// <summary>
        /// Searches the nhan vien.
        /// </summary>
        /// <returns></returns>
        private bool SearchNhanVien()
        {
            NV_NhanVien nhanVien = _bussKeHoach.GetNhanVienByMaNhanVien(txtMaNhanVien.Text, ((DM_PhongBan)cboPhongBan.SelectedItem).Id);
            if (nhanVien != null)
            {
                txtHoDem.Text = nhanVien.HoDem;
                txtTen.Text = nhanVien.Ten;
                TD_KeHoachThuViec thuViec = brscGrdData.CurrencyManager.Current as TD_KeHoachThuViec;
                thuViec.IdNhanVien = nhanVien.Id;
                return true;
            }
            else
            {
                UICommon.ShowMsgInfo("MSG027");
                txtMaNhanVien.Focus();
                return false;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {

            UserInfo user = LayerCommon.CurrentUser;
            NV_NhanVien nhanVien = _bussKeHoach.GetNhanVienByID(user.IdNhanVien.Value);

            if (brscGrdData.Count > 0 && nhanVien.IdPhongBan == ((DM_PhongBan)(cboPhongBan.SelectedItem)).Id)
            {
                TD_KeHoachThuViec keHoach = brscGrdData.CurrencyManager.Current as TD_KeHoachThuViec;
                SF113 frm = new SF113(keHoach, true,((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id);
             
                frm.ShowDialog();
            }
            else if (brscGrdData.Count > 0 && user.IsPhongNhanSu.Value)
            {
                TD_KeHoachThuViec keHoach = brscGrdData.CurrencyManager.Current as TD_KeHoachThuViec;
                SF113 frm = new SF113(keHoach, false, ((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id);
                frm.IdPhieuYeuCau = ((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id;
                frm.ShowDialog();
            }
        }

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            btnSearch.PerformClick();
        }

        /// <summary>
        /// Handles the QueryCellStyleInfo event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs"/> instance containing the event data.</param>
        private void GrdData_QueryCellStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs e)
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
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            UserInfo user = LayerCommon.CurrentUser;
            if (user.IdNhanVien != null && cboPhongBan.SelectedItem != null)
            {
                CheckUser(user);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>23/06/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>23/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
           
        }
        #endregion
    }
}
