using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.Entities;
using HRM.DataAccess.Catalogs;

namespace HRM.DanhMuc
{
    public partial class SF009 : DanhMucBase  
    {
       
        #region ---- Variable and Contructor ----

        private DanhMucCapTuyenDungBLL _busCapTuyenDung = null;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF001"/> class.
        /// </summary>
        /// 
        public SF009()
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
            DM_CapTuyenDung pb = new DM_CapTuyenDung();

            // Add to the binding source
            brscGrdData.Add(pb);

            EnableControls(true);

            // Set forcus the control
            txtMaCapTuyenDung.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            DM_CapTuyenDung item = brscGrdData.Current as DM_CapTuyenDung;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_CapTuyenDung"))
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
                        _busCapTuyenDung.DeleteData(item.Id);

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
            List<DM_CapTuyenDung> pb = brscGrdData.DataSource as List<DM_CapTuyenDung>;

            if (pb.Count > 0)
            {
                // Check the Validate
                if (ValidateData(pb))
                {
                    UICommon.StartUpdate();

                    //Update data
                    _busCapTuyenDung.UpdateDataList(pb);
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
            _busCapTuyenDung = new DanhMucCapTuyenDungBLL();

            // Set Visible the on
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;

            _listError = new List<int>();

            // Set enable controls
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
            brscGrdData.DataSource = _busCapTuyenDung.GetAll();

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
            txtMaCapTuyenDung.DataBindings.Clear();
           txtTenCapTuyenDung.DataBindings.Clear();

            // Add the binding

            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaCapTuyenDung.DataBindings.Add("Text", brscGrdData, "MaCapTuyenDung", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenCapTuyenDung.DataBindings.Add("Text", brscGrdData, "TenCapTuyenDung", true, DataSourceUpdateMode.OnPropertyChanged);
           
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<DM_CapTuyenDung> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (DM_CapTuyenDung pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);

                // Check Ma cap tuyen dung Not null
                if (string.IsNullOrEmpty(pb.MaCapTuyenDung))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaCapTuyenDung.Text);
                    // Set forcus control
                    txtMaCapTuyenDung.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(pb.TenCapTuyenDung))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenCapTuyenDung.Text);

                    // Set forcus control
                    txtTenCapTuyenDung.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Get the existed Phong ban
                List<DM_CapTuyenDung> listIndex = pList.Where(p => p.MaCapTuyenDung == pb.MaCapTuyenDung).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaCapTuyenDung == pb.MaCapTuyenDung).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (DM_CapTuyenDung index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaCapTuyenDung.Text);
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
            txtMaCapTuyenDung.Enabled = IsEnable;
            txtTenCapTuyenDung.Enabled = IsEnable;
            txtGhiChu.Enabled = IsEnable;
        }

        #endregion

        #region ---- Event ----

        /// <summary>
        /// Handles the QueryCellStyleInfo event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs"/> instance containing the event data.</param>
        private  void GrdData_QueryCellStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs e)
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
        public void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            EnableControls(true);
        }

        #endregion
    }
}
