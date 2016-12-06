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

                if (bookShop.Login(loginDialog.UserName, loginDialog.Password)) { // Attempt to login
                    MessageBox.Show("Login Succeeded");
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
            if (!bookShop.LoggedIn()) {
                MessageBox.Show("This operation requires login");
                return;
            }
            Customer c = bookShop.GetLoggedInUserInformation();
            customerDialog.FirstName = c.FirstName; // set initial conditions for display and editing purposes
            customerDialog.LastName = c.LastName;
            customerDialog.UserName = c.UserName;
            customerDialog.Password = c.Password;
            customerDialog.Address = c.Address;
            customerDialog.EMailAddress = c.EmailAddress;
            customerDialog.TelephoneNumber = c.TelephoneNumber;
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
                                        MessageBox.Show("Book is already in the Wishlist"); 
                                } else { // nobody was logged in
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
                    if (bookShop.LoggedIn()) // check to see if user is loggedin
                    {
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
                            Book selected = null;
                            foreach (Book b in books) {  // search for the book that was selected
                                if (b.GetTitleAndAuthor().Equals((string)wishListDialog.SelectedItem)) {
                                    selected = b;
                                    break;
                                }
                            }
                            bookInWishListDialog.BookTitle = selected.Title; // add all of the fields to the dialog
                            bookInWishListDialog.Author = selected.Author;
                            bookInWishListDialog.Publisher = selected.Publisher;
                            bookInWishListDialog.Date = selected.PublishDate;
                            bookInWishListDialog.Price = selected.Price;
                            bookInWishListDialog.Stock = selected.Quantity;
                            bookInWishListDialog.ISBN = selected.Isbn;
                            switch (bookInWishListDialog.Display())
                            {
                                case DialogReturn.AddToCart:
                                    if (!bookShop.AddBookToCart("", books[wishListDialog.SelectedIndex])) // add Book by index into the List of books
                                        MessageBox.Show("No stock of this book");
                                    continue;
                                case DialogReturn.Remove:
                                    if (bookShop.DeleteBookFromWishlist(books[wishListDialog.SelectedIndex])) // deletes the Book from the Wishlist
                                        MessageBox.Show("Book not located in the Wishlist");
                                    continue;
                                case DialogReturn.Done: // Done
                                    continue;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Shopping Cart is empty");
                            return;
                        }
                    }
                    else
                    {
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

                    if (bookShop.LoggedIn())
                    { // user is logged in
                      //-----------------------------------
                        Transaction trans;
                        if (bookShop.GetShoppingCart(out trans)) 
                        { // shopping cart has books
                            List < BookQuantity > books = trans.GetAllBookQuantitiesInTransaction(); // get a listing of all the Books in the Transaction
                            decimal totalPrice = 0;
                            foreach (BookQuantity bq in books) { // add each Book to be printed
                                cartDialog.AddDisplayItems(bq.ToString());
                                totalPrice = totalPrice + bq.Price * bq.Quantity; // increment the total price
                            }
                            cartDialog.AddDisplayItems("==========================", "Total Price : " + totalPrice); // add other two lines to the output
                            switch (cartDialog.Display())
                            {
                                case DialogReturn.CheckOut:  // check out
                                    bookShop.CheckOut();
                                    return;
                                case DialogReturn.ReturnBook: // remove a book
                                    BookQuantity selectedBookQuantity = books.Find(m => (string)cartDialog.SelectedItem == m.ToString()); // search through all Books and see if one matches the string display
                                    if (selectedBookQuantity != null) { // check if the selected item is a Book
                                        bookShop.RemoveBookFromShoppingCart(selectedBookQuantity.Book);
                                    } else // it's not a Book that was selected
                                        MessageBox.Show("The Book was not found");
                                    continue;

                                case DialogReturn.Done: // cancel
                                    return;
                            }
                        }
                        else { // 
                            MessageBox.Show("Cart is empty");
                            return;
                        }
                        //-----------------------------------
                    }else { // user is not logged in
                        MessageBox.Show("This operation requires login");
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
                    if (bookShop.LoggedIn())
                    { // user is logged in
                        List<Transaction> trans; // stores the complete Transactions
                        if (bookShop.GetUserTransactionHistory(out trans))
                        { // transaction history found
                            listTransactionHistoryDialog.ClearDisplayItems();
                            foreach (Transaction t in trans) { // loop through each transaction and add the toString to be displayed
                                listTransactionHistoryDialog.AddDisplayItems(t.ToString());
                            }
                            if (listTransactionHistoryDialog.Display() == DialogReturn.Done) return;
                            // Select is pressed

                            Transaction transFound = trans.Find(m => (string)listTransactionHistoryDialog.SelectedItem == m.ToString()); // search through all the Transactions and see if the Transaction was selected
                            if (transFound != null)
                            { // check if the selected item is a transaction
                                showTransactionDialog.ClearDisplayItems();
                                List<BookQuantity> listQuantities = transFound.GetAllBookQuantitiesInTransaction(); // get the bookquantities for the transaction
                                Decimal totalPrice = 0;
                                foreach (BookQuantity b in listQuantities) { // loop throught the BookQuantities and calculate the total cost and set the BookQuantities for display
                                    showTransactionDialog.AddDisplayItems(b.ToString()); // add the BookQuantity ToString
                                    totalPrice = totalPrice + b.Price * b.Quantity; // increment the totalPrice
                                }
                                showTransactionDialog.AddDisplayItems("===================================");
                                showTransactionDialog.AddDisplayItems("Total Price : " + totalPrice); // add to the total price
                                showTransactionDialog.ShowDialog();
                            }
                            else // it's not a Book that was selected
                                MessageBox.Show("A line was selected");
                        }
                        else { // no transaction history to show
                            MessageBox.Show("Transaction History is empty");
                            return;
                        }
                    }
                    else {
                        MessageBox.Show("This operation requires login");
                        return;
                    }
                        
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
                MessageBox.Show("Another user is Logged In");
         
        }
    }
}
