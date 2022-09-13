using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TL_ChamCong : EntityBase
    {
        #region ---- Variables ----

        private string _MaNhanVien = string.Empty;
        private string _HoDem = string.Empty;
        private string _Ten = string.Empty;
        private bool? _GioiTinh = false;
        private string _GioiTinhText = string.Empty;
        private DateTime? _NgaySinh;

  
        #endregion

        #region ---- Properties ----

        public string MaNhanVien
        {
            get { return _MaNhanVien; }
            set { _MaNhanVien = value; }
        }
        
        public string HoDem
        {
            get { return _HoDem; }
            set { _HoDem = value; }
        }

        public string Ten
        {
            get { return _Ten; }
            set { _Ten = value; }
        }

        public bool? GioiTinh
        {
            get { return _GioiTinh; }
            set { _GioiTinh = value; }
        }

        public string GioiTinhText
        {
            get 
            {
                if (_GioiTinh.HasValue && _GioiTinh.Value==true)
                {
                    return "Nam";
                }
                else
                {
                    return "Nữ";
                }
            }
            set
            {
                _GioiTinhText = value;
            }
        }

        public DateTime? NgaySinh
        {
            get { return _NgaySinh; }
            set { _NgaySinh = value; }
        } 

        #endregion
    }
}
