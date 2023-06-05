using DataLayer.API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data.Linq;

namespace DataLayerTests
{
    [TestClass]
    public class DataTests
    {
        private IDataContext _context;

        [TestInitialize]
        public void TestInitialize()
        {
            _context = IDataContext.DataContextFactory(("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\university\\PT\\projects\\git2\\PT\\PT\\DataLayerTests\\TestDB\\Database1.mdf;Integrated Security=True"));
        }


        [TestMethod]
        public void AddBook_Should_AddBookToContext()
        {
            // Arrange
            int id = 2;
            string title = "Book 1";
            string author = "John Doe";
            string category = "Fiction";
            string publisher = "ABC Publishers";

            // Act
            _context.AddBook(id, title, author, category, publisher);

            // Assert
            Assert.AreEqual(3, _context.Books.Count());
            var book = _context.GetBookById(id);
            Assert.IsNotNull(book);
            Assert.AreEqual(id, book.Id);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(category, book.Category);
            Assert.AreEqual(publisher, book.Publisher);

            _context.RemoveBook(id);
        }

        [TestMethod]
        public void RemoveBook_Should_RemoveBookFromContext()
        {
            // Arrange
            int id = 2;
            string title = "Book 1";
            string author = "John Doe";
            string category = "Fiction";
            string publisher = "ABC Publishers";
            _context.AddBook(id, title, author, category, publisher);

            // Act
            _context.RemoveBook(id);

            // Assert
            Assert.AreEqual(2, _context.Books.Count());
        }

        [TestMethod]
        public void GetBookById_Should_ReturnBookWithMatchingId()
        {
            // Arrange
            int id = 2;
            string title = "Book 1";
            string author = "John Doe";
            string category = "Fiction";
            string publisher = "ABC Publishers";
            _context.AddBook(id, title, author, category, publisher);

            // Act
            var book = _context.GetBookById(id);

            // Assert
            Assert.IsNotNull(book);
            Assert.AreEqual(id, book.Id);
            Assert.AreEqual(title, book.Title);
            Assert.AreEqual(author, book.Author);
            Assert.AreEqual(category, book.Category);
            Assert.AreEqual(publisher, book.Publisher);

            _context.RemoveBook(id);
        }

        [TestMethod]
        public void GetBookById_Should_ThrowException_WhenBookNotFound()
        {
            // Arrange
            int id = 5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => _context.GetBookById(id));
        }

        [TestMethod]
        public void GetAllBooks_Should_ReturnAllBooksInContext()
        {
            // Arrange
            int id1 = 2;
            string title1 = "Book 1";
            string author1 = "John Doe";
            string category1 = "Fiction";
            string publisher1 = "ABC Publishers";
            _context.AddBook(id1, title1, author1, category1, publisher1);

            int id2 = 3;
            string title2 = "Book 2";
            string author2 = "Jane Smith";
            string category2 = "Non-Fiction";
            string publisher2 = "XYZ Publishers";
            _context.AddBook(id2, title2, author2, category2, publisher2);

            // Act
            var books = _context.GetAllBooks();

            // Assert
            Assert.AreEqual(4, books.Count());
            var book1 = books.FirstOrDefault(b => b.Id == id1);
            Assert.IsNotNull(book1);
            Assert.AreEqual(id1, book1.Id);
            Assert.AreEqual(title1, book1.Title);
            Assert.AreEqual(author1, book1.Author);
            Assert.AreEqual(category1, book1.Category);
            Assert.AreEqual(publisher1, book1.Publisher);

            var book2 = books.FirstOrDefault(b => b.Id == id2);
            Assert.IsNotNull(book2);
            Assert.AreEqual(id2, book2.Id);
            Assert.AreEqual(title2, book2.Title);
            Assert.AreEqual(author2, book2.Author);
            Assert.AreEqual(category2, book2.Category);
            Assert.AreEqual(publisher2, book2.Publisher);

            _context.RemoveBook(id1);
            _context.RemoveBook(id2);
        }

    [TestMethod]
        public void AddEmployee_Should_AddEmployeeToContext()
        {
            // Arrange
            int employeeId = 2;
            string name = "John";
            string surname = "Doe";
            string address = "123 Main St";
            string phoneNumber = "555-1234";
            string email = "john.doe@example.com";

            // Act
            _context.AddEmployee(employeeId, name, surname, address, phoneNumber, email);

            // Assert
            Assert.AreEqual(3, _context.Employees.Count());
            var employee = _context.GetEmployeeById(employeeId);
            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.EmployeeId);
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(surname, employee.Surname);
            Assert.AreEqual(address, employee.Address);
            Assert.AreEqual(phoneNumber, employee.PhoneNumber);
            Assert.AreEqual(email, employee.Email);

            _context.RemoveEmployee(employeeId);
        }

        [TestMethod]
        public void RemoveEmployee_Should_RemoveEmployeeFromContext()
        {
            // Arrange
            int employeeId = 2;
            string name = "John";
            string surname = "Doe";
            string address = "123 Main St";
            string phoneNumber = "555-1234";
            string email = "john.doe@example.com";
            _context.AddEmployee(employeeId, name, surname, address, phoneNumber, email);

            // Act
            _context.RemoveEmployee(employeeId);

            // Assert
            Assert.AreEqual(2, _context.Employees.Count());
        }

        [TestMethod]
        public void GetEmployeeById_Should_ReturnEmployeeWithMatchingId()
        {
            // Arrange
            int employeeId = 2;
            string name = "John";
            string surname = "Doe";
            string address = "123 Main St";
            string phoneNumber = "555-1234";
            string email = "john.doe@example.com";
            _context.AddEmployee(employeeId, name, surname, address, phoneNumber, email);

            // Act
            var employee = _context.GetEmployeeById(employeeId);

            // Assert
            Assert.IsNotNull(employee);
            Assert.AreEqual(employeeId, employee.EmployeeId);
            Assert.AreEqual(name, employee.Name);
            Assert.AreEqual(surname, employee.Surname);
            Assert.AreEqual(address, employee.Address);
            Assert.AreEqual(phoneNumber, employee.PhoneNumber);
            Assert.AreEqual(email, employee.Email);

            _context.RemoveEmployee(employeeId);
        }

        [TestMethod]
        public void GetEmployeeById_Should_ThrowException_WhenEmployeeNotFound()
        {
            // Arrange
            int employeeId = 5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => _context.GetEmployeeById(employeeId));
        }

        [TestMethod]
        public void GetAllEmployees_Should_ReturnAllEmployeesInContext()
        {
            // Arrange
            int employeeId1 = 2;
            string name1 = "John";
            string surname1 = "Doe";
            string address1 = "123 Main St";
            string phoneNumber1 = "555-1234";
            string email1 = "john.doe@example.com";
            _context.AddEmployee(employeeId1, name1, surname1, address1, phoneNumber1, email1);

            int employeeId2 = 3;
            string name2 = "Jane";
            string surname2 = "Smith";
            string address2 = "456 Elm St";
            string phoneNumber2 = "555-5678";
            string email2 = "jane.smith@example.com";
            _context.AddEmployee(employeeId2, name2, surname2, address2, phoneNumber2, email2);

            // Act
            var employees = _context.GetAllEmployees();

            // Assert
            Assert.AreEqual(4, employees.Count());
            var employee1 = employees.FirstOrDefault(e => e.EmployeeId == employeeId1);
            Assert.IsNotNull(employee1);
            Assert.AreEqual(employeeId1, employee1.EmployeeId);
            Assert.AreEqual(name1, employee1.Name);
            Assert.AreEqual(surname1, employee1.Surname);
            Assert.AreEqual(address1, employee1.Address);
            Assert.AreEqual(phoneNumber1, employee1.PhoneNumber);
            Assert.AreEqual(email1, employee1.Email);

            var employee2 = employees.FirstOrDefault(e => e.EmployeeId == employeeId2);
            Assert.IsNotNull(employee2);
            Assert.AreEqual(employeeId2, employee2.EmployeeId);
            Assert.AreEqual(name2, employee2.Name);
            Assert.AreEqual(surname2, employee2.Surname);
            Assert.AreEqual(address2, employee2.Address);
            Assert.AreEqual(phoneNumber2, employee2.PhoneNumber);
            Assert.AreEqual(email2, employee2.Email);

            _context.RemoveEmployee(employeeId1);
            _context.RemoveEmployee(employeeId2);
        }

        [TestMethod]
        public void AddReader_Should_AddReaderToContext()
        {
            // Arrange
            int readerId = 2;
            string name = "John";
            string surname = "Doe";
            string address = "123 Main St";
            string phoneNumber = "555-1234";
            string email = "john.doe@example.com";

            // Act
            _context.AddReader(readerId, name, surname, address, phoneNumber, email);

            // Assert
            Assert.AreEqual(1, _context.Readers.Count());
            var reader = _context.GetReaderById(readerId);
            Assert.IsNotNull(reader);
            Assert.AreEqual(readerId, reader.ReaderId);
            Assert.AreEqual(name, reader.Name);
            Assert.AreEqual(surname, reader.Surname);
            Assert.AreEqual(address, reader.Address);
            Assert.AreEqual(phoneNumber, reader.PhoneNumber);
            Assert.AreEqual(email, reader.Email);

            _context.RemoveReader(readerId);
        }

        [TestMethod]
        public void RemoveReader_Should_RemoveReaderFromContext()
        {
            // Arrange
            int readerId = 2;
            string name = "John";
            string surname = "Doe";
            string address = "123 Main St";
            string phoneNumber = "555-1234";
            string email = "john.doe@example.com";
            _context.AddReader(readerId, name, surname, address, phoneNumber, email);

            // Act
            _context.RemoveReader(readerId);

            // Assert
            Assert.AreEqual(0, _context.Readers.Count());
        }

        [TestMethod]
        public void GetReaderById_Should_ReturnReaderWithMatchingId()
        {
            // Arrange
            int readerId = 2;
            string name = "John";
            string surname = "Doe";
            string address = "123 Main St";
            string phoneNumber = "555-1234";
            string email = "john.doe@example.com";
            _context.AddReader(readerId, name, surname, address, phoneNumber, email);

            // Act
            var reader = _context.GetReaderById(readerId);

            // Assert
            Assert.IsNotNull(reader);
            Assert.AreEqual(readerId, reader.ReaderId);
            Assert.AreEqual(name, reader.Name);
            Assert.AreEqual(surname, reader.Surname);
            Assert.AreEqual(address, reader.Address);
            Assert.AreEqual(phoneNumber, reader.PhoneNumber);
            Assert.AreEqual(email, reader.Email);

            _context.RemoveReader(readerId);
        }

        [TestMethod]
        public void GetReaderById_Should_ThrowException_WhenReaderNotFound()
        {
            // Arrange
            int readerId = 5;

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => _context.GetReaderById(readerId));
        }

        [TestMethod]
        public void GetAllReaders_Should_ReturnAllReadersInContext()
        {
            // Arrange
            int readerId1 = 2;
            string name1 = "John";
            string surname1 = "Doe";
            string address1 = "123 Main St";
            string phoneNumber1 = "555-1234";
            string email1 = "john.doe@example.com";
            _context.AddReader(readerId1, name1, surname1, address1, phoneNumber1, email1);

            int readerId2 = 3;
            string name2 = "Jane";
            string surname2 = "Smith";
            string address2 = "456 Elm St";
            string phoneNumber2 = "555-5678";
            string email2 = "jane.smith@example.com";
            _context.AddReader(readerId2, name2, surname2, address2, phoneNumber2, email2);

            // Act
            var readers = _context.GetAllReaders();

            // Assert
            Assert.AreEqual(2, readers.Count());
            var reader1 = readers.FirstOrDefault(r => r.ReaderId == readerId1);
            Assert.IsNotNull(reader1);
            Assert.AreEqual(readerId1, reader1.ReaderId);
            Assert.AreEqual(name1, reader1.Name);
            Assert.AreEqual(surname1, reader1.Surname);
            Assert.AreEqual(address1, reader1.Address);
            Assert.AreEqual(phoneNumber1, reader1.PhoneNumber);
            Assert.AreEqual(email1, reader1.Email);

            var reader2 = readers.FirstOrDefault(r => r.ReaderId == readerId2);
            Assert.IsNotNull(reader2);
            Assert.AreEqual(readerId2, reader2.ReaderId);
            Assert.AreEqual(name2, reader2.Name);
            Assert.AreEqual(surname2, reader2.Surname);
            Assert.AreEqual(address2, reader2.Address);
            Assert.AreEqual(phoneNumber2, reader2.PhoneNumber);
            Assert.AreEqual(email2, reader2.Email);

            _context.RemoveReader(readerId1);
            _context.RemoveReader(readerId2);
        }


    }
}

