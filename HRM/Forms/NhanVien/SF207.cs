﻿using System ;
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
    public partial class SF207 : TuyenDungBaseForm
    {
        #region ---- Variables ----

        private int _IdNhanVien = -1;
        private NV_QuyetDinhNangHeSoLuongBLL _bussHeSoLuong = null;
        private NV_NhanVienBLL _busNhanVien = null;
        private List<int> _listError = null;
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF205"/> class.
        /// </summary>
        public SF207()
        {
            InitializeComponent();
            this.Load += new EventHandler(SF207_Load);
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
            Enable(true);
            // Add data in bindingsourec 
            this.txtTenQuyetDinh.Focus();
            NV_QuyetDinhNangHeSoLuong item = new NV_QuyetDinhNangHeSoLuong();
            item.IdNhanVien = _IdNhanVien;
            item.NgayHieuLuc = CacheData.Context.GetSystemDate();
            brscGrdData.Add(item);
            base.GetNewData();
            this.txtTenQuyetDinh.Focus();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            NV_QuyetDinhNangHeSoLuong item = brscGrdData.Current as NV_QuyetDinhNangHeSoLuong;
            if (brscGrdData.Count > 0)
            {
                if (item != null && item.SoQuyetDinh == 0)
                {
                    if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                    {
                        brscGrdData.RemoveCurrent();
                        if (item.Id != 0)
                        {
                            _bussHeSoLuong.DeleteData(item.Id);
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
                    List<NV_QuyetDinhNangHeSoLuong> list = (List<NV_QuyetDinhNangHeSoLuong>)brscGrdData.DataSource;
                    _bussHeSoLuong.UpdateDataList(list);
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
                excel.AutoExportToExcel(GrdData, "Quá trình nâng hệ số lương NV", false);
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
            _bussHeSoLuong = new NV_QuyetDinhNangHeSoLuongBLL();
            _busNhanVien = new NV_NhanVienBLL();
            _listError = new List<int>();
            this.brscGrdData.PositionChanged += new EventHandler(brscGrdData_PositionChanged);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            // Get data
            this.brscGrdData.DataSource = _bussHeSoLuong.GetKyLuatByIdNhanVien(_IdNhanVien);
            this.GrdData.DataSource = brscGrdData;

            this.AddDataBinding();

            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgayQuyetDinh", "NgayHieuLuc");

            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            Enable(false);
            if (brscGrdData.Count > 0)
            {
                GrdData.Table.CurrentRecord = GrdData.Table.Records[0];
            }
            this.dtpNgayHieuLuc.Enabled = false;
            this.btnPrint.Visible = false;
            this.btnPrintTemplate.Visible = true;
            this.btnPrintTemplate.Text = "In quyết định";

            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);

        }



        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtNoiDung.Enabled = pvalue;
            txtTenQuyetDinh.Enabled = pvalue;
            txtHeSo.Enabled = pvalue;
            dtpNgauQuyetDinh.Enabled = pvalue;
            // dtpNgayHieuLuc.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtNoiDung.DataBindings.Clear();
            txtTenQuyetDinh.DataBindings.Clear();
            txtHeSo.DataBindings.Clear();
            dtpNgauQuyetDinh.DataBindings.Clear();
            dtpNgayHieuLuc.DataBindings.Clear();
            // Bingding
            dtpNgauQuyetDinh.DataBindings.Add("Value", brscGrdData, "NgayQuyetDinh", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayHieuLuc.DataBindings.Add("Value", brscGrdData, "NgayHieuLuc", true, DataSourceUpdateMode.OnPropertyChanged);
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNoiDung.DataBindings.Add("Text", brscGrdData, "NoiDung", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenQuyetDinh.DataBindings.Add("Text", brscGrdData, "TenQuyetDinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHeSo.DataBindings.Add("Text", brscGrdData, "HeSoLuong", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<NV_QuyetDinhNangHeSoLuong> listData = (List<NV_QuyetDinhNangHeSoLuong>)brscGrdData.DataSource;

            foreach (NV_QuyetDinhNangHeSoLuong item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.TenQuyetDinh))// 
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenQuyetDinh.Text);
                    this.txtTenQuyetDinh.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (!(item.NgayHieuLuc.HasValue))// 
                {
                    UICommon.ShowMsgInfo("MSG005", lblNgayHieuLuc.Text);
                    this.dtpNgayHieuLuc.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                //if (item.NgayHieuLuc.HasValue && item.NgayHieuLuc.Value < CacheData.Context.GetSystemDate())
                //{
                //    UICommon.ShowMsgInfo("MSG017", lblNgayHieuLuc.Text, "ngày hiện tại");
                //    this.dtpNgayHieuLuc.Focus();
                //    brscGrdData.Position = a;
                //    _listError.Add(a);
                //    return false;
                //}
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
        void SF207_Load(object sender, EventArgs e)
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
            //NV_QuyetDinhKhenThuong khenthuong = this.brscGrdData.Current as NV_QuyetDinhKhenThuong;

            //if (khenthuong != null && !string.IsNullOrEmpty(khenthuong.SoQuyetDinh))
            //{
            //    txtSoQuyetDinh.Text = khenthuong.SoQuyetDinh;

            //    Enable(false);
            //}
            //else
            //{
            //    txtSoQuyetDinh.Text = UICommon.GetString("MSG024");
            //    Enable(true);
            //}
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
            NV_QuyetDinhNangHeSoLuong hesoluong = this.brscGrdData.Current as NV_QuyetDinhNangHeSoLuong;

            if (hesoluong != null &&  hesoluong.SoQuyetDinh>0)
            {
                txtSoQuyetDinh.Text = hesoluong.SoQuyetDinh.ToString();

                Enable(false);
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
            NV_QuyetDinhNangHeSoLuong hesoluong = this.brscGrdData.Current as NV_QuyetDinhNangHeSoLuong;
            if (hesoluong != null && hesoluong.SoQuyetDinh > 0)
            {
                txtSoQuyetDinh.Text = hesoluong.SoQuyetDinh.ToString();

                Enable(false);
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
            NV_QuyetDinhNangHeSoLuong heSo = this.brscGrdData.Current as NV_QuyetDinhNangHeSoLuong;
            if (heSo != null)
            {
                NV_NhanVien nhanVien = _busNhanVien.GetNhanVienbyId(heSo.IdNhanVien);
                if (nhanVien != null)
                {
                    word.QuyetDinhNangHeSoLuong(nhanVien, heSo);
                }
            }

        }

        #endregion

        #endregion
    }
}
