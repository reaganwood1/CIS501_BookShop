using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    /// <summary>
    /// Holds a listing of Books and their quantity that are part of a lump purchase or potential purchase
    /// </summary>
    [Serializable]
    public class Transaction
    {
        /// <summary>
        /// allBooks that are part of the Transaction
        /// </summary>
        private List<BookQuantity> transactionContents;
        
        /// <summary>
        /// Customer the Transaction belongs to
        /// </summary>
        Customer owner;


        /// <summary>
        /// Constructor for Transaction
        /// </summary>
        public Transaction(Customer c1) {
            transactionContents = new List<BookQuantity>();
            owner = c1;
        }

        /// <summary>
        /// number of book types in the Transaction
        /// </summary>
        private int size;

        /// <summary>
        /// public getter for size
        /// </summary>
        public int Size {
            get {
                return size;
            }
        }

        /// <summary>
        /// Add book to the transaction
        /// </summary>
        /// <param name="b"></param>
        public void AddBook(Book b) {
            foreach (BookQuantity bq in transactionContents) {
                if (bq.Book == b) {
                    bq.IncremenentQuantity();
                    return;
                }
            }
            BookQuantity thisBook = new BookQuantity(b.Price, b);
            transactionContents.Add(thisBook);
            size++; // one more type of book is now part of the transaction
        }

        /// <summary>
        /// Returns whether the book is in the Transactions
        /// </summary>
        /// <param name="book"></param>
        /// <returns>true if the book is in the transaction</returns>
        public bool Contains(Book book) {
            foreach (BookQuantity bq in transactionContents) // iterate until you find the Book
            {
                if (bq.Book == book) // Book is found
                {
                    return true;
                }
            }
            return false; // Book was never found
        }

        /// <summary>
        /// Returns all of the Books in the Transaction
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAllBooksInTransaction() {
            List<Book> books = new List<Book>();
            foreach (BookQuantity bq in transactionContents) {
                books.Add(bq.Book);
            }
            return books;
        }

        /// <summary>
        /// Returns all of the BookQuantities for display purposes
        /// </summary>
        /// <returns></returns>
        public List<BookQuantity> GetAllBookQuantitiesInTransaction() {
            return transactionContents;
        }

        /// <summary>
        /// decrement the quantity of a book and then check if the transaction no longer contains a type of the book
        /// </summary>
        /// <param name="b"></param>
        public void DecrementQuantityOrRemoveBook(Book b) {
            BookQuantity quan = null;
            foreach (BookQuantity bq in transactionContents) {
                if (bq.Book == b)
                {
                    quan = bq;
                    break;
                }
            }

            // remove one type from the Transaction
            if (!quan.DecrementQuantity() && quan.Quantity == 0) {
                size--;
                transactionContents.Remove(quan);
            }
        }

        /// <summary>
        /// Removes the transaction from the customer
        /// </summary>
        public void RemoveTransactions() {
            owner.RemoveTransactionFromAllTransactions(this);
        }

        /// <summary>
        /// returns the username and the books associated with the transaction
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder returnString = new StringBuilder("");
            returnString.Append(owner.UserName + ": ");
            foreach (BookQuantity bq in transactionContents) {

                returnString.Append(bq.Book.Title + " " + bq.Book.Author + " " + "(" + bq.Quantity + ").\t");
            }
            return returnString.ToString();
            
        }
    }
}
