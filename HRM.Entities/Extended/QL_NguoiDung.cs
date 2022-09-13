using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
 

namespace HRM.Entities
{
    public partial class QL_NguoiDung : EntityBase
    {
        #region ---- Variables ----

        private string _TenPhongBan = string.Empty;
        private string _HoDem = string.Empty;
        private string _Ten = string.Empty;
        private string _MaNhanVien = string.Empty;
        partial void OnHoDem();

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
        public string TenPhongBan
        {
            get
            {
                return this._TenPhongBan;
            }
            set
            {
                if ((this._TenPhongBan != value))
                {
                    this._TenPhongBan = value;
                }
            }
        }

        #endregion
    }
}
