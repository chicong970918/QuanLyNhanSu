using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class HRMCombobox :Syncfusion.Windows.Forms.Tools.ComboBoxAdv
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HRMCombobox"/> class.
        /// </summary>
        public HRMCombobox()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            base.OnPaint(e);

            int borderWidth = 1;

            Color borderColor = Color.Blue;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,

                      borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,

                      ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,

                      borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

    }
}
