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
    public partial class ShowPendingTransactionDialog : SelectDialog
    {
        public ShowPendingTransactionDialog()
        {
            InitializeComponent();
        }

        private void ShowPendingTransaction_Load(object sender, EventArgs e)
        {
        }

        public override DialogReturn Display()
        {
            switch (this.ShowDialog())
            {
                case DialogResult.OK: return DialogReturn.Done;
                case DialogResult.Yes: return DialogReturn.Approve;
                case DialogResult.No: return DialogReturn.ReturnBook;
                case DialogResult.Abort: return DialogReturn.Remove;
                default: return DialogReturn.Undefined;
            }
        }
    }
}
