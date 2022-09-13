using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HRM.Entities;
using HRM.DataAccess.Common;

namespace HRM.DataAccess.NguoiDung
{
  public  class DM_ManHinhBLL : DataAccessBase<DM_ManHinh>
    {
        /// <summary>
        /// Gets the man hinh by ID nhom.
        /// </summary>
        /// <param name="pIDNhom">The p ID nhom.</param>
        /// <returns></returns>
      public List<SP_PhanQuyenResult> GetManHinhByIDNhom(int pIDNhom)
      {
          return this.Context.SP_PhanQuyen(pIDNhom).ToList<SP_PhanQuyenResult>();
      }

      /// <summary>
      /// Caps the nhat quyen.
      /// </summary>
      /// <param name="list">The list.</param>
      /// <param name="pIDnhomnguoidung">The p I dnhomnguoidung.</param>
      public void CapNhatQuyen(List<SP_PhanQuyenResult> list, int pIDnhomnguoidung)
      {
          foreach (SP_PhanQuyenResult item in list)
          {
              QL_PhanQuyen quyen = this.Context.QL_PhanQuyens.Where(q => q.IDManHinh == item.Id && q.IDNhomNguoiDung == pIDnhomnguoidung).FirstOrDefault();

              if (quyen == null)
              {
                  quyen = new QL_PhanQuyen()
                  {
                      IDNhomNguoiDung = pIDnhomnguoidung,
                      IDManHinh = item.Id,
                      CoQuyen = item.CoQuyen == null ? false : true
                  };

                  //quyen.MarkAsAdded();

                  this.Context.QL_PhanQuyens.InsertOnSubmit(quyen);
              }
              else
              {
                  quyen.CoQuyen = (bool)item.CoQuyen;
              }
          }

          Context.SubmitChanges();
      }
    }
}
