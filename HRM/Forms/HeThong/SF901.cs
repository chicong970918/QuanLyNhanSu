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
using HRM.DataAccess;

namespace HRM.DanhMuc
{
    /// <summary>
    /// 
    /// </summary>
    public partial class SF901 : DanhMucBase
    {
        #region ---- Variable and Contructor ----

        private QL_NhomNguoiDungBLL _busNhomNguoiDung = null;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF001"/> class.
        /// </summary>
        public SF901()
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
            QL_NhomNguoiDung pb = new QL_NhomNguoiDung();

            // set enable controls
            EnableControls(true);

            // Add to the binding source
            brscGrdData.Add(pb);

            // Set forcus the control
            txtMaNhom.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            QL_NhomNguoiDung item = brscGrdData.Current as QL_NhomNguoiDung;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("QL_NhomNguoiDung"))
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
                        _busNhomNguoiDung.DeleteData(item.Id);

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
        ///  20/08/11
        /// PC
        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            List<QL_NhomNguoiDung> pb = brscGrdData.DataSource as List<QL_NhomNguoiDung>;

            if (pb.Count > 0)
            {

                // Check the Validate
                if (ValidateData(pb))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _busNhomNguoiDung.UpdateDataList(pb);

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
            _busNhomNguoiDung = new QL_NhomNguoiDungBLL();

            // Set Visible the on
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;

            _listError = new List<int>();

            //Set Enable controls
            EnableControls(false);

            // Format the Columns date time
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgayThanhLap");
            this.FormClosing += new FormClosingEventHandler(SF001_FormClosing);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
        }

        /// <summary>
        /// Loas the data.
        /// </summary>
        public void LoaData()
        {
            // Get the data
            brscGrdData.DataSource = _busNhomNguoiDung.GetAll();

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
            txtMaNhom.DataBindings.Clear();
            txtTenNhom.DataBindings.Clear();

            // Add the binding

            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaNhom.DataBindings.Add("Text", brscGrdData, "MaNhom", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenNhom.DataBindings.Add("Text", brscGrdData, "TenNhom", true, DataSourceUpdateMode.OnPropertyChanged);
            
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<QL_NhomNguoiDung> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (QL_NhomNguoiDung pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);

                // Check MaNhom Not null
                if (string.IsNullOrEmpty(pb.MaNhom))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaNhom.Text);
                    // Set forcus control
                    txtMaNhom.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenNhom Not null
                if (string.IsNullOrEmpty(pb.TenNhom))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenNhom.Text);

                    // Set forcus control
                    txtTenNhom.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
                 

                // Get the existed NhomNguoiDung
                List<QL_NhomNguoiDung> listIndex = pList.Where(p => p.MaNhom == pb.MaNhom).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaNhom == pb.MaNhom).Count() > 1 && _busNhomNguoiDung.CheckIsExittedMaNhom(pb))
                {
                    // Travel the list phong ban existed
                    foreach (QL_NhomNguoiDung index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaNhom.Text);
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
            txtTenNhom.Enabled = IsEnable;
            txtMaNhom.Enabled = IsEnable;
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
        /// Handles the FormClosing event of the SF001 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        public void SF001_FormClosing(object sender, FormClosingEventArgs e)
        { 
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
