using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.NguoiDung;
using System.Configuration;
using HRM.Entities;
using System.Threading;
using HRM.DataAccess;
namespace HRM.Forms
{
    public partial class CauHinhSQL : BaseForm
    {
        #region ---- Variables ----

     DBConnectionBLL _bussConnect = null;
        private bool _huy = false;

         
        //public static LoginForm loginForm = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="CauHinhSQL"/> class.
        /// </summary>
        ///  17/05/22
        /// PC
        public CauHinhSQL()
        {
            InitializeComponent();
            _bussConnect = new DBConnectionBLL();
            this.cboSever.DropDown += new EventHandler(cboSever_DropDown);
            //chkboxchungthuc.CheckedChanged += new Syncfusion.Windows.Forms.Tools.CheckedChangedEventHandler(chkboxchungthuc_CheckedChanged);
            btnketnoi.Click += new EventHandler(btnketnoi_Click);
            btnDong.Click += new EventHandler(btnDong_Click);

            this.cboTenCSDL.DropDown += new EventHandler(cboTenCSDL_DropDown);
            this.FormClosed += new FormClosedEventHandler(CauHinhSQL_FormClosed);
            this.Load += new EventHandler(CauHinhSQL_Load);
            this.btnHuy.Click += new EventHandler(btnHuy_Click);
             
        }

        void btnHuy_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool Huy
        {
            get { return _huy; }
            set { _huy = value; }
        }

        void CauHinhSQL_Load(object sender, EventArgs e)
        {
            _huy = Huy;
            this.btnHuy.Enabled = _huy;
        }
        /// <summary>
        /// Handles the FormClosed event of the CauHinhSQL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.FormClosedEventArgs"/> instance containing the event data.</param>
        ///  17/05/22
        /// PC
        void CauHinhSQL_FormClosed(object sender, FormClosedEventArgs e)
        {
            //SplashForm splash = new SplashForm();
            ////// Run flash screen and wait for program load finished data
            //Application.Run(splash);
            //Application.Run(loginForm);
           // Application.Restart();
          
        }
 
        void chkboxchungthuc_CheckedChanged(object sender, Syncfusion.Windows.Forms.Tools.CheckedChangedEventArgs e)
        {
            groupBox1.Enabled = chkboxchungthuc.Checked;
        }

        /// <summary>
        /// Handles the DropDown event of the cboSever control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  17/05/22
        /// PC
        void cboSever_DropDown(object sender, EventArgs e)
        {
            UICommon.StartProcess();

            this.cboSever.DisplayMember = "ServerName";

            this.cboSever.DataSource = _bussConnect.LayDataSource1();

            UICommon.StopProcess();

            Configuration cf = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
           
        } 

        #endregion

        private bool CheckedBeforSearch()
        {
            if (cboSever.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lblTenSerVer.Text);
                cboSever.Focus();
                return false;
            }
            if (txtusername.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lblTenDangNhap.Text);
                txtusername.Focus();
                return false;
            }
            if (txtpass.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lblMatKhau.Text);
                txtpass.Focus();
                return false;
            }
            if (cboTenCSDL.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lbltenCoSoDuLieu.Text);
                cboTenCSDL.Focus();
                return false;
            }

            return true;
        }

        private bool CheckedBeforSearchTenCSDL()
        {
            if (cboSever.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lblTenSerVer.Text);
                cboSever.Focus();
                return false;
            }
            if (txtusername.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lblTenDangNhap.Text);
                txtusername.Focus();
                return false;
            }
            if (txtpass.Text == string.Empty)
            {
                UICommon.ShowMsgInfo("MSG015", lblMatKhau.Text);
                txtpass.Focus();
                return false;
            }
            return true;
        }

        /// <summary>
        /// Handles the Click event of the hrmButton1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  17/05/22
        /// PC
        private void hrmButton1_Click(object sender, EventArgs e)
        {
            //("Data Source=PC\\SQLEXPRESS;Initial Catalog=HRMQUANLYNHANSU;User ID=sa;pwd " +
            //"= sasasa")]
            if (CheckedBeforSearch())
            {
                string conn = string.Empty;
                conn = conn + "Data Source=";
                conn += cboSever.Text + ";";
                conn += "Initial Catalog=";
                conn += cboTenCSDL.Text;
                conn += ";User ID=";
                conn += txtusername.Text + ";pwd=";
                conn += txtpass.Text;
                // CacheData.ConnectionString = conn;
                if (CacheData.TestConnectionConfig(conn))
                {
                    UICommon.ShowMsgInfo("MSG054");
                }
                else
                {
                    UICommon.ShowMsgInfo("MSG055");
                }
            }
            
        }

        /// <summary>
        /// Handles the DropDown event of the cboTenCSDL control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  17/05/22
        /// PC
        void cboTenCSDL_DropDown(object sender, EventArgs e)
        {
            if (CheckedBeforSearchTenCSDL())
            {
                cboTenCSDL.Items.Clear();
                string[] s = _bussConnect.GetDatabaseName(cboSever.Text, txtusername.Text, txtpass.Text);
                foreach (string item in s)
                {
                    cboTenCSDL.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnketnoi control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  17/05/22
        /// PC
        void btnketnoi_Click(object sender, EventArgs e)
        {
            if (CheckedBeforSearch())
            {
                string conn = string.Empty;
                conn = conn + "Data Source=";
                conn += cboSever.Text + ";";
                conn += "Initial Catalog=";
                conn += cboTenCSDL.Text;
                conn += ";User ID=";
                conn += txtusername.Text + ";pwd=";
                conn += txtpass.Text;
                if (CacheData.TestConnectionConfig(conn))
                {
                    try
                    {
                        _bussConnect.Write(conn);
                        UICommon.ShowSplashPanelUpdateMsg();
                        //Thread.Sleep(100);

                        UICommon.ShowMsgInfo("MSG058");

                        Application.Exit();
                    }
                    catch
                    {
                        UICommon.ShowMsgWarning("MSG057");
                    }
                    //CacheData.Context.Connection.ConnectionString = conn;
                }
                else
                {
                    UICommon.ShowMsgInfo("MSG055");
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDong control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  17/05/22
        /// PC
        void btnDong_Click(object sender, EventArgs e)
        {
            Application.Exit();
           // this.Close();
        }
    }
}
