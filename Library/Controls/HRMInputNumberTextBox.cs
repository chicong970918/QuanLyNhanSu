using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Library.Class;

namespace Library.Controls
{
    public partial class HRMInputNumberTextBox : HRMTextBox
    {
        #region ---- Protected methods ----

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Control.KeyPress"/> event.
        /// </summary>
        /// <param name="e">A <see cref="T:System.Windows.Forms.KeyPressEventArgs"/> that contains the event data.</param>
        protected override void OnKeyPress(System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = CommonUtil.IsNumber(e.KeyChar);
        }

        #endregion
    }
}
