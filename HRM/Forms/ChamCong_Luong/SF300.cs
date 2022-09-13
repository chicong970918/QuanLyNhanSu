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
using HRM.DataAccess.QuanLyNhanVien;
namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF300 : TuyenDungBaseForm
    {
        #region ---- Variables ----

        private TL_ChamCongBLL _bussChamCong = null;
        private NV_NhanVienBLL _busNhanVien = null;
        private NV_HopDong _bbbbb = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF300"/> class.
        /// </summary>
        public SF300()
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
            _bussChamCong = new TL_ChamCongBLL();
            _busNhanVien = new NV_NhanVienBLL();
            this.dtpNgayChamCong.Value = CacheData.Context.GetSystemDate();
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSave.Visible = false;
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.toolStripSeparator3.Visible = false;
            this.txtMaNhanVien.KeyDown += new KeyEventHandler(txtMaNhanVien_KeyDown);
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgaySinh", "NgayChamCong");
            brscGrdData.DataSource = _bussChamCong.GetAllData((DateTime)dtpNgayChamCong.Value);
            GrdData.DataSource = brscGrdData;
        }

        #endregion

        #region ---- Enums ----

        #region ---- Textbox ----

        /// <summary>
        /// Handles the KeyDown event of the txtMaNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        void txtMaNhanVien_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                NV_NhanVien nhanvien = (_busNhanVien.CheckedNhanVienIsExited(txtMaNhanVien.Text));
                if (nhanvien == null)
                {
                    lblThongBao.Text = UICommon.GetString("MSG027");
                    return;
                }
                TL_ChamCong chamcong = new TL_ChamCong();
                chamcong.IdNhanVien=((NV_NhanVien)nhanvien).Id;
                chamcong.NgayChamCong=dtpNgayChamCong.Value;
                int trangthai=_bussChamCong.CheckedData(chamcong);
                if( trangthai==1)
                {
                    chamcong.GioVao = CacheData.Context.GetSystemDate();
                }
                else
                {
                    if (trangthai == 3)
                    {
                        chamcong.GioRa = CacheData.Context.GetSystemDate();
                    }
                    else
                    {
                        lblThongBao.Text = UICommon.GetString("MSG034");
                        return;
                    }
                }
                _bussChamCong.UpdateDataChamCong(chamcong);

                lblThongBao.Text = string.Empty;

                brscGrdData.DataSource = _bussChamCong.GetAllData((DateTime)dtpNgayChamCong.Value);
            }
        }  

        #endregion

        #endregion
    }
}
