using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Task_3.Data
{
    /// <summary>
    /// Flyweight
    /// </summary>
    public class Book
    {
        public Book(BookData bookData)
        {
            this.bookData = bookData;
            ReplicatePages();
        }
        public BookData bookData { get; set; }
        public List<string> Pages { get; set; }
        private const int CharactersInPage = 1000;
        /// <summary>
        /// Divides content of a book into pages
        /// </summary>
        public virtual void ReplicatePages()
        {
            if (!string.IsNullOrEmpty(bookData.Content))
                Pages = Enumerable.Range(0, bookData.Content.Length / CharactersInPage)
                    .Select(i => bookData.Content.Substring(i * CharactersInPage, CharactersInPage)).ToList();
            else
                Pages = new List<string>();
        }
    }
}
