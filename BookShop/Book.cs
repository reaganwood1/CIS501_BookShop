using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    class Book
    {
        /// <summary>
        /// title of the book
        /// </summary>
        private string title;

        /// <summary>
        /// author of the book
        /// </summary>
        private string author;

        /// <summary>
        /// author of the book
        /// </summary>
        private string publisher;

        /// <summary>
        /// isbn number of the book
        /// </summary>
        private string isbn;

        /// <summary>
        /// publish date of the book
        /// </summary>
        private string publishDate;

        /// <summary>
        /// price of the book
        /// </summary>
        private double price;

        /// <summary>
        /// public getter for the price
        /// </summary>
        public double Price {
            get;
        }

        /// <summary>
        /// quantity of books available
        /// </summary>
        private int quantity;

        /// <summary>
        /// Constructor for a Book. 
        /// </summary>
        /// <param name="title">title of the book</param>
        /// <param name="author">author of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="isbn">isbn of the book</param>
        /// <param name="publishDate">publish date of the book</param>
        /// <param name="price">price of the book</param>
        public Book(string title, string author, string publisher, string isbn, string publishDate, double price, int quantity) {

            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.isbn = isbn;
            this.publishDate = publishDate;
            this.price = price;
            this.quantity = quantity;
        }

        /// <summary>
        /// Edits the information of a book
        /// </summary>
        /// <param name="title">title to be edited</param>
        /// <param name="author">author to be edited</param>
        /// <param name="publisher">publisher to be edited</param>
        /// <param name="isbn">isbn to be edited</param>
        /// <param name="publishDate">publish date to be edited</param>
        /// <param name="price">price to be edited</param>
        public void EditBook(string title, string author, string publisher, string isbn, string publishDate, double price) {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.isbn = isbn;
            this.publishDate = publishDate;
            this.price = price;
        }

        /// <summary>
        /// description information about the book
        /// </summary>
        /// <returns></returns>
        public string DisplayBookDescription() {
            return publisher + ", " + isbn + " (" + publishDate + ")";
        }

        /// <summary>
        /// title and author of the book
        /// </summary>
        /// <returns></returns>
        public string DisplayBookTitleAndAuthor() {
            return title + " \"" + author + "\"";
        }

        /// <summary>
        /// returns the basic book information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return title + " " + author + " " + publisher + " " + isbn + " " + price + " " + quantity;
        }

        /// <summary>
        /// Takes a book 
        /// </summary>
        /// <returns>if a book is available, it will decmrement and return 1, if none is available it will return false</returns>
        public bool DecrementIfAvailable() {
            if (quantity > 0) {
                quantity--;
                return true;
            }
            return false;
        }

        /// <summary>
        /// increments the amount of books available by 1
        /// </summary>
        public void AddToBookQuantity() {
            quantity++;
        }
    }
}
