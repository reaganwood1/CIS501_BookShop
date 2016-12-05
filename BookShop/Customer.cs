using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Customer
    {
        /// <summary>
        /// Holds the wishlist of books that a customer wants
        /// </summary>
        private List<Book> wishlist;

        /// <summary>
        /// all Transactions that have been completed for a customer
        /// </summary>
        private List<Transaction> allTransactions;

        /// <summary>
        /// shoppingCart of books a customer intends to buy
        /// </summary>
        private Transaction shoppingCart;

        /// <summary>
        /// first name of customer
        /// </summary>
        private string firstName;

        /// <summary>
        /// public getter for the firstName
        /// </summary>
        public string FirstName {
            get {
                return firstName;
            }
        }

        /// <summary>
        /// last name of customer
        /// </summary>
        private string lastName;

        /// <summary>
        /// public getter for the last name
        /// </summary>
        public string LastName {
            get
            {
                return lastName;
            }
        }

        /// <summary>
        /// username of customer
        /// </summary>
        private string userName;

        /// <summary>
        /// public getter for userName
        /// </summary>
        public string UserName {
            get
            {
                return userName;
            }
        }

        /// <summary>
        /// password of customer
        /// </summary>
        private string password;

        /// <summary>
        /// public getter for password
        /// </summary>
        public string Password {
            get
            {
                return password;
            }
        }

        /// <summary>
        /// email address of customer
        /// </summary>
        private string emailAddress;

        /// <summary>
        /// public getter for emailAddress
        /// </summary>
        public string EmailAddress {
            get;
        }

        /// <summary>
        /// physical address
        /// </summary>
        private string address;

        /// <summary>
        /// public getter for address
        /// </summary>
        public string Address {
            get
            {
                return address;
            }
        }

        /// <summary>
        /// telephone number of customer
        /// </summary>
        private string telephoneNumber;

        /// <summary>
        /// public getter for telephoneNumber
        /// </summary>
        public string TelephoneNumber {
            get
            {
                return telephoneNumber;
            }
        }

        /// <summary>
        /// Constructor for all 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="emailAddress"></param>
        /// <param name="telephoneNumber"></param>
        public Customer(string firstName, string lastName, string userName, string password, string emailAddress, string telephoneNumber, string address) {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.emailAddress = emailAddress;
            this.address = address;
            this.telephoneNumber = telephoneNumber;
            wishlist = new List<Book>();
            shoppingCart = new Transaction(this);
            allTransactions = new List<Transaction>();
        }

        public void EditCustomerInformation(string firstName, string lastName, string userName, string password, string emailAddress, string telephoneNumber, string address)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.userName = userName;
            this.password = password;
            this.emailAddress = emailAddress;
            this.address = address;
            this.telephoneNumber = telephoneNumber;
            wishlist = new List<Book>();
            shoppingCart = new Transaction(this);
            allTransactions = new List<Transaction>();
        }

        /// <summary>
        /// Adds book to the shopping cart
        /// </summary>
        /// <param name="book">book to be added</param>
        public void AddBookToCart(Book book) {
            shoppingCart.AddBook(book); 
        }

        /// <summary>
        /// Adds book to the user's wishlist
        /// </summary>
        /// <param name="book"></param>
        public void AddBookToWishlist(Book book) {
            wishlist.Add(book);
        }

        /// <summary>
        /// Checks out the user
        /// </summary>
        /// <param name="trans">out parameter to represent the checked out book</param>
        /// <returns></returns>
        public bool Checkout(out Transaction trans) {

            if (shoppingCart.Size > 0) { // checkout can provede
                trans = shoppingCart;
                shoppingCart = new Transaction(this); // create a new Transaction for the next checkout
                allTransactions.Add(trans); // add trans to the complete Transactions list for the customer
                return true;
            }

            // there was not a shoppingCart with any items to checkout successfully
            trans = null;
            return false;
        }

        /// <summary>
        /// Removes a book from the shoppingCart
        /// </summary>
        /// <param name="book"></param>
        public bool RemoveBookFromCart(Book book) {
            if (shoppingCart.Contains(book)) {
                shoppingCart.DecrementQuantityOrRemoveBook(book);
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Remove Book from the Wishlist
        /// </summary>
        /// <param name="book"></param>
        public bool RemoveBookFromWishlist(Book book) {
            if (wishlist.Remove(book)) {
                return true; // book was found and removed from the Wishlist
            }
            return false; // book was not found in the Wishlist
        }

        /// <summary>
        /// Removes the transaction from the completed transaction if controller requests
        /// </summary>
        /// <param name="trans"></param>
        public void RemoveTransactionFromAllTransactions(Transaction trans) {
            allTransactions.Remove(trans);
        }

        /// <summary>
        /// ToString override returns descriptive information about the Customer
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return firstName + " " + lastName + " " + userName + " " + emailAddress + " " + address + " " + telephoneNumber;
        }

        /// <summary>
        /// Return all the transactions from the user
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetUserTransactionHistory() {
            return allTransactions;
        }

        /// <summary>
        /// returns the user's shopping cart
        /// </summary>
        /// <returns></returns>
        public Transaction GetUserShoppingCart() {
            return shoppingCart;
        }

        /// <summary>
        /// returns the user's current Wishlist
        /// </summary>
        /// <returns></returns>
        public List<Book> GetWishList() {
            return wishlist;
        }
    }
}
