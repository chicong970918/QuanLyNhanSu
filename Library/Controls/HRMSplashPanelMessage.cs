using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms.Tools;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Library.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HRMSplashPanelMessage : SplashPanel
    {
        #region ---- Member varibles ----

        private StringFormat _stringFormat = new StringFormat();

        #endregion ---- Member varibles ----

        #region ---- Constructor ----

        /// <summary>
        /// Initializes a new instance of the <see cref="SECSplashPanelMessage"/> class.
        /// </summary>
        /// <remarks>
        /// The default value for the <see cref="P:Syncfusion.Windows.Forms.Tools.SplashPanel.TimerInterval"/> is set to
        /// 5000 milli seconds.
        /// The splash panel has animation turned and by default will appear in the
        /// middle of the screen.
        /// </remarks>
        public HRMSplashPanelMessage()
        {
            _stringFormat.Alignment = StringAlignment.Center;
            _stringFormat.LineAlignment = StringAlignment.Center;

            this.CloseOnClick = true;
            this.CloseOnLostFocus = true;
            this.ShowAnimation = false;
            this.BorderType = Syncfusion.Windows.Forms.Tools.SplashBorderType.None;
            
            this.BackgroundColor = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192))))));
         
        }

        #endregion ---- Constructor ----

        #region ---- Properties ----

        /// <summary>
        /// Gets or sets the alignment.
        /// </summary>
        /// <value>The alignment.</value>
        public StringAlignment Alignment
        {
            get { return _stringFormat.Alignment; }
            set { _stringFormat.Alignment = value; }
        }

        /// <summary>
        /// Gets or sets the line alignment.
        /// </summary>
        /// <value>The line alignment.</value>
        public StringAlignment LineAlignment
        {
            get { return _stringFormat.LineAlignment; }
            set { _stringFormat.LineAlignment = value; }
        }

        #endregion ---- Properties ----

        #region ---- Protected methods ----

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.Paint"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.PaintEventArgs"/> that contains the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;            

            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), this.ClientRectangle, _stringFormat);
          
        }

        #endregion ---- Protected methods ----
    }
}
