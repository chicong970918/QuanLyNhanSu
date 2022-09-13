using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.TuyenDung;
using HRM.Entities;
using HRM.DataAccess.Common;
using System.Data.Linq;
using Library.Class;
using HRM.Class;
using HRM.DataAccess.Catalogs;
using HRM.DataAccess.ChamCong_TinhLuong;

namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF308 : GridBaseForm
    {
        #region ---- Variables ----

        private DanhMucPhongBanBLL _bussPhongBan = null;
        private List<int> _listError = null;
        private TL_TamUngBLL _bussTamUng = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF308"/> class.
        /// </summary>
        public SF308()
        {
            InitializeComponent();
       
            InitForm();
        } 

        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            if (CommonUtil.IsInt(txtThang.IntegerValue.ToString()) < CacheData.Context.GetSystemDate().Month)
            {
                UICommon.ShowMsgInfo("MSG017", lblThang.Text, CacheData.Context.GetSystemDate().Month.ToString());
                txtThang.Focus();
                return;
            }
            if (CommonUtil.IsInt(txtNam.IntegerValue.ToString()) < CacheData.Context.GetSystemDate().Year)
            {
                UICommon.ShowMsgInfo("MSG017", lblNam.Text, CacheData.Context.GetSystemDate().Year.ToString());
                txtNam.Focus();
                return;
            }
            Enable(_bussTamUng.CheckedIsUsing(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)));
            // Add data in bindingsourec 
            
            // Remove sort
            this.GrdData.TableDescriptor.SortedColumns.Clear();
            
            TL_TamUng item = new TL_TamUng();
            item.SoTien = 0;
            item.NgayTamUng = CacheData.Context.GetSystemDate();
          
            brscGrdData.Add(item);
            
            base.GetNewData();
            
            this.txtMaNhanVien.Focus();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            //if (!AllowDeleteData())
            //{
            //    UICommon.ShowMsgInfo("MSG026");
            //    return;
            //}

            base.Deletedata();

            TL_TamUng item = brscGrdData.Current as TL_TamUng;
            if (item != null)
            {
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                {
                    brscGrdData.RemoveCurrent();
                    if (item.Id != 0)
                    {
                        _bussTamUng.DeleteData(item.Id);
                        UICommon.ShowSplashPanelUpdateMsg();
                        if (!(brscGrdData.Count > 0))
                        {
                            Enable(_bussTamUng.CheckedIsUsing(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)));
                        }
                        else
                        {
                            Enable(_bussTamUng.CheckedIsUsing(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)));
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
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    List<TL_TamUng> list = (List<TL_TamUng>)brscGrdData.DataSource;
                    _bussTamUng.UpdateDataList(list);
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
            GrdData.EndEdit();
            GrdData.RefreshData();
            GrdData.Refresh();
        }

        ///// <summary>
        ///// Allows the delete data.
        ///// </summary>
        ///// <returns></returns>
        ///// <Author>LONG LY</Author>
        ///// <Date>11/06/2011</Date>
        //protected override bool AllowDeleteData()
        //{
        //    return base.AllowDeleteData();
        //}

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Loads the combobox.
        /// </summary>
        private void LoadCombobox()
        {
            cboPhongBan.DataSource = _bussPhongBan.GetPhongBan();
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";

            // GetData
               this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();

            this.txtThang.IntegerValue = CacheData.Context.GetSystemDate().Month;
        }

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {

            // Get data
            _listError = new List<int>();
            _bussPhongBan = new DanhMucPhongBanBLL();
            _bussTamUng = new TL_TamUngBLL();
           
            btnExcelTemplate.Visible = true;
            btnPrintTemplate.Visible = true;
            btnExcel.Visible = false;
            btnPrint.Visible = false;

            LoadCombobox();

            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgayTamUng");
            UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "SoTien");
            // Add events 
           // this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            this.txtThang.TextChanged += new EventHandler(txtThang_TextChanged);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            this.txtMaNhanVien.KeyDown+=new KeyEventHandler(txtMaNhanVien_KeyDown);
            LoadData();
            // Load data by PhongBan
           
           this.AddDataBinding();

             
            Enable(false);

        }
     
        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            this.brscGrdData.DataSource = _bussTamUng.LoadDataByCondition(((DM_PhongBan)cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));

            this.GrdData.DataSource = brscGrdData;

            if (brscGrdData.Count <= 0)
            {
                Enable(false);
            }
        }

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtLyDo.Enabled = pvalue;
            txtMaNhanVien.Enabled = pvalue;
            txtSoTien.Enabled = pvalue;
            dtpNgayTamUng.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtLyDo.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Clear();
            txtSoTien.DataBindings.Clear();
            dtpNgayTamUng.DataBindings.Clear();

            // Bingding
            
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLyDo.DataBindings.Add("Text", brscGrdData, "LyDo", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaNhanVien.DataBindings.Add("Text", brscGrdData, "MaNhanVien", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSoTien.DataBindings.Add("Text", brscGrdData, "SoTien", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayTamUng.DataBindings.Add("Value", brscGrdData, "NgayTamUng", true, DataSourceUpdateMode.OnPropertyChanged);

            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<TL_TamUng> listData = (List<TL_TamUng>)brscGrdData.DataSource;

            foreach (TL_TamUng item in listData)
            {

                // Get The position of the Item
                int a = listData.IndexOf(item);

               

                if (string.IsNullOrEmpty(item.MaNhanVien)) // MaNhanVien not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaNhanVien.Text);
                    this.txtMaNhanVien.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                NV_NhanVien nhanvien = _bussTamUng.GetNhanVienByMaNhanVien(item.MaNhanVien,((DM_PhongBan)cboPhongBan.SelectedItem).Id);

                if (nhanvien == null)
                {
                    UICommon.ShowMsgInfo("MSG013");
                    this.txtMaNhanVien.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                else
                {
                    item.IdNhanVien = ((NV_NhanVien)nhanvien).Id;
                    item.HoDem = nhanvien.HoDem;
                    item.Ten = nhanvien.Ten;
                }

                if (!(item.NgayTamUng!=null))// dtpNgayTamUng nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblNgayTamUng.Text);
                    this.dtpNgayTamUng.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if ((CommonUtil.ParseDouble(item.SoTien.Value.ToString()) <= 0.0)) //sotien >=0
                {
                    UICommon.ShowMsgInfo("MSG017", lblSoTien.Text,txtSoTien.Text);
                    this.txtSoTien.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                if (_bussTamUng.CheckedTamUng(item.IdNhanVien,(CommonUtil.Parsedecimal(item.SoTien.Value.ToString())))==false)
                {
                    UICommon.ShowMsgInfo("MSG059", lblSoTien.Text, txtSoTien.Text);
                    this.txtSoTien.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<TL_TamUng> listIndex = listData.Where(p => p.MaNhanVien == item.MaNhanVien).Select(p => p).ToList();

                if (listIndex.Count > 1)
                {
                    // Check IsExited MaChuyenNganh in Grid
                    foreach (TL_TamUng index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG036", txtThang.Text);
                    brscGrdData.Position = a;
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region ---- Events ----


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

        #region ---- Textbox ----

        /// <summary>
        /// Handles the TextChanged event of the txtThang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void txtThang_TextChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void txtNam_TextChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }

        /// <summary>
        /// Handles the KeyDown event of the txtMaNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                TL_TamUng item = brscGrdData.Current as TL_TamUng;
                if (item != null)
                {
                    NV_NhanVien uv = _bussTamUng.GetNhanVienByMaNhanVien(txtMaNhanVien.Text,((DM_PhongBan)cboPhongBan.SelectedItem).Id);
                    if (uv != null)
                    {
                        item.MaNhanVien = uv.MaNhanVien;
                        item.HoDem = uv.HoDem;
                        item.Ten = uv.Ten;
                        GrdData.RefreshData();
                        GrdData.Refresh();
                    }
                    else
                    {
                        UICommon.ShowMsgInfo("MSG013");
                    }
                }
            }
        }

      
        #endregion

        #region ---- Combobox ----

        void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoadData();
        }  

        #endregion

        #region ---- Bingdingsource ----

        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            Enable(_bussTamUng.CheckedIsUsing(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)));
        }
        

        #endregion

        #endregion

    }
}
