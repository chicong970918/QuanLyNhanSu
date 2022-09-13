using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.Class;
using HRM.DataAccess.Catalogs;
using HRM.Entities;
using System.IO;


namespace HRM.Forms.DanhMuc
{
    public partial class SF019 : DanhMucBase
    {
        #region ---- Variables ----

        DM_BieuMauBLL _bussBieuMau = null;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF019"/> class.
        /// </summary>
        ///  21/08/11
        /// PC
        public SF019()
        {
            InitializeComponent();
            this.InitForm();
        }

        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Gets the new data.
        /// </summary>
        protected override void GetNewData()
        {
            Enable(true);
            // Add data in bindingsourec 
            this.txtMaBieuMau.Focus();
            DM_BieuMau item = new DM_BieuMau();
            brscGrdData.Add(item);
            base.GetNewData();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            DM_BieuMau item = brscGrdData.Current as DM_BieuMau;

            int a = -1;

            if (item != null)
            {
                if (!AllowDeleteData("DM_BieuMau"))
                {
                    UICommon.ShowMsgInfo("MSG026");
                    return;
                }

                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                {
                    a = brscGrdData.IndexOf(item);
                    brscGrdData.RemoveCurrent();
                    _listError.Remove(a);
                    if (item.Id != 0)
                    {
                        _bussBieuMau.DeleteData(item.Id);
                        UICommon.ShowSplashPanelUpdateMsg();
                        if (!(brscGrdData.Count > 0))
                        {
                            Enable(false);
                        }
                        else
                        {
                            Enable(true);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {

            if (Validator() == true)
            {
                base.SaveData();
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    List<DM_BieuMau> list = (List<DM_BieuMau>)brscGrdData.DataSource;
                    _bussBieuMau.UpdateDataList(list);
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();

                }
            }
            GrdData.EndEdit();
            GrdData.RefreshData();
            GrdData.Refresh();
        }

        /// <summary>
        /// Allows the delete data.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
        }

        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            this.btnSearch.Text="Cập nhật biểu mẫu";
            this.btnSearch.Image = HRM.Properties.Resources.Excel_edit;
            this.btnSearch.Visible = true;
            this.toolStripSeparator1.Visible = false;
            // Get data
            _bussBieuMau  = new  DM_BieuMauBLL();
            _listError = new List<int>();
            this.brscGrdData.DataSource = _bussBieuMau.GetAll();
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            Enable(false);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = false;
            this.txtMaBieuMau.Enabled = false;
        }

        void btnSearch_Click(object sender, EventArgs e)
        {
            // Get current template
            DM_BieuMau bieumau = brscGrdData.Current as DM_BieuMau;

            if (bieumau != null && bieumau.NoiDung != null)
            {
                // Create object save file
                SaveFileDialog saveFile = new SaveFileDialog();

                // Fillter file by file type
                if (txtLoaiFile.Text == "Office Word 97-2003")
                {
                    saveFile.Filter = Constants.FILLTER_WORD_2003_FILE;
                }
                if (txtLoaiFile.Text == "Office Excel 97-2003")
                {
                    saveFile.Filter = Constants.FILTER_EXCEL;
                }
                if (txtLoaiFile.Text == "Office Word 2007")
                {
                    saveFile.Filter = Constants.FILLTER_WORD_2007_FILE;
                }
                if (txtLoaiFile.Text == "Office _Excel 2007")
                {
                    saveFile.Filter = Constants.FILTER_EXCEL2007;
                }
               
                   

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    byte[] arr = bieumau.NoiDung.ToArray();
                    // Write file
                    FileCommon.WriteByteToFile(arr, saveFile.FileName);

                    // Open file to edit
                    System.Diagnostics.Process.Start(saveFile.FileName);
                }
            }
        }

        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            //txtMaBieuMau.Enabled = pvalue;
            txtTenBieuMau.Enabled = pvalue;
            txtLoaiFile.Enabled = pvalue;
            btnLoaifile.Enabled = pvalue;
           
        }
        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaBieuMau.DataBindings.Clear();
            txtTenBieuMau.DataBindings.Clear();
            txtLoaiFile.DataBindings.Clear();
            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaBieuMau.DataBindings.Add("Text", brscGrdData, "MaBieuMau", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenBieuMau.DataBindings.Add("Text", brscGrdData, "TenBieuMau", true, DataSourceUpdateMode.OnPropertyChanged);
            txtLoaiFile.DataBindings.Add("Text", brscGrdData, "LoaiFile", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<DM_BieuMau> listData = (List<DM_BieuMau>)brscGrdData.DataSource;

            foreach (DM_BieuMau item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.MaBieuMau))// MaChuyen Nganh nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaBieuMau.Text);
                    this.txtMaBieuMau.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.TenBieuMau)) // Ten chuyen nganh not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaBieuMau.Text);
                    this.txtTenBieuMau.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    return false;
                }

                List<DM_BieuMau> listIndex = listData.Where(p => p.MaBieuMau == item.MaBieuMau).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (DM_BieuMau index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblMaBieuMau.Text);
                    brscGrdData.Position = a;
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Handles the TableControlCellClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            Enable(true);
        }

        #endregion

        #region ---- GrdData ----

        /// <summary>
        /// Handles the QueryCellStyleInfo event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs"/> instance containing the event data.</param>
        private void GrdData_QueryCellStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.RowIndex % 2 == 0)
            {
                e.Style.BackColor = Color.White;
            }
            else
            {
                e.Style.BackColor = Color.MintCream;
            }
            foreach (int item in _listError)
            {
                if (e.TableCellIdentity.RowIndex == item + 2)
                {
                    e.Style.BackColor = Color.Orange;
                    e.Style.CellTipText = UICommon.GetString("MSG011");
                    break;
                }
            }
        }

        #endregion

        /// <summary>
        /// Select the word File
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChon_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog OpFile = new OpenFileDialog();

            OpFile.Filter = Constants.FILLTER_WORD_EXCEL;

            if (OpFile.ShowDialog() == DialogResult.OK)
            {
                DM_BieuMau bieumau = brscGrdData.Current as DM_BieuMau;

                if (bieumau != null)
                {
                    bieumau.NoiDung = File.ReadAllBytes(OpFile.FileName);

                    if (bieumau.NoiDung != null && bieumau.NoiDung.Length> 0)
                    {
                        FileInfo fInfo = new FileInfo(OpFile.FileName);

                        if (string.Equals(fInfo.Extension, Constants.FILE_EXT_DOC, StringComparison.CurrentCultureIgnoreCase))
                        {
                            txtLoaiFile.Text = Constants.FILE_OFFICE_97_2003;
                        }
                        else
                        {
                            if (string.Equals(fInfo.Extension, Constants.FILE_EXT_DOCS, StringComparison.CurrentCultureIgnoreCase))
                            {
                                txtLoaiFile.Text = Constants.FILE_OFFICE_2007;
                            }
                            else
                            {
                                if (string.Equals(fInfo.Extension, Constants.FILE_EXT_XLS, StringComparison.CurrentCultureIgnoreCase))
                                {
                                    txtLoaiFile.Text = Constants.FILE_Excel_97_2003;
                                }
                                else
                                {
                                    if (string.Equals(fInfo.Extension, Constants.FILE_EXT_XLSs, StringComparison.CurrentCultureIgnoreCase))
                                    {
                                        txtLoaiFile.Text = Constants.FILE_Excel_2007;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
