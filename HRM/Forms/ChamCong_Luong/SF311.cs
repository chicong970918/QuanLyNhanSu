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
using HRM.DataAccess.Catalogs;

namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF311 : GridBaseForm
    {
        #region ---- Variables ----
        private int _IdNhanVien = 0;
        private NV_NhanVienBLL _busNhanVien = null;
        private DanhMucPhongBanBLL _bussPhongBan = null;
        private TL_TongHopChamCongNhanVienBLL _bussTHChamCongNV = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF301"/> class.
        /// </summary>
        public SF311()
        {
            InitializeComponent();
            _bussPhongBan = new DanhMucPhongBanBLL();
            _bussTHChamCongNV = new TL_TongHopChamCongNhanVienBLL();
            _busNhanVien = new NV_NhanVienBLL();
            this.btnAdd.Visible = false;
            this.btnSave.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator1.Visible = false;
           // LoadCombobox();
            this.btnSearch.Click+=new EventHandler(btnSearch_Click);
          
            //this.toolStripSeparator2.Visible = false;
        }

        #endregion

        #region ---- Private Methods ----

        ///// <summary>
        ///// Loads the combobox.
        ///// </summary>
        //private void LoadCombobox()
        //{
        //    cboPhongBan.DataSource = _bussPhongBan.GetPhongBan();
        //    cboPhongBan.DisplayMember = "TenPhongBan";
        //    cboPhongBan.ValueMember = "Id";
        //}

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
            if (string.IsNullOrEmpty(txtMaNhanVien.Text))//  
            {
                UICommon.ShowMsgInfo("MSG005", lblMaNhanVien.Text);
                this.txtMaNhanVien.Focus();
                return false;
            }
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
            

            return true;
        }

        /// <summary>
        /// Checkeds the process.
        /// </summary>
        /// <returns></returns>
        private bool CheckedProcess()
        {
            if (LayerCommon.CurrentUser.IdNhanVien.HasValue)
            {
                _IdNhanVien = LayerCommon.CurrentUser.IdNhanVien.Value;
                NV_NhanVien nhanvien = _busNhanVien.GetNhanVienbyId(_IdNhanVien);
                if (nhanvien.MaNhanVien == txtMaNhanVien.Text)
                {
                 
                    return true;
                }
            }
            UICommon.ShowMsgWarning("MSG040","bảng chấm công");
            return false;
        }


        /// <summary>
        /// Visibles the column.
        /// </summary>
        private void VisibleColumn()
        {
            GrdData.TableDescriptor.VisibleColumns.Clear();
            //    string s = string.Empty;
            int ngaytrongthang = DateTime.DaysInMonth(CommonUtil.IsInt(txtNam.Text), CommonUtil.IsInt(txtThang.Text));

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
                        column.HeaderText = "Chiều " + GetDayOfWeek(date.DayOfWeek.ToString()); ;
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

        #region ---- Button ----

        /// <summary>
        /// Handles the Click event of the btnSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnSearch_Click(object sender, EventArgs e)
        {
             
            if (CheckedBeforProcess())
            {
                NV_NhanVien nhanvien = (_busNhanVien.CheckedNhanVienIsExited(txtMaNhanVien.Text));
                if (nhanvien == null)
                {
                    UICommon.ShowMsgInfo("MSG027");
                    return;
                }
                
                if (CheckedProcess())
                {
                    UICommon.StartProcess();

                    brscGrdData.DataSource = _bussTHChamCongNV.TraCuuBangTongHopNhanVien(CommonUtil.IsInt(txtThang.Text), 
                        CommonUtil.IsInt(txtNam.Text), _IdNhanVien);
                        GrdData.DataSource = brscGrdData;

                        if (!(brscGrdData.Count > 0))
                        {
                            UICommon.ShowMsgInfo("MSG009");
                        }

                    VisibleColumn();

                    UICommon.StopProcess();
                }
            }
        }  

        #endregion

        #endregion
    }
}
