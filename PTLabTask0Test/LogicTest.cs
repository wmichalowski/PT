using System;
using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;

namespace LogicLayer.Implementation.Tests
{
    [TestClass]
    public class LogicTests
    {
        private IDataRepository _dataRepository;
        private ILibraryState _libraryState;
        private ILogic _logic;
        private IEventsRecording _events;

        [TestInitialize]
        public void Initialize()
        {
            _libraryState = new LibraryState();
            DataContext _context = new DataContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=D:\\DOCUMENTS\\UNIVERSITY\\PT\\PROJECTS\\GIT2\\PT\\PT\\DATALAYER\\DB\\LIBRARY.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False");
            _dataRepository = new DataRepository(_context);
            _events = new LibraryState();
            _logic = new Logic(_dataRepository, _events);
        }

        [TestMethod]
        public void UpdateBook_BookExists_UpdatesBook()
        {
            // Arrange
            Book book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            Book bookUpdated = new Book("Cats", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.UpdateBook(bookUpdated);

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(bookUpdated, result);
            Assert.AreEqual(bookUpdated.Title, result.Title);
            Assert.AreEqual(bookUpdated.Author, result.Author);
            Assert.AreEqual(bookUpdated.Publisher, result.Publisher);
            Assert.AreEqual(bookUpdated.Category, result.Category);
            Assert.AreEqual(bookUpdated.Available, result.Available);
            _dataRepository.DeleteBook("100");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateBook_BookDoesNotExist_DoesNotUpdateBook_ThrowsException()
        {
            // Arrange
            Book book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            Book bookUpdated = new Book("Cats", "Alice Smith", "10", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.UpdateBook(bookUpdated);

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
            _dataRepository.DeleteBook("100");
        }

        [TestMethod]
        public void BookAcquisition_BookAlreadyExists_ThrowsException()
        {
            // Arrange
            Book book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
            _dataRepository.AddBook(book);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _logic.BookAcquisition(book, "Supplier1", "Emplyee1"));
            _dataRepository.DeleteBook("100");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBook_BookExists_DoesNotAddBook()
        {
            // Arrange
            Book book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            // Act
            _logic.BookAcquisition(book, "Supplier1", "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
            _dataRepository.DeleteBook("100");
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteBook_BookExists_DeletesBook()
        {
            // Arrange
            Book book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            // Act
            _logic.BookDeletion(book.BookId, "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            _dataRepository.DeleteBook("100");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BookDeletion_BookDoesNotExist_DoesNotDeleteBook()
        {
            // Arrange
            Book book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.BookDeletion(book.BookId, "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
            _dataRepository.DeleteBook("100");

        }

    }
}
