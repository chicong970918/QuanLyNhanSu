using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;
namespace HRM.DataAccess.QuanLyNhanVien
{
    /// <summary>
    /// 
    /// </summary>
    public class NV_NhanVienBLL : DataAccessBase<NV_NhanVien>
    {
        /// <summary>
        /// Loads the nhan vien theo phong ban.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<NV_NhanVien> LoadNhanVienTheoPhongBan(int pIdPhongBan)
        {
            var listNhanVien = from NV in this.Context.NV_NhanViens.Where(nv=>nv.HienTaiLoaiHopDong==2)
                               from CD in this.Context.DM_ChucDanhs
                               where NV.IdChucDanh == CD.Id
                               && NV.IdPhongBan == pIdPhongBan
                               
                               select new
                               {
                                   NV.Id,
                                   NV.MaNhanVien,
                                   NV.HoDem,
                                   NV.Ten,
                                   NV.GioiTinhText,
                                   NV.NgaySinh,
                                   NV.DiaChiHienTai,
                                   NV.SoDienThoai,
                                   CD.TenChucDanh,
                                   NV.CMND,
                                   NV.DaChamDutHopDong,
                                   NV.IdDanToc,
                                   NV.DiaChiThuongTru,
                                   NV.Email,
                                   NV.GioiTinh,
                                   NV.HeSoChuyenMonHienTai,
                                   NV.HeSoLuongHienTai,
                                   NV.HienTaiChucDanh,
                                   NV.HienTaiLoaiHopDong,
                                   NV.HienTaiPhongBan,
                                   NV.HinhAnh,
                                   NV.IdChucDanh,
                                   NV.IdChuyenNganh,
                                   NV.IdPhongBan,
                                   NV.IdTinhTrangHonNhan,
                                   NV.IdTrinhDo,
                                   NV.LuongSauThuViec,
                                   NV.NgayCap,
                                   NV.NguyenQuan,
                                   NV.NoiCapCMND,
                                   NV.NoiSinh,
                                   NV.QuocTich,
                                   NV.SoHopDong,
                                   NV.IdTonGiao,
                                   NV.NgaySinhText,
                               };

            var result = listNhanVien.ToList().ConvertAll<NV_NhanVien>(NV => new NV_NhanVien()
            {
                Id = NV.Id,
                MaNhanVien = NV.MaNhanVien,
                HoDem = NV.HoDem,
                Ten = NV.Ten,
                TenChucDanh = NV.TenChucDanh,
                NgaySinhText = NV.NgaySinhText,
                NgaySinh = NV.NgaySinh,
                GioiTinhText = NV.GioiTinhText,
                DiaChiHienTai = NV.DiaChiHienTai,
                SoDienThoai = NV.SoDienThoai,
                CMND = NV.CMND,
                DaChamDutHopDong = NV.DaChamDutHopDong,
                IdDanToc = NV.IdDanToc,
                IdTonGiao=NV.IdTonGiao,
                DiaChiThuongTru = NV.DiaChiThuongTru,
                Email = NV.Email,
                GioiTinh = NV.GioiTinh,
                HeSoLuongHienTai = NV.HeSoChuyenMonHienTai,
                HeSoChuyenMonHienTai = NV.HeSoLuongHienTai,
                HienTaiChucDanh = NV.HienTaiChucDanh,
                HienTaiLoaiHopDong = NV.HienTaiLoaiHopDong,
                HienTaiPhongBan = NV.HienTaiPhongBan,
                HinhAnh = NV.HinhAnh,
                IdChucDanh = NV.IdChucDanh,
                IdChuyenNganh = NV.IdChuyenNganh,
                IdPhongBan = NV.IdPhongBan,
                IdTinhTrangHonNhan = NV.IdTinhTrangHonNhan,
                IdTrinhDo = NV.IdTrinhDo,
                LuongSauThuViec = NV.LuongSauThuViec,
                NgayCap = NV.NgayCap,
                NguyenQuan = NV.NguyenQuan,
                NoiCapCMND = NV.NoiCapCMND,
                NoiSinh = NV.NoiSinh,
            });

            return result;

        }

        /// <summary>
        /// Loads the nhan vien theo phong ban.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<NV_NhanVien> LoadNhanVienTheoPhongBanTraCuu(int pIdPhongBan,bool pValue)
        {
            var listNhanVien = from NV in this.Context.NV_NhanViens.Where(nv => nv.DaChamDutHopDong == pValue)
                               from CD in this.Context.DM_ChucDanhs
                               where NV.IdChucDanh == CD.Id
                               && NV.IdPhongBan == pIdPhongBan

                               select new
                               {
                                   NV.Id,
                                   NV.MaNhanVien,
                                   NV.HoDem,
                                   NV.Ten,
                                   NV.GioiTinhText,
                                   NV.NgaySinh,
                                   NV.DiaChiHienTai,
                                   NV.SoDienThoai,
                                   CD.TenChucDanh,
                                   NV.CMND,
                                   NV.DaChamDutHopDong,
                                   NV.IdDanToc,
                                   NV.DiaChiThuongTru,
                                   NV.Email,
                                   NV.GioiTinh,
                                   NV.HeSoChuyenMonHienTai,
                                   NV.HeSoLuongHienTai,
                                   NV.HienTaiChucDanh,
                                   NV.HienTaiLoaiHopDong,
                                   NV.HienTaiPhongBan,
                                   NV.HinhAnh,
                                   NV.IdChucDanh,
                                   NV.IdChuyenNganh,
                                   NV.IdPhongBan,
                                   NV.IdTinhTrangHonNhan,
                                   NV.IdTrinhDo,
                                   NV.LuongSauThuViec,
                                   NV.NgayCap,
                                   NV.NguyenQuan,
                                   NV.NoiCapCMND,
                                   NV.NoiSinh,
                                   NV.QuocTich,
                                   NV.SoHopDong,
                                   NV.IdTonGiao,
                                   NV.NgaySinhText,
                               };

            var result = listNhanVien.ToList().ConvertAll<NV_NhanVien>(NV => new NV_NhanVien()
            {
                Id = NV.Id,
                MaNhanVien = NV.MaNhanVien,
                HoDem = NV.HoDem,
                Ten = NV.Ten,
                TenChucDanh = NV.TenChucDanh,
                NgaySinhText = NV.NgaySinhText,
                NgaySinh = NV.NgaySinh,
                GioiTinhText = NV.GioiTinhText,
                DiaChiHienTai = NV.DiaChiHienTai,
                SoDienThoai = NV.SoDienThoai,
                CMND = NV.CMND,
                DaChamDutHopDong = NV.DaChamDutHopDong,
                IdDanToc = NV.IdDanToc,
                IdTonGiao = NV.IdTonGiao,
                DiaChiThuongTru = NV.DiaChiThuongTru,
                Email = NV.Email,
                GioiTinh = NV.GioiTinh,
                HeSoLuongHienTai = NV.HeSoChuyenMonHienTai,
                HeSoChuyenMonHienTai = NV.HeSoLuongHienTai,
                HienTaiChucDanh = NV.HienTaiChucDanh,
                HienTaiLoaiHopDong = NV.HienTaiLoaiHopDong,
                HienTaiPhongBan = NV.HienTaiPhongBan,
                HinhAnh = NV.HinhAnh,
                IdChucDanh = NV.IdChucDanh,
                IdChuyenNganh = NV.IdChuyenNganh,
                IdPhongBan = NV.IdPhongBan,
                IdTinhTrangHonNhan = NV.IdTinhTrangHonNhan,
                IdTrinhDo = NV.IdTrinhDo,
                LuongSauThuViec = NV.LuongSauThuViec,
                NgayCap = NV.NgayCap,
                NguyenQuan = NV.NguyenQuan,
                NoiCapCMND = NV.NoiCapCMND,
                NoiSinh = NV.NoiSinh,
            });

            return result;

        }

        /// <summary>
        /// Loads the nhan vien theo phong ban hop dong thu viec.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<NV_NhanVien> LoadNhanVienTheoPhongBanHopDongThuViec(int pIdPhongBan)
        {
            return this.Context.NV_NhanViens.Where(nv => nv.IdPhongBan == pIdPhongBan && (nv.HienTaiLoaiHopDong == 1 || nv.HienTaiLoaiHopDong==null)).ToList<NV_NhanVien>();
        }
        /// <summary>
        /// Loads the nhan vien theo phong ban hop dong chinh thuc.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<NV_NhanVien> LoadNhanVienTheoPhongBanHopDongChinhThuc(int pIdPhongBan)
        {
            return this.Context.NV_NhanViens.Where(nv => nv.IdPhongBan == pIdPhongBan &&( nv.HienTaiLoaiHopDong == 2 || nv.HienTaiLoaiHopDong == 1)).ToList<NV_NhanVien>();
        }

        /// <summary>
        /// Gets the nhan vienby id.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public NV_NhanVien GetNhanVienbyId(int pIdNhanVien)
        {

            NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(uv => ((NV_NhanVien)uv).Id == pIdNhanVien).FirstOrDefault();
            return nhanvien;
            //var query = from nv in nhanvien
            //            join noisinh in this.Context.DM_Tinhs on nv.NoiSinh equals noisinh.Id into tempNoiSinh
            //            from nstemp in tempNoiSinh
            //            join tongiao in this.Context.DM_TonGiaos on nv.TonGiao equals tongiao.Id into temptongiao
            //            from tongiaotemp in temptongiao
            //            join dantoc in this.Context.DM_DanTocs on nv.DanToc equals dantoc.Id into tempdantoc
            //            from dantoctemp in tempdantoc
            //            join chucdanh in this.Context.DM_ChucDanhs on nv.IdChucDanh equals chucdanh.Id into tempchucdanh
            //            from chucdanhtemp in tempchucdanh
            //            join honnhan in this.Context.DM_TinhTrangHonNhans on nv.IdTinhTrangHonNhan equals honnhan.Id into temphonnhan
            //            from honnhantemp in temphonnhan
            //            join trinhdo in this.Context.DM_TrinhDos on nv.IdTrinhDo equals trinhdo.Id into temptrinhdo
            //            from trinhdotemp in temptrinhdo
            //            select new
            //            {
            //                MaNhanVien=nv.MaNhanVien,
            //                HoDem
            //                Ten
            //                NguyenQuan
            //                NgaySinh
            //                NoiSinh
            //                GioiTinh
            //                DanToc
            //                HinhAnh
            //                DiaChiThuongTru
            //                DiaChiHienTai
            //                CMND
            //                NgayCap
            //                NoiCapCMND
            //                TonGiao
            //                QuocTich
            //                Email
            //                SoDienThoai
            //            };



        }

        /// <summary>
        /// Gets the nhan vienby id.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_QuaTrinhCongTac> GetQuaTrinhCongTacbyIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuaTrinhCongTacs.Where(uv => ((NV_QuaTrinhCongTac)uv).IdNhanVien == pIdNhanVien).ToList<NV_QuaTrinhCongTac>();
        }

        /// <summary>
        /// Gets the quan heby id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_QuanHeGiaDinh> GetQuanHebyIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuanHeGiaDinhs.Where(uv => ((NV_QuanHeGiaDinh)uv).IdNhanVien == pIdNhanVien).ToList<NV_QuanHeGiaDinh>();
        }

        /// <summary>
        /// Checkeds the nhan vien is exited.
        /// </summary>
        /// <param name="pMaNhanVien">The p ma nhan vien.</param>
        /// <returns></returns>
        public NV_NhanVien CheckedNhanVienIsExited(string pMaNhanVien)
        {
            NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => nv.MaNhanVien == pMaNhanVien).FirstOrDefault();

            return nhanvien;
        }
    }
}
