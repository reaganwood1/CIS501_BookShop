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
    public partial class CustomerDialog : Form
    {
        public CustomerDialog()
        {
            InitializeComponent();
        }

        public string FirstName
        {
            get
            {
                return tbFirstName.Text.Trim();
            }
            set
            {
                tbFirstName.Text = value;
            }
        }

        public string LastName
        {
            get
            {
                return tbLastName.Text.Trim();
            }
            set
            {
                tbLastName.Text = value;
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

        public string EMailAddress
        {
            get
            {
                return tbEmailAddress.Text.Trim();
            }
            set
            {
                tbEmailAddress.Text = value;
            }
        }

        public string Address
        {
            get
            {
                return tbAddress.Text.Trim();
            }
            set
            {
                tbAddress.Text = value;
            }
        }

        public string TelephoneNumber
        {
            get
            {
                return tbTelephoneNumber.Text.Trim();
            }
            set
            {
                tbTelephoneNumber.Text = value;
            }
        }

        public void ClearDisplayItems()
        {
            FirstName = LastName = UserName = Password = EMailAddress = Address =
                TelephoneNumber = "";
        }

        public virtual DialogReturn Display()
        {
            switch (this.ShowDialog())
            {
                case DialogResult.Cancel: return DialogReturn.Cancel;
                case DialogResult.OK: return DialogReturn.Done;
                default: return DialogReturn.Undefined;
            }
        }

   
    }
}
