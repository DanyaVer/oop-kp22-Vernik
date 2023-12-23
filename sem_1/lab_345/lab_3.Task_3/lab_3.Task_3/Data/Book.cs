using Newtonsoft.Json;
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
        public BookData bookData { get; set; }
        public List<Page> Pages { get; set; }
        private const int CharactersInPage = 1000;
        public Book(BookData bookData)
        {
            this.bookData = bookData;

            /// <summary>
            /// Divides content of a book into pages
            /// </summary>
            if (!string.IsNullOrEmpty(bookData.Content))
                Pages = Enumerable.Range(0, (bookData.Content.Length + CharactersInPage - 1) / CharactersInPage)
                    .Select(i => 
                        new Page(bookData.Content.Substring(i * CharactersInPage, Math.Min(CharactersInPage, bookData.Content.Length - i * CharactersInPage))))
                    .ToList();
            else
                Pages = new List<Page>();
        }
        public virtual List<Book> ReleaseBooks(int count = 1)
        {
            List<Book> result = new List<Book>();
            string json = JsonConvert.SerializeObject(this);
            
            for (int i = 0; i < count; i++)
            {
                Book newBook = JsonConvert.DeserializeObject<Book>(json);
                result.Add(newBook);
            }

            return result;
        }
    }
}
