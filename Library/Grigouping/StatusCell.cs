using System.Drawing;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Grid;

namespace Library
{
    /// <summary>
    /// 
    /// </summary>
    public class StatusCellModel : GridGenericControlCellModel
    {
        #region ---- Constructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCellModel"/> class.
        /// </summary>
        /// <param name="grid">The grid.</param>
        public StatusCellModel(GridModel grid)
            : base(grid)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCellModel"/> class.
        /// </summary>
        /// <param name="info">An object that holds all the data needed to serialize or deserialize this instance.</param>
        /// <param name="context">Describes the source and destination of the serialized stream specified by info.</param>
        protected StatusCellModel(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion ---- Constructors ----

        #region ---- Protected methods ----

        /// <summary>
        /// Creates a renderer for this cell model.
        /// </summary>
        /// <param name="control">The grid control.</param>
        /// <returns>Cell renderer.</returns>
        /// <override/>
        public override GridCellRendererBase CreateRenderer(GridControlBase control)
        {
            return new StatusCellRenderer(control, this);
        }

        /// <summary>
        /// Calculates the preferred size of the cell based on its contents without margins and any buttons.
        /// </summary>
        /// <param name="g">The <see cref="T:System.Drawing.Graphics"/> context of the canvas.</param>
        /// <param name="rowIndex">The row index.</param>
        /// <param name="colIndex">The column index.</param>
        /// <param name="style">The <see cref="T:Syncfusion.Windows.Forms.Grid.GridStyleInfo"/> object that holds cell information.</param>
        /// <param name="queryBounds">grsphical bounds</param>
        /// <returns>The optimal size of the cell.</returns>
        /// <override/>
        protected override Size OnQueryPrefferedClientSize(Graphics g, int rowIndex, int colIndex, GridStyleInfo style, GridQueryBounds queryBounds)
        {
            return base.OnQueryPrefferedClientSize(g, rowIndex, colIndex, style, queryBounds);
        }

        #endregion ---- Protected methods ----
    }

    /// <summary>
    /// 
    /// </summary>
    public class StatusCellRenderer : GridGenericControlCellRenderer
    {
        #region ---- Member variables ----

        private PictureBox _drawPictureBox = new PictureBox();
        private StatusCellModel _cellMode;

        #endregion ---- Member variables ----

        #region ---- Constructors & Destructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="StatusCellRenderer"/> class.
        /// </summary>
        /// <param name="grid">The <see cref="T:Syncfusion.Windows.Forms.Grid.GridControlBase"/> that display this cell renderer.</param>
        /// <param name="cellModel">The <see cref="T:Syncfusion.Windows.Forms.Grid.GridCellModelBase"/> that holds data for this cell renderer that should
        /// be shared among views.</param>
        /// <remarks>References to GridControlBase
        /// and GridCellModelBase will be saved.</remarks>
        public StatusCellRenderer(GridControlBase grid, GridCellModelBase cellModel)
            : base(grid, cellModel)
        {
            this._cellMode = (StatusCellModel)cellModel;
            SupportsFocusControl = false;
            FixControlParent(this._drawPictureBox);
        }

        /// <summary>
        /// Unwires any events subscribed from GridControlBase and releases cell buttons.
        /// </summary>
        /// <param name="disposing"><see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.</param>
        /// <remarks>See the documentation for the <see cref="T:System.ComponentModel.Component"/> class and its Dispose member.</remarks>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _drawPictureBox.Dispose();
                _drawPictureBox = null;
                _cellMode = null;
            }

            base.Dispose(disposing);
        }

        #endregion ---- Constructors & Destructors ----

        #region ---- Protected methods ----

        /// <summary>
        /// </summary>
        /// <param name="g"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="rowIndex"></param>
        /// <param name="colIndex"></param>
        /// <param name="style"></param>
        /// <override/>
        protected override void OnDraw(Graphics g, Rectangle clientRectangle, int rowIndex, int colIndex, GridStyleInfo style)
        {
            _drawPictureBox.SizeMode = PictureBoxSizeMode.Normal;
            _drawPictureBox.BackColor = style.BackColor;
            _drawPictureBox.Image = null;

            //if (style.CellValue != null)
            //{
            //    Bitmap bmp = new Bitmap((Image)Properties.Resources.status_unchanged, ControlsSettings.StatusCellImageSize); ;

            //    if (style.CellValue.ToString() == "Added")
            //    {
            //        bmp = new Bitmap((Image)Properties.Resources.status_added, ControlsSettings.StatusCellImageSize);
            //    }
            //    else if (style.CellValue.ToString() == "Modified")
            //    {
            //        bmp = new Bitmap((Image)Properties.Resources.status_modified, ControlsSettings.StatusCellImageSize);
            //    }
            //    else if (style.CellValue.ToString() == "Deleted")
            //    {
            //        bmp = new Bitmap((Image)Properties.Resources.status_deleted, ControlsSettings.StatusCellImageSize);
            //    }

            //    _drawPictureBox.Image = bmp;
            //}

            style.Control = _drawPictureBox;
            base.OnDraw(g, clientRectangle, rowIndex, colIndex, style);
        }

        #endregion ---- Protected methods ----
    }
}
