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
using HRM.DataAccess.QuanLyNhanVien;

namespace HRM.Forms.NhanVien
{
    public partial class SF214 : TuyenDungBaseForm
    {
        #region ---- Variables ----

        private int _IdNhanVien = -1;
        private NV_HopDongBLL _bussHopDong = null;
        private List<int> _listError = null;
        #endregion
 
        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF205"/> class.
        /// </summary>
        public SF214()
        {
            InitializeComponent();
            this.Load += new EventHandler(SF214_Load);
            dtpNgayKetThuc.Value = null;
            dtpNgayBatDau.Value = null;
            dtpNgayKy.Value = null;
        }
 
        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the id nhan vien.
        /// </summary>
        /// <value>The id nhan vien.</value>
        public int IdNhanVien
        {
            get { return _IdNhanVien; }
            set { _IdNhanVien = value; }
        } 

        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            if (brscGrdData.Count > 0)
            {
                UICommon.ShowMsgInfo("MSG047", "thử việc");
                return;
            }


            Enable(true);
            // Add data in bindingsourec 
            this.dtpNgayKy.Focus();
            NV_HopDong item = new NV_HopDong();
            item.IdNhanVien = _IdNhanVien;
         
            item.IdLoaiHopDong = 1;
          //  item.NgayHieuLuc = CacheData.Context.GetSystemDate();
            brscGrdData.Add(item);
            base.GetNewData();
            this.dtpNgayKy.Focus();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();
            NV_HopDong item = brscGrdData.Current as NV_HopDong;
            int a = -1;
            if (brscGrdData.Count > 0)
            {
                if (item != null && item.SoHopDong == 0 || CacheData.Context.GetSystemDate()<item.NgayKy)
                {
                    if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                    {
                        _bussHopDong.CapNhatLoaiHopDong(_IdNhanVien);
                        a = brscGrdData.IndexOf(item);
                        brscGrdData.RemoveCurrent();
                        _listError.Remove(a);
                        if (item.Id != 0)
                        {
                            _bussHopDong.DeleteData(item.Id);
                            UICommon.ShowSplashPanelUpdateMsg();
                            
                        }
                    }
                }
                else
                {
                    UICommon.ShowMsgWarning("MSG012");
                }
            }
            else
            {
                UICommon.ShowMsgInfo("MSG009");
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
                    List<NV_HopDong> list = (List<NV_HopDong>)brscGrdData.DataSource;
                    _bussHopDong.UpdateDataListThuViec(list);

                   
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
            GrdData.EndEdit();
            GrdData.RefreshData();
            GrdData.Refresh();
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        protected override void ExportExcel()
        {
            if (brscGrdData.Count > 0)
            {
                ExcelExport excel = new ExcelExport();
                excel.AutoExportToExcel(GrdData, "Hợp đồng", false);
            }
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
            _bussHopDong = new     NV_HopDongBLL();
            _listError = new List<int>();
            this.brscGrdData.PositionChanged += new EventHandler(brscGrdData_PositionChanged);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            // Get data
            this.brscGrdData.DataSource = _bussHopDong.GetHopDongByIdNhanVien(_IdNhanVien,1);
            this.GrdData.DataSource = brscGrdData;
            // Load data chucdanh
           
            this.AddDataBinding();
            if (!(brscGrdData.Count > 0))
            {
                Enable(false);
            }
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgayKy", "NgayBatDau", "NgayKetThuc");
        
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
           
            if (brscGrdData.Count > 0)
            {
                GrdData.Table.CurrentRecord = GrdData.Table.Records[0];
            }

            this.btnPrint.Visible = false;
            this.btnPrintTemplate.Visible = true;
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);
        }
 
        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            dtpNgayBatDau.Enabled = pvalue;
            dtpNgayKetThuc.Enabled = pvalue;
            dtpNgayKy.Enabled = pvalue;
           // dtpNgayHieuLuc.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            dtpNgayBatDau.DataBindings.Clear();
            dtpNgayKetThuc.DataBindings.Clear();
            dtpNgayKy.DataBindings.Clear();
            // Bingding
            dtpNgayBatDau.DataBindings.Add("Value", brscGrdData, "NgayBatDau", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayKetThuc.DataBindings.Add("Value", brscGrdData, "NgayKetThuc", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayKy.DataBindings.Add("Value", brscGrdData, "NgayKy", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<NV_HopDong> listData = (List<NV_HopDong>)brscGrdData.DataSource;

            foreach (NV_HopDong item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);
                if (!(item.NgayKy.HasValue))// 
                {
                    UICommon.ShowMsgInfo("MSG005", lblNgayKy.Text);
                    this.dtpNgayKy.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (!(item.NgayBatDau.HasValue))// 
                {
                    UICommon.ShowMsgInfo("MSG005", lblTuNgay.Text);
                    this.dtpNgayBatDau.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (!(item.NgayKetThuc.HasValue))// 
                {
                    UICommon.ShowMsgInfo("MSG005", lblDenNgay.Text);
                    this.dtpNgayKetThuc.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if ( item.NgayKy.Value < CacheData.Context.GetSystemDate().Date)
                {
                    UICommon.ShowMsgInfo("MSG020", lblNgayKy.Text, " ngày hiện tại");
                    this.dtpNgayKy.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (item.NgayKy.Value > item.NgayBatDau.Value)
                {
                    UICommon.ShowMsgInfo("MSG020", lblTuNgay.Text,lblNgayKy.Text);
                    this.dtpNgayBatDau.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                //if (item.NgayBatDau.Value < CacheData.Context.GetSystemDate())
                //{
                //    UICommon.ShowMsgInfo("MSG020", lblTuNgay.Text," ngày hiện tại");
                //    this.dtpNgayBatDau.Focus();
                //    brscGrdData.Position = a;
                //    _listError.Add(a);
                //    return false;
                //}
                if (item.NgayKetThuc.Value <= item.NgayBatDau.Value)
                {
                    UICommon.ShowMsgInfo("MSG020", lblDenNgay.Text, lblTuNgay.Text);
                    this.dtpNgayKetThuc.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
            }
            return true;
        } 

        #endregion

        #region ---- Events ----

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the SF205 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SF214_Load(object sender, EventArgs e)
        {
            this._IdNhanVien = this.IdNhanVien;
            InitForm();
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

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
        }

        #endregion

        #region ---- Bingdingsourcse ----

        /// <summary>
        /// Handles the PositionChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brscGrdData_PositionChanged(object sender, EventArgs e)
        {
            NV_HopDong hopdong = this.brscGrdData.Current as NV_HopDong;

            if (hopdong != null &&  hopdong.SoHopDong>0)
            {
                txtSoQuyetDinh.Text = hopdong.SoHopDong.ToString();
                if (hopdong.NgayKy < CacheData.Context.GetSystemDate())
                {
                    Enable(false);
                }
                else
                {
                    Enable(true);
                }
            }
            else
            {
                txtSoQuyetDinh.Text = UICommon.GetString("MSG024");
                Enable(true);
            }
           
        }

        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            NV_HopDong hopdong = this.brscGrdData.Current as NV_HopDong;


            if (hopdong != null && hopdong.SoHopDong > 0)
            {
                txtSoQuyetDinh.Text = hopdong.SoHopDong.ToString();
                if (hopdong.NgayKy < CacheData.Context.GetSystemDate())
                {
                    Enable(false);
                }
                else
                {
                    Enable(true);
                }
            }
            else
            {
                txtSoQuyetDinh.Text = UICommon.GetString("MSG024");
                Enable(true);
            }
           
        }

        #endregion

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>27/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            WordExport word = new WordExport();
            NV_HopDong hopDong = brscGrdData.CurrencyManager.Current as NV_HopDong;
            if (hopDong != null)
            {
                word.ExportHopDongThuViec(hopDong);
            }
        }

        #endregion

        #endregion
    }
}
