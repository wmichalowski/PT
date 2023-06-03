using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    internal class MockContext : IDataContext
    {
        private readonly List<IBook> _books = new List<IBook>();

        public IQueryable<IBook> Books => _books.AsQueryable();

        public void AddBook(int id, string name)
        {
            _books.Add(new MockBook(id, name));
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return _books;
        }

        public IBook GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id) ?? throw new Exception("book not found!!!");
        }

        public void RemoveBook(int id)
        {
            if (GetBookById(id) != null) { 
                _books.Remove(GetBookById(id));
            }
        }
    }
}
