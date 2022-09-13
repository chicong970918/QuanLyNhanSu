
using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DM_BieuMauBLL : DataAccessBase<DM_BieuMau>
    {
        /// <summary>
        /// Gets the bieu mau by ma.
        /// </summary>
        /// <param name="pMa">The p ma.</param>
        /// <returns></returns>
        ///  05/07/11
        /// PC
        public DM_BieuMau GetBieuMauByMau(string pMa)
        {
            DM_BieuMau bieumau = this.Context.DM_BieuMaus.Where(bm => bm.MaBieuMau == pMa).FirstOrDefault();

            return bieumau;

        }
    }
}
