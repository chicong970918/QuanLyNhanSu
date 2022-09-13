using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
 public   class DM_ThuongNgayLeBLL : DataAccessBase<DM_ThuongNgayLe>
    {
        #region ---- Public Methods ----

        /// <summary>
        /// Loads all data.
        /// </summary>
        /// <returns></returns>
     public List<DM_ThuongNgayLe> LoadAllData()
     {
         List<DM_ThuongNgayLe> list = this.GetAll();
         return list;
     }

        #endregion
    }
}
