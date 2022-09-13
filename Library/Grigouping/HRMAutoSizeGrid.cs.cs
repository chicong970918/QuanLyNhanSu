using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System.Windows.Forms;
using System.ComponentModel;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Grouping;


namespace Library
{
  public  class HRMAutoSizeGrid
    {
       #region Variable

        private GridGroupingControl _ggc;
        private Dictionary<string, int> _dicColumnNotResize;
        private bool _initialed = false;
        private Dictionary<string, int> _dicStartupValues = new Dictionary<string, int>();
        private bool _allowMoveColumnNotResize = true;
        private bool _allowSortColumnNoResize = true;
        private bool _painted = false;
        private bool _allowAutoResizeWhenRecordValueChanged = false;
        private bool _allowAutoResizeWhenSourceListChanged = false;
        private int _totalWidth = 0;

        #endregion

        #region Contructor

        public HRMAutoSizeGrid(GridGroupingControl pGrid)
        {
            _ggc = pGrid;

            _dicColumnNotResize = new Dictionary<string, int>();

            _ggc.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.None;
            _ggc.TableOptions.ShowRowHeader = false;

            _ggc.Paint += new PaintEventHandler(_ggc_Paint);
            _ggc.TableControl.SizeChanged += new EventHandler(TableControl_SizeChanged);
            _ggc.TableControl.ResizingColumns += new GridResizingColumnsEventHandler(TableControl_ResizingColumns);
            _ggc.TableControl.QueryAllowSortColumn += new GridQueryAllowSortColumnEventHandler(TableControl_QueryAllowSortColumn);
        }

        #endregion

        #region Event

        private void TableControl_QueryAllowDragColumn(object sender, GridQueryAllowDragColumnEventArgs e)
        {
            e.AllowDrag = !_dicColumnNotResize.ContainsKey(e.Column);
        }

        private void TableControl_ResizingColumns(object sender, GridResizingColumnsEventArgs e)
        {
            switch (e.Reason)
            {
                case GridResizeCellsReason.MouseMove:
                case GridResizeCellsReason.DoubleClick:
                    if (e.Columns.Left == 0)
                    {
                        e.Cancel = true;
                        return;
                    }

                    GridVisibleColumnDescriptor colVis = _ggc.TableDescriptor.VisibleColumns[e.Columns.Left - 1];

                    if (colVis != null && _dicColumnNotResize.ContainsKey(colVis.Name))
                    {
                        e.Cancel = true;
                    }
                    break;
            }
        }

        private void TableControl_SizeChanged(object sender, EventArgs e)
        {
            AutoSizeGrid();
        }

        private void _ggc_Paint(object sender, PaintEventArgs e)
        {
            if (!_painted)
            {
                AutoSizeGrid();

                _painted = true;
            }
        }

        private void Engine_SourceListListChangedCompleted(object sender, TableListChangedEventArgs e)
        {
            if (_painted)
            {
                _initialed = !_initialed;
                AutoSizeGrid();
            }
        }

        private void _ggc_RecordValueChanged(object sender, RecordValueChangedEventArgs e)
        {
            //_initialed = !_initialed;
            //AutoSizeGrid();
            AutoSizeColumn(e.Column);
        }

        private void TableControl_QueryAllowSortColumn(object sender, GridQueryAllowSortColumnEventArgs e)
        {
            e.AllowSort = !_dicColumnNotResize.ContainsKey(e.Column.Name);
        }

        #endregion

        #region Public Method

        public void AutoSizeColumn(string pColName)
        {
            GridColumnDescriptor col = _ggc.TableDescriptor.Columns[pColName];

            if (col != null && _ggc.TableDescriptor.VisibleColumns.Contains(pColName) && !_dicColumnNotResize.ContainsKey(pColName))
            {
                col.Width = 1;

                _ggc.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Col(_ggc.TableDescriptor.VisibleColumns.IndexOf(pColName) + 1), GridResizeToFitOptions.IncludeHeaders);

                _dicStartupValues[pColName] = col.Width;

                AutoSizeGrid();
            }
        }

        public void AutoSizeGrid()
        {
            if (_ggc.TableDescriptor.VisibleColumns.Count == 0)
            {
                return;
            }

            _totalWidth = (_ggc.TableOptions.ShowRowHeader ? _ggc.TableOptions.RowHeaderWidth : 0) + (_ggc.TableControl.VScroll ? SystemInformation.VerticalScrollBarWidth : 0);
            int iCountVisCol = 0;
            int iCountVisColWithoutNoResize = 0;

            List<int> lIndexCol = new List<int>();

            foreach (GridVisibleColumnDescriptor colVis in _ggc.TableDescriptor.VisibleColumns)
            {
                iCountVisCol++;
                if (!_dicColumnNotResize.ContainsKey(colVis.Name))
                {
                    iCountVisColWithoutNoResize++;
                }
                else
                {
                    lIndexCol.Add(iCountVisCol);

                    GridColumnDescriptor col = _ggc.TableDescriptor.Columns[colVis.Name];

                    if (col != null)
                    {
                        col.Width = _dicColumnNotResize[col.Name];
                        _totalWidth += col.Width;
                    }
                }

            }

            if (!_initialed)
            {
                _dicStartupValues.Clear();
                int iCount = 0;
                foreach (GridVisibleColumnDescriptor colVis in _ggc.TableDescriptor.VisibleColumns)
                {
                    GridColumnDescriptor col = _ggc.TableDescriptor.Columns[colVis.Name];

                    if (col != null && !_dicColumnNotResize.ContainsKey(col.Name))
                    {
                        col.Width = 1;

                        _ggc.TableModel.ColWidths.ResizeToFit(GridRangeInfo.Cols(iCount + 1, iCount + 1), GridResizeToFitOptions.IncludeHeaders);

                        if (!_dicStartupValues.ContainsKey(col.Name))
                        {
                            _dicStartupValues.Add(col.Name, col.Width);
                        }
                    }
                    iCount++;
                }

                _initialed = true;
            }

            _totalWidth += _dicStartupValues.Select(m => m.Value).Sum();

            _totalWidth -= _dicColumnNotResize.Where(m => !_ggc.TableDescriptor.VisibleColumns.Contains(m.Key)).Sum(m => m.Value);

            if (_totalWidth < _ggc.Width)
            {
                int restWidth = _ggc.Width - _totalWidth;
                int perWidth = restWidth / iCountVisColWithoutNoResize;

                foreach (KeyValuePair<string, int> kvp in _dicStartupValues)
                {
                    _ggc.TableDescriptor.Columns[kvp.Key].Width = perWidth + _dicStartupValues[kvp.Key];
                    _totalWidth += perWidth;
                }

                GridColumnDescriptor lastColumn = new GridColumnDescriptor();

                for (int i = iCountVisCol - 1; i > -1; i--)
                {
                    GridVisibleColumnDescriptor colVis = _ggc.TableDescriptor.VisibleColumns[i];

                    if (colVis != null && !_dicColumnNotResize.ContainsKey(colVis.Name))
                    {
                        lastColumn = _ggc.TableDescriptor.Columns[colVis.Name];
                        break;
                    }
                }

                if (_totalWidth < _ggc.Width)
                {
                    lastColumn.Width += _ggc.Width - _totalWidth - 2;
                }
                else if (_totalWidth > _ggc.Width)
                {
                    lastColumn.Width -= _totalWidth - _ggc.Width;
                }
                else
                {
                    _ggc.TableControl.HScrollBehavior = GridScrollbarMode.Disabled;
                }
            }
            else
            {
                _ggc.TableControl.HScrollBehavior = GridScrollbarMode.Enabled;
            }
        }

        #endregion

        #region Property

        public GridGroupingControl GroupingControl
        {
            get
            {
                return _ggc;
            }
            set
            {
                _ggc = value;
            }
        }

        public Dictionary<string, int> NotResizeColumn
        {
            get
            {
                return _dicColumnNotResize;
            }
        }

        [DefaultValue(true)]
        public bool AllowMoveColumnNotResize
        {
            get
            {
                return _allowMoveColumnNotResize;
            }
            set
            {
                _allowMoveColumnNotResize = value;
                if (!_allowMoveColumnNotResize)
                {
                    _ggc.TableControl.QueryAllowDragColumn += new GridQueryAllowDragColumnEventHandler(TableControl_QueryAllowDragColumn);
                }
                else
                {
                    _ggc.TableControl.QueryAllowDragColumn -= new GridQueryAllowDragColumnEventHandler(TableControl_QueryAllowDragColumn);
                }
            }
        }

        [DefaultValue(true)]
        public bool AllowSortColumnNotResize
        {
            get
            {
                return _allowSortColumnNoResize;
            }
            set
            {
                _allowSortColumnNoResize = value;

                if (!_allowSortColumnNoResize)
                {
                    _ggc.TableControl.QueryAllowSortColumn += new GridQueryAllowSortColumnEventHandler(TableControl_QueryAllowSortColumn);
                }
                else
                {
                    _ggc.TableControl.QueryAllowSortColumn -= new GridQueryAllowSortColumnEventHandler(TableControl_QueryAllowSortColumn);
                }
            }
        }

        [DefaultValue(false)]
        public bool AllowAutoResizeWhenRecordValueChanged
        {
            get { return _allowAutoResizeWhenRecordValueChanged; }
            set
            {
                _allowAutoResizeWhenRecordValueChanged = value;

                if (_allowAutoResizeWhenRecordValueChanged)
                {
                    _ggc.RecordValueChanged += new RecordValueChangedEventHandler(_ggc_RecordValueChanged);
                }
                else
                {
                    _ggc.RecordValueChanged -= new RecordValueChangedEventHandler(_ggc_RecordValueChanged);
                }
            }
        }

        [DefaultValue(false)]
        public bool AllowAutoResizeWhenSourceListChanged
        {
            get { return _allowAutoResizeWhenSourceListChanged; }
            set
            {
                _allowAutoResizeWhenSourceListChanged = value;

                if (_allowAutoResizeWhenSourceListChanged)
                {
                    _ggc.Engine.SourceListListChangedCompleted += new TableListChangedEventHandler(Engine_SourceListListChangedCompleted);
                }
                else
                {
                    _ggc.Engine.SourceListListChangedCompleted -= new TableListChangedEventHandler(Engine_SourceListListChangedCompleted);
                }
            }
        }


        #endregion
    }
}
