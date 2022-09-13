using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.TuyenDung
{
    /// <summary>
    /// 
    /// </summary>
    public class TD_BangKeHoachTuyenDungBLL : DataAccessBase<TD_BangKeHoachTuyenDung>
    {
        /// <summary>
        /// Gets the data by phong ban.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public List<TD_BangKeHoachTuyenDung> GetDataByPhongBan(int pIdPhongBan)
        {
            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == pIdPhongBan).FirstOrDefault();

            if (phongban != null)
            {
                if (!phongban.IsPhongNhanSu.HasValue || !phongban.IsPhongNhanSu.Value)
                {
                    List<TD_BangKeHoachTuyenDung> list = this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == pIdPhongBan).ToList<TD_BangKeHoachTuyenDung>();
                    return list;
                }
                else
                {
                    List<TD_BangKeHoachTuyenDung> list = this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == pIdPhongBan ).ToList<TD_BangKeHoachTuyenDung>();
                    return list;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the data by phong ban quy.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <param name="pQuy">The p quy.</param>
        /// <returns></returns>
        public List<TD_BangKeHoachTuyenDung> GetDataByPhongBanQuy(int pIdPhongBan, int pQuy,int pNam)
        {
            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == pIdPhongBan).FirstOrDefault();

            if (phongban != null)
            {
                if (!phongban.IsPhongNhanSu.HasValue || !phongban.IsPhongNhanSu.Value)
                {
                    List<TD_BangKeHoachTuyenDung> list = this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == pIdPhongBan && td.Quy == pQuy && td.Nam==pNam).ToList<TD_BangKeHoachTuyenDung>();
                    return list;
                }
                else
                {
                    List<TD_BangKeHoachTuyenDung> list = this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == pIdPhongBan && td.Quy == pQuy && td.Nam == pNam).ToList<TD_BangKeHoachTuyenDung>();
                    return list;
                }
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the id phong ban by id nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
        public int GetIdPhongBanByIdNhanVien(int pIdNhanVien)
        {
            NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();
            if (item != null)
            {
                return item.IdPhongBan;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Gets the data by ten phong ban.
        /// </summary>
        /// <param name="pTenPhongBan">The p ten phong ban.</param>
        /// <returns></returns>
        public List<TD_BangKeHoachTuyenDung> GetDataByTenPhongBan(string pTenPhongBan)
        {
            List<TD_BangKeHoachTuyenDung> list = new List<TD_BangKeHoachTuyenDung>();

            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => pb.TenPhongBan == pTenPhongBan).FirstOrDefault();

            if (phongban != null)// checked null phongban
            {
                int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;

                NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == IdNhanVien).FirstOrDefault();

                if (item != null)// checked null user dang nhap
                {
                    DM_PhongBan phongbanNS = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.IdPhongBan).FirstOrDefault();

                    if (phongbanNS.IsPhongNhanSu.Value)// checked user is nhansu
                    {
                        return this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == phongban.Id).ToList<TD_BangKeHoachTuyenDung>();
                    }
                    else
                    {
                        if (phongban.Id == phongbanNS.Id)
                        {
                            return this.Context.TD_BangKeHoachTuyenDungs.Where(td => td.IdPhongBan == item.IdPhongBan).ToList<TD_BangKeHoachTuyenDung>();
                        }
                        else
                        {
                            return list;
                        }
                    }
                }
                else
                {
                    return list;
                }
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// Gets all phong ban.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> GetAllPhongBan()
        {
            int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;
            
            NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == IdNhanVien).FirstOrDefault();
            if (item != null)
            {
                DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.IdPhongBan).FirstOrDefault();
                if (phongban.IsPhongNhanSu.Value)
                {
                    return this.Context.DM_PhongBans.Select(pb => pb).ToList<DM_PhongBan>();
                }
                else
                {
                    return this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == phongban.Id).ToList<DM_PhongBan>();
                }
            }
            else
            {
                return this.Context.DM_PhongBans.Select(pb => pb).ToList<DM_PhongBan>();
            }
            
        }

        /// <summary>
        /// Gets all phong ban xet duyet.
        /// </summary>
        /// <returns></returns>
        public List<DM_PhongBan> GetAllPhongBanXetDuyet()
        {
            int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;

            NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == IdNhanVien).FirstOrDefault();

            if (item != null)
            {

                return this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.Id).ToList<DM_PhongBan>();
            }
            else
            {
                return this.Context.DM_PhongBans.Select(pb => pb).ToList<DM_PhongBan>();
            }

        }

        /// <summary>
        /// Gets all quy.
        /// </summary>
        /// <returns></returns>
        public List<DM_Quy> GetAllQuy()
        {
            return this.Context.DM_Quys.Select(pb => pb).ToList<DM_Quy>();
        }

        /// <summary>
        /// Gets the is phong nhan su.
        /// </summary>
        /// <param name="pIdPhongBan">The p id phong ban.</param>
        /// <returns></returns>
        public bool GetIsPhongNhanSu(int pIdPhongBan)
        {
            DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == pIdPhongBan).FirstOrDefault();
            if (phongban != null)
            {
                return phongban.IsPhongNhanSu.Value;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checkeds the is has value.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <returns></returns>
        public bool CheckedIsHasValue(int pIdKeHoach)
        {
            TD_BangKeHoachTuyenDung item = this.Context.TD_BangKeHoachTuyenDungs.Where(kh => ((TD_BangKeHoachTuyenDung)kh).Id == pIdKeHoach).FirstOrDefault();

            if (item != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Checkeds the is has value.
        /// </summary>
        /// <param name="pIdKeHoach">The p id ke hoach.</param>
        /// <returns></returns>
        public bool CheckedIsDaDuyet(int pIdKeHoach)
        {
            this.Context.Refresh(System.Data.Linq.RefreshMode.KeepCurrentValues);
            TD_BangKeHoachTuyenDung item = this.Context.TD_BangKeHoachTuyenDungs.Where(kh => ((TD_BangKeHoachTuyenDung)kh).Id == pIdKeHoach).FirstOrDefault();

            if (item != null)
            {
                return item.DaDuyet.Value;
            }
            else
            {
                return false;
            }
        }
    }
}
