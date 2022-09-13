using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    /// <summary>
    /// 
    /// </summary>
    public partial class TD_ChiTietKeHoachTuyenDung : EntityBase
    {

        #region ---- Variables ----

        private string _TenChucDanh = string.Empty;
        private string _TenLyDo = string.Empty;
        private int _STT;
        private string _SoLuongChu = string.Empty;
        private string _NgayCanNhanSuString = string.Empty;
       
        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the ten chuc danh.
        /// </summary>
        /// <value>The ten chuc danh.</value>
        public string TenChucDanh
        {
            get
            {
                return this._TenChucDanh;
            }
            set
            {
                if ((this._TenChucDanh != value))
                {
                    this._TenChucDanh = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten ly do.
        /// </summary>
        /// <value>The ten ly do.</value>
        public string TenLyDo
        {
            get
            {
                return this._TenLyDo;
            }
            set
            {
                if ((this._TenLyDo != value))
                {
                    this._TenLyDo = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the STT.
        /// </summary>
        /// <value>The STT.</value>
        public int STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        /// <summary>
        /// Gets or sets the so luong chu.
        /// </summary>
        /// <value>The so luong chu.</value>
        public string SoLuongChu
        {
            get { return SoLuong.HasValue ? SoLuong.Value.ToString() : string.Empty; }
            set { _SoLuongChu = value; }
        }

        public string NgayCanNhanSuString
        {
            get { return ThoiGianCanNhanSu.HasValue ? ThoiGianCanNhanSu.Value.ToString("dd/MM/yyyy") : string.Empty; }
            set { _NgayCanNhanSuString = value; }
        }

        #endregion
    }
}
