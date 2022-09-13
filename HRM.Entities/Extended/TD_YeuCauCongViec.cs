using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TD_YeuCauCongViec : EntityBase
    {
        private int _STT;

        public int STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

    }
}
