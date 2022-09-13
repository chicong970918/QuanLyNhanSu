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
using System.IO;
using HRM.DataAccess.QuanLyNhanVien;

namespace HRM.Forms.NhanVien
{
    public partial class SF212 : GridBaseForm
    {
        #region ---- Variables ----

        private NV_NhanVienBLL _bussNhanVien = null;
        private TD_QuaTrinhCongTacBLL _bussQuaTrinh = null;
        private TD_QuanHeGiaDinhBLL _bussQuanHe = null;
        private int _IdNhanVien = -1;
        private NV_NhanVien _current = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF212"/> class.
        /// </summary>
        public SF212()
        {
            InitializeComponent();
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.btnPrint.Visible = false;
            this.btnExcel.Visible = false;
            this.btnAdd.Visible = false;
            this.btnAdd.Text = "Lưu và thêm";
            this.btnSave.Text = "Lưu và đóng";
            _bussNhanVien = new NV_NhanVienBLL();
            _current = new NV_NhanVien();
            _bussQuanHe = new TD_QuanHeGiaDinhBLL();
            _bussQuaTrinh = new TD_QuaTrinhCongTacBLL();
            this.Load += new EventHandler(SF212_Load);
            this.brsQuatrinhcongtac.PositionChanged += new EventHandler(brsQuatrinhcongtac_PositionChanged);
            this.brscQuanHe.PositionChanged += new EventHandler(brscQuanHe_PositionChanged);
            this.GrdataQuaTrinhCongTac.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdataQuaTrinhCongTac_TableControlCellClick);
            this.hrmGrigouping1.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(hrmGrigouping1_TableControlCellClick);
            // QuaTrinhCongTac
            this.btnLuu.Click += new EventHandler(btnLuu_Click);
            this.btnThemQuanHe.Click += new EventHandler(btnThemQuanHe_Click);
            this.btnXoa.Click += new EventHandler(btnXoa_Click);
            this.btnXoaQuanHe.Click += new EventHandler(btnXoaQuanHe_Click);
            this.btnThem.Click += new EventHandler(btnThem_Click);
            this.btnLuuQuanHe.Click += new EventHandler(btnLuuQuanHe_Click);

            UICommon.GridFormatDate(GrdataQuaTrinhCongTac.TableDescriptor.Columns, true, "TuNgay", "DenNgay");
            UICommon.GridFormatDate(hrmGrigouping1.TableDescriptor.Columns, true, "NgaySinh");
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
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            GetOject();
            base.SaveData();
            brscGrdData.EndEdit();
            if (ValidatorQuaTrinh())
            {
                if (ValidatorQuanHe())
                {
                    if (Validator())
                    {
                        UICommon.StartUpdate();
                        _bussNhanVien.UpdateData(_current);
                        _bussQuaTrinh.UpdateDataList((List<NV_QuaTrinhCongTac>)brsQuatrinhcongtac.DataSource);
                        _bussQuanHe.UpdateDataList((List<NV_QuanHeGiaDinh>)brscQuanHe.DataSource);
                        UICommon.StopUpdate();
                        UICommon.ShowSplashPanelUpdateMsg();
                        this.Close();
                    }
                }
            }
        } 

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Sets the oject.
        /// </summary>
        private void SetOject()
        {
            txtMaNhanVien.Text = _current.MaNhanVien;
            txtCMND.Text = _current.CMND;

            txtDiaChiHienTai.Text = _current.DiaChiHienTai;
            txtThuongTru.Text = _current.DiaChiThuongTru;
            txtNguyenQuan.Text = _current.NguyenQuan;

            txtEmail.Text = _current.Email;
            txtHoDem.Text = _current.HoDem;
            txtLuongSauThuViec.Text = _current.LuongSauThuViec.HasValue ? _current.LuongSauThuViec.Value.ToString() : string.Empty;
            txtLuongThuViec.Text = _current.LuongSauThuViec.HasValue ? _current.LuongSauThuViec.Value.ToString() : string.Empty;
            txtNoiCap.Text = _current.NoiCapCMND;
            txtQuocTich.Text = _current.QuocTich;
            txtSDT.Text = _current.SoDienThoai;
            txtTen.Text = _current.Ten;

            cboChucDanh.SelectedValue = _current.IdChucDanh;
            cboDanToc.SelectedValue = _current.IdDanToc.HasValue ? _current.IdDanToc.Value : -1;
            cboHonNhan.SelectedValue = _current.IdTinhTrangHonNhan.HasValue ? _current.IdTinhTrangHonNhan.Value : -1;
            cboNoiSinh.SelectedValue = _current.NoiSinh.HasValue ? _current.NoiSinh.Value : -1;
            cboTonGiao.SelectedValue = _current.IdTonGiao.HasValue ? _current.IdTonGiao.Value : -1;
            cboTrinhDo.SelectedValue = _current.IdTrinhDo;
            cboChuyenNganh.SelectedValue = _current.IdChuyenNganh;
            rdbNam.Checked = _current.GioiTinh.HasValue ? _current.GioiTinh.Value : false;
            rdbNu.Checked = !rdbNam.Checked;

            dtpNgaySinh.Value = _current.NgaySinh;
            dtpNgayNhanViec.Value = _current.NgayNhanViec;

            if (this._current.HinhAnh != null)
            {
                MemoryStream ms = new MemoryStream(this._current.HinhAnh.ToArray());
                picHinhAnh.Image = Image.FromStream(ms);
            }
            else
            {
                picHinhAnh.Image = null;
            }

        }

        /// <summary>
        /// Gets the oject.
        /// </summary>
        private void GetOject()
        {
            _current.CMND = txtCMND.Text;
            _current.DiaChiHienTai = txtDiaChiHienTai.Text;
            _current.DiaChiThuongTru = txtThuongTru.Text;
            _current.NguyenQuan = txtNguyenQuan.Text;
            _current.Email = txtEmail.Text;
            _current.HoDem = txtHoDem.Text;
            if (txtLuongSauThuViec.Text != string.Empty)
            {
                _current.LuongSauThuViec = txtLuongSauThuViec.Text == string.Empty ? 0 : CommonUtil.Parsedecimal(txtLuongSauThuViec.Text);
            }

            _current.NoiCapCMND = txtNoiCap.Text;
            _current.QuocTich = txtQuocTich.Text;

            if (txtSDT.Text != string.Empty)
            {
                _current.SoDienThoai = txtSDT.Text;
            }
            _current.Ten = txtTen.Text;

            _current.IdChucDanh = cboChucDanh.SelectedValue == null ? -1 : (int)cboChucDanh.SelectedValue;
            _current.IdDanToc = cboDanToc.SelectedValue == null ? -1 : (int)cboDanToc.SelectedValue;
            _current.IdTinhTrangHonNhan = cboHonNhan.SelectedValue == null ? -1 : (int)cboHonNhan.SelectedValue;
            _current.NoiSinh = cboNoiSinh.SelectedValue == null ? -1 : (int)cboNoiSinh.SelectedValue;
            _current.IdTonGiao = cboTonGiao.SelectedValue == null ? -1 : (int)cboTonGiao.SelectedValue;
            _current.IdTrinhDo = cboTrinhDo.SelectedValue == null ? -1 : (int)cboTrinhDo.SelectedValue;
            _current.GioiTinh = rdbNam.Checked;
            _current.IdChuyenNganh=cboChuyenNganh.SelectedValue==null ? -1: (int)cboChuyenNganh.SelectedValue;
            _current.NgaySinh = dtpNgaySinh.Value;
            _current.NgayNhanViec = dtpNgayNhanViec.Value;

            if (picHinhAnh.Image == null)
            {
                this._current.HinhAnh = null;
            }
            else
            {
                MemoryStream ms = new MemoryStream();
                picHinhAnh.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                this._current.HinhAnh = ms.ToArray();
            }

        }

        /// <summary>
        /// Clearses the oject.
        /// </summary>
        private void ClearsOject()
        {
            txtCMND.Text = string.Empty;
            txtDiaChiHienTai.Text = string.Empty;
            txtThuongTru.Text = string.Empty;
            txtNguyenQuan.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtHoDem.Text = string.Empty;
            txtLuongSauThuViec.Text = string.Empty;
            txtLuongThuViec.Text = string.Empty;
            txtNoiCap.Text = string.Empty;
            txtQuocTich.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtTen.Text = string.Empty;

            cboChucDanh.SelectedValue = -1;

            cboDanToc.SelectedValue = -1;

            cboHonNhan.SelectedValue = -1;

            cboNoiSinh.SelectedValue = -1;

            cboTonGiao.SelectedValue = -1;

            cboTrinhDo.SelectedValue = -1;

            rdbNam.Checked = true;
            rdbNu.Checked = false;

            dtpNgaySinh.Value = null;
            dtpNgayNhanViec.Value = null;

            picHinhAnh.Image = null;

        }

        /// <summary>
        /// Loads the COM bo box.
        /// </summary>
        private void LoadComBoBox()
        {

            // GetData
            this.cboChucDanh.DisplayMember = "TenChucDanh";
            this.cboChucDanh.ValueMember = "Id";
            this.cboChucDanh.DataSource = CacheData.GetDanhMucChucDanh();

            this.cboHonNhan.DisplayMember = "TenTinhTrang";
            this.cboHonNhan.ValueMember = "Id";
            this.cboHonNhan.DataSource = CacheData.GetDanhMucTinhTrangHonNhan();

            this.cboNoiSinh.DisplayMember = "TenTinh";
            this.cboNoiSinh.ValueMember = "Id";
            this.cboNoiSinh.DataSource = CacheData.GetDanhMucTinh();

            this.cboTonGiao.DisplayMember = "TenTonGiao";
            this.cboTonGiao.ValueMember = "Id";
            this.cboTonGiao.DataSource = CacheData.GetDanhMucTonGiao();

            this.cboDanToc.DisplayMember = "TenDanToc";
            this.cboDanToc.ValueMember = "Id";
            this.cboDanToc.DataSource = CacheData.GetDanhMucDanToc();

            this.cboTrinhDo.DisplayMember = "TenTrinhDo";
            this.cboTrinhDo.ValueMember = "Id";
            this.cboTrinhDo.DataSource = CacheData.GetDanhMucTrinhDo();

            this.cboChuyenNganh.DisplayMember = "TenChuyenNganh";
            this.cboChuyenNganh.ValueMember = "Id";
            this.cboChuyenNganh.DataSource = CacheData.GetDanhMucChuyenNganh();

            this.cboTrinhDo.SelectedIndex = -1;
            this.cboChucDanh.SelectedIndex = -1;
            this.cboHonNhan.SelectedIndex = -1;
            this.cboTonGiao.SelectedIndex = -1;
            this.cboTonGiao.SelectedIndex = -1;
            this.cboDanToc.SelectedIndex = -1;
            this.cboNoiSinh.SelectedIndex = -1;
            this.cboChuyenNganh.SelectedIndex = -1;
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            if (string.IsNullOrEmpty(_current.HoDem))// HoDem nott null
            {
                UICommon.ShowMsgInfo("MSG005", lblHoDem.Text);
                this.txtHoDem.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(_current.Ten)) //Ten not null
            {
                UICommon.ShowMsgInfo("MSG005", lblTen.Text);
                this.txtTen.Focus();
                return false;
            }
            if (cboChucDanh.SelectedIndex < 0) //Ten not null
            {
                UICommon.ShowMsgInfo("MSG005", lblChucDanh.Text);
                this.cboChucDanh.Focus();
                return false;
            }
            if (cboTrinhDo.SelectedIndex < 0) //Ten not null
            {
                UICommon.ShowMsgInfo("MSG005", lblTrinhDo.Text);
                this.cboTrinhDo.Focus();
                return false;
            }
            if (cboChuyenNganh.SelectedIndex < 0) //Ten not null
            {
                UICommon.ShowMsgInfo("MSG005", lblChuyenNganh.Text);
                this.cboChuyenNganh.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Clears the qua trinh cong tac.
        /// </summary>
        private void ClearQuaTrinhCongTac()
        {
            dtpTuNgay.Value = null;
            dtpDenNgay.Value = null;
            txtPhongBan.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtDonVi.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
        }

        /// <summary>
        /// Clears the qua trinh cong tac.
        /// </summary>
        private void ClearQuanHe()
        {
            txtHoTen.Text=string.Empty;
            txtNgaySinh.Value=null;
            txtNghwNghiep.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            txtQuanHe.Text = string.Empty;
            txtGhiChuQuanHe.Text = string.Empty;
        }

        /// <summary>
        /// Enables the controls.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void EnableControlsQuaTrinhCongTac(bool pvalue)
        {
            dtpTuNgay.Enabled = pvalue;
            dtpDenNgay.Enabled = pvalue;
            txtPhongBan.Enabled = pvalue;
            txtChucVu.Enabled = pvalue;
            txtDonVi.Enabled = pvalue;
            txtGhiChu.Enabled = pvalue;
        }

        /// <summary>
        /// Enables the controls.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void EnableControlsQuanHe(bool pvalue)
        {
            txtHoTen.Enabled =pvalue;
            txtNgaySinh.Enabled = pvalue;
            txtNghwNghiep.Enabled = pvalue;
            txtDiaChi.Enabled = pvalue;
            txtQuanHe.Enabled = pvalue;
            txtGhiChuQuanHe.Enabled = pvalue;
        }

        #endregion

        #region ---- Events ----

        #region ---- button ----

        /// <summary>
        /// Handles the Click event of the btnAddPicture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            ofdHinhAnh.Filter = "JPEGs|*.jpg|GIFs|*.gif";

            if (ofdHinhAnh.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = new Bitmap(ofdHinhAnh.FileName);
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDeletePicture control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDeletePicture_Click(object sender, EventArgs e)
        {
            picHinhAnh.Image = null;
        }

        /// <summary>
        /// Handles the Click event of the btnLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            NV_QuaTrinhCongTac quatrinh = brsQuatrinhcongtac.Current as NV_QuaTrinhCongTac;

            if (quatrinh != null)
            {
                if (ValidatorQuaTrinh())
                {
                    quatrinh.TuNgay = dtpTuNgay.Value;
                    quatrinh.DenNgay = dtpDenNgay.Value;
                    quatrinh.PhongBan = txtPhongBan.Text;
                    quatrinh.ChucVu = txtChucVu.Text;
                    quatrinh.DonVi = txtDonVi.Text;
                    quatrinh.GhiChu = txtGhiChu.Text;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnXoa control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnXoa_Click(object sender, EventArgs e)
        {
            brsQuatrinhcongtac.RemoveCurrent();
        }

        /// <summary>
        /// Handles the Click event of the btnThem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnThem_Click(object sender, EventArgs e)
        {
           
            EnableControlsQuaTrinhCongTac(true);
            this.GrdataQuaTrinhCongTac.TableDescriptor.SortedColumns.Clear();
            ClearQuaTrinhCongTac();
            NV_QuaTrinhCongTac quatrinh = new NV_QuaTrinhCongTac();
            quatrinh.IdNhanVien = _IdNhanVien;
            brsQuatrinhcongtac.Add(quatrinh);
            brsQuatrinhcongtac.MoveLast();
            dtpTuNgay.Focus();
        }

        /// <summary>
        /// Handles the Click event of the btnLuuQuanHe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnLuuQuanHe_Click(object sender, EventArgs e)
        {
            NV_QuanHeGiaDinh QuanHe = brscQuanHe.Current as NV_QuanHeGiaDinh;

            if (QuanHe != null)
            {
                if (ValidatorQuanHe())
                {
                    QuanHe.HoTen = txtHoTen.Text;
                    QuanHe.NgaySinh = txtNgaySinh.Value;
                    QuanHe.NgheNghiep = txtNghwNghiep.Text;
                    QuanHe.DiaChi = txtDiaChi.Text;
                    QuanHe.QuanHe = txtQuanHe.Text;
                    QuanHe.GhiChu = txtGhiChuQuanHe.Text;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnXoaQuanHe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnXoaQuanHe_Click(object sender, EventArgs e)
        {
            brscQuanHe.RemoveCurrent();
        }

        /// <summary>
        /// Handles the Click event of the btnThemQuanHe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnThemQuanHe_Click(object sender, EventArgs e)
        {
            EnableControlsQuanHe(true);
            this.hrmGrigouping1.TableDescriptor.SortedColumns.Clear();
            ClearQuanHe();
            NV_QuanHeGiaDinh quanhe= new  NV_QuanHeGiaDinh();
            quanhe.IdNhanVien = _IdNhanVien;
            brscQuanHe.Add(quanhe);
            brscQuanHe.MoveLast();
            txtHoTen.Focus();
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool ValidatorQuaTrinh()
        {
            if (brsQuatrinhcongtac.Count > 0)
            {
                if (!dtpTuNgay.Value.HasValue)// HoDem nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTuNgay.Text);
                    this.dtpTuNgay.Focus();
                    return false;
                }
                if (!dtpDenNgay.Value.HasValue) //Ten not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblDenNgay.Text);
                    this.dtpDenNgay.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtChucVu.Text)) //Ten not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblChucVu.Text);
                    this.txtChucVu.Focus();
                    return false;
                }
            }

            //  }
            return true;
        }
        // <summary>
        /// Validators this instance.
        /// </summary>
        private bool ValidatorQuanHe()
        {
            if (brscQuanHe.Count > 0)
            {
                if (string.IsNullOrEmpty(txtHoTen.Text)) //Ten not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblHoTenQuanHe.Text);
                    this.txtHoTen.Focus();
                    return false;
                }
                if (string.IsNullOrEmpty(txtQuanHe.Text)) //Ten not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblLoaiQuanHe.Text);
                    this.txtQuanHe.Focus();
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region ---- bingdingsource ----

        /// <summary>
        /// Handles the PositionChanged event of the brsQuatrinhcongtac control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brsQuatrinhcongtac_PositionChanged(object sender, EventArgs e)
        {
            NV_QuaTrinhCongTac quatrinh = brsQuatrinhcongtac.Current as NV_QuaTrinhCongTac;

            if (quatrinh != null)
            {
                dtpTuNgay.Value = quatrinh.TuNgay;
                dtpDenNgay.Value = quatrinh.DenNgay;
                txtPhongBan.Text = quatrinh.PhongBan;
                txtChucVu.Text = quatrinh.ChucVu;
                txtDonVi.Text = quatrinh.DonVi;
                txtGhiChu.Text = quatrinh.GhiChu;
            }
        }

        /// <summary>
        /// Handles the PositionChanged event of the brscQuanHe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brscQuanHe_PositionChanged(object sender, EventArgs e)
        {
            NV_QuanHeGiaDinh QuanHe = brscQuanHe.Current as NV_QuanHeGiaDinh;

            if (QuanHe != null)
            {
                txtHoTen.Text = QuanHe.HoTen;
                txtNgaySinh.Value = QuanHe.NgaySinh;
                txtNghwNghiep.Text = QuanHe.NgheNghiep;
                txtDiaChi.Text = QuanHe.DiaChi;
                txtQuanHe.Text = QuanHe.QuanHe;
                txtGhiChuQuanHe.Text = QuanHe.GhiChu;
            }
        }

        #endregion

        #region ---- grd ----

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdataQuaTrinhCongTac control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
       private void GrdataQuaTrinhCongTac_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            EnableControlsQuaTrinhCongTac(true);
        }

       /// <summary>
       /// Handles the TableControlCellClick event of the hrmGrigouping1 control.
       /// </summary>
       /// <param name="sender">The source of the event.</param>
       /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
       void hrmGrigouping1_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
       {
           EnableControlsQuanHe(true);
       }

 
        #endregion

        #region ---- Form ----

        /// <summary>
        /// Handles the Load event of the SF212 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF212_Load(object sender, EventArgs e)
        {
            _IdNhanVien = this.IdNhanVien;
            brsQuatrinhcongtac.DataSource = _bussNhanVien.GetQuaTrinhCongTacbyIdNhanVien(_IdNhanVien);
            brscQuanHe.DataSource = _bussNhanVien.GetQuanHebyIdNhanVien(_IdNhanVien);

            if (brsQuatrinhcongtac.Count > 0)
            {
                GrdataQuaTrinhCongTac.Table.CurrentRecord = GrdataQuaTrinhCongTac.Table.Records[0];
            }
            if (brscQuanHe.Count > 0)
            {
                hrmGrigouping1.Table.CurrentRecord = hrmGrigouping1.Table.Records[0];
            }
           
            EnableControlsQuaTrinhCongTac(false);
            EnableControlsQuanHe(false);
            // GrdataQuaTrinhCongTac.DataSource = brsQuatrinhcongtac;
            LoadComBoBox();
            _current = _bussNhanVien.GetNhanVienbyId(_IdNhanVien);
            SetOject();

        }  

        #endregion

        #endregion
    }
}
