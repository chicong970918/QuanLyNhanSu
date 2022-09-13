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
using System ;
using HRM.Forms.TuyenDung;

namespace HRM.Forms.NhanVien
{
    public partial class SF213 : GridBaseForm
    {
        #region ---- Variables ----

        TD_UngVienBLL _bussUngVien = null;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF107"/> class.
        /// </summary>
        public SF213()
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
            base.GetNewData();
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            this.GrdData.TableDescriptor.SortedColumns.Clear();
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    List<TD_UngVien> list = (List<TD_UngVien>)brscGrdData.DataSource;
                    _bussUngVien.UpdateDataList(list);
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
            // Get data
            _bussUngVien = new TD_UngVienBLL();
            _listError = new List<int>();
            this.btnSearch.Visible = true;
            this.toolStripSeparator1.Visible = true;
            // this.btnSave.Enabled = false;
            this.btnExcel.Visible = false;
            this.btnPrint.Visible = false;
            this.btnPrintTemplate.Visible = true;
            this.btnExcelTemplate.Visible = true;
            toolStripSeparator2.Visible = false;
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSave.Visible = false;
            this.toolStripSeparator3.Visible = false;
            this.btnSearch.Text = "Bổ nhiệm NS";
            this.toolStripSeparator3.Visible = false;
            this.toolStripSeparator4.Visible = false;

            btnExcelTemplate.Visible = true;
            btnPrintTemplate.Visible = true;
            btnExcel.Visible = false;
            btnPrint.Visible = false;

            // Loaddata for combo
            LoadComBoBox();

            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgaySinh", "NgayNhanViec");

            // Add events 
            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);
            this.btnPrintTemplate.Text = "In bổ nhiệm NS";
            this.btnExcelTemplate.Text = "Xuất Excel bổ nhiệm NS";

            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboChucDanh.SelectedIndexChanged += new EventHandler(cboChucDanh_SelectedIndexChanged);
            this.cboDanToc.SelectedIndexChanged += new EventHandler(cboDanToc_SelectedIndexChanged);
            this.cboHonNhan.SelectedIndexChanged += new EventHandler(cboHonNhan_SelectedIndexChanged);
            this.cboNoiSinh.SelectedIndexChanged += new EventHandler(cboNoiSinh_SelectedIndexChanged);
            this.cboTonGiao.SelectedIndexChanged += new EventHandler(cboTonGiao_SelectedIndexChanged);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            this.LoadData();
            EnableControls(false);
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();
            this.brscGrdData.PositionChanged += new EventHandler(brscGrdData_PositionChanged);
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
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;

            if (ungvien != null)
            {
                // Get The position of the Item
                if (string.IsNullOrEmpty(ungvien.TenQuyetDinh))// HoDem nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenQuyetDinh.Text);
                    this.txtTenQuyetDinh.Focus();
                    return false;
                }
                // Get The position of the Item
                if (!ungvien.NgayHieuLuc.HasValue)// HoDem nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblNgayHieuLuc.Text);
                    this.dtpNgayHieuLuc.Focus();
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
            List<TD_UngVien> list = _bussUngVien.GetDataByPhongBanQuyNamBoNhiem(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(this.cboQuy.Text), CommonUtil.IsInt(txtNam.Text));

            this.brscGrdData.DataSource = list;

            if (brscGrdData.Count > 0)
            {
                GrdData.Table.CurrentRecord = GrdData.Table.Records[0];
            }
            // brscGrdData.MoveLast();
        }

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void EnableControls(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtTenQuyetDinh.Enabled = pvalue;
            txtSoQuyetDinh.Enabled = pvalue;
            txtNoiDung.Enabled = pvalue;
            dtpNgayHieuLuc.Enabled = pvalue;
            dtpNgayQuyetDinh.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtTenQuyetDinh.DataBindings.Clear();
            // txtSoQuyetDinh.DataBindings.Clear();
            txtNoiDung.DataBindings.Clear();
            dtpNgayHieuLuc.DataBindings.Clear();
            dtpNgayQuyetDinh.DataBindings.Clear();

            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChuBoNhiem", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenQuyetDinh.DataBindings.Add("Text", brscGrdData, "TenQuyetDinh", true, DataSourceUpdateMode.OnPropertyChanged);
            //txtSoQuyetDinh.DataBindings.Add("Text", brscGrdData, "SoQuyetDinh", true, DataSourceUpdateMode.OnPropertyChanged);
            txtNoiDung.DataBindings.Add("Text", brscGrdData, "NoiDung", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayHieuLuc.DataBindings.Add("Value", brscGrdData, "NgayHieuLuc", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpNgayQuyetDinh.DataBindings.Add("Value", brscGrdData, "NgayQuyetDinh", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
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
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
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

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            //TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;

            //if (ungvien != null && !string.IsNullOrEmpty(ungvien.SoQuyetDinh))
            //{
            //    txtSoQuyetDinh.Text = ungvien.SoQuyetDinh;
            //    EnableControls(false);
            //}
            //else
            //{
            //    txtSoQuyetDinh.Text = UICommon.GetString("MSG032");
            //    EnableControls(true);
            //}
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
            //TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;

            //if (ungvien != null && !string.IsNullOrEmpty(ungvien.SoQuyetDinh))
            //{
            //    txtSoQuyetDinh.Text = ungvien.SoQuyetDinh;
            //}
            //else
            //{
            //    txtSoQuyetDinh.Text = UICommon.GetString("MSG032");
            //}
        }

        /// <summary>
        /// Handles the PositionChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void brscGrdData_PositionChanged(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;

            if (ungvien != null &&  ungvien.SoQuyetDinh>0)
            {
                txtSoQuyetDinh.Text = ungvien.SoQuyetDinh.ToString();
                EnableControls(false);
            }
            else
            {
                txtSoQuyetDinh.Text = UICommon.GetString("MSG032");
                EnableControls(true);
            }

        }

        #endregion

        #region ---- Button ----


        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>12/06/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>12/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;
                if (ungvien != null)
                {
                    NV_QuyetDinhBoNhiem boNhiem = _bussUngVien.GetQuyetDinhByIdUngVien(ungvien.Id);
                    if (boNhiem != null)
                    {
                        WordExport word = new WordExport();
                        word.QuyetDinhBoNhiem(ungvien, boNhiem);

                    }
                }

            }
            //TD_UngVien ungVien = brscGrdData.CurrencyManager.Current as TD_UngVien;
            //if (ungVien != null)
            //{
            //    WordExport word = new WordExport();
            //    word.ExportHoSoUngVien(ungVien);
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TD_UngVien ungvien = this.brscGrdData.Current as TD_UngVien;

            if (ungvien != null)
            {
                if (_bussUngVien.CheckQuyetDinhBoNhiem(ungvien.Id))
                {
                    UICommon.ShowMsgWarning("MSG033", (ungvien.HoDem + " " + ungvien.Ten).Trim());
                    return;
                }
                if (Validator())
                {
                    _bussUngVien.UpdateDataBoNhiem(ungvien);
                    LoadData();
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
        }


        #endregion

        #endregion
    }
}
