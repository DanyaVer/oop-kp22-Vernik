using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using lab_3.Task_3.Data;

namespace lab_3.Task_3.Data2
{
    public class BooksFactory
    {
        /// <summary>
        /// Contains Books based on unique keys "bookData"
        /// </summary>
        private Hashtable books = new Hashtable();
        public BooksFactory(params BookData[] booksData)
        {
            foreach (BookData bookData in booksData)
            {
                AddBookIfNotExist(bookData);
            }
        }

        /// <summary>
        /// Generates a key based on passed book metadata
        /// </summary>
        /// <param name="bookData">Data to retrieve a key for</param>
        /// <returns>A flyweight string hash for a given book data</returns>
        private string GetKey(BookData bookData)
        {
            if (bookData == null)
                throw new ArgumentException("Passed book data is null");
            IEnumerable<string> elements = new string[] { bookData.Author, bookData.EditionNumber, bookData.PublishingHouse, bookData.Series };

            elements = elements.Where(e => e != null);
            if (!elements.Any())
                return string.Empty;

            return string.Join("_", elements);
        }

        private void AddBookIfNotExist(BookData bookData)
        {
            string key = GetKey(bookData);
            Book? book = (Book?)books[key];
            if (book == null)
            {
                Console.WriteLine("Creating a new Book: {0}", key);
                books.Add(key, new Book(bookData));
            }
        }

        public Book GetBook(BookData bookData)
        {
            AddBookIfNotExist(bookData);
            Book? result = (Book?)books[GetKey(bookData)];
            return result ?? throw new InvalidProgramException("Book was not found");
        }
    }
}
