using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.QuanLyNhanVien
{
    public class NV_QuyetDinhNangHeSoLuongBLL : DataAccessBase<NV_QuyetDinhNangHeSoLuong>
    {
        /// <summary>
        /// Gets the khen thuong by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_QuyetDinhNangHeSoLuong> GetKyLuatByIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuyetDinhNangHeSoLuongs.Where(kt => kt.IdNhanVien == pIdNhanVien).ToList<NV_QuyetDinhNangHeSoLuong>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        public override void UpdateDataList(List<NV_QuyetDinhNangHeSoLuong> plistData)
        {
            foreach (NV_QuyetDinhNangHeSoLuong item in plistData)
            {
                if (!(item.SoQuyetDinh>0))
                {
                    int soquyetdinh = -1;
                    try
                    {
                        soquyetdinh = this.Context.NV_QuyetDinhNangHeSoLuongs.Select(u => u).Max(u => u.SoQuyetDinh) + 1;
                    }
                    catch
                    {
                        soquyetdinh = 1;
                    }
                    item.SoQuyetDinh = soquyetdinh;
                    NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == item.IdNhanVien).FirstOrDefault();

                    if (nhanvien != null)
                    {
                        nhanvien.HeSoLuongHienTai =decimal.Parse(  item.HeSoLuong.ToString());
                    }
                }
            }

            base.UpdateDataList(plistData);
        }
    }
}
