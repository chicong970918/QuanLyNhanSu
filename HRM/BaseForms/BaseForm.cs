using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Syncfusion.Windows.Forms;

namespace HRM.BaseForms
{
    public partial class BaseForm : Office2007Form
    {
        #region ---- Member variables ----

        private ToolStripButton _toolStripButtonClose;
        private Control _closeControl;
        private bool _showLoadingOnLoad = true;

        private static bool _isLoading = false;

        private bool _isClosing = false;

        #endregion

        #region ---- Contructors ----

        public BaseForm()
        {
            InitializeComponent();
            StartLoading();
        } 

        #endregion

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the tool strip button close.
        /// </summary>
        /// <value>The tool strip button close.</value>
        public ToolStripButton ToolStripButtonClose
        {
            get { return _toolStripButtonClose; }
            set
            {
                _toolStripButtonClose = value;

                if (_toolStripButtonClose != null)
                {
                    _toolStripButtonClose.Click += new System.EventHandler(toolStripButtonClose_Click);
                }
            }
        }

        /// <summary>
        /// Gets or sets the close control.
        /// </summary>
        /// <value>The close control.</value>
        public Control CloseControl
        {
            get { return _closeControl; }
            set
            {
                _closeControl = value;

                if (_closeControl != null)
                {
                    _closeControl.Click += new EventHandler(closeControl_Click);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show loading on load].
        /// </summary>
        /// <value><c>true</c> if [show loading on load]; otherwise, <c>false</c>.</value>
        public bool ShowLoadingOnLoad
        {
            get { return _showLoadingOnLoad; }
            set { _showLoadingOnLoad = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is loading.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is loading; otherwise, <c>false</c>.
        /// </value>
        public static bool IsLoading
        {
            get { return BaseForm._isLoading; }
            set { BaseForm._isLoading = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is closing.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is closing; otherwise, <c>false</c>.
        /// </value>
        public bool IsClosing
        {
            get { return _isClosing; }
            set { _isClosing = value; }
        }

        #endregion

        #region ---- Protected methods ----

        /// <summary>
        /// Does the exit.
        /// </summary>
        protected virtual void DoExit()
        {
            this._isClosing = true;
            this.DialogResult = DialogResult.None;
            this.Close();
        }

        /// <summary>
        /// Prints the specified p file.
        /// </summary>
        /// <param name="pFile">The p file.</param>
        protected virtual void Print(string pFile)
        {
            if (string.IsNullOrEmpty(pFile))
            {
                return;
            }

            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook wb = null;

            try
            {
                wb = excelApp.Workbooks.Open(pFile);

                if (wb != null)
                {
                    // Show print preview
                    excelApp.Visible = true;
                    wb.PrintPreview(true);
                }
            }
            catch (Exception ex)
            {
                //HRM.Class.UICommon.ManageException(ex);
            }
            finally
            {
                // Cleanup:
                GC.Collect();
                GC.WaitForPendingFinalizers();

                wb.Close(false, Type.Missing, Type.Missing);
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(wb);

                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(excelApp);
            }
        }

        #endregion

        #region ---- Public Methods ----

        /// <summary>
        /// Starts the loading.
        /// </summary>
        /// <param name="pContent">Content of the p.</param>
        public void StartLoading(string pContent = null)
        {
            // Turn on flag
            _isLoading = true;

            // Start loading
            HRM.UICommon.StartLoading(pContent, this);
        }

        /// <summary>
        /// Stops the loading.
        /// </summary>
        public void StopLoading()
        {
            // Turn off flag
            _isLoading = false;

            // Stop loading
            HRM.UICommon.StopLoading();
        }

        #endregion

        #region ---- Private methods ----

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Shown"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnShown(EventArgs e)
        {
            // Set active form
            HRM.UICommon.FormWillActiveAfterLoading = this;

            // Stop loading
            StopLoading();

            base.OnShown(e);
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.FormClosed"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.FormClosedEventArgs"/> that contains the event data.</param>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            // Get parent form
            Form frm = GetParent();

            // Had parent then active parent
            if (frm != null)
            {
                frm.Activate();
            }

            base.OnFormClosed(e);
        }

        /// <summary>
        /// Gets the parent.
        /// </summary>
        /// <returns></returns>
        private Form GetParent()
        {
            // Mdi parent
            if (this.MdiParent != null)
            {
                return this.MdiParent;
            }
            else if (this.Owner != null) // Owner on show dialog
            {
                return this.Owner;
            }

            return null;
        }

        #endregion

        #region ---- Handle events ----

        /// <summary>
        /// Processes a command key.
        /// </summary>
        /// <param name="msg">A <see cref="T:System.Windows.Forms.Message"/>, passed by reference, that represents the Win32 message to process.</param>
        /// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys"/> values that represents the key to process.</param>
        /// <returns>
        /// true if the keystroke was processed and consumed by the control; otherwise, false to allow further processing.
        /// </returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Process hot key
            switch ((int)keyData)
            {
                case (int)Keys.Escape:

                    this.DoExit();

                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        /// <summary>
        /// Handles the Click event of the toolStripButtonClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void toolStripButtonClose_Click(object sender, System.EventArgs e)
        {
            this.DoExit();
        }

        /// <summary>
        /// Handles the Click event of the closeControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void closeControl_Click(object sender, EventArgs e)
        {
            this.DoExit();
        }

        #endregion ---- Handle events ----
    }
}
