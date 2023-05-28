using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Implementation;


namespace DataLayer.API
{
    public interface IDataRepository
    {

        void AddBook(IBook book);
        void UpdateBook(IBook book);
        void DeleteBook(string bookId);
        IBook GetBookById(string bookId);

        void AddReader(IReader person);
        void UpdateReader(IReader person);
        void DeleteReader(string personId);
        IReader GetReaderById(string personId);

        void AddEmployee(IEmployee person);
        void UpdateEmployee(IEmployee person);
        void DeleteEmployee(string personId);
        IEmployee GetEmployeeById(string personId);

        void AddSupplier(ISupplier supplier);
        void UpdateSupplier(ISupplier supplier);
        void DeleteSupplier(string supplierId);
        ISupplier GetSupplierById(string supplierId);

        void RecordBookAcquisition(IBook book, string supplierId, string employeeId, DateTime timestamp);
        void RecordBookDeletion(string bookId, string employeeId, DateTime timestamp);
        void RecordBookCheckout(string bookId, string readerId, string employeeId, DateTime timestamp);
        void RecordBookReturn(string bookId, string readerId, string employeeId, DateTime timestamp);

        public static IDataRepository CreateDataRepository(IDataGenerator? generator = default)
        {
            return new DataRepository(generator ?? new EmptyGenerate());
        }
    }
}
