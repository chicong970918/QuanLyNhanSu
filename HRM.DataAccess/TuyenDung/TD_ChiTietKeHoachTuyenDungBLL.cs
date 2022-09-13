using System ;
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
    public class TD_ChiTietKeHoachTuyenDungBLL : DataAccessBase<TD_ChiTietKeHoachTuyenDung>
    {
        /// <summary>
        /// Loads all data.
        /// </summary>
        /// <param name="pIDKeHoach">The p ID ke hoach.</param>
        /// <returns></returns>
        public List<TD_ChiTietKeHoachTuyenDung> LoadAllData(int pIDKeHoach)
        {
            List<TD_ChiTietKeHoachTuyenDung> listct = this.Context.TD_ChiTietKeHoachTuyenDungs.Where(ctkh => ctkh.IdBangKeHoachTuyenDung == pIDKeHoach).ToList<TD_ChiTietKeHoachTuyenDung>();

            var querychitiet = from ct in listct
                               join cd in this.Context.DM_ChucDanhs on ct.IdChucDanh equals cd.Id into tmpChucDanh
                               from tcd in tmpChucDanh.DefaultIfEmpty()
                               join ld in this.Context.DM_LyDos on ct.IdLyDo equals ld.Id into tempLyDo
                               from tld in tempLyDo.DefaultIfEmpty()
                               select new
                               {
                                   Id = ct.Id,
                                   MaChiTietTD = ct.MaChiTietTD,
                                   IdKeHoachTD = ct.IdBangKeHoachTuyenDung,
                                   IdChucDanh = ct.IdChucDanh,
                                   IdLyDo = ct.IdLyDo,
                                   TenChucDanh = tcd.TenChucDanh == null ? string.Empty : tcd.TenChucDanh,
                                   SoLuong = ct.SoLuong,
                                   ThoiGianCanNhanSu = ct.ThoiGianCanNhanSu,
                                   TenLyDo = tld == null ? string.Empty : tld.TenLyDo,
                                   GhiChu = ct.GhiChu
                               };

            var result = querychitiet.ToList().ConvertAll(t => new TD_ChiTietKeHoachTuyenDung()
          {
              Id = t.Id,
              MaChiTietTD = t.MaChiTietTD,
              IdBangKeHoachTuyenDung = t.IdKeHoachTD,
              IdChucDanh = t.IdChucDanh,
              IdLyDo = t.IdLyDo,
              TenChucDanh = t.TenChucDanh,
              TenLyDo = t.TenLyDo,
              ThoiGianCanNhanSu = t.ThoiGianCanNhanSu,
              GhiChu = t.GhiChu,
              SoLuong = t.SoLuong

          }).OrderBy(ct => ct.MaChiTietTD);

            return result.ToList<TD_ChiTietKeHoachTuyenDung>();
        }

        /// <summary>
        /// Checkeds the is using.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <returns></returns>
        public bool CheckedIsUsing(int pIdKeHoach)
        {
            TD_ChiTietKeHoachTuyenDung item = this.Context.TD_ChiTietKeHoachTuyenDungs.Where(ct => ct.IdBangKeHoachTuyenDung == pIdKeHoach).FirstOrDefault();

            if (item != null)
            {
                return true;
            }

            return false;
        }
    }
}
