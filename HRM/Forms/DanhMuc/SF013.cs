using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.Class;
using HRM.DataAccess.Catalogs;
using HRM.Entities;

namespace HRM.DanhMuc
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SF013 : DanhMucBase
    {
        #region ---- Variable and Contructor ----

        private DanhMucTinhBLL _busTinh = null;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF013"/> class.
        /// </summary>
        public SF013()
        {
            InitializeComponent();

            InitForm();
            //Load data
            LoaData();
        }

        #endregion

        #region ---- Protected ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            // New instance 
            DM_Tinh pb = new DM_Tinh();

            // set enable controls
            EnableControls(true);

            // Add to the binding source
            brscGrdData.Add(pb);

            // Set forcus the control
            txtMaTinh.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            DM_Tinh item = brscGrdData.Current as DM_Tinh;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_Tinh"))
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
                        _busTinh.DeleteData(item.Id);

                        // Show Suceed panel
                        UICommon.ShowSplashPanelUpdateMsg();
                    }
                }
                base.Deletedata();
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
            List<DM_Tinh> pb = brscGrdData.DataSource as List<DM_Tinh>;

            if (pb.Count > 0)
            {
                // Check the Validate
                if (ValidateData(pb))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _busTinh.UpdateDataList(pb);
                    UICommon.StopUpdate();
                    // Show suceed panel
                    UICommon.ShowSplashPanelUpdateMsg();
                }

                // Refesh list data
                GrdData.EndEdit();
                GrdData.RefreshData();
                GrdData.Refresh();

                base.SaveData();
            }
        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            _busTinh = new DanhMucTinhBLL();

            // Set Visible the on
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;

            _listError = new List<int>();

            //Set Enable controls
            EnableControls(false);

            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
        }

        /// <summary>
        /// Loas the data.
        /// </summary>
        public void LoaData()
        {
            // Get the data
            brscGrdData.DataSource = _busTinh.GetAll();

            // Set data to Grid
            GrdData.DataSource = brscGrdData;

            // Binding data
            AddDataBinding();
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clear the binding

            txtGhiChu.DataBindings.Clear();
            txtMaTinh.DataBindings.Clear();
            txtTenTinh.DataBindings.Clear();

            // Add the binding

            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaTinh.DataBindings.Add("Text", brscGrdData, "MaTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenTinh.DataBindings.Add("Text", brscGrdData, "TenTinh", true, DataSourceUpdateMode.OnPropertyChanged);
             
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<DM_Tinh> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (DM_Tinh pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);

                // Check MaPhongBan Not null
                if (string.IsNullOrEmpty(pb.MaTinh))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaTinh.Text);
                    // Set forcus control
                    txtMaTinh.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(pb.TenTinh))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenTinh.Text);

                    // Set forcus control
                    txtTenTinh.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }


                // Get the existed Phong ban
                List<DM_Tinh> listIndex = pList.Where(p => p.MaTinh == pb.MaTinh).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaTinh == pb.MaTinh).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (DM_Tinh index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaTinh.Text);
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
        /// Enables the controls.
        /// </summary>
        /// <param name="IsEnable">if set to <c>true</c> [is enable].</param>
        private void EnableControls(bool IsEnable)
        {
            txtGhiChu.Enabled = IsEnable;
            txtMaTinh.Enabled = IsEnable;
            txtTenTinh.Enabled = IsEnable;
        }

        #endregion

        #region ---- Event ----

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
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            EnableControls(true);
        }

        #endregion
    }
}
