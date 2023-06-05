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

        DbSet<Employee> Employees { set; get; }
        IQueryable<IEmployee> IDataContext.Employees => Employees;

        DbSet<Reader> Readers { set; get; }
        IQueryable<IReader> IDataContext.Readers => Readers;

        DbSet<Rent> Rents { set; get; }
        IQueryable<IRent> IDataContext.Rents => Rents;

        DbSet<Return> Returns { set; get; }
        IQueryable<IReturn> IDataContext.Returns => Returns;

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

        //add

        public void AddBook(int id, string title, string author, string category, string publisher)
        {
            Books.Add(new Book(id, title, author, category, publisher));
            SaveChanges();
        }

        public void AddEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email) {
            Employees.Add(new Employee(employeeId, name, surname, address, phoneNumber, email));
            SaveChanges();
        }

        public void AddReader(int readerId, string name, string surname, string address, string phoneNumber, string email)
        {
            Readers.Add(new Reader(readerId, name, surname, address, phoneNumber, email));
            SaveChanges();
        }

        public void AddRent(int rentId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp) {
            Rents.Add(new Rent(rentId, readerId, bookId, employeeId, intent, timestamp));
            SaveChanges();
        }

        public void AddReturn(int returnId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp)
        {
            Returns.Add(new Return(returnId, readerId, bookId, employeeId, intent, timestamp));
            SaveChanges();
        }

        //remove

        public void RemoveBook(int id)
        {
            Books.Remove((Book)GetBookById(id));
            SaveChanges();
        }

        public void RemoveEmployee(int employeeId) {
            Employees.Remove((Employee)GetEmployeeById(employeeId));
            SaveChanges();
        }

        public void RemoveReader(int readerId)
        {
            Readers.Remove((Reader)GetReaderById(readerId));
            SaveChanges();
        }

        //getById

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

        public IEmployee GetEmployeeById(int id)
        {
            var emp = (from e in Employees
                        where e.EmployeeId == id
                        select e).FirstOrDefault();

            if (emp == null)
            {
                throw new ArgumentException("Employee not found");
            }

            return emp;
        }

        public IReader GetReaderById(int id)
        {
            var reader = (from r in Readers
                       where r.ReaderId == id
                       select r).FirstOrDefault();

            if (reader == null)
            {
                throw new ArgumentException("Reader not found");
            }

            return reader;
        }

        public IRent GetRentById(int id) {

            var rent = (from r in Rents
                          where r.RentId == id
                          select r).FirstOrDefault();

            if (rent == null)
            {
                throw new ArgumentException("Rent not found");
            }

            return rent;
        }

        public IReturn GetReturnById(int id)
        {

            var ret = (from r in Returns
                        where r.ReturnId == id
                        select r).FirstOrDefault();

            if (ret == null)
            {
                throw new ArgumentException("Return not found");
            }

            return ret;
        }


        //getAll

        public IEnumerable<IBook> GetAllBooks()
        {
            return Books.ToList();
        }

        public IEnumerable<IEmployee> GetAllEmployees()
        {
            return Employees.ToList();
        }

        public IEnumerable<IReader> GetAllReaders()
        {
            return Readers.ToList();
        }

        public IEnumerable<IRent> GetAllRents() { 
            return Rents.ToList();
        }

        public IEnumerable<IReturn> GetAllReturns()
        {
            return Returns.ToList();
        }

    }
}
