using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.TuyenDung
{
   public class ThongBaoTuyenDungBLL
    {

        /// <summary>
        /// Gets all quy.
        /// </summary>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>08/06/2011</Date>
       public List<DM_Quy> GetAllQuy()
       {
           return CacheData.Context.DM_Quys.Select(q => ((DM_Quy)(q))).ToList<DM_Quy>();
       }

       /// <summary>
       /// Gets the phieu yeu cau tuyen dung by condition.
       /// </summary>
       /// <param name="pQuy">The p quy.</param>
       /// <param name="pNam">The p nam.</param>
       /// <returns></returns>
       /// <Author>LONG LY</Author>
       /// <Date>09/06/2011</Date>
       public List<IGrouping<int, TD_PhieuYeuCauTuyenDung>> GetPhieuYeuCauTuyenDungByCondition(int pQuy, int pNam)
       {
           List<IGrouping<int, TD_PhieuYeuCauTuyenDung>> pList = CacheData.Context.TD_PhieuYeuCauTuyenDungs.
               Where(yc => ((TD_PhieuYeuCauTuyenDung)(yc)).Quy == pQuy && ((TD_PhieuYeuCauTuyenDung)(yc)).Nam == pNam
                   && ((TD_PhieuYeuCauTuyenDung)(yc)).DaDuyet == true).GroupBy(t => t.IdChucDanh).ToList();

           return pList;
       }
    }
}
