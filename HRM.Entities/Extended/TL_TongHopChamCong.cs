using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
  public partial class TL_TongHopChamCong:EntityBase
    {
        #region ---- Variables ----

        public const string F_Ngay = "Ngay";
        private string _HoDem = string.Empty;
        private string _Ten = string.Empty;
        private string _MaNhanVien = string.Empty;
        private bool _S1;
        private bool _C1;

       

        #endregion

        #region ---- Properties ----

        public bool C1
        {
            get { return _C1; }
            set { _C1 = value; }
        }

        public bool S1
        {
            get { return _S1; }
            set { _S1 = value; }
        }
        /// <summary>
        /// Gets or sets the ho dem.
        /// </summary>
        /// <value>The ho dem.</value>
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
        /// <summary>
        /// Gets or sets the ten.
        /// </summary>
        /// <value>The ten.</value>
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
        /// <summary>
        /// Gets or sets the ma nhan vien.
        /// </summary>
        /// <value>The ma nhan vien.</value>
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
