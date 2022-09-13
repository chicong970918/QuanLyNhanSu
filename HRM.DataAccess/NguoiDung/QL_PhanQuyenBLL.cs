using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.NguoiDung
{
    public class QL_PhanQuyenBLL : DataAccessBase<QL_PhanQuyen>
    {
        /// <summary>
        /// Gets the quyen by nhom nguoi dung.
        /// </summary>
        /// <param name="pListNhom">The p list nhom.</param>
        /// <returns></returns>
        public List<QL_PhanQuyen> GetQuyenByNhomNguoiDung(List<int> pListNhom)
        {
            var query = from manhinh in this.Context.DM_ManHinhs
                        join quyen in this.Context.QL_PhanQuyens.Where(m => pListNhom.Contains(m.IDNhomNguoiDung) && m.CoQuyen == true) on manhinh.Id equals quyen.IDManHinh into tempQuyen
                        from tQuyen in tempQuyen.DefaultIfEmpty()
                        orderby manhinh.MaManHinh
                        select new
                        {
                            IDManHinh = manhinh.Id,
                            MaManHinh = manhinh.MaManHinh,
                            CoQuyen = tQuyen == null ? false : tQuyen.CoQuyen,
                        };

            var result = query.ToList().ConvertAll(m => new QL_PhanQuyen()
            {
                IDManHinh = m.IDManHinh,
                MaManHinh = m.MaManHinh,
                CoQuyen = m.CoQuyen,
            });

            return result.ToList<QL_PhanQuyen>();
        }
    }
}
