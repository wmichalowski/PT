using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Implementation;

namespace DataLayer.API
{
    public interface IDataContext
    {
        IQueryable<IBook> Books { get; }

        public static IDataContext DataContextFactory(string? connectionString = null) => new DataContext(connectionString);

        public abstract void AddBook(int id, string title, string author, string category, string publisher);
        public abstract void RemoveBook(int id);
        public abstract IBook GetBookById(int id);
        public abstract IEnumerable<IBook> GetAllBooks();
    }
}
