using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TD_ChiTietKeHoachThuViec : EntityBase
    {
        #region ---- Variables ----

        private string _HoDemQuanLy = string.Empty;
        private string _TenQuanLy = string.Empty;
        private int _STT = 0;
       
        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the ho dem qun ly.
        /// </summary>
        /// <value>The ho dem qun ly.</value>
        public string HoDemQuanLy
        {
            get
            {
                return _HoDemQuanLy;
            }
            set
            {
                if ((this._HoDemQuanLy != value))
                {
                    this._HoDemQuanLy = value;
                }
            }
        }
        /// <summary>
        /// Gets or sets the ten quan ly.
        /// </summary>
        /// <value>The ten quan ly.</value>
        public string TenQuanLy
        {
            get
            {
                return _TenQuanLy;
            }
            set
            {
                if ((this._TenQuanLy != value))
                {
                    this._TenQuanLy = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the STT.
        /// </summary>
        /// <value>The STT.</value>
        /// <Author>LONG LY</Author>
        /// <Date>23/06/2011</Date>
        public int STT
        {
            get { return _STT; }
            set { _STT = value; }
        }
        #endregion
    }
}
