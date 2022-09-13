using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;

namespace HRM.DataAccess
{
    public class QL_NguoiDungNhomNguoiDungBLL : DataAccessBase<QL_NguoiDungNhomNguoiDung>
    {

        /// <summary>
        /// Gets the nhom nguoi dung.
        /// </summary>
        /// <returns></returns>
        public List<QL_NhomNguoiDung> GetNhomNguoiDung()
        {
            return this.Context.QL_NhomNguoiDungs.ToList<QL_NhomNguoiDung>();
        }

        /// <summary>
        /// Gets all nguoi dung.
        /// </summary>
        /// <returns></returns>
        public List<dynamic> GetAllNguoiDung()
        {
            IQueryable<dynamic> nguoiDung = (from ND in this.Context.QL_NguoiDungs
                                             from NV in this.Context.NV_NhanViens
                                             where ND.IdNhanVien == NV.Id
                                             select new
                                             {
                                                 Id = ND.Id,
                                                 TenDangNhap = ND.TenDangNhap,
                                                 HoDem = NV.HoDem,
                                                 Ten = NV.Ten
                                             });
            

            return nguoiDung.ToList();
        }

        /// <summary>
        /// Gets the nguoi dung by id nhom.
        /// </summary>
        /// <param name="pIdNhom">The p id nhom.</param>
        /// <returns></returns>
        public List<dynamic> GetNguoiDungByIdNhom(int pIdNhom)
        {
            IQueryable<dynamic> Result = (from ND in this.Context.QL_NguoiDungs
                                          from Ql in this.Context.QL_NguoiDungNhomNguoiDungs
                                          where ND.Id == Ql.IdNguoiDung
                                          && Ql.IdNhomNguoiDung == pIdNhom
                                          from NV in this.Context.NV_NhanViens
                                          where ND.IdNhanVien == NV.Id
                                          select new
                                              {
                                                  Id = Ql.Id,
                                                  TenDangNhap = ND.TenDangNhap,
                                                  HoDem = NV.HoDem,
                                                  Ten = NV.Ten
                                              });


            return Result.ToList();
        }

        /// <summary>
        /// Updates the nguoi dung to nhom.
        /// </summary>
        public void UpdateNguoiDungToNhom(List<int> pList, int pIdNhom)
        {
            foreach (int nd in pList)
            {
                QL_NguoiDungNhomNguoiDung ql = this.Context.QL_NguoiDungNhomNguoiDungs.Where(q => q.IdNguoiDung == nd && q.IdNhomNguoiDung == pIdNhom).FirstOrDefault(); ;
                if (ql == null)
                {
                    QL_NguoiDungNhomNguoiDung newItem = new QL_NguoiDungNhomNguoiDung();
                    
                    newItem.IdNguoiDung = nd;
                    newItem.IdNhomNguoiDung = pIdNhom;

                    this.Context.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(newItem);

                    this.Context.SubmitChanges();
                }
            }
 
        }

        /// <summary>
        /// Deletes the nguoi dung trong nhom.
        /// </summary>
        /// <param name="pList">The p list.</param>
        /// <param name="pIdNhom">The p id nhom.</param>
        /// <returns></returns>
        public bool DeleteNguoiDungTrongNhom(List<int> pList, int pIdNhom)
        {
            foreach (int nd in pList)
            {
                QL_NguoiDungNhomNguoiDung item = this.Context.QL_NguoiDungNhomNguoiDungs.Where(q => ((QL_NguoiDungNhomNguoiDung)q).Id == nd).FirstOrDefault();

                    this.Context.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(item);

                    // Save change
                    this.Context.SubmitChanges();
            }
            return true;
        }

        /// <summary>
        /// Gets the nhom by nguoi dung.
        /// </summary>
        /// <param name="pIdNguoiDung">The p id nguoi dung.</param>
        /// <returns></returns>
        public List<int> GetNhomByNguoiDung(int pIdNguoiDung)
        {
            var query = this.Context.QL_NguoiDungNhomNguoiDungs.Where(m => m.IdNguoiDung == pIdNguoiDung).Select(m => m.IdNhomNguoiDung);

            return query.ToList<int>();
        }       

    }
}
