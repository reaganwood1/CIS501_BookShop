using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class BookShopController
    {
        /// <summary>
        /// listing of all the completed transactions that have went through and been accepted by the staff
        /// </summary>
        private List<Transaction> completeTransactions;

        /// <summary>
        /// listing of all Transactions that need to be approved by the staff
        /// </summary>
        private List<Transaction> pendingTransactions;

        /// <summary>
        /// listing of all the Books that are being sold at the BookShop
        /// </summary>
        private List<Book> allBooks;

        /// <summary>
        /// listing of all the Customers that have registered at the BookShop
        /// </summary>
        private List<Customer> allCustomers;

        /// <summary>
        /// Customer that is currently logged in to the system
        /// </summary>
        private Customer loggedIn;

        /// <summary>
        /// Constructor for the BookShopController
        /// </summary>
        public BookShopController() {
            loggedIn = new Customer("", "", "", "", "", "", "");
            completeTransactions = new List<Transaction>();
            pendingTransactions = new List<Transaction>();
            allBooks = new List<Book>();
            allCustomers = new List<Customer>();
        }

        /// <summary>
        /// Create a customer and him to the Customer List if the userName doesn't already exist
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="telephoneNumber"></param>
        public bool AddCustomer(string firstName, string lastName, string userName, string password, string email, string address, string telephoneNumber) {
            foreach (Customer c in allCustomers) {
                if (c.UserName.Equals(userName))
                    return false;
            }
            Customer c1 = new Customer(firstName, lastName, userName, password, email, telephoneNumber, address);
            allCustomers.Add(c1);
            return true;
        }

        /// <summary>
        /// Create book and add it to the allBooks List if the isbn hasn't already been registered
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publisher"></param>
        /// <param name="isbn"></param>
        /// <param name="publishDate"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        public bool AddBook(string title, string author, string publisher, string isbn, string publishDate, decimal price, int quantity) {
            foreach (Book b in allBooks) {
                if (b.Isbn.Equals(isbn))
                    return false;
            }
            Book book = new Book(title, author, publisher, isbn, publishDate, price, quantity);
            allBooks.Add(book);
            return true;
        }

        /// <summary>
        /// Adds a book to the logged in Customer's cart
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool AddBookToCart(string isbn) {
            if (LoggedIn()) {
                foreach (Book book in allBooks)
                {
                    if (book.Isbn.Equals(isbn)) // book is found, break out of loop and add book to the logged in customer's shopping cart
                    {
                        loggedIn.AddBookToCart(book);
                        break;
                    }
                }
            }
            // no customer was logged in
            return false;
        }


        /// <summary>
        /// Adds Book to the Customer's Wishlist if logged in
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns></returns>
        public bool AddBookToWishlist(string isbn) {
            if (LoggedIn())
            {
                foreach (Book book in allBooks)
                {
                    if (book.Isbn.Equals(isbn)) // book is found, break out of loop and add book to the logged in customer's shopping cart
                    {
                        loggedIn.AddBookToWishlist(book);
                        break;
                    }
                }
            }
            // no customer was logged in
            return false;
        }

        /// <summary>
        /// Returns whether a user is currently loggedIn
        /// </summary>
        /// <returns></returns>
        public bool LoggedIn() {
            if (!loggedIn.UserName.Equals("")) // loggedIn
                return true;
            else // not logged in
                return false;
        }

        /// <summary>
        /// Checks out the logged in user
        /// </summary>
        /// <returns></returns>
        public bool CheckOut() {
            if (LoggedIn()) { // customer logged in
                Transaction trans;
                loggedIn.Checkout(out trans); // Transaction returned in the out parameter
                pendingTransactions.Add(trans); // completed Customer Transaction added to the pendingTransactions List to be Ok'd by the Staff member
                return true;
            }
            return false; // no user was logged in
        }

        /// <summary>
        /// Attempts to login
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns>Returns a tuple representing different cases of failure and success that can occur. For instance, failure could mean another user was logged in or the password
        ///  wasn't entered correctly</returns>
        public bool Login(string userName, string password) {
            
                foreach (Customer c in allCustomers)
                {
                    if (c.UserName.Equals(userName) && c.Password.Equals(password)) {
                        loggedIn = c;
                        return true;
                    }
                }
            return false;
        }

        /// <summary>
        /// Edits an existing customer's information if logged in
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public bool EditUserInformation(string firstName, string lastName, string userName, string password, string email, string address, string number) {
            if (LoggedIn()) {
                loggedIn.EditCustomerInformation(firstName, lastName, userName, password, email, number, address);
                return true;
            }
            return false; // customer wasn't logged in 
        }

        /// <summary>
        /// Returns whether a user is currently loggedIn or not
        /// </summary>
        /// <returns></returns>
        public bool Logout() {
            if (LoggedIn()) // logged in true
            {
                loggedIn = new Customer("", "", "", "", "", "", ""); // create blank user swapped with new reference as to not destory the old one
                return true;
            }
            else { // no tlogged in
                return false;
            }
        }

        /// <summary>
        /// returns whether a user has any transaction history
        /// </summary>
        /// <returns></returns>
        public bool GetUserTransactionHistory(out List<Transaction> list) {
            if (LoggedIn()) {
                list = loggedIn.GetUserTransactionHistory();
                if (list.Count > 0) // there are transactions for the user
                {
                    return true;
                }
                else // there are not transactions for the user
                    return false;
            }
            list = null;
            return false; // no transactions and not logged in
        }

        /// <summary>
        /// Gets the shopping cart of the user
        /// </summary>
        /// <param name="trans"></param>
        /// <returns></returns>
        public bool GetShoppingCart(out Transaction trans) {
            if (LoggedIn()) {
                trans = loggedIn.GetUserShoppingCart();
                if (trans.Size > 0)
                    return true; // customer has a shopping cart with items in it and is logged in 
                else
                    return false; // no items in shopping cart
            }
            trans = null; // not logged in
            return false;
        }

        /// <summary>
        /// Gets the wishlist of logged in user
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool GetWishList(out List<Book> list) {
            if (LoggedIn()) {
                list = loggedIn.GetWishList();
                if (list.Count > 0)
                    return true;
                else
                    return false;
            }
            list = null;
            return false;
        }

        /// <summary>
        /// Gets all of the Books in the BookShop
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooks() {
            return allBooks;
        }

        /// <summary>
        /// Gets all of the Customers in the BookShop
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetAllCustomers() {
            return allCustomers;
        }

        /// <summary>
        /// Gets all of the Pending Transactions
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool GetAllPendingTransactions(out List<Transaction> list) {
            if (pendingTransactions.Count > 0) { // Transactions found
                list = pendingTransactions;
                return true;
            }
            list = null; // no PendingTransactions found
            return false;
        }

        /// <summary>
        /// Gets the complete Transactions if there are any
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool GetAllCompleteTransactions(out List<Transaction> list) {
            if (completeTransactions.Count > 0) { // complete Transactions found
                list = completeTransactions;
                return true;
            }
            list = null; // no complete Transactions
            return false;
        }

        /// <summary>
        /// Edits the current Book's information
        /// </summary>
        /// <param name="title"></param>
        /// <param name="author"></param>
        /// <param name="publisher"></param>
        /// <param name="price"></param>
        /// <param name="quantity"></param>
        /// <param name="isbn"></param>
        /// <param name="date"></param>
        /// <param name="book"></param>
        public void EditBookInformation(string title, string author, string publisher, decimal price, int quantity, string isbn, string date, Book book) {
            book.EditBook(title, author, publisher, isbn, date, price);
        }

        public void DeleteTransaction(Transaction trans) {
            trans.RemoveTransactions();
        }

        /// <summary>
        /// Moves the Transaction from pending to complete
        /// </summary>
        /// <param name="trans"></param>
        public void ProcessPendingTransaction(Transaction trans) {
            completeTransactions.Add(trans);
            pendingTransactions.Remove(trans);
        }

        /// <summary>
        /// Deletes Book from logged in Customer's Wishlist
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool DeleteBookFromWishlist(Book book) {
            if (LoggedIn()) { // customer logged in and Book can be removed
                loggedIn.RemoveBookFromWishlist(book);
                return true;
            }
            return false; // Customer not logged in 
        }
    }
}