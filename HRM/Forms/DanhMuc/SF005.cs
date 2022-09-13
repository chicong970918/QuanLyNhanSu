﻿using System ;
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


namespace HRM.DanhMuc
{
    public partial class SF005 : DanhMucBase
    {
        #region ---- Variables ----

        DanhMucQuanHeBLL _bussQuanHe = null;
        private int _lastUpdate = -1;
        private List<int> _listError = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF005()
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
            this.txtMaQuanHe.Focus();
            DM_QuanHe item = new DM_QuanHe();
            brscGrdData.Add(item);
            base.GetNewData();

        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            DM_QuanHe item = brscGrdData.Current as DM_QuanHe;
            int a = -1;
            if (item != null)
            {
                if (!AllowDeleteData("DM_QuanHe"))
                {
                    UICommon.ShowMsgInfo("MSG026");
                    return;
                }
                // Confirm delete
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)
                {
                    a = brscGrdData.IndexOf(item);
                    brscGrdData.RemoveCurrent();
                    _listError.Remove(a);
                    if (item.Id != 0)
                    {
                        _bussQuanHe.DeleteData(item.Id);
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
        /// Allows the delete data.
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        
        protected override bool AllowDeleteData(string pName)
        {
            return base.AllowDeleteData(pName);
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
                    _lastUpdate = 1;
                    List<DM_QuanHe> list = (List<DM_QuanHe>)brscGrdData.DataSource;
                    _bussQuanHe.UpdateDataList(list);
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();
                   
                }

            }
            GrdData.EndEdit();
            GrdData.RefreshData();
            GrdData.Refresh();
        }
 
        #endregion

        #region ---- Private Methods ----

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            this.btnSearch.Visible = false;
            this.toolStripSeparator1.Visible = false;
            // Get data
            _bussQuanHe = new  DanhMucQuanHeBLL();
            _listError = new List<int>();
            this.brscGrdData.DataSource = _bussQuanHe.GetAll();
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            Enable(false);
        }
 
        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtMaQuanHe.Enabled = pvalue;
            txtTenQuanHe.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaQuanHe.DataBindings.Clear();
            txtTenQuanHe.DataBindings.Clear();
            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaQuanHe.DataBindings.Add("Text", brscGrdData, "MaQuanHe", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenQuanHe.DataBindings.Add("Text", brscGrdData, "TenQuanHe", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<DM_QuanHe> listData = (List<DM_QuanHe>)brscGrdData.DataSource;

            foreach (DM_QuanHe item in listData)
            {
                // Get The position of the Item
                int a = listData.IndexOf(item);

                if (string.IsNullOrEmpty(item.MaQuanHe))// MaQuanHe nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblMaQuanHe.Text);
                    this.txtMaQuanHe.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.TenQuanHe)) // TenQuanHe not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenQuanHe.Text);
                    this.txtTenQuanHe.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<DM_QuanHe> listIndex = listData.Where(p => p.MaQuanHe == item.MaQuanHe).Select(p => p).ToList();

                // Check IsExited MaQuanHe in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (DM_QuanHe index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblMaQuanHe.Text);
                    brscGrdData.Position = a;
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region ---- Events ----

        #region ---- Button ----

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

        #endregion
    }
}
