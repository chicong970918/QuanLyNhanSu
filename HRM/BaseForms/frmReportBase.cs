using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SpreadsheetGear;

namespace HRM.BaseForms
{
     
    public partial class frmReportBase : BaseForm
    {
        #region Variables

        private MadeReportResults _result;

        #endregion 

        #region Structs

        protected struct MadeReportResults
        {
            private string _fileName;
            private string _range;
            private int _freezeRow;
            private int _freezeColumn;

            /// <summary>
            /// Initializes a new instance of the <see cref="MadeReportResults"/> struct.
            /// </summary>
            /// <param name="fileName">Name of the file.</param>
            /// <param name="rightBottomRange">The right bottom range.</param>
            /// <param name="freezeRow">The freeze row.</param>
            /// <param name="freezeColumn">The freeze column.</param>
            public MadeReportResults(string fileName = null, string rightBottomRange = null, int freezeRow = -1, int freezeColumn = -1)
            {
                _fileName = fileName;
                _range = rightBottomRange;
                _freezeRow = freezeRow;
                _freezeColumn = freezeColumn;
            }

            /// <summary>
            /// Gets or sets the name of the file.
            /// </summary>
            /// <value>The name of the file.</value>
            public string FileName
            {
                get { return _fileName; }
                set { _fileName = value; }
            }

            /// <summary>
            /// Gets or sets the right bottom range.
            /// </summary>
            /// <value>The right bottom range.</value>
            public string RightBottomRange
            {
                get { return _range; }
                set { _range = value; }
            }

            /// <summary>
            /// Gets or sets the freeze row.
            /// </summary>
            /// <value>The freeze row.</value>
            public int FreezeRow
            {
                get { return _freezeRow; }
                set { _freezeRow = value; }
            }
            

            public int FreezeColumn
            {
                get { return _freezeColumn; }
                set { _freezeColumn = value; }
            }
        }

        #endregion

        #region Contructors

        public frmReportBase()
        {
            InitializeComponent();

            // Set setting for workbook viewer
            Settings();
            InitForm();
        }

        #endregion

        #region Virtual Methods

        protected virtual MadeReportResults MadeReport()
        {
            return new MadeReportResults();
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Inits the form.
        /// </summary>
        /// <Author>LONG LY</Author>
        /// <Date>09/06/2011</Date>
        private void InitForm()
        {
            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnEditExcel.Text = "Chỉnh sửa trên Excel";
            btnEditExcel.Image = Properties.Resources.Edit;
            
            this.btnEditExcel.Click +=new EventHandler(btnSave_Click);
            this.btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            this.btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);
        }

       
        /// <summary>
        /// Settingses this instance.
        /// </summary>
        private void Settings()
        {
            try
            {
                // Lock
                workbookView.GetLock();

                // Setup
                if (workbookView.ActiveWorkbook.WindowInfo != null) // Instead workbookView.ActiveWorkbookWindowInfo -- Trieu Long 31/03/2011
                {
                    //workbookView.ActiveWorkbook.WindowInfo.DisplayWorkbookTabs = false; // Instead workbookView.ActiveWorkbookWindowInfo.DisplayWorkbookTabs -- Trieu Long 31/03/2011
                }

                //if (workbookView.ActiveWorksheetWindowInfo != null)
                if (workbookView.ActiveWorkbook.ActiveWorksheet.WindowInfo != null)
                {
                    workbookView.ActiveWorkbook.ActiveWorksheet.WindowInfo.DisplayGridlines = false; // Instead workbookView.ActiveWorksheetWindowInfo.DisplayHeadings -- Trieu Long 31/03/2011
                    workbookView.ActiveWorkbook.ActiveWorksheet.WindowInfo.DisplayHeadings = false; // Instead workbookView.ActiveWorksheetWindowInfo.DisplayGridlines -- Trieu Long 31/03/2011
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                workbookView.ReleaseLock();
            }
        }

        #endregion 

        #region Events

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>08/06/2011</Date>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                StartLoading();

                _result = MadeReport();

                StopLoading();

                bool enabled = !string.IsNullOrEmpty(_result.FileName);

                if (!string.IsNullOrEmpty(_result.FileName))
                {
                    IWorkbook workbook = Factory.GetWorkbook(_result.FileName);
                    workbookView.ActiveWorkbook = workbook;

                    try
                    {
                        workbookView.GetLock();

                        // Get a reference to the active worksheet window info.
                        SpreadsheetGear.IWorksheetWindowInfo windowInfo =
                            workbookView.ActiveWorkbook.ActiveWorksheet.WindowInfo; // Instead workbookView.ActiveWorksheetWindowInfo -- Trieu Long 31/03/2011

                        // Range
                        if (!string.IsNullOrEmpty(_result.RightBottomRange) && workbookView.ActiveWorkbook.ActiveWorksheet != null) // Instead workbookView.ActiveWorksheet != null
                        {
                            workbookView.ActiveWorkbook.ActiveWorksheet.Name = "Sheet1"; // Instead workbookView.ActiveWorksheet.Name

                            // Change the display reference to a single range.
                            workbookView.DisplayReference = string.Format("Sheet1!A1:{0}", _result.RightBottomRange);

                            // Change the extra color diplayed beyond the last row and column.
                            workbookView.ExtraColor = System.Drawing.Color.White;

                            //Refresh workbookView
                            workbookView.Refresh();
                        }

                        // FreezePanes
                        if (windowInfo != null && 
                            (_result.FreezeColumn != -1 ||
                            _result.FreezeRow != -1))
                        {

                            // Display the first row at the top.
                            windowInfo.ScrollRow = 0;

                            // Display the first column at the left.
                            windowInfo.ScrollColumn = 0;

                            // Split rows.
                            if (_result.FreezeRow != -1)
                            {
                                windowInfo.SplitRows = _result.FreezeRow;
                            }

                            // Split column.
                            if (_result.FreezeColumn != -1)
                            {
                                windowInfo.SplitColumns = _result.FreezeColumn;
                            }

                            // Freeze the top and left panes.
                            windowInfo.FreezePanes = true;
                        }
                    }
                    finally
                    {
                        // NOTE: Must release the workbook set lock.
                        workbookView.ReleaseLock();
                    }
                }
                else
                {
                    workbookView.ActiveWorkbook = Factory.GetWorkbook();
                }

                // Menu
                //tsbPrint.Enabled = enabled;
                //tsbExcel.Enabled = enabled;
                //tsbEditInExcel.Enabled = enabled;

                // Set setting for workbook viewer
                Settings();  
            }
            catch
            {
                throw;
            }
            finally
            {
                //StopLoading();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_result.FileName);

            //// NOTE: Must acquire a workbook set lock.
            //workbookView.GetLock();
            //try
            //{
            //    // Get the active workbook set.
            //    SpreadsheetGear.IWorkbookSet workbookSet = workbookView.ActiveWorkbookSet;

            //    // Create the Workbook Designer for the active workbook set.
            //    SpreadsheetGear.Windows.Forms.WorkbookDesigner designer =
            //        new SpreadsheetGear.Windows.Forms.WorkbookDesigner(workbookSet);

            //    // Set up some event handlers.
            //    //designer.Shown +=
            //    //    new System.EventHandler(workbookDesigner_Shown);
            //    //designer.FormClosed +=
            //    //    new System.Windows.Forms.FormClosedEventHandler(workbookDesigner_FormClosed);

            //    // Display the Workbook Designer to the user.
            //    designer.Show(workbookView);
            //}
            //finally
            //{
            //    // NOTE: Must release the workbook set lock.
            //    workbookView.ReleaseLock();
            //}
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>08/06/2011</Date>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        void btnPrintTemplate_Click(object sender, EventArgs e)
        {

            try
            {
                StartLoading();

                // Lock
                workbookView.GetLock();
                workbookView.ActiveWorkbook.Save();
                workbookView.PrintPreview();
            }
            catch
            {
                throw;
            }
            finally
            {
                // Release lock
                workbookView.ReleaseLock();
                StopLoading();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>10/06/2011</Date>
        void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile = new SaveFileDialog();

            // Lock
            workbookView.GetLock();

            try
            {
                // Setting
                saveFile.Filter = "Excel files (*.xls)|*.xls";
                saveFile.FileName = DefaultFileName;

                if (saveFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    // Save
                    workbookView.ActiveWorkbook.SaveAs(saveFile.FileName, SpreadsheetGear.FileFormat.Excel8);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // Release lock
                workbookView.ReleaseLock();
            }

            // Confirm for open file was exported
            if (!string.IsNullOrEmpty(saveFile.FileName) && UICommon.ShowMessage("MSG023", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(saveFile.FileName);
            }
        }

        #endregion

        #region Properties
 

        /// <summary>
        /// Gets the default name of the file.
        /// </summary>
        /// <value>The default name of the file.</value>
        protected virtual string DefaultFileName
        {
            get { return string.Empty; }
        }

        #endregion
        
    }
}
