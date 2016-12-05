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
    public partial class CustomerWindow : Form
    {
        // XXX add more fields if necessary
        BookShopController bookShop;
        CustomerDialog customerDialog;
        LoginDialog loginDialog;
        ListBooksDialog listBooksDialog;
        BookInformationDialog bookInformationDialog;
        CartDialog cartDialog;
        WishListDialog wishListDialog;
        BookInWishListDialog bookInWishListDialog;
        ListTransactionHistoryDialog listTransactionHistoryDialog;
        ShowTransactionDialog showTransactionDialog;

        public CustomerWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// overloaded constructor to set the BookShopController object and also call intialize component
        /// </summary>
        /// <param name="bookShop"></param>
        public CustomerWindow(BookShopController bookShop) : this() {
            this.bookShop = bookShop;
        }

        // XXX You may add overriding constructors (constructors with different set of arguments).
        // If you do so, make sure to call :this()
        // public CustomerWindow(XXX xxx): this() { }
        // Without :this(), InitializeComponent() is not called
        private void CustomerWindow_Load(object sender, EventArgs e)
        {
            customerDialog = new CustomerDialog();
            loginDialog = new LoginDialog();
            listBooksDialog = new ListBooksDialog();
            bookInformationDialog = new BookInformationDialog();
            cartDialog = new CartDialog();
            wishListDialog = new WishListDialog();
            bookInWishListDialog = new BookInWishListDialog();
            listTransactionHistoryDialog = new ListTransactionHistoryDialog();
            showTransactionDialog = new ShowTransactionDialog();
        }

        private void bnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // throw exception if the customer is not found
                // XXX Login Button event handler
                // First, you may want to check if anyone is logged in
                if (bookShop.LoggedIn()) {
                    throw new BookShopException("Another user is already logged in");
                }

                if (loginDialog.Display() == DialogReturn.Cancel) return;
                // XXX Login Button is pressed

                if (bookShop.Login(loginDialog.UserName, loginDialog.Password)) {
                    MessageBox.Show("Login Successful");
                } else
                    throw new BookShopException("Login Failed"); 
            }
            catch(BookShopException bsex)
            {
                MessageBox.Show(this, bsex.ErrorMessage);
            }
}

        private void bnAddCustomer_Click(object sender, EventArgs e)
        {
            try
            {
                // throw exception if the customer id is already registered
                // XXX Register Button event handler
                customerDialog.ClearDisplayItems();
                if (customerDialog.Display() == DialogReturn.Cancel) return;
                // XXX pick up information from customerDialog by calling its properties
                // and register a new customer
                if (!bookShop.AddCustomer(customerDialog.FirstName, customerDialog.LastName, customerDialog.UserName, customerDialog.Password, customerDialog.EMailAddress, customerDialog.Address, customerDialog.TelephoneNumber))
                    MessageBox.Show("Username " + customerDialog.UserName + " has already been registered");

            }
            catch (BookShopException bsex)
            {
                MessageBox.Show(this, bsex.ErrorMessage);
            }
        }

        private void bnEditSelfInfo_Click(object sender, EventArgs e)
        {
            // XXX Edit Self Info button event handler
            if (!bookShop.LoggedIn())
                throw new BookShopException("This operation requires login");
            if (customerDialog.Display() == DialogReturn.Cancel) return;
            // XXX Done button is pressed
            // edit the customer information
            bookShop.EditUserInformation(customerDialog.FirstName, customerDialog.LastName, customerDialog.UserName, customerDialog.Password, customerDialog.EMailAddress, customerDialog.Address, customerDialog.TelephoneNumber);
        }

        private void bnBook_Click(object sender, EventArgs e)
        {
            // XXX List Books buton is pressed
            
            while (true)
            { 
                try
                {  // to capture an exception from SelectedItem/SelectedIndex of listBooksDialog
                    listBooksDialog.ClearDisplayItems();
                    listBooksDialog.AddDisplayItems(bookShop.GetAllBooks().ToArray()); // adds all of the books to an array for display
                    if (listBooksDialog.Display() == DialogReturn.Done) return;
                    // select is pressed

                    if (listBooksDialog.SelectedItem is Book) // Checks to see that a book was selected before opening the bookInformationDialog
                    {
                        Book book = (Book)listBooksDialog.SelectedItem; // get the book and set the properties for display
                        bookInformationDialog.ClearDisplayItems();
                        bookInformationDialog.Author = book.Author;
                        bookInformationDialog.BookTitle = book.Title;
                        bookInformationDialog.Publisher = book.Publisher;
                        bookInformationDialog.Date = book.PublishDate;
                        bookInformationDialog.Stock = book.Quantity;
                        bookInformationDialog.ISBN = book.Isbn;
                        bookInformationDialog.Price = book.Price;
                        switch (bookInformationDialog.Display())
                        {
                            case DialogReturn.AddToCart: // Add to Cart
                                if (bookShop.LoggedIn()) // check for logged in user before attemping to add book to cart
                                {
                                    if (!bookShop.AddBookToCart("", book))
                                        MessageBox.Show("No stock of this book");
                                }
                                else
                                { // nobod was logged in
                                    MessageBox.Show("This operation requires login");
                                }                 
                                continue;

                            case DialogReturn.AddToWishList: // Add to Wishlist
                                if (bookShop.LoggedIn())
                                {
                                    if (!bookShop.AddBookToWishlist("", book))  
                                        MessageBox.Show("Book is already in the Wislist"); 
                                } else { // nobod was logged in
                                    MessageBox.Show("This operation requires login");
                                }
                                
                                continue;

                            case DialogReturn.Done: // cancel
                                continue;
                            default: return;
                        }
                    }
                    else
                        MessageBox.Show("Select a line");
                }
                catch (BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                    continue;
                }
            }
        }

        private void bnShowWishlist_Click(object sender, EventArgs e)
        {
            // XXX Show WishList Button event handler
          
            while (true)
            {
                try
                { // to capture an excepton by SelectedItem/SelectedIndex of wishListDialog
                    wishListDialog.ClearDisplayItems();
                    List<Book> books;
                    if (bookShop.GetWishList(out books))
                    { // user is logged in
                        List<string> booksArrayDisplay = new List<string>();
                        foreach (Book b in books)
                        { // gets the books in the proper format for display
                            booksArrayDisplay.Add(b.GetTitleAndAuthor());
                        }
                        wishListDialog.AddDisplayItems(booksArrayDisplay.ToArray());  // XXX null is a dummy argument
                        if (wishListDialog.Display() == DialogReturn.Done) return;
                        // select is pressed
                        //XXX 
                        switch (bookInWishListDialog.Display())
                        {
                            case DialogReturn.AddToCart:
                                // XXX 

                                continue;
                            case DialogReturn.Remove:
                                // XXX

                                continue;
                            case DialogReturn.Done: // Done
                                continue;
                        }
                    }
                    else {
                        MessageBox.Show("User not logged in");
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

        private void bnShowCart_Click(object sender, EventArgs e)
        {
           // XXX Show Cart Button event handler
            while (true)
            {
                try
                {  // to capture an exception from SelectedIndex/SelectedItem of carDisplay
                    cartDialog.ClearDisplayItems();
                    cartDialog.AddDisplayItems(null); // null is a dummy argument
                    switch (cartDialog.Display())
                    {
                        case DialogReturn.CheckOut:  // check out
                            // XXX

                            return;
                        case DialogReturn.ReturnBook: // remove a book
                               // XXX

                                continue;
                        
                        case DialogReturn.Done: // cancel
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

        private void bnTransactionHistory_Click(object sender, EventArgs e)
        {
            // XXX Transaction History button handler
            while (true)
            {
                
                try
                {  // to capture an exception from SelectedIndex/SelectedItem of listTransactionHistoryDialog
                    listTransactionHistoryDialog.ClearDisplayItems();
                    listTransactionHistoryDialog.AddDisplayItems(null); // null is a dummy argument
                    if (listTransactionHistoryDialog.Display() == DialogReturn.Done) return;
                    // Select is pressed
                    

                    showTransactionDialog.ClearDisplayItems();
                    showTransactionDialog.AddDisplayItems(null); // null is a dummy argument
                    showTransactionDialog.ShowDialog();
                }
                catch(BookShopException bsex)
                {
                    MessageBox.Show(this, bsex.ErrorMessage);
                }
            }
        }

        private void bnLogout_Click(object sender, EventArgs e)
        {
            // XXX Logout  button event handler
            if (!bookShop.Logout())
                MessageBox.Show("Nobody is logged in");
         
        }
    }
}
