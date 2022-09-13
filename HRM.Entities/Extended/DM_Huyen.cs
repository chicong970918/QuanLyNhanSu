using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    public partial class DM_Huyen : EntityBase
    {
        private string _tenTinh;

        public string TenTinh
        {
            get { return _tenTinh; }
            set { _tenTinh = value; }
        }

        
    }
}
