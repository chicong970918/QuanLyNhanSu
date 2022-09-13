using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.Grouping;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms;


namespace Library
{
    public sealed class HRMCheckBoxColumn
    {
         public const string SELECTED_ALL_VALUE = "ALL";
        private const int CHECKBOX_WIDTH = 13;
        private const int CHECKBOX_HEIGHT = 13;

        #region Variable

        private GridGroupingControl _ggc;
        private GridColumnDescriptor _colCheckBox;
        public const string _colName = "colCheckBox";
        private Dictionary<int, bool> _dicValues;
        private Dictionary<int, bool> _hardValue;
        private string _uniqueProperty = string.Empty;
        private bool _checkAll = false;

        private bool _ReadOnly = false;        

        public delegate void OnCheckBoxClicked(int RowIndex, object currentRecord, bool value);
        public event OnCheckBoxClicked EventCheckBoxClick;

        #endregion

        #region Contructor

        public HRMCheckBoxColumn(GridGroupingControl pGrid, string pHeaderText = " ", int index = 0, int width = 40)
        {
            _ggc = pGrid;

            _dicValues = new Dictionary<int, bool>();

            _colCheckBox = new GridColumnDescriptor(_colName, string.Empty, pHeaderText) { Width = width };

            CheckBoxHeaderCell headerCell = new CheckBoxHeaderCell(_ggc.TableModel);
            pGrid.TableModel.CellModels.Add("CheckBoxHeaderCell", headerCell);


            GridTableCellStyleInfo styleRecordCell = _colCheckBox.Appearance.AnyRecordFieldCell;

            styleRecordCell.HorizontalAlignment = GridHorizontalAlignment.Center;
            styleRecordCell.CellType = "CheckBox";
            styleRecordCell.CellValueType = typeof(bool);
            styleRecordCell.Clickable = true;
            styleRecordCell.Enabled = true;
            styleRecordCell.Themed = true;

            GridTableCellStyleInfo styleHeaderCell = _colCheckBox.Appearance.ColumnHeaderCell;

            styleHeaderCell.HorizontalAlignment = GridHorizontalAlignment.Center;
            styleHeaderCell.CellType = "CheckBoxHeaderCell";
            styleHeaderCell.CellValueType = typeof(bool);
            styleHeaderCell.Enabled = true;

            //_colCheckBox.Appearance.ColumnHeaderCell.CellType=

            _ggc.TableDescriptor.Columns.Add(_colCheckBox);
            AddNewVisibleColumn(pGrid, _colName);

            _ggc.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(_ggc_QueryCellStyleInfo);
            _ggc.TableControlCheckBoxClick += new GridTableControlCellClickEventHandler(_ggc_TableControlCheckBoxClick);
            _ggc.TableControl.MouseUp += new MouseEventHandler(TableControl_MouseUp);
        }

        #endregion

        #region Private Method

        private int GetValue(object pValue, string pProperty)
        {
            return (int)pValue.GetType().GetProperty(pProperty).GetValue(pValue, null);
        }

        private void AddNewVisibleColumn(GridGroupingControl pGridGrouping, string p)
        {
            // Store last visible columns
            GridVisibleColumnDescriptorCollection visibleCols = pGridGrouping.TableDescriptor.VisibleColumns.Clone();

            // Clear all visible column
            pGridGrouping.TableDescriptor.VisibleColumns.Clear();

            // Add TrackingState column
            pGridGrouping.TableDescriptor.VisibleColumns.Add(new GridVisibleColumnDescriptor(p));

            // Re add last visible columns
            foreach (GridVisibleColumnDescriptor col in visibleCols)
            {
                pGridGrouping.TableDescriptor.VisibleColumns.Add(col);
            }
        }

        #endregion

        #region Event

        private void _ggc_TableControlCheckBoxClick(object sender, GridTableControlCellClickEventArgs e)
        {
            GridTableCellStyleInfo style = e.TableControl.GetTableViewStyleInfo(e.Inner.RowIndex, e.Inner.ColIndex);

            if (style.TableCellIdentity.Column != null && style.TableCellIdentity.Column.Name == _colName)
            {

                switch (style.TableCellIdentity.TableCellType)
                {
                    case GridTableCellType.RecordFieldCell:
                    case GridTableCellType.AlternateRecordFieldCell:

                        if (e.TableControl.Table.CurrentRecord == null)
                            return;

                        int uniqueValue = GetValue(style.TableCellIdentity.DisplayElement.GetData(), UniqueProperty);

                        if (uniqueValue == 0)
                        {
                            if (EventCheckBoxClick != null)
                            {
                                EventCheckBoxClick(e.Inner.RowIndex, e.TableControl.Table.CurrentRecord.GetData(), !(bool)style.CellValue);
                            }
                            return;
                        }

                        bool value = !(bool)style.CellValue;

                        style.CellValue = value;

                        if (value)
                        {
                            _dicValues[uniqueValue] = value;

                            _checkAll = (_dicValues.Count + HardValue.Count) == _ggc.Table.Records.Count;
                        }
                        else
                        {
                            _dicValues.Remove(uniqueValue);

                            _checkAll = false;
                        }

                        if (EventCheckBoxClick != null)
                        {
                            EventCheckBoxClick(e.Inner.RowIndex, e.TableControl.Table.CurrentRecord.GetData(), value);
                        }

                        e.Inner.Cancel = true;
                        _ggc.Refresh();
                        break;

                    case GridTableCellType.ColumnHeaderCell:

                        if (_ReadOnly)
                        {
                            return;
                        }

                        _checkAll = !_checkAll;

                        if (_checkAll)
                        {
                            foreach (Record record in _ggc.Table.Records)
                            {
                                int recordID = GetValue(record.GetData(), UniqueProperty);

                                if (HardValue.ContainsKey(recordID))
                                    continue;

                                _dicValues[recordID] = _checkAll;

                            }
                        }
                        else
                        {
                            _dicValues.Clear();
                        }

                        style.Tag = _checkAll;
                        _ggc.Refresh();

                        if (EventCheckBoxClick != null)
                        {
                            EventCheckBoxClick(e.Inner.RowIndex, SELECTED_ALL_VALUE, _checkAll);
                        }

                        break;
                }
            }
        }

        private void _ggc_QueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            if (e.TableCellIdentity.Column != null && e.TableCellIdentity.Column.Name == _colName)
            {
                switch (e.TableCellIdentity.TableCellType)
                {
                    case GridTableCellType.AlternateRecordFieldCell:
                    case GridTableCellType.RecordFieldCell:

                        bool value = false;

                        int valueData = (int)GetValue(e.TableCellIdentity.DisplayElement.GetData(), UniqueProperty);

                        if (HardValue.ContainsKey(valueData))
                        {
                            e.Style.CellValue = HardValue[valueData];
                            e.Style.ReadOnly = true;

                            return;
                        }


                        if (_dicValues.ContainsKey(valueData))
                            value = _dicValues[valueData];

                        e.Style.CellValue = value;

                        break;

                    case GridTableCellType.ColumnHeaderCell:

                        e.Style.Tag = _checkAll;

                        break;

                    case GridTableCellType.AddNewRecordFieldCell:

                        e.Style.CellType = "Static";
                        e.Style.ReadOnly = true;
                        e.Style.AllowEnter = false;

                        break;
                }
                e.Handled = true;
            }
        }

        private void TableControl_MouseUp(object sender, MouseEventArgs e)
        {
            int row, col;
            _ggc.TableControl.PointToRowCol(new Point(e.X, e.Y), out row, out col);
            GridTableCellStyleInfo style = _ggc.TableControl.Model[row, col];

            IMouseController controller;
            _ggc.TableControl.MouseControllerDispatcher.HitTest(new Point(e.X, e.Y), e.Button, e.Clicks, out controller);

            if (controller != null && controller.Name == "DragGroupHeader")
            {
                _ggc.TableControl.GetCellRenderer(row, col).RaiseMouseUp(row, col, e);
            }
        }

        #endregion

        #region Public Method

        public List<int> GetCheckedRow()
        {
            return this.HardValue.Select(m => m.Key)
                .Union(_dicValues.Where(m => m.Value).Select(m => m.Key)).ToList<int>();
        }

        /// <summary>
        /// Resets to no check.
        /// </summary>
        ///  21/08/11
        /// PC
        public void ResetToNoCheck()
        {
            _checkAll = false;
            _dicValues.Clear();
            _ggc.Refresh();
        }

        /// <summary>
        /// Checks all.
        /// </summary>
        public void CheckAll()
        {
            foreach (var key in this._dicValues.Keys)
            {
                this._dicValues[key] = true;
            }
            this._ggc.Refresh();
        }

        #endregion

        #region Property

        /// <summary>
        /// Unique Property in datasource
        /// </summary>
        [Description("Unique Property in datasource")]
        [DefaultValue("")]
        public string UniqueProperty
        {
            get
            {
                return _uniqueProperty;
            }
            set
            {
                _uniqueProperty = value;
            }
        }

        public string ColName
        {
            get { return _colName; }
        }

        public Dictionary<int, bool> HardValue
        {
            get
            {
                if (_hardValue == null)
                    _hardValue = new Dictionary<int, bool>();

                return _hardValue;
            }
        }

        public bool ReadOnly
        {
            get { return _ReadOnly; }
            set { _ReadOnly = value; }
        }

        #endregion

        #region Private Class

        private class CheckBoxHeaderCell : GridTableColumnHeaderCellModel
        {
            public CheckBoxHeaderCell(GridModel grid)
                : base(grid)
            {

            }

            public override GridCellRendererBase CreateRenderer(GridControlBase control)
            {
                return new CheckBoxHeaderCellRender(control, this);
            }

            private class CheckBoxHeaderCellRender : GridTableColumnHeaderCellRenderer
            {
                #region Variables

                private Rectangle _rectChk;
                private int countClick = 0;

                #endregion

                #region Contructors

                public CheckBoxHeaderCellRender(GridControlBase grid, CheckBoxHeaderCell cellModel)
                    : base(grid, cellModel)
                {
                    DropDownImp = new GridDropDownCellImp(this);

                    DropDownButton = new GridCellButton(this) { Text = "X" };

                    grid.CellClick += new GridCellClickEventHandler(grid_CellClick);
                }

                #endregion

                #region Events

                private void grid_CellClick(object sender, GridCellClickEventArgs e)
                {
                    GridTableControl tableControl = sender as GridTableControl;
                    GridTableCellStyleInfo style = tableControl.Model[e.RowIndex, e.ColIndex];

                    if (style.TableCellIdentity.Column != null && style.TableCellIdentity.Column.Name == _colName)
                    {
                        if (_rectChk.Contains(e.MouseEventArgs.Location))
                        {
                            countClick++;
                            if (countClick == 2)
                            {
                                countClick = 0;

                                tableControl.RaiseCheckBoxClick(e.RowIndex, e.ColIndex, e.MouseEventArgs);
                                style = tableControl.Model[e.RowIndex, e.ColIndex];

                                bool cellValue = bool.Parse(style.Tag.ToString());
                            }

                        }
                    }
                }

                #endregion

                #region Override Methods

                protected override IGridDropDownContainer CreateDropDownContainer()
                {
                    return null;
                }

                protected override void OnDrawCellButtonBackground(GridCellButton button, Graphics g, Rectangle rect, ButtonState buttonState, GridStyleInfo style)
                {
                    GridTableCellStyleInfo styleTableCell = style as GridTableCellStyleInfo;

                    GridColumnDescriptor col = styleTableCell.TableCellIdentity.Column;

                    // Get width header
                    int colWidth = col.Width <= 0 ? CHECKBOX_WIDTH : col.Width;

                    // Get height header
                    int colHeight = styleTableCell.TableCellIdentity.Table.TableOptions.ColumnHeaderRowHeight;

                    // Cal location checkbox
                    int X = rect.X - (colWidth / 2) - (CHECKBOX_WIDTH / 2);
                    int Y = rect.Y + (colHeight / 2) - (CHECKBOX_HEIGHT / 2);

                    rect = new Rectangle(X, Y, CHECKBOX_WIDTH, CHECKBOX_HEIGHT);
                    _rectChk = rect;

                    bool tag = style.Tag != null && bool.Parse(style.Tag.ToString());


                    ControlPaint.DrawCheckBox(g, rect, tag ? ButtonState.Checked : ButtonState.Normal);
                }

                #endregion

            }
        }

        #endregion
    }
}
