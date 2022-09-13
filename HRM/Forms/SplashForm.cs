using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace HRM.Forms
{
    public partial class SplashForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SplashForm"/> class.
        /// </summary>
        public SplashForm()
        {
            InitializeComponent();

            this.InitFlashScreen();
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        protected override void OnShown(EventArgs e)
        {
            Thread initMainScreen = new Thread(new ThreadStart(InitInfo));

            CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //culture.DateTimeFormat.DateSeparator = Constants.CHAR_DATE_SEPARATOR;
            //culture.DateTimeFormat.FullDateTimePattern = Constants.DATE_PATTERN;

            // Set Culture
            initMainScreen.CurrentCulture = culture;
            initMainScreen.CurrentUICulture = culture;

            initMainScreen.Start();
        }

        /// <summary>
        /// Inits the info.
        /// </summary>
        private void InitInfo()
        {
            this.BeginInvoke(new MethodInvoker(delegate()
            {
                this.Refresh();
            }));

            // Do update script to db
            //this.DoUpdateScriptToDBServer();

            // Init variables system
          //  UICommon.Initilize(this.CreateFlashMessage(), false);
            Thread.Sleep(1200);

            this.BeginInvoke(new MethodInvoker(delegate()
            {
                Program.loginForm = new LoginForm();
                this.Close();
            }));
        }

        /// <summary>
        /// Inits the flash screen.
        /// </summary>
        private void InitFlashScreen()
        {
           // this.Text = AssemblyTitle;
            //this.labelProductName.Text = AssemblyProduct;
            //this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
           //// this.labelCopyright.Text = AssemblyCopyright;
            //this.labelCompanyName.Text = AssemblyCompany;
            //this.textBoxDescription.Text = AssemblyDescription;
        }

        /// <summary>
        /// Does the update sript to DB server.
        /// </summary>
        private void DoUpdateScriptToDBServer()
        {
            //// Get file update script to DB
            //string fileSqlUpdateDB = Global.AppPath + Constants.FOLDER_SQL_UPDATEDB + Constants.CHAR_FLASH + Constants.FILE_SQLQUERY_UPDATEDB;

            //// Check file is exists
            //if (FileCommon.Exists(fileSqlUpdateDB))
            //{
            //    // Do update compare
            //    SECHUI.Project.Layers.Common.DataAccess.CompareUpdateDB(fileSqlUpdateDB);
            //}
        }

    }
}
