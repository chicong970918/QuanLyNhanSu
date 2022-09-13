using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.ChamCong_TinhLuong
{
    /// <summary>
    /// 
    /// </summary>
    public class TL_BangLuongBLL : DataAccessBase<TL_BangLuong>
    {
        /// <summary>
        /// Checkeds the data do du lieu.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckedDataTinhLuong(int pThang, int pNam)
        {
            TL_BangLuong tinhluong = this.Context.TL_BangLuongs.Where(tl => tl.Thang == pThang && tl.Nam == pNam).FirstOrDefault();

            if (tinhluong != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the data tinh luong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuong(int pThang, int pNam)
        {
            // Load nhung nhanvien con hop dong de tinh luong
            List<NV_NhanVien> ListNhanVien = this.Context.NV_NhanViens.Where(nv => nv.DaChamDutHopDong == false).ToList<NV_NhanVien>();
            //Tinh cho tung nhan vien
            foreach (NV_NhanVien nhanvien in ListNhanVien)
            {
                TL_BangLuong bangluong = new TL_BangLuong();

                bangluong.Nam = pNam;
                bangluong.Thang = pThang;
                bangluong.IdNhanVien = ((NV_NhanVien)nhanvien).Id;

                // Tinh so ngay cong
                TL_TongHopChamCongNhanVien tonhhopcong = this.Context.TL_TongHopChamCongNhanViens.Where(thcc => thcc.Nam == pNam && thcc.Thang == pThang &&
                                                                                                        thcc.IdNhanVien == ((NV_NhanVien)nhanvien).Id
                                                                                                       ).FirstOrDefault();
                if (tonhhopcong == null)
                {
                    bangluong.SoNgayCong = 0;
                }
                else
                {
                    int sobuoi = 0;
                    for (int i = 1; i <= 31; i++)
                    {
                        bool? valueC = (Nullable<bool>)(tonhhopcong.GetType().GetProperty("C" + i).GetValue(tonhhopcong, null));
                        if (valueC.HasValue && valueC.Value == true)
                        {
                            sobuoi++;
                        }
                        bool? valueS = (Nullable<bool>)(tonhhopcong.GetType().GetProperty("S" + i).GetValue(tonhhopcong, null));
                        if (valueS.HasValue && valueS.Value == true)
                        {
                            sobuoi++;
                        }
                    }


                    bangluong.SoNgayCong =decimal.Parse(( sobuoi / 2).ToString());

                    if (sobuoi % 2 != 0)
                    {
                        bangluong.SoNgayCong = bangluong.SoNgayCong.Value + decimal.Parse("0.5");
                    }
                }

                if (bangluong.SoNgayCong >= 15)
                {
                    bangluong.HeSoLuong = nhanvien.HeSoLuongHienTai;
                    bangluong.HeSoChucVu = decimal.Parse(this.Context.HeSoChucDanh(((NV_NhanVien)nhanvien).Id).Value.ToString());
                    bangluong.HeSoChuyenMon = nhanvien.HeSoChuyenMonHienTai;
                    bangluong.HeSoTrachNhiem = decimal.Parse(this.Context.HeSoTrachNhiem(((NV_NhanVien)nhanvien).Id).Value.ToString());
                    bangluong.TongHeSo = bangluong.HeSoLuong + bangluong.HeSoChucVu + bangluong.HeSoChuyenMon + bangluong.HeSoTrachNhiem;
                }
                else
                {
                    bangluong.HeSoLuong = 0;
                    bangluong.HeSoChucVu = 0;
                    bangluong.HeSoChuyenMon = 0;
                    bangluong.HeSoTrachNhiem = 0;
                    bangluong.TongHeSo = 0;
                }

                if (nhanvien.HienTaiLoaiHopDong == 1)
                {
                    bangluong.MucLuongCoBan = decimal.Parse((nhanvien.LuongSauThuViec.Value * decimal.Parse("0.7") ).ToString());
                }
                else
                {
                    bangluong.MucLuongCoBan = nhanvien.LuongSauThuViec.Value;
                }

                //Bao Hiem

                bangluong.BaoHiem = bangluong.MucLuongCoBan.Value * decimal.Parse("0.15");

                bangluong.TienHeSoLuong = bangluong.MucLuongCoBan * bangluong.TongHeSo;
                bangluong.SoNgayNghi = 24 - bangluong.SoNgayCong;
                if (bangluong.SoNgayNghi < 0)
                {
                    bangluong.SoNgayNghi = 0;
                }
                bangluong.TienNgayNghi = (bangluong.SoNgayNghi * bangluong.MucLuongCoBan) / 24;

                // Tien thuong
                List<NV_QuyetDinhKhenThuong> listkhenthuong = this.Context.NV_QuyetDinhKhenThuongs.Where(kt => kt.IdNhanVien == ((NV_NhanVien)nhanvien).Id &&
                                                                                                       kt.NgayHieuLuc.Value.Year == pNam && kt.NgayHieuLuc.Value.Month == pThang).ToList<NV_QuyetDinhKhenThuong>();

                if (listkhenthuong == null)
                {
                    bangluong.TienThuongKhac = 0;
                }
                else
                {
                    bangluong.TienThuongKhac = decimal.Parse(listkhenthuong.Sum(kt => kt.TienThuong.HasValue ? kt.TienThuong.Value : 0).ToString());
                }

                // Tien ky luat (phat)
                List<NV_QuyetDinhKyLuat> listkyluat = this.Context.NV_QuyetDinhKyLuats.Where(kt => kt.IdNhanVien == ((NV_NhanVien)nhanvien).Id &&
                                                                                                      kt.NgayHieuLuc.Value.Year == pNam && kt.NgayHieuLuc.Value.Month == pThang).ToList<NV_QuyetDinhKyLuat>();

                if (listkyluat == null)
                {
                    bangluong.TienPhat = 0;
                }
                else
                {
                    bangluong.TienPhat = decimal.Parse(listkyluat.Sum(kt => kt.TienPhat.Value).ToString());
                }


                TL_TamUng tamung = this.Context.TL_TamUngs.Where(tu => tu.IdNhanVien == ((NV_NhanVien)nhanvien).Id
                                                               && tu.NgayTamUng.Year == pNam && tu.NgayTamUng.Month == pThang).FirstOrDefault();

                if (tamung == null)
                {
                    bangluong.TamUng = 0;
                }
                else
                {
                    bangluong.TamUng = tamung.SoTien;
                }

                // Tinh thuong le 
                DM_ThuongNgayLe thuongle = this.Context.DM_ThuongNgayLes.Where(tl => tl.NgayLe.Year == pNam && tl.NgayLe.Month == pThang).FirstOrDefault();
                if (thuongle == null)
                {
                    bangluong.TienThuongLe = 0;
                }
                else
                {
                    DM_ChiTietThuongNgayLe chitietthuong = this.Context.DM_ChiTietThuongNgayLes.Where(ct => ct.IdThuongNgayLe == ((DM_ThuongNgayLe)thuongle).Id
                                                                                                    && ct.IdChucDanh == nhanvien.HienTaiChucDanh).FirstOrDefault();
                    if (chitietthuong == null)
                    {
                        bangluong.TienThuongLe = 0;
                    }
                    else
                    {
                        bangluong.TienThuongLe = chitietthuong.MucThuong;
                    }
                }

                bangluong.ThucLinh = bangluong.MucLuongCoBan + bangluong.TienHeSoLuong - (bangluong.TienNgayNghi + bangluong.TienPhat + bangluong.TamUng + bangluong.BaoHiem) + bangluong.TienThuongKhac + bangluong.TienThuongLe;

                TL_BangLuong BangLuongChecked = this.Context.TL_BangLuongs.Where(bl => bl.IdNhanVien == ((NV_NhanVien)nhanvien).Id && bl.Nam == pNam && bl.Thang == pThang).FirstOrDefault();

                if (BangLuongChecked == null)
                {
                    this.Context.TL_BangLuongs.InsertOnSubmit(bangluong);
                }
                else
                {
                    bangluong.Id = BangLuongChecked.Id;
                    UpdateData(bangluong);
                }
            }

            this.Context.SubmitChanges();

            List<TL_BangLuong> listbangluong = this.Context.TL_BangLuongs.Where(bl => bl.Nam == pNam && bl.Thang == pThang).ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens.Where(nv => nv.DaChamDutHopDong == false) on luong.IdNhanVien equals nhanvien.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChucVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            GiamTruKhac = luong.GiamTruKhac,
                            BaoHiem = luong.BaoHiem,
                            TamUng = luong.TamUng,
                            ThucLinh = luong.ThucLinh,
                            GhiChu = luong.GhiChu
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem.Trim(),
                Ten = t.Ten.Trim(),
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChucVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac,
                GiamTruKhac = t.GiamTruKhac,
                TamUng = t.TamUng,
                BaoHiem = t.BaoHiem,
                ThucLinh = t.ThucLinh,
                GhiChu = t.GhiChu
            });

            return result.ToList<TL_BangLuong>();
            //}
        }

        /// <summary>
        /// Loads the data tinh luong xem.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuongXem(int pThang, int pNam)
        {
            List<TL_BangLuong> listbangluong = this.Context.TL_BangLuongs.Where(bl => bl.Nam == pNam && bl.Thang == pThang).ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens on luong.IdNhanVien equals nhanvien.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChuVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            GiamTruKhac = luong.GiamTruKhac,
                            TamUng = luong.TamUng,
                            BaoHiem = luong.BaoHiem,
                            ThucLinh = luong.ThucLinh,
                            GhiChu = luong.GhiChu
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChuVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac,
                GiamTruKhac = t.GiamTruKhac,
                TamUng = t.TamUng,
                BaoHiem = t.BaoHiem,
                ThucLinh = t.ThucLinh,
                GhiChu = t.GhiChu
            });

            return result.ToList<TL_BangLuong>();
        }

        /// <summary>
        /// Khoas the luong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        public void KhoaLuong(int pThang, int pNam)
        {
            TL_KhoaLuong khoaluong = this.Context.TL_KhoaLuongs.Where(kl => kl.Nam == pNam && kl.Thang == pThang).FirstOrDefault();

            if (khoaluong == null)
            {
                khoaluong = new TL_KhoaLuong();
                khoaluong.Thang = pThang;
                khoaluong.Nam = pNam;
                this.Context.TL_KhoaLuongs.InsertOnSubmit(khoaluong);
                this.Context.SubmitChanges();

            }
        }

        /// <summary>
        /// Checkeds the khoa luong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckedKhoaLuong(int pThang, int pNam)
        {
            TL_KhoaLuong khoaluong = this.Context.TL_KhoaLuongs.Where(kl => kl.Nam == pNam && kl.Thang == pThang).FirstOrDefault();

            if (khoaluong != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the data tinh luong xem.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuongXemTatCa(int pIdNhanVien)
        {
            List<TL_BangLuong> listbangluong = this.Context.TL_BangLuongs.Where(bl => bl.IdNhanVien == pIdNhanVien).ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens on luong.IdNhanVien equals nhanvien.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChuVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            TamUng = luong.TamUng,
                            ThucLinh = luong.ThucLinh,
                            BaoHiem = luong.BaoHiem,
                            GiamTruKhac = luong.GiamTruKhac,
                            GhiChu = luong.GhiChu
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChuVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac,
                TamUng = t.TamUng,
                ThucLinh = t.ThucLinh,
                BaoHiem = t.BaoHiem,
                GiamTruKhac = t.GiamTruKhac,
                GhiChu = t.GhiChu
            });

            return result.ToList<TL_BangLuong>();
        }

        /// <summary>
        /// Loads the data tinh luong xem.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuongXemNamThang(int pIdNhanVien, int pThang, int pNam)
        {
            List<TL_BangLuong> listbangluong;
            var query1 = this.Context.TL_BangLuongs.Where(t => t.IdNhanVien == pIdNhanVien);

            if (pNam > 0)
            {
                query1 = query1.Where(bl => bl.Nam == pNam);
            }
            if (pThang > 0)
            {
                query1 = query1.Where(d => d.Thang == pThang);
            }

            listbangluong = query1.ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens on luong.IdNhanVien equals nhanvien.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChuVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            TamUng = luong.TamUng,
                            ThucLinh = luong.ThucLinh,
                            BaoHiem = luong.BaoHiem,
                            GiamTruKhac = luong.GiamTruKhac,
                            GhiChu = luong.GhiChu
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChuVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac,
                TamUng = t.TamUng,
                ThucLinh = t.ThucLinh,
                BaoHiem = t.BaoHiem,
                GiamTruKhac = t.GiamTruKhac,
                GhiChu = t.GhiChu
            });

            return result.ToList<TL_BangLuong>();
        }

        /// <summary>
        /// Checkes the tinh luong thoi viec nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public bool CheckeQuyetDinhThoiViecNhanVien(int pIdNhanVien)
        {
            NV_QuyetDinhThoiViec thoiviec = this.Context.NV_QuyetDinhThoiViecs.Where(tv => tv.IdNhanVien == pIdNhanVien).FirstOrDefault();

            if (thoiviec == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checkes the tinh luong thoi viec nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckeTinhLuongThoiViecNhanVien(int pIdNhanVien, int pThang, int pNam)
        {
            NV_QuyetDinhThoiViec thoiviec = this.Context.NV_QuyetDinhThoiViecs.Where(tv => tv.IdNhanVien == pIdNhanVien).FirstOrDefault();

            if (thoiviec.NgayHieuLuc.Value.Year != pNam || thoiviec.NgayHieuLuc.Value.Month != pThang)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Loads the data tinh luong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuongThoiViec(int pIdNhanVien, int pThang, int pNam)
        {
            // Load nhung nhanvien con hop dong de tinh luong
            List<NV_NhanVien> ListNhanVien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).ToList<NV_NhanVien>();
            //Tinh cho tung nhan vien
            foreach (NV_NhanVien nhanvien in ListNhanVien)
            {
                TL_BangLuong bangluong = new TL_BangLuong();

                bangluong.Nam = pNam;
                bangluong.Thang = pThang;
                bangluong.IdNhanVien = ((NV_NhanVien)nhanvien).Id;

                // Tinh so ngay cong
                TL_TongHopChamCongNhanVien tonhhopcong = this.Context.TL_TongHopChamCongNhanViens.Where(thcc => thcc.Nam == pNam && thcc.Thang == pThang &&
                                                                                                        thcc.IdNhanVien == ((NV_NhanVien)nhanvien).Id
                                                                                                        ).FirstOrDefault();
                if (tonhhopcong == null)
                {
                    bangluong.SoNgayCong = 0;
                }
                else
                {
                    int sobuoi = 0;
                    for (int i = 1; i <= 31; i++)
                    {
                        bool? valueC = (Nullable<bool>)(tonhhopcong.GetType().GetProperty("C" + i).GetValue(tonhhopcong, null));
                        if (valueC.HasValue && valueC.Value == true)
                        {
                            sobuoi++;
                        }
                        bool? valueS = (Nullable<bool>)(tonhhopcong.GetType().GetProperty("S" + i).GetValue(tonhhopcong, null));
                        if (valueS.HasValue && valueS.Value == true)
                        {
                            sobuoi++;
                        }
                    }
                    bangluong.SoNgayCong = sobuoi / 2;
                }

                if (bangluong.SoNgayCong >= 15)
                {
                    bangluong.HeSoLuong = nhanvien.HeSoLuongHienTai;
                    bangluong.HeSoChucVu = decimal.Parse(this.Context.HeSoChucDanh(((NV_NhanVien)nhanvien).Id).Value.ToString());
                    bangluong.HeSoChuyenMon = nhanvien.HeSoChuyenMonHienTai;
                    bangluong.HeSoTrachNhiem = decimal.Parse(this.Context.HeSoTrachNhiem(((NV_NhanVien)nhanvien).Id).Value.ToString());
                    bangluong.TongHeSo = bangluong.HeSoLuong + bangluong.HeSoChucVu + bangluong.HeSoChuyenMon + bangluong.HeSoTrachNhiem;
                }
                else
                {
                    bangluong.HeSoLuong = 0;
                    bangluong.HeSoChucVu = 0;
                    bangluong.HeSoChuyenMon = 0;
                    bangluong.HeSoTrachNhiem = 0;
                    bangluong.TongHeSo = 0;
                }

                if (nhanvien.HienTaiLoaiHopDong == 1)
                {
                    bangluong.MucLuongCoBan = decimal.Parse((nhanvien.LuongSauThuViec.Value * (70 / 100)).ToString());
                }
                else
                {
                    bangluong.MucLuongCoBan = nhanvien.LuongSauThuViec.Value;
                }

                //Bao Hiem
                bangluong.BaoHiem = bangluong.MucLuongCoBan * decimal.Parse("0.15");
                bangluong.TienHeSoLuong = bangluong.MucLuongCoBan * bangluong.TongHeSo;

                bangluong.SoNgayNghi = 24 - bangluong.SoNgayCong;

                if (bangluong.SoNgayNghi < 0)
                {
                    bangluong.SoNgayNghi = 0;
                }
                bangluong.TienNgayNghi = (bangluong.SoNgayNghi * bangluong.MucLuongCoBan) / 24;

                // Tien thuong
                List<NV_QuyetDinhKhenThuong> listkhenthuong = this.Context.NV_QuyetDinhKhenThuongs.Where(kt => kt.IdNhanVien == ((NV_NhanVien)nhanvien).Id &&
                                                                                                       kt.NgayHieuLuc.Value.Year == pNam && kt.NgayHieuLuc.Value.Month == pThang).ToList<NV_QuyetDinhKhenThuong>();

                if (listkhenthuong == null)
                {
                    bangluong.TienThuongKhac = 0;
                }
                else
                {
                    bangluong.TienThuongKhac = decimal.Parse(listkhenthuong.Sum(kt => kt.TienThuong.HasValue ? kt.TienThuong.Value : 0).ToString());
                }

                // Tien ky luat (phat)
                List<NV_QuyetDinhKyLuat> listkyluat = this.Context.NV_QuyetDinhKyLuats.Where(kt => kt.IdNhanVien == ((NV_NhanVien)nhanvien).Id &&
                                                                                                      kt.NgayHieuLuc.Value.Year == pNam && kt.NgayHieuLuc.Value.Month == pThang).ToList<NV_QuyetDinhKyLuat>();

                if (listkyluat == null)
                {
                    bangluong.TienPhat = 0;
                }
                else
                {
                    bangluong.TienPhat = decimal.Parse(listkyluat.Sum(kt => kt.TienPhat.Value).ToString());
                }


                TL_TamUng tamung = this.Context.TL_TamUngs.Where(tu => tu.IdNhanVien == ((NV_NhanVien)nhanvien).Id
                                                               && tu.NgayTamUng.Year == pNam && tu.NgayTamUng.Month == pThang).FirstOrDefault();

                if (tamung == null)
                {
                    bangluong.TamUng = 0;
                }
                else
                {
                    bangluong.TamUng = tamung.SoTien;
                }

                // Tinh thuong le 
                DM_ThuongNgayLe thuongle = this.Context.DM_ThuongNgayLes.Where(tl => tl.NgayLe.Year == pNam && tl.NgayLe.Month == pThang).FirstOrDefault();
                if (thuongle == null)
                {
                    bangluong.TienThuongLe = 0;
                }
                else
                {
                    DM_ChiTietThuongNgayLe chitietthuong = this.Context.DM_ChiTietThuongNgayLes.Where(ct => ct.IdThuongNgayLe == ((DM_ThuongNgayLe)thuongle).Id
                                                                                                    && ct.IdChucDanh == nhanvien.HienTaiChucDanh).FirstOrDefault();
                    if (chitietthuong == null)
                    {
                        bangluong.TienThuongLe = 0;
                    }
                    else
                    {
                        bangluong.TienThuongLe = chitietthuong.MucThuong;
                    }
                }

                bangluong.ThucLinh = bangluong.MucLuongCoBan + bangluong.TienHeSoLuong - (bangluong.TienNgayNghi + bangluong.TienPhat + bangluong.TamUng - bangluong.BaoHiem) + bangluong.TienThuongKhac + bangluong.TienThuongLe;

                TL_BangLuong BangLuongChecked = this.Context.TL_BangLuongs.Where(bl => bl.IdNhanVien == ((NV_NhanVien)nhanvien).Id && bl.Nam == pNam && bl.Thang == pThang).FirstOrDefault();

                if (BangLuongChecked == null)
                {
                    this.Context.TL_BangLuongs.InsertOnSubmit(bangluong);
                }
                else
                {

                    UpdateData(bangluong);
                }
            }

            this.Context.SubmitChanges();

            List<TL_BangLuong> listbangluong = this.Context.TL_BangLuongs.Where(bl => bl.Nam == pNam && bl.Thang == pThang && bl.IdNhanVien == pIdNhanVien).ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens on luong.IdNhanVien equals nhanvien.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChucVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            BaoHiem = luong.BaoHiem,
                            GiamTruKhac = luong.GiamTruKhac,
                            TamUng = luong.TamUng,
                            ThucLinh = luong.ThucLinh,
                            GhiChu = luong.GhiChu
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChucVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac,
                TamUng = t.TamUng,
                BaoHiem = t.BaoHiem,
                GiamTruKhac = t.GiamTruKhac,
                ThucLinh = t.ThucLinh,
                GhiChu = t.GhiChu
            });

            return result.ToList<TL_BangLuong>();
        }

        /// <summary>
        /// Checkeds the has data cham cong_ tinh luong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckedHasDataChamCong_TinhLuong(int pThang, int pNam)
        {
            TL_TongHopChamCongNhanVien tonghop = this.Context.TL_TongHopChamCongNhanViens.Where(th => th.Nam == pNam && th.Thang == pThang).FirstOrDefault();

            if (tonghop == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Loads the data tinh luong xem.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuongXemNamThangNhanVienThoiViec(int pIdNhanVien, int pThang, int pNam)
        {
            List<TL_BangLuong> listbangluong;
            var query1 = this.Context.TL_BangLuongs.Where(t => t.IdNhanVien == pIdNhanVien);

            if (pNam > 0)
            {
                query1 = query1.Where(bl => bl.Nam == pNam);
            }
            if (pThang > 0)
            {
                query1 = query1.Where(d => d.Thang == pThang);
            }

            listbangluong = query1.ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens on luong.IdNhanVien equals nhanvien.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChuVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            TamUng = luong.TamUng,
                            ThucLinh = luong.ThucLinh,
                            BaoHiem = luong.BaoHiem,
                            GiamTruKhac = luong.GiamTruKhac,
                            GhiChu = luong.GhiChu
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChuVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac,
                TamUng = t.TamUng,
                ThucLinh = t.ThucLinh,
                BaoHiem = t.BaoHiem,
                GiamTruKhac = t.GiamTruKhac,
                GhiChu = t.GhiChu
            });

            return result.ToList<TL_BangLuong>();
        }

        /// <summary>
        /// Loads the data tinh luong xem.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public List<TL_BangLuong> LoadDataTinhLuongXemNamThangPhongBan(int pIdPhongBan, int pThang, int pNam)
        {
            List<TL_BangLuong> listbangluong;
            var query1 = this.Context.TL_BangLuongs.Select(t => t);

            if (pNam > 0)
            {
                query1 = query1.Where(bl => bl.Nam == pNam);
            }
            if (pThang > 0)
            {
                query1 = query1.Where(d => d.Thang == pThang);
            }

            listbangluong = query1.ToList<TL_BangLuong>();

            var query = from luong in listbangluong
                        join nhanvien in this.Context.NV_NhanViens.Where(nv => nv.IdPhongBan == pIdPhongBan) on luong.IdNhanVien equals nhanvien.Id
                        join chucDanh in this.Context.DM_ChucDanhs on nhanvien.IdChucDanh equals chucDanh.Id
                        select new
                        {
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            Id = luong.Id,
                            Nam = luong.Nam,
                            Thang = luong.Thang,
                            IdNhanVien = luong.IdNhanVien,
                            HeSoLuong = luong.HeSoLuong,
                            HeSoChuyenMon = luong.HeSoChuyenMon,
                            HeSoTrachNhiem = luong.HeSoTrachNhiem,
                            HeSoChuVu = luong.HeSoChucVu,
                            TongHeSo = luong.TongHeSo,
                            MucLuongCoBan = luong.MucLuongCoBan,
                            SoNgayCong = luong.SoNgayCong,
                            TienHeSoLuong = luong.TienHeSoLuong,
                            SoNgayNghi = luong.SoNgayNghi,
                            TienNgayNghi = luong.TienNgayNghi,
                            TienThuongLe = luong.TienThuongLe,
                            TienPhat = luong.TienPhat,
                            TienThuongKhac = luong.TienThuongKhac,
                            PhuCapKhac = luong.PhuCapKhac,
                            TamUng = luong.TamUng,
                            ThucLinh = luong.ThucLinh,
                            BaoHiem = luong.BaoHiem,
                            GiamTruKhac = luong.GiamTruKhac,
                            GhiChu = luong.GhiChu,
                            ChucVu = chucDanh.TenChucDanh,
                        };

            var result = query.ToList().ConvertAll(t => new TL_BangLuong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                Id = t.Id,
                Nam = t.Nam,
                Thang = t.Thang,
                IdNhanVien = t.IdNhanVien,
                HeSoLuong = t.HeSoLuong,
                HeSoChuyenMon = t.HeSoChuyenMon,
                HeSoChucVu = t.HeSoChuVu,
                HeSoTrachNhiem = t.HeSoTrachNhiem,
                TongHeSo = t.TongHeSo,
                MucLuongCoBan = t.MucLuongCoBan,
                SoNgayCong = t.SoNgayCong,
                TienHeSoLuong = t.TienHeSoLuong,
                SoNgayNghi = t.SoNgayNghi,
                TienNgayNghi = t.TienNgayNghi,
                TienThuongLe = t.TienThuongLe,
                TienPhat = t.TienPhat,
                TienThuongKhac = t.TienThuongKhac,
                PhuCapKhac = t.PhuCapKhac.HasValue ? t.PhuCapKhac : 0,
                TamUng = t.TamUng,
                GiamTruKhac = t.GiamTruKhac.HasValue ? t.GiamTruKhac : 0,
                BaoHiem = t.BaoHiem.HasValue ? t.BaoHiem : 0,
                ThucLinh = t.ThucLinh,
                GhiChu = t.GhiChu,
                ChucVu = t.ChucVu,

            });

            return result.ToList<TL_BangLuong>();
        }

    }
}
