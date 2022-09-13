using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DanhMucCapTuyenDungBLL : DataAccessBase<DM_CapTuyenDung >
	{

        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<DM_CapTuyenDung> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<DM_CapTuyenDung> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaPhongBan(DM_CapTuyenDung pObject)
        {
            IQueryable<DM_CapTuyenDung> phongBan = this.Context.DM_CapTuyenDungs.Where(pb => pb.MaCapTuyenDung == pObject.MaCapTuyenDung).Select(pb => pb);
            if (phongBan.Count() > 1)
            {
                return true;
            }
            return false;
        }


        #endregion
	}
}
