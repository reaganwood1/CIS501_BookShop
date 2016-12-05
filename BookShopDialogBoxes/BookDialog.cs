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
    public partial class BookDialog : Form
    {
        public BookDialog()
        {
            InitializeComponent();
        }

        protected string Title
        {
            get
            {
                return this.Text;
            }

            set 
            {
                this.Text = value;
            }
        }
        public string BookTitle
        {
            get
            {
                return tbTitle.Text.Trim();
            }
            set
            {
                tbTitle.Text = value;
            }
        }

        public string Author
        {
            get
            {
                return tbAuthor.Text.Trim();
            }
            set
            {
                tbAuthor.Text = value;
            }
        }

        public string Publisher
        {
            get
            {
                return tbPublisher.Text.Trim();
            }
            set
            {
                tbPublisher.Text = value;
            }
        }

        public string ISBN
        {
            get
            {
                return tbISBN.Text.Trim();
            }
            set
            {
                tbISBN.Text = value;
            }
        }

        public string Date
        {
            get
            {
                return tbDate.Text.Trim();
            }
            set
            {
                tbDate.Text = value;
            }
        }
        public decimal Price
        {
            get
            {
                try
                {
                    return decimal.Parse(tbPrice.Text.Trim());
                }
                catch(Exception)
                {
                    throw new BookShopException("Input Decimal for Price");
                } 
            }
            set
            {
                tbPrice.Text = value.ToString() ;
            }
        }

        public int Stock
        {
            get
            {
                try
                {
                    return int.Parse(tbStock.Text.Trim());
                }
                catch (Exception)
                {
                    throw new BookShopException("Input int for Stock");
                }
            }
            set
            {
                tbStock.Text = value.ToString();
            }
        }

        public void ClearDisplayItems()
        {
            BookTitle = Author = Publisher = ISBN = Date = "";
            Stock = 0; Price = 0.0m;
        }

        public virtual DialogReturn Display()
        {
            switch(this.ShowDialog())
            {
                case DialogResult.Cancel: return DialogReturn.Cancel;
                case DialogResult.OK: return DialogReturn.Done;
                default: return DialogReturn.Undefined;
            }
        }

    }
}
