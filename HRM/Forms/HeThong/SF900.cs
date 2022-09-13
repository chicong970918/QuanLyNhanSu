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
using HRM.DataAccess.NguoiDung;
using Library.Class;

namespace HRM.Forms.HeThong
{
    /// <summary>
    /// 
    /// </summary>
    ///  03/08/11
    /// PC
    public partial class SF900 : TuyenDungBaseForm
    {
        #region ---- Variables ----

        QL_NguoiDungBLL _bussNguoiDung = null;
        private int _lastUpdate = -1;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF900()
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
            this.txtTenDangNhap.Focus();
            QL_NguoiDung item = new QL_NguoiDung();
            item.MatKhau = CommonUtil.Encrypt("123456", CommonUtil.PUBLIC_KEY);
            item.HoatDong = true;
            brscGrdData.Add(item);
            base.GetNewData();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            QL_NguoiDung item = brscGrdData.Current as QL_NguoiDung;
            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("QL_NguoiDung"))
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
                        _bussNguoiDung.DeleteData(item.Id);
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
            if (Validator() == true)
            {
                base.SaveData();
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    _lastUpdate = 1;
                    List<QL_NguoiDung> list = (List<QL_NguoiDung>)brscGrdData.DataSource;
                    _bussNguoiDung.UpdateDataList(list);
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
            this.btnSearch.Text = "Reset mật khẩu";
            this.btnSearch.Image = HRM.Properties.Resources.resetpassword;
            // Get data
            _bussNguoiDung = new  QL_NguoiDungBLL();
            _listError = new List<int>();
            this.brscGrdData.DataSource = _bussNguoiDung.GetAll();
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();
            // Add events
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            Enable(false);
            if (brscGrdData.Count > 0)
            {
                foreach (QL_NguoiDung item in (List<QL_NguoiDung>) brscGrdData.DataSource)
                {
                    NV_NhanVien uv = _bussNguoiDung.GetNhanVien(item.IdNhanVien);
                    if (uv != null)
                    {
                      item.MaNhanVien = uv.MaNhanVien;
                      item.HoDem = uv.HoDem;
                      item.Ten = uv.Ten;
                      item.TenPhongBan = _bussNguoiDung.GetTenPhongBan(uv.IdPhongBan);
                     
                    }
                }
            }
        }
       
        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtTenDangNhap.Enabled = pvalue;
            txtMaNhanVien.Enabled = pvalue;
            cbxHoatDong.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtTenDangNhap.DataBindings.Clear();
            txtMaNhanVien.DataBindings.Clear();
            cbxHoatDong.DataBindings.Clear();
            txtHoDem.DataBindings.Clear();
            txtTen.DataBindings.Clear();
            txtPhongBan.DataBindings.Clear();
          
            // Bingding
            txtTenDangNhap.DataBindings.Add("Text", brscGrdData, "TenDangNhap", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaNhanVien.DataBindings.Add("Text", brscGrdData, "MaNhanVien", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHoDem.DataBindings.Add("Text", brscGrdData, "HoDem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", brscGrdData, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);
            txtPhongBan.DataBindings.Add("Text", brscGrdData, "TenPhongBan", true, DataSourceUpdateMode.OnPropertyChanged);
            cbxHoatDong.DataBindings.Add("BoolValue", brscGrdData, "HoatDong", true, DataSourceUpdateMode.OnPropertyChanged);
           
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<QL_NguoiDung> listData = (List<QL_NguoiDung>)brscGrdData.DataSource;

            foreach (QL_NguoiDung item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.TenDangNhap))// TenDangNhap   nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenDAngNhap.Text);
                    this.txtTenDangNhap.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.MaNhanVien)) // MaNhanVien not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaNhanVien.Text);
                    this.txtMaNhanVien.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                bool isNhansu = false;
                NV_NhanVien uv = _bussNguoiDung.GetNhanVienByMaNhanVien(item.MaNhanVien,out   isNhansu);
                if (uv == null)
                {
                    UICommon.ShowMsgInfo("MSG013");
                    item .HoDem= string.Empty;
                    item.Ten = string.Empty;
                    item.TenPhongBan = string.Empty;
                    item.IsNhanSu = isNhansu;
                    this.txtMaNhanVien.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                else
                {
                    item.MaNhanVien = uv.MaNhanVien;
                    item.HoDem = uv.HoDem;
                    item.Ten = uv.Ten;
                    item.IsNhanSu = isNhansu;
                    item.TenPhongBan = _bussNguoiDung.GetTenPhongBan(uv.IdPhongBan);
                    item.IdNhanVien = uv.Id;
                }

                List<QL_NguoiDung> listIndex = listData.Where(p => p.TenDangNhap == item.TenDangNhap).Select(p => p).ToList();

                // Check IsExited TenDangNhap in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (QL_NguoiDung index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblTenDAngNhap.Text);
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
        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            QL_NguoiDung nguoidung = brscGrdData.Current as QL_NguoiDung;
            if (nguoidung != null)
            {
                nguoidung.MatKhau = CommonUtil.Encrypt("123456", CommonUtil.PUBLIC_KEY);
                _bussNguoiDung.UpdateData(nguoidung);
                UICommon.ShowSplashPanelUpdateMsg();
            }
        }

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

        #region ---- Textbox ----

        private void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                QL_NguoiDung item = brscGrdData.Current as QL_NguoiDung;
                if (item != null)
                {
                    bool isnhansu=false;
                    NV_NhanVien uv = _bussNguoiDung.GetNhanVienByMaNhanVien(txtMaNhanVien.Text,out isnhansu);
                    if (uv != null)
                    {
                        item.MaNhanVien = uv.MaNhanVien;
                        txtHoDem.Text = uv.HoDem;
                        txtTen.Text = uv.Ten;
                        txtPhongBan.Text = _bussNguoiDung.GetTenPhongBan(uv.IdPhongBan);
                        item.IsNhanSu = isnhansu;
                    }
                    else
                    {
                        UICommon.ShowMsgInfo("MSG013");
                        txtHoDem.Text = string.Empty;
                        txtTen.Text = string.Empty;
                        txtPhongBan.Text = string.Empty;
                    }
                }
            }
        } 

        #endregion

        #endregion
       
    }
}
