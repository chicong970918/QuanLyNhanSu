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
    public class NV_QuyetDinhNangHeSoChuyenMonBLL : DataAccessBase<NV_QuyetDinhNangHeSoChuyenMon>
    {
        /// <summary>
        /// Gets the khen thuong by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_QuyetDinhNangHeSoChuyenMon> GetTangHeSoChuyenMonByIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuyetDinhNangHeSoChuyenMons.Where(kt => kt.IdNhanVien == pIdNhanVien).ToList<NV_QuyetDinhNangHeSoChuyenMon>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        public override void UpdateDataList(List<NV_QuyetDinhNangHeSoChuyenMon> plistData)
        {
            foreach (NV_QuyetDinhNangHeSoChuyenMon item in plistData)
            {
                if (!(item.SoQuyetDinh>0))
                {
                    int soquyetdinh = -1;
                    try
                    {
                        soquyetdinh = this.Context.NV_QuyetDinhNangHeSoChuyenMons.Select(u => u).Max(u => u.SoQuyetDinh) + 1;
                    }
                    catch
                    {
                        soquyetdinh = 1;
                    }

                    item.SoQuyetDinh = soquyetdinh;
                    NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == item.IdNhanVien).FirstOrDefault();

                    if (nhanvien != null)
                    {
                        nhanvien.IdTrinhDo = item.IdTrinhDo;
                        DM_TrinhDo trinhdo = this.Context.DM_TrinhDos.Where(td => ((DM_TrinhDo)td).Id == item.IdTrinhDo).FirstOrDefault();
                        if (trinhdo != null)
                        {
                            nhanvien.HeSoChuyenMonHienTai= trinhdo.HeSoChuyenMon;
                        }
                    }
                }
            }

            base.UpdateDataList(plistData);
        }
    }
}
