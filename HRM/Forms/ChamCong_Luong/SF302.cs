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
using HRM.DataAccess.ChamCong_TinhLuong;
using HRM.DataAccess.NguoiDung;

namespace HRM.Forms.ChamCong_Luong
{
    public partial class SF302 : GridBaseForm
    {
        #region ---- Variables ----

        private TL_BangLuongBLL _bussBangLuong = null;
      
        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF302"/> class.
        /// </summary>
        public SF302()
        {
            InitializeComponent();
            this.btnAdd.Visible = true;
            this.btnSave.Visible = true;
            this.btnDelete.Visible = true;
            this.toolStripSeparator1.Visible = false;
            this.btnSearch.Click += new EventHandler(btnSearch_Click);
            this.btnAdd.Click += new EventHandler(btnAdd_Click);
            this.btnDelete.Click += new EventHandler(btnDelete_Click);
            _bussBangLuong = new TL_BangLuongBLL();
            this.btnAdd.Text = "Xem bảng lương";
            this.btnSearch.Text = "Tính lương";
            this.btnSearch.Image = imageList1.Images[0];
            this.btnAdd.Image = imageList1.Images[2];
            this.btnDelete.Text = "Khóa lương";
            this.btnDelete.Image = imageList1.Images[3];
            ToolStripItem mnuItem = null;

            for (int i = this.contextMenuStrip1.Items.Count - 1; i >= 0; i--)
            {
                mnuItem = contextMenuStrip1.Items[i];
                this.GrdData.InternalContextMenuStripEx.Items.Insert(0, mnuItem);
            }
          //  UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "TienHeSoLuong", "TienNgayNghi", "TienThuongLe", "TienPhat", "TienThuongKhac", "PhuCapKhac", "TamUng", "ThucLinh", "MucLuongCoBan");
            UICommon.GridFormatMoney(GrdData.TableDescriptor.Columns, "TienHeSoLuong", "TienNgayNghi", "ThucLinh");
        }

        
        #endregion

        #region ---- Override Methods ----

        /// <summary>
        /// Saves the data.
        /// </summary>
        protected override void SaveData()
        {
            if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                return;
            }
            if (!(brscGrdData.Count > 0))
            {
                return;
            }
            base.SaveData();
            UICommon.StartUpdate();
            List<TL_BangLuong> list = (List<TL_BangLuong>)brscGrdData.DataSource;
            _bussBangLuong.UpdateDataList(list);
            UICommon.StopUpdate();
            UICommon.ShowSplashPanelUpdateMsg();

        } 

        #endregion

        #region ---- Private Methods ----

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


            return true;
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
           
            if (CheckedBeforProcess())
            {
                if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
                {
                    UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                    return;
                }
                 
                if (_bussBangLuong.CheckedHasDataChamCong_TinhLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
                {
                    UICommon.ShowMsgInfo("MSG045","chấm công");
                    return;
                }

                UICommon.StartProcess();

                brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                GrdData.DataSource = brscGrdData;

                UICommon.StopProcess();
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAdd control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnAdd_Click(object sender, EventArgs e)
        {
            if (CheckedBeforProcess())
            {
                UICommon.StartProcess();

                brscGrdData.DataSource = _bussBangLuong.LoadDataTinhLuongXem(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                GrdData.DataSource = brscGrdData;

                UICommon.StopProcess();

                if (!(brscGrdData.Count > 0))
                {
                    UICommon.ShowMsgInfo("MSG009");
                    return;
                }

                
            }
        }

        /// <summary>
        /// Handles the Click event of the btnDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void btnDelete_Click(object sender, EventArgs e)
        {
            if (CheckedBeforProcess())
            {

                if (!(brscGrdData.Count > 0))
                {
                    UICommon.ShowMsgInfo("MSG009");
                    return;
                }

                if (UICommon.ShowMsgConfirm("MSG038") == DialogResult.Yes)// Xac nhan
                {
                    _bussBangLuong.KhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text));
                    UICommon.ShowSplashPanelUpdateMsg();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the phụCấpKhácToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void phụCấpKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                return;
            }
            
            TL_BangLuong bangluong = this.brscGrdData.Current as TL_BangLuong;
            
            if (bangluong != null)
            {
                SF309 frm = new SF309();
                frm.BangLuong = bangluong;
                frm.ShowDialog();
                bangluong.PhuCapKhac = frm.SoTien;
                bangluong.ThucLinh = bangluong.ThucLinh + bangluong.PhuCapKhac;
            }
        }

        /// <summary>
        /// Handles the Click event of the giảmTrừKhácToolStripMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        ///  22/08/11
        /// PC
        private void giảmTrừKhácToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_bussBangLuong.CheckedKhoaLuong(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text)))
            {
                UICommon.ShowMsgInfo("MSG039", txtThang.Text);
                return;
            }

            TL_BangLuong bangluong = this.brscGrdData.Current as TL_BangLuong;

            if (bangluong != null)
            {
                SF312 frm = new SF312();
                frm.BangLuong = bangluong;
                frm.ShowDialog();
                bangluong.GiamTruKhac = frm.SoTien;
                bangluong.ThucLinh = bangluong.ThucLinh - bangluong.GiamTruKhac;
            }
        }

        #endregion

       

        #endregion
    }
}
