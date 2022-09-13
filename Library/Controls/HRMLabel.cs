using System.Drawing;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class HRMLabel : Label
    {
        #region ---- Member variables ----

        /// <summary>
        /// 
        /// </summary>
        private bool _isRequired = false;

        #endregion ---- Member variables ----

        #region ---- Constructors & Destructors ----


        /// <summary>
        /// Initializes a new instance of the <see cref="HRMLabel"/> class.
        /// </summary>
        public HRMLabel()
        {
            this.BackColor = Color.Transparent;
            this.TextAlign = ContentAlignment.MiddleLeft;
            this.AutoSize = false;
        }

        #endregion ---- Constructors & Destructors ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets a value indicating whether this instance is required.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is required; otherwise, <c>false</c>.
        /// </value>
        public bool IsRequired
        {
            get { return _isRequired; }
            set { _isRequired = value; }
        }

        #endregion ---- Properties ----

        #region ---- Protected methods ----

        /// <summary>
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            
            if (_isRequired)
            {
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                // Create new string format
                StringFormat format = new StringFormat();
                format.Alignment = StringAlignment.Far;
                format.LineAlignment = StringAlignment.Center;

                // Font
                Font font = new System.Drawing.Font(this.Font.FontFamily, this.Font.Size, FontStyle.Bold);

                float width = e.Graphics.MeasureString(this.Text, this.Font).Width + 12;

                // Draw string
                e.Graphics.DrawString(/*"●"*/"*", font, new SolidBrush(Color.Red), new RectangleF(0, 0, width, this.Height), format);
            }
        }

        #endregion ---- Protected methods ----        
    }
}
