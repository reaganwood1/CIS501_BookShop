using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Transaction
    {
        /// <summary>
        /// allBooks that are part of the Transaction
        /// </summary>
        private Dictionary<Book, BookQuantity> dictionaryOfBooks;
        
        /// <summary>
        /// Customer the Transaction belongs to
        /// </summary>
        Customer owner;


        /// <summary>
        /// Constructor for Transaction
        /// </summary>
        public Transaction(Customer c1) {
            dictionaryOfBooks = new Dictionary<Book, BookQuantity>();
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
            get;
        }

        /// <summary>
        /// Add book to the transaction
        /// </summary>
        /// <param name="b"></param>
        public void AddBook(Book b) {
            if (dictionaryOfBooks.ContainsKey(b))
            {
                dictionaryOfBooks[b].IncremenentQuantity();
            }
            else {
                BookQuantity thisBook = new BookQuantity(b.Price, b);
                dictionaryOfBooks.Add(b, thisBook);
                size++;
            }
        }

        /// <summary>
        /// decrement the quantity of a book and then check if the transaction no longer contains a type of the book
        /// </summary>
        /// <param name="b"></param>
        public void DecrementQuantityOrRemoveBook(Book b) {
            if (dictionaryOfBooks[b].DecrementQuantity() && dictionaryOfBooks[b].Quantity == 0) {
                size--;
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
            foreach (Book b in dictionaryOfBooks.Keys) {
                returnString.Append(b.Title + " " + b.Author + " " + "(" + dictionaryOfBooks[b].Quantity + ").\t");
            }
            return returnString.ToString();
            
        }
    }
}
