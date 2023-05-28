using DataLayer.API;

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

        void AddReader(IReader person);
        void UpdateReader(IReader person);
        void DeleteReader(string personId);
        IReader? GetReaderById(string personId);

        void AddEmployee(IEmployee person);
        void UpdateEmployee(IEmployee person);
        void DeleteEmployee(string personId);
        IEmployee? GetEmployeeById(string personId);

        void AddSupplier(ISupplier supplier);
        void UpdateSupplier(ISupplier supplier);
        void DeleteSupplier(string supplierId);
        ISupplier? GetSupplierById(string supplierId);
    }
}
