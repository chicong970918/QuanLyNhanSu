using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
  public partial  class SP_GetTongHopChamCongThangResult:EntityBase
    {
        #region ---- Variables ----

        private string _HoDem = string.Empty;
        private string _Ten = string.Empty;
        private string _MaNhanVien = string.Empty;

        #endregion

        #region ---- Properties ----


        public string HoDem
        {
            get
            {
                return _HoDem;
            }
            set
            {
                if ((this._HoDem != value))
                {
                    this._HoDem = value;
                }
            }
        }

        public string Ten
        {
            get
            {
                return _Ten;
            }
            set
            {
                if ((this._Ten != value))
                {
                    this._Ten = value;
                }
            }
        }

        public string MaNhanVien
        {
            get
            {
                return this._MaNhanVien;
            }
            set
            {
                if ((this._MaNhanVien != value))
                {
                    this._MaNhanVien = value;
                }
            }
        }

        #endregion
    }
}
