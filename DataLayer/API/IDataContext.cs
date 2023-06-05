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
        IQueryable<IEmployee> Employees { get; }
        IQueryable<IReader> Readers { get; }
        IQueryable<IRent> Rents { get; }
        IQueryable<IReturn> Returns { get;  }
        IQueryable<ISupplier> Suppliers { get; }

        public static IDataContext DataContextFactory(string? connectionString = null) => new DataContext(connectionString);

        public abstract void AddBook(int id, string title, string author, string category, string publisher);
        public abstract void RemoveBook(int id);
        public abstract IBook GetBookById(int id);
        public abstract IEnumerable<IBook> GetAllBooks();

        public abstract void AddEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email);
        public abstract void RemoveEmployee(int employeeId);
        public abstract IEmployee GetEmployeeById(int employeeId);
        public abstract IEnumerable<IEmployee> GetAllEmployees();

        public abstract void AddReader(int readerId, string name, string surname, string address, string phoneNumber, string email);
        public abstract void RemoveReader(int readerId);
        public abstract IReader GetReaderById(int readerId);
        public abstract IEnumerable<IReader> GetAllReaders();

        public abstract void AddSupplier(int supplierId, string name, string address, string phoneNumber, string email);
        public abstract void RemoveSupplier(int supplierId);
        public abstract ISupplier GetSupplierById(int supplierId);
        public abstract IEnumerable<ISupplier> GetAllSuppliers();

        public abstract void AddRent(int rentId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp);
        public abstract IRent GetRentById(int rentId);
        public abstract IEnumerable<IRent> GetAllRents();

        public abstract void AddReturn(int returnId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp);
        public abstract IReturn GetReturnById(int returnId);
        public abstract IEnumerable<IReturn> GetAllReturns();
    }
}
