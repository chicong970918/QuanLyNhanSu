using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using Syncfusion.Windows.Forms.Grid;
using Syncfusion.Windows.Forms.Grid.Grouping;
using System.Windows.Forms;

namespace Library
{
   public class HRMCell_MoveColumn
    {
        #region Static Variables

        private static Point _lastCellHeaderIndex;
        private static HRMGrigouping _gridGrouping;
        private static bool _clickButtonCell = false;
        private static Rectangle _cellRec;
        private static string _lastColumnName = string.Empty;
        #endregion

        #region Contructors


        #endregion

        public class CustomCellModel : GridHeaderCellModel
        {
            private CustomCellRender _customCellRender;

            #region Contructors

            public CustomCellModel(GridModel grid, HRMGrigouping gridGrouping)
                : base(grid)
            {

                _gridGrouping = gridGrouping;

                ButtonBarSize = new Size(15, 15);

                _gridGrouping.TableControlCellClick += new GridTableControlCellClickEventHandler(_gridGrouping_TableControlCellClick);
                _gridGrouping.TableControlCellMouseHoverEnter += new GridTableControlCellMouseEventHandler(_gridGrouping_TableControlCellMouseHoverEnter);
            }

            #endregion

            #region GridGrouping Events

            private void _gridGrouping_TableControlCellClick(object sender, GridTableControlCellClickEventArgs e)
            {
                if (e.TableControl.GetCellRenderer(e.Inner.RowIndex, e.Inner.ColIndex).GetType() == typeof(CustomCellRender))
                {
                    e.Inner.Cancel = _clickButtonCell;
                }
            }

            private void _gridGrouping_TableControlCellMouseHoverEnter(object sender, GridTableControlCellMouseEventArgs e)
            {
                if (!_gridGrouping.EnableCustomCell)
                {
                    return;
                }
                GridTableCellStyleInfo style = _gridGrouping.Table.GetTableCellStyle(e.Inner.RowIndex, e.Inner.ColIndex);

                if (_lastColumnName != string.Empty)
                {
                    _gridGrouping.TableDescriptor.Columns[_lastColumnName].Appearance.ColumnHeaderCell.CellType = "ColumnHeaderCell";
                }

                if (style.TableCellIdentity.TableCellType == GridTableCellType.ColumnHeaderCell)
                {
                    GridVisibleColumnDescriptor visCol = _gridGrouping.TableDescriptor.VisibleColumns[e.Inner.ColIndex - 1];
                    GridColumnDescriptor col = _gridGrouping.TableDescriptor.Columns[visCol.Name];
                    col.Appearance.ColumnHeaderCell.Enabled = true;
                    col.Appearance.ColumnHeaderCell.CellType = _gridGrouping._cellStyleName;

                    _lastColumnName = visCol.Name;
                }
            }

            #endregion

            #region Override Methods

            public override GridCellRendererBase CreateRenderer(GridControlBase control)
            {
                _customCellRender = new CustomCellRender(control, this) { GridGrouping = _gridGrouping };

                return _customCellRender;
            }

            #endregion

            #region Properties



            #endregion
        }

        public class CustomCellRender : GridHeaderCellRenderer
        {
            #region Variables
            private CustomDropDownContainer _dropDownContainer;
            private ListBox box;
            private HRMGrigouping _gridGrouping;
            #endregion

            #region Contructors

            public CustomCellRender(GridControlBase grid, CustomCellModel cellModel)
                : base(grid, cellModel)
            {
                _dropDownContainer = new CustomDropDownContainer();

                DropDownImp = new CustomDropDownCellImp(this);
            }

            #endregion

            #region Private Methods

            private void SetItemBox()
            {
                box.SelectedIndex = -1;

                box.Items.Clear();

                ComboBoxItem[] cbxItem = new ComboBoxItem[this.GridGrouping.TableDescriptor.VisibleColumns.Count];

                int iCount = 0;

                foreach (GridVisibleColumnDescriptor colVis in this.GridGrouping.TableDescriptor.VisibleColumns)
                {
                    GridColumnDescriptor colDes = this.GridGrouping.TableDescriptor.Columns[colVis.Name];
                    if (colDes != null)
                    {
                        cbxItem[iCount] = new ComboBoxItem(colDes.HeaderText, colVis);
                        iCount++;
                    }
                }

                box.Items.AddRange(cbxItem);
                box.DisplayMember = "Display";
                box.ValueMember = "Value";
            }

            #endregion

            #region Events

            private void box_SelectedIndexChanged(object sender, EventArgs e)
            {
                ComboBoxItem cbxi = box.SelectedItem as ComboBoxItem;
                int src = _lastCellHeaderIndex.Y - 1;
                int des = box.SelectedIndex;

                this.GridGrouping.TableDescriptor.VisibleColumns.Move(src, des);
                if (src < des)
                {
                    this.GridGrouping.TableDescriptor.VisibleColumns.Move(des - 1, src);
                }
                else if (src > des)
                {
                    this.GridGrouping.TableDescriptor.VisibleColumns.Move(des + 1, src);
                }
                else
                {
                    return;
                }

                _dropDownContainer.HidePopup();
            }

            private void dropDownContainer_MouseLeave(object sender, EventArgs e)
            {
                _dropDownContainer.HidePopup(Syncfusion.Windows.Forms.PopupCloseType.Done);
            }

            #endregion

            #region Override Methods

            protected override void OnShowDropDown()
            {
                box.SelectedIndexChanged -= new EventHandler(box_SelectedIndexChanged);


                SetItemBox();

                _dropDownContainer.Height = box.ItemHeight * (box.Items.Count > 10 ? 10 : box.Items.Count) + 26;

                box.Location = new Point(1, 1);

                box.Height = _dropDownContainer.Height - 2;
                box.Width = _dropDownContainer.Width - 2;

                box.SelectedIndex = _lastCellHeaderIndex.Y - 1;

                Point mousePosition = _gridGrouping.PointToScreen(_cellRec.Location);

                mousePosition.X = mousePosition.X + box.Width / 2;
                mousePosition.Y = mousePosition.Y + _cellRec.Height + box.ItemHeight / 2;

                Cursor.Position = mousePosition;

                base.OnShowDropDown();

                box.SelectedIndexChanged += new EventHandler(box_SelectedIndexChanged);
            }


            protected override IGridDropDownContainer CreateDropDownContainer()
            {
                return _dropDownContainer;
            }

            public override void Draw(Graphics g, Rectangle cellRectangle, int rowIndex, int colIndex, GridStyleInfo style)
            {
                _cellRec = cellRectangle;

                base.Draw(g, cellRectangle, rowIndex, colIndex, style);
            }
            #endregion

            #region Properties

            public HRMGrigouping GridGrouping
            {
                get { return _gridGrouping; }
                set
                {
                    _gridGrouping = value;

                    box = new ListBox();

                    _dropDownContainer.Controls.Add(box);

                    _dropDownContainer.MouseEnter += new EventHandler(dropDownContainer_MouseLeave);
                }
            }

            #endregion
        }

        public class CustomDropDownContainer : GridDropDownContainer
        {
            #region Variables

            #endregion

            #region Contructors

            public CustomDropDownContainer()
            {
            }

            #endregion

            #region Override Methods

            protected override void OnPaintBackground(PaintEventArgs e)
            {

            }
            #endregion
        }

        public class CustomDropDownCellImp : GridDropDownCellImp
        {
            #region Variables

            private CustomCellButton _gridComboBoxButton;
            private Point _lastCellIndex;

            #endregion

            #region Contructors

            public CustomDropDownCellImp(CustomCellRender cellRender)
                : base(cellRender)
            {
                _gridComboBoxButton = new CustomCellButton(cellRender);
                _lastCellIndex = new Point();

                DropDownButton = _gridComboBoxButton;
            }

            #endregion

            #region Override Methods

            public override void OnButtonClicked(int rowIndex, int colIndex, int button)
            {
                if (_lastCellIndex.X != rowIndex || _lastCellIndex.Y != colIndex)
                {
                    GridCellRendererBase cellRender = Grid.GetCellRenderer(_lastCellIndex.X, _lastCellIndex.Y);

                    HidePoup(cellRender);

                    _lastCellIndex.X = rowIndex;
                    _lastCellIndex.Y = colIndex;
                }

                ShowPoup(_lastCellIndex.X, _lastCellIndex.Y, button);
            }

            #endregion

            #region Private Methods

            private void HidePoup(GridCellRendererBase cell, Syncfusion.Windows.Forms.PopupCloseType pPoupCloseType = Syncfusion.Windows.Forms.PopupCloseType.Done)
            {
                if (cell != null && cell.DropDownContainer != null)
                {
                    cell.DropDownContainer.HidePopup(pPoupCloseType);
                }
            }

            private void ShowPoup(int pRowIndex, int pColIndex, int pButton)
            {
                GridCellRendererBase cell = Grid.GetCellRenderer(pRowIndex, pColIndex);
                if (cell != null && cell.DropDownContainer != null)
                {
                    if (!cell.DropDownContainer.IsShowing())
                    {
                        CustomDropDownContainer dropDownContainer = (cell.DropDownContainer as CustomDropDownContainer);
                        Rectangle recCellBounds = cell.GetCellBoundsCore(pRowIndex, pColIndex);

                        dropDownContainer.Width = recCellBounds.Width;

                        base.OnButtonClicked(pRowIndex, pColIndex, pButton);
                    }
                }
            }

            #endregion
        }

        public class CustomCellButton : GridCellComboBoxButton
        {
            #region Variables

            private int countHit = 0;

            #endregion

            #region Contructors

            public CustomCellButton(CustomCellRender control)
                : base(control)
            {
                this.FireClickOnMouseUp = false;
            }

            #endregion

            #region Override Methods

            public override int HitTest(int rowIndex, int colIndex, MouseEventArgs e, Syncfusion.Windows.Forms.IMouseController controller)
            {
                if ((e.X >= Bounds.X && e.X <= Bounds.X + Bounds.Width) && (e.Y >= Bounds.Top && e.Y <= Bounds.Y + Bounds.Height))
                {
                    _clickButtonCell = true;
                    if (e.Clicks == 2)
                    {

                        countHit++;
                        if (countHit == 2)
                        {
                            _lastCellHeaderIndex = new Point(rowIndex, colIndex);

                            this.OnClicked(new GridCellEventArgs(rowIndex, colIndex));
                            countHit = 0;
                        }
                    }
                }
                else
                {
                    _clickButtonCell = false;
                }

                return base.HitTest(rowIndex, colIndex, e, controller);
            }

            public override void DrawButton(Graphics g, Rectangle rect, ButtonState buttonState, GridStyleInfo style)
            {
                rect.Height = _cellRec.Height;
                rect.Y = _cellRec.Y;

                Owner.Model.ButtonBarSize = new Size(rect.Width, rect.Height);

                ControlPaint.DrawComboButton(g, rect, buttonState);
                //base.DrawButton(g, rect, buttonState, style);
            }

            #endregion
        }

        public sealed class ComboBoxItem
        {
            #region Variables

            private string _display;
            private GridVisibleColumnDescriptor _value;

            #endregion

            #region Contructors

            public ComboBoxItem(string pDisplay, GridVisibleColumnDescriptor pColumn)
            {
                _display = pDisplay;
                _value = pColumn;
            }

            #endregion

            #region Properties

            public string Display
            {
                get { return _display; }
                set { _display = value; }
            }

            public GridVisibleColumnDescriptor Value
            {
                get { return _value; }
                set { _value = value; }
            }

            #endregion
        }
    }
}
