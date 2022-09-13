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
    public partial class SF304 : GridBaseForm
    {
        #region ---- Variables ----
        private int _IdNhanVien = 0;
        private TL_BangLuongBLL _bussBangLuong = null;
        private NV_NhanVienBLL _busNhanVien = null;
      
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF302"/> class.
        /// </summary>
        public SF304()
        {
            InitializeComponent();
            this.btnAdd.Visible = true;
            this.btnSave.Visible = true;
            this.btnDelete.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            _bussBangLuong = new TL_BangLuongBLL();
            _busNhanVien = new NV_NhanVienBLL();
            this.btnAdd.Text = "Xem bảng lương";
            this.btnSearch.Text = "Tính lương";
            this.btnSearch.Image = imageList1.Images[0];
            this.btnAdd.Image = imageList1.Images[2];
            this.btnDelete.Text = "Khóa lương";
            this.btnDelete.Image = imageList1.Images[3];
            ToolStripItem mnuItem = null;

            for (int i = this.contextMenuStrip1.Items.Count - 1; i >= 0; i--)
            {
                mnuItem = contextMenuStrip1.Items[i];
                this.GrdData.InternalContextMenuStripEx.Items.Insert(0, mnuItem);
            }
            UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "TienHeSoLuong", "TienNgayNghi", "ThucLinh");
          //  UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "TienHeSoLuong", "TienNgayNghi", "TienThuongLe", "TienPhat", "TienThuongKhac", "PhuCapKhac", "TamUng", "ThucLinh", "MucLuongCoBan");
        }
        
        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                return;
            }
            if (!(brscGrdData.Count > 0))
            {
                return;
            }
            base.SaveData();
            UICommon.StartUpdate();
            List<TL_BangLuong> list = (List<TL_BangLuong>)brscGrdData.DataSource;
            _bussBangLuong.UpdateDataList(list);
            UICommon.StopUpdate();
            UICommon.ShowSplashPanelUpdateMsg();

        } 

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Checkeds the befor process.
        /// </summary>
        /// <returns></returns>
        private bool CheckedBeforProcess()
        {
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

        #region ---- Events ----

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            NV_NhanVien nhanvien = (_busNhanVien.CheckedNhanVienIsExited(txtMaNhanVien.Text));
            if (nhanvien == null)
            {
                UICommon.ShowMsgInfo("MSG027");
                return;
            }

            _IdNhanVien = ((NV_NhanVien)nhanvien).Id;

            if (_bussBangLuong.CheckeQuyetDinhThoiViecNhanVien(_IdNhanVien))
            {
                UICommon.ShowMsgInfo("MSG043");
                return;
            }


            if (_bussBangLuong.CheckeTinhLuongThoiViecNhanVien(_IdNhanVien, CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG044");
                return;
            }

            if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                return;
            }
            if (CheckedBeforProcess())
            {

                //if (_bussBangLuong.CheckedDataTinhLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
                //{
                //    UICommon.ShowMsgInfo("MSG037", txtThang.Text);
                //    return;
                //}

                UICommon.StartProcess();

                brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuongThoiViec(_IdNhanVien,CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                
                GrdData.DataSource = brscGrdData;

                UICommon.StopProcess();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnAdd_Click(object sender, EventArgs e)
        {
            NV_NhanVien nhanvien = (_busNhanVien.CheckedNhanVienIsExited(txtMaNhanVien.Text));
            if (nhanvien == null)
            {
                UICommon.ShowMsgInfo("MSG027");
                return;
            }

            _IdNhanVien = ((NV_NhanVien)nhanvien).Id;

            if (_bussBangLuong.CheckeQuyetDinhThoiViecNhanVien(_IdNhanVien))
            {
                UICommon.ShowMsgInfo("MSG043");
                return;
            }


            if (CheckedBeforProcess())
            {
                UICommon.StartProcess();

                brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuongXemNamThang(_IdNhanVien,CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                GrdData.DataSource = brscGrdData;

                UICommon.StopProcess();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckedBeforProcess())
            {
                if (UICommon.ShowMsgConfirm("MSG038") == DialogResult.Yes)// Xac nhan
                {
                    _bussBangLuong.KhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the phụCấpKhácToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void phụCấpKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                return;
            }
            
            TL_BangLuong bangluong = this.brscGrdData.Current as TL_BangLuong;
            
            if (bangluong != null)
            {
                SF309 frm = new SF309();
                frm.BangLuong = bangluong;
                frm.ShowDialog();
                bangluong.PhuCapKhac = frm.SoTien;
                bangluong.ThucLinh = bangluong.ThucLinh + bangluong.PhuCapKhac;
            }
        }

        #endregion

        #endregion
    }
}
