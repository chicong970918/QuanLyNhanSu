using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.TuyenDung;
using HRM.Entities;
using HRM.DataAccess.Common;
using System.Data.Linq;
using Library.Class;
using HRM.Class;
using Library;

namespace HRM.Forms.TuyenDung
{
    public partial class SF102 : GridBaseForm
    {
        #region ---- Variables ----

        TD_BangKeHoachTuyenDungBLL _bussKeHoach = null;
        private List<int> _listError = null;
        private List<TD_BangKeHoachTuyenDung> _list = null;
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF002"/> class.
        /// </summary>
        public SF102()
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
            this.txtMaKeHoach.Focus();
            TD_BangKeHoachTuyenDung item = new TD_BangKeHoachTuyenDung();
            item.IdPhongBan = ((DM_PhongBan)this.cboPhongBan.SelectedItem).Id;
            item.Quy = ((DM_Quy)this.cboQuy.SelectedItem).Id;
            item.Nam = CommonUtil.IsInt(txtNam.Text);
            brscGrdData.Add(item);
            base.GetNewData();
        }

        /// <summary>
        /// Deletedatas this instance.
        /// </summary>
        protected override void Deletedata()
        {
            base.Deletedata();

            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                if (UICommon.ShowMsgConfirm("MSG006") == DialogResult.Yes)// Xac nhan
                {
                    brscGrdData.RemoveCurrent();
                    if (item.Id != 0)
                    {
                        _bussKeHoach.DeleteData(item.Id);
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
            base.SaveData();
            brscGrdData.EndEdit();
            if (Validator() == true)
            {
                if (brscGrdData.Count > 0)
                {
                    UICommon.StartUpdate();
                    foreach (TD_BangKeHoachTuyenDung item in ((List<TD_BangKeHoachTuyenDung>)brscGrdData.DataSource))
                    {
                        if (item.DaDuyet.Value)
                        {
                            _list.Add(item);
                        }
                    }
                    List<TD_BangKeHoachTuyenDung> list = (List<TD_BangKeHoachTuyenDung>)brscGrdData.DataSource;
                    _bussKeHoach.UpdateDataList(list);
                    UICommon.StopUpdate();
                    UICommon.ShowSplashPanelUpdateMsg();
                    LoadData();
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
            this.txtNam.Text = CacheData.Context.GetSystemDate().Year.ToString();
            // GetData
             

            // GetData
           
            // Get data
            _bussKeHoach = new  TD_BangKeHoachTuyenDungBLL();
            this.cboPhongBan.DisplayMember = "TenPhongBan";
            this.cboPhongBan.ValueMember = "Id";
            this.cboPhongBan.DataSource = _bussKeHoach.GetAllPhongBan();
          
            this.cboQuy.DisplayMember = "Ten";
            this.cboQuy.ValueMember = "Id";
            this.cboQuy.DataSource = _bussKeHoach.GetAllQuy();
            this.btnSearch.Text = "Chi tiết kế hoạch";
            _listError = new List<int>();
            _list = new List<TD_BangKeHoachTuyenDung>();
            this.btnAdd.Enabled = false;
            this.btnDelete.Enabled = false;
            this.btnSave.Enabled = true;
            // Add events 
            this.GrdData.TableControlCellClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellClick);
            this.cboPhongBan.SelectedIndexChanged += new EventHandler(cboPhongBan_SelectedIndexChanged);
            this.cboQuy.SelectedIndexChanged += new EventHandler(cboQuy_SelectedIndexChanged);
            this.cboQuy.TextChanged += new EventHandler(cboQuy_TextChanged);
            this.txtNam.TextChanged += new EventHandler(txtNam_TextChanged);
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            this.brscGrdData.CurrentItemChanged += new EventHandler(brscGrdData_CurrentItemChanged);
            brscGrdData.PositionChanged += new EventHandler(brscGrdData_PositionChanged);
            // Load data by PhongBan
            int IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.HasValue?LayerCommon.CurrentUser.IdNhanVien.Value:-1;
            int IdPhongBan = _bussKeHoach.GetIdPhongBanByIdNhanVien(IdNhanVien);
            this.brscGrdData.DataSource = _bussKeHoach.GetDataByPhongBanQuy(IdPhongBan, CommonUtil.IsInt(this.cboQuy.Text),CommonUtil.IsInt(txtNam.Text));
            //this.brscGrdData.DataSource = _bussKeHoach.GetDataByPhongBan(IdPhongBan);
            this.GrdData.DataSource = brscGrdData;
            this.AddDataBinding();

             

               

            Enable(false);
            ToolStripItem mnuItem = null;
            for (int i = hrmContextMenustrip1.Items.Count - 1; i >= 0; i--)
            {
                mnuItem = hrmContextMenustrip1.Items[i];
                this.GrdData.InternalContextMenuStripEx.Items.Insert(0, mnuItem);
            }

        }
 
        /// <summary>
        /// Enables the specified pvalue.
        /// </summary>
        /// <param name="pvalue">if set to <c>true</c> [pvalue].</param>
        private void Enable(bool pvalue)
        {
            txtGhiChu.Enabled = pvalue;
            txtMaKeHoach.Enabled = pvalue;
            txtTenKeHoach.Enabled = pvalue;
            //radioButton1.Enabled = pvalue;
            //radioButton2.Enabled = pvalue;
        }

        /// <summary>
        /// Adds the data binding.
        /// </summary>
        private void AddDataBinding()
        {
            // Clears
            txtGhiChu.DataBindings.Clear();
            txtMaKeHoach.DataBindings.Clear();
            txtTenKeHoach.DataBindings.Clear();
            radioButton1.DataBindings.Clear();
            radioButton2.DataBindings.Clear();
            // Bingding
            txtGhiChu.DataBindings.Add("Text", brscGrdData, "GhiChu", true, DataSourceUpdateMode.OnPropertyChanged);
            txtMaKeHoach.DataBindings.Add("Text", brscGrdData, "MaKeHoach", true, DataSourceUpdateMode.OnPropertyChanged);
            txtTenKeHoach.DataBindings.Add("Text", brscGrdData, "TenKeHoach", true, DataSourceUpdateMode.OnPropertyChanged);
            radioButton1.DataBindings.Add("Checked", brscGrdData, "DaDuyet", true, DataSourceUpdateMode.OnPropertyChanged);
            radioButton2.DataBindings.Add("Checked", brscGrdData, "KhongDuyet", true, DataSourceUpdateMode.OnPropertyChanged);
            this.GrdData.QueryCellStyleInfo += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventHandler(GrdData_QueryCellStyleInfo);
        }

        /// <summary>
        /// Validators this instance.
        /// </summary>
        private bool Validator()
        {
            _listError.Clear();
            // Get data in bindingsource
            List<TD_BangKeHoachTuyenDung> listData = (List<TD_BangKeHoachTuyenDung>)brscGrdData.DataSource;

            foreach (TD_BangKeHoachTuyenDung item in listData)
            {

                // Get The position of the Item
                int a = listData.IndexOf(item);
                if (!(item.Nam.HasValue))// MaKeHoach nott null
                {
                    UICommon.ShowMsgInfo("MSG005", lblNam.Text);
                    this.txtNam.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                if (item.Nam < CacheData.Context.GetSystemDate().Year)
                {
                    UICommon.ShowMsgInfo("MSG017", lblNam.Text, CacheData.Context.GetSystemDate().Year.ToString());
                    this.txtNam.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                if (string.IsNullOrEmpty(item.MaKeHoach))// MaKeHoach nott null
                {
                    UICommon.ShowMsgInfo("MSG005",  lblMaKeHoach.Text);
                    this.txtMaKeHoach.Focus();
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }
                if (string.IsNullOrEmpty(item.TenKeHoach)) //TenKeHoach not null
                {
                    UICommon.ShowMsgInfo("MSG005", lblTenKeHoach.Text);
                    this.txtTenKeHoach.Focus();
                    _listError.Add(a);
                    brscGrdData.Position = a;
                    _listError.Add(a);
                    return false;
                }

                List<TD_BangKeHoachTuyenDung> listIndex = listData.Where(p => p.MaKeHoach == item.MaKeHoach).Select(p => p).ToList();

                // Check IsExited MaChuyenNganh in Grid
                if (listIndex.Count() > 1)
                {
                    foreach (TD_BangKeHoachTuyenDung index in listIndex)
                    {
                        _listError.Add(brscGrdData.IndexOf(index));
                    }
                    UICommon.ShowMsgInfo("MSG008", lblMaKeHoach.Text);
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
            //phan quyen nhan su phong ban
           // PhanQuyen();
            Enable(this.btnAdd.Enabled);
        }

        /// <summary>
        /// Phans the quyen.
        /// </summary>
        private void PhanQuyen()
        {
            try
            {
                //TD_BangKeHoachTuyenDungBLL _busschild = new TD_BangKeHoachTuyenDungBLL();
                if (LayerCommon.CurrentUser.IsPhongNhanSu.Value)
                {
                    this.btnSave.Enabled = _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                }
                else
                {
                    this.btnSave.Enabled = !_bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                }
                if (LayerCommon.CurrentUser.IsPhongNhanSu.Value)
                {
                    radioButton1.Enabled = _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                    radioButton2.Enabled = _bussKeHoach.GetIsPhongNhanSu(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id);
                }

                TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
                if (item != null)
                {
                    foreach (TD_BangKeHoachTuyenDung subitem in _list)
                    {
                        if (subitem.Id == item.Id)
                        {
                            radioButton1.Enabled = !item.DaDuyet.Value;
                            radioButton2.Enabled = !item.DaDuyet.Value;
                        }
                    }
                }
            }
            catch
            {

            }

        }

        /// <summary>
        /// Loads the data.
        /// </summary>
        private void LoadData()
        {
            this.brscGrdData.DataSource = _bussKeHoach.GetDataByPhongBanQuy(((DM_PhongBan)this.cboPhongBan.SelectedItem).Id, CommonUtil.IsInt(this.cboQuy.Text),int.Parse(txtNam.Text));

            Enable(false);

            _list.Clear();
            foreach(TD_BangKeHoachTuyenDung item in ((List<TD_BangKeHoachTuyenDung>)brscGrdData.DataSource))
            {
                if (item.DaDuyet.HasValue && item.DaDuyet.Value==true)
                {
                    _list.Add(item);
                }
            }
            radioButton1.Enabled = true;
            radioButton2.Enabled = true;

            TD_BangKeHoachTuyenDung item1 = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item1 != null)
            {
                foreach (TD_BangKeHoachTuyenDung subitem in _list)
                {
                    if (subitem.Id == item1.Id)
                    {
                        radioButton1.Enabled = !item1.DaDuyet.Value;
                        radioButton2.Enabled = !item1.DaDuyet.Value;
                    }
                    //else
                    //{
                    //    radioButton1.Enabled = true;
                    //    radioButton2.Enabled = true;
                    //}
                }
            }
            //brscGrdData.ResetCurrentItem();
            // phan quyen nhansu phongban
           // PhanQuyen();
        }

        #endregion

        #region ---- Events ----

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                SF101 frm = new SF101();
                frm.KeHoach = item;
                frm.InputPhanQuyen = this.btnAdd.Enabled;
                MngForms.ShowDialog(frm);
                
            }
        }
 
        #endregion

        #region ---- Textbox ----

        /// <summary>
        /// Handles the TextChanged event of the txtNam control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtNam_TextChanged(object sender, EventArgs e)
        {
            LoadData();
        } 

        #endregion

        #region ---- Combobox ----

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Handles the TextChanged event of the cboPhongBan control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboPhongBan_TextChanged(object sender, EventArgs e)
        {
            brscGrdData.DataSource = _bussKeHoach.GetDataByTenPhongBan(this.cboPhongBan.Text);
            //// phan quyen nhan su phong ban
           // PhanQuyen();
           // LoadData();
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Handles the TextChanged event of the cboQuy control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboQuy_TextChanged(object sender, EventArgs e)
        {
            LoadData();
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

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;

            if (item != null)
            {
                TD_BangKeHoachTuyenDungBLL _bussnew = new TD_BangKeHoachTuyenDungBLL();

                if (_bussnew.CheckedIsHasValue(item.Id))
                {
                    SF101 frm = new SF101();
                    frm.KeHoach = item;
                    frm.InputPhanQuyen = this.btnAdd.Enabled;
                    MngForms.ShowDialog(frm);
                }
                else
                {
                    UICommon.ShowMsgWarning("MSG018");
                    return;
                }

            }

        }

        /// <summary>
        /// Handles the Click event of the xemChiTiếtToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void xemChiTiếtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;

            if (item != null)
            {
                TD_BangKeHoachTuyenDungBLL _bussnew = new TD_BangKeHoachTuyenDungBLL();

                if (_bussnew.CheckedIsHasValue(item.Id))
                {
                    SF101 frm = new SF101();
                    frm.KeHoach = item;
                    frm.InputPhanQuyen = this.btnAdd.Enabled;
                    MngForms.ShowDialog(frm);
                }
                else
                {
                    UICommon.ShowMsgWarning("MSG018");
                    return;
                }

            }
        }

        /// <summary>
        /// Handles the CurrentItemChanged event of the brscGrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void brscGrdData_CurrentItemChanged(object sender, EventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                foreach (TD_BangKeHoachTuyenDung subitem in _list)
                {
                    if (subitem.Id == item.Id)
                    {
                        radioButton1.Enabled = !item.DaDuyet.Value;
                        radioButton2.Enabled = !item.DaDuyet.Value;
                    }
                    //else
                    //{
                    //    radioButton1.Enabled = true;
                    //    radioButton2.Enabled = true;
                    //}
                }
            }
        }

        void brscGrdData_PositionChanged(object sender, EventArgs e)
        {
            TD_BangKeHoachTuyenDung item = brscGrdData.Current as TD_BangKeHoachTuyenDung;
            if (item != null)
            {
                foreach (TD_BangKeHoachTuyenDung subitem in _list)
                {
                    if (subitem.Id == item.Id)
                    {
                        radioButton1.Enabled = !item.DaDuyet.Value;
                        radioButton2.Enabled = !item.DaDuyet.Value;
                    }
                    //else
                    //{
                    //    radioButton1.Enabled = true;
                    //    radioButton2.Enabled = true;
                    //}
                }
            }
        }
 

        #endregion

        #endregion
    }
}
