using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.ChamCong_TinhLuong
{
    public class TL_KhoaLuongBLL : DataAccessBase<TL_KhoaLuong>
    {
        /// <summary>
        /// Checkeds the is da tinh thuong.
        /// </summary>
        /// <param name="pThang">The p thang.</param>
        /// <param name="pNam">The p nam.</param>
        /// <returns></returns>
        ///  21/08/11
        /// DANHTTT-PC
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
