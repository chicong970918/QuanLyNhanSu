using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.Catalogs;
using HRM.Entities;
using HRM.DataAccess.NguoiDung;
using Library.Class;

namespace HRM.Forms
{
    public partial class ChangePwd : BaseForm
    {
        #region ---- Member variables ----
       
        private QL_NguoiDungBLL _PassDLL;

        #endregion

        #region ---- Contructor ----

        public ChangePwd()
        {
            InitializeComponent();
        }

        #endregion

        #region ---- Private Method ----

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <returns></returns>
        private bool CheckInput()
        {
            // Check current password not empty
            if (string.IsNullOrEmpty(txtMatKhauCu.Text.Trim()))
            {
                UICommon.ShowMsgError("MSG015", lblMatKhauCu.Text.ToLower());
                this.txtMatKhauCu.Focus();
                return false;
            }

            // Check new password not empty
            if (string.IsNullOrEmpty(txtMatKhauMoi.Text.Trim()))
            {
                UICommon.ShowMsgError("MSG015", lblMatKhauMoi.Text.ToLower());
                this.txtMatKhauMoi.Focus();
                return false;
            }

            // Check confirm password not empty
            if (string.IsNullOrEmpty(txtXacNhanMatKhau.Text.Trim()))
            {
                UICommon.ShowMsgError("MSG015", lblXacNhanMatKhau.Text.ToLower());
                this.txtXacNhanMatKhau.Focus();
                return false;
            }

            // Compare new password and confirm password
            if (!string.Equals(txtMatKhauMoi.Text.Trim(), txtXacNhanMatKhau.Text.Trim()))
            {
                UICommon.ShowMsgError("MSG016", lblMatKhauMoi.Text.ToLower(), lblXacNhanMatKhau.Text.ToLower());
                this.txtMatKhauMoi.Focus();
                this.txtMatKhauMoi.SelectAll();
                return false;
            }

            return true;

        }

        /// <summary>
        /// Confirms the save data.
        /// </summary>
        private void ConfirmSaveData()
        {
            // Check input
            if (!CheckInput())
            {
                return;
            }

            _PassDLL = new  QL_NguoiDungBLL();

            // Get curent User
            QL_NguoiDung user = _PassDLL.GetCurrentUser();

            // Compare current password
            if (!string.Equals(user.MatKhau, CommonUtil.Encrypt(txtMatKhauCu.Text.Trim(), "HRM")))
            {
                UICommon.ShowMsgError("MSG016");
                this.txtMatKhauCu.Focus();
                this.txtMatKhauCu.SelectAll();
            }
            else
            {
                user.MatKhau = CommonUtil.Encrypt(txtMatKhauMoi.Text.Trim(), "HRM");
                _PassDLL.UpdateData(user);

                UICommon.ShowSplashPanelUpdateMsg();

                this.Close();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnLuu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLuu_Click(object sender, EventArgs e)
        {
            ConfirmSaveData();
        }
        /// <summary>
        /// Handles the Click event of the hrmButton2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void hrmButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        
    }
}
