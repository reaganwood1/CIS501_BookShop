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
    public partial class ShowTransactionDialog : SelectDialog
    {
        public ShowTransactionDialog()
        {
            InitializeComponent();
        }

        private void ShowTransactionDialog_Load(object sender, EventArgs e)
        {
            bnSelect.Enabled = false;
            Title = "Transaction (Read Only)";
        }
    }
}
