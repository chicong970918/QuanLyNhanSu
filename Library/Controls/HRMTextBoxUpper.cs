using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Library.Controls
{
    public partial class HRMTextBoxUpper : HRMTextBox
    {
        public HRMTextBoxUpper()
            : base()
        {
            this.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.MaxLength = 20;
        }
    }
}
