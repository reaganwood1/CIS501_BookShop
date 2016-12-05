using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace edu.ksu.cis.masaaki
{
    public class Book
    {
        /// <summary>
        /// title of the book
        /// </summary>
        private string title;

        /// <summary>
        /// public getter for title
        /// </summary>
        public string Title {
            get {
                return title;
            }
        }

        /// <summary>
        /// author of the book
        /// </summary>
        private string author;

        /// <summary>
        /// public getter for author
        /// </summary>
        public string Author {
            get
            {
                return author;
            }
        }

        /// <summary>
        /// author of the book
        /// </summary>
        private string publisher;

        /// <summary>
        /// public getter for publisher
        /// </summary>
        public string Publisher {
            get
            {
                return publisher;
            }
        }

        /// <summary>
        /// isbn number of the book
        /// </summary>
        private string isbn;

        /// <summary>
        /// public getter for isbn
        /// </summary>
        public string Isbn {
            get
            {
                return Isbn;
            }
        }

        /// <summary>
        /// publish date of the book
        /// </summary>
        private string publishDate;

        /// <summary>
        /// public getter for publishDate
        /// </summary>
        public string PublishDate {
            get
            {
                return publishDate;
            }
        }

        /// <summary>
        /// price of the book
        /// </summary>
        private decimal price;

        /// <summary>
        /// public getter for the price
        /// </summary>
        public decimal Price {
            get
            {
                return price;
            }
        }

        /// <summary>
        /// quantity of books available
        /// </summary>
        private int quantity;

        /// <summary>
        /// public getter for quantity
        /// </summary>
        public int Quantity {
            get
            {
                return quantity;
            }
        }

        /// <summary>
        /// Constructor for a Book. 
        /// </summary>
        /// <param name="title">title of the book</param>
        /// <param name="author">author of the book</param>
        /// <param name="publisher">publisher of the book</param>
        /// <param name="isbn">isbn of the book</param>
        /// <param name="publishDate">publish date of the book</param>
        /// <param name="price">price of the book</param>
        public Book(string title, string author, string publisher, string isbn, string publishDate, decimal price, int quantity) {

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
        public void EditBook(string title, string author, string publisher, string isbn, string publishDate, decimal price) {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.isbn = isbn;
            this.publishDate = publishDate;
            this.price = price;
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
