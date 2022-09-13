using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    public partial class TD_UngVien : EntityBase
    {
        #region ---- Variables ----

        private string _TenChucDanh = string.Empty;
        private string _DanTocText = string.Empty;
        private string _NoiSinhText = string.Empty;
        private string _TonGiaoText = string.Empty;
        private string _HonNhanText = string.Empty;
        private string _TenQuyetDinh = string.Empty;
        private int _SoQuyetDinh = 0;
        private DateTime? _NgayQuyetDinh;
        private DateTime? _NgayHieuLuc;
        private string _NoiDung = string.Empty;
        private string _GhiChuBoNhiem = string.Empty;
        private string _NgaySinhText = string.Empty;
        private string _NgayNhanViecText = string.Empty;
        private string _LuongThuViecText = string.Empty;
        private string _LuongChinhThucText = string.Empty;

        
       
        private bool _GioiTinhNu = false;
        private double? _DiemTB;
        private string _KetquaText = string.Empty;
 
        private bool _KetQua = false;
        private string _GioiTinhText = string.Empty;
        private string _MaKeHoach = string.Empty;
        private string _STT = string.Empty;

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the ghi chu bo nhiem.
        /// </summary>
        /// <value>The ghi chu bo nhiem.</value>
        public string GhiChuBoNhiem
        {
            get { return _GhiChuBoNhiem; }
            set { _GhiChuBoNhiem = value; }
        }

        /// <summary>
        /// Gets or sets the noi dung.
        /// </summary>
        /// <value>The noi dung.</value>
        public string NoiDung
        {
            get { return _NoiDung; }
            set { _NoiDung = value; }
        }
       
        /// <summary>
        /// Gets or sets the ngay hieu luc.
        /// </summary>
        /// <value>The ngay hieu luc.</value>
        public DateTime? NgayHieuLuc
        {
            get { return _NgayHieuLuc; }
            set { _NgayHieuLuc = value; }
        }
      
        /// <summary>
        /// Gets or sets the ngay quyet dinh.
        /// </summary>
        /// <value>The ngay quyet dinh.</value>
        public DateTime? NgayQuyetDinh
        {
            get { return _NgayQuyetDinh; }
            set { _NgayQuyetDinh = value; }
        }
 
        /// <summary>
        /// Gets or sets the so quyet dinh.
        /// </summary>
        /// <value>The so quyet dinh.</value>
        public int SoQuyetDinh
        {
            get { return _SoQuyetDinh; }
            set { _SoQuyetDinh = value; }
        }

        /// <summary>
        /// Gets or sets the ten quyet dinh.
        /// </summary>
        /// <value>The ten quyet dinh.</value>
        public string TenQuyetDinh
        {
            get { return _TenQuyetDinh; }
            set { _TenQuyetDinh = value; }
        }

        /// <summary>
        /// Gets or sets the ma ke hoach.
        /// </summary>
        /// <value>The ma ke hoach.</value>
        public string MaKeHoach
        {
            get { return _MaKeHoach; }
            set { _MaKeHoach = value; }
        }

        /// <summary>
        /// Gets or sets the diem TB.
        /// </summary>
        /// <value>The diem TB.</value>
        public double? DiemTB
        {
            get { return _DiemTB; }
            set { _DiemTB = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [ket qua].
        /// </summary>
        /// <value><c>true</c> if [ket qua]; otherwise, <c>false</c>.</value>
        public bool KetQua
        {
            get { return _KetQua; }
            set { _KetQua = value; }
        }

        /// <summary>
        /// Gets or sets the ketqua text.
        /// </summary>
        /// <value>The ketqua text.</value>
        public string KetquaText
        {
            get { return _KetquaText; }
            set { _KetquaText = value; }
        }

        /// <summary>
        /// Gets or sets the ten chuc danh.
        /// </summary>
        /// <value>The ten chuc danh.</value>
        public string ChucDanhText
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
        /// Gets or sets the noi sinh text.
        /// </summary>
        /// <value>The noi sinh text.</value>
        /// 
        public string NoiSinhText
        {
            get
            {
                return this._NoiSinhText;
            }
            set
            {
                if ((this._NoiSinhText != value))
                {
                    this._NoiSinhText = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ton giao text.
        /// </summary>
        /// <value>The ton giao text.</value>
        /// 
        public string TonGiaoText
        {
            get
            {
                return this._TonGiaoText;
            }
            set
            {
                if ((this._TonGiaoText != value))
                {
                    this._TonGiaoText = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ton giao text.
        /// </summary>
        /// <value>The ton giao text.</value>
        /// 
        public string DanTocText
        {
            get
            {
                return this._DanTocText;
            }
            set
            {
                if ((this._DanTocText != value))
                {
                    this._DanTocText = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the hon nhan text.
        /// </summary>
        /// <value>The hon nhan text.</value>
        public string HonNhanText
        {
            get
            {
                return this._HonNhanText;
            }
            set
            {
                if ((this._HonNhanText != value))
                {
                    this._HonNhanText = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the hon nhan text.
        /// </summary>
        /// <value>The hon nhan text.</value>
        public string GioiTinhText
        {
            get
            {
                if (this.GioiTinh.Value)
                {
                 return    "Nam";
                }
                else
                {
                    return "Nữ";
                }
            }
            set
            {
                if (this.GioiTinh.Value)
                {
                    _GioiTinhText = "Nam";
                }
                else
                {
                    _GioiTinhText = "Nữ";
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [gioi tinh nu].
        /// </summary>
        /// <value><c>true</c> if [gioi tinh nu]; otherwise, <c>false</c>.</value>
        public bool GioiTinhNu
        {
            get
            {
                return this._GioiTinhNu;
            }
            set
            {
                if ((this._GioiTinhNu != value))
                {
                    this._GioiTinhNu = value;
                    if (this._GioiTinhNu)
                    {
                        this._GioiTinhText = "Nữ";
                    }
                    else
                    {
                        if (this._GioiTinhNu == false)
                        {
                            this._GioiTinhText = "Nam";
                        }
                        else
                        {
                            this._GioiTinhText = string.Empty;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets or sets the STT.
        /// </summary>
        /// <value>The STT.</value>
        /// <Author>LONG LY</Author>
        /// <Date>09/07/2011</Date>
        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        /// <summary>
        /// Gets or sets the ngay sinh text.
        /// </summary>
        /// <value>The ngay sinh text.</value>
        /// <Author>LONG LY</Author>
        /// <Date>09/07/2011</Date>
        public string NgaySinhText
        {
            get
            {
                if (NgaySinh.HasValue)
                {
                    return NgaySinh.Value.ToString("dd/MM/yyyy");
                }
                else
                    return string.Empty;
            }
            set { _NgaySinhText = value; }
        }

        /// <summary>
        /// Gets or sets the ngay nhan viec text.
        /// </summary>
        /// <value>The ngay nhan viec text.</value>
        /// <Author>LONG LY</Author>
        /// <Date>09/07/2011</Date>
        public string NgayNhanViecText
        {
            get
            {
                if (NgayNhanViec.HasValue)
                {
                    return NgayNhanViec.Value.ToString("dd/MM/yyyy");
                }
                else
                    return string.Empty;
            }
            set { _NgayNhanViecText = value; }
        }

        /// <summary>
        /// Gets or sets the luong thu viec text.
        /// </summary>
        /// <value>The luong thu viec text.</value>
        /// <Author>LONG LY</Author>
        /// <Date>09/07/2011</Date>
        public string LuongThuViecText
        {
            get {
                if (LuongThuViec.HasValue)
                {
                    return LuongThuViec.ToString();
                }
                else
                    return string.Empty;

                }
            set { _LuongThuViecText = value; }
        }

        /// <summary>
        /// Gets or sets the luong chinh thuc text.
        /// </summary>
        /// <value>The luong chinh thuc text.</value>
        /// <Author>LONG LY</Author>
        /// <Date>09/07/2011</Date>
        public string LuongChinhThucText
        {
            get {
                if (LuongSauThuViec.HasValue)
                {
                    return LuongSauThuViec.Value.ToString();
                }
                else
                    return string.Empty;
            }
            set { _LuongChinhThucText = value; }
        }
    }
 #endregion
}
