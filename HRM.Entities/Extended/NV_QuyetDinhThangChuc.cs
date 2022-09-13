using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
  public partial  class NV_QuyetDinhThangChuc:EntityBase
    {
      private string _TenChucDanh = string.Empty;

      #region ---- Properties ----

      /// <summary>
      /// Gets or sets the ten chuc danh.
      /// </summary>
      /// <value>The ten chuc danh.</value>
      public string TenChucDanh
      {
          get
          {
              return this._TenChucDanh;
          }
          set
          {
              if ((this._TenChucDanh != value))
              {
                  this._TenChucDanh = value;
              }
          }
      }

      #endregion
    }
}
