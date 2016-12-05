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
    public partial class ShowCompleteTransactionDialog : SelectDialog
    {
        public ShowCompleteTransactionDialog()
        {
            InitializeComponent();
        }

        private void ShowCompleteTransactionDialog_Load(object sender, EventArgs e)
        {
        }

        public override DialogReturn Display()
        {
            switch (this.ShowDialog())
            {
                case DialogResult.OK: return DialogReturn.Done;
                case DialogResult.Yes: return DialogReturn.Remove;
                default: return DialogReturn.Undefined;
            }
        }
    }
}
