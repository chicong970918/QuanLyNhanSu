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
using HRM.DataAccess.ChamCong_TinhLuong;
using Syncfusion.Windows.Forms.Grid.Grouping;

namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF306 : GridBaseForm
    {
       #region ---- Variables ----

        private NV_NhanVienBLL _bussNhanVien = null;
        private TL_TongHopChamCongBLL _bussTHChamCong = null;
        private TL_TongHopChamCongNhanVienBLL _bussTHChamCongNV = null;
        private TL_BangLuongBLL _bussBangLuong = null;
        #endregion

       #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF200"/> class.
        /// </summary>
        public SF306()
        {
            InitializeComponent();
            this.btnAdd.Visible = false;
            this.btnDelete.Visible = false;
            _bussTHChamCongNV = new TL_TongHopChamCongNhanVienBLL();
            _bussBangLuong = new TL_BangLuongBLL();
           // this.btnSave.Visible = false;
            //this.toolStripSeparator1.Visible = false;
            //this.btnSearch.Visible = false;
            this.toolStripSeparator2.Visible = false;
            this.btnSearch.Text = "Lọc dữ liệu";
            this.btnPrintTemplate.Visible = false;
            _bussNhanVien = new NV_NhanVienBLL();
            _bussTHChamCong = new TL_TongHopChamCongBLL();
            this.Load += new EventHandler(SF306_Load);
            UICommon.GridFormatDate(GrdData.TableDescriptor.Columns, true, "NgaySinh");
            //GridFormatCheckBox
           // UICommon.GridFormatCheckBox(GrdData.TableDescriptor.Columns, true, "C1");
            this.treeInfo.AfterSelect += new TreeViewEventHandler(treeInfo_AfterSelect);
            //this.GrdData.TableControlCellDoubleClick += new Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCellClickEventHandler(GrdData_TableControlCellDoubleClick);
            btnExcelTemplate.Click += new EventHandler(btnExcelTemplate_Click);
            btnPrintTemplate.Click += new EventHandler(btnPrintTemplate_Click);

            //btnPrintTemplate.Visible = true;
            btnExcelTemplate.Visible = true;
            btnExcelTemplate.Text = "Xuất Excel HS Nhân viên";
            btnPrintTemplate.Text = "In thẻ nhân viên";
            btnExcel.Visible = false;
            btnPrint.Visible = false;
            this.btnSearch.Click += new EventHandler(btnSearch_Click);

        }
 
        #endregion

       #region ---- Override Methods ----

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {

            // base.SaveData();
            brscGrdData.EndEdit();
            GrdData.EndEdit();

            if (brscGrdData.Count > 0)
            {
                UICommon.StartUpdate();
                List<TL_TongHopChamCongNhanVien> list = (List<TL_TongHopChamCongNhanVien>)brscGrdData.DataSource;

                TL_TongHopChamCongNhanVien item = this.brscGrdData.Current as TL_TongHopChamCongNhanVien;
                string ssss = item.MaNhanVien;
                _bussTHChamCongNV.UpdateDataList(list.ToList<TL_TongHopChamCongNhanVien>());
                UICommon.StopUpdate();
                UICommon.ShowSplashPanelUpdateMsg();
            }
            else
            {
                UICommon.ShowMsgInfo("MSG009");
            }
            
            //  this.Close();


        } 

        #endregion

       #region ---- Private Methods ----

        /// <summary>
        /// Gets the day of week.
        /// </summary>
        /// <param name="pstring">The pstring.</param>
        /// <returns></returns>
        public string GetDayOfWeek(string pstring)
        {
            pstring = pstring.Trim();
            if (pstring == "Monday")
            {
                return "T2";
            }
            if (pstring == "Tuesday")
            {
                return "T3";
            }
            if (pstring == "Wednesday")
            {
                return "T4";
            }
            if (pstring == "Thursday")
            {
                return "T5";
            }
            if (pstring == "Friday")
            {
                return "T6";
            }
            if (pstring == "Saturday")
            {
                return "T7";
            }
            if (pstring == "Sunday")
            {
                return "CN";
            }

            return string.Empty;
        }

        /// <summary>
        /// Checkeds the befor process.
        /// </summary>
        /// <returns></returns>
        private bool CheckedBeforProcess()
        {
            if (string.IsNullOrEmpty(txtThang.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lbThang.Text);
                this.txtThang.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtNam.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lblNam.Text);
                this.txtNam.Focus();
                return false;
            }
            if (CommonUtil.IsInt(txtNam.Text) < CacheData.Context.GetSystemDate().Year)
            {
                UICommon.ShowMsgInfo("MSG017", lblNam.Text, "năm hiện tại");
                this.txtNam.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Visibles the column.
        /// </summary>
        private void VisibleColumn()
        {
            GrdData.TableDescriptor.VisibleColumns.Clear();
        //    string s = string.Empty;
            int ngaytrongthang = DateTime.DaysInMonth(CommonUtil.IsInt(txtNam.Text),CommonUtil.IsInt(txtThang.Text));

            foreach (GridColumnDescriptor column in GrdData.TableDescriptor.Columns)
            {

                // Hide regular mark
                if (column.MappingName.IndexOf(TL_TongHopChamCongNhanVien.F_C) >= 0 &&
                   int.Parse(column.MappingName.Substring(1, column.MappingName.Length - 1)) > ngaytrongthang)
                {

                    continue;
                }
                else
                {
                    if (column.MappingName.Substring(0, 1) == TL_TongHopChamCongNhanVien.F_C)
                    {
                        DateTime date = new DateTime(CommonUtil.IsInt(txtNam.Text), CommonUtil.IsInt(txtThang.Text), int.Parse(column.MappingName.Substring(1, column.MappingName.Length - 1)));
                   // + GetDayOfWeek(date.DayOfWeek.ToString());

                        GrdData.TableDescriptor.VisibleColumns.Add(new GridVisibleColumnDescriptor(column.MappingName));
                        column.HeaderText = "Chiều "+ GetDayOfWeek(date.DayOfWeek.ToString());;
                    }
                    else
                    {
                        if (column.MappingName.IndexOf(TL_TongHopChamCongNhanVien.F_S) >= 0 &&
                 int.Parse(column.MappingName.Substring(1, column.MappingName.Length - 1)) > ngaytrongthang)
                        {
                            continue;
                        }
                        else
                        {
                            if (column.MappingName.Substring(0, 1) == TL_TongHopChamCongNhanVien.F_S)
                            {
                                DateTime date = new DateTime(CommonUtil.IsInt(txtNam.Text), CommonUtil.IsInt(txtThang.Text), int.Parse(column.MappingName.Substring(1, column.MappingName.Length - 1)));
                                column.HeaderText = "Sáng " + GetDayOfWeek(date.DayOfWeek.ToString());
                                GrdData.TableDescriptor.VisibleColumns.Add(new GridVisibleColumnDescriptor(column.MappingName));
                            }
                            else
                            {
                                GrdData.TableDescriptor.VisibleColumns.Add(new GridVisibleColumnDescriptor(column.MappingName));
                            }
                        }
                    }

                }
            }
           
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
           // brscGrdData.DataSource = _bussNhanVien.LoadNhanVienTheoPhongBanHopDongChinhThuc((int)treeInfo.SelectedNode.Tag);

            //GrdData.DataSource = brscGrdData;
        }

        /// <summary>
        /// Handles the Load event of the SF200 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SF306_Load(object sender, EventArgs e)
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
                root.ImageIndex = 0;
                root.SelectedImageIndex = 1;
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
            //NV_NhanVien item = brscGrdData.Current as NV_NhanVien;
            //if (item != null)
            //{
            //    SF212 frm = new SF212();
            //    frm.IdNhanVien = item.Id;
            //    frm.ShowDialog();
            //    brscGrdData.DataSource = _bussNhanVien.LoadNhanVienTheoPhongBan((int)treeInfo.SelectedNode.Tag);

            //    GrdData.DataSource = brscGrdData;
            //}
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

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnSearch_Click(object sender, EventArgs e)
        {
            if (CheckedBeforProcess())
            {
               
                if (_bussTHChamCongNV.CheckedIsExitedTongHopChamCongNhanVien(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text), (int)treeInfo.SelectedNode.Tag))
                {
                    brscGrdData.DataSource = _bussTHChamCongNV.LoadDataByConditionBangTongHopNhanVien(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text), (int)treeInfo.SelectedNode.Tag);
                    GrdData.DataSource = brscGrdData;
                }
                else
                {
                    brscGrdData.DataSource = _bussTHChamCongNV.LoadDataByCondition(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text), (int)treeInfo.SelectedNode.Tag);
                    GrdData.DataSource = brscGrdData;
                }
                VisibleColumn();

                GrdData.TableDescriptor.AllowEdit = !_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
            }
        }


        #endregion

    }
}
