using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.QuanLyNhanVien
{
  public  class NV_QuyetDinhKyLuatBLL :DataAccessBase<NV_QuyetDinhKyLuat>
    {
        /// <summary>
        /// Gets the khen thuong by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
      public List<NV_QuyetDinhKyLuat> GetKyLuatByIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuyetDinhKyLuats.Where(kt => kt.IdNhanVien == pIdNhanVien).ToList<NV_QuyetDinhKyLuat>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
      public override void UpdateDataList(List<NV_QuyetDinhKyLuat> plistData)
        {
            foreach (NV_QuyetDinhKyLuat item in plistData)
            {
                if (!(item.SoQuyetDinh >0))
                {
                    int soquyetdinh = -1;
                    try
                    {
                        soquyetdinh = this.Context.NV_QuyetDinhKyLuats.Select(u => u).Max(u => u.SoQuyetDinh) + 1;
                    }
                    catch
                    {
                        soquyetdinh = 1;
                    }
                    item.SoQuyetDinh = soquyetdinh;
                }
            }

            base.UpdateDataList(plistData);
        }
    }
}
