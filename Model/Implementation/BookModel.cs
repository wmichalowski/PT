using LogicLayer.API;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementation
{
    public class BookModel : IBookModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
        public string Publisher { get; set; }

        private List<BookModel> bookList;

        public BookModel()
        {
            bookList = new List<BookModel>();
        }

        public void AddBook(int bookId, string title, string author, string category, string publisher)
        {
            bookList.Add(new BookModel
            {
                BookId = bookId,
                Title = title,
                Author = author,
                Category = category,
                Publisher = publisher
            });
        }

        public void RemoveBook(int bookId)
        {
            var bookToRemove = bookList.Find(book => book.BookId == bookId);
            if (bookToRemove != null)
                bookList.Remove(bookToRemove);
        }

        public IEnumerable<IBookModel> GetAllBooks()
        {
            return bookList;
        }
    }
}
