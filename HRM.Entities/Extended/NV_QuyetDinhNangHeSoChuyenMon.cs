using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
  public partial  class NV_QuyetDinhNangHeSoChuyenMon:EntityBase
    {
      private string _TenTrinhDo = string.Empty;
     
      public string TenTrinhDo
      {
          get
          {
              return this._TenTrinhDo;
          }
          set
          {
              if ((this._TenTrinhDo != value))
              {
                  this._TenTrinhDo = value;
              }
          }
      }

    }
}
