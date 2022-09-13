using System ;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using Syncfusion.GridHelperClasses;
using Syncfusion.Windows.Forms.Tools;
using Syncfusion.Grouping;
using Syncfusion.GroupingGridExcelConverter;
using Syncfusion.GridExcelConverter;
using Library.Properties;
namespace Library
{
    public partial class HRMGrigouping : GridGroupingControl
    {
        #region ---- Enums ----

        /// <summary>
        /// 
        /// </summary>
        public enum SelectionType
        {
            /// <summary>
            /// 
            /// </summary>
            Default,
            /// <summary>
            /// 
            /// </summary>
            None,
            /// <summary>
            /// 
            /// </summary>
            CellOnly,
            /// <summary>
            /// 
            /// </summary>
            RowOnly,
            /// <summary>
            /// 
            /// </summary>
            RowAndColumn,
            /// <summary>
            /// 
            /// </summary>
            ColumnOnly
        }

        #endregion ---- Enums ----

        #region ---- Delegates & Events ----

        public delegate void OnExportExcelHandler(object sender, EventArgs e);

        public event OnExportExcelHandler OnExportExcel;

        #endregion

        #region ---- Member variables ----

        private SelectionType _selectionMode = SelectionType.Default;
        private GridDynamicFilter _filter = null;
        private ContextMenuStripEx _internalContextMenuStripEx;
        private bool _initilized = false;
        private Hashtable _errors;

        private ToolStripMenuItem _toolStripMenuItemFilter;
        private ToolStripMenuItem _toolStripMenuItemGroup;
        private ToolStripMenuItem _toolStripMenuItemExportToExcel;
        private ToolStripButton _toolStripButtonFilter;
        private ToolStripButton _toolStripButtonGroup;
        //private ToolStripButton _toolStripButtonExportToExcel;
        private ToolStripButton _toolStripButtonAddNew;

        private bool _enabledDynamicFilter = true;
        private bool _enabledGroup = true;
        private bool _enabledExportToExcel = true;
        private bool _enabledAutoResizeColumns = false;        

        private const int _minColumnResize = 30;
        private const int _summaryRowHeight = 23;
        private const GridSummaryRowPlacement _gridSummaryRowPlacement = GridSummaryRowPlacement.BeforeDetails;

        private List<String> _columnsNotAutoResize = new List<String>();
        private bool _showOrdinalNumber = false;   
     
        private bool _enableCustomCell = false;
        public string _cellStyleName = "CustomCell";        

        #endregion ---- Member variables ----

        #region ---- Contructor ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SECGridGrouping"/> class.
        /// </summary>
        public HRMGrigouping()
        {
            InitializeComponent();

            this.TableModel.Options.MinResizeColSize = _minColumnResize;
            this.TableOptions.SummaryRowHeight = _summaryRowHeight;
            this.TopLevelGroupOptions.SummaryRowPlacement = _gridSummaryRowPlacement;
            this.ChildGroupOptions.SummaryRowPlacement = _gridSummaryRowPlacement;
            this.ChildGroupOptions.CaptionText = "Có {RecordCount} thông tin liên quan đến {CategoryCaption}: {Category}";
            this.TableControlCurrentCellKeyDown += new GridTableControlKeyEventHandler(HRMGrigouping_TableControlCurrentCellKeyDown);
            this.TableModel.CellModels.Add(_cellStyleName, new HRMCell_MoveColumn.CustomCellModel(TableModel, this));

            
            //auto.AllowAutoResizeWhenRecordValueChanged = true;
            //auto.AllowAutoResizeWhenSourceListChanged = true;
            //auto.NotResizeColumn.Add("TrackingState", 22);
            //auto.NotResizeColumn.Add("Select", 50);
            //auto.NotResizeColumn.Add("colCheckBox", 22);
        }

       
        #endregion ---- Contructor ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the selection mode.
        /// </summary>
        /// <value>The selection mode.</value>
        [DefaultValue(SelectionType.Default)]
        public SelectionType SelectionMode
        {
            get { return _selectionMode; }
            set
            {
                _selectionMode = value;

                this.TableModel.Options.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.GrayWhenLostFocus;
                this.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.None;

                switch (_selectionMode)
                {
                    case SelectionType.Default:
                        this.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
                        break;

                    case SelectionType.None:
                        this.TableModel.Options.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.HideAlways;
                        break;
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled dynamic filter].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enabled dynamic filter]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool EnabledDynamicFilter
        {
            get { return _enabledDynamicFilter; }
            set
            {
                _enabledDynamicFilter = value;
                _toolStripMenuItemFilter.Visible = _enabledDynamicFilter;

                if (_enabledDynamicFilter)
                {
                    this.Refresh();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled group].
        /// </summary>
        /// <value><c>true</c> if [enabled group]; otherwise, <c>false</c>.</value>
        [DefaultValue(true)]
        public bool EnabledGroup
        {
            get { return _enabledGroup; }
            set { _enabledGroup = value; _toolStripMenuItemGroup.Visible = _enabledGroup; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled export to excel].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enabled export to excel]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(true)]
        public bool EnabledExportToExcel
        {
            get { return _enabledExportToExcel; }
            set 
            { 
                _enabledExportToExcel = value;
                _toolStripMenuItemExportToExcel.Visible = _enabledExportToExcel; 
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [enabled auto resize columns].
        /// </summary>
        /// <value>
        /// 	<c>true</c> if [enabled auto resize columns]; otherwise, <c>false</c>.
        /// </value>
        [DefaultValue(false)]
        public bool EnabledAutoResizeColumns
        {
            get { return _enabledAutoResizeColumns; }
            set { _enabledAutoResizeColumns = value; }
        }

        /// <summary>
        /// Gets or sets the shortcut menu associated with the control.
        /// </summary>
        /// <value></value>
        /// <returns>A <see cref="T:System.Windows.Forms.ContextMenu"/> that represents the shortcut menu associated with the control.</returns>
        public override ContextMenu ContextMenu
        {
            get { return base.ContextMenu; }
        }

        /// <summary>
        /// Gets the internal context menu strip ex.
        /// </summary>
        /// <value>The internal context menu strip ex.</value>
        public ContextMenuStripEx InternalContextMenuStripEx
        {
            get { return _internalContextMenuStripEx; }
        }

        /// <summary>
        /// Gets the columns not auto resize.
        /// </summary>
        /// <value>The columns not auto resize.</value>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<String> ColumnsNotAutoResize
        {
            get { return _columnsNotAutoResize; }
        }        

        /// <summary>
        /// Gets a value indicating whether [showed filter].
        /// </summary>
        /// <value><c>true</c> if [showed filter]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowedFilter
        {
            get { return _toolStripMenuItemFilter.Checked; }
        }

        /// <summary>
        /// Gets a value indicating whether [showed group].
        /// </summary>
        /// <value><c>true</c> if [showed group]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowedGroup
        {
            get { return _toolStripMenuItemGroup.Checked; }
        }

        /// <summary>
        /// Gets or sets the tool strip button filter.
        /// </summary>
        /// <value>The tool strip button filter.</value>
        [DefaultValue(null)]
        public ToolStripButton ToolStripButtonFilter
        {
            get { return _toolStripButtonFilter; }
            set
            {
                _toolStripButtonFilter = SetToolStripButton(value, _toolStripButtonFilter, extenalToolStripButton_Click);
            }
        }

        /// <summary>
        /// Gets or sets the tool strip button group.
        /// </summary>
        /// <value>The tool strip button group.</value>
        [DefaultValue(null)]
        public ToolStripButton ToolStripButtonGroup
        {
            get { return _toolStripButtonGroup; }
            set
            {
                _toolStripButtonGroup = SetToolStripButton(value, _toolStripButtonGroup, extenalToolStripButton_Click);
            }
        }

        ///// <summary>
        ///// Gets or sets the tool strip button export to excel.
        ///// </summary>
        ///// <value>The tool strip button export to excel.</value>
        //[DefaultValue(null)]
        //public ToolStripButton ToolStripButtonExportToExcel
        //{
        //    get { return _toolStripButtonExportToExcel; }
        //    set
        //    {
        //        _toolStripButtonExportToExcel = SetToolStripButton(value, _toolStripButtonExportToExcel, extenalToolStripButton_Click);
        //    }
        //}

        /// <summary>
        /// Gets or sets the tool strip button add new.
        /// </summary>
        /// <value>The tool strip button add new.</value>
        [DefaultValue(null)]
        public ToolStripButton ToolStripButtonAddNew
        {
            get { return _toolStripButtonAddNew; }
            set
            {
                _toolStripButtonAddNew = SetToolStripButton(value, _toolStripButtonAddNew, extenalToolStripButton_Click);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether [show ordinal number].
        /// </summary>
        /// <value><c>true</c> if [show ordinal number]; otherwise, <c>false</c>.</value>
        [DefaultValue(false)]
        public bool ShowOrdinalNumber
        {
            get { return _showOrdinalNumber; }
            set
            {
                _showOrdinalNumber = value;

                if (_showOrdinalNumber)
                {
                    this.TableOptions.ShowRowHeader = true;
                    this.TableOptions.RowHeaderWidth = 40;
                }
            }
        }

        [DefaultValue(false)]
        public bool EnableCustomCell
        {
            get
            {
                return _enableCustomCell;
            }
            set
            {
                _enableCustomCell = value;
            }
        }

        #endregion ---- Properties ----

        #region ---- Handle events ----

        /// <summary>
        /// Handles the CurrentCellActivating event of the TableControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.GridCurrentCellActivatingEventArgs"/> instance containing the event data.</param>
        private void TableControl_CurrentCellActivating(object sender, GridCurrentCellActivatingEventArgs e)
        {
            if (_selectionMode == SelectionType.None ||
                _selectionMode == SelectionType.Default)
            {
                return;
            }

            this.TableControl.Refresh();
        }

        /// <summary>
        /// Handles the CurrentCellStartEditing event of the TableControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void TableControl_CurrentCellStartEditing(object sender, CancelEventArgs e)
        {
            e.Cancel = !this.TableDescriptor.AllowEdit;
        }


        /// <summary>
        /// Handles the TableControlCurrentCellKeyDown event of the HRMGrigouping control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlKeyEventArgs"/> instance containing the event data.</param>
        private void HRMGrigouping_TableControlCurrentCellKeyDown(object sender, GridTableControlKeyEventArgs e)
        {
            if (e.Inner.KeyCode == Keys.Enter)
            {
                e.TableControl.CurrentCell.MoveDown();
            }
        }

        /// <summary>
        /// Handles the PrepareViewStyleInfo event of the TableControl control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.GridPrepareViewStyleInfoEventArgs"/> instance containing the event data.</param>
        private void TableControl_PrepareViewStyleInfo(object sender, Syncfusion.Windows.Forms.Grid.GridPrepareViewStyleInfoEventArgs e)
        {
            if (_selectionMode == SelectionType.None ||
                _selectionMode == SelectionType.Default)
            {
                return;
            }

            GridCurrentCell cc = TableControl.CurrentCell;
            GridControlBase grid = this.TableControl.CurrentCell.Grid;

            if (e.RowIndex > grid.Model.Rows.HeaderCount && 
                e.ColIndex > grid.Model.Cols.HeaderCount
                && cc.HasCurrentCellAt(e.RowIndex))
            {
                if (this.TopLevelGroupOptions.ShowFilterBar)
                {
                    if (e.RowIndex == 2)
                    {
                        return;
                    }
                }

                switch (_selectionMode)
                {
                    case SelectionType.RowOnly:
                        // Highlight the current row with SystemColors.Highlight and bold font
                        e.Style.Interior = new BrushInfo(SystemColors.Highlight);
                        e.Style.TextColor = SystemColors.HighlightText;
                        e.Style.Font.Bold = true;
                        break;

                    case SelectionType.CellOnly:
                        // Highlight the current cell with SystemColors.Highlight and bold font                    
                        e.Style.Interior = new BrushInfo(SystemColors.Highlight);
                        e.Style.TextColor = SystemColors.HighlightText;
                        e.Style.Font.Bold = true;
                        break;

                    case SelectionType.ColumnOnly:
                        // Highlight the current column with SystemColors.Highlight and bold font
                        e.Style.Interior = new BrushInfo(SystemColors.Highlight);
                        e.Style.TextColor = SystemColors.HighlightText;
                        e.Style.Font.Bold = true;
                        break;

                    case SelectionType.RowAndColumn:
                        // Highlight the current row & col with SystemColors.Highlight and bold font                    
                        e.Style.Interior = new BrushInfo(SystemColors.Highlight);
                        e.Style.TextColor = SystemColors.HighlightText;
                        e.Style.Font.Bold = true;
                        break;
                }
            }
        }

        /// <summary>
        /// Handles the ExceptionRaised event of the GridGrouping control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Grouping.ExceptionRaisedEventArgs"/> instance containing the event data.</param>
        private void GridGrouping_ExceptionRaised(object sender, Syncfusion.Grouping.ExceptionRaisedEventArgs e)
        {
            e.Cancel = true;
        }

        /// <summary>
        /// Handles the TableControlCurrentCellErrorMessage event of the GridGrouping control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableControlCurrentCellErrorMessageEventArgs"/> instance containing the event data.</param>
        private void GridGrouping_TableControlCurrentCellErrorMessage(object sender, GridTableControlCurrentCellErrorMessageEventArgs e)
        {
            e.Inner.Cancel = true;
            
        }

        /// <summary>
        /// Handles the QueryCellStyleInfo event of the GridGrouping control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Syncfusion.Windows.Forms.Grid.Grouping.GridTableCellStyleInfoEventArgs"/> instance containing the event data.</param>
        private void GridGrouping_QueryCellStyleInfo(object sender, GridTableCellStyleInfoEventArgs e)
        {
            // Show row header oridinal except in group
            if (_showOrdinalNumber && this.TableOptions.ShowRowHeader && 
                this.TableDescriptor.GroupedColumns.Count == 0)
            {
                // if in dynamic filter mode then get filtered rows else get total records
                int header = this.TableModel.RowCount - (this.EnabledDynamicFilter ? this.Table.EngineTable.FilteredRecords.Count : this.Table.Records.Count);

                // In first column
                if (e.TableCellIdentity.ColIndex == 0 && e.TableCellIdentity.RowIndex > header)
                {
                    e.Style.CellType = "Header";
                    e.Style.Text = (e.TableCellIdentity.RowIndex - header).ToString();
                }
            }

            // Didn't have error
            if (_errors == null)
            {
                return;
            }

            object dr = e.TableCellIdentity.DisplayElement.GetData();

            // Had data
            if (dr != null)
            {
                // Row had error
                if (_errors.ContainsKey(dr) && e.TableCellIdentity.Column != null)
                {
                    //if (e.TableCellIdentity.ColIndex == 1)
                    {
                        // Get error
                        Dictionary<string, string> fieldErrors = (Dictionary<string, string>)_errors[dr];

                        // Reset
                        e.Style.BackColor = e.Style.BackColor;
                        e.Style.CellTipText = string.Empty;

                        if (fieldErrors.ContainsKey(e.TableCellIdentity.Column.MappingName))
                        {
                            // Highlight row had errors
                            //e.Style.BackColor = ControlsSettings.GridGrouppingErrorHighLightColor;
                            e.Style.CellTipText = fieldErrors[e.TableCellIdentity.Column.MappingName];
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the toolStripMenuItemGroup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItemGroup_Click(object sender, EventArgs e)
        {
            this.ShowGroupDropArea = _toolStripMenuItemGroup.Checked;

            if (ToolStripButtonGroup != null)
            {
                ToolStripButtonGroup.Checked = _toolStripMenuItemGroup.Checked;
            }

            if (!this.ShowGroupDropArea)
            {
                this.GridGroupDropArea.Selections.Clear();

                // Reset group
                this.TableDescriptor.ResetGroupedColumns();
            }
        }

        /// <summary>
        /// Handles the Click event of the toolStripMenuItemFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItemFilter_Click(object sender, EventArgs e)
        {
            Filter(_toolStripMenuItemFilter.Checked);

            if (ToolStripButtonFilter != null)
            {
                ToolStripButtonFilter.Checked = _toolStripMenuItemFilter.Checked;
            }
        }

        /// <summary>
        /// Handles the Click event of the toolStripMenuItemExportToExcel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void toolStripMenuItemExportToExcel_Click(object sender, EventArgs e)
        {
            if (OnExportExcel != null)
            {
                OnExportExcel(sender, e);
            }
            // ExportToExcel();
        }

        /// <summary>
        /// Handles the Click event of the extenalToolStripButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void extenalToolStripButton_Click(object sender, EventArgs e)
        {
            ToolStripButton ts = sender as ToolStripButton;

            if (ts == ToolStripButtonFilter)
            {
                this.Filter();
            }
            else if (ts == ToolStripButtonGroup)
            {
                this.Group();
            }
            //else if (ts == ToolStripButtonExportToExcel)
            //{
            //    ExportToExcel();
            //}
            else if (ts == ToolStripButtonAddNew)
            {
                this.Table.CurrentRecordManager.AddNew();
            }
        }

        #endregion ---- Handle events ----

        #region ---- Private Methods ----

        /// <summary>
        /// Initializes the component.
        /// </summary>
        public void InitializeComponent()
        {
            this._internalContextMenuStripEx = new Syncfusion.Windows.Forms.Tools.ContextMenuStripEx();
            this._toolStripMenuItemFilter = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemGroup = new System.Windows.Forms.ToolStripMenuItem();
            this._toolStripMenuItemExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this._internalContextMenuStripEx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // _internalContextMenuStripEx
            // 
            this._internalContextMenuStripEx.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripMenuItemFilter,
            this._toolStripMenuItemGroup,
            this._toolStripMenuItemExportToExcel});
            this._internalContextMenuStripEx.Name = "contextMenuStripEx";
            this._internalContextMenuStripEx.ShowCheckMargin = true;
            this._internalContextMenuStripEx.Size = new System.Drawing.Size(170, 70);
            // 
            // _toolStripMenuItemFilter
            // 
            this._toolStripMenuItemFilter.CheckOnClick = true;
            this._toolStripMenuItemFilter.Name = "_toolStripMenuItemFilter";
            this._toolStripMenuItemFilter.Size = new System.Drawing.Size(169, 22);
            this._toolStripMenuItemFilter.Text = "Lọc dữ liệu";
            this._toolStripMenuItemFilter.Click += new System.EventHandler(this.toolStripMenuItemFilter_Click);
            // 
            // _toolStripMenuItemGroup
            // 
            this._toolStripMenuItemGroup.CheckOnClick = true;
            this._toolStripMenuItemGroup.Name = "_toolStripMenuItemGroup";
            this._toolStripMenuItemGroup.Size = new System.Drawing.Size(169, 22);
            this._toolStripMenuItemGroup.Text = "Nhóm dữ liệu";
            this._toolStripMenuItemGroup.Click += new System.EventHandler(this.toolStripMenuItemGroup_Click);
            // 
            // _toolStripMenuItemExportToExcel
            // 
            this._toolStripMenuItemExportToExcel.Name = "_toolStripMenuItemExportToExcel";
            this._toolStripMenuItemExportToExcel.Size = new System.Drawing.Size(169, 22);
            this._toolStripMenuItemExportToExcel.Text = "Xuất ra Excel";
            this._toolStripMenuItemExportToExcel.Click += new System.EventHandler(this.toolStripMenuItemExportToExcel_Click);
            // 
            // HRMGrigouping
            // 
            this.BackColor = System.Drawing.Color.White;
            this.TableDescriptor.TableOptions.ListBoxSelectionMode = System.Windows.Forms.SelectionMode.One;
            this.TableDescriptor.TableOptions.RecordRowHeight = 22;
            this._internalContextMenuStripEx.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        /// <summary>
        /// Filters the specified p enabled.
        /// </summary>
        /// <param name="pEnabled">if set to <c>true</c> [p enabled].</param>
        private void Filter(bool pEnabled)
        {
            // Dynamic filter
            if (pEnabled)
            {
                if (_filter == null)
                {
                    _filter = new GridDynamicFilter();
                }

                _filter.WireGrid(this);
                this.TopLevelGroupOptions.ShowFilterBar = true;

                //Enable the filter for each columns 
                for (int i = 0; i < this.TableDescriptor.Columns.Count; i++)
                {
                    this.TableDescriptor.Columns[i].AllowFilter = true;
                }
            }
            else if (_filter != null)
            {
                // Reset filter
                this.TableDescriptor.ResetRecordFilters();

                // Hide filter bar
                _filter.UnWireGrid(this);
                this.TopLevelGroupOptions.ShowFilterBar = false;
            }
        }

        /// <summary>
        /// Sets the tool strip button.
        /// </summary>
        /// <param name="pNewControl">The p new control.</param>
        /// <param name="pVariable">The p variable.</param>
        /// <param name="pEventHandler">The p event handler.</param>
        /// <returns></returns>
        private ToolStripButton SetToolStripButton(ToolStripButton pNewControl, 
                                                    ToolStripButton pVariable, EventHandler pEventHandler)
        {
            if (pNewControl == pVariable)
            {
                return pVariable;
            }

            // Set null
            if (pNewControl == null && pVariable != null)
            {
                // Remove click event handler
                pVariable.Click -= new EventHandler(pEventHandler);
            }

            // Set value
            pVariable = pNewControl;

            if (pVariable != null)
            {
                // Add click event handler
                pVariable.Click += new EventHandler(pEventHandler);
            }

            return pVariable;
        }

        #endregion ---- Private Methods ----

        #region ---- Override Methods -----

        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        /// <override/>
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
        }

        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        /// <override/>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            if (!_initilized)
            {
                _initilized = true;

                // Customize
                this.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;//..AliceBlue//PapayaWhip//Linen//OldLace//MintCream//BlanchedAlmond
                this.TableDescriptor.Appearance.AlternateRecordFieldCell.BackColor = Color.MintCream; //Color.SkyBlue; //Color.FromArgb(240, 240, 240);//mau xanh  record tren luoi 
                this.BackColor = Color.White;
                this.TableModel.Options.RefreshCurrentCellBehavior = GridRefreshCurrentCellBehavior.RefreshCell;
                this.TableModel.Options.ShowCurrentCellBorderBehavior = GridShowCurrentCellBorder.GrayWhenLostFocus;

                this.Appearance.SummaryEmptyCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
                this.Appearance.SummaryFieldCell.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.SystemColors.Info);
                
                this.ShowOrdinalNumber = true;

                this.ContextMenuStrip = this._internalContextMenuStripEx;

                this.TableControl.PrepareViewStyleInfo += new Syncfusion.Windows.Forms.Grid.GridPrepareViewStyleInfoEventHandler(TableControl_PrepareViewStyleInfo);
                this.TableControl.CurrentCellStartEditing += new CancelEventHandler(TableControl_CurrentCellStartEditing);
                this.TableControl.CurrentCellActivating += new GridCurrentCellActivatingEventHandler(TableControl_CurrentCellActivating);
                this.QueryCellStyleInfo += new GridTableCellStyleInfoEventHandler(GridGrouping_QueryCellStyleInfo);
                this.TableControlCurrentCellErrorMessage += new GridTableControlCurrentCellErrorMessageEventHandler(GridGrouping_TableControlCurrentCellErrorMessage);
                this.ExceptionRaised += new Syncfusion.Grouping.ExceptionRaisedEventHandler(GridGrouping_ExceptionRaised);

                // Text
                this.TableDescriptor.Name = string.Empty;
                this.GridGroupDropArea.DragColumnHeaderText = "Click, giữ và kéo một cột lên đây để thực hiện nhóm dữ liệu.";                
                
            }
        }

        #endregion ---- Override Methods -----

        #region ---- Public methods ----        

        /// <summary>
        /// Exports to excel.
        /// </summary>
        public void ExportToExcel()
        {
            ExportToExcel("Lưu file");
        }

        /// <summary>
        /// Exports to excel.
        /// </summary>
        /// <param name="pTitle">The p title.</param>
        public void ExportToExcel(string pTitle)
        {
            if (this.DataSource == null || this.Table.Records.Count == 0)
            {
                MessageBoxAdv.Show(Resources.GridGrouping_ExportExcel_Error, 
                        Resources.Messenge_Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel(*.xls)|*.xls";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultExt = ".xls";
            saveFileDialog.Title = pTitle;

            if (saveFileDialog.ShowDialog() == DialogResult.OK && saveFileDialog.CheckPathExists)
            {
                GroupingGridExcelConverterControl converter = new GroupingGridExcelConverterControl();

                converter.GroupingGridToExcel(this, saveFileDialog.FileName, ConverterOptions.Visible);

                if (MessageBoxAdv.Show(Resources.GridGrouping_ExportExcel_OpenFileConfirm,
                    Resources.Messenge_ConfirmTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = saveFileDialog.FileName;
                    proc.Start();
                }
            }
        }

        /// <summary>
        /// Filters this instance.
        /// </summary>
        /// <returns></returns>
        public bool Filter()
        {
            _toolStripMenuItemFilter.PerformClick();
            return _toolStripMenuItemFilter.Checked;
        }

        /// <summary>
        /// Groups this instance.
        /// </summary>
        /// <returns></returns>
        public bool Group()
        {
            _toolStripMenuItemGroup.PerformClick();
            return _toolStripMenuItemGroup.Checked;
        }

        /// <summary>
        /// Refreshes the data.
        /// </summary>
        public void RefreshData()
        {
            this.Table.TableDirty = true;
            this.Refresh();
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="pErrors">The p errors.</param>
        public void SetError(Hashtable pErrors)
        {
            this._errors = pErrors;
            this.Refresh();
        }

        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void RemoveError(object entity)
        {
            if (_errors != null && _errors.ContainsKey(entity))
            {
                _errors.Remove(entity);

                this.Refresh();
            }
        }

        /// <summary>
        /// Clears the error.
        /// </summary>
        public void ClearError()
        {
            this._errors = null;
            this.Refresh();
        }

        /// <summary>
        /// Sets the current.
        /// </summary>
        /// <param name="pRowIndex">Index of the p row.</param>
        public void SetCurrent(int pRowIndex)
        {
            this.Table.CurrentRecord = this.Table.DisplayElements[pRowIndex].GetRecord();

            //// Inspect via records of grid and check rowindex
            foreach (Syncfusion.Grouping.Record record in this.Table.Records)
            {
                if (record.GetRowIndex() == pRowIndex &&
                    !record.IsColumnHeader() && !record.IsFilterBar())
                {
                    // Set current record
                    this.Table.CurrentRecord = record;

                    return;
                }
            }
        }

        /// <summary>
        /// Sets the last row is current row.
        /// </summary>
        public void SetLastRowIsCurrentRow()
        {
            if (this.Table.Records.Count > 0)
            {
                this.Table.CurrentRecord = this.Table.Records[this.Table.Records.Count - 1];
            }
        }

        /// <summary>
        /// Ends the edit.
        /// </summary>
        public void EndEdit()
        {
            this.Table.EndEdit();
        }

        /// <summary>
        /// Optimizes this instance.
        /// </summary>
        public void Optimize()
        {
            // Get engine
            GridEngine schema = this.Engine;

            // Optimize engine
            schema.InvalidateAllWhenListChanged = false;
            schema.AllowedOptimizations = EngineOptimizations.All;
            schema.CounterLogic = EngineCounters.YAmount;//.FilteredRecords;
            schema.TableOptions.VerticalPixelScroll = false;  // also dependant on CounterLogic = EngineCounters.YAmount 
            //schema.TableOptions.ColumnsMaxLengthStrategy = GridColumnsMaxLengthStrategy.FirstNRecords;
            //schema.TableOptions.ColumnsMaxLengthFirstNRecords = 100;
        }

        #endregion ---- Public methods ----
    }
}
