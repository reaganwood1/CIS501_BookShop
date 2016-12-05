using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace edu.ksu.cis.masaaki
{
    public partial class BookInformationDialog : BookDialog
    {
        public BookInformationDialog()
        {
            InitializeComponent();
        }

        private void SetFieldsReadOnly()
        {
            tbAuthor.ReadOnly = tbDate.ReadOnly = tbISBN.ReadOnly =tbStock.ReadOnly =
                tbPrice.ReadOnly = tbPublisher.ReadOnly = tbTitle.ReadOnly = true;
        }
        private void BookInformationDialog_Load(object sender, EventArgs e)
        {
            bnCancel.Enabled = false;
            SetFieldsReadOnly();
        }

        public override DialogReturn Display()
        {
            switch(this.ShowDialog())
            {
                case DialogResult.OK: return DialogReturn.Done;
                case DialogResult.Yes: return DialogReturn.AddToCart;
                case DialogResult.No: return DialogReturn.AddToWishList;
                default: return DialogReturn.Undefined;
            }
        }
    }
}
