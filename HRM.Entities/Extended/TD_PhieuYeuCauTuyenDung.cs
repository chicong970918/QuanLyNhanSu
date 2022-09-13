using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRM.Entities
{
    public partial class TD_PhieuYeuCauTuyenDung : EntityBase
    {
        private string _TenPhongBan;
        private string _TenChucDanh;
        private string _TenTinhTrangHonNhan;
        private string _TenLyDo;
        private string _TenTrinhDo;
        private string _TenChuyenNganh;
        private string _TenTrinhDoTinHoc;
        private string _TenTrinhDoNgoaiNgu;

        /// <summary>
        /// Gets or sets the ten trinh do ngoai ngu.
        /// </summary>
        /// <value>The ten trinh do ngoai ngu.</value>
        public string TenTrinhDoNgoaiNgu
        {
            get { return _TenTrinhDoNgoaiNgu; }
            set
            {
                if ((this._TenTrinhDoNgoaiNgu != value))
                {
                    this._TenTrinhDoNgoaiNgu = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten trinh do tin hoc.
        /// </summary>
        /// <value>The ten trinh do tin hoc.</value>
        public string TenTrinhDoTinHoc
        {
            get { return _TenTrinhDoTinHoc; }
            set
            {
                if ((this._TenTrinhDoTinHoc != value))
                {
                    this._TenTrinhDoTinHoc = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten chuyen nganh.
        /// </summary>
        /// <value>The ten chuyen nganh.</value>
        public string TenChuyenNganh
        {
            get { return _TenChuyenNganh; }
            set
            {
                if ((this._TenChuyenNganh != value))
                {
                    this._TenChuyenNganh = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten trinh do.
        /// </summary>
        /// <value>The ten trinh do.</value>
        public string TenTrinhDo
        {
            get { return _TenTrinhDo; }
            set
            {
                if ((this._TenTrinhDo != value))
                {
                    this._TenTrinhDo = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten ly do.
        /// </summary>
        /// <value>The ten ly do.</value>
        public string TenLyDo
        {
            get { return _TenLyDo; }
            set
            {
                if ((this._TenLyDo != value))
                {
                    this._TenLyDo = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten tinh trang hon nhan.
        /// </summary>
        /// <value>The ten tinh trang hon nhan.</value>
        public string TenTinhTrangHonNhan
        {
            get { return _TenTinhTrangHonNhan; }
            set
            {
                if ((this._TenTinhTrangHonNhan != value))
                {
                    this._TenTinhTrangHonNhan = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten chuc danh.
        /// </summary>
        /// <value>The ten chuc danh.</value>
        public string TenChucDanh
        {
            get { return _TenChucDanh; }
            set
            {
                if ((this._TenChucDanh != value))
                {
                    this._TenChucDanh = value;
                }
            }
        }

        /// <summary>
        /// Gets or sets the ten phong ban.
        /// </summary>
        /// <value>The ten phong ban.</value>
        public string TenPhongBan
        {
            get { return _TenPhongBan; }
            set
            {
                if ((this._TenPhongBan != value))
                {
                    this._TenPhongBan = value;
                }
            }
        }
    }
}
