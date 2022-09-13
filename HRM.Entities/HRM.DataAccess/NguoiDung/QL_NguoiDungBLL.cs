using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;
namespace HRM.DataAccess.NguoiDung
{
    /// <summary>
    /// 
    /// </summary>
   public class QL_NguoiDungBLL:DataAccessBase<QL_NguoiDung>
    {
       /// <summary>
        /// Gets the ma nhan vien.
        /// </summary>
        /// <param name="pIdNhanVien">The p id nhan vien.</param>
        /// <returns></returns>
       public NV_NhanVien GetNhanVien(int pIdNhanVien)
       {
           
           NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).Id == pIdNhanVien).FirstOrDefault();
           return item;
       }

       /// <summary>
       /// Gets the nhan vien by ma nhan vien.
       /// </summary>
       /// <param name="pIdNhanVien">The p id nhan vien.</param>
       /// <returns></returns>
       public NV_NhanVien GetNhanVienByMaNhanVien(string pMaNhanVien)
       {

           NV_NhanVien item = this.Context.NV_NhanViens.Where(nv => ((NV_NhanVien)nv).MaNhanVien == pMaNhanVien).FirstOrDefault();

           return item;
       }

       /// <summary>
       /// Gets the ten phong ban.
       /// </summary>
       /// <param name="pIdPhongBan">The p id phong ban.</param>
       /// <returns></returns>
       public string GetTenPhongBan(int pIdPhongBan)
       {
           DM_PhongBan item = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id== pIdPhongBan).FirstOrDefault();
           if (item != null)
           {
               return item.TenPhongBan;
           }
           else
           {
               return string.Empty;
           }
       }

       /// <summary>
       /// Gets the nhan vien by ma nhan vien.
       /// </summary>
       /// <param name="pMaNhanVien">The p ma nhan vien.</param>
       /// <returns></returns>
       public NV_NhanVien GetNhanVienByMaNhanVien(string pMaNhanVien ,out bool IsNhanSu)
       {
           NV_NhanVien item = this.Context.NV_NhanViens.Where(uv => uv.MaNhanVien == pMaNhanVien).FirstOrDefault();

           if (item != null)
           {
               DM_PhongBan phongban = this.Context.DM_PhongBans.Where(pb => ((DM_PhongBan)pb).Id == item.IdPhongBan).FirstOrDefault();
               if (phongban != null)
               {
                   IsNhanSu = phongban.IsPhongNhanSu.Value;
               }
               else
               {
                   IsNhanSu = false;
               }
           }
           else
           {
               IsNhanSu = false;
           }
           return item;
       }

       /// <summary>
       /// Logins the specified user name.
       /// </summary>
       /// <param name="userName">Name of the user.</param>
       /// <param name="pwd">The PWD.</param>
       /// <returns></returns>
       public LoginResult Login(string userName, string pwd)
       {
           QL_NguoiDung userLogin = this.Context.QL_NguoiDungs.Where(m => m.TenDangNhap.Equals(userName) && m.MatKhau.Equals(pwd)).FirstOrDefault();

           if (userLogin == null)
           {
               return LoginResult.Invalid;
           }
           else if (userLogin.HoatDong == null || !userLogin.HoatDong.Value)
           {
               return LoginResult.Disabled;
           }

           LayerCommon.CurrentUser = new UserInfo(userLogin.Id, userLogin.TenDangNhap,userLogin.IdNhanVien,userLogin.IsNhanSu);

           return LoginResult.Success;
       }

       /// <summary>
       /// Gets the current user.
       /// </summary>
       /// <returns></returns>
       public QL_NguoiDung GetCurrentUser()
       {
           QL_NguoiDung userLogin = this.Context.QL_NguoiDungs.Where(m => m.TenDangNhap.Equals(LayerCommon.CurrentUser.UserName)).FirstOrDefault();

           return userLogin;
       }

       /// <summary>
       /// Updates the specified id nguoidung.
       /// </summary>
       /// <param name="IdNguoidung">The id nguoidung.</param>
       ///  14/10/11
       /// DANHTTT-PC
       public void Update(int IdNguoidung,bool pValue)
       {
           QL_NguoiDung nguoidung = this.Context.QL_NguoiDungs.Where(nd => ((QL_NguoiDung)nd).Id == IdNguoidung).FirstOrDefault();
           if (nguoidung != null)
           {
               nguoidung.DelFlag = pValue;
               this.Context.SubmitChanges();
           }
       }
    }
}
