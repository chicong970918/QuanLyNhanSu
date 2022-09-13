using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library.Forms
{
    public partial class LoadingForm : Form
    {
        #region ---- Constructors ----

        /// <summary>
        /// Initializes a new instance of the <see cref="LoadingForm"/> class.
        /// </summary>
        /// <param name="pContent">Content of the p.</param>
        public LoadingForm(string pContent = null)
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(pContent))
            {
                lblProcessText.Text = pContent;
            }
        }

        #endregion ---- Constructors ----
    }
}
