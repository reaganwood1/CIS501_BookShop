using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    /// <summary>
    /// BookQuantity class holds information pertaining to how much of a certain book will be ordered
    /// </summary>
    [Serializable]
    public class BookQuantity
    {
        /// <summary>
        /// number of Books that will be potentially purchased
        /// </summary>
        private int quantity;

        /// <summary>
        /// public getter for quantity
        /// </summary>
        public int Quantity {
            get {
                return quantity;
            }
        }

        /// <summary>
        /// price of the Book to be potentially purchased
        /// </summary>
        private decimal price;

        /// <summary>
        /// public getter for the price
        /// </summary>
        public decimal Price {
            get {
                return price;
            } 
        }

        /// <summary>
        /// Book to be potentially purchased at a certain sum
        /// </summary>
        private Book book;

        /// <summary>
        /// public getter for Book
        /// </summary>
        public Book Book {
            get {
                return book;
            }
        }

        /// <summary>
        /// initial BookQuantity constructor
        /// </summary>
        /// <param name="price">price of the book when the Book was picked up</param>
        /// <param name="book">Book to be potentially purchased</param>
        public BookQuantity(decimal price, Book book) {
            this.quantity = 1;
            this.price = price;
            this.book = book;
            if (!book.DecrementIfAvailable()) {// if no books are available,set the quantity to 0
                quantity = 0;
            } 
        }

        /// <summary>
        /// Decrement the quantity if possible
        /// </summary>
        /// <returns>true if books remain, false if none remain</returns>
        public bool DecrementQuantity() {
            if (quantity == 1)
            {
                quantity--;
                book.AddToBookQuantity();
                return false;
            }

            quantity--;
            book.AddToBookQuantity();
            return true;
        }

        /// <summary>
        /// Increments the amount of books that will be potentially bought if the book is available
        /// </summary>
        /// <returns>false or true based on the availability of the Book</returns>
        public bool IncremenentQuantity() {
            if (book.DecrementIfAvailable()) // is there a Book to take?
            {
                quantity++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// default for displaying basic book information pertaining to how many are currently being ordered
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return book.GetTitleAndAuthor() + ": " + quantity + "\t$" + price;
        }
    }
}
