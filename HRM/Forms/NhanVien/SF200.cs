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
using HRM.DataAccess.QuanLyNhanVien;
using System.Diagnostics;

namespace HRM.Forms.NhanVien
{
    public partial class SF200 : GridBaseForm
    {
        #region ---- Variables ----

        private NV_NhanVienBLL _bussNhanVien = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF200"/> class.
        /// </summary>
        public SF200()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            this.btnSave.Visible = false;
            this.toolStripSeparator1.Visible = false;
            this.btnSearch.Visible = false;
            this.toolStripSeparator2.Visible = false;
            _bussNhanVien = new NV_NhanVienBLL();
            this.Load += new EventHandler(SF200_Load);
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgaySinh");
            this.treeInfo.AfterSelect += new TreeViewEventHandler(treeInfo_AfterSelect);
            this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);

            btnPrintTemplate.Visible = true;
            btnExcelTemplate.Visible = true;
            btnExcelTemplate.Text = "Xuất Excel HS Nhân viên";
            btnPrintTemplate.Text = "In thẻ nhân viên";
            btnExcel.Visible = false;
            btnPrint.Visible = false;
            radioButton2.CheckedChanged += new EventHandler(radioButton2_CheckedChanged);
            radioButton1.CheckedChanged += new EventHandler(radioButton1_CheckedChanged);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButton2 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  03/08/11
        /// PC
        void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            brscGrdData.DataSource = _bussNhanVien.LoadNhanVienTheoPhongBanTraCuu((int)treeInfo.SelectedNode.Tag, !radioButton1.Checked);

            GrdData.DataSource = brscGrdData;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the radioButton1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  03/08/11
        /// PC
        void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            brscGrdData.DataSource = _bussNhanVien.LoadNhanVienTheoPhongBanTraCuu((int)treeInfo.SelectedNode.Tag, !radioButton1.Checked);

            GrdData.DataSource = brscGrdData;
        }

        #endregion

        #region ---- Events ----

        /// <summary>
        /// Handles the AfterSelect event of the treeInfo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        private void treeInfo_AfterSelect(object sender, TreeViewEventArgs e)
        {
            brscGrdData.DataSource = _bussNhanVien.LoadNhanVienTheoPhongBanTraCuu((int)treeInfo.SelectedNode.Tag,!radioButton1.Checked);

            GrdData.DataSource = brscGrdData;
        }

        /// <summary>
        /// Handles the Load event of the SF200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF200_Load(object sender, EventArgs e)
        {
            TreeNode root = null;
            TreeNode subNode = null;
            TreeNode child = null;
            treeInfo.ImageList = imageList1;
            // Clear old nodes
            if (treeInfo.Nodes.Count > 0)
            {
                treeInfo.Nodes.Clear();
            }

            List<DM_PhongBan> listPhongBan = CacheData.GetDanhMucPhongBan().ToList<DM_PhongBan>();

            foreach (DM_PhongBan phongban in listPhongBan)
            {
                root = treeInfo.Nodes.Add(phongban.TenPhongBan);
                root.Tag = phongban.Id;
                root.ImageIndex = 2;
                root.SelectedImageIndex = 3;
                //root.ImageIndex = 1;
            }

            treeInfo.ExpandAll();

        }

        /// <summary>
        /// Handles the TableControlCellDoubleClick event of the GrdData control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs"/> instance containing the event data.</param>
        private void GrdData_TableControlCellDoubleClick(object sender, Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventArgs e)
        {
            NV_NhanVien item = brscGrdData.Current as NV_NhanVien;
            if (item != null)
            {
                SF212 frm = new SF212();
                frm.IdNhanVien = item.Id;
                frm.ShowDialog();
                brscGrdData.DataSource = _bussNhanVien.LoadNhanVienTheoPhongBanTraCuu((int)treeInfo.SelectedNode.Tag, !radioButton1.Checked);

                GrdData.DataSource = brscGrdData;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnPrintTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>17/06/2011</Date>
        private void btnPrintTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                DrawingCommon draw = new DrawingCommon();
                NV_NhanVien nhanVien = new NV_NhanVien();
                nhanVien = brscGrdData.CurrencyManager.Current as NV_NhanVien;
                string fileName = string.Empty;

                fileName = draw.DrawTemplateNhanVien(nhanVien);
                if (fileName != string.Empty)
                {
                    Process.Start(fileName);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnExcelTemplate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        /// <Author>LONG LY</Author>
        /// <Date>17/06/2011</Date>
        private void btnExcelTemplate_Click(object sender, EventArgs e)
        {
            if (brscGrdData.Count > 0)
            {
                Dictionary<string, string> listThongTin = new Dictionary<string, string>();
                listThongTin.Add("PhongBan", treeInfo.SelectedNode.Text);
                string nam = CacheData.Context.GetSystemDate().Year.ToString();
                listThongTin.Add("Nam", nam);
                ExcelExport excel = new ExcelExport();
                List<NV_NhanVien> listDS = new List<NV_NhanVien>();
                listDS = brscGrdData.DataSource as List<NV_NhanVien>;
                string file = string.Empty;
                excel.ExportDanhSachNhanVienTheoPhongBan(listDS, listThongTin, ref file, true);
            }
            else
            {
                UICommon.ShowMsgInfo("MSG022");
            }
        }

        #endregion
    }
}
