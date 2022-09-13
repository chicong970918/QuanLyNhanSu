using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.TuyenDung;
using HRM.Entities;
using HRM.DataAccess.Common;
using System.Data.Linq;
using Library.Class;
using HRM.Class;
using HRM.DataAccess.ChamCong_TinhLuong;

namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF312 : BaseForm
    {
         #region ---- Variables ----

        TL_BangLuong _bangLuong = null;
        private decimal _SoTien = 0;
 
        #endregion

        #region ---- Contructors ----


        /// <summary>
        /// Initializes a new instance of the <see cref="SF309"/> class.
        /// </summary>
        public SF312()
        {
            InitializeComponent();
            this.Load += new EventHandler(SF312_Load);
        }
 
        #endregion

        #region ---- Properties ----


        /// <summary>
        /// Gets or sets the bang luong.
        /// </summary>
        /// <value>The bang luong.</value>
        public TL_BangLuong BangLuong
        {
            get { return _bangLuong; }
            set { _bangLuong = value; }
        }

        /// <summary>
        /// Gets or sets the so tien.
        /// </summary>
        /// <value>The so tien.</value>
        public decimal SoTien
        {
            get { return _SoTien; }
            set { _SoTien = value; }
        }

        #endregion

        #region ---- Events ----

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the SF309 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void SF312_Load(object sender, EventArgs e)
        {
            _bangLuong=BangLuong;
            txtHoDem.Text = _bangLuong.HoDem;
            txtMaNhanVien.Text = _bangLuong.MaNhanVien;
            txtTen.Text = _bangLuong.Ten;
            txtSoTien.Text = _bangLuong.GiamTruKhac.HasValue ? _bangLuong.GiamTruKhac.Value.ToString() : "0";
            _SoTien = _bangLuong.GiamTruKhac.HasValue ? _bangLuong.GiamTruKhac.Value :0;
            txtSoTien.Focus();
        } 

        #endregion

        /// <summary>
        /// Handles the Click event of the btnHuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnChon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnChon_Click(object sender, EventArgs e)
        {
         _SoTien=   CommonUtil.Parsedecimal(txtSoTien.Text);
         btnHuy.PerformClick();
        }

        #endregion
    }
}
