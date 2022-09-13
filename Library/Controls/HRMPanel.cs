using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Library.Controls
{
    public class HRMPanel : System.Windows.Forms.Panel
    {
        public HRMPanel()
        {
            InitializeComponent();            
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // CustomPanel
            // 
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CustomPanel_Paint);
            this.ResumeLayout(false);

        }

        private void CustomPanel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            this.BackColor = Color.Transparent;
        }
    }
}
