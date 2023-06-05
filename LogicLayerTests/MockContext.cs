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

        public IQueryable<IEmployee> Employees => throw new NotImplementedException();

        public IQueryable<IReader> Readers => throw new NotImplementedException();

        public IQueryable<IRent> Rents => throw new NotImplementedException();

        public IQueryable<IReturn> Returns => throw new NotImplementedException();

        public IQueryable<ISupplier> Suppliers => throw new NotImplementedException();

        public void AddBook(int id, string title, string author, string category, string publisher)
        {
            _books.Add(new MockBook(id, title, author, category, publisher));
        }

        public void AddEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email)
        {
            throw new NotImplementedException();
        }

        public void AddReader(int readerId, string name, string surname, string address, string phoneNumber, string email)
        {
            throw new NotImplementedException();
        }

        public void AddRent(int rentId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        public void AddReturn(int returnId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp)
        {
            throw new NotImplementedException();
        }

        public void AddSupplier(int supplierId, string name, string address, string phoneNumber, string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IBook> GetAllBooks()
        {
            return _books;
        }

        public IEnumerable<IEmployee> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReader> GetAllReaders()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IRent> GetAllRents()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IReturn> GetAllReturns()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ISupplier> GetAllSuppliers()
        {
            throw new NotImplementedException();
        }

        public IBook GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id) ?? throw new Exception("book not found!!!");
        }

        public IEmployee GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IReader GetReaderById(int readerId)
        {
            throw new NotImplementedException();
        }

        public IRent GetRentById(int rentId)
        {
            throw new NotImplementedException();
        }

        public IReturn GetReturnById(int returnId)
        {
            throw new NotImplementedException();
        }

        public ISupplier GetSupplierById(int supplierId)
        {
            throw new NotImplementedException();
        }

        public void RemoveBook(int id)
        {
            if (GetBookById(id) != null) { 
                _books.Remove(GetBookById(id));
            }
        }

        public void RemoveEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void RemoveReader(int readerId)
        {
            throw new NotImplementedException();
        }

        public void RemoveSupplier(int supplierId)
        {
            throw new NotImplementedException();
        }
    }
}
