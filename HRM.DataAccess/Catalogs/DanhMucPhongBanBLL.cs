using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.Catalogs
{
    public class DanhMucPhongBanBLL : DataAccessBase<DM_PhongBan>
    {
        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> LoadData()
        {
            return this.GetAll();
        }

        /// <summary>
        /// Updates the data list.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        public override void UpdateDataList(List<DM_PhongBan> pObject)
        {

            base.UpdateDataList(pObject);
        }

        /// <summary>
        /// Checks the is exitted ma phong ban.
        /// </summary>
        /// <param name="pObject">The p object.</param>
        /// <returns></returns>
        public bool CheckIsExittedMaPhongBan(DM_PhongBan pObject)
        {
            IQueryable<DM_PhongBan> phongBan = this.Context.DM_PhongBans.Where(pb => pb.MaPhongBan == pObject.MaPhongBan).Select(pb => pb);

            if (phongBan.Count() > 1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Gets the phong ban by ID.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public DM_PhongBan GetPhongBanByID(int pIdPhongBan)
        {
            return this.Context.DM_PhongBans.Where(p => ((DM_PhongBan)(p)).Id == pIdPhongBan).FirstOrDefault();
        }

        /// <summary>
        /// Gets the phong ban.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> GetPhongBan()
        {
            UserInfo _user = LayerCommon.CurrentUser;
            if (_user.IdNhanVien == null || _user.IsPhongNhanSu == true)
            {
                return this.Context.DM_PhongBans.Select(pb => pb).ToList();
            }
            else
            {
                int userPhongBan = (from Pb in this.Context.DM_PhongBans
                                    from Nv in this.Context.NV_NhanViens
                                    where Pb.Id == Nv.IdPhongBan
                                    && Nv.Id == _user.IdNhanVien
                                    select Pb).FirstOrDefault().Id;

                return this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)(pb)).Id == userPhongBan).ToList();
            }
        }

        #endregion
       
    }
}
