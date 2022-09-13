using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.Controls
{
    public partial class HRMIntergerTextBox : Syncfusion.Windows.Forms.Tools.IntegerTextBox
    {
        public HRMIntergerTextBox()
        {
            InitializeComponent();
            this.MaxValue = 2147483647;
            this.MinValue = 0;
            this.NullString = string.Empty;
            this.UseNullString = true;
            this.IsNullValue = true;
            this.Text = "";
            this.TextAlign = HorizontalAlignment.Right;
        }

        public HRMIntergerTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
