using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
                    List<Customer> customers = bookShop.GetAllCustomers();
                    listCustomersDialog.AddDisplayItems(customers.ToArray()); // null is a dummy argument
                    if (listCustomersDialog.Display() == DialogReturn.Done) return;
                    // select button is pressed
                    Customer customer = null;
                    foreach (Customer c in customers)
                    {
                        if ((listCustomersDialog.SelectedItem.ToString().Equals(c.ToString()))) // search for the right customer
                        {
                            customer = c;
                            break;
                        }
                    }
                    if (customer != null) // a customer was located
                    {
                        customerDialog.FirstName = customer.FirstName; // set values for customer to begin editing
                        customerDialog.LastName = customer.LastName;
                        customerDialog.UserName = customer.UserName;
                        customerDialog.Password = customer.Password;
                        customerDialog.Address = customer.Address;
                        customerDialog.EMailAddress = customer.EmailAddress;
                        customerDialog.TelephoneNumber = customer.TelephoneNumber;
                        if (customerDialog.Display() == DialogReturn.Cancel) continue;
                        bookShop.EditUserInformationForUsersNotLoggedIn(customerDialog.FirstName, customerDialog.LastName, customerDialog.UserName, customerDialog.Password, customerDialog.EMailAddress, customerDialog.Address, customerDialog.TelephoneNumber, customer);
                    }
                    else {
                        MessageBox.Show("Customer not selected");
                    }
                    
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
                                Book book = (Book)listBooksDialog.SelectedItem;
                                bookDialog.ClearDisplayItems();
                                bookDialog.Author = book.Author; // set all of the windows for the display
                                bookDialog.BookTitle = book.Title;
                                bookDialog.Publisher = book.Publisher;
                                bookDialog.Date = book.PublishDate;
                                bookDialog.Stock = book.Quantity;
                                bookDialog.ISBN = book.Isbn;
                                bookDialog.Price = book.Price;
                                if (bookDialog.Display() == DialogReturn.Cancel) break;
                                // edit the existing Book with potential new information
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
                        listPendingTransactionsDialog.AddDisplayItems(trans.ToArray());  // display array of pendingTransactions
                        if (listPendingTransactionsDialog.Display() == DialogReturn.Done) return;
                        // select button is pressed
                        Transaction transFound = null;
                        foreach (Transaction c in trans) // find the selected Transaction
                        {
                            if ((listPendingTransactionsDialog.SelectedItem.ToString().Equals(c.ToString())))
                            {
                                transFound = c; // set Transaction when found
                                break;
                            }
                        }
                        if (transFound != null) 
                        { // Trnsaction was found
                            while (true)
                            {
                                try
                                {  // to capture an exception from SelectedItem/SelectedTransaction of showPendingTransactionDialog
                                    showPendingTransactionDialog.ClearDisplayItems();
                                    showPendingTransactionDialog.AddDisplayItems(transFound); // Display contents of the Transaction
                                    switch (showPendingTransactionDialog.Display())
                                    {
                                        case DialogReturn.Approve:  // Transaction Processed
                                            bookShop.ProcessPendingTransaction(transFound); // move transaction to completed Transactions
                                            break;
                                        case DialogReturn.ReturnBook: // Return Book
                                            // this dialog box wasn't built correctly, nothing I can do about. You can return a book that's a Transaction
                                            continue;
                                        case DialogReturn.Remove: // Remove transaction
                                            Transaction transToDelete = (Transaction)showPendingTransactionDialog.SelectedItem;
                                            bookShop.RemoveTransactionFromPendingTransactions(transToDelete); // Remove the Transaction
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
                        foreach (Transaction c in trans) { // look for selected Transaction
                            if ((listCompleteTransactionsDialog.SelectedItem.ToString().Equals(c.ToString()))) {
                                transFound = c;
                                break;
                            }   
                        }
                        if (transFound != null)
                        { // Transaction found
                            showCompleteTransactionDialog.AddDisplayItems(transFound);
                            switch (showCompleteTransactionDialog.Display())
                            {
                                case DialogReturn.Remove: // transaction Remove
                                    bookShop.DeleteTransaction(transFound); // Transaction will be deleted

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
                BinaryFormatter fo = new BinaryFormatter();

                using (FileStream f = new FileStream(saveFileDialog.FileName,
                         FileMode.Create,
                         FileAccess.Write, FileShare.None)) {
                    Tuple<int, BookShopController> t = new Tuple<int, BookShopController>(1, bookShop); // Store Bookshop as a Tuple
                    fo.Serialize(f, t); // serielize the Tuple
                }
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
                
                BinaryFormatter fo = new BinaryFormatter();
                using (FileStream f = new FileStream(openFileDialog.FileName,
                          FileMode.OpenOrCreate,
                          FileAccess.Read)) {
                    Tuple<int, BookShopController> t = (Tuple<int, BookShopController>)fo.Deserialize(f);
                    List<Transaction> pending;
                    t.Item2.GetAllPendingTransactions(out pending); // get fields to be set
                    List<Transaction> complete;
                    t.Item2.GetAllCompleteTransactions(out complete);
                    bookShop.SetNewVariableReferences(t.Item2.GetAllCustomers(), t.Item2.GetAllBooks(), pending, complete); // set the new reference variables.  
                }
                
                //new FileStream(Application.UserAppDataPath + "\\data.stn", FileMode.OpenOrCreate, FileAccess.Read
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
