using DataLayer.API;
using LogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementation
{
    internal class BusinessLogic: IBusinessLogic
    {

        private IDataContext dataContext;

        internal BusinessLogic(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddBook(int Id, string title, string author, string category, string publisher)
        {
            dataContext.AddBook(Id, title, author, category, publisher);
        }

        public void AddReader(int readerId, string name, string surname, string address, string phoneNumber, string email) {
            dataContext.AddReader(readerId,name, surname,address,phoneNumber, email);
        }

        public void AddEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email)
        {
            dataContext.AddEmployee(employeeId, name, surname, address, phoneNumber, email);
        }

        public void AddSupplier(int supplierId, string name, string address, string phoneNumber, string email)
        {
            dataContext.AddSupplier(supplierId, name, address, phoneNumber, email);
        }

        public void AddReturn(int returnId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp) {
            dataContext.AddReturn(returnId, readerId, bookId, employeeId, intent, timestamp);
        }

        public void AddRent(int rentId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp)
        {
            dataContext.AddRent(rentId, readerId, bookId, employeeId, intent, timestamp);
        }

        public IEnumerable<IBook> GetAllBooks()
        {
           return dataContext.GetAllBooks();
        }

        public IEnumerable<IReader> GetAllReaders()
        {
            return dataContext.GetAllReaders();
        }

        public IEnumerable<IRent> GetAllRents()
        {
            return dataContext.GetAllRents();
        }

        public IEnumerable<IReturn> GetAllReturns()
        {
            return dataContext.GetAllReturns();
        }

        public IEnumerable<IEmployee> GetAllEmployees()
        {
            return dataContext.GetAllEmployees();
        }

        public IEnumerable<ISupplier> GetAllSuppliers()
        {
            return dataContext.GetAllSuppliers();
        }

        public void RemoveBook(int Id)
        {
            dataContext.RemoveBook(Id);
        }

        public void RemoveReader(int Id)
        {
            dataContext.RemoveReader(Id);
        }

        public void RemoveEmployee(int Id)
        {
            dataContext.RemoveEmployee(Id);
        }

        public void RemoveSupplier(int Id)
        {
            dataContext.RemoveSupplier(Id);
        }

        public void updateBook(int Id, string title, string author, string category, string publisher)
        {
            IEnumerable<IBook> allBooks = dataContext.GetAllBooks();
            if (allBooks.Any(b => b.Id == Id))
            {
                dataContext.RemoveBook(Id);
                dataContext.AddBook(Id, title, author, category, publisher);
            }
            else {
                throw new Exception("book does not exist!!!");
            }
                
        }

        public void updateReader(int readerId, string name, string surname, string address, string phoneNumber, string email)
        {
            IEnumerable<IReader> allReaders = dataContext.GetAllReaders();
            if (allReaders.Any(b => b.ReaderId == readerId))
            {
                dataContext.RemoveReader(readerId);
                dataContext.AddReader(readerId, name, surname, address, phoneNumber, email);
            }
            else
            {
                throw new Exception("reader does not exist!!!");
            }

        }

        public void updateEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email)
        {
            IEnumerable<IEmployee> allEmployees = dataContext.GetAllEmployees();
            if (allEmployees.Any(b => b.EmployeeId == employeeId))
            {
                dataContext.RemoveEmployee(employeeId);
                dataContext.AddEmployee(employeeId, name, surname, address, phoneNumber, email);
            }
            else
            {
                throw new Exception("employee does not exist!!!");
            }

        }

        public void updateSupplier(int supplierId, string name, string address, string phoneNumber, string email)
        {
            IEnumerable<ISupplier> allSuppliers = dataContext.GetAllSuppliers();
            if (allSuppliers.Any(b => b.SupplierId == supplierId))
            {
                dataContext.RemoveSupplier(supplierId);
                dataContext.AddSupplier(supplierId, name, address, phoneNumber, email);
            }
            else
            {
                throw new Exception("supplier does not exist!!!");
            }

        }
    }
}
