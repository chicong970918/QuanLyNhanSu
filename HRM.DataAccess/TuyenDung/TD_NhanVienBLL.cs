using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.TuyenDung
{
    public class TD_NhanVienBLL : DataAccessBase<NV_NhanVien>
    {
        /// <summary>
        /// Gets the nhan vien by ma nhan vien.
        /// </summary>
        /// <returns></returns>
        public NV_NhanVien GetNhanVienByMaNhanVien(string pMaNhanVien)
        {
            return this.Context.NV_NhanViens.Where(nv => nv.MaNhanVien == pMaNhanVien).FirstOrDefault();
        }

        /// <summary>
        /// Gets the nhan vien by ma nhan vien.
        /// </summary>
        /// <param name="pMaNhanVien">The p ma nhan vien.</param>
        /// <returns></returns>
        public NV_NhanVien GetNhanVienByIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)(nv)).Id == pIdNhanVien).FirstOrDefault();
        }
    }
}
