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

namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF310 : GridBaseForm
    {
        private int _IdNhanVien = 0;
        private QL_NguoiDungBLL _bussNguoiDung = null;
        private NV_NhanVienBLL _busNhanVien = null;
        private TL_BangLuongBLL _bussBangLuong = null;

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF310"/> class.
        /// </summary>
        public SF310()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnSave.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            //this.checkboxAll.CheckedChanged += new Syncfusion.Windows.Forms.Tools.CheckedChangedEventHandler(checkboxAll_CheckedChanged);
            _bussNguoiDung = new QL_NguoiDungBLL();
            _busNhanVien = new NV_NhanVienBLL();
            _bussBangLuong = new TL_BangLuongBLL();
        }

        /// <summary>
        /// Checkeds the process.
        /// </summary>
        /// <returns></returns>
        private bool CheckedProcess()
        {
            if (LayerCommon.CurrentUser.IdNhanVien.HasValue)
            {
                _IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.Value;
                NV_NhanVien nhanvien = _bussNguoiDung.GetNhanVien(_IdNhanVien);
                if (nhanvien.MaNhanVien == txtMaNhanVien.Text)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Checkeds the search.
        /// </summary>
        /// <returns></returns>
        private bool CheckedSearch()
        {
            if (txtNam.Text == string.Empty && txtThang.Text == string.Empty)
            {
                txtThang.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            NV_NhanVien nhanvien = (_busNhanVien.CheckedNhanVienIsExited(txtMaNhanVien.Text));
            if (nhanvien == null)
            {
                 UICommon.ShowMsgInfo("MSG027");
                return;
            }
            if (CheckedProcess())
            {
                if (checkboxAll.Checked)
                {
                    brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuongXemTatCa(_IdNhanVien);
                }
                else
                {
                    if (CheckedSearch())
                    {
                        brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuongXemNamThang(_IdNhanVien,CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                    }
                    else
                    {
                        UICommon.ShowMsgInfo("MSG041","tháng","năm");
                        return;
                    }
                }
            }
            else
            {
                UICommon.ShowMsgWarning("MSG040","bảng lương");
            }
        }
  
        /// <summary>
        /// Handles the CheckedChanged event of the checkboxAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Tools.CheckedChangedEventArgs"/> instance containing the event data.</param>
        void checkboxAll_CheckedChanged(object sender, Syncfusion.Windows.Forms.Tools.CheckedChangedEventArgs e)
        {
            if (checkboxAll.Checked)
            {
                txtNam.Text = null;
                txtThang.Text = null;
                txtNam.Enabled = !checkboxAll.Checked;
                txtThang.Enabled = !checkboxAll.Checked;
            }
            else
            {
                txtNam.Enabled = !checkboxAll.Checked;
                txtThang.Enabled = !checkboxAll.Checked;
            }
        }


        #endregion
    }
}
