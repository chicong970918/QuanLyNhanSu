using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
  public partial  class QL_PhanQuyen:EntityBase
    {
        #region ---- Member variables ----

        private string _MaManHinh = string.Empty;

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the ma man hinh.
        /// </summary>
        /// <value>The ma man hinh.</value>
        public string MaManHinh
        {
            get { return _MaManHinh; }
            set { _MaManHinh = value; }
        }

        #endregion
    }
}
