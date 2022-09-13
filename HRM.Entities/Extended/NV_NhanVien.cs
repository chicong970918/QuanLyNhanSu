using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
   public partial class NV_NhanVien :EntityBase
    {
       private string _GioiTinhText = string.Empty;
       private string _STT = string.Empty;
       private string _TenChucDanh = string.Empty;
       private string _NgaySinhText = string.Empty;
       private string _SoDienThoaiText = string.Empty;

       #region ---- Properties ----

       /// <summary>
       /// Gets or sets the hon nhan text.
       /// </summary>
       /// <value>The hon nhan text.</value>
       public string GioiTinhText
       {
           get
           {
               if (this.GioiTinh.HasValue && this.GioiTinh.Value)
               {
                   return "Nam";
               }
               else
               {
                   return "Nữ";
               }
           }
           set
           {
               if (this.GioiTinh.HasValue && this.GioiTinh.Value)
               {
                   _GioiTinhText = "Nam";
               }
               else
               {
                   _GioiTinhText = "Nữ";
               }
           }
       }

       public string STT
       {
           get { return _STT; }
           set { _STT = value; }
       }

       public string TenChucDanh
       {
           get { return _TenChucDanh; }
           set { _TenChucDanh = value; }
       }

       public string NgaySinhText
       {
           get {
               if (NgaySinh.HasValue)
               {
                   return NgaySinh.Value.ToString("dd/MM/yyyy");
               }
               else
               {
                   return string.Empty;
               }
               ; }
           set { _NgaySinhText = value; }
       }

       /// <summary>
       /// Gets or sets the so dien thoai text.
       /// </summary>
       /// <value>The so dien thoai text.</value>
       /// <Author>LONG LY</Author>
       /// <Date>09/07/2011</Date>
       public string SoDienThoaiText
       {
           get {
               if (string.IsNullOrEmpty(SoDienThoai))
               {
                   return string.Empty;
               }
               else
                   return SoDienThoai;
           }
           set { _SoDienThoaiText = value; }
       }


       #endregion
        
    }
}
