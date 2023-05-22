using DataLayer.API;
using DataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.API
{
    public interface ILogic
    {
        void BookAcquisition(Book book, string supplierId, string employeeId);
        void UpdateBook(Book book);
        void BookDeletion(string bookId, string employeeId);
        Book? GetBookById(string bookId);

        void BookRent(string bookId, string readerId, string employeeId);
        void BookReturn(string bookId, string readerId, string employeeId);

        void AddReader(Person person);
        void UpdateReader(Person person);
        void DeleteReader(string personId);
        Person? GetReaderById(string personId);

        void AddEmployee(Person person);
        void UpdateEmployee(Person person);
        void DeleteEmployee(string personId);
        Person? GetEmployeeById(string personId);

        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(string supplierId);
        Supplier? GetSupplierById(string supplierId);
    }
}
