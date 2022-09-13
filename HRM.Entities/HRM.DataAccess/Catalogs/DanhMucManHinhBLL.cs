using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
   public class DanhMucManHinhBLL :DataAccessBase<DM_ManHinh>
    {
        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<DM_ManHinh> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<DM_ManHinh> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaPhongBan(DM_ManHinh pObject)
        {
            IQueryable<DM_ManHinh> phongBan = this.Context.DM_ManHinhs.Where(pb => pb.MaManHinh == pObject.MaManHinh).Select(pb => pb);
            if (phongBan.Count() > 1)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
