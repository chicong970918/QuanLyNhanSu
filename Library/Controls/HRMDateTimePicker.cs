using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms.Tools;

namespace Library.Controls
{
    public partial class HRMDateTimePicker : DateTimePickerAdv
    {
        #region ---- Constants ----

        private const string DATE_FORMAT = "dd/MM/yyyy";

        #endregion ---- Constants ----

        #region ---- Member variables ----

        private bool _inited = false;

        #endregion ---- Member variables ----

        #region ---- Constructor ---

        /// <summary>
        /// Initializes a new instance of the <see cref="SECDateTimePicker"/> class.
        /// </summary>
        public HRMDateTimePicker()
        {
            this.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CustomFormat = DATE_FORMAT;
        }

        #endregion ---- Constructor ---

        #region ---- Propterties ----

        /// <summary>
        /// Gets or sets the selected date of the picker.
        /// </summary>
        /// <value></value>
        public new DateTime? Value
        {
            get
            {
                if (this.IsNullDate)
                {
                    return null;
                }
                else
                {
                    return base.Value;
                }
            }
            set
            {
                if (value == null)
                {
                    this.IsNullDate = true;
                    return;
                }

                base.Value = value.Value;
            }
        }

        #endregion ---- Propterties ----

        #region ---- Protected methods ----

        /// <summary>
        /// Raises the <see cref="E:Paint"/> event.
        /// </summary>
        /// <param name="e">The <see cref="System.Windows.Forms.PaintEventArgs"/> instance containing the event data.</param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (!_inited)
            {
                this.ShowCheckBox = false;
                this.ThemesEnabled = true;
                this.Style = Syncfusion.Windows.Forms.VisualStyle.Office2007;
                this.UseEnhancedMenu = false;
                
                this.NullString = "Chưa chọn";

                _inited = true;
            }

            base.OnPaint(e);
        }

        #endregion ---- Protected methods ----

    }
}
