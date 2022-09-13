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

namespace HRM.Forms.TuyenDung
{
    public partial class SF111 : GridBaseForm
    {
        #region ---- Variables ----

        TD_UngVienBLL _bussUngVien = null;
        private List<int> _listError = null;
        private TD_UngVien _UngVien = null;
        private int _IdPhongBan = -1;
        private int _Quy = -1;
        private int _Nam = -1;
        private TD_UngVien _current = null;
        List<TD_UngVien> _list = null;
        private bool _uppdate = false;
        private bool _TuyenThang = false;
 
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF111"/> class.
        /// </summary>
        public SF111()
        {
            InitializeComponent();
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.btnPrint.Visible = false;
            this.btnExcel.Visible = false;
            this.btnAdd.Text = "Lưu và thêm";
            this.btnSave.Text = "Lưu và đóng";
            this.Load += new EventHandler(SF111_Load);
            _bussUngVien = new TD_UngVienBLL();
            _current = new TD_UngVien();
            _list = new List<TD_UngVien>();
      
        }

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
 
        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets a value indicating whether [tuyen thang].
        /// </summary>
        /// <value><c>true</c> if [tuyen thang]; otherwise, <c>false</c>.</value>
        public bool TuyenThang
        {
            get { return _TuyenThang; }
            set { _TuyenThang = value; }
        }

        /// <summary>
        /// Gets or sets the list.
        /// </summary>
        /// <value>The list.</value>
        public List<TD_UngVien> List
        {
            get { return _list; }
            set { _list = value; }
        }

        /// <summary>
        /// Gets or sets the nam.
        /// </summary>
        /// <value>The nam.</value>
        public int Nam
        {
            get { return _Nam; }
            set { _Nam = value; }
        }

        /// <summary>
        /// Gets or sets the quy.
        /// </summary>
        /// <value>The quy.</value>
        public int Quy
        {
            get { return _Quy; }
            set { _Quy = value; }
        }

        /// <summary>
        /// Gets or sets the id phong ban.
        /// </summary>
        /// <value>The id phong ban.</value>
        public int IdPhongBan
        {
            get { return _IdPhongBan; }
            set { _IdPhongBan = value; }
        }

        /// <summary>
        /// Gets or sets the ung vien.
        /// </summary>
        /// <value>The ung vien.</value>
        public TD_UngVien UngVien
        {
            get { return _UngVien; }
            set { _UngVien = value; }
        }
        

        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            GetOject();
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                UICommon.StartUpdate();
                List<TD_UngVien> list = (List<TD_UngVien>)brscGrdData.DataSource;
                _bussUngVien.UpdateDataList(list);
                UICommon.StopUpdate();
                UICommon.ShowSplashPanelUpdateMsg();
                _current = new TD_UngVien();
                _current.IdPhongBan = _IdPhongBan;
                _current.Quy = _Quy;
                _current.Nam = _Nam;
                _current.GioiTinh = true;
                if (_TuyenThang)
                {
                    _current.TuyenThang = _TuyenThang;
                    _current.DanhGia = true;
                }
                txtMaUngVien.Text = UICommon.GetString("MSG024");
                ClearsOject();
                txtHoDem.Focus();
                brscGrdData.Add(_current);
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            GetOject();
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                UICommon.StartUpdate();
                List<TD_UngVien> list = (List<TD_UngVien>)brscGrdData.DataSource;
                _bussUngVien.UpdateDataList(list);
                UICommon.StopUpdate();
                UICommon.ShowSplashPanelUpdateMsg();
                this.Close();
            }
        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Gets the oject.
        /// </summary>
        private void GetOject()
        {
            _current.CMND = txtCMND.Text;
            _current.DiaChiHienTai = txtDiaChiHienTai.Text;
            _current.DiaChiThuongTru = txtThuongTru.Text;
            _current.Email = txtEmail.Text;
            _current.GhiChu = txtGhiChu.Text;
            _current.HoDem = txtHoDem.Text;
            if (txtLuongSauThuViec.Text != string.Empty)
            {
                _current.LuongSauThuViec = txtLuongSauThuViec.Text == string.Empty ? 0 : CommonUtil.IsInt(txtLuongSauThuViec.Text);
            }
            if (txtLuongThuViec.Text != string.Empty)
            {
                _current.LuongThuViec = txtLuongThuViec.Text == string.Empty ? 0 : CommonUtil.IsInt(txtLuongThuViec.Text);
            }

            _current.NoiCapCMND = txtNoiCap.Text;
            _current.QuocTich = txtQuocTich.Text;


            _current.SoDienThoai = txtSDT.Text;
            _current.Ten = txtTen.Text;

            _current.IdChucDanh = cboChucDanh.SelectedValue == null ? -1 : (int)cboChucDanh.SelectedValue;
            _current.ChucDanhText = CacheData.GetTenChucDanh(cboChucDanh.SelectedValue == null ? -1 : (int)cboChucDanh.SelectedValue);
            _current.IdDanToc = cboDanToc.SelectedValue == null ? -1 : (int)cboDanToc.SelectedValue;
            _current.DanTocText = CacheData.GetTenDanToc(cboDanToc.SelectedValue == null ? -1 : (int)cboDanToc.SelectedValue);
            _current.IdTinhTrangHonNhan = cboHonNhan.SelectedValue == null ? -1 : (int)cboHonNhan.SelectedValue;
            _current.HonNhanText = CacheData.GetTenTinhTrangHonNhan(cboHonNhan.SelectedValue == null ? -1 : (int)cboHonNhan.SelectedValue);
            _current.NoiSinh = cboNoiSinh.SelectedValue == null ? -1 : (int)cboNoiSinh.SelectedValue;
            _current.NoiSinhText = CacheData.GetTenTinhThanh(cboNoiSinh.SelectedValue == null ? -1 : (int)cboNoiSinh.SelectedValue);
            _current.IdTonGiao = cboTonGiao.SelectedValue == null ? -1 : (int)cboTonGiao.SelectedValue;
            _current.TonGiaoText = CacheData.GetTenTonGiao(cboTonGiao.SelectedValue == null ? -1 : (int)cboTonGiao.SelectedValue);
            _current.IdTrinhDo = cboTrinhDo.SelectedValue == null ? -1 : (int)cboTrinhDo.SelectedValue;
            _current.IdChuyenNganh = cboChuyenNganh.SelectedValue == null ? -1 : (int)cboChuyenNganh.SelectedValue;

            _current.GioiTinh = rdbNam.Checked;
            _current.GioiTinhNu = rdbNu.Checked;

            _current.NgaySinh = dtpNgaySinh.Value;
            _current.NgayNhanViec = dtpNgayNhanViec.Value;

            if (_TuyenThang)
            {
                _current.TuyenThang = _TuyenThang;
            }

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
        /// Sets the oject.
        /// </summary>
        private void SetOject()
        {
            txtMaUngVien.Text = _current.MaUngVien;
            if (_current.MaUngVien == UICommon.GetString("MSG024"))
            {
                _current.MaUngVien = null;
            }
            txtCMND.Text = _current.CMND;
            txtDiaChiHienTai.Text = _current.DiaChiHienTai;
            txtThuongTru.Text = _current.DiaChiThuongTru;
            txtEmail.Text = _current.Email;
            txtGhiChu.Text = _current.GhiChu;
            txtHoDem.Text = _current.HoDem;
            txtLuongSauThuViec.Text = _current.LuongSauThuViec.HasValue ? _current.LuongSauThuViec.Value.ToString() : string.Empty;
            txtLuongThuViec.Text = _current.LuongThuViec.HasValue ? _current.LuongThuViec.Value.ToString() : string.Empty;
            txtNoiCap.Text = _current.NoiCapCMND;
            txtQuocTich.Text = _current.QuocTich;
            txtSDT.Text = _current.SoDienThoai;
            txtTen.Text = _current.Ten;

            cboChucDanh.SelectedValue = _current.IdChucDanh.HasValue ? _current.IdChucDanh.Value : -1;
            cboDanToc.SelectedValue = _current.IdDanToc.HasValue ? _current.IdDanToc.Value : -1;
            cboHonNhan.SelectedValue = _current.IdTinhTrangHonNhan.HasValue ? _current.IdTinhTrangHonNhan.Value : -1;
            cboNoiSinh.SelectedValue = _current.NoiSinh.HasValue ? _current.NoiSinh.Value  : -1;
            cboTonGiao.SelectedValue = _current.IdTonGiao.HasValue ? _current.IdTonGiao.Value : -1;
            cboTrinhDo.SelectedValue = _current.IdTrinhDo ;
            cboChuyenNganh.SelectedValue = _current.IdChuyenNganh;

            rdbNam.Checked = _current.GioiTinh.HasValue ? _current.GioiTinh.Value :false;
            rdbNu.Checked = _current.GioiTinhNu;

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
        /// Clearses the oject.
        /// </summary>
        private void ClearsOject()
        {
            txtCMND.Text = string.Empty;
            txtDiaChiHienTai.Text = string.Empty;
            txtThuongTru.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtGhiChu.Text = string.Empty;
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

            cboChuyenNganh.SelectedValue = -1;

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

            if (_TuyenThang)
            {
                this.cboChucDanh.DisplayMember = "TenChucDanh";
                this.cboChucDanh.ValueMember = "Id";
                this.cboChucDanh.DataSource = CacheData.GetDanhMucChucDanh();
            }
            else
            {
                this.cboChucDanh.DisplayMember = "TenChucDanh";
                this.cboChucDanh.ValueMember = "Id";
                this.cboChucDanh.DataSource = _bussUngVien.GetChucDanhTheoPYC(_IdPhongBan, _Quy, _Nam);
            }

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


           

            if (_TuyenThang)
            {
                this.cboTrinhDo.DisplayMember = "TenTrinhDo";
                this.cboTrinhDo.ValueMember = "Id";
                this.cboTrinhDo.DataSource = CacheData.GetDanhMucTrinhDo();
            }
            else
            {
                this.cboTrinhDo.DisplayMember = "TenTrinhDo";
                this.cboTrinhDo.ValueMember = "Id";
                this.cboTrinhDo.DataSource = _bussUngVien.GetTrinhDoTheoPYC(_IdPhongBan, _Quy, _Nam);
            }

            
            if (_TuyenThang)
            {
                this.cboChuyenNganh.DisplayMember = "TenChuyenNganh";
                this.cboChuyenNganh.ValueMember = "Id";
                this.cboChuyenNganh.DataSource = CacheData.GetDanhMucChuyenNganh();
            }
            else
            {
                this.cboChuyenNganh.DisplayMember = "TenChuyenNganh";
                this.cboChuyenNganh.ValueMember = "Id";
                this.cboChuyenNganh.DataSource = _bussUngVien.GetChuyenNganhTheoPYC(_IdPhongBan, _Quy, _Nam);
            }

            this.cboChucDanh.SelectedIndex = -1;
            this.cboHonNhan.SelectedIndex = -1;
            this.cboTonGiao.SelectedIndex = -1;
            this.cboTonGiao.SelectedIndex = -1;
            this.cboDanToc.SelectedIndex = -1;
            this.cboNoiSinh.SelectedIndex = -1;
            this.cboTrinhDo.SelectedIndex = -1;
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
            if  (cboChucDanh.SelectedIndex<0) //Ten not null
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
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears txt
            txtCMND.DataBindings.Clear();
            txtDiaChiHienTai.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtHoDem.DataBindings.Clear();
            txtLuongSauThuViec.DataBindings.Clear();
            txtLuongThuViec.DataBindings.Clear();
            //txtMaUngVien.DataBindings.Clear();
           // txtNam.DataBindings.Clear();
            txtNoiCap.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtTen.DataBindings.Clear();

            //clear combo
            cboChucDanh.DataBindings.Clear();
            cboHonNhan.DataBindings.Clear();
            cboNoiSinh.DataBindings.Clear();
          //  cboPhongBan.DataBindings.Clear();
           // cboQuy.DataBindings.Clear();
            cboTonGiao.DataBindings.Clear();

            //Clear dtp
            dtpNgayNhanViec.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();

            //Check box
            rdbNam.DataBindings.Clear();
            rdbNu.DataBindings.Clear();

           //  Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCMND.DataBindings.Add("Text", brscGrdData, "CMND", true, DataSourceUpdateMode.OnPropertyChanged);
            txtDiaChiHienTai.DataBindings.Add("Text", brscGrdData, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
            txtEmail.DataBindings.Add("Text", brscGrdData, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            txtHoDem.DataBindings.Add("Text", brscGrdData, "HoDem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLuongSauThuViec.DataBindings.Add("Text", brscGrdData, "LuongSauThuViec", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLuongThuViec.DataBindings.Add("Text", brscGrdData, "LuongThuViec", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtMaUngVien.DataBindings.Add("Text", brscGrdData, "MaUngVien", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNoiCap.DataBindings.Add("Text", brscGrdData, "NoiCapCMND", true, DataSourceUpdateMode.OnPropertyChanged);
            txtQuocTich.DataBindings.Add("Text", brscGrdData, "QuocTich", true, DataSourceUpdateMode.OnPropertyChanged);
            txtSDT.DataBindings.Add("Text", brscGrdData, "SoDienThoai", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTen.DataBindings.Add("Text", brscGrdData, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);

            //cbo
            cboChucDanh.DataBindings.Add("SelectedValue", brscGrdData, "IdChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboHonNhan.DataBindings.Add("SelectedValue", brscGrdData, "IdTinhTrangHonNhan", true, DataSourceUpdateMode.OnPropertyChanged);
            cboNoiSinh.DataBindings.Add("SelectedValue", brscGrdData, "NoiSinh", true, DataSourceUpdateMode.OnPropertyChanged);
            cboTonGiao.DataBindings.Add("SelectedValue", brscGrdData, "TonGiao", true, DataSourceUpdateMode.OnPropertyChanged);

            //dtp
            dtpNgayNhanViec.DataBindings.Add("Value", brscGrdData, "NgayNhanViec", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgaySinh.DataBindings.Add("Value", brscGrdData, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);

            //rdb
            rdbNam.DataBindings.Add("Checked", brscGrdData, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            rdbNu.DataBindings.Add("Checked", brscGrdData, "GioiTinhNu", true, DataSourceUpdateMode.OnPropertyChanged);
          
        }

        #endregion

        #region ---- Events ----

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the SF111 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF111_Load(object sender, EventArgs e)
        {
            // Get value
            _Nam = this.Nam;
            _IdPhongBan = this.IdPhongBan;
            _Quy = this.Quy;
            _list = this.List;
            _UngVien = this.UngVien;
            _current = _UngVien;
            _TuyenThang = TuyenThang;
            if (_TuyenThang)
            {
                _current.DanhGia = true;
            }
            // load combo
            LoadComBoBox();
            // set value to form
            SetOject();

            //_current = new TD_UngVien();
            //TD_UngVien item = new TD_UngVien();
            _current.IdPhongBan = _IdPhongBan;
            _current.Quy = _Quy;
            _current.Nam = _Nam;
          //  List<TD_UngVien> list = new List<TD_UngVien>();
            brscGrdData.DataSource = _list;
            brscGrdData.Add(_current);
           // AddDataBinding();
            this.txtHoDem.Focus();
           // this.ss.Click += new EventHandler(btnAddPicture_Click);
            this.btnDeletePicture.Click+=new EventHandler(btnDeletePicture_Click);
        } 

        #endregion
        

        #endregion
    }
}
