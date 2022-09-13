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
    public partial class SF001 : DanhMucBase
    {
        #region ---- Variable and Contructor ----

        private DanhMucPhongBanBLL _busPhongBan = null;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF001"/> class.
        /// </summary>
        public SF001()
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
            DM_PhongBan pb = new DM_PhongBan();

            pb.IsPhongNhanSu = false;

            // set enable controls
            EnableControls(true);

            // Add to the binding source
            brscGrdData.Add(pb);

            // Set forcus the control
            txtMaPhongBan.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            DM_PhongBan item = brscGrdData.Current as DM_PhongBan;
            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_PhongBan"))
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
                        _busPhongBan.DeleteData(item.Id);

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
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            base.SaveData();

            List<DM_PhongBan> pb = brscGrdData.DataSource as List<DM_PhongBan>;
            
            if (pb.Count > 0)
            {

                // Check the Validate
                if (ValidateData(pb))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _busPhongBan.UpdateDataList(pb);
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
        /// Allows the delete data.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
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
            _busPhongBan = new DanhMucPhongBanBLL();

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
            brscGrdData.DataSource = _busPhongBan.GetAll();

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
            txtMaPhongBan.DataBindings.Clear();
            txtTenPhongBan.DataBindings.Clear();
            txtTruongPhong.DataBindings.Clear();
            dtpNgayThanhLap.DataBindings.Clear();
            chkNhanSu.DataBindings.Clear();
            // Add the binding

            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu",true,DataSourceUpdateMode.OnPropertyChanged);
            txtMaPhongBan.DataBindings.Add("Text", brscGrdData, "MaPhongBan", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenPhongBan.DataBindings.Add("Text", brscGrdData, "TenPhongBan", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTruongPhong.DataBindings.Add("Text", brscGrdData, "TruongPhongBan", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayThanhLap.DataBindings.Add("Value", brscGrdData, "NgayThanhLap", true, DataSourceUpdateMode.OnPropertyChanged);
            chkNhanSu.DataBindings.Add("BoolValue", brscGrdData, "IsPhongNhanSu", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<DM_PhongBan> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (DM_PhongBan pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);

                // Check MaPhongBan Not null
                if (string.IsNullOrEmpty(pb.MaPhongBan))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaPhongBan.Text);
                    // Set forcus control
                    txtMaPhongBan.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(pb.TenPhongBan))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenPhongBan.Text);

                    // Set forcus control
                    txtTenPhongBan.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

              

                // Get the existed Phong ban
                List<DM_PhongBan> listIndex = pList.Where(p => p.MaPhongBan == pb.MaPhongBan).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaPhongBan == pb.MaPhongBan).Count() > 1) // || _busPhongBan.CheckIsExittedMaPhongBan(pb))
                {
                    // Travel the list phong ban existed
                    foreach (DM_PhongBan index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaPhongBan.Text);
                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Get the existed truong phong
                List<DM_PhongBan> listIndexPhongBan = pList.Where(p => p.IsPhongNhanSu == true).Select(p => p).ToList();

                if (listIndexPhongBan.Where(p => p.IsPhongNhanSu == pb.IsPhongNhanSu).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (DM_PhongBan index in listIndexPhongBan)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", chkNhanSu.Text);
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
            txtMaPhongBan.Enabled = IsEnable;
            txtTenPhongBan.Enabled = IsEnable;
            txtTruongPhong.Enabled = IsEnable;
            dtpNgayThanhLap.Enabled = IsEnable;
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
        /// Handles the FormClosing event of the SF001 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosingEventArgs"/> instance containing the event data.</param>
        public void SF001_FormClosing(object sender, FormClosingEventArgs e)
        {
            //List<DM_PhongBan> pList = brscGrdData.DataSource as List<DM_PhongBan>;
            //foreach (DM_PhongBan pb in pList)
            //{
            //    //if (_busPhongBan.CheckStateChange(pb))
            //    //{
            //    //    UICommon.ShowMsgConfirm("MSG010");
            //    //}

            //    _busPhongBan.RefeshContext(pb);
            //}
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
