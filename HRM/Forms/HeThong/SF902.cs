using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess;
using Library.Controls;
using Library;
using HRM.Entities;

namespace HRM.Forms.HeThong
{
    public partial class SF902 : GridBaseForm
    {
        #region Variable and Cóntructor

        private QL_NguoiDungNhomNguoiDungBLL _busNguoiDungNhom;

        private HRMCheckBoxColumn _colCheckDanhSach;

        private HRMCheckBoxColumn _colCheckNhomNguoiDung;


        /// <summary>
        /// Initializes a new instance of the <see cref="SF902"/> class.
        /// </summary>
        public SF902()
        {
            InitializeComponent();
            InitForm();
            LoadData();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Loads the data.
        /// </summary>
        public void LoadData()
        {
            // Remove event
            //cboNhomNguoiDung.SelectedIndexChanged -= new EventHandler(cboNhomNguoiDung_SelectedIndexChanged);

            //// Load data combobox
            //cboNhomNguoiDung.DataSource = _busNguoiDungNhom.GetNhomNguoiDung();

            //// Add vent
            ////cboNhomNguoiDung.SelectedIndexChanged +=new EventHandler(cboNhomNguoiDung_SelectedIndexChanged);

            //cboNhomNguoiDung.DisplayMember = "TenNhom";
            //cboNhomNguoiDung.ValueMember = "Id";

            // Get all nguoi dung
            brscDanhSachNguoiDung.DataSource = _busNguoiDungNhom.GetAllNguoiDung();
            grdDanhSach.DataSource = brscDanhSachNguoiDung;

            brscGrdData.DataSource = _busNguoiDungNhom.GetNguoiDungByIdNhom(((QL_NhomNguoiDung)(cboNhomNguoiDung.SelectedItem)).Id);
            grdNguoiDung.DataSource = brscGrdData;

        }

        private void LoadCombo()
        {
             // Load data combobox
            cboNhomNguoiDung.DataSource = _busNguoiDungNhom.GetNhomNguoiDung();

            // Add vent
            //cboNhomNguoiDung.SelectedIndexChanged +=new EventHandler(cboNhomNguoiDung_SelectedIndexChanged);

            cboNhomNguoiDung.DisplayMember = "TenNhom";
            cboNhomNguoiDung.ValueMember = "Id";
        }

        #endregion

        #region Protected Mothods
        

        #endregion

        #region Private Methods

        /// <summary>
        /// Inits the form.
        /// </summary>
        private void InitForm()
        {
            _busNguoiDungNhom = new QL_NguoiDungNhomNguoiDungBLL();
            LoadCombo();
            // Insert check box in grid
            _colCheckDanhSach = new HRMCheckBoxColumn(this.grdDanhSach, string.Empty, 0) { UniqueProperty = "Id" };

            _colCheckNhomNguoiDung = new HRMCheckBoxColumn(this.grdNguoiDung, string.Empty, 0) { UniqueProperty = "Id" };

            // Event

            cboNhomNguoiDung.SelectedIndexChanged += new EventHandler(cboNhomNguoiDung_SelectedIndexChanged);

            // Set Visible controls

            btnAdd.Visible = false;
            btnDelete.Visible = false;
            btnExcel.Visible = false;
            btnPrint.Visible = false;
            btnSave.Visible = false;
            btnSearch.Visible = false;

            toolStripSeparator1.Visible = false;
            toolStripSeparator2.Visible = false;
            toolStripSeparator3.Visible = false;

        }

        /// <summary>
        /// Gets the nguoi dung selected.
        /// </summary>
        /// <returns></returns>
        private List<int> GetNguoiDungSelected()
        {
            // Get Nguoi dung buoc duoc chon
            List<int> idNguoiDung = _colCheckDanhSach.GetCheckedRow();

            return idNguoiDung;
        }

        /// <summary>
        /// Gets the nguoi dung selected.
        /// </summary>
        /// <returns></returns>
        private List<int> GetNguoiDungDelete()
        {
            // Get Nguoi dung buoc duoc chon
            List<int> idNguoiDung = _colCheckNhomNguoiDung.GetCheckedRow();

            return idNguoiDung;
        }

        #endregion

        #region Event

        /// <summary>
        /// Handles the Click event of the btnPhai control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnPhai_Click(object sender, EventArgs e)
        {

            List<int> listNguoiDung = GetNguoiDungSelected();

            if (listNguoiDung.Count > 0)
            {
                if (listNguoiDung.Count > 0 && cboNhomNguoiDung.SelectedIndex >= 0)
                {
                    _busNguoiDungNhom.UpdateNguoiDungToNhom(listNguoiDung, (int)cboNhomNguoiDung.SelectedValue);
                }
                UICommon.ShowSplashPanelUpdateMsg();

                _colCheckDanhSach.ResetToNoCheck();                
                
                LoadData();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnTrai control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnTrai_Click(object sender, EventArgs e)
        {
            List<int> listNguoiDung = GetNguoiDungDelete();

            if (listNguoiDung.Count > 0)
            {
                if (listNguoiDung.Count > 0 && cboNhomNguoiDung.SelectedIndex >= 0)
                {
                    _busNguoiDungNhom.DeleteNguoiDungTrongNhom(listNguoiDung, (int)cboNhomNguoiDung.SelectedValue);
                }
                UICommon.ShowSplashPanelUpdateMsg();

                LoadData();

                _colCheckNhomNguoiDung.ResetToNoCheck();
            }
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the cboNhomNguoiDung control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        public void cboNhomNguoiDung_SelectedIndexChanged(object sender, EventArgs e)
        {
            brscGrdData.DataSource = _busNguoiDungNhom.GetNguoiDungByIdNhom(((QL_NhomNguoiDung)(cboNhomNguoiDung.SelectedItem)).Id);
        }

        #endregion

       
    }
}
