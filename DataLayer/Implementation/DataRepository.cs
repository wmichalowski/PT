using DataLayer.API;

namespace DataLayer.Implementation
{
    public class DataRepository: IDataRepository, IEventsRecording
    {

        private readonly ILibraryState _libraryState;
        private readonly DataContext _context;

        public DataRepository(IDataGenerator generator)
        {
            generator.Generate(this);
        }

        public DataRepository(DataContext dataContext) {
            _context = dataContext;
        }

        public void AddBook(IBook book) {

            if(_context.Books.FirstOrDefault(b => b.BookId == book.BookId) == null)
            {
                _context.Books.Add((Book)book);
                _context.SaveChanges();   
            }
             
        }

        public void UpdateBook(IBook book)
        {
            IBook bookToUpdate = _context.Books.FirstOrDefault(b => b.BookId == book.BookId) ?? throw new ArgumentException("Book not found");
            if (bookToUpdate != null)
            {
                bookToUpdate.Author = book.Author;
                bookToUpdate.Title = book.Title;
                bookToUpdate.Category = book.Category;
                bookToUpdate.Publisher = book.Publisher;

                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }

        public void DeleteBook(string bookId)
        {
            IBook bookToDelete = _context.Books.FirstOrDefault(b => b.BookId == bookId) ?? throw new ArgumentException("Book not found");
            if (bookToDelete != null)
            {
                _context.Books.Remove((Book)bookToDelete);
                _context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }


        public IBook GetBookById(string bookId) {
            IBook returnedBook = _context.Books.FirstOrDefault(b => b.BookId == bookId) ?? throw new ArgumentException("Book not found");
            if (returnedBook != null)
            {
                return returnedBook;
            }
            else
            {
                throw new ArgumentException("Book not found");
            }
        }

        public void AddReader(IReader person) {
            _context.Readers.Add((Reader)person);
            _context.SaveChanges();
        }
        public void UpdateReader(IReader person) { 
            IReader readerToUpdate = _context.Readers.FirstOrDefault(b => b.ReaderId == person.ReaderId) ?? throw new ArgumentException("Person not found");
            if(readerToUpdate != null)
            {
                readerToUpdate.Name = person.Name; 
                readerToUpdate.Surname = person.Surname;  
                readerToUpdate.Address = person.Address;
                readerToUpdate.PhoneNumber = person.PhoneNumber;
                readerToUpdate.Email = person.Email;

                _context.SaveChanges();
            }
        }
        public void DeleteReader(string personId) {
            IReader readerToDelete = _context.Readers.FirstOrDefault(x => x.ReaderId == personId) ?? throw new ArgumentException("Person not found");
            if ( readerToDelete != null)
            {
                _context.Readers.Remove((Reader)readerToDelete);
                _context.SaveChanges();
            }
        }
        public IReader GetReaderById(string personId)
        {
            return _context.Readers.FirstOrDefault(x => x.ReaderId == personId) ?? throw new ArgumentException("Person not found");
        }

        public void AddEmployee(IEmployee person)
        {
            _context.Employees.Add((Employee)person);
            _context.SaveChanges();
        }
        public void UpdateEmployee(IEmployee person)
        {
            IEmployee employeeToUpdate = _context.Employees.FirstOrDefault(x => x.EmployeeId == person.EmployeeId) ?? throw new ArgumentException("Person not found");
            if (employeeToUpdate != null)
            {
                employeeToUpdate.Name = person.Name;
                employeeToUpdate.Surname = person.Surname;
                employeeToUpdate.Address = person.Address;
                employeeToUpdate.PhoneNumber = person.PhoneNumber;
                employeeToUpdate.Email = person.Email;
                _context.SaveChanges();
            }
        }
        public void DeleteEmployee(string personId)
        {
            IEmployee employeeToDelete = _context.Employees.FirstOrDefault(x => x.EmployeeId == personId) ?? throw new ArgumentException("Person not found");
            if (employeeToDelete != null)
            {
                _context.Employees.Remove((Employee)employeeToDelete);
                _context.SaveChanges();
            }
        }
        public IEmployee GetEmployeeById(string personId)
        {
            return _context.Employees.FirstOrDefault(x => x.EmployeeId == personId) ?? throw new ArgumentException("Person not found");
        }

        public void AddSupplier(ISupplier supplier)
        {
            _context.Suppliers.Add((Supplier)supplier);
            _context.SaveChanges();
        }
        public void UpdateSupplier(ISupplier supplier)
        {
            ISupplier supplierToUpdate = _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplier.SupplierId) ?? throw new ArgumentException("Supplier not found");
            if (supplierToUpdate != null)
            {
                supplierToUpdate.Name = supplier.Name;
                supplierToUpdate.Email = supplier.Email;
                supplierToUpdate.Address = supplier.Address;
                supplierToUpdate.PhoneNumber = supplier.PhoneNumber;

                _context.SaveChanges();
            }
        }
        public void DeleteSupplier(string supplierId)
        {
            ISupplier supplierToDelete = _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplierId) ?? throw new ArgumentException("Supplier not found");
            if (supplierToDelete != null)
            {
                _context.Suppliers.Remove((Supplier)supplierToDelete);
                _context.SaveChanges();
            }
        }
        public ISupplier GetSupplierById(string supplierId)
        {
            return _context.Suppliers.FirstOrDefault(x => x.SupplierId == supplierId) ?? throw new ArgumentException("Supplier not found");
        }

        public void RecordBookAcquisition(IBook book, string supplierId, string employeeId, DateTime timestamp)
        {
            BookAcquisition acquisition = new(102, supplierId, book.BookId, employeeId, timestamp);

            _context.Books.Add((Book)book);
            _context.Event_BookAcquisitions.Add(acquisition);
            _context.SaveChanges();
        }

        public void RecordBookDeletion(string bookId, string employeeId, DateTime timestamp)
        {
            _context.Event_BookDeletions.Add(new BookDeletion(111, bookId, employeeId, timestamp));
            _context.SaveChanges();
        }

        public void RecordBookCheckout(string bookId, string readerId, string employeeId, DateTime timestamp)
        {
            _context.Event_RentsReturns.Add(new Rent_Return(101, bookId, readerId, employeeId, "Rent", timestamp));
            _context.SaveChanges();
        }

        public void RecordBookReturn(string bookId, string readerId, string employeeId, DateTime timestamp)
        {
            _context.Event_RentsReturns.Add(new Rent_Return(300, bookId, readerId, employeeId, "Return", timestamp));
            _context.SaveChanges();
        }

    }
}
