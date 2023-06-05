using DataLayer.API;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Metadata.Ecma335;

namespace DataLayer.Implementation
{
    internal class DataContext: DbContext, IDataContext
    {
        DbSet<Book> Books { set; get; }
        IQueryable<IBook> IDataContext.Books => Books;

        private readonly string _connectionString;

        private readonly string defaultConnectionString= "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\universityT\\projects\\git2\\PT\\PT\\DataLayerTests\\TestDB\\Database1.mdf;Integrated Security = True";
       // private readonly string defaultConnectionString= "Data Source = (LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\university\\PT\\projects\\git2\\PT\\PT\\DataLayerTests\\TestDB\\Database1.mdf;Integrated Security = True";

        public DataContext(string? connectionString = null)
        {
            this._connectionString = connectionString ?? defaultConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);

        }

        public void AddBook(int id, string title, string author, string category, string publisher)
        {
            Books.Add(new Book(id, title, author, category, publisher));
            SaveChanges();
        }

        public void RemoveBook(int id)
        {
            Books.Remove((Book)GetBookById(id));
            SaveChanges();
        }

        public IBook GetBookById(int id)
        {
            var book = (from b in Books
                        where b.Id == id
                        select b).FirstOrDefault();

            if (book == null)
            {
                throw new ArgumentException("Book not found");
            }

            return book;
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return Books.ToList();
        }

    }
}
