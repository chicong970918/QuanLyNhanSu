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
    public class TL_ChamCongBLL : DataAccessBase<TL_ChamCong>
    {
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="pNgayChamCong">The p ngay cham cong.</param>
        /// <returns></returns>
        public  List<TL_ChamCong> GetAllData(DateTime pNgayChamCong)
        {
            List<TL_ChamCong> list = this.Context.TL_ChamCongs.Where(cc => cc.NgayChamCong.Value.Day == pNgayChamCong.Day &&
                                                                         cc.NgayChamCong.Value.Month == pNgayChamCong.Month && cc.NgayChamCong.Value.Year == pNgayChamCong.Year).ToList<TL_ChamCong>();

            var query = from chamcong in list
                        join nhanvien in this.Context.NV_NhanViens on chamcong.IdNhanVien equals ((NV_NhanVien)nhanvien).Id into tempNhanVien
                        from nhanvientemp in tempNhanVien.DefaultIfEmpty()
                        select new
                        {
                            MaNhanVien = nhanvientemp.MaNhanVien,
                            HoDem = nhanvientemp.HoDem,
                            Ten = nhanvientemp.Ten,
                            NgaySinh = nhanvientemp.NgaySinh,
                            GioiTinh = nhanvientemp.GioiTinh,
                            IdNhanVien = chamcong.IdNhanVien,
                            Id = chamcong.Id,
                            GioVao = chamcong.GioVao,
                            GioRa = chamcong.GioRa,
                            NgayCapNgat=chamcong.NgayCapNhat,
                            NgayCham=chamcong.NgayChamCong
                        };
            var result = query.ToList().ConvertAll(t => new TL_ChamCong()
            {
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                NgaySinh = t.NgaySinh,
                GioiTinh = t.GioiTinh,
                IdNhanVien=t.IdNhanVien,
                Id=t.Id,
                GioVao=t.GioVao,
                GioRa=t.GioRa,
                NgayCapNhat=t.NgayCapNgat,
                NgayChamCong=t.NgayCham
            });

            return result.OrderByDescending(cc=>cc.NgayCapNhat).Take(10).ToList<TL_ChamCong>();
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

        /// <summary>
        /// Checkeds the data.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public int CheckedData(TL_ChamCong pObject)
        {
            TL_ChamCong chamcong = this.Context.TL_ChamCongs.Where(cc => cc.IdNhanVien == pObject.IdNhanVien && cc.NgayChamCong.Value.Day == pObject.NgayChamCong.Value.Day &&
                                                                         cc.NgayChamCong.Value.Month == pObject.NgayChamCong.Value.Month && cc.NgayChamCong.Value.Year == pObject.NgayChamCong.Value.Year).FirstOrDefault();
            if (chamcong == null)
            {
                return 1;
            }
            else
            {
                if (chamcong.GioRa.HasValue)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            }
           // base.UpdateData(pObject);
        }

        /// <summary>
        /// Updates the data cham cong.
        /// </summary>
        /// <param name="pitem">The pitem.</param>
        public void UpdateDataChamCong(TL_ChamCong pitem)
        {
            TL_ChamCong chamcong = this.Context.TL_ChamCongs.Where(cc => cc.IdNhanVien == pitem.IdNhanVien && cc.NgayChamCong.Value.Day == pitem.NgayChamCong.Value.Day &&
                                                                        cc.NgayChamCong.Value.Month == pitem.NgayChamCong.Value.Month && cc.NgayChamCong.Value.Year == pitem.NgayChamCong.Value.Year).FirstOrDefault();
            if (chamcong != null)
            {
                chamcong.NgayCapNhat = CacheData.Context.GetSystemDate();
               chamcong.GioRa= pitem.GioRa;
               this.Context.SubmitChanges();
            }
            else
            {
                pitem.NgayCapNhat = CacheData.Context.GetSystemDate();
                InsertData(pitem);
            }

        }

        /// <summary>
        /// Checkeds the data do du lieu.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckedDataDoDuLieu(int pThang, int pNam)
        {
            TL_TongHopChamCong tonghop = this.Context.TL_TongHopChamCongs.Where(cc => cc.ThoiGian.Value.Year == pNam && cc.ThoiGian.Value.Month == pThang).FirstOrDefault();

            if (tonghop != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checkeds the du lieu cham cong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        public bool CheckedDuLieuChamCong(int pThang, int pNam)
        {
            TL_ChamCong chamcong = this.Context.TL_ChamCongs.Where(cc => cc.NgayChamCong.Value.Year == pNam && cc.NgayChamCong.Value.Month == pThang).FirstOrDefault();

            if (chamcong != null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Does the du lieu cham cong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        public void DoDuLieuChamCong(int pThang, int pNam)
        {
            List<TL_ChamCong> listchamcong = this.Context.TL_ChamCongs.Where(cc => cc.NgayChamCong.Value.Year == pNam && cc.NgayChamCong.Value.Month == pThang).ToList<TL_ChamCong>();

            foreach (TL_ChamCong item in listchamcong)
            {
                if (item.GioVao.HasValue && item.GioRa.HasValue)
                {

                    TL_TongHopChamCong tonghop = new TL_TongHopChamCong();
                    tonghop.IdNhanVien = item.IdNhanVien;
                    tonghop.ThoiGian = item.NgayChamCong;
                    if (item.GioVao.Value.Hour < 7)
                    {
                        item.GioVao = new DateTime(item.GioVao.Value.Year, item.GioVao.Value.Month, item.GioVao.Value.Day, 7, 0, 0, 0, DateTimeKind.Utc);
                    }
                    if (item.GioRa.Value.Hour > 17)
                    {
                        item.GioRa = new DateTime(item.GioRa.Value.Year, item.GioRa.Value.Month, item.GioRa.Value.Day, 17, 0, 0, 0, DateTimeKind.Utc);
                    }
                    if (item.GioRa.Value.Hour < 13)
                    {
                        item.GioRa = new DateTime(item.GioRa.Value.Year, item.GioRa.Value.Month, item.GioRa.Value.Day, 11, 0, 0, 0, DateTimeKind.Utc);
                    }

                    TimeSpan hh = ((DateTime)(item.GioRa) - (DateTime)(item.GioVao));

                    decimal phutround = Math.Round((decimal)hh.Minutes / 60, 2);

                    if (item.GioVao.Value.Hour <= 11 && item.GioRa.Value.Hour >= 13)
                    {
                        tonghop.VaoRa = double.Parse((hh.Hours - 2 + phutround).ToString());
                    }
                    else
                    {
                        tonghop.VaoRa = double.Parse((hh.Hours + phutround).ToString());
                    }

                    this.Context.TL_TongHopChamCongs.InsertOnSubmit(tonghop);
                }
            }

            this.Context.SubmitChanges();

            this.Context.SP_GetTongHopChamCongThang(pThang, pNam);
        }

        public static DateTime Round(DateTime dateTime)
        {
            var updated = dateTime.AddMinutes(30);
            return new DateTime(updated.Year, updated.Month, updated.Day,
                                 updated.Hour, 0, 0, dateTime.Kind);
        }
        public static DateTime RoundToHours(DateTime input)
        {
            DateTime dt = new DateTime(input.Year, input.Month, input.Day, input.Hour, 0, 0);

            if (input.Minute > 29)
                return dt.AddHours(1);
            else
                return dt;
        }


    }
}
