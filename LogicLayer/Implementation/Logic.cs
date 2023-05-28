using DataLayer.API;
using LogicLayer.API;

namespace LogicLayer.Implementation
{
    public class Logic : ILogic
    {
        private readonly IDataRepository _dataRepository;
        public Logic(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void BookAcquisition(IBook book, string supplierId, string employeeId)
        {
            if (_dataRepository.GetBookById(book.BookId) == null)
            {
                _dataRepository.RecordBookAcquisition(book, supplierId, employeeId, DateTime.Now);
            }
            else
            {
                throw new ArgumentException("Book already exists");
            }
        }

        public void UpdateBook(IBook book)
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
                _dataRepository.RecordBookDeletion(bookId, employeeId, DateTime.Now);
            }
        }

        public void BookRent(string bookId, string readerId, string employeeId)
        {
            IBook bookToRent = _dataRepository.GetBookById(bookId);
            if (_dataRepository.GetBookById(bookId) != null && bookToRent.Available == true)
            {
                bookToRent.Available = false;
                _dataRepository.RecordBookCheckout(bookId, readerId, employeeId, DateTime.Now);
            }
        }

        public void BookReturn(string bookId, string readerId, string employeeId)
        {
            IBook bookToRent = _dataRepository.GetBookById(bookId);

            if (_dataRepository.GetBookById(bookId) != null && bookToRent.Available == false)
            {

                bookToRent.Available = true;
                _dataRepository.RecordBookCheckout(bookId, readerId, employeeId, DateTime.Now);
            }
        }

        public IBook? GetBookById(string bookId)
        {
            var book = _dataRepository.GetBookById(bookId);
            return book ?? throw new ArgumentException("Book not found.");
        }

        public void AddReader(IReader person)
        {
            if (_dataRepository.GetReaderById(person.ReaderId) == null)
            {
                _dataRepository.AddReader(person);
            }
        }

        public void UpdateReader(IReader person)
        {
            if (_dataRepository.GetReaderById(person.ReaderId) != null)
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

        public IReader? GetReaderById(string personId)
        {
            var person = _dataRepository.GetReaderById(personId);
            return person ?? throw new ArgumentException("Person not found");
        }

        public void AddEmployee(IEmployee person)
        {
            if (_dataRepository.GetReaderById(person.EmployeeId) == null)
            {
                _dataRepository.AddEmployee(person);
            }
        }

        public void UpdateEmployee(IEmployee person)
        {
            if (_dataRepository.GetReaderById(person.EmployeeId) != null)
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

        public IEmployee? GetEmployeeById(string personId)
        {
            var employee = _dataRepository.GetEmployeeById(personId);
            return employee ?? throw new ArgumentException("no such employee");
        }

        public void AddSupplier(ISupplier supplier)
        {
            if (_dataRepository.GetSupplierById(supplier.SupplierId) == null)
            {
                _dataRepository.AddSupplier(supplier);
            }
        }

        public void UpdateSupplier(ISupplier supplier)
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

        public ISupplier? GetSupplierById(string supplierId)
        {
            var supplier = _dataRepository.GetSupplierById(supplierId);
            return supplier ?? throw new ArgumentException("no such supplier");
        }

    }
}