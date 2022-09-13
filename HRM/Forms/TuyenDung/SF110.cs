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
    public partial class SF110 : GridBaseForm
    {
        #region ---- Variables ----

        TD_UngVienBLL _bussUngVien = null;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF107"/> class.
        /// </summary>
        public SF110()
        {
            InitializeComponent();
            this.InitForm();
        }

        #endregion

        #region Protected methods

        /// <summary>
        /// Prints the documents.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        protected override void PrintDocuments()
        {

        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            // Get data
            _bussUngVien = new TD_UngVienBLL();
            _listError = new List<int>();
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnSave.Enabled = false;
            // Loaddata for combo
            LoadComBoBox();

            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSave.Visible = false;
            this.btnExcel.Visible = false;
            this.btnPrint.Visible = false;
            this.btnExcelTemplate.Visible = true;
            this.btnPrintTemplate.Visible = true;

            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgaySinh", "NgayNhanViec");

            // Add events 
            // this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            //this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);

            this.cboChucDanh.SelectedIndexChanged += new EventHandler(cboChucDanh_SelectedIndexChanged);
            this.cboDanToc.SelectedIndexChanged += new EventHandler(cboDanToc_SelectedIndexChanged);
            this.cboHonNhan.SelectedIndexChanged += new EventHandler(cboHonNhan_SelectedIndexChanged);
            this.cboNoiSinh.SelectedIndexChanged += new EventHandler(cboNoiSinh_SelectedIndexChanged);
            this.cboTonGiao.SelectedIndexChanged += new EventHandler(cboTonGiao_SelectedIndexChanged);

            // Event button
            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);

            this.LoadData();
            this.GrdData.DataSource = brscGrdData;
        }



        /// <summary>
        /// Loads the COM bo box.
        /// </summary>
        private void LoadComBoBox()
        {

            // GetData
            this.cboPhongBan.DisplayMember = "TenPhongBan";
            this.cboPhongBan.ValueMember = "Id";
            this.cboPhongBan.DataSource = _bussUngVien.GetAllPhongBan();

            // GetData
            this.cboQuy.DisplayMember = "Ten";
            this.cboQuy.ValueMember = "Id";
            this.cboQuy.DataSource = _bussUngVien.GetAllQuy();

            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();


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

            this.cboChucDanh.SelectedIndex = -1;
            this.cboHonNhan.SelectedIndex = -1;
            this.cboTonGiao.SelectedIndex = -1;
            this.cboTonGiao.SelectedIndex = -1;
            this.cboDanToc.SelectedIndex = -1;
            this.cboNoiSinh.SelectedIndex = -1;
        }

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            // txt

            txtCMND.Enabled = pvalue;
            txtDiaChi.Enabled = pvalue;
            txtEmail.Enabled = pvalue;
            txtGhiChu.Enabled = pvalue;
            txtHoDem.Enabled = pvalue;
            txtLuongSauThuViec.Enabled = pvalue;
            txtLuongThuViec.Enabled = pvalue;
            txtMaUngVien.Enabled = pvalue;
            //txtNam.Enabled = pvalue;
            txtNoiCap.Enabled = pvalue;
            txtQuocTich.Enabled = pvalue;
            txtSDT.Enabled = pvalue;
            txtTen.Enabled = pvalue;

            //combo
            cboChucDanh.Enabled = pvalue;
            cboHonNhan.Enabled = pvalue;
            cboNoiSinh.Enabled = pvalue;
            //cboPhongBan.Enabled = pvalue;
            //cboQuy.Enabled = pvalue;
            cboTonGiao.Enabled = pvalue;
            cboDanToc.Enabled = pvalue;

            //dtp 
            dtpNgayNhanViec.Enabled = pvalue;
            dtpNgaySinh.Enabled = pvalue;

            //Check box

            rdbNam.Enabled = pvalue;
            rdbNu.Enabled = pvalue;

        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears txt
            txtCMND.DataBindings.Clear();
            txtDiaChi.DataBindings.Clear();
            txtEmail.DataBindings.Clear();
            txtGhiChu.DataBindings.Clear();
            txtHoDem.DataBindings.Clear();
            txtLuongSauThuViec.DataBindings.Clear();
            txtLuongThuViec.DataBindings.Clear();
            //txtMaUngVien.DataBindings.Clear();
            txtNam.DataBindings.Clear();
            txtNoiCap.DataBindings.Clear();
            txtQuocTich.DataBindings.Clear();
            txtSDT.DataBindings.Clear();
            txtTen.DataBindings.Clear();

            //clear combo
            cboChucDanh.DataBindings.Clear();
            cboHonNhan.DataBindings.Clear();
            cboNoiSinh.DataBindings.Clear();
            cboPhongBan.DataBindings.Clear();
            cboQuy.DataBindings.Clear();
            cboTonGiao.DataBindings.Clear();

            //Clear dtp
            dtpNgayNhanViec.DataBindings.Clear();
            dtpNgaySinh.DataBindings.Clear();

            //Check box
            rdbNam.DataBindings.Clear();
            rdbNu.DataBindings.Clear();

            // Bingding
            //txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtCMND.DataBindings.Add("Text", brscGrdData, "CMND", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtDiaChi.DataBindings.Add("Text", brscGrdData, "DiaChi", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtEmail.DataBindings.Add("Text", brscGrdData, "Email", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtHoDem.DataBindings.Add("Text", brscGrdData, "HoDem", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtLuongSauThuViec.DataBindings.Add("Text", brscGrdData, "LuongSauThuViec", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtLuongThuViec.DataBindings.Add("Text", brscGrdData, "LuongThuViec", true, DataSourceUpdateMode.OnPropertyChanged);
            ////txtMaUngVien.DataBindings.Add("Text", brscGrdData, "MaUngVien", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtNoiCap.DataBindings.Add("Text", brscGrdData, "NoiCapCMND", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtQuocTich.DataBindings.Add("Text", brscGrdData, "QuocTich", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtSDT.DataBindings.Add("Text", brscGrdData, "SoDienThoai", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtTen.DataBindings.Add("Text", brscGrdData, "Ten", true, DataSourceUpdateMode.OnPropertyChanged);

            ////cbo
            //cboChucDanh.DataBindings.Add("SelectedValue", brscGrdData, "IdChucDanh", true, DataSourceUpdateMode.OnPropertyChanged);
            //cboHonNhan.DataBindings.Add("SelectedValue", brscGrdData, "IdTinhTrangHonNhan", true, DataSourceUpdateMode.OnPropertyChanged);
            //cboNoiSinh.DataBindings.Add("SelectedValue", brscGrdData, "NoiSinh", true, DataSourceUpdateMode.OnPropertyChanged);
            //cboTonGiao.DataBindings.Add("SelectedValue", brscGrdData, "TonGiao", true, DataSourceUpdateMode.OnPropertyChanged);

            ////dtp
            //dtpNgayNhanViec.DataBindings.Add("Value", brscGrdData, "NgayNhanViec", true, DataSourceUpdateMode.OnPropertyChanged);
            //dtpNgaySinh.DataBindings.Add("Value", brscGrdData, "NgaySinh", true, DataSourceUpdateMode.OnPropertyChanged);

            ////rdb
            //rdbNam.DataBindings.Add("Checked", brscGrdData, "GioiTinh", true, DataSourceUpdateMode.OnPropertyChanged);
            //rdbNu.DataBindings.Add("Checked", brscGrdData, "GioiTinhNu", true, DataSourceUpdateMode.OnPropertyChanged);


            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<TD_UngVien> listData = (List<TD_UngVien>)brscGrdData.DataSource;

            foreach (TD_UngVien item in listData)
            {

                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.HoDem))// HoDem nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblHoDem.Text);
                    this.txtHoDem.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.Ten)) //Ten not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTen.Text);
                    this.txtTen.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

            }
            return true;
        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            List<TD_UngVien> list = _bussUngVien.GetUngVienTrungTuyen(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(this.cboQuy.Text), CommonUtil.IsInt(txtNam.Text));

            this.brscGrdData.DataSource = list;

            Enable(false);
            brscGrdData.MoveLast();
            // phan quyen nhansu phongban
            //  PhanQuyen();
        }

        #endregion

        #region ---- Events ----

        #region ---- Textbox ----

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        #endregion

        #region ---- Combobox ----

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboTonGiao control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboTonGiao_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;
            if (ungvien != null)
            {
                try
                {
                    ungvien.IdTonGiao = ((DM_TonGiao)this.cboTonGiao.SelectedItem).Id;
                    ungvien.TonGiaoText = CacheData.GetTenTonGiao(((DM_TonGiao)this.cboTonGiao.SelectedItem).Id);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboNoiSinh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboNoiSinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;
            if (ungvien != null)
            {
                try
                {
                    ungvien.NoiSinh = ((DM_Tinh)this.cboNoiSinh.SelectedItem).Id;
                    ungvien.NoiSinhText = CacheData.GetTenTinhThanh(((DM_Tinh)this.cboNoiSinh.SelectedItem).Id);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboHonNhan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboHonNhan_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;
            if (ungvien != null)
            {
                try
                {
                    ungvien.IdTinhTrangHonNhan = ((DM_TinhTrangHonNhan)this.cboHonNhan.SelectedItem).Id;
                    ungvien.HonNhanText = CacheData.GetTenTinhTrangHonNhan(((DM_TinhTrangHonNhan)this.cboHonNhan.SelectedItem).Id);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboDanToc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;
            if (ungvien != null)
            {
                try
                {
                    ungvien.IdDanToc = ((DM_DanToc)this.cboDanToc.SelectedItem).Id;
                    ungvien.DanTocText = CacheData.GetTenDanToc(((DM_DanToc)this.cboDanToc.SelectedItem).Id);
                }
                catch
                {

                }
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboChucDanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboChucDanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;
            if (ungvien != null)
            {
                try
                {
                    ungvien.IdChucDanh = ((DM_ChucDanh)this.cboChucDanh.SelectedItem).Id;
                    ungvien.ChucDanhText = CacheData.GetTenChucDanh(((DM_ChucDanh)this.cboChucDanh.SelectedItem).Id);
                }
                catch
                {

                }
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

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            Enable(true);
        }

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            //return;
            //TD_UngVien ungvien = brscGrdData.Current as TD_UngVien;

            //if (ungvien != null)
            //{
            //    SF111 frm = new SF111();
            //    frm.UngVien = ungvien;
            //    frm.IdPhongBan = ((DM_PhongBan)this.cboPhongBan.SelectedItem).Id;
            //    frm.Quy = (int)cboQuy.SelectedValue;
            //    frm.Nam = CommonUtil.IsInt(txtNam.IntegerValue.ToString());
            //    frm.List = ((List<TD_UngVien>)brscGrdData.DataSource);
            //    frm.ShowDialog();
            //    LoadData();
            //}

        }

        #endregion

        #region ---- Bingdingsource ----

        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;

            if (ungvien != null && !string.IsNullOrEmpty(ungvien.MaUngVien))
            {
                txtMaUngVien.Text = ungvien.MaUngVien;
                //txtCMND.Text = ungvien.CMND;
                //txtDiaChi.Text = ungvien.DiaChi;
                //txtEmail.Text = ungvien.Email;
                //txtGhiChu.Text = ungvien.GhiChu;
                //txtHoDem.Text = ungvien.HoDem;
                //txtLuongSauThuViec.Text = ungvien.LuongSauThuViec.HasValue ? ungvien.LuongSauThuViec.ToString():string.Empty ;
                //txtLuongThuViec.Text = ungvien.LuongThuViec.HasValue ? ungvien.LuongThuViec.Value.ToString(): string.Empty;
                //txtNoiCap.Text = ungvien.NoiCapCMND;
                //txtQuocTich.Text = ungvien.QuocTich;
                //txtSDT.Text = ungvien.SoDienThoai.HasValue ? ungvien.SoDienThoai.Value.ToString():string.Empty;
                //txtTen.Text = ungvien.Ten;

                //cboChucDanh.SelectedValue = ungvien.IdChucDanh.HasValue ? ungvien.IdChucDanh.Value : -1;
            }
            else
            {
                txtMaUngVien.Text = UICommon.GetString("MSG024");
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
        /// <Date>16/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                Dictionary<string, string> listThongTin = new Dictionary<string, string>();
                listThongTin.Add("PhongBan", cboPhongBan.Text);
                listThongTin.Add("Quy", cboQuy.Text);
                listThongTin.Add("Nam", txtNam.Text);
                ExcelExport excel = new ExcelExport();
                List<TD_UngVien> listDS = new List<TD_UngVien>();
                listDS = brscGrdData.DataSource as List<TD_UngVien>;
                string file = string.Empty;
                excel.ExportDanhSachUngVienDau(listDS, listThongTin, ref file, true);
            }
            else
            {
                UICommon.ShowMsgInfo("MSG022");
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>16/06/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                Dictionary<string, string> listThongTin = new Dictionary<string, string>();
                listThongTin.Add("PhongBan", cboPhongBan.Text);
                listThongTin.Add("Quy", cboQuy.Text);
                listThongTin.Add("Nam", txtNam.Text);
                ExcelExport excel = new ExcelExport();
                List<TD_UngVien> listDS = new List<TD_UngVien>();
                listDS = brscGrdData.DataSource as List<TD_UngVien>;
                string file = string.Empty;
                excel.ExportDanhSachUngVienDau(listDS, listThongTin, ref file, false);
                excel.OpenFile(file);
            }
            else
            {
                UICommon.ShowMsgInfo("MSG022");
            }
        }

        #endregion

        #endregion
    }
}
