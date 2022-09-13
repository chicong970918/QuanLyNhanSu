using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.Class;
using HRM.Entities;


namespace HRM.BaseForms
{
    public partial class TuyenDungBaseForm : BaseForm
    {
         #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="DanhMucBase"/> class.
        /// </summary>
        public TuyenDungBaseForm()
        {
            InitializeComponent();
            InitFormBse();
        } 

        #endregion

        #region ---- Public Methods ----

        #endregion

        #region ---- Events ----

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnUpdate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        /// <summary>
        /// Handles the Click event of the btnPrint control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocuments();
        }

        /// <summary>
        /// Handles the Click event of the btnExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel();
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            Deletedata();
        }

        /// <summary>
        /// Handles the Click event of the btnClose control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            GetNewData();
            
        } 

        #endregion

        #region ---- Forms ----

        /// <summary>
        /// Handles the Load event of the DanhMucBase control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DanhMucBase_Load(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                GrdData.Table.CurrentRecord = GrdData.Table.Records[0];
            }
             
        }  

        #endregion

        #endregion

        #region ---- Override Methods ----

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
                // Ctrl + N : Add new
                case (int)Keys.Control + (int)Keys.N:

                    this.btnAdd.PerformClick();
                    return true;

                // Ctrl + D : Delete
                case (int)Keys.Control + (int)Keys.D:

                    this.btnDelete.PerformClick();

                    return true;

                // Ctrl + S : Save
                case (int)Keys.Control + (int)Keys.S:

                    this.btnSave.PerformClick();

                    return true;

                // Ctrl + Z : Undo
                case (int)Keys.Control + (int)Keys.Z:

                    //    toolStripButtonUndo.PerformClick();

                    return true;

                // Ctrl + R : Refresh
                case (int)Keys.Control + (int)Keys.R:

                    //  this.btn PerformClick();

                    return true;

                // Ctrl + E : Export excel
                case (int)Keys.Control + (int)Keys.E:

                    this.btnExcel.PerformClick();

                    return true;

                // Ctrl + P : Print
                case (int)Keys.Control + (int)Keys.P:

                    this.btnPrint.PerformClick();

                    return true;

                // Esc : Close
                case (int)Keys.Escape:

                    this.btnClose.PerformClick();

                    return true;

                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }
        }

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected virtual void GetNewData()
        {
            // Remove sort
            this.GrdData.TableDescriptor.SortedColumns.Clear();
            // Move last
            brscGrdData.MoveLast();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected virtual void Deletedata()
        {

        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected virtual void SaveData()
        {
            this.GrdData.TableDescriptor.SortedColumns.Clear(); 
        }

        /// <summary>
        /// Exports the excel.
        /// </summary>
        protected virtual void ExportExcel()
        {
            // Check data source
            if (brscGrdData.Count > 0)
            {
                ExcelExport excel = new ExcelExport();
                excel.AutoExportToExcel(GrdData, "TUYỂN DỤNG", false);
            }
            else
            {
                UICommon.ShowMsgInfo("MSG009");
            }
        }

        /// <summary>
        /// Prints the documents.
        /// </summary>
        protected virtual void PrintDocuments()
        {
            // Check data Source
            if (brscGrdData.Count > 0)
            {
                ExcelExport excel = new ExcelExport();
                string path = excel.AutoExportToExcel(GrdData, "TUYỂN DỤNG", true);
                base.Print(path);
            }
            else
            {
                UICommon.ShowMsgInfo("MSG009");
            }
        }

        /// <summary>
        /// Inits the form.
        /// </summary>
        protected void InitFormBse()
        {
            // Add events
            btnAdd.Click += new EventHandler(btnAdd_Click);
            this.Load += new EventHandler(DanhMucBase_Load);
            btnClose.Click += new EventHandler(btnClose_Click);
            btnDelete.Click += new EventHandler(btnDelete_Click);
            btnExcel.Click += new EventHandler(btnExcel_Click);
            btnPrint.Click += new EventHandler(btnPrint_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);
            btnProcess.Visible = false;
            btnExcelTemplate.Visible = false;
            btnPrintTemplate.Visible = false;
            toolStripSeparator3.Visible = false;

        }

        /// <summary>
        /// Allows the delete data.
        /// </summary>
        /// <returns></returns>
        /// <Author>LONG LY</Author>
        /// <Date>11/06/2011</Date>
        protected virtual bool AllowDeleteData(string pName )
        {
            if (brscGrdData.Current == null)
                return false;

            if (CacheData.IsKeyUsing(pName, brscGrdData.Current)) //typeof(T).Name
            {
                return false;
            }

            return true;
        }


        #endregion
    }
}
