using LogicLayer.API;
using Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IBookModel
    {
        int BookId { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Category { get; set; }
        string Publisher { get; set; }

        void AddBook(int bookId, string title, string author, string category, string publisher);
        void RemoveBook(int bookId);
        IEnumerable<IBookModel> GetAllBooks();

        public static IBookModel BookModelFactory()
        {
            return new BookModel();
        }

    }
}
