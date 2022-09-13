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

namespace HRM.Forms.HeThong
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SF903 : DanhMucBase
    {    
        #region ---- Variables ----

        private DanhMucManHinhBLL _busManHinh = null;
        private int _lastUpdate = -1;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ---- 

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF903()
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
            this.txtMaManHinh.Focus();
            DM_ManHinh item = new DM_ManHinh();
            brscGrdData.Add(item);
            base.GetNewData();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            DM_ManHinh item = brscGrdData.Current as DM_ManHinh;
            if (item != null)
            {
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                {
                    brscGrdData.RemoveCurrent();
                    if (item.Id != 0)
                    {
                        _busManHinh.DeleteData(item.Id);
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

            if (Validator() == true)
            {
                base.SaveData();
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    _lastUpdate = 1;
                    List<DM_ManHinh> list = (List<DM_ManHinh>)brscGrdData.DataSource;
                    _busManHinh.UpdateDataList(list);
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
            _busManHinh = new DanhMucManHinhBLL();
            _listError = new List<int>();
            this.brscGrdData.DataSource = _busManHinh.GetAll();
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            Enable(false);
        }

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtMaManHinh.Enabled = pvalue;
            txtTenManHinh.Enabled = pvalue;
        }
        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtMaManHinh.DataBindings.Clear();
            txtTenManHinh.DataBindings.Clear();
            // Bingding
            txtMaManHinh.DataBindings.Add("Text", brscGrdData, "MaManHinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenManHinh.DataBindings.Add("Text", brscGrdData, "TenManHinh", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<DM_ManHinh> listData = (List<DM_ManHinh>)brscGrdData.DataSource;

            foreach (DM_ManHinh item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.MaManHinh))// MaChuyen Nganh nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaManHinh.Text);
                    this.txtMaManHinh.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.TenManHinh)) // Ten chuyen nganh not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenManHinh.Text);
                    this.txtTenManHinh.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<DM_ManHinh> listIndex = listData.Where(p => p.MaManHinh == item.MaManHinh).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (DM_ManHinh index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblMaManHinh.Text);
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
