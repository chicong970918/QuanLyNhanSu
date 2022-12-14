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

namespace HRM.Forms.TuyenDung
{
    public partial class SF114 : TuyenDungBaseForm
    {
        #region ---- Variables ----

        private TD_YeuCauCongViecBLL _bussChiTietYeuCau = null;
        private List<int> _listError = null;
        private string _MaKeHoach = string.Empty;
        private int _IdChiTietKeHoach = -1;
        private DateTime? _NgayBatDau;
        private DateTime? _NgayKetThuc;
        private bool? _PhongBan = false;
        private bool _DanhGia = true;


        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF114"/> class.
        /// </summary>
        public SF114()
        {
            InitializeComponent();
            this.Load += new EventHandler(SF114_Load);
        }

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the id ke hoch thu viec.
        /// </summary>
        /// <value>The id ke hoch thu viec.</value>
        public int IdChiTietKeHochThuViec
        {
            get { return _IdChiTietKeHoach; }
            set { _IdChiTietKeHoach = value; }
        }

        /// <summary>
        /// Gets or sets the ma ke hoach.
        /// </summary>
        /// <value>The ma ke hoach.</value>
        public string MaKeHoach
        {
            get { return _MaKeHoach; }
            set { _MaKeHoach = value; }
        }

        /// <summary>
        /// Gets or sets the ngay bat dau.
        /// </summary>
        /// <value>The ngay bat dau.</value>
        public DateTime? NgayBatDau
        {
            get { return _NgayBatDau; }
            set { _NgayBatDau = value; }
        }

        /// <summary>
        /// Gets or sets the ngay ket thuc.
        /// </summary>
        /// <value>The ngay ket thuc.</value>
        public DateTime? NgayKetThuc
        {
            get { return _NgayKetThuc; }
            set { _NgayKetThuc = value; }
        }

        /// <summary>
        /// Gets or sets the phong ban.
        /// </summary>
        /// <value>The phong ban.</value>
        public bool? PhongBan
        {
            get { return _PhongBan; }
            set { _PhongBan = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [danh gia].
        /// </summary>
        /// <value><c>true</c> if [danh gia]; otherwise, <c>false</c>.</value>
        public bool DanhGia
        {
            get { return _DanhGia; }
            set { _DanhGia = value; }
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
            this.txtTenCongViec.Focus();
            TD_YeuCauCongViec item = new TD_YeuCauCongViec();
            item.IdChiTietKeHoachThuViec = _IdChiTietKeHoach;
            brscGrdData.Add(item);
            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            TD_YeuCauCongViec item = brscGrdData.Current as TD_YeuCauCongViec;
            if (item != null)
            {
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                {
                    brscGrdData.RemoveCurrent();
                    if (item.Id != 0)
                    {
                        _bussChiTietYeuCau.DeleteData(item.Id);
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
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    List<TD_YeuCauCongViec> list = (List<TD_YeuCauCongViec>)brscGrdData.DataSource;
                    _bussChiTietYeuCau.UpdateDataList(list);
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
            _bussChiTietYeuCau = new TD_YeuCauCongViecBLL();
            _listError = new List<int>();

            this.brscGrdData.DataSource = _bussChiTietYeuCau.GetYeuCauByChiTiet(_IdChiTietKeHoach);
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
            txtKetQua.Enabled = pvalue;
            //  txtMaKeHoach.Enabled = pvalue;
            txtTiTrong.Enabled = pvalue;
            txtTrachNhiem.Enabled = pvalue;
            txtTenCongViec.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtKetQua.DataBindings.Clear();
            txtTiTrong.DataBindings.Clear();
            txtTrachNhiem.DataBindings.Clear();
            txtTenCongViec.DataBindings.Clear();

            // Bingding
            txtKetQua.DataBindings.Add("Text", brscGrdData, "KetQua", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTrachNhiem.DataBindings.Add("Text", brscGrdData, "TrachNhiem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTiTrong.DataBindings.Add("Text", brscGrdData, "TiTrong", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenCongViec.DataBindings.Add("Text", brscGrdData, "TenCongViec", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<TD_YeuCauCongViec> listData = (List<TD_YeuCauCongViec>)brscGrdData.DataSource;

            foreach (TD_YeuCauCongViec item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.TenCongViec))//TenCongViec nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenCongViec.Text);
                    this.txtTenCongViec.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<TD_YeuCauCongViec> listIndex = listData.Where(p => p.TenCongViec == item.TenCongViec).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (TD_YeuCauCongViec index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblTenCongViec.Text);
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
            Enable(CheckedTime(_NgayBatDau, _NgayKetThuc) && (_bussChiTietYeuCau.CheckedPhanQuyen(_PhongBan.Value)));
        }

        /// <summary>
        /// Checkeds the input phan quyen.
        /// </summary>
        /// <param name="pValue">if set to <c>true</c> [p value].</param>
        private void CheckedInputPhanQuyen(bool pValue)
        {
            this.btnAdd.Enabled = pValue;
            this.btnDelete.Enabled = pValue;
            this.btnSave.Enabled = pValue;
        }

        private bool CheckedPhanQuyen()
        {
            return true;
        }
        /// <summary>
        /// Checkeds the time.
        /// </summary>
        /// <param name="pNgayBatDau">The p ngay bat dau.</param>
        /// <param name="pNgayKetThuc">The p ngay ket thuc.</param>
        /// <returns></returns>
        private bool CheckedTime(DateTime? pNgayBatDau, DateTime? pNgayKetThuc)
        {
            if (pNgayBatDau.HasValue && pNgayBatDau.Value < CacheData.Context.GetSystemDate())
            {
                return false;
            }
            return true;
        }

        #endregion

        #region ---- Event ----

      

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the SF101 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SF114_Load(object sender, EventArgs e)
        {
            InitForm();
            txtMaKeHoach.Text = _MaKeHoach;
            this._IdChiTietKeHoach = IdChiTietKeHochThuViec;
            txtMaKeHoach.Enabled = false;
            this._NgayBatDau = NgayBatDau;
            this._NgayKetThuc = NgayKetThuc;
            this._PhongBan = PhongBan;
            this._DanhGia = DanhGia;


            this.btnAdd.Enabled = CheckedTime(_NgayBatDau, _NgayKetThuc) && (_bussChiTietYeuCau.CheckedPhanQuyen(_PhongBan.Value));
            this.btnDelete.Enabled = CheckedTime(_NgayBatDau, _NgayKetThuc) && (_bussChiTietYeuCau.CheckedPhanQuyen(_PhongBan.Value));
            this.btnSave.Enabled = CheckedTime(_NgayBatDau, _NgayKetThuc) && (_bussChiTietYeuCau.CheckedPhanQuyen(_PhongBan.Value));


            //CheckedInputPhanQuyen(_InputPhanQuyen);

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
        #endregion
    }
}
