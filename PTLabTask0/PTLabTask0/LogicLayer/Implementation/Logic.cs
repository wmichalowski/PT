using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;

namespace LogicLayer.Implementation
{
    public class Logic: ILogic
    {
        private readonly IDataRepository _dataRepository;

        public Logic(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }

        public void AddBook(IBook book) { 
            if (_dataRepository.GetBookById(book.BookId) == null)
            {
               _dataRepository.AddBook(book);
            }
            
        }
        public void UpdateBook(IBook book) { 
            if (_dataRepository.GetBookById(book.BookId)!= null)
            {
                _dataRepository.UpdateBook(book);
            }
       
        }
        public void DeleteBook(string bookId)
        {
            if (_dataRepository.GetBookById(bookId) != null)
            {
                _dataRepository.DeleteBook(bookId);
            }
        }
        public IBook? GetBookById(string bookId)
        {
            var book = _dataRepository.GetBookById(bookId);
            return book ?? throw new ArgumentException("Book not found.");
        }

        public void AddReader(IPerson person)
        {
            if(_dataRepository.GetReaderById(person.PersonId) == null)
            {
                _dataRepository.AddReader(person);
            }
            
        }
        public void UpdateReader(IPerson person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) != null)
            {
                _dataRepository.UpdateReader(person);
            }
           
        }
        public void DeleteReader(IPerson.PersonIdType personId)
        {
            if (_dataRepository.GetReaderById(personId) != null)
            {
                _dataRepository.DeleteReader(personId);
            }
        }
        public IPerson? GetReaderById(IPerson.PersonIdType personId)
        {
            var person = _dataRepository.GetReaderById(personId);
            return person ?? throw new ArgumentException("Person not found");
        }

        public void AddEmployee(IPerson person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) == null)
            {
                _dataRepository.AddEmployee(person);
            }
        }
        public void UpdateEmployee(IPerson person)
        {
            if (_dataRepository.GetReaderById(person.PersonId) != null)
            {
                _dataRepository.UpdateEmployee(person);
            }
        }
        public void DeleteEmployee(IPerson.PersonIdType personId)
        {
            if (_dataRepository.GetEmployeeById(personId) != null)
            {
                _dataRepository.DeleteEmployee(personId);
            }
        }
        public IPerson? GetEmployeeById(IPerson.PersonIdType personId)
        {
            var employee = _dataRepository.GetEmployeeById(personId);
            return employee ?? throw new ArgumentException("no such employee");
        }

        public void AddSupplier(ISupplier supplier)
        {
            if ( _dataRepository.GetSupplierById(supplier.SupplierId) == null)
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