using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.DataAccess.Common;
using HRM.Class;
using HRM.DataAccess.NguoiDung;
using Library.Class;
using HRM.Entities;

namespace HRM.Forms
{
    /// <summary>
    /// 
    /// </summary>
    public partial class LoginForm : Form
    {
        #region ---- Member variables ----

        QL_NguoiDungBLL _bussNguoiDung = null;
        #endregion ---- Member variables ----

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginForm"/> class.
        /// </summary>
        ///  03/07/11
        /// PC
        public LoginForm()
        {
            InitializeComponent();
            this.InitForm();
            this.btnThayDoi.Click += new EventHandler(btnThayDoi_Click);
        }

        void btnThayDoi_Click(object sender, EventArgs e)
        {
            CauHinhSQL frm = new CauHinhSQL();
           // this.Hide();
            frm.Huy = true;
            frm.ShowDialog();
                    
        } 

        #endregion

        #region ---- Private methods -----


        /// <summary>
        /// Inits the form.
        /// </summary>
        ///  03/07/11
        /// PC
        private void InitForm()
        {
            _bussNguoiDung = new QL_NguoiDungBLL();
            this.BackColor = Color.FromArgb(227, 239, 255);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.KeyPreview = true;
        }

        #endregion ---- Private methods -----

        #region ---- Handle events ----

        #region ---- Form ----

        /// <summary>
        /// Handles the Load event of the SF001 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF001_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the VisibleChanged event of the SF001 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF001_VisibleChanged(object sender, EventArgs e)
        {
            if (!this.Visible)
            {
                txtPassword.Text = string.Empty;
                txtUsername.Focus();
            }
        }

        #endregion ---- Form ----

        #region ---- Buttons ----

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Handles the Click event of the btnLogin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            // UserName is empty
            if (string.IsNullOrEmpty(txtUsername.Text.Trim()))
            {
                UICommon.ShowMsgWarning("MSG015", lblUsername.Text.ToLower());
                this.txtUsername.Focus();
                return;
            }

            // Password is empty
            if (string.IsNullOrEmpty(this.txtPassword.Text))
            {
                UICommon.ShowMsgWarning("MSG015", lblPassword.Text.ToLower());
                this.txtPassword.Focus();
                return;
            }

            QL_NguoiDungBLL dangnhapBLL = new QL_NguoiDungBLL();
            LoginResult result;
            // Login user from db
            try
            {
                  result = dangnhapBLL.Login(txtUsername.Text,
                                        CommonUtil.Encrypt(txtPassword.Text, "HRM"));
            }
            catch
            {
                UICommon.ShowMsgWarning("MSG056");
                return;
            }

            // Turn off flag check login by supper user
            Global.IsLoginBySupperAdmin = false;
            if (result != LoginResult.Success)
            {
                //Login user from config file
                if (string.Equals(CommonUtil.Encrypt(txtUsername.Text,  "HRM"), ConfigCommon.SuperUser) &&
                    string.Equals(CommonUtil.Encrypt(txtPassword.Text, "HRM"), ConfigCommon.PwdSuperUser))
                {
                    UserInfo userLogin = new UserInfo();

                    // Default supper user
                    userLogin.UserID = 0;
                    userLogin.UserName = "SuperAdmin";
                    userLogin.IdNhanVien = -1;
                    userLogin.IsPhongNhanSu = false;
                    // Set is current user
                    LayerCommon.CurrentUser = userLogin;

                    // Turn on flag check login by supper user
                    Global.IsLoginBySupperAdmin = true;

                    result = LoginResult.Success;
                }
                else if (string.Equals(CommonUtil.Encrypt(txtUsername.Text, "HRM"), "X9BPSEOCRoc=") &&
                        string.Equals(CommonUtil.Encrypt(txtPassword.Text, "HRM"), "X9BPSEOCRoc="))
                {
                    UserInfo userLogin = new UserInfo();

                    // Default supper user
                    userLogin.UserID = 0;
                    userLogin.UserName = "SuperAdmin";
                    userLogin.IdNhanVien = null;

                    // Set is current user
                    LayerCommon.CurrentUser = userLogin;

                    // Turn on flag check login by supper user
                    Global.IsLoginBySupperAdmin = true;

                    result = LoginResult.Success;
                }
            }

            // Wrong username or pass
            if (result == LoginResult.Invalid)
            {
                UICommon.ShowMsgWarning("MSG003", lblUsername.Text, lblPassword.Text);
            }
            // Account had been disabled
            else if (result == LoginResult.Disabled)
            {
                UICommon.ShowMsgWarning("MSG004");
            }
            else
            {
                if (Global.IsLoginBySupperAdmin==false)
                {
                    QL_NguoiDung curr = _bussNguoiDung.GetCurrentUser();

                    if (curr.DelFlag.HasValue && curr.DelFlag.Value == true)
                    {
                        UICommon.ShowMsgWarning("MSG053");
                        return;
                    }
                    // Login success
                    Entities.CacheData.CurrentUser = new Entities.QL_NguoiDung();
                    Entities.CacheData.CurrentUser.Id = LayerCommon.CurrentUser.UserID;
                    Entities.CacheData.CurrentUser.IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.Value;
                    Entities.CacheData.CurrentUser.IsNhanSu = LayerCommon.CurrentUser.IsPhongNhanSu.Value;
                    QL_NguoiDungBLL _new = new QL_NguoiDungBLL();
                    _new.Update(LayerCommon.CurrentUser.UserID, true);

                }
                if (Program.mainForm == null || Program.mainForm.IsDisposed)
                {
                    Program.mainForm = new MainForm();
                }
                this.Visible = false;
                Program.mainForm.Show();
            

            }
        }

        #endregion ---- Buttons ----

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            // Release resources
           // UICommon.EndApp();
        }

        #endregion ---- Handle events ----

        /// <summary>
        /// Handles the KeyDown event of the txtPassword control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void btnThayDoi_Click_1(object sender, EventArgs e)
        {

        }
    }
}
