 
using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess.Catalogs
{
    public class DanhMucTinhBLL : DataAccessBase<DM_Tinh>
    {
        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<DM_Tinh> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<DM_Tinh> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaPhongBan(DM_Tinh pObject)
        {
            IQueryable<DM_Tinh> phongBan = this.Context.DM_Tinhs.Where(pb => pb.MaTinh == pObject.MaTinh).Select(pb => pb);
            if (phongBan.Count() > 1)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks the is used.
        /// </summary>
        /// <param name="pIdTinh">The p id tinh.</param>
        /// <returns></returns>
        public bool CheckIsUsed(int pIdTinh)
        {
            DM_Huyen huyen = this.Context.DM_Huyens.Where(h=>h.IdTinh == pIdTinh).FirstOrDefault();
            
            if (huyen != null)
            {
                return true;
            }

            return false;
        }

        #endregion
       
    }
}

