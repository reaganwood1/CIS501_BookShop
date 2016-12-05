using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class BookQuantity
    {
        /// <summary>
        /// number of Books that will be potentially purchased
        /// </summary>
        private int quantity;


        public int Quantity {
            get;
        }

        /// <summary>
        /// price of the Book to be potentially purchased
        /// </summary>
        private double price;

        /// <summary>
        /// Book to be potentially purchased at a certain sum
        /// </summary>
        private Book book;

        /// <summary>
        /// public getter for Book
        /// </summary>
        public Book Book {
            get;
        }

        /// <summary>
        /// initial BookQuantity constructor
        /// </summary>
        /// <param name="price">price of the book when the Book was picked up</param>
        /// <param name="book">Book to be potentially purchased</param>
        public BookQuantity(double price, Book book) {
            this.quantity = 1;
            this.price = price;
            this.book = book;
        }

        /// <summary>
        /// Decrement the quantity if possible
        /// </summary>
        /// <returns></returns>
        public bool DecrementQuantity() {
            if (quantity > 0) {
                quantity--;
                book.AddToBookQuantity();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Increments the amount of books that will be potentially bought if the book is available
        /// </summary>
        /// <returns>false or true based on the availability of the Book</returns>
        public bool IncremenentQuantity() {
            if (book.DecrementIfAvailable())
            {
                quantity++;
                return true;
            }
            return false;
        }

        /// <summary>
        /// If the books are equal, return true
        /// </summary>
        /// <param name="b1"></param>
        /// <returns></returns>
        public bool BookMatches(Book b1) {
            if (book == b1)
                return true;
            else
                return false;
        }
    }
}
