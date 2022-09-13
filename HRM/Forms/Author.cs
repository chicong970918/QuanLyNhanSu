using System ;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HRM.BaseForms;
using HRM.DataAccess.Catalogs;
using HRM.Entities;
using HRM.DataAccess.NguoiDung;
using Library.Class;

namespace HRM.Forms
{
    public partial class Author : BaseForm
    {
        public Author()
        {
            InitializeComponent();
            this.Load += new EventHandler(Author_Load);
        }

        void Author_Load(object sender, EventArgs e)
        {
            btnOk.Focus();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
