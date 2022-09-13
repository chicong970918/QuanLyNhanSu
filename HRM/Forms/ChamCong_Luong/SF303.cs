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
using HRM.DataAccess.ChamCong_TinhLuong;
using HRM.DataAccess.NguoiDung;
using HRM.DataAccess.QuanLyNhanVien;
using HRM.DataAccess.Catalogs;
namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF303 : GridBaseForm
    {
        #region ---- Variable ----

        private int _IdNhanVien = 0;
        private QL_NguoiDungBLL _bussNguoiDung = null;
        private NV_NhanVienBLL _busNhanVien = null;
        private TL_BangLuongBLL _bussBangLuong = null;
        private DanhMucPhongBanBLL _bussPhongBan = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF310"/> class.
        /// </summary>
        public SF303()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnSave.Visible = false;
            this.btnDelete.Visible = false;
            this.btnExcelTemplate.Visible = true;
            this.btnPrintTemplate.Visible = true;
            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);
            this.btnExcelTemplate.Text = "Xuất bảng lương";
            this.btnPrintTemplate.Text = "In bảng lương";
            this.btnExcel.Text = "Xuất phiếu lương";
            this.btnPrint.Text = "In phiếu lương";

            this.toolStripSeparator1.Visible = false;
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            _bussPhongBan = new DanhMucPhongBanBLL();
            _bussNguoiDung = new QL_NguoiDungBLL();
            _busNhanVien = new NV_NhanVienBLL();
            _bussBangLuong = new TL_BangLuongBLL();
            LoadCombobox();
            UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "TienHeSoLuong", "TienNgayNghi", "ThucLinh");
        }

        #endregion

        #region ---- Protected methods ----

        /// <summary>
        /// Exports the excel.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>08/07/2011</Date>
        protected override void ExportExcel()
        {
            ExcelExport excel = new ExcelExport();
            if (brscGrdData.Count > 0)
            {
                List<TL_BangLuong> list = brscGrdData.DataSource as List<TL_BangLuong>;
                string path = string.Empty;
                excel.ExportBangLuongTungNhanVien(list, cboPhongBan.Text, ref path, false);

                if (!string.IsNullOrEmpty(path) && UICommon.ShowMessage("MSG023", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(path);
                }
            }
        }

        /// <summary>
        /// Prints the documents.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>08/07/2011</Date>
        protected override void PrintDocuments()
        {
            ExcelExport excel = new ExcelExport();
            if (brscGrdData.Count > 0)
            {
                List<TL_BangLuong> list = brscGrdData.DataSource as List<TL_BangLuong>;
                string path = string.Empty;
                excel.ExportBangLuongTungNhanVien(list,cboPhongBan.Text, ref path, true);
                if (!string.IsNullOrEmpty(path))
                {
                    Print(path);
                }
            }

        }

        #endregion

        #region ---- Private Methods ----


        /// <summary>
        /// Loads the combobox.
        /// </summary>
        private void LoadCombobox()
        {
            cboPhongBan.DataSource = _bussPhongBan.GetPhongBan();
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";
        }

        /// <summary>
        /// Checkeds the search.
        /// </summary>
        /// <returns></returns>
        private bool CheckedSearch()
        {

            if (cboPhongBan.SelectedIndex < 0)
            {
                UICommon.ShowMsgInfo("MSG005", lblPhongBan.Text);
                this.cboPhongBan.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtThang.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lbThang.Text);
                this.txtThang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNam.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lblNam.Text);
                this.txtNam.Focus();
                return false;
            }
            return true;
        }

        #endregion

        #region ---- Event ----


        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckedSearch())
            {
                brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuongXemNamThangPhongBan((int)((DM_PhongBan)cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));

                if (!(brscGrdData.Count > 0))
                {
                    UICommon.ShowMsgInfo("MSG009");
                }
            }
 
        }

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>05/07/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            if (brscGrdData.Count > 0)
            {
                List<TL_BangLuong> bangLuong = brscGrdData.DataSource as List<TL_BangLuong>;

                if (bangLuong == null)
                {
                    UICommon.ShowMsgInfo("MSG022");
                }
                else
                {
                    string path = string.Empty;
                    Dictionary<string, string> pThongTin = new Dictionary<string, string>();
                    string thongTin = string.Empty;
                    thongTin = cboPhongBan.Text + " THÁNG" + txtThang.Text + " NĂM " + txtNam.Text;
                    pThongTin.Add("PhongBan", thongTin.ToUpper());
                    excel.ExportBangLuongNhanVien(bangLuong, pThongTin, ref path, true);


                }

            }
        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>05/07/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            ExcelExport excel = new ExcelExport();
            if (brscGrdData.Count > 0)
            {
                List<TL_BangLuong> bangLuong = brscGrdData.DataSource as List<TL_BangLuong>;

                if (bangLuong == null)
                {
                    UICommon.ShowMsgInfo("MSG022");
                }
                else
                {
                    string path = string.Empty;
                    Dictionary<string, string> pThongTin = new Dictionary<string, string>();
                    string thongTin = string.Empty;
                    thongTin = cboPhongBan.Text + " THÁNG " + txtThang.Text + " NĂM " + txtNam.Text;
                    pThongTin.Add("PhongBan", thongTin.ToUpper());
                    excel.ExportBangLuongNhanVien(bangLuong, pThongTin, ref path, false);

                    // Confirm for open file was exported

                    if (!string.IsNullOrEmpty(path) && UICommon.ShowMessage("MSG023", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                    {
                        System.Diagnostics.Process.Start(path);
                    }
                }

            }
        }

        #endregion
    }
}
