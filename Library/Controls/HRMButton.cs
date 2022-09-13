using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Syncfusion.Windows.Forms;

namespace Library.Controls
{
    /// <summary>
    /// 
    /// </summary>
    public partial class HRMButton : ButtonAdv
    {
        #region ---- Contructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="HRMButton"/> class.
        /// </summary>
        public HRMButton()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HRMButton"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public HRMButton(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
        

        #endregion


        #region ---- Protected methods ----

        /// <summary>
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            if (!this.UseVisualStyle)
            {
                this.UseVisualStyle = true;
                this.Appearance = Syncfusion.Windows.Forms.ButtonAppearance.Office2007;
                this.Office2007ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Managed;
            }
            base.OnPaint(e);
        }

        #endregion ---- Protected methods ----
    }
}
