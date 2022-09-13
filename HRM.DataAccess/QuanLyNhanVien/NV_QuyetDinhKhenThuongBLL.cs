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
    public class NV_QuyetDinhKhenThuongBLL : DataAccessBase<NV_QuyetDinhKhenThuong>
    {
        /// <summary>
        /// Gets the khen thuong by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public List<NV_QuyetDinhKhenThuong> GetKhenThuongByIdNhanVien(int pIdNhanVien)
        {
            return this.Context.NV_QuyetDinhKhenThuongs.Where(kt=>kt.IdNhanVien==pIdNhanVien).ToList<NV_QuyetDinhKhenThuong>();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="plistData">The plist data.</param>
        public override void UpdateDataList(List<NV_QuyetDinhKhenThuong> plistData)
        {
            foreach (NV_QuyetDinhKhenThuong item in plistData)
            {
                if (!(item.SoQuyetDinh >0))
                {
                    int soquyetdinh = -1;
                    try
                    {
                        soquyetdinh = this.Context.NV_QuyetDinhKhenThuongs.Select(u => u).Max(u => u.SoQuyetDinh) + 1;
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


        /// <summary>
        /// Checkeds the is da tinh thuong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        ///  21/08/11
        /// PC
        public bool CheckedIsDaTinhThuong(int pThang, int pNam)
        {
            TL_KhoaLuong khoaluong = this.Context.TL_KhoaLuongs.Where(kl => kl.Thang == pThang && kl.Nam == pNam).FirstOrDefault();

            if (khoaluong != null)
            {
                return false;
            }

            return true;
        }
    }
}
