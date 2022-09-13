using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DanhMucLyDoBLL :DataAccessBase<DM_LyDo>
    {
        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<DM_LyDo> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<DM_LyDo> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaPhongBan(DM_LyDo pObject)
        {
            IQueryable<DM_LyDo> phongBan = this.Context.DM_LyDos.Where(pb => pb.MaLyDo == pObject.MaLyDo).Select(pb => pb);
            if (phongBan.Count() > 1)
            {
                return true;
            }
            return false;
        }


        #endregion
    }
}
