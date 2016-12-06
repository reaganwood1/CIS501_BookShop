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
    public partial class StaffWindow : Form
    {
        // XXX add more fields if necessary
        BookShopController bookShop;
        ListCustomersDialog listCustomersDialog;
        CustomerDialog customerDialog;
        ListBooksDialog listBooksDialog;
        BookDialog bookDialog;
        ListCompleteTransactionsDialog listCompleteTransactionsDialog;
        ShowCompleteTransactionDialog showCompleteTransactionDialog;
        ListPendingTransactionsDialog listPendingTransactionsDialog;
        ShowPendingTransactionDialog showPendingTransactionDialog;

        public StaffWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// overloaded constructor for StaffWindow
        /// </summary>
        /// <param name="bookShop"></param>
        public StaffWindow(BookShopController bookShop) : this() {
            this.bookShop = bookShop;
        }

        // XXX You may add overriding constructors (constructors with different set of arguments).
        // If you do so, make sure to call :this()
        // public StaffWindow(XXX xxx): this() { }
        // Without :this(), InitializeComponent() is not called
        private void StaffWindow_Load(object sender, EventArgs e)
        {
            listCustomersDialog = new ListCustomersDialog();
            customerDialog = new CustomerDialog();
            listBooksDialog = new ListBooksDialog();
            bookDialog = new BookDialog();
            listCompleteTransactionsDialog = new ListCompleteTransactionsDialog();
            showCompleteTransactionDialog = new ShowCompleteTransactionDialog();
            listPendingTransactionsDialog = new ListPendingTransactionsDialog();
            showPendingTransactionDialog = new ShowPendingTransactionDialog();
        }

        private void bnListCustomers_Click(object sender, EventArgs e)
        {
            // XXX List Customers button event handler
            
            while (true)
            {
               
                try
                { // to capture an exception from SelectedIndex/SelectedItem of listCustomersDialog
                    listCustomersDialog.ClearDisplayItems();
                    listCustomersDialog.AddDisplayItems(null); // null is a dummy argument
                    if (listCustomersDialog.Display() == DialogReturn.Done) return;
                    // select button is pressed
                   

                    if (customerDialog.Display() == DialogReturn.Cancel) continue;
                    // XXX Edit Done button is pressed
                    
                }
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnAddBook_Click(object sender, EventArgs e)
        {
            // XXX Add Book button event handler
            while (true)
            {
                try
                { // to capture an exception from Price/Stock of bookDialog
                    // also throw an exception if the ISBN is already registered
                    bookDialog.ClearDisplayItems();
                    if (bookDialog.ShowDialog() == DialogResult.Cancel) return;
                    // Edit Done button is pressed
                    if (!bookShop.AddBook(bookDialog.BookTitle, bookDialog.Author, bookDialog.Publisher, bookDialog.ISBN, bookDialog.Date, bookDialog.Price, bookDialog.Stock)) // book ISBN already exists
                        MessageBox.Show("Book with ISBN number " + bookDialog.ISBN + " has already been added.");
                    return;
                }
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnListBooks_Click(object sender, EventArgs e)
        {
            // XXX List Books button event handler
           
            while (true)
            {
            
                try
                {   // to capture an exception from SelectedItem/SelectedIndex of listBooksDialog
                    listBooksDialog.ClearDisplayItems();
                    listBooksDialog.AddDisplayItems(bookShop.GetAllBooks().ToArray()); //null is a dummy argument
                    if (listBooksDialog.Display() == DialogReturn.Done) return;
                    // select is pressed
                    if (listBooksDialog.SelectedItem is Book) // checks to see that the item selected is a Book, if it's not, then the user didn't select anything in this case
                    {
                        while (true)
                        {

                            try
                            { // to capture an exception from Price/Stock of bookDialog
                                if (bookDialog.Display() == DialogReturn.Cancel) break;

                                bookShop.EditBookInformation(bookDialog.BookTitle, bookDialog.Author, bookDialog.Publisher, bookDialog.Price, bookDialog.Stock, bookDialog.ISBN, bookDialog.Date, (Book)listBooksDialog.SelectedItem);

                                break;
                            }
                            catch (BookShopException bsex)
                            {
                                MessageBox.Show(this, bsex.ErrorMessage);
                                continue;
                            }
                        }
                    }
                    else // no line was selected
                        MessageBox.Show("Select a Line");
                }
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }
        private void bnPendingTransactions_Click(object sender, EventArgs e)
        {
            // XXX List Pending Transactions button event handl

            while (true)
            {
               
                try
                {  // to capture an exception from SelectedIndex/SelectedItem of listPendingTransactionsDialog
                    listPendingTransactionsDialog.ClearDisplayItems();
                    List<Transaction> trans;
                    if (bookShop.GetAllPendingTransactions(out trans))
                    {
                        listPendingTransactionsDialog.AddDisplayItems(trans.ToArray());  // null is a dummy argument
                        if (listPendingTransactionsDialog.Display() == DialogReturn.Done) return;
                        // select button is pressed
                        Transaction transFound = null;
                        foreach (Transaction c in trans)
                        {
                            if ((listPendingTransactionsDialog.SelectedItem.ToString().Equals(c.ToString())))
                            {
                                transFound = c;
                                break;
                            }
                        }
                        if (transFound != null)
                        {
                            while (true)
                            {
                                try
                                {  // to capture an exception from SelectedItem/SelectedTransaction of showPendingTransactionDialog
                                    showPendingTransactionDialog.ClearDisplayItems();
                                    showPendingTransactionDialog.AddDisplayItems(transFound); // null is a dummy argument
                                    switch (showPendingTransactionDialog.Display())
                                    {
                                        case DialogReturn.Approve:  // Transaction Processed
                                            bookShop.ProcessPendingTransaction(transFound);
                                            break;
                                        case DialogReturn.ReturnBook: // Return Book
                                            // this dialog box wasn't built correctly, nothing I can do about. You can return a book that's a Transaction
                                            continue;
                                        case DialogReturn.Remove: // Remove transaction
                                            Transaction transToDelete = (Transaction)showPendingTransactionDialog.SelectedItem;
                                            bookShop.RemoveTransactionFromPendingTransactions(transToDelete);
                                            break;
                                    }
                                    break; //for "transaction processed"
                                }
                                catch (BookShopException bsex)
                                {
                                    MessageBox.Show(this, bsex.ErrorMessage);
                                    continue;
                                }
                            }
                        }
                    }
                    else {
                        MessageBox.Show("No Pending Transactions");
                        return;
                    }
                } 
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnCompleteTransactions_Click(object sender, EventArgs e)
        {
            // XXX List Complete Transactions button event handler
            
            while (true)
            {           
                try
                { // to capture an exception from SelectedItem/SelectedIndex of listCompleteTransactionsDialog
                    listCompleteTransactionsDialog.ClearDisplayItems();
                    List<Transaction> trans;
                    if (bookShop.GetAllCompleteTransactions(out trans)) { // transactions are present
                        listCompleteTransactionsDialog.AddDisplayItems(trans.ToArray()); // display all of the complete transactions
                        if (listCompleteTransactionsDialog.Display() == DialogReturn.Done) return;
                        // select button is pressed
                        Transaction transFound = null;
                        foreach (Transaction c in trans) {
                            if ((listCompleteTransactionsDialog.SelectedItem.ToString().Equals(c.ToString()))) {
                                transFound = c;
                                break;
                            }   
                        }
                        if (transFound != null)
                        {
                            showCompleteTransactionDialog.AddDisplayItems(transFound);
                            switch (showCompleteTransactionDialog.Display())
                            {
                                case DialogReturn.Remove: // transaction Remove
                                    bookShop.DeleteTransaction(transFound);

                                    continue;
                                case DialogReturn.Done:
                                    continue;
                            }
                        }
                        else {
                            MessageBox.Show("A line was selected");
                        }
                        
                    } else {
                        MessageBox.Show("No Complete Transactions");
                        return;
                    }
                }
                catch(BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnSave_Click(object sender, EventArgs e)
        {
            // XXX Save button handler
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "VRS Files|*.vrs";
                saveFileDialog.AddExtension = true;
                saveFileDialog.InitialDirectory = Application.StartupPath;
                if (saveFileDialog.ShowDialog() != DialogResult.OK) return;
                // XXX
            }
            catch (Exception)
            {
                MessageBox.Show("Serialization Failed");
            }
        }

        private void bnRestore_Click(object sender, EventArgs e)
        {
            // XXX Restore button handler
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "VRS Files|*.vrs";
                openFileDialog.InitialDirectory = Application.StartupPath;
                if (openFileDialog.ShowDialog() != DialogResult.OK) return;
                // XXX
            }
 
            catch (Exception)
            {
                MessageBox.Show("Serialization Failed");
            }
        }

        private void bnDone_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
