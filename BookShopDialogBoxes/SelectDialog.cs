//////////////////////////////////////////////////////////////////
//  Domestic Telephone System (DTS)                             //
//    Written by Masaaki Mizuno, (c) 2007, 2008                 //
//      for K-State Course cis501                               //
//      also for Learning Tree Course, 123P, 230Y               //
//////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace edu.ksu.cis.masaaki
{
    public partial class SelectDialog : Form
    {
        public SelectDialog()
        {
            InitializeComponent();
        }
        private void SelectDialog_Load(object sender, EventArgs e)
        {
            SelectedIndex = -1;
        }
        protected string Title
        {
            set
            {
                this.Text = value;
            }
        }
        public void AddDisplayItems(params object[] objects)
        {
            lbList.Items.AddRange(objects);
        }

        public void ClearDisplayItems()
        {
            lbList.Items.Clear();
            lbList.SelectedIndex = -1;
        }
        
        public int SelectedIndex
        {
            get
            {
                if (lbList.SelectedIndex == -1) throw new BookShopException("Select a line");
                return lbList.SelectedIndex;
            }
            set { lbList.SelectedIndex = value; }
        }

        public object SelectedItem
        {
            get
            {
                if (lbList.SelectedItem == null) throw new BookShopException("Select a line");
                return lbList.SelectedItem;
            }
        }

        public virtual DialogReturn Display()
        {
            switch (this.ShowDialog())
            {
                case DialogResult.OK: return DialogReturn.Done;
                case DialogResult.Yes: return DialogReturn.Select;
                default: return DialogReturn.Undefined;
            }
        }
    }
}