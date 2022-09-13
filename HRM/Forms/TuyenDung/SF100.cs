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
    public partial class SF100 : GridBaseForm
    {
        #region ---- Variables ----

        TD_BangKeHoachTuyenDungBLL _bussKeHoach = null;
        TD_ChiTietKeHoachTuyenDungBLL _busChiTiet = null;
        private List<int> _listError = null;
        private List<int> _listKhongduyet = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF100()
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
            if (brscGrdData.Count >= 1)
            {
                UICommon.ShowMsgInfo("MSG019", cboQuy.SelectedValue.ToString());
                return;
            }
            if (CommonUtil.IsInt(txtNam.Text.ToString()) < CacheData.Context.GetSystemDate().Year)
            {
                UICommon.ShowMsgInfo("MSG020", lblNam.Text, txtNam.Text.ToString());
                return;
            }
            if (! (CommonUtil.IsInt(txtNam.Text.ToString()) > CacheData.Context.GetSystemDate().Year))
            {
                if ((int)cboQuy.SelectedValue < (((CacheData.Context.GetSystemDate().Month - 1) / 3) + 1))
                {
                    UICommon.ShowMsgInfo("MSG020", lblQuy.Text, ((CacheData.Context.GetSystemDate().Month - 1) / 3).ToString());
                    return;
                }
            }
            Enable(true);
            // Add data in bindingsourec 
            TD_BangKeHoachTuyenDung item = new TD_BangKeHoachTuyenDung();
            item.IdPhongBan = ((DM_PhongBan)this.cboPhongBan.SelectedItem).Id;
            item.Quy = ((DM_Quy)this.cboQuy.SelectedItem).Id;
            item.Nam = CommonUtil.IsInt(txtNam.Text);
            item.DaDuyet = false;
            item.KhongDuyet = false;
            brscGrdData.Add(item);
            base.GetNewData();
            this.txtMaKeHoach.Focus();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
           
            base.Deletedata();
            
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("TD_BangKeHoachTuyenDung"))
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
                        UICommon.ShowSplashPanelUpdateMsg();
                        if (!(brscGrdData.Count > 0))
                        {
                            Enable(false);
                        }
                        else
                        {
                            Enable(true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    List<TD_BangKeHoachTuyenDung> list = (List<TD_BangKeHoachTuyenDung>)brscGrdData.DataSource;
                    _bussKeHoach.UpdateDataList(list);
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
            GrdData.EndEdit();
            GrdData.RefreshData();
            GrdData.Refresh();
        }

        /// <summary>
        /// Allows the delete data.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        ///  20/08/11
        /// PC
        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        protected override void ExportExcel()
        {
        }

        /// <summary>
        /// Prints the documents.
        /// </summary>
        protected override void PrintDocuments()
        {
        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {

            this.btnSearch.Text = "Chi tiết kế hoạch";
            // Get data
            _bussKeHoach = new TD_BangKeHoachTuyenDungBLL();
            _busChiTiet = new TD_ChiTietKeHoachTuyenDungBLL();
            _listKhongduyet = new List<int>();
            _listError = new List<int>();

            btnExcelTemplate.Visible = true;
            btnPrintTemplate.Visible = true;
            btnExcel.Visible = false;
            btnPrint.Visible = false;


            // Add events 
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            this.cboQuy.TextChanged += new EventHandler(cboQuy_TextChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            // Load data by PhongBan
            int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;
            int IdPhongBan = _bussKeHoach.GetIdPhongBanByIdNhanVien(IdNhanVien);
            this.brscGrdData.DataSource = _bussKeHoach.GetDataByPhongBanQuy(IdPhongBan, CommonUtil.IsInt(this.cboQuy.Text), CommonUtil.IsInt(txtNam.Text));

            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();

            // GetData
            this.cboPhongBan.DisplayMember = "TenPhongBan";
            this.cboPhongBan.ValueMember = "Id";
            this.cboPhongBan.DataSource = _bussKeHoach.GetAllPhongBan();

            // GetData
            this.cboQuy.DisplayMember = "Ten";
            this.cboQuy.ValueMember = "Id";
            this.cboQuy.DataSource = _bussKeHoach.GetAllQuy();

            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();

            Enable(false);

        }

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtMaKeHoach.Enabled = pvalue;
            txtTenKeHoach.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaKeHoach.DataBindings.Clear();
            txtTenKeHoach.DataBindings.Clear();

            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaKeHoach.DataBindings.Add("Text", brscGrdData, "MaKeHoach", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenKeHoach.DataBindings.Add("Text", brscGrdData, "TenKeHoach", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<TD_BangKeHoachTuyenDung> listData = (List<TD_BangKeHoachTuyenDung>)brscGrdData.DataSource;

            foreach (TD_BangKeHoachTuyenDung item in listData)
            {

                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.MaKeHoach))// MaKeHoach nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaKeHoach.Text);
                    this.txtMaKeHoach.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.TenKeHoach)) //TenKeHoach not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenKeHoach.Text);
                    this.txtTenKeHoach.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<TD_BangKeHoachTuyenDung> listIndex = listData.Where(p => p.MaKeHoach == item.MaKeHoach).Select(p => p).ToList();

                if (listIndex.Count > 1)
                {
                    // Check IsExited MaChuyenNganh in Grid
                    foreach (TD_BangKeHoachTuyenDung index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblMaKeHoach.Text);
                    brscGrdData.Position = a;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Phans the quyen.
        /// </summary>
        private void PhanQuyen()
        {
            
            TD_BangKeHoachTuyenDung kehoach = brscGrdData.Current as TD_BangKeHoachTuyenDung;

            try
            {
                if (LayerCommon.CurrentUser.IsPhongNhanSu.Value)
                {
                    this.btnAdd.Enabled = _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                    this.btnDelete.Enabled = _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                    this.btnSave.Enabled = _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                }
                else
                {
                    this.btnAdd.Enabled = !_bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                    this.btnDelete.Enabled = !_bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                    this.btnSave.Enabled = !_bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                }
            }
            catch
            {

            }
            if (kehoach != null)
            {

                bool flagphanquyen = true ;// _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                try
                {
                    if (LayerCommon.CurrentUser.IsPhongNhanSu.Value)
                    {
                        // phong nhan su
                        // rieng phong nhan su chi nhin thay phongban khac ma khong duoc thao tac du lieu
                        if (kehoach.DaDuyet.Value)
                        {
                            // this.btnAdd.Enabled =_bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                            this.btnDelete.Enabled = !flagphanquyen && _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                            this.btnSave.Enabled = !flagphanquyen && _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                            Enable(!flagphanquyen && _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id) && !_busChiTiet.CheckedIsUsing(kehoach.Id));
                        }
                        else
                        {
                            //this.btnAdd.Enabled =_bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                            this.btnDelete.Enabled = flagphanquyen && _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                            this.btnSave.Enabled = flagphanquyen && _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                            Enable(flagphanquyen && _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id) && !_busChiTiet.CheckedIsUsing(kehoach.Id));
                        }

                    }
                    else
                    {
                        // phan quyen chung cho toan user
                        if (kehoach.DaDuyet.Value)
                        {
                            //this.btnAdd.Enabled = !flagphanquyen;
                            this.btnDelete.Enabled = !flagphanquyen;
                            this.btnSave.Enabled = !flagphanquyen;
                            Enable(!flagphanquyen && !_busChiTiet.CheckedIsUsing(kehoach.Id));
                        }
                        else
                        {
                            // this.btnAdd.Enabled = flagphanquyen;
                            this.btnDelete.Enabled = flagphanquyen;
                            this.btnSave.Enabled = flagphanquyen;
                            Enable(flagphanquyen && !_busChiTiet.CheckedIsUsing(kehoach.Id));
                        }
                    }
                }
                catch
                {

                }
               
              
              
                
            }
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            _listKhongduyet.Clear();
            List<TD_BangKeHoachTuyenDung> list = _bussKeHoach.GetDataByPhongBanQuy(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(this.cboQuy.Text), CommonUtil.IsInt(txtNam.Text));

            this.brscGrdData.DataSource = list;

            foreach (TD_BangKeHoachTuyenDung kehoach in list)
            {
                int a = list.IndexOf(kehoach);

                if (kehoach.KhongDuyet.Value)
                {
                    _listKhongduyet.Add(a);
                }
            }

            Enable(false);

            // phan quyen nhansu phongban
            PhanQuyen();

            
        }

        #endregion

        #region ---- Events ----

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                TD_BangKeHoachTuyenDungBLL _bussnew = new TD_BangKeHoachTuyenDungBLL();

                if (_bussnew.CheckedIsHasValue(item.Id))
                {
                    SF101 frm = new SF101();
                    frm.KeHoach = item;
                    frm.InputPhanQuyen = this.btnDelete.Enabled;
                    frm.Quy = ((DM_Quy)cboQuy.SelectedItem).Ten;
                    MngForms.ShowDialog(frm);
                }
                else
                {
                    UICommon.ShowMsgWarning("MSG018");
                    return;
                }

            }
            PhanQuyen();

        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            SaveFileDialog saveFile = new SaveFileDialog();
            Dictionary<string, string> pThongTin = new Dictionary<string, string>();

            if (brscGrdData.Count == 0)
            {
                UICommon.ShowMsgInfo("MSG022");
                return;
            }
            TD_BangKeHoachTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_BangKeHoachTuyenDung;
            List<TD_ChiTietKeHoachTuyenDung> dataSource = _busChiTiet.LoadAllData(tuyenDung.Id).ToList();
            if (tuyenDung == null || dataSource.Count == 0)
            {
                UICommon.ShowMsgInfo("MSG022");
            }
            else
            {
                pThongTin.Add("PhongBan", CacheData.GetTenPhongBan(tuyenDung.IdPhongBan));
                pThongTin.Add("Quy", tuyenDung.Quy.ToString());
                pThongTin.Add("Nam", tuyenDung.Nam.ToString());
                string path = string.Empty;
                excel.ExportKeHoachTuyenDung(dataSource, pThongTin, ref path, false);

                // Confirm for open file was exported
                if (!string.IsNullOrEmpty(path) && UICommon.ShowMessage("MSG023", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();

            Dictionary<string, string> pThongTin = new Dictionary<string, string>();
            if (brscGrdData.Count == 0)
            {
                UICommon.ShowMsgInfo("MSG022");
                return;
            }
            TD_BangKeHoachTuyenDung tuyenDung = brscGrdData.CurrencyManager.Current as TD_BangKeHoachTuyenDung;
            List<TD_ChiTietKeHoachTuyenDung> dataSource = _busChiTiet.LoadAllData(tuyenDung.Id).ToList();
            if (tuyenDung == null || dataSource.Count == 0)
            {
                UICommon.ShowMsgInfo("MSG022");

            }
            else
            {
                pThongTin.Add("PhongBan", CacheData.GetTenPhongBan(tuyenDung.IdPhongBan));
                pThongTin.Add("Quy", tuyenDung.Quy.ToString());
                pThongTin.Add("Nam", tuyenDung.Nam.ToString());
                string path = string.Empty;
                excel.ExportKeHoachTuyenDung(dataSource, pThongTin, ref path, true);
            }
        }

        #endregion

        #region ---- Textbox ----

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region ---- Combobox ----

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Handles the TextChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_TextChanged(object sender, EventArgs e)
        {
            brscGrdData.DataSource = _bussKeHoach.GetDataByTenPhongBan(this.cboPhongBan.Text);
            //// phan quyen nhan su phong ban
            PhanQuyen();
            // LoadData();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Handles the TextChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region ---- GrdData ----

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

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;

            if (item != null)
            {
                TD_BangKeHoachTuyenDungBLL _bussnew = new TD_BangKeHoachTuyenDungBLL();

                if (_bussnew.CheckedIsHasValue(item.Id))
                {
                    SF101 frm = new SF101();
                    frm.KeHoach = item;
                    frm.InputPhanQuyen = this.btnDelete.Enabled;
                    frm.Quy =  ((DM_Quy)cboQuy.SelectedItem).Ten;
                    MngForms.ShowDialog(frm);
                }
                else
                {
                    UICommon.ShowMsgWarning("MSG018");
                    return;
                }

            }
            PhanQuyen();

        }

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            PhanQuyen();
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                Enable(!_busChiTiet.CheckedIsUsing(item.Id));
            }
        }


        #endregion

        #region ---- Bingdingsource ----

        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            PhanQuyen();
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                Enable(!_busChiTiet.CheckedIsUsing(item.Id));
            }
        }

        #endregion

        #endregion
    }
}
