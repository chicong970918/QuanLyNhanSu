using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    public partial class TD_KeHoachThuViec : EntityBase
    {
        private string _HoDem = string.Empty;
        private string _Ten;
        private string _MaNhanVien;


        public string HoDem
        {
            get
            {
                NV_NhanVien nhanVien = CacheData.GetNhanVienByMaNhanVien(IdNhanVien);
                if (nhanVien != null)
                {
                    return nhanVien.HoDem;
                }
                return string.Empty;
                ;

            }
            set { _HoDem = value; }
        }
        public string Ten
        {
            get
            {
                NV_NhanVien nhanVien = CacheData.GetNhanVienByMaNhanVien(IdNhanVien);
                if (nhanVien != null)
                {
                    return nhanVien.Ten;
                }
                return string.Empty;
                ;
            }
            set { _Ten = value; }
        }
        public string MaNhanVien
        {
            get
            {
                NV_NhanVien nhanVien = CacheData.GetNhanVienByMaNhanVien(IdNhanVien);
                if (nhanVien != null)
                {
                    return nhanVien.MaNhanVien;
                }
                return string.Empty;
                ;
            }
            set { _MaNhanVien = value; }
        }


        //////


        #region ---- Variables ----

        private string _HoDemQuanLy = string.Empty;
        private string _TenQuanLy = string.Empty;
        private string _MaNhanVienQuanLy = string.Empty;


        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the ma nhan vien quan ly.
        /// </summary>
        /// <value>The ma nhan vien quan ly.</value>
        public string MaNhanVienQuanLy
        {
            get { return _MaNhanVienQuanLy; }
            set { _MaNhanVienQuanLy = value; }
        }


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

        #endregion
    }
}
