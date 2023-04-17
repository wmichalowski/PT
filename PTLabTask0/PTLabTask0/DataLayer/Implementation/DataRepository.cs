using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class DataRepository: IDataRepository
    {

        private readonly ILibraryState _libraryState;

        public DataRepository(ILibraryState libraryState)
        {
            _libraryState = libraryState;
        }

        public void AddBook(IBook book) {
            _libraryState.Books.Add(book);
        }
        public void UpdateBook(IBook book) { 
            IBook bookToUpdate = _libraryState.Books.FirstOrDefault(x => x.BookId == book.BookId) ?? throw new ArgumentException("Book not found");
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Title = book.Title;
                bookToUpdate.Category = book.Category;  
                bookToUpdate.Publisher = book.Publisher;

                int index = _libraryState.Books.IndexOf(bookToUpdate);

                _libraryState.Books[index] = bookToUpdate;
            }
        }



        public void DeleteBook(string bookId)
        {
            IBook bookToDelete = _libraryState.Books.FirstOrDefault(x => x.BookId == bookId) ?? throw new ArgumentException("Book not found");
            if (bookToDelete != null)
            {
                _libraryState.Books.Remove(bookToDelete);
            }
        }
        public IBook GetBookById(string bookId)
        {
            return _libraryState.Books.FirstOrDefault(x => x.BookId == bookId) ?? throw new ArgumentException("Book not found");
        }

        public void AddReader(IPerson person) { 
            _libraryState.Readers.Add(person);
        }
        public void UpdateReader(IPerson person) { 
            IPerson readerToUpdate = _libraryState.Readers.FirstOrDefault(x => x.PersonId == person.PersonId) ?? throw new ArgumentException("Person not found");
            if(readerToUpdate != null)
            {
                readerToUpdate.Name = person.Name; 
                readerToUpdate.Surname = person.Surname;  
                readerToUpdate.Address = person.Address;
                readerToUpdate.PhoneNumber = person.PhoneNumber;
                readerToUpdate.Role = person.Role;
                readerToUpdate.Email = person.Email;
            }
        }
        public void DeleteReader(IPerson.PersonIdType personId) {
            IPerson readerToDelete = _libraryState.Readers.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
            if ( readerToDelete != null)
            {
                _libraryState.Readers.Remove(readerToDelete);
            }
        }
        public IPerson GetReaderById(IPerson.PersonIdType personId)
        {
            return _libraryState.Readers.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
        }

        public void AddEmployee(IPerson person)
        {
            _libraryState.Employees.Add(person);
        }
        public void UpdateEmployee(IPerson person)
        {
            IPerson employeeToUpdate = _libraryState.Employees.FirstOrDefault(x => x.PersonId==person.PersonId) ?? throw new ArgumentException("Person not found");
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = person.Name;
                employeeToUpdate.Surname = person.Surname;
                employeeToUpdate.Address = person.Address;
                employeeToUpdate.PhoneNumber = person.PhoneNumber;
                employeeToUpdate.Role = person.Role;
                employeeToUpdate.Email = person.Email;
            }
        }
        public void DeleteEmployee(IPerson.PersonIdType personId)
        {
            IPerson readerToDelete = _libraryState.Employees.FirstOrDefault(x=>x.PersonId==personId) ?? throw new ArgumentException("Person not found");
            if (readerToDelete != null)
            {
                _libraryState.Employees.Remove(readerToDelete);
            }
        }
        public IPerson GetEmployeeById(IPerson.PersonIdType personId)
        {
            return _libraryState.Employees.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
        }

        public void AddSupplier(ISupplier supplier)
        {
            _libraryState.Suppliers.Add(supplier);
        }
        public void UpdateSupplier(ISupplier supplier)
        {
            ISupplier supplierToUpdate = _libraryState.Suppliers.FirstOrDefault(x => x.SupplierId == supplier.SupplierId) ?? throw new ArgumentException("Supplier not found");
            if (supplierToUpdate != null)
            {
                supplierToUpdate.Name = supplier.Name;
                supplierToUpdate.Email = supplier.Email;
                supplierToUpdate.Address = supplier.Address;
                supplierToUpdate.PhoneNumber = supplier.PhoneNumber;
            }
        }
        public void DeleteSupplier(string supplierId)
        {
            ISupplier supplierToDelete = _libraryState.Suppliers.FirstOrDefault(x=>x.SupplierId==supplierId) ?? throw new ArgumentException("Supplier not found");
            if (supplierToDelete != null)
            {
                _libraryState.Suppliers.Remove(supplierToDelete);
            }
        }
        public ISupplier GetSupplierById(string supplierId)
        {
            return _libraryState.Suppliers.FirstOrDefault(x => x.SupplierId == supplierId) ?? throw new ArgumentException("Supplier not found");
        }

    }
}
