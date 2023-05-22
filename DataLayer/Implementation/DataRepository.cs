using DataLayer.API;
using DataLayer.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class DataRepository: IDataRepository
    {

        private readonly ILibraryState _libraryState;
        private readonly DataContext _context;

        public DataRepository(IDataGenerator generator)
        {
            generator.Generate(this);
        }

        public DataRepository(ILibraryState libraryState)
        {
            _libraryState = libraryState;
        }

        public DataRepository(DataContext dataContext) {
            _context = dataContext;
        }

        public void AddBook(Book book) {

            if(_context.Books.FirstOrDefault(b => b.BookId == book.BookId) == null)
            {
                _context.Books.InsertOnSubmit(book);
                _context.SubmitChanges();   
            }
             
        }

        public void UpdateBook(Book book)
        {
            Book bookToUpdate = _context.Books.FirstOrDefault(b => b.BookId == book.BookId) ?? throw new ArgumentException("Book not found");
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Title = book.Title;
                bookToUpdate.Category = book.Category;
                bookToUpdate.Publisher = book.Publisher;

                _context.SubmitChanges();
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }

        public void DeleteBook(string bookId)
        {
            Book bookToDelete = _context.Books.FirstOrDefault(b => b.BookId == bookId) ?? throw new ArgumentException("Book not found");
            if (bookToDelete != null)
            {
                _context.Books.DeleteOnSubmit(bookToDelete);
                _context.SubmitChanges();
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }


        public Book GetBookById(string bookId) {
            Book returnedBook = _context.Books.FirstOrDefault(b => b.BookId == bookId) ?? throw new ArgumentException("Book not found");
            if (returnedBook != null)
            {
                return returnedBook;
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }

        public void AddReader(Person person) {
            _context.Readers.InsertOnSubmit(person);
            _context.SubmitChanges();
        }
        public void UpdateReader(Person person) { 
            Person readerToUpdate = _context.Readers.FirstOrDefault(b => b.PersonId == person.PersonId) ?? throw new ArgumentException("Person not found");
            if(readerToUpdate != null)
            {
                readerToUpdate.Name = person.Name; 
                readerToUpdate.Surname = person.Surname;  
                readerToUpdate.Address = person.Address;
                readerToUpdate.PhoneNumber = person.PhoneNumber;
                readerToUpdate.Email = person.Email;

                _context.SubmitChanges();
            }
        }
        public void DeleteReader(string personId) {
            Person readerToDelete = _context.Readers.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
            if ( readerToDelete != null)
            {
                _context.Readers.DeleteOnSubmit(readerToDelete);
                _context.SubmitChanges();
            }
        }
        public Person GetReaderById(string personId)
        {
            return _context.Readers.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
        }

        public void AddEmployee(Person person)
        {
            _context.Employees.InsertOnSubmit(person);
            _context.SubmitChanges();
        }
        public void UpdateEmployee(Person person)
        {
            Person employeeToUpdate = _context.Employees.FirstOrDefault(x => x.PersonId == person.PersonId) ?? throw new ArgumentException("Person not found");
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = person.Name;
                employeeToUpdate.Surname = person.Surname;
                employeeToUpdate.Address = person.Address;
                employeeToUpdate.PhoneNumber = person.PhoneNumber;
                employeeToUpdate.Email = person.Email;
                _context.SubmitChanges();
            }
        }
        public void DeleteEmployee(string personId)
        {
            Person employeeToDelete = _context.Employees.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
            if (employeeToDelete != null)
            {
                _context.Employees.DeleteOnSubmit(employeeToDelete);
                _context.SubmitChanges();
            }
        }
        public Person GetEmployeeById(string personId)
        {
            return _context.Employees.FirstOrDefault(x => x.PersonId == personId) ?? throw new ArgumentException("Person not found");
        }

        public void AddSupplier(Supplier supplier)
        {
            _context.Suppliers.InsertOnSubmit(supplier);
            _context.SubmitChanges();
        }
        public void UpdateSupplier(Supplier supplier)
        {
            Supplier supplierToUpdate = _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplier.SupplierId) ?? throw new ArgumentException("Supplier not found");
            if (supplierToUpdate != null)
            {
                supplierToUpdate.Name = supplier.Name;
                supplierToUpdate.Email = supplier.Email;
                supplierToUpdate.Address = supplier.Address;
                supplierToUpdate.PhoneNumber = supplier.PhoneNumber;

                _context.SubmitChanges();
            }
        }
        public void DeleteSupplier(string supplierId)
        {
            Supplier supplierToDelete = _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplierId) ?? throw new ArgumentException("Supplier not found");
            if (supplierToDelete != null)
            {
                _context.Suppliers.DeleteOnSubmit(supplierToDelete);
                _context.SubmitChanges();
            }
        }
        public Supplier GetSupplierById(string supplierId)
        {
            return _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplierId) ?? throw new ArgumentException("Supplier not found");
        }

    }
}
