using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess
{
    public class QL_NhomNguoiDungBLL : DataAccessBase<QL_NhomNguoiDung>
    {
        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<QL_NhomNguoiDung> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<QL_NhomNguoiDung> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaNhom(QL_NhomNguoiDung pObject)
        {
            IQueryable<QL_NhomNguoiDung> phongBan = this.Context.QL_NhomNguoiDungs.Where(pb => pb.MaNhom == pObject.MaNhom).Select(pb => pb);

            if (phongBan.Count() > 1)
            {
                return false;
            }
            return true;
        }


        #endregion
    }
}
