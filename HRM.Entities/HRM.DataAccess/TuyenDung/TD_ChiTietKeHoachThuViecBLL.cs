using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.TuyenDung
{
    /// <summary>
    /// 
    /// </summary>
    public class TD_ChiTietKeHoachThuViecBLL : DataAccessBase<TD_ChiTietKeHoachThuViec>
    {
        /// <summary>
        /// Gets the quan ly.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TD_KeHoachThuViec> GetQuanLy(int pIdPhongBan, int pQuy, int pNam,int pIdPYC)
        {
            List<TD_KeHoachThuViec> list = this.Context.TD_KeHoachThuViecs.Where(kh => kh.IdPhongBan == pIdPhongBan && kh.Quy == pQuy && kh.Nam == pNam && kh.IdPhieuYeuCauTuyenDung==pIdPYC).ToList<TD_KeHoachThuViec>();

            var query = from kh in list
                        join nv in this.Context.NV_NhanViens on kh.IdNhanVien equals nv.Id into tmpNhanVien
                        from tempnv in tmpNhanVien.DefaultIfEmpty()
                        select new
                        {
                            Id = kh.Id,
                            MaKeHoachThuViec = kh.MaKeHoachThuViec,
                            TenQuanLy = tempnv.Ten,
                            HoDemQuanLy = tempnv.HoDem,
                            MaNhanVien = tempnv.MaNhanVien,
                            NgayBatDau = kh.ThuViecTuNgay,
                            NgayKetThuc = kh.ThuViecDenNgay,
                            IdNhanVien = ((NV_NhanVien)tempnv).Id,
                            IdPhongBan = tempnv.IdPhongBan,
                            Quy = kh.Quy,
                            Nam = kh.Nam

                        };
            var result = query.ToList().ConvertAll(t => new TD_KeHoachThuViec()
       {
           Id = t.Id,
           MaNhanVienQuanLy = t.MaNhanVien,
           HoDemQuanLy = t.HoDemQuanLy,
           TenQuanLy = t.TenQuanLy,
           MaKeHoachThuViec = t.MaKeHoachThuViec,
           ThuViecTuNgay = t.NgayBatDau,
           ThuViecDenNgay = t.NgayKetThuc,
           IdNhanVien = t.IdNhanVien,
           IdPhongBan = t.IdPhongBan,
           Quy = t.Quy,
           Nam = t.Nam
       });

            return result.OrderBy(kh => kh.MaKeHoachThuViec).ToList<TD_KeHoachThuViec>();
        }

        /// <summary>
        /// Gets the ung vien.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetUngVien(int pIdKeHoach)
        {
            List<TD_ChiTietKeHoachThuViec> list = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdKeHoachThuViec == pIdKeHoach).ToList<TD_ChiTietKeHoachThuViec>();

            var query = from ct in list
                        join uv in this.Context.TD_UngViens on ct.IdUngVien equals uv.Id into temp
                        from tempuv in temp
                        join kh in this.Context.TD_KeHoachThuViecs on ct.IdKeHoachThuViec equals kh.Id
                        join chucdanh in this.Context.DM_ChucDanhs on tempuv.IdChucDanh equals chucdanh.Id into tmpChucDanh
                        from tchucdanh in tmpChucDanh.DefaultIfEmpty()
                        select new
                        {
                            HoDem = tempuv.HoDem,
                            Ten = tempuv.Ten,
                            ChucDanhText = tchucdanh == null ? string.Empty : tchucdanh.TenChucDanh,
                            GioiTinh = tempuv.GioiTinh,
                            NgaySinh = tempuv.NgaySinh,
                            // MaChuongTrinhThuViec=this.Context.TD_KeHoachThuViecs.Where(kh=>kh.Id==ct.IdKeHoachThuViec).FirstOrDefault().MaKeHoachThuViec,
                            MaUngVien = tempuv.MaUngVien,
                            Id = ((TD_UngVien)tempuv).Id,
                            MaKeHoach = kh.MaKeHoachThuViec,
                            DanhGia = tempuv.DanhGia,
                            DiemTB = ct.DiemTB,
                            KetQua = ct.KetQua

                        };

            var result = query.ToList().ConvertAll(t => new TD_UngVien()
            {
                Id = t.Id,
                MaUngVien = t.MaUngVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                //MaKeHoach = t.MaChuongTrinhThuViec,
                ChucDanhText = t.ChucDanhText,
                GioiTinh = t.GioiTinh,
                NgaySinh = t.NgaySinh,
                MaKeHoach = t.MaKeHoach,
                DanhGia = t.DanhGia,
                DiemTB = t.DiemTB,
                KetquaText = t.KetQua == false ? "Rớt" : "Đậu"

            });
            return result.OrderBy(kh => kh.Ten).ToList<TD_UngVien>();
        }

        /// <summary>
        /// Loads the ung vien by id ke hoach thu viec.
        /// </summary>
        /// <param name="pIdKHThuViec">The p id KH thu viec.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetUngVienByIdKeHoachThuViec(TD_KeHoachThuViec pkeHoach)
        {
            List<TD_ChiTietKeHoachThuViec> plist = this.Context.TD_ChiTietKeHoachThuViecs.Where(uv => uv.IdKeHoachThuViec == pkeHoach.Id).ToList<TD_ChiTietKeHoachThuViec>();

            List<TD_UngVien> plistUV = (from UV in this.Context.TD_UngViens
                                        from CT in this.Context.TD_ChiTietKeHoachThuViecs
                                        where UV.Id == CT.IdUngVien
                                        && CT.IdKeHoachThuViec == pkeHoach.Id
                                        && UV.DanhGia.HasValue == false
                                        select UV).ToList<TD_UngVien>();

            //List<TD_UngVien> plistUV = (from UV in this.Context.TD_UngViens
            //                            from CT in this.Context.TD_ChiTietKeHoachThuViecs
            //                            where UV.Id == CT.IdUngVien
            //                            from KH in this.Context.TD_KeHoachThuViecs
            //                            where KH.IdNhanVien == pkeHoach.IdNhanVien
            //                            && CT.IdKeHoachThuViec == KH.Id
            //                            && KH.Id == pkeHoach.Id
            //                            && UV.DanhGia == false
            //                            select UV).ToList<TD_UngVien>();
            return plistUV;
        }

        /// <summary>
        /// Getungs the vien chua co KH thu viec.
        /// </summary>
        /// <param name="pKeHoach">The p ke hoach.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetUngVienChuaCoKHThuViec(TD_KeHoachThuViec pKeHoach,int pIdPhieuYeuCau)
        {
            TD_PhieuYeuCauTuyenDung PYC = this.Context.TD_PhieuYeuCauTuyenDungs.Where(pyc => ((TD_PhieuYeuCauTuyenDung)pyc).Id == pIdPhieuYeuCau).FirstOrDefault();
            int IdChucdanh = -1;
            int IdTrinhDo = -1;
            int IdChuyenNganh = -1;
            if (PYC != null)
            {
                IdChucdanh = PYC.IdChucDanh;
                IdTrinhDo = PYC.IdTrinhDo.Value;
                IdChuyenNganh = PYC.IdChuyenNganh.Value;
            }
            List<TD_UngVien> listUngVien = (from UV in this.Context.TD_UngViens.Where(uv=>uv.IdChucDanh==IdChucdanh && uv.IdChuyenNganh==IdChuyenNganh && uv.IdTrinhDo==IdTrinhDo)
                                            where !this.Context.TD_ChiTietKeHoachThuViecs.Any(ct => ct.IdUngVien == UV.Id) && UV.DanhGia.HasValue == false
                                            select UV).ToList<TD_UngVien>();

            List<TD_UngVien> listResult = listUngVien.Where(uv =>
                                            ((TD_UngVien)(uv)).IdPhongBan == pKeHoach.IdPhongBan
                                            && ((TD_UngVien)(uv)).Quy == pKeHoach.Quy
                                            && ((TD_UngVien)(uv)).Nam == pKeHoach.Nam).ToList<TD_UngVien>();

            return listResult;
        }

        /// <summary>
        /// Thems the ung vien cho chi tiet thu viec.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        public void ThemUngVienChoChiTietThuViec(List<int> pList, int pIdKeHoach)
        {
            foreach (int nd in pList)
            {
                TD_ChiTietKeHoachThuViec ql = this.Context.TD_ChiTietKeHoachThuViecs.Where(q => ((TD_ChiTietKeHoachThuViec)(q)).IdUngVien == nd).FirstOrDefault();
                if (ql == null)
                {
                    TD_ChiTietKeHoachThuViec newItem = new TD_ChiTietKeHoachThuViec();

                    newItem.IdKeHoachThuViec = pIdKeHoach;
                    newItem.IdUngVien = nd;
                    this.Context.TD_ChiTietKeHoachThuViecs.InsertOnSubmit(newItem);

                    this.Context.SubmitChanges();
                }
            }
        }

        /// <summary>
        /// Deletes the ung vien tu chi tiet.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <returns></returns>
        public bool DeleteUngVienTuChiTiet(List<int> pList)
        {
            foreach (int nd in pList)
            {
                TD_ChiTietKeHoachThuViec item = this.Context.TD_ChiTietKeHoachThuViecs.Where(q => ((TD_ChiTietKeHoachThuViec)(q)).IdUngVien == nd).FirstOrDefault();

                if (item != null)
                {
                    this.Context.TD_ChiTietKeHoachThuViecs.DeleteOnSubmit(item);

                    // Save change
                    this.Context.SubmitChanges();
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the id chi tiet.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        public int GetIdChiTiet(int pIdKeHoach, int pIdUngVien)
        {
            List<int> listid = new List<int>();

            TD_ChiTietKeHoachThuViec item = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdKeHoachThuViec == pIdKeHoach && ct.IdUngVien == pIdUngVien).FirstOrDefault();

            if (item != null)
            {
                return item.Id;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the phong ban.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> GetPhongBan()
        {
            UserInfo _user = LayerCommon.CurrentUser;
            if (_user.IdNhanVien == null || _user.IsPhongNhanSu == true)
            {
                return this.Context.DM_PhongBans.Select(pb => pb).ToList();
            }
            else
            {
                int userPhongBan = (from Pb in this.Context.DM_PhongBans
                                    from Nv in this.Context.NV_NhanViens
                                    where Pb.Id == Nv.IdPhongBan
                                    && Nv.Id == _user.IdNhanVien
                                    select Pb).FirstOrDefault().Id;

                return this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)(pb)).Id == userPhongBan).ToList();
            }
        }

        /// <summary>
        /// Calls the tinh TB.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        public void CallTinhTB(int pIdKeHoach, int pIdUngVien, int pIdPhongBan, int pQuy, int pNam, int pIdPYC)
        {
            TD_KeHoachThuViec kehoach = this.Context.TD_KeHoachThuViecs.Where(kh => ((TD_KeHoachThuViec)kh).Id == pIdKeHoach).FirstOrDefault();

            if (kehoach != null)
            {
                TD_ChiTietKeHoachThuViec chitiet = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdKeHoachThuViec == kehoach.Id && ct.IdUngVien == pIdUngVien).FirstOrDefault();

                if (chitiet != null)
                {
                    List<TD_YeuCauCongViec> list = this.Context.TD_YeuCauCongViecs.Where(yc => yc.IdChiTietKeHoachThuViec == chitiet.Id).ToList<TD_YeuCauCongViec>();

                    if (list.Count > 0)
                    {
                        int dtb = list.Sum(yc => yc.DiemSo.Value);
                        if (list.Count > 1)
                        {
                            if (dtb % 2 == 0)
                            {
                                chitiet.DiemTB = dtb / list.Count;
                            }
                            else
                            {
                                chitiet.DiemTB = dtb / list.Count + double.Parse("0.5");
                            }
                        }
                        else
                        {
                            chitiet.DiemTB = dtb / list.Count;
                        }
                    }
                    else
                    {
                        chitiet.DiemTB = 0;
                    }
                    if (!chitiet.DiemTB.HasValue)
                    {
                        chitiet.DiemTB = 0;
                    }
                    double? drb = chitiet.DiemTB + 1;
                }
            }

            this.Context.SubmitChanges();
        }

        /// <summary>
        /// Danhes the gia ket qua.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <param name="pNam">The p nam.</param>
        /// <param name="pIdChucDanh">The p id chuc danh.</param>
        public void DanhGiaKetQua(int pIdKeHoach, int pIdPhongBan, int pQuy, int pNam, int pIdPYC)
        {
            List<TD_PhieuYeuCauTuyenDung> listyc = this.Context.TD_PhieuYeuCauTuyenDungs.Where(yc =>((TD_PhieuYeuCauTuyenDung) yc).Id == pIdPYC).ToList<TD_PhieuYeuCauTuyenDung>();

            int soluongyeucau = 0;

            foreach (TD_PhieuYeuCauTuyenDung item in listyc)
            {
                if (item.SoLuong.HasValue)
                {
                    soluongyeucau = soluongyeucau + item.SoLuong.Value;
                }
            }

            TD_KeHoachThuViec kehoach = this.Context.TD_KeHoachThuViecs.Where(kh => ((TD_KeHoachThuViec)kh).Id == pIdKeHoach).FirstOrDefault();

            if (kehoach != null)
            {
                List<TD_ChiTietKeHoachThuViec> listchitiet = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdKeHoachThuViec == kehoach.Id&& ct.DiemTB>=5).OrderByDescending(ct => ct.DiemTB ).ToList<TD_ChiTietKeHoachThuViec>();
                var query = (from p in listchitiet
                             select p).Take(soluongyeucau).OrderBy(p=>p.DiemTB);

                TD_ChiTietKeHoachThuViec danhgia=query.FirstOrDefault();

                var query1 = listchitiet.Where(d => d.DiemTB >= danhgia.DiemTB);
                

                List<TD_ChiTietKeHoachThuViec> listchitietRot = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdKeHoachThuViec == kehoach.Id && ct.DiemTB < 5).OrderByDescending(ct => ct.DiemTB).ToList<TD_ChiTietKeHoachThuViec>();

                foreach (TD_ChiTietKeHoachThuViec ctkh in listchitietRot)
                {
                    ctkh.KetQua = false;
                    TD_UngVien ungvien = this.Context.TD_UngViens.Where(uv => ((TD_UngVien)uv).Id == ctkh.IdUngVien).FirstOrDefault();

                    if (ungvien != null)
                    {
                        ungvien.DanhGia = false;
                    }
                }

                foreach (TD_ChiTietKeHoachThuViec ctkh in listchitiet)
                {
                    ctkh.KetQua = false;

                    TD_UngVien ungvien = this.Context.TD_UngViens.Where(uv => ((TD_UngVien)uv).Id == ctkh.IdUngVien).FirstOrDefault();

                    if (ungvien != null)
                    {
                        ungvien.DanhGia = false;
                    }
                }

                query1 = query1.ToList<TD_ChiTietKeHoachThuViec>();

                foreach (TD_ChiTietKeHoachThuViec ctkh in query1)
                {
                    ctkh.KetQua = true;
                    TD_UngVien ungvien = this.Context.TD_UngViens.Where(uv => ((TD_UngVien)uv).Id == ctkh.IdUngVien).FirstOrDefault();

                    if (ungvien != null)
                    {
                        ungvien.DanhGia = true;
                    }
                }
                this.Context.SubmitChanges();
            }
        }


        /// <summary>
        /// Gets the ung vien.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <returns></returns>
        public List<TD_UngVien> GetUngVienDanhGiaKetQua(int pIdKeHoach, int pIdPYC)
        {
            TD_PhieuYeuCauTuyenDung PYC = this.Context.TD_PhieuYeuCauTuyenDungs.Where(pyc => ((TD_PhieuYeuCauTuyenDung)pyc).Id == pIdPYC).FirstOrDefault();
            int IdChucdanh = -1;
            int IdTrinhDo = -1;
            int IdChuyenNganh = -1;
            if (PYC != null)
            {
                IdChucdanh = PYC.IdChucDanh;
                IdTrinhDo = PYC.IdTrinhDo.Value;
                IdChuyenNganh = PYC.IdChuyenNganh.Value;
            }

            List<TD_ChiTietKeHoachThuViec> list = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ct.IdKeHoachThuViec == pIdKeHoach).ToList<TD_ChiTietKeHoachThuViec>();



            var query = from ct in list
                        join uv in this.Context.TD_UngViens.Where(uv => uv.IdChucDanh == IdChucdanh && uv.IdChuyenNganh == IdChuyenNganh && uv.IdTrinhDo == IdTrinhDo) on ct.IdUngVien equals uv.Id into temp
                        from tempuv in temp
                        join kh in this.Context.TD_KeHoachThuViecs on ct.IdKeHoachThuViec equals kh.Id
                        join chucdanh in this.Context.DM_ChucDanhs on tempuv.IdChucDanh equals chucdanh.Id into tmpChucDanh
                        from tchucdanh in tmpChucDanh.DefaultIfEmpty()
                        select new
                        {
                            HoDem = tempuv.HoDem,
                            Ten = tempuv.Ten,
                            ChucDanhText = tchucdanh == null ? string.Empty : tchucdanh.TenChucDanh,
                            GioiTinh = tempuv.GioiTinh,
                            NgaySinh = tempuv.NgaySinh,
                            // MaChuongTrinhThuViec=this.Context.TD_KeHoachThuViecs.Where(kh=>kh.Id==ct.IdKeHoachThuViec).FirstOrDefault().MaKeHoachThuViec,
                            MaUngVien = tempuv.MaUngVien,
                            Id = ((TD_UngVien)tempuv).Id,
                            MaKeHoach = kh.MaKeHoachThuViec,
                            DanhGia = tempuv.DanhGia,
                            DiemTB = ct.DiemTB,
                            KetQua = ct.KetQua,
                            IdChuDanh = tempuv.IdChucDanh,

                        };

            var result = query.ToList().ConvertAll(t => new TD_UngVien()
            {
                Id = t.Id,
                MaUngVien = t.MaUngVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                //MaKeHoach = t.MaChuongTrinhThuViec,
                ChucDanhText = t.ChucDanhText,
                GioiTinh = t.GioiTinh,
                NgaySinh = t.NgaySinh,
                MaKeHoach = t.MaKeHoach,
                DanhGia = t.DanhGia,
                DiemTB = t.DiemTB,
                KetquaText = t.KetQua.HasValue ? t.KetQua.Value == false ? "Rớt" : "Đậu" : string.Empty,
                IdChucDanh = t.IdChuDanh

            });
            return result.OrderBy(kh => kh.Ten).ToList<TD_UngVien>();
        }
    }
}
