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
    public partial class SF014 : DanhMucBase
    {
        #region ---- Variable and Contructor ----

        private DanhMucHuyenBLL _busHuyen = null;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF001"/> class.
        /// </summary>
        public SF014()
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
            DM_Huyen pb = new DM_Huyen();

            pb.IdTinh = (int)cboTinh.SelectedValue;

            // Add to the binding source
            brscGrdData.Add(pb);

            // set enable controls
            EnableControls(true);

            // Set forcus the control
            txtTenHuyen.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        /// 

        protected override void Deletedata()
        {
            DM_Huyen item = brscGrdData.Current as DM_Huyen;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_Huyen"))
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
                        _busHuyen.DeleteData(item.Id);

                        // Show Suceed panel
                        UICommon.ShowSplashPanelUpdateMsg();
                    }
                }
            }
            base.Deletedata();
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
            List<DM_Huyen> pb = brscGrdData.DataSource as List<DM_Huyen>;

            if (pb.Count > 0)
            {
                // Check the Validate
                if (ValidateData(pb))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _busHuyen.UpdateDataList(pb);
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
            _busHuyen = new DanhMucHuyenBLL();

            // Set Visible the on
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;

            _listError = new List<int>();

            //Set Enable controls
            EnableControls(false);

            // Format the Columns date time
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);

            cboTinh.SelectedIndexChanged += new EventHandler(cboTinh_SelectedIndexChanged);
        }

        /// <summary>
        /// Loas the data.
        /// </summary>
        private void LoaData()
        {
            cboTinh.SelectedIndexChanged -=new EventHandler(cboTinh_SelectedIndexChanged); 

            cboTinh.DataSource = _busHuyen.GetAllTinh();

            cboTinh.DisplayMember = "TenTinh";
            cboTinh.ValueMember = "Id";

            if (cboTinh.SelectedIndex >=0)
            {
                List<DM_Huyen> pList = _busHuyen.GetHuyenByIDTinh((int)cboTinh.SelectedValue);
                // Get the data
                brscGrdData.DataSource = pList;
            }
            
            // Set data to Grid
            GrdData.DataSource = brscGrdData;

            // Binding data
            AddDataBinding();
            cboTinh.SelectedIndexChanged+=new EventHandler(cboTinh_SelectedIndexChanged);
            
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clear the binding

            txtGhiChu.DataBindings.Clear();
            txtMaHuyen.DataBindings.Clear();
            txtTenHuyen.DataBindings.Clear();

            // Add the binding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaHuyen.DataBindings.Add("Text", brscGrdData, "MaHuyen", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenHuyen.DataBindings.Add("Text", brscGrdData, "TenHuyen", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<DM_Huyen> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (DM_Huyen pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);


                // Check Id Tinh Not null
                if (cboTinh.SelectedIndex<0)
                {
                    UICommon.ShowMsgInfo("MSG005", lblTinh.Text);

                    // Set forcus control
                    cboTinh.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(pb.TenHuyen))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenHuyen.Text);

                    // Set forcus control
                    txtTenHuyen.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check MaPhongBan Not null
                if (string.IsNullOrEmpty(pb.MaHuyen))
                {
                    UICommon.ShowMsgInfo("MSG005", lblmaHuyen.Text);
                    // Set forcus control
                    txtMaHuyen.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
               
                // Get the existed Phong ban
                List<DM_Huyen> listIndex = pList.Where(p => p.MaHuyen == pb.MaHuyen).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaHuyen == pb.MaHuyen).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (DM_Huyen index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblmaHuyen.Text);
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
            txtMaHuyen.Enabled = IsEnable;
            txtTenHuyen.Enabled = IsEnable;
             
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
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            EnableControls(true);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTinh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTinh.SelectedIndex >= 0)
            {
                brscGrdData.DataSource = _busHuyen.GetHuyenByIDTinh((int)(cboTinh.SelectedValue));
                _listError.Clear();
            }
        }

        #endregion
    }
}
