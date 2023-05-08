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

        void AddReader(IPerson person);
        void UpdateReader(IPerson person);
        void DeleteReader(IPerson.PersonIdType personId);
        IPerson GetReaderById(IPerson.PersonIdType personId);

        void AddEmployee(IPerson person);
        void UpdateEmployee(IPerson person);
        void DeleteEmployee(IPerson.PersonIdType personId);
        IPerson GetEmployeeById(IPerson.PersonIdType personId);

        void AddSupplier(ISupplier supplier);
        void UpdateSupplier(ISupplier supplier);
        void DeleteSupplier(string supplierId);
        ISupplier GetSupplierById(string supplierId);

        public static IDataRepository CreateDataRepository(IDataGenerator? generator = default)
        {
            return new DataRepository(generator ?? new EmptyGenerate());
        }
    }
}
