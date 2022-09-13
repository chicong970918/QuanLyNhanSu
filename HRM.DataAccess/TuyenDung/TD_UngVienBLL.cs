using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.TuyenDung
{
    public class TD_UngVienBLL : DataAccessBase<TD_UngVien>
    {
        /// <summary>
        /// Gets all phong ban.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> GetAllPhongBan()
        {
            int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;

            NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == IdNhanVien).FirstOrDefault();
            if (item != null)
            {
                DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.IdPhongBan).FirstOrDefault();
                if (phongban.IsPhongNhanSu.Value)
                {
                    return this.Context.DM_PhongBans.Select(pb => pb).ToList<DM_PhongBan>();
                }
                else
                {
                    return this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == phongban.Id).ToList<DM_PhongBan>();
                }
            }
            else
            {
                return this.Context.DM_PhongBans.Select(pb => pb).ToList<DM_PhongBan>();
            }

        }

        /// <summary>
        /// Gets all quy.
        /// </summary>
        /// <returns></returns>
        public List<DM_Quy> GetAllQuy()
        {
            return this.Context.DM_Quys.Select(pb => pb).ToList<DM_Quy>();
        }

        /// <summary>
        /// Gets the data by phong ban quy.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetDataByPhongBanQuyNam(int pIdPhongBan, int pQuy, int pNam)
        {
            List<TD_UngVien> list = this.Context.TD_UngViens.Where(uv => uv.IdPhongBan == pIdPhongBan && uv.Quy == pQuy && uv.Nam == pNam && uv.TuyenThang==null).ToList<TD_UngVien>();

            var querychitiet = from uv in list
                               join tinh in this.Context.DM_Tinhs on uv.NoiSinh equals tinh.Id into tmpNoiSinh
                               from tnoisinh in tmpNoiSinh.DefaultIfEmpty()
                               join tongiao in this.Context.DM_TonGiaos on uv.IdTonGiao equals tongiao.Id into tmpTonGiao
                               from ttongiao in tmpTonGiao.DefaultIfEmpty()
                               join dantoc in this.Context.DM_DanTocs on uv.IdDanToc equals dantoc.Id into tmpDanToc
                               from tdantoc in tmpDanToc.DefaultIfEmpty()
                               join chucdanh in this.Context.DM_ChucDanhs on uv.IdChucDanh equals chucdanh.Id into tmpChucDanh
                               from tchucdanh in tmpChucDanh.DefaultIfEmpty()
                               join honnhan in this.Context.DM_TinhTrangHonNhans on uv.IdTinhTrangHonNhan equals honnhan.Id into tmpHonNhan
                               from thonnhan in tmpHonNhan.DefaultIfEmpty()
                               select new
                              {
                                  Id=uv.Id,
                                  IdPhongBan=uv.IdPhongBan,
                                  Quy=uv.Quy,
                                  Nam=uv.Nam,
                                  MaUngVien=uv.MaUngVien,
                                  HoDem=uv.HoDem,
                                  Ten=uv.Ten,
                                  NgaySinh=uv.NgaySinh,
                                  NoiSinhText = tnoisinh==null ? string.Empty : tnoisinh.TenTinh,
                                  NoiSinh=uv.NoiSinh,
                                  GioiTinh = uv.GioiTinh.HasValue ? uv.GioiTinh.Value : uv.GioiTinh,
                                  GioiTinhNu = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? false : true) : false,
                                  GioiTinhText=uv.GioiTinh.HasValue? (uv.GioiTinh.Value==true? "Nam" : "Nữ"):string.Empty,
                                  DanTocText = tdantoc==null ? string.Empty : tdantoc.TenDanToc,
                                  DanToc=uv.IdDanToc,
                                  DiaChi=uv.DiaChiHienTai,
                                  ThuongTru=uv.DiaChiThuongTru,
                                  CMND=uv.CMND,
                                  NoiCapCMND=uv.NoiCapCMND,
                                  TonGiaoText=ttongiao==null ?string.Empty : ttongiao.TenTonGiao,
                                  TonGiao=uv.IdTonGiao,
                                  QuocTich=uv.QuocTich,
                                  IdChucDanh=uv.IdChucDanh,
                                  IdTrinhDo=uv.IdTrinhDo,
                                  IdChuyenNganh=uv.IdChuyenNganh,
                                  ChucDanhText=tchucdanh==null ? string.Empty : tchucdanh.TenChucDanh,
                                  SoDienThoai=uv.SoDienThoai,
                                  Email=uv.Email,
                                  IdTinhTrangHonNhan=uv.IdTinhTrangHonNhan,
                                  HonNhanText=thonnhan==null ? string.Empty :thonnhan.TenTinhTrang,
                                  NgayNhanViec=uv.NgayNhanViec,
                                  LuongThuViec=uv.LuongThuViec,
                                  LuongSauThuViec=uv.LuongSauThuViec,
                                  GhiChu=uv.GhiChu,
                                  DanhGia=uv.DanhGia,
                                  HinhAnh=uv.HinhAnh

                              };

            var result = querychitiet.ToList().ConvertAll(t => new TD_UngVien()
            {
                 Id=t.Id,
                 IdPhongBan=t.IdPhongBan,
                 Quy = t.Quy,
                 Nam = t.Nam,
                 MaUngVien = t.MaUngVien,
                 HoDem = t.HoDem,
                 Ten = t.Ten,
                 NgaySinh = t.NgaySinh,
                 NoiSinhText = t.NoiSinhText,
                 NoiSinh = t.NoiSinh,
                 GioiTinh = t.GioiTinh,
                 GioiTinhText=t.GioiTinhText,
                 GioiTinhNu=t.GioiTinhNu,
                 IdDanToc = t.DanToc,
                 DanTocText = t.DanTocText,
                 DiaChiHienTai = t.DiaChi,
                 DiaChiThuongTru=t.ThuongTru,
                 CMND = t.CMND,
                 NoiCapCMND = t.NoiCapCMND,
                 TonGiaoText = t.TonGiaoText,
                 IdTonGiao = t.TonGiao,
                 QuocTich =  t.QuocTich,
                 IdChucDanh = t.IdChucDanh,
                 IdTrinhDo=t.IdTrinhDo,
                 IdChuyenNganh=t.IdChuyenNganh,
                 ChucDanhText = t.ChucDanhText,
                 SoDienThoai = t.SoDienThoai,
                 Email = t.Email,
                 IdTinhTrangHonNhan = t.IdTinhTrangHonNhan,
                 HonNhanText = t.HonNhanText,
                 NgayNhanViec = t.NgayNhanViec,
                 LuongThuViec = t.LuongThuViec,
                 LuongSauThuViec = t.LuongSauThuViec,
                 GhiChu = t.GhiChu,
                DanhGia=t.DanhGia,
                HinhAnh=t.HinhAnh

            });

            return result.OrderBy(uv => uv.Id).ToList<TD_UngVien>();
        }

        /// <summary>
        /// Gets the data by phong ban quy nam bo nhiem.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetDataByPhongBanQuyNamBoNhiem(int pIdPhongBan, int pQuy, int pNam)
        {
            List<TD_UngVien> list = this.Context.TD_UngViens.Where(uv => uv.IdPhongBan == pIdPhongBan && uv.Quy == pQuy && uv.Nam == pNam && uv.DanhGia.HasValue && uv.DanhGia.Value==true).ToList<TD_UngVien>();

            var querychitiet = from uv in list
                               join tinh in this.Context.DM_Tinhs on uv.NoiSinh equals tinh.Id into tmpNoiSinh
                               from tnoisinh in tmpNoiSinh.DefaultIfEmpty()
                               join tongiao in this.Context.DM_TonGiaos on uv.IdTonGiao equals tongiao.Id into tmpTonGiao
                               from ttongiao in tmpTonGiao.DefaultIfEmpty()
                               join dantoc in this.Context.DM_DanTocs on uv.IdDanToc equals dantoc.Id into tmpDanToc
                               from tdantoc in tmpDanToc.DefaultIfEmpty()
                               join chucdanh in this.Context.DM_ChucDanhs on uv.IdChucDanh equals chucdanh.Id into tmpChucDanh
                               from tchucdanh in tmpChucDanh.DefaultIfEmpty()
                               join honnhan in this.Context.DM_TinhTrangHonNhans on uv.IdTinhTrangHonNhan equals honnhan.Id into tmpHonNhan
                               from thonnhan in tmpHonNhan.DefaultIfEmpty()
                               join bonhiem in this.Context.NV_QuyetDinhBoNhiems on ((TD_UngVien) uv).Id equals bonhiem.IdUngVien into tempBoNhiem
                               from tbonhiem in tempBoNhiem.DefaultIfEmpty()
                               select new
                               {
                                   Id = uv.Id,
                                   IdPhongBan = uv.IdPhongBan,
                                   Quy = uv.Quy,
                                   Nam = uv.Nam,
                                   MaUngVien = uv.MaUngVien,
                                   HoDem = uv.HoDem,
                                   Ten = uv.Ten,
                                   NgaySinh = uv.NgaySinh,
                                   NoiSinhText = tnoisinh == null ? string.Empty : tnoisinh.TenTinh,
                                   NoiSinh = uv.NoiSinh,
                                   GioiTinh = uv.GioiTinh.HasValue ? uv.GioiTinh.Value : uv.GioiTinh,
                                   GioiTinhNu = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? false : true) : false,
                                   GioiTinhText = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? "Nam" : "Nữ") : string.Empty,
                                   DanTocText = tdantoc == null ? string.Empty : tdantoc.TenDanToc,
                                   DanToc = uv.IdDanToc,
                                   DiaChi = uv.DiaChiHienTai,
                                   ThuongTru=uv.DiaChiThuongTru,
                                   CMND = uv.CMND,
                                   NoiCapCMND = uv.NoiCapCMND,
                                   TonGiaoText = ttongiao == null ? string.Empty : ttongiao.TenTonGiao,
                                   TonGiao = uv.IdTonGiao,
                                   QuocTich = uv.QuocTich,
                                   IdChucDanh = uv.IdChucDanh,
                                   IdTrinhDo=uv.IdTrinhDo,
                                   ChucDanhText = tchucdanh == null ? string.Empty : tchucdanh.TenChucDanh,
                                   SoDienThoai = uv.SoDienThoai,
                                   Email = uv.Email,
                                   IdChuyenNganh=uv.IdChuyenNganh,
                                   IdTinhTrangHonNhan = uv.IdTinhTrangHonNhan,
                                   HonNhanText = thonnhan == null ? string.Empty : thonnhan.TenTinhTrang,
                                   NgayNhanViec = uv.NgayNhanViec,
                                   LuongThuViec = uv.LuongThuViec,
                                   LuongSauThuViec = uv.LuongSauThuViec,
                                   GhiChu = uv.GhiChu,
                                   DanhGia = uv.DanhGia,
                                   HinhAnh = uv.HinhAnh,
                                   TenQuyetDinh=tbonhiem==null ? string.Empty : tbonhiem.TenQuyetDinh,
                                   SoQuyetDinh=tbonhiem==null ? 0 : tbonhiem.SoQuyetDinh,
                                   NgayQuyetDinh=tbonhiem==null ?null: tbonhiem.NgayQuyetDinh,
                                   NgayHieuLuc = tbonhiem == null ? null : tbonhiem.NgayHieuLuc,
                                   NoiDung = tbonhiem == null ? string.Empty : tbonhiem.NoiDung,
                                   GhiChuBoNhiem = tbonhiem == null ? string.Empty : tbonhiem.GhiChu
                               };

            var result = querychitiet.ToList().ConvertAll(t => new TD_UngVien()
            {
                Id = t.Id,
                IdPhongBan = t.IdPhongBan,
                Quy = t.Quy,
                Nam = t.Nam,
                MaUngVien = t.MaUngVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                NgaySinh = t.NgaySinh,
                NoiSinhText = t.NoiSinhText,
                NoiSinh = t.NoiSinh,
                GioiTinh = t.GioiTinh,
                GioiTinhText = t.GioiTinhText,
                GioiTinhNu = t.GioiTinhNu,
                IdDanToc = t.DanToc,
                DanTocText = t.DanTocText,
                DiaChiHienTai = t.DiaChi,
                DiaChiThuongTru=t.ThuongTru,
                CMND = t.CMND,
                NoiCapCMND = t.NoiCapCMND,
                TonGiaoText = t.TonGiaoText,
                IdTonGiao = t.TonGiao,
                QuocTich = t.QuocTich,
                IdChucDanh = t.IdChucDanh,
                IdTrinhDo=t.IdTrinhDo,
                IdChuyenNganh=t.IdChuyenNganh,
                ChucDanhText = t.ChucDanhText,
                SoDienThoai = t.SoDienThoai,
                Email = t.Email,
                IdTinhTrangHonNhan = t.IdTinhTrangHonNhan,
                HonNhanText = t.HonNhanText,
                NgayNhanViec = t.NgayNhanViec,
                LuongThuViec = t.LuongThuViec,
                LuongSauThuViec = t.LuongSauThuViec,
                GhiChu = t.GhiChu,
                DanhGia = t.DanhGia,
                HinhAnh = t.HinhAnh,
                TenQuyetDinh = t.TenQuyetDinh,
                SoQuyetDinh = t.SoQuyetDinh,
                NgayQuyetDinh = t.NgayQuyetDinh,
                NgayHieuLuc = t.NgayHieuLuc,
                NoiDung = t.NoiDung,
                GhiChuBoNhiem = t.GhiChu
            });

            return result.OrderBy(uv => uv.Id).ToList<TD_UngVien>();
        }

        /// <summary>
        /// Gets the data by phong ban quy.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetDataByPhongBanQuyNamTuyenThang(int pIdPhongBan, int pQuy, int pNam)
        {
            List<TD_UngVien> list = this.Context.TD_UngViens.Where(uv => uv.IdPhongBan == pIdPhongBan && uv.Quy == pQuy && uv.Nam == pNam && uv.TuyenThang.HasValue && uv.TuyenThang.Value==true).ToList<TD_UngVien>();

            var querychitiet = from uv in list
                               join tinh in this.Context.DM_Tinhs on uv.NoiSinh equals tinh.Id into tmpNoiSinh
                               from tnoisinh in tmpNoiSinh.DefaultIfEmpty()
                               join tongiao in this.Context.DM_TonGiaos on uv.IdTonGiao equals tongiao.Id into tmpTonGiao
                               from ttongiao in tmpTonGiao.DefaultIfEmpty()
                               join dantoc in this.Context.DM_DanTocs on uv.IdDanToc equals dantoc.Id into tmpDanToc
                               from tdantoc in tmpDanToc.DefaultIfEmpty()
                               join chucdanh in this.Context.DM_ChucDanhs on uv.IdChucDanh equals chucdanh.Id into tmpChucDanh
                               from tchucdanh in tmpChucDanh.DefaultIfEmpty()
                               join honnhan in this.Context.DM_TinhTrangHonNhans on uv.IdTinhTrangHonNhan equals honnhan.Id into tmpHonNhan
                               from thonnhan in tmpHonNhan.DefaultIfEmpty()
                               select new
                               {
                                   Id = uv.Id,
                                   IdPhongBan = uv.IdPhongBan,
                                   Quy = uv.Quy,
                                   Nam = uv.Nam,
                                   MaUngVien = uv.MaUngVien,
                                   HoDem = uv.HoDem,
                                   Ten = uv.Ten,
                                   NgaySinh = uv.NgaySinh,
                                   NoiSinhText = tnoisinh == null ? string.Empty : tnoisinh.TenTinh,
                                   NoiSinh = uv.NoiSinh,
                                   GioiTinh = uv.GioiTinh.HasValue ? uv.GioiTinh.Value : uv.GioiTinh,
                                   GioiTinhNu = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? false : true) : false,
                                   GioiTinhText = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? "Nam" : "Nữ") : string.Empty,
                                   DanTocText = tdantoc == null ? string.Empty : tdantoc.TenDanToc,
                                   DanToc = uv.IdDanToc,
                                   DiaChi = uv.DiaChiHienTai,
                                   ThuongTru=uv.DiaChiThuongTru,
                                   CMND = uv.CMND,
                                   NoiCapCMND = uv.NoiCapCMND,
                                   TonGiaoText = ttongiao == null ? string.Empty : ttongiao.TenTonGiao,
                                   TonGiao = uv.IdTonGiao,
                                   QuocTich = uv.QuocTich,
                                   IdChucDanh = uv.IdChucDanh,
                                   IdChuyenNganh=uv.IdChuyenNganh,
                                   IdTrinhDo=uv.IdTrinhDo,
                                   ChucDanhText = tchucdanh == null ? string.Empty : tchucdanh.TenChucDanh,
                                   SoDienThoai = uv.SoDienThoai,
                                   Email = uv.Email,
                                   IdTinhTrangHonNhan = uv.IdTinhTrangHonNhan,
                                   HonNhanText = thonnhan == null ? string.Empty : thonnhan.TenTinhTrang,
                                   NgayNhanViec = uv.NgayNhanViec,
                                   LuongThuViec = uv.LuongThuViec,
                                   LuongSauThuViec = uv.LuongSauThuViec,
                                   GhiChu = uv.GhiChu,
                                   HinhAnh = uv.HinhAnh,
                                   DanhGia=uv.DanhGia,
                                   TuyenThang=uv.TuyenThang,

                               };

            var result = querychitiet.ToList().ConvertAll(t => new TD_UngVien()
            {
                Id = t.Id,
                IdPhongBan = t.IdPhongBan,
                Quy = t.Quy,
                Nam = t.Nam,
                MaUngVien = t.MaUngVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                NgaySinh = t.NgaySinh,
                NoiSinhText = t.NoiSinhText,
                NoiSinh = t.NoiSinh,
                GioiTinh = t.GioiTinh,
                GioiTinhText = t.GioiTinhText,
                GioiTinhNu = t.GioiTinhNu,
                IdDanToc = t.DanToc,
                DanTocText = t.DanTocText,
                DiaChiHienTai = t.DiaChi,
                DiaChiThuongTru=t.ThuongTru,
                CMND = t.CMND,
                NoiCapCMND = t.NoiCapCMND,
                TonGiaoText = t.TonGiaoText,
                IdTonGiao = t.TonGiao,
                IdChuyenNganh=t.IdChuyenNganh,
                QuocTich = t.QuocTich,
                IdChucDanh = t.IdChucDanh,
                IdTrinhDo=t.IdTrinhDo,
                ChucDanhText = t.ChucDanhText,
                SoDienThoai = t.SoDienThoai,
                Email = t.Email,
                IdTinhTrangHonNhan = t.IdTinhTrangHonNhan,
                HonNhanText = t.HonNhanText,
                NgayNhanViec = t.NgayNhanViec,
                LuongThuViec = t.LuongThuViec,
                LuongSauThuViec = t.LuongSauThuViec,
                GhiChu = t.GhiChu,
                HinhAnh = t.HinhAnh,
                DanhGia=t.DanhGia,
                TuyenThang=t.TuyenThang

            });

            return result.OrderBy(uv => uv.Id).ToList<TD_UngVien>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        public override void UpdateDataList(List<TD_UngVien> plistData)
        {
            foreach (TD_UngVien uv in plistData)
            {
                if (uv.MaUngVien == null)
                {
                    string kytudau = CacheData.Context.GetSystemDate().Year.ToString().Substring((CacheData.Context.GetSystemDate().Year.ToString().Length - 2), 2).ToString();
                    int maxxx = 1;
                    string maphongban = CacheData.GetMaPhongBan(uv.IdPhongBan).ToString();
                    List<TD_UngVien> list11 = this.Context.TD_UngViens.Where(uss => uss.MaUngVien.StartsWith(kytudau)).ToList<TD_UngVien>();

                    if (list11.Count > 0)
                    {
                        list11 = list11.Where(uvww => uvww.IdPhongBan == uv.IdPhongBan).ToList<TD_UngVien>();
                        try
                        {
                            maxxx = list11.Max(ug => int.Parse(ug.MaUngVien.Substring(2 + maphongban.Length, ug.MaUngVien.Length - (2 + maphongban.Length))));
                            maxxx++;
                        }
                        catch
                        {

                        }
                    }

                    uv.MaUngVien = kytudau.Trim() + maphongban.Trim() + maxxx.ToString();

                }
            }

            base.UpdateDataList(plistData);
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateData(TD_UngVien pObject)
        {
            TD_UngVien item =GetEntityById(0);
           
           // pObject.Id =  
            if (pObject.MaUngVien == null)
            {
                string kytudau = CacheData.Context.GetSystemDate().Year.ToString().Substring((CacheData.Context.GetSystemDate().Year.ToString().Length - 2), 2).ToString();
                string maphongban = CacheData.GetMaPhongBan(pObject.IdPhongBan).ToString();
                string thutuungvien = (this.Context.TD_UngViens.Where(u => u.IdPhongBan == pObject.IdPhongBan).Count() + 1).ToString();
                pObject.MaUngVien = kytudau.Trim() + maphongban.Trim() + thutuungvien.Trim();
            }
            base.UpdateData(pObject);
        }

        /// <summary>
        /// Checkeds the using.
        /// </summary>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        public bool CheckedUsing(int pIdUngVien)
        {
            if ((this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdUngVien == pIdUngVien).Count()) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Gets the ung vien by id.
        /// </summary>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        public TD_UngVien GetUngVienById(int pIdUngVien)
        {
            return this.Context.TD_UngViens.Where(uv => ((TD_UngVien)(uv)).Id == pIdUngVien).FirstOrDefault();
        }

        /// <summary>
        /// Gets the data by phong ban quy nam.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        public List<TD_UngVien> GetUngVienTrungTuyen(int pIdPhongBan, int pQuy, int pNam)
        {
            List<TD_UngVien> list = this.Context.TD_UngViens.Where(uv => uv.IdPhongBan == pIdPhongBan && uv.Quy == pQuy && uv.Nam == pNam && uv.DanhGia == true).ToList<TD_UngVien>();

            var querychitiet = from uv in list
                               join tinh in this.Context.DM_Tinhs on uv.NoiSinh equals tinh.Id into tmpNoiSinh
                               from tnoisinh in tmpNoiSinh.DefaultIfEmpty()
                               join tongiao in this.Context.DM_TonGiaos on uv.IdTonGiao equals tongiao.Id into tmpTonGiao
                               from ttongiao in tmpTonGiao.DefaultIfEmpty()
                               join dantoc in this.Context.DM_DanTocs on uv.IdDanToc equals dantoc.Id into tmpDanToc
                               from tdantoc in tmpDanToc.DefaultIfEmpty()
                               join chucdanh in this.Context.DM_ChucDanhs on uv.IdChucDanh equals chucdanh.Id into tmpChucDanh
                               from tchucdanh in tmpChucDanh.DefaultIfEmpty()
                               join honnhan in this.Context.DM_TinhTrangHonNhans on uv.IdTinhTrangHonNhan equals honnhan.Id into tmpHonNhan
                               from thonnhan in tmpHonNhan.DefaultIfEmpty()
                               select new
                               {
                                   Id = uv.Id,
                                   IdPhongBan = uv.IdPhongBan,
                                   Quy = uv.Quy,
                                   Nam = uv.Nam,
                                   MaUngVien = uv.MaUngVien,
                                   HoDem = uv.HoDem,
                                   Ten = uv.Ten,
                                   NgaySinh = uv.NgaySinh,
                                   NoiSinhText = tnoisinh == null ? string.Empty : tnoisinh.TenTinh,
                                   NoiSinh = uv.NoiSinh,
                                   GioiTinh = uv.GioiTinh.HasValue ? uv.GioiTinh.Value : uv.GioiTinh,
                                   GioiTinhNu = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? false : true) : false,
                                   GioiTinhText = uv.GioiTinh.HasValue ? (uv.GioiTinh.Value == true ? "Nam" : "Nữ") : string.Empty,
                                   DanTocText = tdantoc == null ? string.Empty : tdantoc.TenDanToc,
                                   DanToc = uv.IdDanToc,
                                   DiaChi = uv.DiaChiHienTai,
                                   ThuongTru=uv.DiaChiThuongTru,
                                   CMND = uv.CMND,
                                   NoiCapCMND = uv.NoiCapCMND,
                                   TonGiaoText = ttongiao == null ? string.Empty : ttongiao.TenTonGiao,
                                   TonGiao = uv.IdTonGiao,
                                   QuocTich = uv.QuocTich,
                                   IdChucDanh = uv.IdChucDanh,
                                   IdTrinhDo=uv.IdTrinhDo,
                                   ChucDanhText = tchucdanh == null ? string.Empty : tchucdanh.TenChucDanh,
                                   SoDienThoai = uv.SoDienThoai,
                                   Email = uv.Email,
                                   IdTinhTrangHonNhan = uv.IdTinhTrangHonNhan,
                                   HonNhanText = thonnhan == null ? string.Empty : thonnhan.TenTinhTrang,
                                   NgayNhanViec = uv.NgayNhanViec,
                                   LuongThuViec = uv.LuongThuViec,
                                   LuongSauThuViec = uv.LuongSauThuViec,
                                   GhiChu = uv.GhiChu

                               };

            var result = querychitiet.ToList().ConvertAll(t => new TD_UngVien()
            {
                Id = t.Id,
                IdPhongBan = t.IdPhongBan,
                Quy = t.Quy,
                Nam = t.Nam,
                MaUngVien = t.MaUngVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                NgaySinh = t.NgaySinh,
                NoiSinhText = t.NoiSinhText,
                NoiSinh = t.NoiSinh,
                GioiTinh = t.GioiTinh,
                GioiTinhText = t.GioiTinhText,
                GioiTinhNu = t.GioiTinhNu,
                IdDanToc = t.DanToc,
                DanTocText = t.DanTocText,
                DiaChiHienTai = t.DiaChi,
                DiaChiThuongTru=t.ThuongTru,
                CMND = t.CMND,
                NoiCapCMND = t.NoiCapCMND,
                TonGiaoText = t.TonGiaoText,
                IdTonGiao = t.TonGiao,
                QuocTich = t.QuocTich,
                IdChucDanh = t.IdChucDanh,
                IdTrinhDo=t.IdTrinhDo,
                ChucDanhText = t.ChucDanhText,
                SoDienThoai = t.SoDienThoai,
                Email = t.Email,
                IdTinhTrangHonNhan = t.IdTinhTrangHonNhan,
                HonNhanText = t.HonNhanText,
                NgayNhanViec = t.NgayNhanViec,
                LuongThuViec = t.LuongThuViec,
                LuongSauThuViec = t.LuongSauThuViec,
                GhiChu = t.GhiChu

            });

            return result.OrderBy(uv => uv.Id).ToList<TD_UngVien>();
        }

        /// <summary>
        /// Gets the chuc danh theo PYC.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<DM_ChucDanh> GetChucDanhTheoPYC(int pIdPhongBan, int pQuy, int pNam)
        {
            List<DM_ChucDanh> listChucDanh = this.Context.DM_ChucDanhs.Select(cd => cd).ToList<DM_ChucDanh>();

            List<int> listIdChucDanh = this.Context.TD_PhieuYeuCauTuyenDungs.Where(yc => yc.IdPhongBan == pIdPhongBan && yc.Nam == pNam && yc.Quy == pQuy && yc.DaDuyet.Value==true).Select(yc => yc.IdChucDanh).ToList<int>();


            listChucDanh = listChucDanh.Where(cd => listIdChucDanh.Contains(cd.Id)).ToList<DM_ChucDanh>();

            return listChucDanh;
        }

        /// <summary>
        /// Gets the trinh do theo PYC.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        ///  19/10/11
        /// PC
        public List<DM_TrinhDo> GetTrinhDoTheoPYC(int pIdPhongBan, int pQuy, int pNam)
        {
            List<DM_TrinhDo> listtrinhdo = this.Context.DM_TrinhDos.Select(cd => cd).ToList<DM_TrinhDo>();

            List<int> listIdChucDanh = this.Context.TD_PhieuYeuCauTuyenDungs.Where(yc => yc.IdPhongBan == pIdPhongBan && yc.Nam == pNam && yc.Quy == pQuy && yc.DaDuyet.Value == true).Select(yc => yc.IdTrinhDo.Value).ToList<int>();


            listtrinhdo = listtrinhdo.Where(cd => listIdChucDanh.Contains(cd.Id)).ToList<DM_TrinhDo>();

            return listtrinhdo;
        }
        /// <summary>
        /// Gets the trinh do theo PYC.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        ///  19/10/11
        /// PC
        public List<DM_ChuyenNganh> GetChuyenNganhTheoPYC(int pIdPhongBan, int pQuy, int pNam)
        {
            List<DM_ChuyenNganh> listChuyenNganh = this.Context.DM_ChuyenNganhs.Select(cd => cd).ToList<DM_ChuyenNganh>();

            List<int> listIdChucDanh = this.Context.TD_PhieuYeuCauTuyenDungs.Where(yc => yc.IdPhongBan == pIdPhongBan && yc.Nam == pNam && yc.Quy == pQuy && yc.DaDuyet.Value == true).Select(yc => yc.IdChuyenNganh.Value).ToList<int>();

            listChuyenNganh = listChuyenNganh.Where(cd => listIdChucDanh.Contains(cd.Id)).ToList<DM_ChuyenNganh>();

            return listChuyenNganh;
        }

        /// <summary>
        /// Getungvienbyids the specified p id ung vien.
        /// </summary>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        public TD_UngVien getungvienbyid(int pIdUngVien)
        {
            return this.Context.TD_UngViens.Where(uv => ((TD_UngVien)uv).Id == pIdUngVien).FirstOrDefault();
        }

        /// <summary>
        /// Gets the quyet dinh by id ung vien.
        /// </summary>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        public NV_QuyetDinhBoNhiem GetQuyetDinhByIdUngVien(int pIdUngVien)
        {
            return this.Context.NV_QuyetDinhBoNhiems.Where(qd => qd.IdUngVien == pIdUngVien).FirstOrDefault();
        }

        /// <summary>
        /// Checks the quyet dinh bo nhiem.
        /// </summary>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        public bool CheckQuyetDinhBoNhiem(int pIdUngVien)
        {
            NV_QuyetDinhBoNhiem ungvien = this.Context.NV_QuyetDinhBoNhiems.Where(qd => qd.IdUngVien == pIdUngVien).FirstOrDefault();

            if (ungvien != null)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void UpdateDataBoNhiem(TD_UngVien pObject)
        {
            NV_NhanVien nhanvien = new NV_NhanVien();
            NV_QuyetDinhBoNhiem bonhiem = new NV_QuyetDinhBoNhiem();
              int soquyetdinh=-1;
            NV_QuyetDinhBoNhiem bn = this.Context.NV_QuyetDinhBoNhiems.Select(u => u).FirstOrDefault();
            if (bn != null)
            {
                soquyetdinh = this.Context.NV_QuyetDinhBoNhiems.Select(u => u).Max(u => u.SoQuyetDinh) + 1;
            }
            else
            {
                soquyetdinh = 1;
            }

            string kytudau = CacheData.Context.GetSystemDate().Year.ToString().Substring((CacheData.Context.GetSystemDate().Year.ToString().Length - 2), 2).ToString();
            int maxxx = 1;
            string maphongban = CacheData.GetMaPhongBan(pObject.IdPhongBan).ToString();
            List<NV_NhanVien> list11 = this.Context.NV_NhanViens.Where(uss => uss.MaNhanVien.StartsWith(kytudau)).ToList<NV_NhanVien>();

           // nhanvien.MaNhanVien = kytudau + maphongban + thutuungvien;
            // Add bonhiem
            bonhiem.SoQuyetDinh = soquyetdinh;
            bonhiem.TenQuyetDinh = pObject.TenQuyetDinh;
            bonhiem.NgayHieuLuc = pObject.NgayHieuLuc;
            bonhiem.NgayQuyetDinh = pObject.NgayQuyetDinh;
            bonhiem.TenQuyetDinh = pObject.TenQuyetDinh;
            bonhiem.NoiDung = pObject.NoiDung;
            bonhiem.GhiChu = pObject.GhiChuBoNhiem;
            bonhiem.IdUngVien =((TD_UngVien) pObject).Id;
            Common.LayerCommon.Copy(pObject, nhanvien, "Id", "MaNhanVien", "NguyenQuan", "NgayCap", "SoDienThoai",
                 "DaChamDutHopDong", "HienTaiChucDanh", "SoHopDong", "HeSoChuyenMonHienTai", "HeSoLuongHienTai", "HienTaiPhongBan",
                "LuongSauThuViec");

            if (list11.Count > 0)
            {
                list11 = list11.Where(uvww => uvww.IdPhongBan == pObject.IdPhongBan).ToList<NV_NhanVien>();
                try
                {
                    maxxx = list11.Max(ug => int.Parse(ug.MaNhanVien.Substring(2 + maphongban.Length, ug.MaNhanVien.Length - (2 + maphongban.Length))));
                    maxxx++;
                }
                catch
                {

                }
            }

            nhanvien.MaNhanVien = kytudau.Trim() + maphongban.Trim() + maxxx.ToString();
          
            nhanvien.HeSoLuongHienTai = decimal.Parse((0.2).ToString());
            nhanvien.DaChamDutHopDong = false;
            nhanvien.HienTaiChucDanh = nhanvien.IdChucDanh;
            nhanvien.HienTaiPhongBan = nhanvien.IdPhongBan;
           
            DM_ChucDanh chucdanh =this.Context.DM_ChucDanhs.Where(cd=>((DM_ChucDanh)cd).Id==nhanvien.IdChucDanh).FirstOrDefault();
            nhanvien.IdChuyenNganh = pObject.IdChuyenNganh;
            if (chucdanh != null)
            {
                nhanvien.LuongSauThuViec = chucdanh.LuongCanBan==null ? 0: chucdanh.LuongCanBan;
            }
            else
            {
                nhanvien.LuongSauThuViec = 0;
            }

            DM_TrinhDo item = this.Context.DM_TrinhDos.Where(td => ((DM_TrinhDo)td).Id == nhanvien.IdTrinhDo).FirstOrDefault();

            if (item != null)
            {
                nhanvien.HeSoChuyenMonHienTai = item.HeSoChuyenMon==null? 0 : item.HeSoChuyenMon;
            }
            else
            {
                nhanvien.HeSoChuyenMonHienTai = 0;
            }

            this.Context.NV_NhanViens.InsertOnSubmit(nhanvien);
            this.Context.NV_QuyetDinhBoNhiems.InsertOnSubmit(bonhiem);

            this.Context.SubmitChanges();

        }
    }
}
