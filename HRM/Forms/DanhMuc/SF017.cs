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
    public partial class SF017 : DanhMucBase
    {
         #region ---- Variables ----

        DM_ThuongNgayLeBLL _bussThuongLe = null;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF017()
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
            Enable(true);
            // Add data in bindingsourec 
            this.txtMaNgayLe.Focus();
            DM_ThuongNgayLe item = new DM_ThuongNgayLe();
            item.NgayLe = CacheData.Context.GetSystemDate();
            brscGrdData.Add(item);
            base.GetNewData();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            DM_ThuongNgayLe item = brscGrdData.Current as DM_ThuongNgayLe;
            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_ThuongNgayLe"))
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
                        _bussThuongLe.DeleteData(item.Id);
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

        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
           
            if (Validator() == true)
            {
                base.SaveData();
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    List<DM_ThuongNgayLe> list = (List<DM_ThuongNgayLe>)brscGrdData.DataSource;
                    _bussThuongLe.UpdateDataList(list);
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
            _bussThuongLe = new  DM_ThuongNgayLeBLL();
            _listError = new List<int>();
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgayLe");
            this.brscGrdData.DataSource = _bussThuongLe.GetAll();
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            Enable(false);
        }
 

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtMaNgayLe.Enabled = pvalue;
            txtTenNgayLe.Enabled = pvalue;
            dtpNgayLe.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaNgayLe.DataBindings.Clear();
            txtTenNgayLe.DataBindings.Clear();
            dtpNgayLe.DataBindings.Clear();
            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaNgayLe.DataBindings.Add("Text", brscGrdData, "MaNgayLe", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenNgayLe.DataBindings.Add("Text", brscGrdData, "TenNgayLe", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayLe.DataBindings.Add("Value", brscGrdData, "NgayLe", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
      
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<DM_ThuongNgayLe> listData = (List<DM_ThuongNgayLe>)brscGrdData.DataSource;

            foreach (DM_ThuongNgayLe item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.MaNgayLe))// MaNgayLe nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaNgayLe.Text);
                    this.txtMaNgayLe.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.TenNgayLe)) // TenNgayLe not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenNgayLe.Text);
                    this.txtTenNgayLe.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                if (item.NgayLe == null)
                {
                    UICommon.ShowMsgInfo("MSG005", dtpNgay.Text);
                    this.dtpNgayLe.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<DM_ThuongNgayLe> listIndex = listData.Where(p => p.MaNgayLe == item.MaNgayLe).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (DM_ThuongNgayLe index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008",lblMaNgayLe.Text);
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

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            DM_ThuongNgayLe item = brscGrdData.Current as DM_ThuongNgayLe;
            if (item != null)
            {
                SF018 frm = new SF018();
                frm.ThuongLe = item;
                frm.ShowDialog();
            }
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

        #endregion
    }
}
