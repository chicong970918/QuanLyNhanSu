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
using HRM.DataAccess.Common;
using HRM.Entities;
using HRM.Class;
using Library.Class;
using Library;

namespace HRM.Forms.TuyenDung
{
    public partial class SF112 : GridBaseForm
    {
        #region ---- Variables ----

        private TD_ChiTietKeHoachThuViecBLL _bussChiTietThuViec = null;
        private TD_YeuCauCongViecBLL _busYeuCauCongViec = null;
        private TD_UngVienBLL _busUngVien = null;
        private TD_NhanVienBLL _busNhanVien = null;
        private TD_KeHoachThuViecBLL _bussKeHoach = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF112"/> class.
        /// </summary>
        public SF112()
        {
            InitializeComponent();
            InitForm();
        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            // Get data
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnSave.Visible = false;
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator2.Visible = false;
            _bussChiTietThuViec = new TD_ChiTietKeHoachThuViecBLL();
            _busYeuCauCongViec = new TD_YeuCauCongViecBLL();
            _busUngVien = new TD_UngVienBLL();
            _busNhanVien = new TD_NhanVienBLL();
            _bussKeHoach = new TD_KeHoachThuViecBLL();
            LoadComBoBox();
            // Add events 
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            this.cboPhieuYeuCau.SelectedIndexChanged += new EventHandler(cboPhieuYeuCau_SelectedIndexChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            this.brscGrdQuanLy.PositionChanged += new EventHandler(brscGrdQuanLy_PositionChanged);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            this.brscGrdQuanLy.CurrentItemChanged += new EventHandler(brscGrdQuanLy_CurrentItemChanged);
            // Loaddata for combo
            

            UICommon.GridFormatDate(grdData.TableDescriptor.Columns, true, "NgaySinh");

            LoadData();

            //this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);

            this.grdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(grdData_TableControlCellDoubleClick);

            this.btnExcelTemplate.Visible = true;
            this.btnPrintTemplate.Visible = true;
            this.btnExcel.Visible = false;
            this.btnPrint.Visible = false;

            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);

            //this.GrdData.DataSource = brscGrdData;
        }

        /// <summary>
        /// Loadcomboes the PYC.
        /// </summary>
        ///  26/07/11
        /// PC
        private void LoadcomboPYC()
        {
            cboPhieuYeuCau.DataSource = _bussKeHoach.GetPhieuYCByPhongBanQuyNam(((DM_PhongBan)cboPhongBan.SelectedItem).Id, ((DM_Quy)cboQuy.SelectedItem).Id, int.Parse(txtNam.Text));
            cboPhieuYeuCau.DisplayMember = "MaPhieuYeuCau";
            cboPhieuYeuCau.ValueMember = "Id";
        }

        /// <summary>
        /// Loads the COM bo box.
        /// </summary>
        private void LoadComBoBox()
        {

            // GetData
            this.cboPhongBan.DisplayMember = "TenPhongBan";
            this.cboPhongBan.ValueMember = "Id";
            this.cboPhongBan.DataSource = _bussChiTietThuViec.GetPhongBan();

            // GetData
            this.cboQuy.DisplayMember = "Ten";
            this.cboQuy.ValueMember = "Id";
            this.cboQuy.DataSource = CacheData.GetDanhMucQuy();

            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();

        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            List<TD_KeHoachThuViec> list = new List<TD_KeHoachThuViec>();
            try
            {
                  list = _bussChiTietThuViec.GetQuanLy(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(this.cboQuy.Text), CommonUtil.IsInt(txtNam.Text), ((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id);

            }
            catch
            {
                
            }
            brscGrdQuanLy.DataSource = list;
            grdQuanLy.DataSource = brscGrdQuanLy;
            //this.brscGrdData.DataSource = list;
            if (brscGrdQuanLy.Count > 0)
            {
                grdQuanLy.Table.CurrentRecord = grdQuanLy.Table.Records[0];
            }
            //brscGrdData.MoveLast();
            // phan quyen nhansu phongban
            //  PhanQuyen();
        }

        #endregion

        #region ---- Events ----

        #region ---- combo ----


        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            //LoadData();
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
           // LoadData();
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
        }


        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhieuYeuCau control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  26/07/11
        /// PC
        void cboPhieuYeuCau_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }


        #endregion

        #region ---- text ----

        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            //LoadData();
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
        }

        #endregion

        #region ---- bindingsource ----

        /// <summary>
        /// Handles the PositionChanged event of the brscGrdQuanLy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdQuanLy_PositionChanged(object sender, EventArgs e)
        {
            TD_KeHoachThuViec item = brscGrdQuanLy.Current as TD_KeHoachThuViec;
            if (item != null)
            {
                List<TD_UngVien> list = _bussChiTietThuViec.GetUngVien(item.Id);
                brscGrdData.DataSource = list;
                grdData.DataSource = brscGrdData;
                if (brscGrdData.Count > 0)
                {
                    grdData.Table.CurrentRecord = grdData.Table.Records[0];
                }
            }
            else
            {
                List<TD_UngVien> list = new List<TD_UngVien>();
                brscGrdData.DataSource = list;
                grdData.DataSource = brscGrdData;
                if (brscGrdData.Count > 0)
                {
                    grdData.Table.CurrentRecord = grdData.Table.Records[0];
                }
            }
        }


        void brscGrdQuanLy_CurrentItemChanged(object sender, EventArgs e)
        {
            TD_KeHoachThuViec item = brscGrdQuanLy.Current as TD_KeHoachThuViec;
            if (item != null)
            {
                List<TD_UngVien> list = _bussChiTietThuViec.GetUngVien(item.Id);
                brscGrdData.DataSource = list;
                grdData.DataSource = brscGrdData;
                if (brscGrdData.Count > 0)
                {
                    grdData.Table.CurrentRecord = grdData.Table.Records[0];
                }
            }
            else
            {
                List<TD_UngVien> list = new List<TD_UngVien>();
                brscGrdData.DataSource = list;
                grdData.DataSource = brscGrdData;
                if (brscGrdData.Count > 0)
                {
                    grdData.Table.CurrentRecord = grdData.Table.Records[0];
                }
            }
        }


        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        #endregion

        #region ---- Grid ----
        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the grdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void grdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            TD_UngVien item = this.brscGrdData.Current as TD_UngVien;
            if (item != null)
            {
                TD_KeHoachThuViec kehoach = brscGrdQuanLy.Current as TD_KeHoachThuViec;
                if (kehoach != null)
                {
                    SF114 frm = new SF114();
                    frm.MaKeHoach = item.MaKeHoach;
                    frm.IdChiTietKeHochThuViec = _bussChiTietThuViec.GetIdChiTiet(((TD_KeHoachThuViec)kehoach).Id, item.Id);
                    frm.NgayBatDau = kehoach.ThuViecTuNgay;
                    frm.PhongBan = ((DM_PhongBan)cboPhongBan.SelectedItem).IsPhongNhanSu;
                    frm.NgayKetThuc = kehoach.ThuViecDenNgay;
                    frm.ShowDialog();
                }

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
        /// <Date>23/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                TD_UngVien ungVien = brscGrdData.CurrencyManager.Current as TD_UngVien;

                if (ungVien != null)
                {
                    ExcelExport excel = new ExcelExport();
                    List<TD_YeuCauCongViec> listYeuCau = new List<TD_YeuCauCongViec>();
                    TD_KeHoachThuViec keHoachThuViec = new TD_KeHoachThuViec();
                    Dictionary<string, string> dicThongTin = new Dictionary<string, string>();
                    string path = string.Empty;
                    keHoachThuViec = brscGrdQuanLy.CurrencyManager.Current as TD_KeHoachThuViec;

                    int idChiTietKh = _bussChiTietThuViec.GetIdChiTiet(((TD_KeHoachThuViec)keHoachThuViec).Id, ungVien.Id);
                    listYeuCau = _busYeuCauCongViec.GetYeuCauByChiTiet(idChiTietKh);

                    string TenPhongBan = CacheData.GetTenPhongBan(keHoachThuViec.IdPhongBan);
                    NV_NhanVien nhanVien = _busNhanVien.GetNhanVienByIdNhanVien(keHoachThuViec.IdNhanVien);
                    string QuanLyCV = CacheData.GetTenChucDanh(nhanVien.IdChucDanh);
                    string dateFormat = "dd/MM/yyyy";

                    dicThongTin.Add("Quy", keHoachThuViec.Quy.ToString());
                    dicThongTin.Add("Nam", keHoachThuViec.Nam.ToString());
                    dicThongTin.Add("PhongBan", TenPhongBan);
                    dicThongTin.Add("HoTen", ungVien.HoDem + " " + ungVien.Ten);
                    dicThongTin.Add("ChucVu", ungVien.ChucDanhText);
                    dicThongTin.Add("NgayThuViec", keHoachThuViec.ThuViecTuNgay.Value.ToString(dateFormat));
                    dicThongTin.Add("ThuViecDenNgay", keHoachThuViec.ThuViecDenNgay.Value.ToString(dateFormat));
                    dicThongTin.Add("NguoiQuanLy", keHoachThuViec.HoDem + " " + keHoachThuViec.Ten);
                    dicThongTin.Add("QuanLyCV", QuanLyCV);

                    if (listYeuCau.Count > 0 && keHoachThuViec != null)
                    {
                        excel.ExportKeHoachThuViec(listYeuCau, dicThongTin, ref path, false);
                        if (!string.IsNullOrEmpty(path))
                        {
                            Print(path);
                        }
                    }

                }

            }
        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>23/06/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                TD_UngVien ungVien = brscGrdData.CurrencyManager.Current as TD_UngVien;

                if (ungVien != null)
                {
                    ExcelExport excel = new ExcelExport();
                    List<TD_YeuCauCongViec> listYeuCau = new List<TD_YeuCauCongViec>();
                    TD_KeHoachThuViec keHoachThuViec = new TD_KeHoachThuViec();
                    Dictionary<string, string> dicThongTin = new Dictionary<string, string>();
                    string path = string.Empty;
                    keHoachThuViec = brscGrdQuanLy.CurrencyManager.Current as TD_KeHoachThuViec;

                    int idChiTietKh = _bussChiTietThuViec.GetIdChiTiet(((TD_KeHoachThuViec)keHoachThuViec).Id, ungVien.Id);
                    listYeuCau = _busYeuCauCongViec.GetYeuCauByChiTiet(idChiTietKh);

                    string TenPhongBan = CacheData.GetTenPhongBan(keHoachThuViec.IdPhongBan);
                    NV_NhanVien nhanVien = _busNhanVien.GetNhanVienByIdNhanVien(keHoachThuViec.IdNhanVien);
                    string QuanLyCV = CacheData.GetTenChucDanh(nhanVien.IdChucDanh);
                    string dateFormat = "dd/MM/yyyy";

                    dicThongTin.Add("Quy", keHoachThuViec.Quy.ToString());
                    dicThongTin.Add("Nam", keHoachThuViec.Nam.ToString());
                    dicThongTin.Add("PhongBan", TenPhongBan);
                    dicThongTin.Add("HoTen", ungVien.HoDem + " " + ungVien.Ten);
                    dicThongTin.Add("ChucVu", ungVien.ChucDanhText);
                    dicThongTin.Add("NgayThuViec", keHoachThuViec.ThuViecTuNgay.Value.ToString(dateFormat));
                    dicThongTin.Add("ThuViecDenNgay", keHoachThuViec.ThuViecDenNgay.Value.ToString(dateFormat));
                    dicThongTin.Add("NguoiQuanLy", keHoachThuViec.HoDem + " " + keHoachThuViec.Ten);
                    dicThongTin.Add("QuanLyCV", QuanLyCV);

                    if (listYeuCau.Count > 0 && keHoachThuViec != null)
                    {
                        excel.ExportKeHoachThuViec(listYeuCau, dicThongTin, ref path, false);
                        if (!string.IsNullOrEmpty(path))
                        {
                            excel.OpenFile(path);
                        }
                    }

                }

            }
        }

        #endregion

        #endregion

    }
}
