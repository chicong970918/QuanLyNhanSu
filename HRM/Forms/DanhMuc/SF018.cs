using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.Catalogs;
using HRM.Entities;


namespace HRM.Forms.DanhMuc
{
    public partial class SF018 : DanhMucBase
    {
        #region ---- Variables ----

        private DM_ThuongNgayLeBLL _bussThuongLe = null;
        private DM_ChiTietThuongNgayLeBLL _bussChiTiet = null;
        private List<int> _listError = null;
        private DM_ThuongNgayLe _ThuongLe = null;
 
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF101"/> class.
        /// </summary>
        public SF018()
        {
            InitializeComponent();
            _bussThuongLe = new  DM_ThuongNgayLeBLL();
            this.Load += new EventHandler(SF018_Load);
          //  this.InitForm();
        }

        
        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the thuong le.
        /// </summary>
        /// <value>The thuong le.</value>
        public DM_ThuongNgayLe ThuongLe
        {
            get { return _ThuongLe; }
            set { _ThuongLe = value; }
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
            this.cboChucDanh.Focus();
            DM_ChiTietThuongNgayLe item = new DM_ChiTietThuongNgayLe();
            item.IdThuongNgayLe = _ThuongLe.Id;
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

            DM_ChiTietThuongNgayLe item = brscGrdData.Current as DM_ChiTietThuongNgayLe;
            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_ChiTietThuongNgayLe"))
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
        /// Allows the delete data.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        
        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
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
                    List<DM_ChiTietThuongNgayLe> list = (List<DM_ChiTietThuongNgayLe>)brscGrdData.DataSource;
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
            _bussChiTiet = new   DM_ChiTietThuongNgayLeBLL();
            _listError = new List<int>();
            // Load data chucdanh
            this.cboChucDanh.DisplayMember = "TenChucDanh";
            this.cboChucDanh.ValueMember = "Id";
            this.cboChucDanh.DataSource = CacheData.GetDanhMucChucDanh();

            this.brscGrdData.DataSource = _bussChiTiet.LoadDataBycondition(((DM_ThuongNgayLe)_ThuongLe).Id);
            this.GrdData.DataSource = brscGrdData;

            cboChucDanh.SelectedIndex = -1;

            this.AddDataBinding();

            UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns,"MucThuong");

            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboChucDanh.SelectedIndexChanged += new EventHandler(cboChucDanh_SelectedIndexChanged);
            Enable(false);
        }
 
        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtMucThuong.Enabled = pvalue;
            cboChucDanh.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMucThuong.DataBindings.Clear();
            cboChucDanh.DataBindings.Clear();
            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMucThuong.DataBindings.Add("Text", brscGrdData, "MucThuong", true, DataSourceUpdateMode.OnPropertyChanged);
            cboChucDanh.DataBindings.Add("SelectedValue", brscGrdData, "IdChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<DM_ChiTietThuongNgayLe> listData = (List<DM_ChiTietThuongNgayLe>)brscGrdData.DataSource;

            foreach (DM_ChiTietThuongNgayLe item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (item.IdChucDanh<0) // ChucDanh not null
                {
                    UICommon.ShowMsgInfo("MSG005",  lblChucDanh.Text);
                    this.cboChucDanh.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (!(item.MucThuong.HasValue))//MucThuong nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMucThuong.Text);
                    this.txtMucThuong.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<DM_ChiTietThuongNgayLe> listIndex = listData.Where(p => p.IdChucDanh == item.IdChucDanh).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (DM_ChiTietThuongNgayLe index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblChucDanh.Text);
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
            Enable(true);
        }

        #endregion

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the SF101 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SF018_Load(object sender, EventArgs e)
        {
            InitForm();
            txtMaNgayLe.Text = _ThuongLe.MaNgayLe;
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
        /// Handles the SelectedIndexChanged event of the cboChucDanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void cboChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            DM_ChiTietThuongNgayLe chitiet = this.brscGrdData.Current as DM_ChiTietThuongNgayLe;
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
