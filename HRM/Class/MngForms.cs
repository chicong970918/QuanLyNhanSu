using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.DanhMuc;
using HRM.DataAccess.Common;
using System.Threading;
using HRM.Forms.DanhMuc;
using HRM.Forms.TuyenDung;
using HRM.Forms.HeThong;
using HRM.Forms.NhanVien;
using HRM.Forms.ChamCong_Luong;
using HRM.Entities;

namespace HRM.Class
{
    /// <summary>
    /// 
    /// </summary>
    public class MngForms
    {
        #region ---- Enums ----

        /// <summary>
        /// 
        /// </summary>
        public enum Forms
        {
            #region ---- Danh muc ----

            DanhMucPhongBan,
            DanhMucChuyenNganh,
            DanhMucDanToc,
            DanhMucNgoaiNgu,
            DanhMucQuanHe,
            DanhMucHonNhan,
            DanhMucTonGiao,
            DanhMucTinHoc,
            DanhMucCapTuyenDung,
            DanhMucChucDanh,
            DanhMucLyDo,
            DanhMucYeuCauCongViec,
            DanhMucTinhThanh,
            DanhMucQuanHuyen,
            DanhMucPhuCap,
            DanhMucThuongLe,
            DanhMucTrinhDo,
            DanhMucBieuMau,
            
            #endregion

            #region ---- Tuyen dung ----

            KeHoachTuyenDung,
            ChiTietKeHoachTD,
            XetDuyetKHTD,
            LapPYCTheoKH,
            LapPYCTuDo,
            XetDuyetPYC,
            ThongBaoTuyenDung,
            NhapHoSoUngVien,
            KeHoachThuViec,
            ChiTietKeHoachThuViec,
            DanhGiaThuViec, 
            LamHopDong ,
            KetQuaThuViec,

            #endregion

            #region ---- NhanVien ----

            TraCuuHoSoNV,
            ThemNhanVien,
            QuyetDinhBoNhiem,
            QuyetDinhThoiViec,
            HopDongLaoDongThuViec, 
            HopDongChinhThuc,
            QuyetDinhKhenThuong,
            QuyetDinhKyLuat,
            QuyetDinhTangHeSoLuong,
            QuyetDinhThangCap,
            QuyetDinhTangHeSoChuyenMon,
            CacLoaiQD,

            #endregion

            #region ---- ChamCong_TinhLuong ----

            ChamCongMaVach,
            ChamCongBangTay,
            TongHopChamCongPhongBan,
            TinhLuongTheoThang,
            TraCuuLuong,
            PhieuLuong,
            LuongChoNVThoiViec, 
            DanhMucTamUng,
            TraCuuChamCongNhanVien,

            #endregion

            #region ---- Dang Nhap  ----
			DanhMucNguoiDung,
            DanhMucNhomNguoiDung,
            ThemNguoiDungVaoNhom,
            DanhMucManHinh,
		    PhanQuyenNguoiDung,
		
	        #endregion
        }


        #endregion

        #region ---- Member variables ----

        private static SortedList<Forms, Form> _lstForm = new SortedList<Forms, Form>();

        private static List<QL_PhanQuyen> _lstQuyen = null;

        public static List<QL_PhanQuyen> ListQuyen
        {
            get
            {
                if (MngForms._lstQuyen == null)
                {
                    MngForms._lstQuyen = new List<QL_PhanQuyen>();
                }
                return MngForms._lstQuyen;
            }
            set { MngForms._lstQuyen = value; }
        }


        #endregion

        #region ---- Public methods ----

        /// <summary>
        /// Shows the MDI child form.
        /// </summary>
        /// <param name="pForm">The p form.</param>
        public static void ShowMDIChildForm(Forms pForm, params object[] arg)
        {
            //System.Diagnostics.Stopwatch sw = System.Diagnostics.Stopwatch.StartNew();

            if (_lstForm.ContainsKey(pForm))
            {
                _lstForm[pForm].Activate();

                return;
            }

            Form frm = null;

            switch (pForm)
            {
                #region ---- Danh muc ---

                case Forms.DanhMucPhongBan:
                    frm = new SF001();
                    break;

                case Forms.DanhMucChuyenNganh:
                    frm = new SF002();
                    break;
                case Forms.DanhMucDanToc:
                    frm = new SF003();
                    break;
                case Forms.DanhMucNgoaiNgu:
                    frm = new SF004();
                    break;
                case Forms.DanhMucQuanHe:
                    frm = new SF005();
                    break;

                case Forms.DanhMucHonNhan:
                    frm = new SF006();
                    break;

                case Forms.DanhMucTonGiao:
                    frm = new SF007();
                    break;

                case Forms.DanhMucTinHoc:
                    frm = new SF008();
                    break;
                case Forms.DanhMucCapTuyenDung:
                    frm = new SF009();
                    break;
                case Forms.DanhMucChucDanh:
                    frm = new SF010();
                    break;
                case Forms.DanhMucTrinhDo:
                    frm = new SF016();
                    break;
                case Forms.DanhMucLyDo:
                    frm = new SF011();
                    break;
                case Forms.DanhMucYeuCauCongViec:
                    frm = new SF012();
                    break;
                case Forms.DanhMucTinhThanh:
                    frm = new SF013();
                    break;
                case Forms.DanhMucQuanHuyen:
                    frm = new SF014();
                    break;
                case Forms.DanhMucPhuCap:
                    frm = new SF015();
                    break;
                case Forms.DanhMucThuongLe:
                    frm = new SF017();
                    break;
                case Forms.DanhMucBieuMau:
                    frm = new SF019();
                    break;

                #endregion

                #region ----  Tuyen Dung ---

                case Forms.KeHoachTuyenDung:
                    frm = new SF100();
                    break;
                case Forms.ChiTietKeHoachTD:
                    frm = new SF101();
                    break;
                case Forms.XetDuyetKHTD:
                    frm = new SF102();
                    break;
                case Forms.LapPYCTheoKH:
                    frm = new SF103();
                    break;
                case Forms.LapPYCTuDo:
                    frm = new SF104();
                    break;
                case Forms.XetDuyetPYC:
                    frm = new SF105();
                    break;
                case Forms.ThongBaoTuyenDung:
                    frm = new SF106();
                    break;
                case Forms.NhapHoSoUngVien:
                    frm = new SF107();
                    break;
                case Forms.KeHoachThuViec:
                    frm = new SF108();
                    break;
                case Forms.ChiTietKeHoachThuViec:
                    frm = new SF112();
                    break;
                case Forms.DanhGiaThuViec:
                    frm = new SF109();
                    break;
                case Forms.LamHopDong:
                    frm = new SF110();
                    break;
                case Forms.KetQuaThuViec:
                    frm = new SF116();
                    break;
                //ChiTietKeHoachThuViec

                #endregion

                #region ---- Nhanvien ----

                case Forms.TraCuuHoSoNV:
                    frm = new SF200();
                    break;
                case Forms.ThemNhanVien:
                    frm = new SF201();
                    break;
                case Forms.QuyetDinhBoNhiem:
                    frm = new SF213();
                    break;
                case Forms.QuyetDinhThoiViec:
                    frm = new SF203();
                    break;
                case Forms.HopDongLaoDongThuViec:
                    frm = new SF204();
                    break;
                case Forms.CacLoaiQD:
                    frm = new SF210();
                    break; 
                case Forms.HopDongChinhThuc:
                    frm = new SF211();
                    break; 

                #endregion

                #region ---- ChamCong_TinhLuong ----

                case Forms.TongHopChamCongPhongBan:
                    frm = new SF301();
                    break;
                case Forms.ChamCongBangTay:
                    frm = new SF306();
                    break;
                case Forms.TinhLuongTheoThang:
                    frm = new SF302();
                    break;
                case Forms.PhieuLuong:
                    frm = new SF303();
                    break;
                case Forms.LuongChoNVThoiViec:
                    frm = new SF304();
                    break;
                case Forms.DanhMucTamUng:
                    frm = new SF308();
                    break;
                case Forms.TraCuuLuong:
                    frm = new SF310();
                    break;
                case Forms.TraCuuChamCongNhanVien:
                    frm = new SF311();
                    break; 

                #endregion

                #region ---- He thong ----

                case Forms.DanhMucNguoiDung:
                    frm = new SF900();
                    break;
                case Forms.DanhMucNhomNguoiDung:
                    frm = new SF901();
                    break;
                case Forms.ThemNguoiDungVaoNhom:
                    frm = new SF902();
                    break;
                case Forms.DanhMucManHinh:
                    frm = new SF903();
                    break;
                case Forms.PhanQuyenNguoiDung:
                    frm = new SF904();
                    break;

                #endregion
            }

            if (frm != null)
            {
                //Wait load all data finish
                while (LayerCommon._SecondThread != null)
                {
                    if (LayerCommon._SecondThread.ThreadState == ThreadState.Stopped)
                    {
                        break;
                    }
                    Thread.Sleep(100);
                }

                // Add to list
                _lstForm.Add(pForm, frm);

                frm.Tag = pForm;
                frm.Disposed += new EventHandler(frmMDIChild_Disposed);

                // Set Mdi Parent
                frm.MdiParent = Program.mainForm;

                // Show form
                frm.Show();
            }

            //sw.Stop();
            //MessageBox.Show(Program.mainForm, sw.Elapsed.TotalSeconds.ToString());
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="pForm">The p form.</param>
        public static void ShowDialog(Form pForm)
        {
            //Wait load data completed
            while (LayerCommon._SecondThread != null)
            {
                if (LayerCommon._SecondThread.ThreadState == ThreadState.Stopped)
                {
                    break;
                }
                Thread.Sleep(100);
            }

            pForm.StartPosition = FormStartPosition.CenterParent;

            pForm.ShowDialog(Program.mainForm);
        }

        #endregion

        #region ---- Handle events ----

        /// <summary>
        /// Handles the Disposed event of the frmMDIChild control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private static void frmMDIChild_Disposed(object sender, EventArgs e)
        {
            Form frm = sender as Form;

            if (frm.Tag != null)
            {
                Forms f = (Forms)frm.Tag;

                _lstForm.Remove(f);
            }
        }

        #endregion ---- Handle events ----
    }
}
