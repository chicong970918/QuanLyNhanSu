using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DanhMucHuyenBLL : DataAccessBase<DM_Huyen>
    {
        #region Public Methods

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaPhongBan(DM_Huyen pObject)
        {
            IQueryable<DM_Huyen> phongBan = this.Context.DM_Huyens.Where(pb => pb.MaHuyen == pObject.MaHuyen).Select(pb => pb);
            if (phongBan.Count() > 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Gets all tinh.
        /// </summary>
        /// <returns></returns>
        public List<DM_Tinh> GetAllTinh()
        {
            return this.Context.DM_Tinhs.Select(t => t).ToList();
        }

        /// <summary>
        /// Gets the huyen by ID tinh.
        /// </summary>
        /// <param name="pIdTinh">The p id tinh.</param>
        /// <returns></returns>
        public List<DM_Huyen> GetHuyenByIDTinh(int pIdTinh)
        {
            return  this.GetAll().Where(h => h.IdTinh == pIdTinh).ToList();
        }
 
        #endregion
       
    }
}

