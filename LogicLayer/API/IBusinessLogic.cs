using LogicLayer.Implementation;
using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.API
{
    public interface IBusinessLogic
    {
        public static IBusinessLogic BusinessLogicFactory(IDataContext dataContext) => new BusinessLogic(dataContext);
        public static IBusinessLogic BusinessLogicFactory() => new BusinessLogic(IDataContext.DataContextFactory());

        public void updateBook(int Id, string Title, string Author, string Category, string Publisher);
        public void AddBook(int Id, string Title, string Author, string Category, string Publisher);
        public void RemoveBook(int Id);
        public IEnumerable<IBook> GetAllBooks();

        public void updateReader(int readerId, string name, string surname, string address, string phoneNumber, string email);
        public void AddReader(int readerId, string name, string surname, string address, string phoneNumber, string email);
        public void RemoveReader(int Id);
        public IEnumerable<IReader> GetAllReaders();

        public void updateEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email);
        public void AddEmployee(int employeeId, string name, string surname, string address, string phoneNumber, string email);
        public void RemoveEmployee(int Id);
        public IEnumerable<IEmployee> GetAllEmployees();

        public void updateSupplier(int supplierId, string name, string address, string phoneNumber, string email);
        public void AddSupplier(int supplierId, string name, string address, string phoneNumber, string email);
        public void RemoveSupplier(int Id);
        public IEnumerable<ISupplier> GetAllSuppliers();

        public void AddReturn(int returnId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp);
        public IEnumerable<IReturn> GetAllReturns();

        public void AddRent(int rentId, int readerId, int bookId, int employeeId, string intent, DateTime timestamp);
        public IEnumerable<IRent> GetAllRents();

    }
}
