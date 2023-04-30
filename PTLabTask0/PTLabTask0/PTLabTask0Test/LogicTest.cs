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

        [TestMethod]
        public void UpdateBook_BookExists_UpdatesBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            IBook bookUpdated = new Book("Cats", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

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
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void UpdateBook_BookDoesNotExist_DoesNotUpdateBook_ThrowsException()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            IBook bookUpdated = new Book("Cats", "Alice Smith", "10", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.UpdateBook(bookUpdated);

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
        }

        [TestInitialize]
        public void Initialize()
        {
            _libraryState = new LibraryState(); 
            _dataRepository = new DataRepository(_libraryState);
            _events = new LibraryState();
            _logic = new Logic(_dataRepository, _events);
        }

        [TestMethod]
        public void BookAcquisition_BookAlreadyExists_ThrowsException()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
            _dataRepository.AddBook(book);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => _logic.BookAcquisition(book, "Supplier1", "Emplyee1"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddBook_BookExists_DoesNotAddBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            // Act
            _logic.BookAcquisition(book, "Supplier1", "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DeleteBook_BookExists_DeletesBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            // Act
            _logic.BookDeletion(book.BookId, "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void BookDeletion_BookDoesNotExist_DoesNotDeleteBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.BookDeletion(book.BookId, "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);

        }

    }
}
