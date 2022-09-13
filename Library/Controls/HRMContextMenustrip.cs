using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Library.Controls
{
    public partial class HRMContextMenustrip : System.Windows.Forms.ContextMenuStrip
    {
        public HRMContextMenustrip()
        {
            InitializeComponent();
        }

        public HRMContextMenustrip(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
