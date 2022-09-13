using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class HRMDoubleTextBox : Syncfusion.Windows.Forms.Tools.DoubleTextBox
    {
        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="HRMDoubleTextBox"/> class.
        /// </summary>
        /// <remarks>
        /// The DoubleTextBox object will be initialized with the default values
        /// for the display and data properties. You need to set any specific
        /// values.
        /// </remarks>
        public HRMDoubleTextBox()
        {
            InitializeComponent();
            this.MaxValue = double.MaxValue;
            this.MinValue = 0.0D;
            this.NullString = string.Empty;
           // this.UseNullString = true;
          //  this.IsNullValue = true;
            this.Text = string.Empty;
            this.TextAlign = HorizontalAlignment.Right;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HRMDoubleTextBox"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public HRMDoubleTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        } 

        #endregion
    }
}
