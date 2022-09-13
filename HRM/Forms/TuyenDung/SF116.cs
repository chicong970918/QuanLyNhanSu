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
    public partial class SF116 : GridBaseForm
    {
        #region ---- Variables ----

        private TD_ChiTietKeHoachThuViecBLL _bussChiTietThuViec = null;
        private TD_UngVienBLL _bussUngVien = null;
        private TD_KeHoachThuViecBLL _bussKeHoach = null;
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF112"/> class.
        /// </summary>
        public SF116()
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
            this.btnSearch.Visible = true;
            this.toolStripSeparator1.Visible = false;
            this.btnSave.Visible = false;
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator2.Visible = false;
            _bussChiTietThuViec = new TD_ChiTietKeHoachThuViecBLL();
            _bussKeHoach = new TD_KeHoachThuViecBLL();
            this.btnSearch.Text = "Đánh giá";
            _bussUngVien = new TD_UngVienBLL();
            LoadComBoBox();
            // Add events 
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            this.cboPhieuYeuCau.SelectedIndexChanged += new EventHandler(cboChucDanh_SelectedIndexChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            this.brscGrdQuanLy.PositionChanged += new EventHandler(brscGrdQuanLy_PositionChanged);
            this.brscGrdQuanLy.CurrentItemChanged += new EventHandler(brscGrdQuanLy_CurrentItemChanged);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            // Loaddata for combo
            
         
            UICommon.GridFormatDate(grdData.TableDescriptor.Columns, true, "NgaySinh");
            
            LoadData();
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            //this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);

            this.grdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(grdData_TableControlCellDoubleClick);

            //this.LoadData();

            //this.GrdData.DataSource = brscGrdData;
        }
 
        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                foreach (TD_UngVien uv in (List<TD_UngVien>)brscGrdData.DataSource)
                {
                    TD_KeHoachThuViec kehoach = brscGrdQuanLy.Current as TD_KeHoachThuViec;

                    if (kehoach != null)
                    {
                        _bussChiTietThuViec.CallTinhTB(kehoach.Id, uv.Id, ((DM_PhongBan)this.cboPhongBan.SelectedItem).Id,
                            ((DM_Quy)this.cboQuy.SelectedItem).Ten, CommonUtil.IsInt(txtNam.Text), uv.IdChucDanh.Value);
                    }

                }
                TD_KeHoachThuViec kehoach1 = brscGrdQuanLy.Current as TD_KeHoachThuViec;

                if (kehoach1 != null)
                {
                    _bussChiTietThuViec.DanhGiaKetQua(kehoach1.Id, ((DM_PhongBan)this.cboPhongBan.SelectedItem).Id,
                                ((DM_Quy)this.cboQuy.SelectedItem).Ten, CommonUtil.IsInt(txtNam.Text), ((TD_PhieuYeuCauTuyenDung)this.cboPhieuYeuCau.SelectedItem).Id);
                }
                LoadData();
                LoadUngVien();
            }
            else
            {
                UICommon.ShowMsgInfo("MSG009");
            }
        }

        /// <summary>
        /// Loads the ung vien.
        /// </summary>
        private void LoadUngVien()
        {
            TD_KeHoachThuViec item = brscGrdQuanLy.Current as TD_KeHoachThuViec;
            if (item != null)
            {
                try
                {
                    List<TD_UngVien> list = _bussChiTietThuViec.GetUngVienDanhGiaKetQua(item.Id, ((TD_PhieuYeuCauTuyenDung)cboPhieuYeuCau.SelectedItem).Id);
                    brscGrdData.DataSource = list;

                }
                catch
                {

                }
                grdData.DataSource = brscGrdData;
                if (brscGrdData.Count > 0)
                {
                    grdData.Table.CurrentRecord = grdData.Table.Records[0];
                }
            }
        }

         /// <summary>
        /// Loads the COM bo box.
        /// </summary>
        private void LoadComBoBox()
        {
            // GetData
            this.cboPhongBan.DisplayMember = "TenPhongBan";
            this.cboPhongBan.ValueMember = "Id";
            this.cboPhongBan.DataSource  = _bussChiTietThuViec.GetPhongBan();

            // GetData
            this.cboQuy.DisplayMember = "Ten";
            this.cboQuy.ValueMember = "Id";
            this.cboQuy.DataSource = CacheData.GetDanhMucQuy();

            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();
            LoadcomboPYC();
             
        }

        //private void LoadChuDanh()
        //{
        //    try
        //    {
        //        this.cboPhieuYeuCau.DisplayMember = "TenChucDanh";
        //        this.cboPhieuYeuCau.ValueMember = "Id";
        //        this.cboPhieuYeuCau.DataSource = _bussUngVien.GetChucDanhTheoPYC(((DM_PhongBan)cboPhongBan.SelectedItem).Id, ((DM_Quy)cboQuy.SelectedItem).Ten, CommonUtil.IsInt(txtNam.Text));
        //    }
        //    catch
        //    {

        //    }
        //}

        /// <summary>
        /// Loadcomboes the PYC.
        /// </summary>
        ///  26/07/11
        /// PC
        private void LoadcomboPYC()
        {
            cboPhieuYeuCau.DataSource = _bussKeHoach.GetPhieuYCByPhongBanQuyNam(((DM_PhongBan)cboPhongBan.SelectedItem).Id, ((DM_Quy)cboQuy.SelectedItem).Id, CommonUtil.IsInt(txtNam.Text));
            cboPhieuYeuCau.DisplayMember = "MaPhieuYeuCau";
            cboPhieuYeuCau.ValueMember = "Id";
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
          //  brscGrdQuanLy.DataSource = new List<TD_UngVien>();
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
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
            LoadData();
            LoadUngVien();
           
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
            LoadData();
            LoadUngVien();
          
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboChucDanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void cboChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
           // LoadChuDanh();
            LoadUngVien();
        }

        #endregion

        #region ---- text ----

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadcomboPYC();
            }
            catch
            {

            }
            LoadData();
            
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
            TD_KeHoachThuViec item =brscGrdQuanLy.Current as TD_KeHoachThuViec;
            if(item!=null)
            {
                try
                {
                    List<TD_UngVien> list = _bussChiTietThuViec.GetUngVienDanhGiaKetQua(item.Id, ((DM_ChucDanh)cboPhieuYeuCau.SelectedItem).Id);
                    brscGrdData.DataSource = list;

                }
                catch
                {

                }    
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
        /// Handles the CurrentItemChanged event of the brscGrdQuanLy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brscGrdQuanLy_CurrentItemChanged(object sender, EventArgs e)
        {
            TD_KeHoachThuViec item = brscGrdQuanLy.Current as TD_KeHoachThuViec;
            if (item != null)
            {
                try
                {
                    List<TD_UngVien> list = _bussChiTietThuViec.GetUngVienDanhGiaKetQua(item.Id, ((DM_ChucDanh)cboPhieuYeuCau.SelectedItem).Id);
                    brscGrdData.DataSource = list;

                }
                catch
                {

                }
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

        #region ---- Grd ----

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the grdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void grdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            //TD_UngVien item = this.brscGrdData.Current as TD_UngVien;
            //if (item != null)
            //{
            //    TD_KeHoachThuViec kehoach = brscGrdQuanLy.Current as TD_KeHoachThuViec;
            //    if (kehoach != null)
            //    {
            //        SF117 frm = new SF117();
            //        frm.MaKeHoach = item.MaKeHoach;
            //        frm.IdChiTietKeHochThuViec = _bussChiTietThuViec.GetIdChiTiet(((TD_KeHoachThuViec)kehoach).Id,item.Id);
            //        frm.NgayBatDau = kehoach.ThuViecTuNgay;
            //        frm.PhongBan = ((DM_PhongBan)cboPhongBan.SelectedItem).IsPhongNhanSu;
            //        frm.NgayKetThuc = kehoach.ThuViecDenNgay;
            //        frm.FlagDanhGia = false;
            //        frm.DanhGia = item.DanhGia;
            //        frm.ShowDialog();
            //    }

            //}
        }

        #endregion

        #endregion

        private void txtNam_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
