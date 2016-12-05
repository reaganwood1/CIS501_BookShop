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
    public partial class LoginDialog : Form
    {
        public LoginDialog()
        {
            InitializeComponent();
        }

        public string Password
        {
            get
            {
                return tbPassword.Text.Trim();
            }

            set
            {
                tbPassword.Text = value;
            }
        }

        public string UserName
        {
            get
            {
                return tbUserName.Text.Trim();
            }

            set
            {
                tbUserName.Text = value;
            }
        }

        public virtual DialogReturn Display()
        {
            switch (this.ShowDialog())
            {
                case DialogResult.Cancel: return DialogReturn.Cancel;
                case DialogResult.OK: return DialogReturn.Login;
                default: return DialogReturn.Undefined;
            }
        }

    }
}
