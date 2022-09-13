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
    public partial class SF305 : DanhMucBase
    {
        private TL_ChamCongBLL _bussChamCong = null;

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF305"/> class.
        /// </summary>
        public SF305()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSave.Visible = false;
            this.btnExcel.Visible = false;
            this.btnPrint.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.toolStripSeparator3.Visible = false;
            _bussChamCong = new TL_ChamCongBLL();
            this.btnSearch.Image = HRM.Properties.Resources.Process;
            this.btnSearch.Text = "Đổ dữ liệu";
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
        }
 
        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Checkeds the befor process.
        /// </summary>
        /// <returns></returns>
        private bool CheckedBeforProcess()
        {
            if (string.IsNullOrEmpty(txtThang.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lbThang.Text);
                this.txtThang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNam.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lblNam.Text);
                this.txtNam.Focus();
                return false;
            }
            if (CommonUtil.IsInt(txtNam.Text) < CacheData.Context.GetSystemDate().Year)
            {
                UICommon.ShowMsgInfo("MSG017", lblNam.Text, "năm hiện tại");
                this.txtNam.Focus();
                return false;
            }

            return true;
        } 

        #endregion

        #region ---- Events ----

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckedBeforProcess())
            {
                if (_bussChamCong.CheckedDataDoDuLieu(CommonUtil.IsInt( txtThang.Text), CommonUtil.IsInt( txtNam.Text)))
                {
                    UICommon.ShowMsgInfo("MSG035",txtThang.Text,txtNam.Text);
                    return;
                }

                if (_bussChamCong.CheckedDuLieuChamCong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
                {
                    UICommon.ShowMsgInfo("MSG009");
                    return;
                }

                UICommon.StartProcess();
                _bussChamCong.DoDuLieuChamCong(CommonUtil.IsInt( txtThang.Text), CommonUtil.IsInt( txtNam.Text));
                UICommon.StopProcess();
                UICommon.ShowMsgInfo("MSG042");
                return;
            }
        }   

        #endregion

        #endregion

    }
}
