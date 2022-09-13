using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;
namespace HRM.DataAccess.TuyenDung
{
    public class TD_YeuCauCongViecBLL : DataAccessBase<TD_YeuCauCongViec>
    {
        public List<TD_YeuCauCongViec> GetYeuCauByChiTiet(int pIdChiTietKeHoach)
        {
            List<TD_YeuCauCongViec> list = this.Context.TD_YeuCauCongViecs.Where(yc => yc.IdChiTietKeHoachThuViec == pIdChiTietKeHoach).ToList<TD_YeuCauCongViec>();

            return list;
        }
        /// <summary>
        /// Checkeds the phan quyen.
        /// </summary>
        /// <param name="pValuePhongBan">if set to <c>true</c> [p value phong ban].</param>
        /// <returns></returns>
        public bool CheckedPhanQuyen(bool pValuePhongBan)
        {
            int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue ? LayerCommon.CurrentUser.IdNhanVien.Value : -1;

            NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == IdNhanVien).FirstOrDefault();

            if (item != null)// checked null user dang nhap
            {
                DM_PhongBan phongbanNS = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.IdPhongBan).FirstOrDefault();

                if (phongbanNS != null)
                {
                    if (pValuePhongBan == phongbanNS.IsPhongNhanSu.Value)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

            return false;
        }


        /// <summary>
        /// Gets the yeu cau by id ung vien.
        /// </summary>
        /// <param name="pIdUngVien">The p id ung vien.</param>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        public TD_YeuCauCongViec GetYeuCauByIdUngVien(int pIdUngVien)
        {
            TD_ChiTietKeHoachThuViec chiTiet = this.Context.TD_ChiTietKeHoachThuViecs.Where(ct => ((TD_ChiTietKeHoachThuViec)(ct)).IdUngVien == pIdUngVien).FirstOrDefault();
            if (chiTiet != null)
            {
                return this.Context.TD_YeuCauCongViecs.Where(yc => ((TD_YeuCauCongViec)(yc)).IdChiTietKeHoachThuViec == chiTiet.Id).FirstOrDefault();
            }
            return null;
        }
    }
}
