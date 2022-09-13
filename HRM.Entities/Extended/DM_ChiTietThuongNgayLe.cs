using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
  public partial  class DM_ChiTietThuongNgayLe:EntityBase
    {
        private string _TenChucDanh = string.Empty;

        public string TenChucDanh
        {
            get { return _TenChucDanh; }
            set { _TenChucDanh = value; }
        }
    }
}
