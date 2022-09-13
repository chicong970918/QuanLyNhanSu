using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.ChamCong_TinhLuong
{
    public class TL_TongHopChamCongNhanVienBLL : DataAccessBase<TL_TongHopChamCongNhanVien>
    {
        /// <summary>
        /// Loads the data by condition.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<TL_TongHopChamCongNhanVien> LoadDataByCondition(int pThang, int pNam, int pIdPhongBan)
        {
         
            List<TL_TongHopChamCongNhanVien> listData1 = this.Context.TL_TongHopChamCongNhanViens.Where(th => th.Thang == pThang && th.Nam == pNam ).ToList<TL_TongHopChamCongNhanVien>();
            
            var query = from chamcong in listData1
                        join nhanvien in this.Context.NV_NhanViens.Where(nv=>nv.IdPhongBan==pIdPhongBan) on chamcong.IdNhanVien equals ((NV_NhanVien)nhanvien).Id//into nhanvientemp
                       // from nvtemp in nhanvientemp
                        select new
                        {
                            Id = chamcong.Id,
                            IdNhanVien = chamcong.IdNhanVien,
                            Thang = chamcong.Thang,
                            Nam = chamcong.Nam,
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            S1 = chamcong.S1,
                            S2 = chamcong.S2,
                            S3 = chamcong.S3,
                            S4 = chamcong.S4,
                            S5 = chamcong.S5,
                            S6 = chamcong.S6,
                            S7 = chamcong.S7,
                            S8 = chamcong.S8,
                            S9 = chamcong.S9,
                            S10 = chamcong.S10,
                            S11 = chamcong.S11,
                            S12 = chamcong.S12,
                            S13 = chamcong.S13,
                            S14 = chamcong.S14,
                            S15 = chamcong.S15,
                            S16 = chamcong.S16,
                            S17 = chamcong.S17,
                            S18 = chamcong.S18,
                            S19 = chamcong.S19,
                            S20 = chamcong.S20,
                            S21 = chamcong.S21,
                            S22 = chamcong.S22,
                            S23 = chamcong.S23,
                            S24 = chamcong.S24,
                            S25 = chamcong.S25,
                            S26 = chamcong.S26,
                            S27 = chamcong.S27,
                            S28 = chamcong.S28,
                            S29 = chamcong.S29,
                            S30 = chamcong.S30,
                            S31 = chamcong.S31,

                            C1 = chamcong.C1,
                            C2 = chamcong.C2,
                            C3 = chamcong.C3,
                            C4 = chamcong.C4,
                            C5 = chamcong.C5,
                            C6 = chamcong.C6,
                            C7 = chamcong.C7,
                            C8 = chamcong.C8,
                            C9 = chamcong.C9,
                            C10 = chamcong.C10,
                            C11 = chamcong.C11,
                            C12 = chamcong.C12,
                            C13 = chamcong.C13,
                            C14 = chamcong.C14,
                            C15 = chamcong.C15,
                            C16 = chamcong.C16,
                            C17 = chamcong.C17,
                            C18 = chamcong.C18,
                            C19 = chamcong.C19,
                            C20 = chamcong.C20,
                            C21 = chamcong.C21,
                            C22 = chamcong.C22,
                            C23 = chamcong.C23,
                            C24 = chamcong.C24,
                            C25 = chamcong.C25,
                            C26 = chamcong.C26,
                            C27 = chamcong.C27,
                            C28 = chamcong.C28,
                            C29 = chamcong.C29,
                            C30 = chamcong.C30,
                            C31 = chamcong.C31,


                        };

            var result = query.ToList().ConvertAll(t => new TL_TongHopChamCongNhanVien()
            {
                Id = t.Id,
                IdNhanVien = t.IdNhanVien,
                
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Ten = t.Ten,
                S1 = t.S1,
                S2 = t.S2,
                S3 = t.S3,
                S4 = t.S4,
                S5 = t.S5,
                S6 = t.S6,
                S7 = t.S7,
                S8 = t.S8,
                S9 = t.S9,
                S10 = t.S10,
                S11 = t.S11,
                S12 = t.S12,
                S13 = t.S13,
                S14 = t.S14,
                S15 = t.S15,
                S16 = t.S16,
                S17 = t.S17,
                S18 = t.S18,
                S19 = t.S19,
                S20 = t.S20,
                S21 = t.S21,
                S22 = t.S22,
                S23 = t.S23,
                S24 = t.S24,
                S25 = t.S25,
                S26 = t.S26,
                S27 = t.S27,
                S28 = t.S28,
                S29 = t.S29,
                S30 = t.S30,
                S31 = t.S31,

                C1 = t.C1,
                C2 = t.C2,
                C3 = t.C3,
                C4 = t.C4,
                C5 = t.C5,
                C6 = t.C6,
                C7 = t.C7,
                C8 = t.C8,
                C9 = t.C9,
                C10 = t.C10,
                C11 = t.C11,
                C12 = t.C12,
                C13 = t.C13,
                C14 = t.C14,
                C15 = t.C15,
                C16 = t.C16,
                C17 = t.C17,
                C18 = t.C18,
                C19 = t.C19,
                C20 = t.C20,
                C21 = t.C21,
                C22 = t.C22,
                C23 = t.C23,
                C24 = t.C24,
                C25 = t.C25,
                C26 = t.C26,
                C27 = t.C27,
                C28 = t.C28,
                C29 = t.C29,
                C30 = t.C30,
                C31 = t.C31,
            });

            return result.ToList<TL_TongHopChamCongNhanVien>();
        }

        /// <summary>
        /// Loads the data by condition bang tong hop nhan vien.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<TL_TongHopChamCongNhanVien> LoadDataByConditionBangTongHopNhanVien(int pThang, int pNam, int pIdPhongBan)
        {

            List<TL_TongHopChamCongNhanVien> listData = this.Context.TL_TongHopChamCongNhanViens.Where(th=>th.Thang==pThang && th.Nam==pNam).ToList<TL_TongHopChamCongNhanVien>();

            var query = from chamcong in listData
                        join nhanvien in this.Context.NV_NhanViens.Where(nv=>nv.IdPhongBan==pIdPhongBan) on chamcong.IdNhanVien equals ((NV_NhanVien)nhanvien).Id //into nhanvientemp
                        //from nvtemp in nhanvientemp
                        select new
                        {
                            Id = chamcong.Id,
                            IdNhanVien = chamcong.IdNhanVien,
                          
                            Thang = chamcong.Thang,
                            Nam = chamcong.Nam,
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            S1 = chamcong.S1,
                            S2 = chamcong.S2,
                            S3 = chamcong.S3,
                            S4 = chamcong.S4,
                            S5 = chamcong.S5,
                            S6 = chamcong.S6,
                            S7 = chamcong.S7,
                            S8 = chamcong.S8,
                            S9 = chamcong.S9,
                            S10 = chamcong.S10,
                            S11 = chamcong.S11,
                            S12 = chamcong.S12,
                            S13 = chamcong.S13,
                            S14 = chamcong.S14,
                            S15 = chamcong.S15,
                            S16 = chamcong.S16,
                            S17 = chamcong.S17,
                            S18 = chamcong.S18,
                            S19 = chamcong.S19,
                            S20 = chamcong.S20,
                            S21 = chamcong.S21,
                            S22 = chamcong.S22,
                            S23 = chamcong.S23,
                            S24 = chamcong.S24,
                            S25 = chamcong.S25,
                            S26 = chamcong.S26,
                            S27 = chamcong.S27,
                            S28 = chamcong.S28,
                            S29 = chamcong.S29,
                            S30 = chamcong.S30,
                            S31 = chamcong.S31,

                            C1 = chamcong.C1,
                            C2 = chamcong.C2,
                            C3 = chamcong.C3,
                            C4 = chamcong.C4,
                            C5 = chamcong.C5,
                            C6 = chamcong.C6,
                            C7 = chamcong.C7,
                            C8 = chamcong.C8,
                            C9 = chamcong.C9,
                            C10 = chamcong.C10,
                            C11 = chamcong.C11,
                            C12 = chamcong.C12,
                            C13 = chamcong.C13,
                            C14 = chamcong.C14,
                            C15 = chamcong.C15,
                            C16 = chamcong.C16,
                            C17 = chamcong.C17,
                            C18 = chamcong.C18,
                            C19 = chamcong.C19,
                            C20 = chamcong.C20,
                            C21 = chamcong.C21,
                            C22 = chamcong.C22,
                            C23 = chamcong.C23,
                            C24 = chamcong.C24,
                            C25 = chamcong.C25,
                            C26 = chamcong.C26,
                            C27 = chamcong.C27,
                            C28 = chamcong.C28,
                            C29 = chamcong.C29,
                            C30 = chamcong.C30,
                            C31 = chamcong.C31,


                        };

            var result = query.ToList().ConvertAll(t => new TL_TongHopChamCongNhanVien()
            {
                Id=t.Id,
                IdNhanVien=t.IdNhanVien,
               
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Thang=t.Thang,
                Nam=t.Nam,
                Ten = t.Ten,
                S1 = t.S1,
                S2 = t.S2,
                S3 = t.S3,
                S4 = t.S4,
                S5 = t.S5,
                S6 = t.S6,
                S7 = t.S7,
                S8 = t.S8,
                S9 = t.S9,
                S10 = t.S10,
                S11 = t.S11,
                S12 = t.S12,
                S13 = t.S13,
                S14 = t.S14,
                S15 = t.S15,
                S16 = t.S16,
                S17 = t.S17,
                S18 = t.S18,
                S19 = t.S19,
                S20 = t.S20,
                S21 = t.S21,
                S22 = t.S22,
                S23 = t.S23,
                S24 = t.S24,
                S25 = t.S25,
                S26 = t.S26,
                S27 = t.S27,
                S28 = t.S28,
                S29 = t.S29,
                S30 = t.S30,
                S31 = t.S31,

                C1 = t.C1,
                C2 = t.C2,
                C3 = t.C3,
                C4 = t.C4,
                C5 = t.C5,
                C6 = t.C6,
                C7 = t.C7,
                C8 = t.C8,
                C9 = t.C9,
                C10 = t.C10,
                C11 = t.C11,
                C12 = t.C12,
                C13 = t.C13,
                C14 = t.C14,
                C15 = t.C15,
                C16 = t.C16,
                C17 = t.C17,
                C18 = t.C18,
                C19 = t.C19,
                C20 = t.C20,
                C21 = t.C21,
                C22 = t.C22,
                C23 = t.C23,
                C24 = t.C24,
                C25 = t.C25,
                C26 = t.C26,
                C27 = t.C27,
                C28 = t.C28,
                C29 = t.C29,
                C30 = t.C30,
                C31 = t.C31,
            });
            return result.ToList<TL_TongHopChamCongNhanVien>();
        }

        /// <summary>
        /// Checkeds the is exited tong hop cham cong nhan vien.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public bool CheckedIsExitedTongHopChamCongNhanVien(int pThang, int pNam, int pIdPhongBan)
        {
            List<TL_TongHopChamCongNhanVien> listData = this.Context.TL_TongHopChamCongNhanViens.Where(th => th.Thang == pThang && th.Nam == pNam ).ToList<TL_TongHopChamCongNhanVien>();

            if (listData.Count>0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Tras the cuu bang tong hop nhan vien.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<TL_TongHopChamCongNhanVien> TraCuuBangTongHopNhanVien(int pThang, int pNam, int pIdNhanVien)
        {
            List<TL_TongHopChamCongNhanVien> listData = this.Context.TL_TongHopChamCongNhanViens.Where(th => th.Thang == pThang && th.Nam == pNam && th.IdNhanVien == pIdNhanVien).ToList<TL_TongHopChamCongNhanVien>();

            var query = from chamcong in listData
                        join nhanvien in this.Context.NV_NhanViens on chamcong.IdNhanVien equals ((NV_NhanVien)nhanvien).Id //into nhanvientemp
                        //from nvtemp in nhanvientemp
                        select new
                        {
                            Id = chamcong.Id,
                            IdNhanVien = chamcong.IdNhanVien,
                           
                            Thang = chamcong.Thang,
                            Nam = chamcong.Nam,
                            MaNhanVien = nhanvien.MaNhanVien,
                            HoDem = nhanvien.HoDem,
                            Ten = nhanvien.Ten,
                            S1 = chamcong.S1,
                            S2 = chamcong.S2,
                            S3 = chamcong.S3,
                            S4 = chamcong.S4,
                            S5 = chamcong.S5,
                            S6 = chamcong.S6,
                            S7 = chamcong.S7,
                            S8 = chamcong.S8,
                            S9 = chamcong.S9,
                            S10 = chamcong.S10,
                            S11 = chamcong.S11,
                            S12 = chamcong.S12,
                            S13 = chamcong.S13,
                            S14 = chamcong.S14,
                            S15 = chamcong.S15,
                            S16 = chamcong.S16,
                            S17 = chamcong.S17,
                            S18 = chamcong.S18,
                            S19 = chamcong.S19,
                            S20 = chamcong.S20,
                            S21 = chamcong.S21,
                            S22 = chamcong.S22,
                            S23 = chamcong.S23,
                            S24 = chamcong.S24,
                            S25 = chamcong.S25,
                            S26 = chamcong.S26,
                            S27 = chamcong.S27,
                            S28 = chamcong.S28,
                            S29 = chamcong.S29,
                            S30 = chamcong.S30,
                            S31 = chamcong.S31,

                            C1 = chamcong.C1,
                            C2 = chamcong.C2,
                            C3 = chamcong.C3,
                            C4 = chamcong.C4,
                            C5 = chamcong.C5,
                            C6 = chamcong.C6,
                            C7 = chamcong.C7,
                            C8 = chamcong.C8,
                            C9 = chamcong.C9,
                            C10 = chamcong.C10,
                            C11 = chamcong.C11,
                            C12 = chamcong.C12,
                            C13 = chamcong.C13,
                            C14 = chamcong.C14,
                            C15 = chamcong.C15,
                            C16 = chamcong.C16,
                            C17 = chamcong.C17,
                            C18 = chamcong.C18,
                            C19 = chamcong.C19,
                            C20 = chamcong.C20,
                            C21 = chamcong.C21,
                            C22 = chamcong.C22,
                            C23 = chamcong.C23,
                            C24 = chamcong.C24,
                            C25 = chamcong.C25,
                            C26 = chamcong.C26,
                            C27 = chamcong.C27,
                            C28 = chamcong.C28,
                            C29 = chamcong.C29,
                            C30 = chamcong.C30,
                            C31 = chamcong.C31,


                        };

            var result = query.ToList().ConvertAll(t => new TL_TongHopChamCongNhanVien()
            {
                Id = t.Id,
                IdNhanVien = t.IdNhanVien,
               
                MaNhanVien = t.MaNhanVien,
                HoDem = t.HoDem,
                Thang = t.Thang,
                Nam = t.Nam,
                Ten = t.Ten,
                S1 = t.S1,
                S2 = t.S2,
                S3 = t.S3,
                S4 = t.S4,
                S5 = t.S5,
                S6 = t.S6,
                S7 = t.S7,
                S8 = t.S8,
                S9 = t.S9,
                S10 = t.S10,
                S11 = t.S11,
                S12 = t.S12,
                S13 = t.S13,
                S14 = t.S14,
                S15 = t.S15,
                S16 = t.S16,
                S17 = t.S17,
                S18 = t.S18,
                S19 = t.S19,
                S20 = t.S20,
                S21 = t.S21,
                S22 = t.S22,
                S23 = t.S23,
                S24 = t.S24,
                S25 = t.S25,
                S26 = t.S26,
                S27 = t.S27,
                S28 = t.S28,
                S29 = t.S29,
                S30 = t.S30,
                S31 = t.S31,

                C1 = t.C1,
                C2 = t.C2,
                C3 = t.C3,
                C4 = t.C4,
                C5 = t.C5,
                C6 = t.C6,
                C7 = t.C7,
                C8 = t.C8,
                C9 = t.C9,
                C10 = t.C10,
                C11 = t.C11,
                C12 = t.C12,
                C13 = t.C13,
                C14 = t.C14,
                C15 = t.C15,
                C16 = t.C16,
                C17 = t.C17,
                C18 = t.C18,
                C19 = t.C19,
                C20 = t.C20,
                C21 = t.C21,
                C22 = t.C22,
                C23 = t.C23,
                C24 = t.C24,
                C25 = t.C25,
                C26 = t.C26,
                C27 = t.C27,
                C28 = t.C28,
                C29 = t.C29,
                C30 = t.C30,
                C31 = t.C31,
            });
            return result.ToList<TL_TongHopChamCongNhanVien>();
        }
    }
}
