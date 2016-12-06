using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    [Serializable]
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
                    return false; // returns false if the customer cannot be added because of a conflicting userName
            }
            Customer c1 = new Customer(firstName, lastName, userName, password, email, telephoneNumber, address);
            allCustomers.Add(c1);
            return true;
        }

        /// <summary>
        /// Updates the fields of the BookShopController for when serielizing occurs, setting by reference didn't work for Serialization
        /// </summary>
        /// <param name="customers">new list of Customers</param>
        /// <param name="books">new list of Books</param>
        /// <param name="pendingTransactions">new PendingTransactions list</param>
        /// <param name="completeTransactions">new complete Transactions list</param>
        public void SetNewVariableReferences(List<Customer> customers, List<Book> books, List<Transaction> pendingTransactions, List<Transaction> completeTransactions) {
            allBooks = books; // set new references
            allCustomers = customers;
            this.pendingTransactions = pendingTransactions;
            this.completeTransactions = completeTransactions;

            if (this.pendingTransactions == null) // if either pendingTransactions or completeTransactions are null, create new ones
                this.pendingTransactions = new List<Transaction>();
            if (this.completeTransactions == null)
                this.completeTransactions = new List<Transaction>();
            loggedIn = new Customer("", "", "", "", "", "", "");
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
                    return false; // if the Book with an isbn already exists, don't add it
            }
            Book book = new Book(title, author, publisher, isbn, publishDate, price, quantity); // if the Book doesn't exist, add it to the list of Books
            allBooks.Add(book);
            return true;
        }

        /// <summary>
        /// Adds a book to the logged in Customer's cart if the book is in stock
        /// </summary>
        /// <param name="isbn"></param>
        /// <returns>true if book is added to the cart, false if it was not</returns>
        public bool AddBookToCart(string isbnOptionalProvided, Book bookOptionalProvided) {
            if (bookOptionalProvided == null)
            { // if no book is given, this is an initial setup condition
                foreach (Book book in allBooks) // iterate and search by isbn until Book is found
                {
                    if (book.Isbn.Equals(isbnOptionalProvided) && book.Quantity > 0) // book is found, break out of loop and add book to the logged in customer's shopping cart
                    {
                        loggedIn.AddBookToCart(book);
                        return true;
                    }
                }
            } else if (bookOptionalProvided.Quantity > 0) {
                loggedIn.AddBookToCart(bookOptionalProvided);
                return true;
            }

            return false; // Book is out of stock
        }


        /// <summary>
        /// Adds Book to the Customer's Wishlist if logged in
        /// </summary>
        /// <param name="isbn">optional parameter for loading stage</param>
        /// /// <param name="bookOptionProvided">optional parameter for non-loading stage</param>
        /// <returns>Returns true or false on whether the book already exists in the Wishlist or not</returns>
        public bool AddBookToWishlist(string isbnOptionalProvided, Book bookOptionalProvided) {

            if (bookOptionalProvided == null)
            {
                foreach (Book book in allBooks) // search through the books until you find a match
                {
                    if (book.Isbn.Equals(isbnOptionalProvided) && !loggedIn.GetWishList().Contains(book)) // book is found, break out of loop and add book to the logged in customer's wishlist if not already there
                    {
                        loggedIn.AddBookToWishlist(book); // book added to the wishlist
                        return true;
                    } 
                }
            }
            else if (!loggedIn.GetWishList().Contains(bookOptionalProvided)) // quantity is satisfactory
            {

                loggedIn.AddBookToWishlist(bookOptionalProvided); // add the book to the wishlist
                return true;
            }

            return false; // book is in the wishlist
        }

        /// <summary>
        /// Returns whether a user is currently loggedIn
        /// </summary>
        /// <returns></returns>
        public bool LoggedIn() {
            if (!loggedIn.UserName.Equals("")) // loggedIn, a username of "" means that no one is loggedIn
                return true;
            else // not logged in
                return false;
        }

        /// <summary>
        /// Checks out the logged in user if books are available to check out
        /// </summary>
        /// <returns>returns true if a checkout was possible and happened, else it returns false</returns>
        public bool CheckOut() {
                Transaction trans;
            if (loggedIn.Checkout(out trans))
            {// Transaction returned in the out parameter
                pendingTransactions.Add(trans);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Removes a Book from shoppingCart
        /// </summary>
        /// <param name="book">Book to be removed from the Shopping Cart</param>
        /// <returns>returns true or false based on whether the book was removed from the shoppingCart of the logged in user</returns>
        public bool RemoveBookFromShoppingCart(Book book) {
            if (loggedIn.RemoveBookFromCart(book))
            { // book is in the shopping cart
                return true;
            }
            else {
                return false; // book is not in the shopping cart
            }
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
                        return true; // user successfully logged in
                    }
                }
            return false; // no log in
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
        public void EditUserInformation(string firstName, string lastName, string userName, string password, string email, string address, string number) {
            if (LoggedIn()) { // only allow access to editing the user if the user is loggedIn
                loggedIn.EditCustomerInformation(firstName, lastName, userName, password, email, number, address);
            } 
        }

        /// <summary>
        /// Edits user information for users that are not logged in
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="email"></param>
        /// <param name="address"></param>
        /// <param name="number"></param>
        /// <param name="c1"></param>
        public void EditUserInformationForUsersNotLoggedIn(string firstName, string lastName, string userName, string password, string email, string address, string number, Customer c1) {
            c1.EditCustomerInformation(firstName, lastName, userName, password, email, number, address);
        }

        /// <summary>
        /// Returns whether a user is currently loggedIn or not
        /// </summary>
        /// <returns>true: logged out successfully, false: nobody was logged in</returns>
        public bool Logout() {
            if (LoggedIn()) // logged in true
            {
                loggedIn = new Customer("", "", "", "", "", "", ""); // create blank user swapped with new reference as to not destory the old one
                return true;
            }
            else { // not logged in
                return false;
            }
        }

        /// <summary>
        /// returns whether a user has any transaction history
        /// </summary>
        /// <returns>true if there is a transaction history, false if there isn't</returns>
        public bool GetUserTransactionHistory(out List<Transaction> list) {
                list = loggedIn.GetUserTransactionHistory();
                if (list.Count > 0) // there are transactions for the user
                {
                    return true;
                }
                else // there are not transactions for the user
                    return false;
        }

        /// <summary>
        /// Gets the shopping cart of the user
        /// </summary>
        /// <param name="trans"></param>
        /// <returns>true if there are books in the shopping cart, false if there are not</returns>
        public bool GetShoppingCart(out Transaction trans) {
                trans = loggedIn.GetUserShoppingCart(); // get the shopping cart of the logged in user
                if (trans.GetAllBooksInTransaction().Count > 0)
                    return true; // customer has a shopping cart with items in it and is logged in 
                else
                    return false; // no items in shopping cart
        }

        /// <summary>
        /// Gets the wishlist of logged in user
        /// </summary>
        /// <param name="list">out parameter for wishlist of the user</param>
        /// <returns>true if there are books, false if there are not</returns>
        public bool GetWishList(out List<Book> list) {
            list = loggedIn.GetWishList();
            if (list.Count > 0) {
                return true;
            }
            return false;   
        }

        /// <summary>
        /// Gets all of the Books in the BookShop
        /// </summary>
        /// <returns>gets a listing of all the books in the BookShop</returns>
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
        /// <param name="list">out list that will hold the pendingTransactions</param>
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
        /// <param name="list">out list to hold all completeTransactions</param>
        /// <returns>returns true if there are Transactions, false if there not</returns>
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
            book.EditBook(title, author, publisher, isbn, date, price, quantity);
        }

        /// <summary>
        /// Remove the Transaction from pendingtransactions and its assocaited relations
        /// </summary>
        /// <param name="trans"></param>
        public void RemoveTransactionFromPendingTransactions(Transaction trans) {
            trans.RemoveTransactions(); // navigates all the way to customer and edits itself
            pendingTransactions.Remove(trans); // remove fromt he pendingTransactions list
        }

        /// <summary>
        /// deletes the transaction from the complete transactions list
        /// </summary>
        /// <param name="trans"></param>
        public void DeleteTransaction(Transaction trans) {
            trans.RemoveTransactions(); // removes itself all the way to user
            completeTransactions.Remove(trans); // remove the transaction
        }

        /// <summary>
        /// Moves the Transaction from pending to complete
        /// </summary>
        /// <param name="trans">moves a transaction to the completed section</param>
        public void ProcessPendingTransaction(Transaction trans) {
            completeTransactions.Add(trans);
            pendingTransactions.Remove(trans);
        }

        /// <summary>
        /// Deletes Book from logged in Customer's Wishlist
        /// </summary>
        /// <param name="book"></param>
        /// <returns>true if the book was found, false if wasn't</returns>
        public bool DeleteBookFromWishlist(Book book) {
            if (loggedIn.RemoveBookFromWishlist(book))
            {
                return true; // book was found and deleted from the wishlist
            }
            else
                return false; // book was not found, and therefore, not deleted from the wishlist
        }

        /// <summary>
        /// Initial load for processing pending transactions and completing a transaction
        /// </summary>
        /// <param name="index">index of the Transaction</param>
        public void ProcessPendingTransactionByIndex(int index) {
            Transaction trans = pendingTransactions[index];
            completeTransactions.Add(trans);
            pendingTransactions.Remove(trans);
        }
    }
}