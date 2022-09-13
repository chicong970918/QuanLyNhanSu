using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using HRM.DanhMuc;
using System.Data.EntityClient;
using Library.Controls;
using System.Diagnostics;
using HRM.Forms;
using log4net;
using System.Globalization;
using System.Threading;
using HRM.Class;
using System.IO;
using HRM.DataAccess.Catalogs;
using HRM.Entities;

namespace HRM
{
    static class Program
    {
        public static MainForm mainForm = null;
        public static LoginForm loginForm = null;
        private static ILog _Logger = null;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           // UICommon.ShowMsgInfo("MSG018");
            //Application.ThreadException +=new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            if (HasMoreThanOneInstance())
            {
                UICommon.ShowMsgInfo("MSG014");
                return;
                
            }
           // DanhMucCapTuyenDungBLL _bus = new DanhMucCapTuyenDungBLL();
         // UICommon.ShowMsgInfo("MSG018");
            // Manage exeption
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            
            HRMSplashPanelMessage CreateFlashMessage = new HRMSplashPanelMessage();
            UICommon.Initilize(CreateFlashMessage, false);

           // Entities.CacheData.Context.Connection.ConnectionString;
            if(!Entities.CacheData.TestConnection())
            {
                UICommon.ShowMsgError("MSG048");
                CauHinhSQL frm = new CauHinhSQL();
                frm.ShowDialog();
                return;
            }
            SplashForm splash = new SplashForm();
            //// Run flash screen and wait for program load finished data
            Application.Run(splash);
          //  Application.Run(loginForm);
           // AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

             #if DEBUG

              mainForm = new MainForm();
              mainForm.StartPosition = FormStartPosition.CenterScreen;
              
             //  Manage exeption
            Application.Run(mainForm);
            
            #endif

            #if !DEBUG

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //CultureInfo culture = new System.Globalization.CultureInfo("en-US");
            //culture.DateTimeFormat.DateSeparator = Constants.CHAR_DATE_SEPARATOR;
            //culture.DateTimeFormat.FullDateTimePattern = Constants.DATE_PATTERN;
            // Set Culture
            //Thread.CurrentThread.CurrentCulture = culture;
            //Thread.CurrentThread.CurrentUICulture = culture;
            // Wait until flash screen closed, mainscreen will show immediately
           Application.Run(loginForm);
          // Application.Restart();
            #endif


        }


        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>The logger.</value>
        private static ILog Logger
        {
            get
            {
                if (_Logger == null)
                {
                    _Logger = LogManager.GetLogger("HRM");
                }
                return _Logger;
            }
        }
        /// <summary>
        /// Handles the ThreadException event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Threading.ThreadExceptionEventArgs"/> instance containing the event data.</param>
        //private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        //{
        //    UICommon.ShowMsgError("MSG_ERROR");
        //    Program.Logger.Error(e.Exception);
        //}

        /// <summary>
        /// Determines whether [has more than one instance].
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if [has more than one instance]; otherwise, <c>false</c>.
        /// </returns>
        private static bool HasMoreThanOneInstance()
        {
            Process[] pro = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);

            return (pro.Length > 1);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            UICommon.ShowMsgError("Có lỗi xảy ra, vui lòng khởi động lại chương trình");
           //  
            //Application.Exit();
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            UICommon.ShowMsgError("MSG_ERROR");
            Program.Logger.Error(e.Exception);
           // string s = sss + "s";
            // doc file
            //try
            //{
            //    StreamReader Re = File.OpenText("log.txt");
            //    string input = null;
            //    while ((input = Re.ReadLine()) != null)
            //    {
            //        Console.WriteLine(input);
            //    }
            //    FileInfo myfile = FileInfo("log.txt");
            //    StreamWriter tex = myfile.CreateText();
            //    tex.Write(tex.NewLine);
            //    tex.WriteLine(sss);
            //    Re.Close();
            //}
            //catch
            //{
            //    //Ghi file
            //    FileInfo myfile = new FileInfo("log.txt");
            //    StreamWriter tex = myfile.CreateText();
            //    tex.Write(tex.NewLine);
            //    tex.WriteLine(sss);
            //    tex.Close();
            //}
          //  Console.ReadKey();
        }
    }
}
