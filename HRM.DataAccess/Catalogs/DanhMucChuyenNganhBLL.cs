using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    /// <summary>
    /// 
    /// </summary>
    public class DanhMucChuyenNganhBLL:DataAccessBase<DM_ChuyenNganh>
    {
        #region ---- Public Methods ----

        /// <summary>
        /// Loads all data.
        /// </summary>
        /// <returns></returns>
        public List<DM_ChuyenNganh> LoadAllData()
        {
            List<DM_ChuyenNganh> list = this.GetAll();
            foreach (DM_ChuyenNganh item in list)
            {
                item.State = CacheData.OjectState.Unchaged.ToString();
            }

            return list;
        }


        public bool Closing(List<DM_ChuyenNganh> pList)
        {
              
            foreach(DM_ChuyenNganh item in pList)
            {
                var t = this.Context.DM_ChuyenNganhs.GetModifiedMembers(item);

               
            }
            if (pList.Where(cn => cn.State == CacheData.OjectState.Added.ToString() 
                                                      || cn.State == CacheData.OjectState.Modified.ToString()).Count() > 0)
            {
                return false;
            }
            return true;
        }

        #endregion
    }
}
