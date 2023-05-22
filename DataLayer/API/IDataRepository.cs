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

        void AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(string bookId);
        Book GetBookById(string bookId);

        void AddReader(Person person);
        void UpdateReader(Person person);
        void DeleteReader(string personId);
        Person GetReaderById(string personId);

        void AddEmployee(Person person);
        void UpdateEmployee(Person person);
        void DeleteEmployee(string personId);
        Person GetEmployeeById(string personId);

        void AddSupplier(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(string supplierId);
        Supplier GetSupplierById(string supplierId);

        public static IDataRepository CreateDataRepository(IDataGenerator? generator = default)
        {
            return new DataRepository(generator ?? new EmptyGenerate());
        }
    }
}
