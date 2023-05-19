using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.API
{
    public interface ILogic
    {
        void BookAcquisition(IBook book, string supplierId, string employeeId);
        void UpdateBook(IBook book);
        void BookDeletion(string bookId, string employeeId);
        IBook? GetBookById(string bookId);

        void BookRent(string bookId, string readerId, string employeeId);
        void BookReturn(string bookId, string readerId, string employeeId);

        void AddReader(IPerson person);
        void UpdateReader(IPerson person);
        void DeleteReader(IPerson.PersonIdType personId);
        IPerson? GetReaderById(IPerson.PersonIdType personId);

        void AddEmployee(IPerson person);
        void UpdateEmployee(IPerson person);
        void DeleteEmployee(IPerson.PersonIdType personId);
        IPerson? GetEmployeeById(IPerson.PersonIdType personId);

        void AddSupplier(ISupplier supplier);
        void UpdateSupplier(ISupplier supplier);
        void DeleteSupplier(string supplierId);
        ISupplier? GetSupplierById(string supplierId);
    }
}
