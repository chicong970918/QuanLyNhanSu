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
    public partial class SF301 : GridBaseForm
    {
        #region ---- Variables ----

        private DanhMucPhongBanBLL _bussPhongBan = null;
        private TL_TongHopChamCongNhanVienBLL _bussTHChamCongNV = null;

        #endregion

        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SF301"/> class.
        /// </summary>
        public SF301()
        {
            InitializeComponent();
            Designer();
            _bussPhongBan = new DanhMucPhongBanBLL();
            _bussTHChamCongNV = new TL_TongHopChamCongNhanVienBLL();
            this.btnAdd.Visible = false;
            this.btnSave.Visible = false;
            this.btnDelete.Visible = false;
            this.toolStripSeparator1.Visible = false;
            LoadCombobox();
            this.btnSearch.Click+=new EventHandler(btnSearch_Click);
          
            //this.toolStripSeparator2.Visible = false;
        }
        

        #endregion

        public void Designer()
        {
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor2 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor3 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor4 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor5 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor6 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor7 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor8 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor9 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor10 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor11 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor12 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor13 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor14 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor15 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor16 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor17 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor18 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor19 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor20 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor21 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor22 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor23 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor24 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor25 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor26 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor27 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor28 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor29 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor30 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor31 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor32 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor33 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor34 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor35 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor36 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor37 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor38 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor39 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor40 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor41 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor42 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor43 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor44 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor45 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor46 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor47 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor48 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor49 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor50 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor51 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor52 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor53 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor54 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor55 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor56 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor57 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor58 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor59 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor60 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor61 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor62 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor63 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor64 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor gridColumnDescriptor65 = new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor();
            Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor gridStackedHeaderDescriptor1 = new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor();

            gridColumnDescriptor1.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor1.HeaderText = "Mã nhân viên";
            gridColumnDescriptor1.MappingName = "MaNhanVien";
            gridColumnDescriptor1.ReadOnly = true;
            gridColumnDescriptor1.Width = 109;
            gridColumnDescriptor2.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor2.HeaderText = "Họ đệm";
            gridColumnDescriptor2.MappingName = "HoDem";
            gridColumnDescriptor2.ReadOnly = true;
            gridColumnDescriptor2.Width = 146;
            gridColumnDescriptor3.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor3.HeaderText = "Tên";
            gridColumnDescriptor3.MappingName = "Ten";
            gridColumnDescriptor3.ReadOnly = true;
            gridColumnDescriptor3.Width = 108;
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.CellValueType = typeof(bool);
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.CheckBoxOptions.CheckedValue = "true";
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.CheckBoxOptions.UncheckedValue = "false";
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor4.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor4.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor4.MappingName = "S1";
            gridColumnDescriptor4.Width = 69;
            gridColumnDescriptor5.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor5.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor5.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor5.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor5.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor5.MappingName = "C1";
            gridColumnDescriptor5.Width = 72;
            gridColumnDescriptor6.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor6.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor6.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor6.MappingName = "S2";
            gridColumnDescriptor7.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor7.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor7.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor7.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor7.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor7.MappingName = "C2";
            gridColumnDescriptor8.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor8.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor8.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor8.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor8.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor8.MappingName = "S3";
            gridColumnDescriptor9.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor9.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor9.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor9.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor9.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor9.MappingName = "C3";
            gridColumnDescriptor10.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor10.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor10.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor10.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor10.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor10.MappingName = "S4";
            gridColumnDescriptor11.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor11.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor11.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor11.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor11.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor11.MappingName = "C4";
            gridColumnDescriptor12.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor12.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor12.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor12.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor12.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor12.MappingName = "S5";
            gridColumnDescriptor13.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor13.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor13.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor13.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor13.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor13.MappingName = "C5";
            gridColumnDescriptor14.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor14.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor14.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor14.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor14.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor14.MappingName = "S6";
            gridColumnDescriptor15.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor15.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor15.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor15.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor15.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor15.MappingName = "C6";
            gridColumnDescriptor16.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor16.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor16.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor16.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor16.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor16.MappingName = "S7";
            gridColumnDescriptor17.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor17.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor17.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor17.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor17.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor17.MappingName = "C7";
            gridColumnDescriptor18.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor18.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor18.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor18.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor18.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor18.MappingName = "S8";
            gridColumnDescriptor19.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor19.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor19.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor19.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor19.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor19.MappingName = "C8";
            gridColumnDescriptor20.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor20.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor20.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor20.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor20.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor20.MappingName = "S9";
            gridColumnDescriptor21.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor21.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor21.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor21.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor21.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor21.MappingName = "C9";
            gridColumnDescriptor22.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor22.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor22.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor22.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor22.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor22.MappingName = "S10";
            gridColumnDescriptor23.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor23.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor23.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor23.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor23.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor23.MappingName = "C10";
            gridColumnDescriptor24.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor24.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor24.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor24.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor24.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor24.MappingName = "S11";
            gridColumnDescriptor25.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor25.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor25.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor25.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor25.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor25.MappingName = "C11";
            gridColumnDescriptor26.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor26.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor26.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor26.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor26.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor26.MappingName = "S12";
            gridColumnDescriptor27.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor27.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor27.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor27.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor27.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor27.MappingName = "C12";
            gridColumnDescriptor28.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor28.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor28.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor28.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor28.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor28.MappingName = "S13";
            gridColumnDescriptor29.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor29.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor29.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor29.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor29.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor29.MappingName = "C13";
            gridColumnDescriptor30.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor30.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor30.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor30.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor30.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor30.MappingName = "S14";
            gridColumnDescriptor31.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor31.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor31.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor31.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor31.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor31.MappingName = "C14";
            gridColumnDescriptor32.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor32.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor32.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor32.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor32.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor32.MappingName = "S15";
            gridColumnDescriptor33.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor33.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor33.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor33.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor33.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor33.MappingName = "C15";
            gridColumnDescriptor34.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor34.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor34.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor34.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor34.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor34.MappingName = "S16";
            gridColumnDescriptor35.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor35.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor35.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor35.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor35.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor35.MappingName = "C16";
            gridColumnDescriptor36.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor36.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor36.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor36.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor36.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor36.MappingName = "S17";
            gridColumnDescriptor37.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor37.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor37.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor37.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor37.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor37.MappingName = "C17";
            gridColumnDescriptor38.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor38.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor38.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor38.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor38.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor38.MappingName = "S18";
            gridColumnDescriptor39.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor39.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor39.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor39.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor39.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor39.MappingName = "C18";
            gridColumnDescriptor40.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor40.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor40.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor40.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor40.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor40.MappingName = "S19";
            gridColumnDescriptor41.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor41.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor41.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor41.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor41.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor41.MappingName = "C19";
            gridColumnDescriptor42.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor42.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor42.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor42.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor42.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor42.MappingName = "S20";
            gridColumnDescriptor43.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor43.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor43.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor43.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor43.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor43.MappingName = "C20";
            gridColumnDescriptor44.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor44.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor44.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor44.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor44.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor44.MappingName = "S21";
            gridColumnDescriptor45.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor45.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor45.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor45.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor45.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor45.MappingName = "C21";
            gridColumnDescriptor46.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor46.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor46.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor46.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor46.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor46.MappingName = "S22";
            gridColumnDescriptor47.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor47.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor47.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor47.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor47.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor47.MappingName = "C22";
            gridColumnDescriptor48.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor48.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor48.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor48.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor48.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor48.MappingName = "S23";
            gridColumnDescriptor49.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor49.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor49.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor49.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor49.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor49.MappingName = "C23";
            gridColumnDescriptor50.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor50.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor50.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor50.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor50.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor50.MappingName = "S24";
            gridColumnDescriptor51.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor51.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor51.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor51.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor51.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor51.MappingName = "C24";
            gridColumnDescriptor52.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor52.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor52.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor52.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor52.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor52.MappingName = "S25";
            gridColumnDescriptor53.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor53.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor53.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor53.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor53.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor53.MappingName = "C25";
            gridColumnDescriptor54.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor54.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor54.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor54.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor54.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor54.MappingName = "S26";
            gridColumnDescriptor55.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor55.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor55.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor55.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor55.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor55.MappingName = "C26";
            gridColumnDescriptor56.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor56.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor56.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor56.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor56.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor56.MappingName = "S27";
            gridColumnDescriptor57.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor57.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor57.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor57.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor57.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor57.MappingName = "C27";
            gridColumnDescriptor58.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor58.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor58.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor58.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor58.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor58.MappingName = "S28";
            gridColumnDescriptor59.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor59.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor59.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor59.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor59.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor59.MappingName = "C28";
            gridColumnDescriptor60.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor60.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor60.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor60.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor60.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor60.MappingName = "S29";
            gridColumnDescriptor61.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor61.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor61.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor61.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor61.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor61.MappingName = "C29";
            gridColumnDescriptor62.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor62.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor62.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor62.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor62.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor62.MappingName = "S30";
            gridColumnDescriptor63.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor63.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor63.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor63.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor63.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor63.MappingName = "C30";
            gridColumnDescriptor64.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor64.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor64.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor64.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor64.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor64.MappingName = "S31";
            gridColumnDescriptor65.Appearance.AlternateRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor65.Appearance.AnyRecordFieldCell.CellType = "CheckBox";
            gridColumnDescriptor65.Appearance.AnyRecordFieldCell.HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Center;
            gridColumnDescriptor65.Appearance.AnyRecordFieldCell.VerticalAlignment = Syncfusion.Windows.Forms.Grid.GridVerticalAlignment.Middle;
            gridColumnDescriptor65.GroupByOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            gridColumnDescriptor65.MappingName = "C31";
            this.GrdData.TableDescriptor.Columns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridColumnDescriptor[] {
            gridColumnDescriptor1,
            gridColumnDescriptor2,
            gridColumnDescriptor3,
            gridColumnDescriptor4,
            gridColumnDescriptor5,
            gridColumnDescriptor6,
            gridColumnDescriptor7,
            gridColumnDescriptor8,
            gridColumnDescriptor9,
            gridColumnDescriptor10,
            gridColumnDescriptor11,
            gridColumnDescriptor12,
            gridColumnDescriptor13,
            gridColumnDescriptor14,
            gridColumnDescriptor15,
            gridColumnDescriptor16,
            gridColumnDescriptor17,
            gridColumnDescriptor18,
            gridColumnDescriptor19,
            gridColumnDescriptor20,
            gridColumnDescriptor21,
            gridColumnDescriptor22,
            gridColumnDescriptor23,
            gridColumnDescriptor24,
            gridColumnDescriptor25,
            gridColumnDescriptor26,
            gridColumnDescriptor27,
            gridColumnDescriptor28,
            gridColumnDescriptor29,
            gridColumnDescriptor30,
            gridColumnDescriptor31,
            gridColumnDescriptor32,
            gridColumnDescriptor33,
            gridColumnDescriptor34,
            gridColumnDescriptor35,
            gridColumnDescriptor36,
            gridColumnDescriptor37,
            gridColumnDescriptor38,
            gridColumnDescriptor39,
            gridColumnDescriptor40,
            gridColumnDescriptor41,
            gridColumnDescriptor42,
            gridColumnDescriptor43,
            gridColumnDescriptor44,
            gridColumnDescriptor45,
            gridColumnDescriptor46,
            gridColumnDescriptor47,
            gridColumnDescriptor48,
            gridColumnDescriptor49,
            gridColumnDescriptor50,
            gridColumnDescriptor51,
            gridColumnDescriptor52,
            gridColumnDescriptor53,
            gridColumnDescriptor54,
            gridColumnDescriptor55,
            gridColumnDescriptor56,
            gridColumnDescriptor57,
            gridColumnDescriptor58,
            gridColumnDescriptor59,
            gridColumnDescriptor60,
            gridColumnDescriptor61,
            gridColumnDescriptor62,
            gridColumnDescriptor63,
            gridColumnDescriptor64,
            gridColumnDescriptor65});
            this.GrdData.TableDescriptor.ForceEmptyRelations = true;
            this.GrdData.TableDescriptor.FrozenColumn = "Ten";
            this.GrdData.TableDescriptor.Name = "";
            gridStackedHeaderDescriptor1.Appearance.StackedHeaderCell.VerticalScrollbar = true;
            gridStackedHeaderDescriptor1.HeaderText = "Thông tin nhân viên";
            gridStackedHeaderDescriptor1.Name = "StackedHeader 1";
            gridStackedHeaderDescriptor1.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("MaNhanVien"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("HoDem"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("Ten")});
            this.GrdData.TableDescriptor.StackedHeaderRows.Add(new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderRowDescriptor("Row 1", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor[] {
                gridStackedHeaderDescriptor1,
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 1", "Ngày 1", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S1"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C1")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 2", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S2"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C2")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 3", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S3"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C3")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 4", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S4"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C4")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 5", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S5"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C5")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 6", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S6"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C6")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 7", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S7"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C7")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 8", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S8"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C8")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 9", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S9"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C9")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 10", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S10"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C10")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 11", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S11"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C11")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 12", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S12"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C12")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 13", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S13"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C13")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 14", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S14"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C14")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 15", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S15"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C15")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 16", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S16"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C16")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 17", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S17"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C17")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 18", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S18"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C18")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 19", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S19"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C19")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 20", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S20"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C20")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 21", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S21"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C21")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 22", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S22"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C22")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 23", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S23"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C23")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 24", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S24"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C24")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 25", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S25"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C25")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 26", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S26"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C26")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 27", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S27"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C27")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 28", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S28"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C28")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 29", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S29"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C29")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 30", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S30"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C30")}),
                new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderDescriptor("Ngày 31", new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor[] {
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("S31"),
                            new Syncfusion.Windows.Forms.Grid.Grouping.GridStackedHeaderVisibleColumnDescriptor("C31")})}));
            this.GrdData.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.GrdData.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaption = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaptionPlusMinus = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.ShowCaptionSummaryCells = false;
            this.GrdData.TableDescriptor.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.TableDescriptor.VisibleColumns.AddRange(new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor[] {
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("MaNhanVien"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("HoDem"),
            new Syncfusion.Windows.Forms.Grid.Grouping.GridVisibleColumnDescriptor("Ten")});
            this.GrdData.TableOptions.RowHeaderWidth = 40;
            this.GrdData.TableOptions.ShowRowHeader = true;
            this.GrdData.TableOptions.SummaryRowHeight = 23;
            this.GrdData.Text = "hrmGrigouping1";
            this.GrdData.TopLevelGroupOptions.SummaryRowPlacement = Syncfusion.Windows.Forms.Grid.Grouping.GridSummaryRowPlacement.BeforeDetails;
            this.GrdData.VersionInfo = "1.0.0.0";
           
        }

        #region ---- Private Methods ----

        /// <summary>
        /// Loads the combobox.
        /// </summary>
        private void LoadCombobox()
        {
            cboPhongBan.DataSource = _bussPhongBan.GetPhongBan();
            cboPhongBan.DisplayMember = "TenPhongBan";
            cboPhongBan.ValueMember = "Id";
        }

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
            if (cboPhongBan.SelectedIndex < 0)
            {
                UICommon.ShowMsgInfo("MSG005", lblPhongBan.Text);
                this.cboPhongBan.Focus();
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
                UICommon.StartProcess();

                //if (_bussTHChamCongNV.CheckedIsExitedTongHopChamCongNhanVien(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text), (int)((DM_PhongBan)cboPhongBan.SelectedItem).Id))
                //{
                //    brscGrdData.DataSource = _bussTHChamCongNV.LoadDataByConditionBangTongHopNhanVien(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text), (int)((DM_PhongBan)cboPhongBan.SelectedItem).Id);
                //    GrdData.DataSource = brscGrdData;
                //}
                //else
                //{
                    brscGrdData.DataSource = _bussTHChamCongNV.LoadDataByCondition(CommonUtil.IsInt(txtThang.Text), CommonUtil.IsInt(txtNam.Text), (int)((DM_PhongBan)cboPhongBan.SelectedItem).Id);
                    GrdData.DataSource = brscGrdData;
             //   }
                VisibleColumn();

                UICommon.StopProcess();
            }
        }  

        #endregion

        #endregion
    }
}
