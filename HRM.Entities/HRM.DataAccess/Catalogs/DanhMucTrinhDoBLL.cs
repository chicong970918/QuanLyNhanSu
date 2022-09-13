using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DanhMucTrinhDoBLL :DataAccessBase<DM_TrinhDo>
    {
        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<DM_TrinhDo> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<DM_TrinhDo> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaTrinhDo(DM_TrinhDo pObject)
        {
            IQueryable<DM_TrinhDo> trinhDo = this.Context.DM_TrinhDos.Where(pb => pb.MaTrinhDo == pObject.MaTrinhDo).Select(pb => pb);
            
            if (trinhDo.Count() > 1)
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
