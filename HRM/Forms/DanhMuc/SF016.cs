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
    public partial class SF016 : DanhMucBase
    {
        #region ---- Variable and Contructor ----

        private DanhMucTrinhDoBLL _busTrinhDo = null;
        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF001"/> class.
        /// </summary>
        public SF016()
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
            DM_TrinhDo pb = new DM_TrinhDo();

            // set enable controls
            EnableControls(true);

            // Add to the binding source
            brscGrdData.Add(pb);

            // Set forcus the control
            txtMaTrinhDo.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            DM_TrinhDo item = brscGrdData.Current as DM_TrinhDo;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_TrinhDo"))
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
                        _busTrinhDo.DeleteData(item.Id);

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
            List<DM_TrinhDo> td = brscGrdData.DataSource as List<DM_TrinhDo>;

            if (td.Count > 0)
            {

                // Check the Validate
                if (ValidateData(td))
                {
                    UICommon.StartUpdate();
                    // Update data
                    _busTrinhDo.UpdateDataList(td);
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
            _busTrinhDo = new DanhMucTrinhDoBLL();

            // Set Visible the on
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;

            _listError = new List<int>();

            //Set Enable controls
            EnableControls(false);


            this.FormClosing += new FormClosingEventHandler(SF016_FormClosing);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
        }

        /// <summary>
        /// Loas the data.
        /// </summary>
        public void LoaData()
        {
            // Get the data
            brscGrdData.DataSource = _busTrinhDo.GetAll();

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
            txtMaTrinhDo.DataBindings.Clear();
            txtTenTrinhDo.DataBindings.Clear();
            txtHeSoChuyenMon.DataBindings.Clear();
            // Add the binding

            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu",true,DataSourceUpdateMode.OnPropertyChanged);
            txtMaTrinhDo.DataBindings.Add("Text", brscGrdData, "MaTrinhDo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenTrinhDo.DataBindings.Add("Text", brscGrdData, "TenTrinhDo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHeSoChuyenMon.DataBindings.Add("Text", brscGrdData, "HeSoChuyenMon", true, DataSourceUpdateMode.OnPropertyChanged);
            
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<DM_TrinhDo> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (DM_TrinhDo pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);

                // Check MaPhongBan Not null
                if (string.IsNullOrEmpty(pb.MaTrinhDo))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaTrinhDo.Text);
                    // Set forcus control
                    txtMaTrinhDo.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(pb.TenTrinhDo))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenTrinhDo.Text);

                    // Set forcus control
                    txtTenTrinhDo.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
                // Check  HeSoChuyenMon Not null
                if ( !(pb.HeSoChuyenMon.HasValue))
                {
                    UICommon.ShowMsgInfo("MSG005", lblHeSoChuyenMon.Text);

                    // Set forcus control
                    txtTenTrinhDo.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Get the existed Phong ban
                List<DM_TrinhDo> listIndex = pList.Where(p => p.MaTrinhDo == pb.MaTrinhDo).Select(p => p).ToList();

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaTrinhDo == pb.MaTrinhDo).Count() > 1) // || _busTrinhDo.CheckIsExittedMaTrinhDo(pb))
                {
                    // Travel the list phong ban existed
                    foreach (DM_TrinhDo index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaTrinhDo.Text);
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
            txtMaTrinhDo.Enabled = IsEnable;
            txtTenTrinhDo.Enabled = IsEnable;
            txtHeSoChuyenMon.Enabled = IsEnable;
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
        public void SF016_FormClosing(object sender, FormClosingEventArgs e)
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
