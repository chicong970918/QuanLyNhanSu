using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DM_ChiTietThuongNgayLeBLL : DataAccessBase<DM_ChiTietThuongNgayLe>
    {
        /// <summary>
        /// Loads the data bycondition.
        /// </summary>
        /// <param name="pIdThuongLe">The p id thuong le.</param>
        /// <returns></returns>
        public List<DM_ChiTietThuongNgayLe> LoadDataBycondition(int pIdThuongLe)
        {

            List < DM_ChiTietThuongNgayLe > listdata= this.Context.DM_ChiTietThuongNgayLes.Where(ct => ct.IdThuongNgayLe == pIdThuongLe).ToList<DM_ChiTietThuongNgayLe>();

            var query=from thuong in listdata
                      join chucdanh in this.Context.DM_ChucDanhs on thuong.IdChucDanh equals ((DM_ChucDanh)chucdanh).Id into chucdanhtemp
                      from tempchudanh in chucdanhtemp
                      select new 
                      {
                          TenChucDanh=tempchudanh.TenChucDanh,
                          Id=thuong.Id,
                          IdThuongNgayLe=thuong.IdThuongNgayLe,
                          IdChucDanh=thuong.IdChucDanh,
                          MucThuong=thuong.MucThuong,
                          GhiChu=thuong.GhiChu
                      };


            var result = query.ToList().ConvertAll(t => new DM_ChiTietThuongNgayLe()
          {
              TenChucDanh = t.TenChucDanh,
              Id = t.Id,
              IdThuongNgayLe = t.IdThuongNgayLe,
              IdChucDanh = t.IdChucDanh,
              MucThuong = t.MucThuong,
              GhiChu = t.GhiChu
          });

            return result.ToList<DM_ChiTietThuongNgayLe>();
        }

    }
}
