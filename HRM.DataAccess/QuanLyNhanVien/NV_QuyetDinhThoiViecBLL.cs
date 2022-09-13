using System ;
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
    public class NV_QuyetDinhThoiViecBLL : DataAccessBase<NV_QuyetDinhThoiViec>
    {
        /// <summary>
        /// Gets the khen thuong by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_QuyetDinhThoiViec> GetQuyetDinhThoiViecByIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuyetDinhThoiViecs.Where(kt => kt.IdNhanVien == pIdNhanVien).ToList<NV_QuyetDinhThoiViec>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        public override void UpdateDataList(List<NV_QuyetDinhThoiViec> plistData)
        {
            foreach (NV_QuyetDinhThoiViec item in plistData)
            {
                if (!(item.SoQuyetDinh>0) )
                {
                    int soquyetdinh;
                    try
                    {
                         soquyetdinh = this.Context.NV_QuyetDinhThoiViecs.Select(u => u).Max(u => u.SoQuyetDinh) + 1;
                    }
                    catch
                    {
                        soquyetdinh = 1;
                    }
                    item.SoQuyetDinh = soquyetdinh;
                    NV_NhanVien nhanvien = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == item.IdNhanVien).FirstOrDefault();

                    if (nhanvien != null)
                    {
                        nhanvien.DaChamDutHopDong = item.DaChamDutHopDong;
                    }
                }
            }

            base.UpdateDataList(plistData);
        }
    }
}
