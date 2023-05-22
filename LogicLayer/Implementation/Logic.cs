using System.Net;
using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;

namespace LogicLayer.Implementation
{
    public class Logic : ILogic
    {
        private readonly IDataRepository _dataRepository;
        private readonly IEventsRecording _events;

        public Logic(IDataRepository dataRepository, IEventsRecording events)
        {
            _dataRepository = dataRepository;
            _events = events;
        }

        public void BookAcquisition(Book book, string supplierId, string employeeId)
        {
            if (_dataRepository.GetBookById(book.BookId) == null)
            {
                _dataRepository.AddBook(book);
                _events.RecordBookAcquisition(book, supplierId, employeeId, DateTime.Now);
            }
            else
            {
                throw new ArgumentException("Book already exists");
            }
        }

        public void UpdateBook(Book book)
        {
            if (_dataRepository.GetBookById(book.BookId) != null)
            {
                _dataRepository.UpdateBook(book);
            }
        }

        public void BookDeletion(string bookId, string employeeId)
        {
            if (_dataRepository.GetBookById(bookId) != null)
            {
                _dataRepository.DeleteBook(bookId);
                _events.RecordBookDeletion(bookId, employeeId, DateTime.Now);
            }
        }

        public void BookRent(string bookId, string readerId, string employeeId)
        {
            Book bookToRent = _dataRepository.GetBookById(bookId);
            if (_dataRepository.GetBookById(bookId) != null && bookToRent.Available == true)
            {
                bookToRent.Available = false;
                _events.RecordBookCheckout(bookId, readerId, employeeId, DateTime.Now);
            }
        }

        public void BookReturn(string bookId, string readerId, string employeeId)
        {
            Book bookToRent = _dataRepository.GetBookById(bookId);

            if (_dataRepository.GetBookById(bookId) != null && bookToRent.Available == false)
            {

                bookToRent.Available = true;
                _events.RecordBookCheckout(bookId, readerId, employeeId, DateTime.Now);
            }
        }

        public Book? GetBookById(string bookId)
        {
            var book = _dataRepository.GetBookById(bookId);
            return book ?? throw new ArgumentException("Book not found.");
        }

        public void AddReader(Person person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) == null)
            {
                _dataRepository.AddReader(person);
            }
        }

        public void UpdateReader(Person person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) != null)
            {
                _dataRepository.UpdateReader(person);
            }
        }

        public void DeleteReader(string personId)
        {
            if (_dataRepository.GetReaderById(personId) != null)
            {
                _dataRepository.DeleteReader(personId);
            }
        }

        public Person? GetReaderById(string personId)
        {
            var person = _dataRepository.GetReaderById(personId);
            return person ?? throw new ArgumentException("Person not found");
        }

        public void AddEmployee(Person person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) == null)
            {
                _dataRepository.AddEmployee(person);
            }
        }

        public void UpdateEmployee(Person person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) != null)
            {
                _dataRepository.UpdateEmployee(person);
            }
        }

        public void DeleteEmployee(string personId)
        {
            if (_dataRepository.GetEmployeeById(personId) != null)
            {
                _dataRepository.DeleteEmployee(personId);
            }
        }

        public Person? GetEmployeeById(string personId)
        {
            var employee = _dataRepository.GetEmployeeById(personId);
            return employee ?? throw new ArgumentException("no such employee");
        }

        public void AddSupplier(Supplier supplier)
        {
            if (_dataRepository.GetSupplierById(supplier.SupplierId) == null)
            {
                _dataRepository.AddSupplier(supplier);
            }
        }

        public void UpdateSupplier(Supplier supplier)
        {
            if (_dataRepository.GetSupplierById(supplier.SupplierId) != null)
            {
                _dataRepository.UpdateSupplier(supplier);
            }
        }

        public void DeleteSupplier(string supplierId)
        {
            if (_dataRepository.GetSupplierById(supplierId) != null)
            {
                _dataRepository.DeleteSupplier(supplierId);
            }
        }

        public Supplier? GetSupplierById(string supplierId)
        {
            var supplier = _dataRepository.GetSupplierById(supplierId);
            return supplier ?? throw new ArgumentException("no such supplier");
        }

    }
}