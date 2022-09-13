using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using HRM.Class;
using HRM.DanhMuc;
using HRM.Forms.ChamCong_Luong;
using HRM.DataAccess.NguoiDung;
using HRM.DataAccess;
using HRM.DataAccess.Common;
using HRM.Entities;
using HRM.Forms;
using System.IO;
using HRM.DataAccess.QuanLyNhanVien;

namespace HRM
{
    /// <summary>
    /// 
    /// </summary>
    public partial class MainForm : Office2007Form
    {
        NV_NhanVienBLL _bussNhanVien = null;
        QL_NguoiDungBLL _bussNguoiDung = null;

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _bussNhanVien=new NV_NhanVienBLL();
            _bussNguoiDung = new QL_NguoiDungBLL();
            this.Load+=new EventHandler(MainForm_Load);
           // this.statusStripLabelSpring.Text = string.Empty;
            try
            {
                NV_NhanVien nhanvien = _bussNhanVien.GetNhanVienbyId(LayerCommon.CurrentUser.IdNhanVien.Value);
                this.statusStripLabelUserName.Text = nhanvien.HoDem.ToString() + " " + nhanvien.Ten.ToString();
                this.statusStripMain.ContextMenuStrip = null;
            }
            catch
            {

            }
           
        }

        #endregion

        public void Designer()
        {
           
            //this.mnuMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(227)))), ((int)(((byte)(239)))), ((int)(((byte)(255)))));
            //this.mnuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            //this.mnuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.hệThốngToolStripMenuItem,
            //this.toolStripMenuItem8,
            //this.toolStripMenuItem6,
            //this.toolStripMenuItem11,
            //this.danhMụcToolStripMenuItem,
            //this.trợGiúpToolStripMenuItem});
            //this.mnuMain.Location = new System.Drawing.Point(0, 0);
            //this.mnuMain.Name = "mnuMain";
            //this.mnuMain.Size = new System.Drawing.Size(913, 25);
            //this.mnuMain.TabIndex = 2;
            //this.mnuMain.Text = "menuStrip1";
            //// 
            //// hệThốngToolStripMenuItem
            //// 
            //this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.toolStripMenuItem5,
            //this.toolStripSeparator10,
            //this.toolStripMenuItem7,
            //this.toolStripSeparator6,
            //this.mnu_HeThong_ChangePwd,
            //this.toolStripSeparator7,
            //this.mnuHeThongDanhMucManHinh,
            //this.mnuHeThong_DanhMucManHinh,
            //this.toolStripSeparator22,
            //this.mnuHeThong_Thoat});
            //this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            //this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(78, 21);
            //this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            //// 
            //// toolStripMenuItem5
            //// 
            //this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.mnuHeThong_QLND_NhomNguoiDung,
            //this.mnuHeThong_QLND_NguoiDung,
            //this.mnuHeThong_QLND_ThemNguoiDungNhom});
            //this.toolStripMenuItem5.Image = global::HRM.Properties.Resources.User;
            //this.toolStripMenuItem5.ImageTransparentColor = System.Drawing.Color.Transparent;
            //this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            //this.toolStripMenuItem5.Size = new System.Drawing.Size(204, 22);
            //this.toolStripMenuItem5.Text = " Quản lý người dùng";
            //// 

            //// toolStripMenuItem7
            //// 
            //this.toolStripMenuItem7.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.mnuHT_PhanQuyen_NguoiDung});
            //this.toolStripMenuItem7.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem7.Image")));
            //this.toolStripMenuItem7.ImageTransparentColor = System.Drawing.Color.Transparent;
            //this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            //this.toolStripMenuItem7.Size = new System.Drawing.Size(204, 22);
            //this.toolStripMenuItem7.Text = "Phân quyền";
            //// mnuHeThong_QLND_NhomNguoiDung
            //// 
            //this.mnuHeThong_QLND_NhomNguoiDung.Image = global::HRM.Properties.Resources.UserGroup;
            //this.mnuHeThong_QLND_NhomNguoiDung.Name = "mnuHeThong_QLND_NhomNguoiDung";
            //this.mnuHeThong_QLND_NhomNguoiDung.Size = new System.Drawing.Size(253, 22);
            //this.mnuHeThong_QLND_NhomNguoiDung.Tag = "SF901";
            //this.mnuHeThong_QLND_NhomNguoiDung.Text = "Nhóm người dùng";
            //this.mnuHeThong_QLND_NhomNguoiDung.Click += new System.EventHandler(this.mnuHeThong_NhomNguoiDung_Click);
            //// 
            //// mnuHeThong_QLND_NguoiDung
            //// 
            //this.mnuHeThong_QLND_NguoiDung.Image = global::HRM.Properties.Resources.user1;
            //this.mnuHeThong_QLND_NguoiDung.Name = "mnuHeThong_QLND_NguoiDung";
            //this.mnuHeThong_QLND_NguoiDung.Size = new System.Drawing.Size(253, 22);
            //this.mnuHeThong_QLND_NguoiDung.Tag = "SF902";
            //this.mnuHeThong_QLND_NguoiDung.Text = "Người dùng";
            //this.mnuHeThong_QLND_NguoiDung.Click += new System.EventHandler(this.mnuHeThong_NguoiDung_Click);
            //// 
            //// mnuHeThong_QLND_ThemNguoiDungNhom
            //// 
            //this.mnuHeThong_QLND_ThemNguoiDungNhom.Image = global::HRM.Properties.Resources.UserToGroup;
            //this.mnuHeThong_QLND_ThemNguoiDungNhom.Name = "mnuHeThong_QLND_ThemNguoiDungNhom";
            //this.mnuHeThong_QLND_ThemNguoiDungNhom.Size = new System.Drawing.Size(253, 22);
            //this.mnuHeThong_QLND_ThemNguoiDungNhom.Tag = "SF903";
            //this.mnuHeThong_QLND_ThemNguoiDungNhom.Text = "Thêm người dùng vào nhóm";
            //this.mnuHeThong_QLND_ThemNguoiDungNhom.Click += new System.EventHandler(this.mnuHeThong_NguoiDungNhomNguoiDung_Click);
            //// 
            //// toolStripSeparator10
            //// 
            //this.toolStripSeparator10.Name = "toolStripSeparator10";
            //this.toolStripSeparator10.Size = new System.Drawing.Size(201, 6);
            //// 
      
            //// 
            //// mnuHT_PhanQuyen_NguoiDung
            //// 
            //this.mnuHT_PhanQuyen_NguoiDung.Image = global::HRM.Properties.Resources.user1;
            //this.mnuHT_PhanQuyen_NguoiDung.Name = "mnuHT_PhanQuyen_NguoiDung";
            //this.mnuHT_PhanQuyen_NguoiDung.Size = new System.Drawing.Size(152, 22);
            //this.mnuHT_PhanQuyen_NguoiDung.Tag = "SF904";
            //this.mnuHT_PhanQuyen_NguoiDung.Text = "Người dùng";
            //this.mnuHT_PhanQuyen_NguoiDung.Click += new System.EventHandler(this.mnuHeThong_PhanQuyenNguoiDung_Click);
            //// 
            //// toolStripSeparator6
            //// 
            //this.toolStripSeparator6.BackColor = System.Drawing.SystemColors.Control;
            //this.toolStripSeparator6.Name = "toolStripSeparator6";
            //this.toolStripSeparator6.Size = new System.Drawing.Size(201, 6);
            //this.toolStripSeparator6.Tag = "";
            //// 
            //// mnu_HeThong_ChangePwd
            //// 
            //this.mnu_HeThong_ChangePwd.Image = global::HRM.Properties.Resources.resetpassword;
            //this.mnu_HeThong_ChangePwd.Name = "mnu_HeThong_ChangePwd";
            //this.mnu_HeThong_ChangePwd.Size = new System.Drawing.Size(204, 22);
            //this.mnu_HeThong_ChangePwd.Tag = "";
            //this.mnu_HeThong_ChangePwd.Text = "Thay đổi mật khẩu";
            //this.mnu_HeThong_ChangePwd.Click += new System.EventHandler(this.mnuHeThong_ThayDoiMatKhau_Click);
            //// 
            //// toolStripSeparator7
            //// 
            //this.toolStripSeparator7.Name = "toolStripSeparator7";
            //this.toolStripSeparator7.Size = new System.Drawing.Size(201, 6);
            //this.toolStripSeparator7.Tag = "";
            //// 
            //// mnuHeThongDanhMucManHinh
            //// 
            //this.mnuHeThongDanhMucManHinh.Enabled = false;
            //this.mnuHeThongDanhMucManHinh.Image = global::HRM.Properties.Resources.lcd;
            //this.mnuHeThongDanhMucManHinh.Name = "mnuHeThongDanhMucManHinh";
            //this.mnuHeThongDanhMucManHinh.Size = new System.Drawing.Size(204, 22);
            //this.mnuHeThongDanhMucManHinh.Tag = "";
            //this.mnuHeThongDanhMucManHinh.Text = "Danh mục màn hình";
            //this.mnuHeThongDanhMucManHinh.Visible = false;
            //this.mnuHeThongDanhMucManHinh.Click += new System.EventHandler(this.mnuHeThong_DanhMucManHinh_Click);
            //// 
            //// mnuHeThong_DanhMucManHinh
            //// 
            //this.mnuHeThong_DanhMucManHinh.Enabled = false;
            //this.mnuHeThong_DanhMucManHinh.Name = "mnuHeThong_DanhMucManHinh";
            //this.mnuHeThong_DanhMucManHinh.Size = new System.Drawing.Size(204, 22);
            //this.mnuHeThong_DanhMucManHinh.Tag = "";
            //this.mnuHeThong_DanhMucManHinh.Text = "Hệ thống";
            //this.mnuHeThong_DanhMucManHinh.Visible = false;
            //// 
            //// toolStripSeparator22
            //// 
            //this.toolStripSeparator22.Name = "toolStripSeparator22";
            //this.toolStripSeparator22.Size = new System.Drawing.Size(201, 6);
            //// 
            //// mnuHeThong_Thoat
            //// 
            //this.mnuHeThong_Thoat.Image = global::HRM.Properties.Resources.shutdowns;
            //this.mnuHeThong_Thoat.Name = "mnuHeThong_Thoat";
            //this.mnuHeThong_Thoat.Size = new System.Drawing.Size(204, 22);
            //this.mnuHeThong_Thoat.Text = "Thoát chương trình";
            //this.mnuHeThong_Thoat.Click += new System.EventHandler(this.mnuHeThongThoatChuongTrinh_Click);
            //// 
            //// toolStripMenuItem8
            //// 
            //this.toolStripMenuItem8.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.kếHoạchToolStripMenuItem,
            //this.phiếuYêuCầuToolStripMenuItem,
            //this.inThôngBáoTDToolStripMenuItem,
            //this.ứngViênToolStripMenuItem,
            //this.thửViệcToolStripMenuItem});
            //this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            //this.toolStripMenuItem8.Size = new System.Drawing.Size(96, 21);
            //this.toolStripMenuItem8.Text = "Tuyển dụng";
            //// 
            //// kếHoạchToolStripMenuItem
            //// 
            //this.kếHoạchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.lậpKếHoạchToolStripMenuItem,
            //this.xétDuyệtKếHoạchToolStripMenuItem});
            //this.kếHoạchToolStripMenuItem.Image = global::HRM.Properties.Resources.KeHoachTD1;
            //this.kếHoạchToolStripMenuItem.Name = "kếHoạchToolStripMenuItem";
            //this.kếHoạchToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            //this.kếHoạchToolStripMenuItem.Text = "Kế hoạch";
            //// 
            //// lậpKếHoạchToolStripMenuItem
            //// 
            //this.lậpKếHoạchToolStripMenuItem.Image = global::HRM.Properties.Resources.KeHoach2;
            //this.lậpKếHoạchToolStripMenuItem.Name = "lậpKếHoạchToolStripMenuItem";
            //this.lậpKếHoạchToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            //this.lậpKếHoạchToolStripMenuItem.Tag = "SF100";
            //this.lậpKếHoạchToolStripMenuItem.Text = "Lập kế hoạch";
            //this.lậpKếHoạchToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_LapKeHoach_Click);
            //// 
            //// xétDuyệtKếHoạchToolStripMenuItem
            //// 
            //this.xétDuyệtKếHoạchToolStripMenuItem.Image = global::HRM.Properties.Resources.XetDuyet;
            //this.xétDuyệtKếHoạchToolStripMenuItem.Name = "xétDuyệtKếHoạchToolStripMenuItem";
            //this.xétDuyệtKếHoạchToolStripMenuItem.Size = new System.Drawing.Size(198, 22);
            //this.xétDuyệtKếHoạchToolStripMenuItem.Tag = "SF102";
            //this.xétDuyệtKếHoạchToolStripMenuItem.Text = "Xét duyệt kế hoạch";
            //this.xétDuyệtKếHoạchToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_XetDuyetKeHoach_Click);
            //// 
            //// phiếuYêuCầuToolStripMenuItem
            //// 
            //this.phiếuYêuCầuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem,
            //this.lậpPhiếuTựDoToolStripMenuItem,
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem});
            //this.phiếuYêuCầuToolStripMenuItem.Image = global::HRM.Properties.Resources.PhieuYeuCau1;
            //this.phiếuYêuCầuToolStripMenuItem.Name = "phiếuYêuCầuToolStripMenuItem";
            //this.phiếuYêuCầuToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            //this.phiếuYêuCầuToolStripMenuItem.Text = "Phiếu yêu cầu";
            //// 
            //// lậpPhiếuTheoKếHoachToolStripMenuItem
            //// 
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem.Image = global::HRM.Properties.Resources.KeHoach2;
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem.Name = "lậpPhiếuTheoKếHoachToolStripMenuItem";
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem.Tag = "SF103";
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem.Text = "Lập phiếu theo kế hoach";
            //this.lậpPhiếuTheoKếHoachToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_LapPYCTheoKH_Click);
            //// 
            //// lậpPhiếuTựDoToolStripMenuItem
            //// 
            //this.lậpPhiếuTựDoToolStripMenuItem.Image = global::HRM.Properties.Resources.PhieuYeuCau;
            //this.lậpPhiếuTựDoToolStripMenuItem.Name = "lậpPhiếuTựDoToolStripMenuItem";
            //this.lậpPhiếuTựDoToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            //this.lậpPhiếuTựDoToolStripMenuItem.Tag = "SF104";
            //this.lậpPhiếuTựDoToolStripMenuItem.Text = "Lập phiếu tự do";
            //this.lậpPhiếuTựDoToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_LapPYCTuDo_Click);
            //// 
            //// xétDuyệtPhiếuYêuCầuToolStripMenuItem
            //// 
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem.Image = global::HRM.Properties.Resources.XetDuyet;
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem.Name = "xétDuyệtPhiếuYêuCầuToolStripMenuItem";
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem.Tag = "SF105";
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem.Text = "Xét duyệt phiếu yêu cầu";
            //this.xétDuyệtPhiếuYêuCầuToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_XetDuyetPYC_Click);
            //// 
            //// inThôngBáoTDToolStripMenuItem
            //// 
            //this.inThôngBáoTDToolStripMenuItem.Image = global::HRM.Properties.Resources.ThongBao;
            //this.inThôngBáoTDToolStripMenuItem.Name = "inThôngBáoTDToolStripMenuItem";
            //this.inThôngBáoTDToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            //this.inThôngBáoTDToolStripMenuItem.Tag = "SF106";
            //this.inThôngBáoTDToolStripMenuItem.Text = "In thông báo TD";
            //this.inThôngBáoTDToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_ThongBaoTuyenDung_Click);
            //// 
            //// ứngViênToolStripMenuItem
            //// 
            //this.ứngViênToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.nhậpHồSơỨngViênToolStripMenuItem,
            //this.tToolStripMenuItem});
            //this.ứngViênToolStripMenuItem.Image = global::HRM.Properties.Resources.UngVien;
            //this.ứngViênToolStripMenuItem.Name = "ứngViênToolStripMenuItem";
            //this.ứngViênToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            //this.ứngViênToolStripMenuItem.Text = "Ứng viên";
            //// 
            //// nhậpHồSơỨngViênToolStripMenuItem
            //// 
            //this.nhậpHồSơỨngViênToolStripMenuItem.Image = global::HRM.Properties.Resources.addUngVien;
            //this.nhậpHồSơỨngViênToolStripMenuItem.Name = "nhậpHồSơỨngViênToolStripMenuItem";
            //this.nhậpHồSơỨngViênToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            //this.nhậpHồSơỨngViênToolStripMenuItem.Tag = "SF107";
            //this.nhậpHồSơỨngViênToolStripMenuItem.Text = "Nhập hồ sơ ứng viên";
            //this.nhậpHồSơỨngViênToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_HoSoUngVien_Click);
            //// 
            //// tToolStripMenuItem
            //// 
            //this.tToolStripMenuItem.Image = global::HRM.Properties.Resources.search;
            //this.tToolStripMenuItem.Name = "tToolStripMenuItem";
            //this.tToolStripMenuItem.Size = new System.Drawing.Size(211, 22);
            //this.tToolStripMenuItem.Tag = "SF115";
            //this.tToolStripMenuItem.Text = "Tra cứu ứng viên đậu";
            //this.tToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_LamHopDong_Click);
            //// 
            //// thửViệcToolStripMenuItem
            //// 
            //this.thửViệcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.kếHoạchThửViệcToolStripMenuItem,
            //this.toolStripMenuItem10,
            //this.toolStripSeparator1,
            //this.đánhGiáThửViệcToolStripMenuItem,
            //this.kếtQuảThửViệcToolStripMenuItem});
            //this.thửViệcToolStripMenuItem.Image = global::HRM.Properties.Resources.ThuViec;
            //this.thửViệcToolStripMenuItem.Name = "thửViệcToolStripMenuItem";
            //this.thửViệcToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            //this.thửViệcToolStripMenuItem.Text = "Thử việc";
            //// 
            //// kếHoạchThửViệcToolStripMenuItem
            //// 
            //this.kếHoạchThửViệcToolStripMenuItem.Image = global::HRM.Properties.Resources.ThuViec2;
            //this.kếHoạchThửViệcToolStripMenuItem.Name = "kếHoạchThửViệcToolStripMenuItem";
            //this.kếHoạchThửViệcToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            //this.kếHoạchThửViệcToolStripMenuItem.Tag = "SF108";
            //this.kếHoạchThửViệcToolStripMenuItem.Text = "Kế hoạch thử việc";
            //this.kếHoạchThửViệcToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_LapKeHoachThuViec_Click);
            //// 
            //// toolStripMenuItem10
            //// 
            //this.toolStripMenuItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem10.Image")));
            //this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            //this.toolStripMenuItem10.Size = new System.Drawing.Size(234, 22);
            //this.toolStripMenuItem10.Tag = "SF112";
            //this.toolStripMenuItem10.Text = "Chi tiết kế hoạch thử việc";
            //this.toolStripMenuItem10.Click += new System.EventHandler(this.mnuTuyenDung_ChiTietKeHoachThuViec_Click);
            //// 
            //// toolStripSeparator1
            //// 
            //this.toolStripSeparator1.Name = "toolStripSeparator1";
            //this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            //// 
            //// đánhGiáThửViệcToolStripMenuItem
            //// 
            //this.đánhGiáThửViệcToolStripMenuItem.Image = global::HRM.Properties.Resources.ThuViec1;
            //this.đánhGiáThửViệcToolStripMenuItem.Name = "đánhGiáThửViệcToolStripMenuItem";
            //this.đánhGiáThửViệcToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            //this.đánhGiáThửViệcToolStripMenuItem.Tag = "SF109";
            //this.đánhGiáThửViệcToolStripMenuItem.Text = "Đánh giá thử việc";
            //this.đánhGiáThửViệcToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_DanhGiaThuViec_Click);
            //// 
            //// kếtQuảThửViệcToolStripMenuItem
            //// 
            //this.kếtQuảThửViệcToolStripMenuItem.Image = global::HRM.Properties.Resources.resrt;
            //this.kếtQuảThửViệcToolStripMenuItem.Name = "kếtQuảThửViệcToolStripMenuItem";
            //this.kếtQuảThửViệcToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            //this.kếtQuảThửViệcToolStripMenuItem.Tag = "SF116";
            //this.kếtQuảThửViệcToolStripMenuItem.Text = "Kết quả thử việc";
            //this.kếtQuảThửViệcToolStripMenuItem.Click += new System.EventHandler(this.mnuTuyenDung_KetThuVQuaiec_Click);
            //// 
            //// toolStripMenuItem6
            //// 
            //this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.hồSơToolStripMenuItem,
            //this.quyếtĐịnhToolStripMenuItem,
            //this.hợpĐồngToolStripMenuItem});
            //this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            //this.toolStripMenuItem6.Size = new System.Drawing.Size(84, 21);
            //this.toolStripMenuItem6.Text = "Nhân viên";
            //// 
            //// hồSơToolStripMenuItem
            //// 
            //this.hồSơToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.taCứuNhânViênToolStripMenuItem,
            //this.thêmNhânViênToolStripMenuItem});
            //this.hồSơToolStripMenuItem.Image = global::HRM.Properties.Resources.documents;
            //this.hồSơToolStripMenuItem.Name = "hồSơToolStripMenuItem";
            //this.hồSơToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            //this.hồSơToolStripMenuItem.Text = "Hồ sơ";
            //// 
            //// taCứuNhânViênToolStripMenuItem
            //// 
            //this.taCứuNhânViênToolStripMenuItem.Image = global::HRM.Properties.Resources.Search2;
            //this.taCứuNhânViênToolStripMenuItem.Name = "taCứuNhânViênToolStripMenuItem";
            //this.taCứuNhânViênToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            //this.taCứuNhânViênToolStripMenuItem.Tag = "SF200";
            //this.taCứuNhânViênToolStripMenuItem.Text = "Tra cứu nhân viên";
            //this.taCứuNhânViênToolStripMenuItem.Click += new System.EventHandler(this.mnuNhanVien_TraCuuNhanVien_Click);
            //// 
            //// thêmNhânViênToolStripMenuItem
            //// 
            //this.thêmNhânViênToolStripMenuItem.Image = global::HRM.Properties.Resources.addUngVien;
            //this.thêmNhânViênToolStripMenuItem.Name = "thêmNhânViênToolStripMenuItem";
            //this.thêmNhânViênToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            //this.thêmNhânViênToolStripMenuItem.Tag = "SF201";
            //this.thêmNhânViênToolStripMenuItem.Text = "Nhân viên tuyển thẳng";
            //this.thêmNhânViênToolStripMenuItem.Click += new System.EventHandler(this.mnuNhanVien_ThemNhanVien_Click);
            //// 
            //// quyếtĐịnhToolStripMenuItem
            //// 
            //this.quyếtĐịnhToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.toolStripMenuItem15,
            //this.bổNhiệmToolStripMenuItem1});
            //this.quyếtĐịnhToolStripMenuItem.Image = global::HRM.Properties.Resources.quanlyquyetdinh;
            //this.quyếtĐịnhToolStripMenuItem.Name = "quyếtĐịnhToolStripMenuItem";
            //this.quyếtĐịnhToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            //this.quyếtĐịnhToolStripMenuItem.Text = "Quản lý quyết định";
            //// 
            //// toolStripMenuItem15
            //// 
            //this.toolStripMenuItem15.Image = global::HRM.Properties.Resources.bonhiem;
            //this.toolStripMenuItem15.ImageTransparentColor = System.Drawing.Color.Transparent;
            //this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            //this.toolStripMenuItem15.Size = new System.Drawing.Size(151, 22);
            //this.toolStripMenuItem15.Tag = "SF213";
            //this.toolStripMenuItem15.Text = "Bổ nhiệm";
            //this.toolStripMenuItem15.Click += new System.EventHandler(this.mnuNhanVien_QuyetDinhBoNhiem_Click);
            //// 
            //// bổNhiệmToolStripMenuItem1
            //// 
            //this.bổNhiệmToolStripMenuItem1.Image = global::HRM.Properties.Resources.decision;
            //this.bổNhiệmToolStripMenuItem1.Name = "bổNhiệmToolStripMenuItem1";
            //this.bổNhiệmToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            //this.bổNhiệmToolStripMenuItem1.Tag = "SF210";
            //this.bổNhiệmToolStripMenuItem1.Text = "Các loại QĐ";
            //this.bổNhiệmToolStripMenuItem1.Click += new System.EventHandler(this.mnuNhanVien_QuanLyQuyetDinh_Click);
            //// 
            //// hợpĐồngToolStripMenuItem
            //// 
            //this.hợpĐồngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.thửViệcToolStripMenuItem1,
            //this.chínhThứcToolStripMenuItem});
            //this.hợpĐồngToolStripMenuItem.Image = global::HRM.Properties.Resources.HopDong;
            //this.hợpĐồngToolStripMenuItem.Name = "hợpĐồngToolStripMenuItem";
            //this.hợpĐồngToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            //this.hợpĐồngToolStripMenuItem.Text = "Hợp đồng";
            //// 
            //// thửViệcToolStripMenuItem1
            //// 
            //this.thửViệcToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("thửViệcToolStripMenuItem1.Image")));
            //this.thửViệcToolStripMenuItem1.Name = "thửViệcToolStripMenuItem1";
            //this.thửViệcToolStripMenuItem1.Size = new System.Drawing.Size(143, 22);
            //this.thửViệcToolStripMenuItem1.Tag = "SF204";
            //this.thửViệcToolStripMenuItem1.Text = "Thử việc";
            //this.thửViệcToolStripMenuItem1.Click += new System.EventHandler(this.mnuNhanVien_HopDongLaoDongThuViec_Click);
            //// 
            //// chínhThứcToolStripMenuItem
            //// 
            //this.chínhThứcToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chínhThứcToolStripMenuItem.Image")));
            //this.chínhThứcToolStripMenuItem.Name = "chínhThứcToolStripMenuItem";
            //this.chínhThứcToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            //this.chínhThứcToolStripMenuItem.Tag = "SF211";
            //this.chínhThứcToolStripMenuItem.Text = "Chính thức";
            //this.chínhThứcToolStripMenuItem.Click += new System.EventHandler(this.mnuNhanVien_HopDongLaoDongChinhThuc_Click);
            //// 
            //// toolStripMenuItem11
            //// 
            //this.toolStripMenuItem11.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.chấmCôngToolStripMenuItem,
            //this.tínhLươngToolStripMenuItem});
            //this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            //this.toolStripMenuItem11.Size = new System.Drawing.Size(166, 21);
            //this.toolStripMenuItem11.Text = "Chấm công_Tính lương";
            //// 
            //// chấmCôngToolStripMenuItem
            //// 
            //this.chấmCôngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.toolStripMenuItem14,
            //this.toolStripMenuItem16,
            //this.toolStripMenuItem12,
            //this.tổngHợpCôngToolStripMenuItem,
            //this.traCứuNgàyCôngToolStripMenuItem});
            //this.chấmCôngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("chấmCôngToolStripMenuItem.Image")));
            //this.chấmCôngToolStripMenuItem.Name = "chấmCôngToolStripMenuItem";
            //this.chấmCôngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            //this.chấmCôngToolStripMenuItem.Text = "Chấm công";
            //// 
            //// toolStripMenuItem14
            //// 
            //this.toolStripMenuItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem14.Image")));
            //this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            //this.toolStripMenuItem14.Size = new System.Drawing.Size(213, 22);
            //this.toolStripMenuItem14.Tag = "SF300";
            //this.toolStripMenuItem14.Text = "Chấm công mã vạch";
            //this.toolStripMenuItem14.Click += new System.EventHandler(this.mnuChamCongTinhLuong_ChamCongMaVachRa_Click);
            //// 
            //// toolStripMenuItem16
            //// 
            //this.toolStripMenuItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem16.Image")));
            //this.toolStripMenuItem16.Name = "toolStripMenuItem16";
            //this.toolStripMenuItem16.Size = new System.Drawing.Size(213, 22);
            //this.toolStripMenuItem16.Tag = "SF305";
            //this.toolStripMenuItem16.Text = "Đỗ dữ liệu chấm công";
            //this.toolStripMenuItem16.Click += new System.EventHandler(this.mnuChamCongTinhLuong_DoDuLieuChamCong_Click);
            //// 
            //// toolStripMenuItem12
            //// 
            //this.toolStripMenuItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem12.Image")));
            //this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            //this.toolStripMenuItem12.Size = new System.Drawing.Size(213, 22);
            //this.toolStripMenuItem12.Tag = "SF306";
            //this.toolStripMenuItem12.Text = "Chấm công thủ công";
            //this.toolStripMenuItem12.Click += new System.EventHandler(this.mnuChamCongTinhLuong_ChamCongBangTay_Click);
            //// 
            //// tổngHợpCôngToolStripMenuItem
            //// 
            //this.tổngHợpCôngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tổngHợpCôngToolStripMenuItem.Image")));
            //this.tổngHợpCôngToolStripMenuItem.Name = "tổngHợpCôngToolStripMenuItem";
            //this.tổngHợpCôngToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            //this.tổngHợpCôngToolStripMenuItem.Tag = "SF301";
            //this.tổngHợpCôngToolStripMenuItem.Text = "Tổng hợp ngày công";
            //this.tổngHợpCôngToolStripMenuItem.Click += new System.EventHandler(this.mnuChamCongTinhLuong_TongHopChamCong_Click);
            //// 
            //// traCứuNgàyCôngToolStripMenuItem
            //// 
            //this.traCứuNgàyCôngToolStripMenuItem.Image = global::HRM.Properties.Resources.search;
            //this.traCứuNgàyCôngToolStripMenuItem.Name = "traCứuNgàyCôngToolStripMenuItem";
            //this.traCứuNgàyCôngToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            //this.traCứuNgàyCôngToolStripMenuItem.Tag = "SF311";
            //this.traCứuNgàyCôngToolStripMenuItem.Text = "Tra cứu ngày công";
            //this.traCứuNgàyCôngToolStripMenuItem.Click += new System.EventHandler(this.mnuChamCongTinhLuong_TraCuuChamCongNhanVien_Click);
            //// 
            //// tínhLươngToolStripMenuItem
            //// 
            //this.tínhLươngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.toolStripMenuItem17,
            //this.toolStripMenuItem13,
            //this.bảngLươngThángToolStripMenuItem,
            //this.toolStripMenuItem18,
            //this.lươngThôiViệcToolStripMenuItem});
            //this.tínhLươngToolStripMenuItem.Image = global::HRM.Properties.Resources.process1;
            //this.tínhLươngToolStripMenuItem.Name = "tínhLươngToolStripMenuItem";
            //this.tínhLươngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            //this.tínhLươngToolStripMenuItem.Text = "Tính lương";
            //// 
            //// toolStripMenuItem17
            //// 
            //this.toolStripMenuItem17.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem17.Image")));
            //this.toolStripMenuItem17.Name = "toolStripMenuItem17";
            //this.toolStripMenuItem17.Size = new System.Drawing.Size(183, 22);
            //this.toolStripMenuItem17.Tag = "SF308";
            //this.toolStripMenuItem17.Text = "Tạm ứng";
            //this.toolStripMenuItem17.Click += new System.EventHandler(this.mnuChamCongTinhLuong_DanhMucTamUng_Click);
            //// 
            //// toolStripMenuItem13
            //// 
            //this.toolStripMenuItem13.Image = global::HRM.Properties.Resources.Process;
            //this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            //this.toolStripMenuItem13.Size = new System.Drawing.Size(183, 22);
            //this.toolStripMenuItem13.Tag = "SF302";
            //this.toolStripMenuItem13.Text = "Tính lương tháng";
            //this.toolStripMenuItem13.Click += new System.EventHandler(this.mnuChamCongTinhLuong_LuongTheoThang_Click);
            //// 
            //// bảngLươngThángToolStripMenuItem
            //// 
            //this.bảngLươngThángToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("bảngLươngThángToolStripMenuItem.Image")));
            //this.bảngLươngThángToolStripMenuItem.Name = "bảngLươngThángToolStripMenuItem";
            //this.bảngLươngThángToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            //this.bảngLươngThángToolStripMenuItem.Tag = "SF304";
            //this.bảngLươngThángToolStripMenuItem.Text = "Lương thôi việc";
            //this.bảngLươngThángToolStripMenuItem.Click += new System.EventHandler(this.mnuChamCongTinhLuong_LuongChoNhanVienThoiViec_Click);
            //// 
            //// toolStripMenuItem18
            //// 
            //this.toolStripMenuItem18.Image = global::HRM.Properties.Resources.search;
            //this.toolStripMenuItem18.Name = "toolStripMenuItem18";
            //this.toolStripMenuItem18.Size = new System.Drawing.Size(183, 22);
            //this.toolStripMenuItem18.Tag = "SF310";
            //this.toolStripMenuItem18.Text = "Tra cứu lương";
            //this.toolStripMenuItem18.Click += new System.EventHandler(this.mnuChamCongTinhLuong_TraCuuLuong_Click);
            //// 
            //// lươngThôiViệcToolStripMenuItem
            //// 
            //this.lươngThôiViệcToolStripMenuItem.Image = global::HRM.Properties.Resources.PhieuYeuCau;
            //this.lươngThôiViệcToolStripMenuItem.Name = "lươngThôiViệcToolStripMenuItem";
            //this.lươngThôiViệcToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            //this.lươngThôiViệcToolStripMenuItem.Tag = "SF303";
            //this.lươngThôiViệcToolStripMenuItem.Text = "Phiếu lương";
            //this.lươngThôiViệcToolStripMenuItem.Click += new System.EventHandler(this.mnuChamCongTinhLuong_PhieuLuong_Click);
            //// 
            //// danhMụcToolStripMenuItem
            //// 
            //this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.thôngTinTổChứcToolStripMenuItem,
            //this.toolStripMenuItem4,
            //this.toolStripMenuItem2,
            //this.toolStripMenuItem1,
            //this.toolStripMenuItem3,
            //this.toolStripSeparator26,
            //this.kTKLToolStripMenuItem,
            //this.biểuMẫuToolStripMenuItem});
            //this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            //this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(84, 21);
            //this.danhMụcToolStripMenuItem.Text = "Danh mục";
            //// 
            //// thôngTinTổChứcToolStripMenuItem
            //// 
            //this.thôngTinTổChứcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.mnuDM_ToChuc_PhongBan});
            //this.thôngTinTổChứcToolStripMenuItem.Image = global::HRM.Properties.Resources.PhongBan;
            //this.thôngTinTổChứcToolStripMenuItem.Name = "thôngTinTổChứcToolStripMenuItem";
            //this.thôngTinTổChứcToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            //this.thôngTinTổChứcToolStripMenuItem.Text = "Tổ chức";
            //// 
            //// mnuDM_ToChuc_PhongBan
            //// 
            //this.mnuDM_ToChuc_PhongBan.Image = global::HRM.Properties.Resources.Nha;
            //this.mnuDM_ToChuc_PhongBan.Name = "mnuDM_ToChuc_PhongBan";
            //this.mnuDM_ToChuc_PhongBan.Size = new System.Drawing.Size(152, 22);
            //this.mnuDM_ToChuc_PhongBan.Tag = "SF001";
            //this.mnuDM_ToChuc_PhongBan.Text = "Phòng ban";
            //this.mnuDM_ToChuc_PhongBan.Click += new System.EventHandler(this.mnuDM_ToChuc_PhongBan_Click);
            //// 
            //// toolStripMenuItem4
            //// 
            //this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.chuyênNgànhToolStripMenuItem,
            //this.dânTộToolStripMenuItem,
            //this.ngoạiNgữToolStripMenuItem,
            //this.quanHệToolStripMenuItem,
            //this.hônNhânToolStripMenuItem,
            //this.tônGiáoToolStripMenuItem,
            //this.tinHọcToolStripMenuItem});
            //this.toolStripMenuItem4.Image = global::HRM.Properties.Resources.Person;
            //this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            //this.toolStripMenuItem4.Size = new System.Drawing.Size(158, 22);
            //this.toolStripMenuItem4.Text = "Cá nhân";
            //// 
            //// chuyênNgànhToolStripMenuItem
            //// 
            //this.chuyênNgànhToolStripMenuItem.Image = global::HRM.Properties.Resources.ChuyenNganh;
            //this.chuyênNgànhToolStripMenuItem.Name = "chuyênNgànhToolStripMenuItem";
            //this.chuyênNgànhToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.chuyênNgànhToolStripMenuItem.Tag = "SF002";
            //this.chuyênNgànhToolStripMenuItem.Text = "Chuyên ngành";
            //this.chuyênNgànhToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_ChuyenNganh_Click);
            //// 
            //// dânTộToolStripMenuItem
            //// 
            //this.dânTộToolStripMenuItem.Image = global::HRM.Properties.Resources.Canhan;
            //this.dânTộToolStripMenuItem.Name = "dânTộToolStripMenuItem";
            //this.dânTộToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.dânTộToolStripMenuItem.Tag = "SF003";
            //this.dânTộToolStripMenuItem.Text = "Dân tộc";
            //this.dânTộToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_DanToc_Click);
            //// 
            //// ngoạiNgữToolStripMenuItem
            //// 
            //this.ngoạiNgữToolStripMenuItem.Image = global::HRM.Properties.Resources.NgoaiNgu;
            //this.ngoạiNgữToolStripMenuItem.Name = "ngoạiNgữToolStripMenuItem";
            //this.ngoạiNgữToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.ngoạiNgữToolStripMenuItem.Tag = "SF004";
            //this.ngoạiNgữToolStripMenuItem.Text = "Ngoại ngữ";
            //this.ngoạiNgữToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_NgoaiNgu_Click);
            //// 
            //// quanHệToolStripMenuItem
            //// 
            //this.quanHệToolStripMenuItem.Image = global::HRM.Properties.Resources.quanHe;
            //this.quanHệToolStripMenuItem.Name = "quanHệToolStripMenuItem";
            //this.quanHệToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.quanHệToolStripMenuItem.Tag = "SF005";
            //this.quanHệToolStripMenuItem.Text = "Quan hệ";
            //this.quanHệToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_QuanHe_Click);
            //// 
            //// hônNhânToolStripMenuItem
            //// 
            //this.hônNhânToolStripMenuItem.Image = global::HRM.Properties.Resources.weding;
            //this.hônNhânToolStripMenuItem.Name = "hônNhânToolStripMenuItem";
            //this.hônNhânToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.hônNhânToolStripMenuItem.Tag = "SF006";
            //this.hônNhânToolStripMenuItem.Text = "Hôn nhân";
            //this.hônNhânToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_HonNhan_Click);
            //// 
            //// tônGiáoToolStripMenuItem
            //// 
            //this.tônGiáoToolStripMenuItem.Image = global::HRM.Properties.Resources.TonGiao;
            //this.tônGiáoToolStripMenuItem.Name = "tônGiáoToolStripMenuItem";
            //this.tônGiáoToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.tônGiáoToolStripMenuItem.Tag = "SF007";
            //this.tônGiáoToolStripMenuItem.Text = "Tôn giáo";
            //this.tônGiáoToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_TonGiao_Click);
            //// 
            //// tinHọcToolStripMenuItem
            //// 
            //this.tinHọcToolStripMenuItem.Image = global::HRM.Properties.Resources.ViTinh;
            //this.tinHọcToolStripMenuItem.Name = "tinHọcToolStripMenuItem";
            //this.tinHọcToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            //this.tinHọcToolStripMenuItem.Tag = "SF008";
            //this.tinHọcToolStripMenuItem.Text = "Tin học";
            //this.tinHọcToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_TinHoc_Click);
            //// 
            //// toolStripMenuItem2
            //// 
            //this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            //this.toolStripMenuItem2.Size = new System.Drawing.Size(155, 6);
            //// 
            //// toolStripMenuItem1
            //// 
            //this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.CapTuyenDungToolStripMenuItem,
            //this.chứcDanhToolStripMenuItem,
            //this.toolStripMenuItem9,
            //this.lýDoToolStripMenuItem});
            //this.toolStripMenuItem1.Image = global::HRM.Properties.Resources.TuyenDung;
            //this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            //this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 22);
            //this.toolStripMenuItem1.Text = "Tuyển dụng";
            //// 
            //// CapTuyenDungToolStripMenuItem
            //// 
            //this.CapTuyenDungToolStripMenuItem.Image = global::HRM.Properties.Resources.ChucDanh;
            //this.CapTuyenDungToolStripMenuItem.Name = "CapTuyenDungToolStripMenuItem";
            //this.CapTuyenDungToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            //this.CapTuyenDungToolStripMenuItem.Tag = "SF009";
            //this.CapTuyenDungToolStripMenuItem.Text = "Cấp tuyển dụng";
            //this.CapTuyenDungToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_CapTuyenDung_Click);
            //// 
            //// chứcDanhToolStripMenuItem
            //// 
            //this.chứcDanhToolStripMenuItem.Image = global::HRM.Properties.Resources.ChucDanh1;
            //this.chứcDanhToolStripMenuItem.Name = "chứcDanhToolStripMenuItem";
            //this.chứcDanhToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            //this.chứcDanhToolStripMenuItem.Tag = "SF010";
            //this.chứcDanhToolStripMenuItem.Text = "Chức danh";
            //this.chứcDanhToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_ChucDanh_Click);
            //// 
            //// toolStripMenuItem9
            //// 
            //this.toolStripMenuItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolStripMenuItem9.Image")));
            //this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            //this.toolStripMenuItem9.Size = new System.Drawing.Size(192, 22);
            //this.toolStripMenuItem9.Tag = "SF016";
            //this.toolStripMenuItem9.Text = "Trình độ";
            //this.toolStripMenuItem9.Click += new System.EventHandler(this.mnuDM_TuyenDung_TrinhDo_Click);
            //// 
            //// lýDoToolStripMenuItem
            //// 
            //this.lýDoToolStripMenuItem.Image = global::HRM.Properties.Resources.LyDo;
            //this.lýDoToolStripMenuItem.Name = "lýDoToolStripMenuItem";
            //this.lýDoToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            //this.lýDoToolStripMenuItem.Tag = "SF011";
            //this.lýDoToolStripMenuItem.Text = "Lý do";
            //this.lýDoToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_LyDo_Click);
            //// 
            //// toolStripMenuItem3
            //// 
            //this.toolStripMenuItem3.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.mnuDM_TinhHuyen_Tinh});
            //this.toolStripMenuItem3.Image = global::HRM.Properties.Resources.Tinh;
            //this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            //this.toolStripMenuItem3.Size = new System.Drawing.Size(158, 22);
            //this.toolStripMenuItem3.Text = "Tỉnh - Huyện";
            //// 
            //// mnuDM_TinhHuyen_Tinh
            //// 
            //this.mnuDM_TinhHuyen_Tinh.Image = global::HRM.Properties.Resources.Huyen;
            //this.mnuDM_TinhHuyen_Tinh.Name = "mnuDM_TinhHuyen_Tinh";
            //this.mnuDM_TinhHuyen_Tinh.Size = new System.Drawing.Size(186, 22);
            //this.mnuDM_TinhHuyen_Tinh.Tag = "SF013";
            //this.mnuDM_TinhHuyen_Tinh.Text = "Tỉnh - Thành phố";
            //this.mnuDM_TinhHuyen_Tinh.Click += new System.EventHandler(this.mnuDM_TuyenDung_TinhThanh_Click);
            //// 
            //// toolStripSeparator26
            //// 
            //this.toolStripSeparator26.Name = "toolStripSeparator26";
            //this.toolStripSeparator26.Size = new System.Drawing.Size(155, 6);
            //// 
            //// kTKLToolStripMenuItem
            //// 
            //this.kTKLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.khenThưởngToolStripMenuItem});
            //this.kTKLToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("kTKLToolStripMenuItem.Image")));
            //this.kTKLToolStripMenuItem.Name = "kTKLToolStripMenuItem";
            //this.kTKLToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            //this.kTKLToolStripMenuItem.Text = "Nhân sự";
            //// 
            //// khenThưởngToolStripMenuItem
            //// 
            //this.khenThưởngToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("khenThưởngToolStripMenuItem.Image")));
            //this.khenThưởngToolStripMenuItem.Name = "khenThưởngToolStripMenuItem";
            //this.khenThưởngToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            //this.khenThưởngToolStripMenuItem.Tag = "SF017";
            //this.khenThưởngToolStripMenuItem.Text = "Thưởng lễ";
            //this.khenThưởngToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_TuyenDung_ThuongLe_Click);
            //// 
            //// biểuMẫuToolStripMenuItem
            //// 
            //this.biểuMẫuToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("biểuMẫuToolStripMenuItem.Image")));
            //this.biểuMẫuToolStripMenuItem.Name = "biểuMẫuToolStripMenuItem";
            //this.biểuMẫuToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            //this.biểuMẫuToolStripMenuItem.Tag = "SF019";
            //this.biểuMẫuToolStripMenuItem.Text = "Biểu mẫu";
            //this.biểuMẫuToolStripMenuItem.Click += new System.EventHandler(this.mnuDM_BieuMau_Click);
            //// 
            //// trợGiúpToolStripMenuItem
            //// 
            //this.trợGiúpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.mnuTroGiup_Help,
            //this.toolStripSeparator9,
            //this.mnuTroGiup_TacGia});
            //this.trợGiúpToolStripMenuItem.Name = "trợGiúpToolStripMenuItem";
            //this.trợGiúpToolStripMenuItem.Size = new System.Drawing.Size(73, 21);
            //this.trợGiúpToolStripMenuItem.Text = "Trợ giúp";
            //// 
            //// mnuTroGiup_Help
            //// 
            //this.mnuTroGiup_Help.Image = global::HRM.Properties.Resources.Help;
            //this.mnuTroGiup_Help.Name = "mnuTroGiup_Help";
            //this.mnuTroGiup_Help.Size = new System.Drawing.Size(201, 22);
            //this.mnuTroGiup_Help.Text = "Hướng dẫn sử dụng";
            //this.mnuTroGiup_Help.Click += new System.EventHandler(this.mnuTroGiup_Help_Click);
            //// 
            //// toolStripSeparator9
            //// 
            //this.toolStripSeparator9.Name = "toolStripSeparator9";
            //this.toolStripSeparator9.Size = new System.Drawing.Size(198, 6);
            //// 
            //// mnuTroGiup_TacGia
            //// 
            //this.mnuTroGiup_TacGia.Image = global::HRM.Properties.Resources.tacGia;
            //this.mnuTroGiup_TacGia.Name = "mnuTroGiup_TacGia";
            //this.mnuTroGiup_TacGia.Size = new System.Drawing.Size(201, 22);
            //this.mnuTroGiup_TacGia.Text = "Tác giả";
            //this.mnuTroGiup_TacGia.Click += new System.EventHandler(this.mnuHeThongg_About_Click);
            //// 
            //// toolStripEx1
            //// 
            //this.toolStripEx1.ForeColor = System.Drawing.Color.MidnightBlue;
            //this.toolStripEx1.Image = null;
            //this.toolStripEx1.Location = new System.Drawing.Point(0, 25);
            //this.toolStripEx1.Name = "toolStripEx1";
            //this.toolStripEx1.ShowCaption = false;
            //this.toolStripEx1.ShowLauncher = true;
            //this.toolStripEx1.Size = new System.Drawing.Size(913, 25);
            //this.toolStripEx1.TabIndex = 10;
            //this.toolStripEx1.Text = "toolStripEx1";
            //// 
            //// statusStripMain
            //// 
            //this.statusStripMain.Dock = Syncfusion.Windows.Forms.Tools.DockStyleEx.Bottom;
            //this.statusStripMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            //this.statusStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            //this.toolStripStatusLabel1,
            //this.statusStripLabelUser,
            //this.statusStripLabelUserName});
            //this.statusStripMain.Location = new System.Drawing.Point(0, 506);
            //this.statusStripMain.Name = "statusStripMain";
            //this.statusStripMain.Size = new System.Drawing.Size(913, 23);
            //this.statusStripMain.TabIndex = 12;
            //this.statusStripMain.Text = "statusStripEx1";
            //// 
            //// toolStripStatusLabel1
            //// 
            //this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            //this.toolStripStatusLabel1.Size = new System.Drawing.Size(80, 17);
            //this.toolStripStatusLabel1.Text = "12/05/2011";
            //// 
            //// statusStripLabelUser
            //// 
            //this.statusStripLabelUser.BackColor = System.Drawing.Color.Blue;
            //this.statusStripLabelUser.ForeColor = System.Drawing.Color.Blue;
            //this.statusStripLabelUser.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            //this.statusStripLabelUser.Name = "statusStripLabelUser";
            //this.statusStripLabelUser.Size = new System.Drawing.Size(155, 17);
            //this.statusStripLabelUser.Text = "Chào mừng người dùng";
            //// 
            //// statusStripLabelUserName
            //// 
            //this.statusStripLabelUserName.ForeColor = System.Drawing.Color.Blue;
            //this.statusStripLabelUserName.Margin = new System.Windows.Forms.Padding(0, 4, 0, 2);
            //this.statusStripLabelUserName.Name = "statusStripLabelUserName";
            //this.statusStripLabelUserName.Size = new System.Drawing.Size(46, 17);
            //this.statusStripLabelUserName.Text = "admin";
        }

        /// <summary>
        /// Shows all menu.
        /// </summary>
        /// <param name="mnuItems">The mnu items.</param>
        private void ShowAllMenu(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    ShowAllMenu(((ToolStripMenuItem)(menu)).DropDownItems);
                }
                else
                {
                    menu.Enabled = true;
                    menu.Visible = true;
                }
            }
        }

        /// <summary>
        /// Phans the quyen menu.
        /// </summary>
        private void PhanQuyenMenu()
        {
            QL_PhanQuyenBLL busQuyen = new QL_PhanQuyenBLL();

            QL_NguoiDungNhomNguoiDungBLL busNguoiDungNhom = new QL_NguoiDungNhomNguoiDungBLL();

            List<int> listNhom = busNguoiDungNhom.GetNhomByNguoiDung(LayerCommon.CurrentUser.UserID);

            List<QL_PhanQuyen> listQuyen = busQuyen.GetQuyenByNhomNguoiDung(listNhom);

            MngForms.ListQuyen = listQuyen;

            foreach (QL_PhanQuyen quyen in listQuyen)
            {
                FindMenuPhanQuyen(this.mnuMain.Items, quyen.MaManHinh, quyen.CoQuyen);
            }

            HideToolStripSeparator(this.mnuMain.Items);

            mnuHeThong_Thoat.Enabled = mnuHeThong_Thoat.Visible = true;
        }

        /// <summary>
        /// Finds the menu phan quyen.
        /// </summary>
        /// <param name="mnuItems">The mnu items.</param>
        /// <param name="pScreenName">Name of the p screen.</param>
        /// <param name="pEnable">if set to <c>true</c> [p enable].</param>
        private void FindMenuPhanQuyen(ToolStripItemCollection mnuItems, string pScreenName, bool pEnable)
        {
            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    FindMenuPhanQuyen(((ToolStripMenuItem)(menu)).DropDownItems, pScreenName, pEnable);

                    menu.Enabled = CheckAllMenuChildVisible(((ToolStripMenuItem)(menu)).DropDownItems);
                    menu.Visible = menu.Enabled;
                }
                else if (string.Equals(pScreenName, menu.Tag))
                {
                    menu.Enabled = pEnable;
                    menu.Visible = pEnable;
                }
            }
        }

        /// <summary>
        /// Checks all menu chid visible.
        /// </summary>
        /// <param name="mnuItems">The mnu items.</param>
        /// <returns></returns>
        private bool CheckAllMenuChildVisible(ToolStripItemCollection mnuItems)
        {
            foreach (ToolStripItem menuItem in mnuItems)
            {
                if (menuItem is ToolStripMenuItem && menuItem.Enabled)
                {
                    return true;
                }
                else if (menuItem is ToolStripSeparator)
                {
                    continue;
                }
            }

            return false;
        }

        /// <summary>
        /// Hides the tool strip separator.
        /// </summary>
        /// <param name="mnuItems">The mnu items.</param>
        ///  22/08/11
        /// PC
        private void HideToolStripSeparator(ToolStripItemCollection mnuItems)
        {
            bool FlagHiden = false;

            foreach (ToolStripItem menu in mnuItems)
            {
                if (menu is ToolStripMenuItem && ((ToolStripMenuItem)(menu)).DropDownItems.Count > 0)
                {
                    FlagHiden = false;
                    HideToolStripSeparator(((ToolStripMenuItem)(menu)).DropDownItems);
                }

                if (menu is ToolStripMenuItem && menu.Enabled)
                {
                    FlagHiden = true;
                    continue;
                }

                if (menu is ToolStripSeparator)
                {
                    menu.Visible = FlagHiden;
                    FlagHiden = false;
                    ToolStripSeparator current = menu as ToolStripSeparator;

                    ToolStripItem menuTemp = menu;
                    while (true)
                    {
                        if ((menuTemp is ToolStripSeparator) || (mnuItems.IndexOf(menuTemp) + 1 > mnuItems.Count))
                        {
                            break;
                        }

                        if (!menuTemp.Visible)
                        {
                            menuTemp = mnuItems[mnuItems.IndexOf(menuTemp) + 1];
                            continue;
                        }

                        if (menuTemp.Visible && !(menuTemp is ToolStripSeparator))
                        {
                            current.Visible = FlagHiden;
                            FlagHiden = false;
                            break;
                        }

                        menuTemp = mnuItems[mnuItems.IndexOf(menuTemp) + 1];
                    }
                }
            }
        }

        #region ---- Timer ----

        /// <summary>
        /// Handles the Tick event of the timerMain control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void timerMain_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = CacheData.Context.GetSystemDate().ToString("dd/MM/yyyy HH:mm:ss");
        }

        #endregion

        #region ---- Menu ----

        #region ---- Danh Muc ----

        #region ---- To Chuc ----

        /// <summary>
        /// Handles the Click event of the mnuDM_ToChuc_PhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_ToChuc_PhongBan_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucPhongBan);
        }

        #endregion

        #region ---- Ca Nhan  ----

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_ChuyenNganh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_ChuyenNganh_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucChuyenNganh);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_DanToc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_DanToc_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucDanToc);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_NgoaiNgu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_NgoaiNgu_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucNgoaiNgu);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_QuanHe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_QuanHe_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucQuanHe);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_HonNhan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_HonNhan_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucHonNhan);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_TonGiao control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_TonGiao_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucTonGiao);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_TinHoc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_TinHoc_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucTinHoc);
        }

        #endregion

        #region ---- Tuyen Dung ----

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_ChuyenNganh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_CapTuyenDung_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucCapTuyenDung);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_ChucDanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_ChucDanh_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucChucDanh);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_LyDo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_LyDo_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucLyDo);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_YeuCauCongViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_YeuCauCongViec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucYeuCauCongViec);
        }

        private void mnuDM_TuyenDung_TrinhDo_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucTrinhDo);
        }

        #endregion

        #region ---- Tinh huyen ----

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_TinhThanh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_TinhThanh_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucTinhThanh);
        }

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_QuanHuyen control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_QuanHuyen_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucQuanHuyen);
        }

        #endregion

        #region ---- Luong  ----

        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_PhuCap control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_PhuCap_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucPhuCap);
        }
        /// <summary>
        /// Handles the Click event of the mnuDM_TuyenDung_ThuongLe control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuDM_TuyenDung_ThuongLe_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucThuongLe);
        }
        /// <summary>
        /// Handles the Click event of the mnuDM_BieuMau control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  21/08/11
        /// PC
        private void mnuDM_BieuMau_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucBieuMau);
        }

        #endregion

        #endregion

        #region ---- Tuyen Dung ----

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_LapKeHoach control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_LapKeHoach_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.KeHoachTuyenDung);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_ChiTietLapKeHoach control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_ChiTietLapKeHoach_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.ChiTietKeHoachTD);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_XetDuyetKeHoach control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_XetDuyetKeHoach_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.XetDuyetKHTD);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_LapPYCTheoKH control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_LapPYCTheoKH_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.LapPYCTheoKH);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_LapPYCTuDo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_LapPYCTuDo_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.LapPYCTuDo);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_XetDuyetPYC control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_XetDuyetPYC_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.XetDuyetPYC);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_ThongBaoTuyenDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_ThongBaoTuyenDung_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.ThongBaoTuyenDung);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_HoSoUngVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_HoSoUngVien_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.NhapHoSoUngVien);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_LapKeHoachThuViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_LapKeHoachThuViec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.KeHoachThuViec);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_ChiTietKeHoachThuViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_ChiTietKeHoachThuViec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.ChiTietKeHoachThuViec);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_DanhGiaThuViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_DanhGiaThuViec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhGiaThuViec);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_KetThuVQuaiec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_KetThuVQuaiec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.KetQuaThuViec);
        }

        /// <summary>
        /// Handles the Click event of the mnuTuyenDung_LamHopDong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuTuyenDung_LamHopDong_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.LamHopDong);
        }

        #endregion

        #region ---- NhanVien ----

        /// <summary>
        /// Handles the Click event of the mnuNhanVien_TraCuuNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuNhanVien_TraCuuNhanVien_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.TraCuuHoSoNV);
        }

        /// <summary>
        /// Handles the Click event of the mnuNhanVien_ThemNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuNhanVien_ThemNhanVien_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.ThemNhanVien);
        }

        /// <summary>
        /// Handles the Click event of the mnuNhanVien_QuyetDinhBoNhiem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuNhanVien_QuyetDinhBoNhiem_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.QuyetDinhBoNhiem);
        }

        /// <summary>
        /// Handles the Click event of the mnuNhanVien_QuanLyQuyetDinh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuNhanVien_QuanLyQuyetDinh_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.CacLoaiQD);
        }

        /// <summary>
        /// Handles the Click event of the mnuNhanVien_HopDongLaoDongThuViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuNhanVien_HopDongLaoDongThuViec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.HopDongLaoDongThuViec);
        }
        /// <summary>
        /// Handles the Click event of the mnuNhanVien_HopDongLaoDongChinhThuc control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuNhanVien_HopDongLaoDongChinhThuc_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.HopDongChinhThuc);
        } 
        #endregion

        #region ---- ChamCongLuong ----

        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_ChamCongMaVachRa control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_ChamCongMaVachRa_Click(object sender, EventArgs e)
        {
            MngForms.ShowDialog(new SF300());
        }
        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_DoDuLieuChamCong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_DoDuLieuChamCong_Click(object sender, EventArgs e)
        {
            MngForms.ShowDialog(new SF305());
        }

        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_ChamCongBangTay control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_ChamCongBangTay_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.ChamCongBangTay);
        }
        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_TongHopChamCong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_TongHopChamCong_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.TongHopChamCongPhongBan);
        }
        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_TraCuuChamCongNhanVien control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_TraCuuChamCongNhanVien_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.TraCuuChamCongNhanVien);
        }
        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_DanhMucTamUng control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_DanhMucTamUng_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucTamUng);
        }
        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_LuongTheoThang control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_LuongTheoThang_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.TinhLuongTheoThang);
        }
        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_TraCuuLuong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_TraCuuLuong_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.TraCuuLuong);
        }

        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_PhieuLuong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_PhieuLuong_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.PhieuLuong);
        }

        /// <summary>
        /// Handles the Click event of the mnuChamCongTinhLuong_LuongChoNhanVienThoiViec control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuChamCongTinhLuong_LuongChoNhanVienThoiViec_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.LuongChoNVThoiViec);
        }


        /// <summary>
        /// Handles the Click event of the mnuHeThongg_About control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  05/07/11
        /// PC
        private void mnuHeThongg_About_Click(object sender, EventArgs e)
        {
            MngForms.ShowDialog(new Author());
        } 


        #endregion

        #region ---- He thong ----

        /// <summary>
        /// Handles the Click event of the mnuHeThong_NguoiDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuHeThong_NguoiDung_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucNguoiDung);
        }
        /// <summary>
        /// Handles the Click event of the mnuHeThong_NhomNguoiDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuHeThong_NhomNguoiDung_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucNhomNguoiDung);
        }
        /// <summary>
        /// Handles the Click event of the mnuHeThong_NguoiDungNhomNguoiDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuHeThong_NguoiDungNhomNguoiDung_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.ThemNguoiDungVaoNhom);
        }
        /// <summary>
        /// Handles the Click event of the mnuHeThong_PhanQuyenNguoiDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuHeThong_PhanQuyenNguoiDung_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.PhanQuyenNguoiDung);
        }
        /// <summary>
        /// Handles the Click event of the mnuHeThong_ThayDoiMatKhau control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuHeThong_ThayDoiMatKhau_Click(object sender, EventArgs e)
        {
            MngForms.ShowDialog(new HRM.Forms.ChangePwd());
        }

        /// <summary>
        /// Handles the Click event of the mnuHeThong_DanhMucManHinh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>12/06/2011</Date>
        private void mnuHeThong_DanhMucManHinh_Click(object sender, EventArgs e)
        {
            MngForms.ShowMDIChildForm(MngForms.Forms.DanhMucManHinh);
        }
        /// <summary>
        /// Handles the Click event of the mnuHeThongThoatChuongTrinh control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void mnuHeThongThoatChuongTrinh_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion

        #region ---- Form ----

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, EventArgs e)
        {
              
            if (Global.IsLoginBySupperAdmin)
            {
                this.ShowAllMenu(this.mnuMain.Items);
            }
            else
            {
                this.PhanQuyenMenu();
            }     

            MdiClient client;

            foreach (Control ctr in this.Controls)
            {
                client = ctr as MdiClient;
                if (client != null)
                {
                    client.BackColor = Color.FromArgb(238, 243, 250); // Color.White;
                    client.BackgroundImage = Properties.Resources.hinhnenchinh;
                }
            }

             #if DEBUG
                    this.ShowAllMenu(this.mnuMain.Items);
            
            #endif

            #if !DEBUG

            #endif

        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            // Khoi tam de tranh truong hop mo form dau tien cham
            base.OnShown(e);
            HRM.DanhMuc.SF001 frmTemp = new HRM.DanhMuc.SF001();
            frmTemp.MdiParent = this;
            frmTemp.Show();
            frmTemp.Close();
            frmTemp.StopLoading();
            frmTemp.Dispose();
        }

        /// <summary>
        /// Handles the FormClosed event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                QL_NguoiDung curr = _bussNguoiDung.GetCurrentUser();
                if (curr.DelFlag.HasValue && curr.DelFlag.Value == true)
                {
                    QL_NguoiDungBLL _new = new QL_NguoiDungBLL();
                    _new.Update(LayerCommon.CurrentUser.UserID, false);
                }
            }
            catch
            {

            }


            
#if DEBUG
            Application.Exit();
#endif
            Program.loginForm.Show();
        }

        #endregion


        private void mnuTroGiup_Help_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName =   Global.AppPath + Constants.CHAR_FLASH + Constants.FOLDER_TEMPLATES + Constants.CHAR_FLASH + Constants.FILE_HELP;
            proc.Start();
        }
        

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch ((int)keyData)
            {
                case (int)Keys.F1:

                    mnuTroGiup_Help.PerformClick();

                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

        }


    }
}
