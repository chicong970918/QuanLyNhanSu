using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
   public class DanhMucChucDanhBLL : DataAccessBase<DM_ChucDanh>
    {

        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
       public List<DM_ChucDanh> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
       public override void UpdateDataList(List<DM_ChucDanh> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
       public bool CheckIsExittedMaPhongBan(DM_ChucDanh pObject)
        {
            IQueryable<DM_ChucDanh> phongBan = this.Context.DM_ChucDanhs.Where(pb => pb.MaChucDanh == pObject.MaChucDanh).Select(pb => pb);
            if (phongBan.Count() > 1)
            {
                return true;
            }
            return false;
        }


        #endregion
    }
}
