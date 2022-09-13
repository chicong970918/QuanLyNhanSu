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

namespace HRM.DanhMuc
{
    public partial class SF010 : DanhMucBase
    {
        #region ---- Variable and Contructor ----

        private DanhMucChucDanhBLL _busChucDanh = null;

        private List<int> _listError = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SF001"/> class.
        /// </summary>
        /// 
        public SF010()
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
            DM_ChucDanh pb = new DM_ChucDanh();

            // Add to the binding source
            brscGrdData.Add(pb);

            EnableControls(true);
            
            // Set forcus the control
            txtMaChucDanh.Focus();

            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            DM_ChucDanh item = brscGrdData.Current as DM_ChucDanh;

            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_ChucDanh"))
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
                        _busChucDanh.DeleteData(item.Id);

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
            brscGrdData.EndEdit();
            List<DM_ChucDanh> pb = brscGrdData.DataSource as List<DM_ChucDanh>;
            base.SaveData();
            if (pb.Count > 0)
            {
                // Check the Validate
                if (ValidateData(pb))
                {
                    UICommon.StartUpdate();
                    //Update data
                    _busChucDanh.UpdateDataList(pb);
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

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            _busChucDanh = new DanhMucChucDanhBLL();

            // Set Visible the on
            btnSearch.Visible = false;
            toolStripSeparator1.Visible = false;

            _listError = new List<int>();

            UICommon.GridFormatNumber(GrdData.TableDescriptor.Columns, false, "HeSoChucVu", "HeSoTrachNhiem");
            UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "LuongCanBan");
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
            brscGrdData.DataSource = _busChucDanh.GetAll();

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
            txtMaChucDanh.DataBindings.Clear();
            txtTenChuDanh.DataBindings.Clear();
            txtHSTrachNhiem.DataBindings.Clear();
            txtLuongCoBan.DataBindings.Clear();
            txtHeSoChucVu.DataBindings.Clear();
            // Add the binding

            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaChucDanh.DataBindings.Add("Text", brscGrdData, "MaChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenChuDanh.DataBindings.Add("Text", brscGrdData, "TenChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            chkTruongPhong.DataBindings.Add("BoolValue", brscGrdData, "TruongPhong", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHSTrachNhiem.DataBindings.Add("Text", brscGrdData, "HeSoTrachNhiem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLuongCoBan.DataBindings.Add("Text", brscGrdData, "LuongCanBan", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHeSoChucVu.DataBindings.Add("Text", brscGrdData, "HeSoChucVu", true, DataSourceUpdateMode.OnPropertyChanged);
           
        }

        /// <summary>
        /// Validates the data.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        private bool ValidateData(List<DM_ChucDanh> pList)
        {
            // Clear the list error
            this._listError.Clear();

            foreach (DM_ChucDanh pb in pList)
            {
                // Get The position of the Item
                int a = pList.IndexOf(pb);

                // Check Ma ly do dung Not null
                if (string.IsNullOrEmpty(pb.MaChucDanh))
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaChucDanh.Text);
                    // Set forcus control
                    txtMaChucDanh.Focus();

                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Check TenPhongBan Not null
                if (string.IsNullOrEmpty(pb.TenChucDanh))
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenChucDanh.Text);

                    // Set forcus control
                    txtTenChuDanh.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (!(pb.LuongCanBan.HasValue))
                {
                    UICommon.ShowMsgInfo("MSG005", lblLuong.Text);

                    // Set forcus control
                    txtLuongCoBan.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
                if (!(pb.HeSoTrachNhiem.HasValue))
                {
                    UICommon.ShowMsgInfo("MSG005", lblHeSoTrachNhiem.Text);

                    // Set forcus control
                    txtHSTrachNhiem.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                if (!(pb.HeSoChucVu.HasValue))
                {
                    UICommon.ShowMsgInfo("MSG005", lblHeSoChucDanh.Text);

                    // Set forcus control
                    txtHeSoChucVu.Focus();

                    // Set position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }

                // Get the existed Phong ban
                List<DM_ChucDanh> listIndex = pList.Where(p => p.MaChucDanh == pb.MaChucDanh).Select(p => p).ToList();
             

                // Check IsExited MaPhongBan in Grid
                if (pList.Where(p => p.MaChucDanh == pb.MaChucDanh).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (DM_ChucDanh index in listIndex)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", lblMaChucDanh.Text);
                    // Set the position
                    brscGrdData.Position = a;

                    // Add to the error list
                    _listError.Add(a);

                    return false;
                }
                // Get the existed truong phong
                List<DM_ChucDanh> listIndexTruongphong = pList.Where(p => p.TruongPhong == true).Select(p => p).ToList();

                if (listIndexTruongphong.Where(p => p.TruongPhong == pb.TruongPhong).Count() > 1)
                {
                    // Travel the list phong ban existed
                    foreach (DM_ChucDanh index in listIndexTruongphong)
                    {
                        // Add error to the list
                        _listError.Add(brscGrdData.IndexOf(index));
                    }

                    UICommon.ShowMsgInfo("MSG008", chkTruongPhong.Text);
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
            txtMaChucDanh.Enabled = IsEnable;
            txtTenChuDanh.Enabled = IsEnable;
            txtGhiChu.Enabled = IsEnable;
            txtHSTrachNhiem.Enabled = IsEnable;
            txtLuongCoBan.Enabled = IsEnable;
            txtHeSoChucVu.Enabled = IsEnable;
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
