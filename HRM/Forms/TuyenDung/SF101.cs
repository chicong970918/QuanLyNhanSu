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
    public partial class SF101 : TuyenDungBaseForm
    {
        #region ---- Variables ----

        private TD_BangKeHoachTuyenDung _KeHoachTuyenDung = null;
        private TD_ChiTietKeHoachTuyenDungBLL _bussChiTiet = null;
        private List<int> _listError = null;
        private bool _InputPhanQuyen = true;
        private int _Quy = -1;
 
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF101"/> class.
        /// </summary>
        public SF101()
        {
            InitializeComponent();
            _KeHoachTuyenDung = new TD_BangKeHoachTuyenDung();
            this.Load += new EventHandler(SF101_Load);
          //  this.InitForm();
        }

        
        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets a value indicating whether [input phan quyen].
        /// </summary>
        /// <value><c>true</c> if [input phan quyen]; otherwise, <c>false</c>.</value>
        public bool InputPhanQuyen
        {
            get { return _InputPhanQuyen; }
            set { _InputPhanQuyen = value; }
        }

        /// <summary>
        /// Gets or sets the ma ke hoach.
        /// </summary>
        /// <value>The ma ke hoach.</value>
        public TD_BangKeHoachTuyenDung KeHoach
        {
            get { return _KeHoachTuyenDung; }
            set { _KeHoachTuyenDung = value; }
        }

        /// <summary>
        /// Gets or sets the quy.
        /// </summary>
        /// <value>The quy.</value>
        public int Quy
        {
            get { return _Quy; }
            set { _Quy = value; }
        }
     

        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            Enable(true);
            // Add data in bindingsourec 
            this.txtMaChiTiet.Focus();
            TD_ChiTietKeHoachTuyenDung item = new TD_ChiTietKeHoachTuyenDung();
            item.IdBangKeHoachTuyenDung = _KeHoachTuyenDung.Id;
            item.IdChucDanh = -1;
            brscGrdData.Add(item);
            base.GetNewData();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            TD_ChiTietKeHoachTuyenDung item = brscGrdData.Current as TD_ChiTietKeHoachTuyenDung;
            if (item != null)
            {
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                {
                    brscGrdData.RemoveCurrent();
                    if (item.Id != 0)
                    {
                        _bussChiTiet.DeleteData(item.Id);
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
                    List<TD_ChiTietKeHoachTuyenDung> list = (List<TD_ChiTietKeHoachTuyenDung>)brscGrdData.DataSource;
                    _bussChiTiet.UpdateDataList(list);
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
            GrdData.EndEdit();
            GrdData.RefreshData();
            GrdData.Refresh();
        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;

  
            // Get data
            _bussChiTiet = new  TD_ChiTietKeHoachTuyenDungBLL();
            _listError = new List<int>();
            // Load data chucdanh
            this.cboChucDanh.DisplayMember = "TenChucDanh";
            this.cboChucDanh.ValueMember = "Id";
            this.cboChucDanh.DataSource = CacheData.GetDanhMucChucDanh();

            // load datalydo
            this.cboLyDo.DisplayMember = "TenLyDo";
            this.cboLyDo.ValueMember = "Id";
            this.cboLyDo.DataSource = CacheData.GetDanhMucLyDo();

            this.brscGrdData.DataSource = _bussChiTiet.LoadAllData(_KeHoachTuyenDung.Id);
            this.GrdData.DataSource = brscGrdData;

            cboChucDanh.SelectedIndex = -1;
            cboLyDo.SelectedIndex = -1;

            this.AddDataBinding();
            
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "ThoiGianCanNhanSu");

            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboChucDanh.SelectedIndexChanged += new EventHandler(cboChucDanh_SelectedIndexChanged);
            this.cboLyDo.SelectedIndexChanged += new EventHandler(cboLyDo_SelectedIndexChanged);
            Enable(false);
        }
 
        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtMaChiTiet.Enabled = pvalue;
            txtSoLuong.Enabled = pvalue;
            dtpNgayCan.Enabled = pvalue;
            cboChucDanh.Enabled = pvalue;
            cboLyDo.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaChiTiet.DataBindings.Clear();
            txtSoLuong.DataBindings.Clear();
            dtpNgayCan.DataBindings.Clear();
            cboChucDanh.DataBindings.Clear();
            cboLyDo.DataBindings.Clear();
            // Bingding
            dtpNgayCan.DataBindings.Add("Value", brscGrdData,"ThoiGianCanNhanSu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaChiTiet.DataBindings.Add("Text", brscGrdData, "MaChiTietTD", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChucDanh.DataBindings.Add("SelectedValue", brscGrdData, "IdChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboLyDo.DataBindings.Add("SelectedValue", brscGrdData, "IdLyDo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoLuong.DataBindings.Add("Text", brscGrdData, "SoLuong", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<TD_ChiTietKeHoachTuyenDung> listData = (List<TD_ChiTietKeHoachTuyenDung>)brscGrdData.DataSource;

            foreach (TD_ChiTietKeHoachTuyenDung item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.MaChiTietTD))//MaChiTietTD nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblChiTiet.Text);
                    this.txtMaChiTiet.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (item.IdChucDanh<0) // ChucDanh not null
                {
                    UICommon.ShowMsgInfo("MSG005",  lblChucDanh.Text);
                    this.cboChucDanh.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (!(item.SoLuong.HasValue))//MaChiTietTD nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblSoLuong.Text);
                    this.txtSoLuong.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (!(item.ThoiGianCanNhanSu.HasValue))//MaChiTietTD nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblNgayCan.Text);
                    this.dtpNgayCan.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (item.ThoiGianCanNhanSu.HasValue && ((item.ThoiGianCanNhanSu.Value.Month - 1) / 3) + 1 != _Quy)
                {
                    UICommon.ShowMsgInfo("MSG030", _Quy.ToString());
                    this.dtpNgayCan.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                 
                    return false;
                }
                if (item.ThoiGianCanNhanSu.HasValue && item.ThoiGianCanNhanSu.Value.Year!=_KeHoachTuyenDung.Nam.Value)
                {
                    UICommon.ShowMsgInfo("MSG049", _KeHoachTuyenDung.Nam.Value.ToString());
                    this.dtpNgayCan.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    return false;
                }
                List<TD_ChiTietKeHoachTuyenDung> listIndex = listData.Where(p => p.MaChiTietTD == item.MaChiTietTD).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (TD_ChiTietKeHoachTuyenDung index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblChiTiet.Text);
                    brscGrdData.Position = a;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            Enable(_InputPhanQuyen);
        }

        /// <summary>
        /// Checkeds the input phan quyen.
        /// </summary>
        /// <param name="pValue">if set to <c>true</c> [p value].</param>
        private void CheckedInputPhanQuyen(bool pValue)
        {
            this.btnAdd.Enabled = pValue;
            this.btnDelete.Enabled = pValue;
            this.btnSave.Enabled = pValue;
        }

        #endregion

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the SF101 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SF101_Load(object sender, EventArgs e)
        {
            InitForm();
            txtMaKeHoach.Text = _KeHoachTuyenDung.MaKeHoach;
            CheckedInputPhanQuyen(_InputPhanQuyen);
            _Quy = Quy;
        }
        

        #endregion

        #region ---- Events ----

        #region ---- Button ----

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

        #region ---- Combobox ----


        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboLyDo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void cboLyDo_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_ChiTietKeHoachTuyenDung chitiet = this.brscGrdData.Current as TD_ChiTietKeHoachTuyenDung;
            if (chitiet != null)
            {
                try
                {
                    chitiet.IdLyDo = ((DM_LyDo)this.cboLyDo.SelectedItem).Id;
                    chitiet.TenLyDo = CacheData.GetTenLyDo(((DM_LyDo)this.cboLyDo.SelectedItem).Id);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboChucDanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void cboChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_ChiTietKeHoachTuyenDung chitiet = this.brscGrdData.Current as TD_ChiTietKeHoachTuyenDung;
            if (chitiet != null)
            {
                try
                {
                    chitiet.IdChucDanh = ((DM_ChucDanh)this.cboChucDanh.SelectedItem).Id;
                    chitiet.TenChucDanh = CacheData.GetTenChucDanh(((DM_ChucDanh)this.cboChucDanh.SelectedItem).Id);
                }
                catch
                {

                }
            }
        }

        
        #endregion
        #endregion

    }
}
