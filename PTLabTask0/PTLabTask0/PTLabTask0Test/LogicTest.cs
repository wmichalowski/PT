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
        private ILogic _logic;
        private IEventsRecording _events;


        [TestInitialize]
        public void Initialize()
        {
            _logic = new Logic(_dataRepository, _events);
        }

        [TestMethod]
        public void BookAcquisition_BookDoesNotExist_AddsBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.BookAcquisition(book, "Supplier1", "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
            Assert.AreEqual(book, result);
            Assert.AreEqual(book.Title, result.Title);
            Assert.AreEqual(book.Author, result.Author);
            Assert.AreEqual(book.Publisher, result.Publisher);
            Assert.AreEqual(book.Category, result.Category);
            Assert.AreEqual(book.Available, result.Available);
        }

        [TestMethod]
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
        public void UpdateBook_BookDoesNotExist_DoesNotUpdateBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            IBook bookUpdated = new Book("Cats", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            // Act
            _logic.UpdateBook(bookUpdated);

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.AreEqual(book, result);
        }

        [TestMethod]
        public void DeleteBook_BookExists_DeletesBook()
        {
            // Arrange
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            _dataRepository.AddBook(book);

            // Act
            _logic.BookDeletion(book.BookId, "Emplyee1");

            // Assert
            var result = _dataRepository.GetBookById(book.BookId);
            Assert.IsNull(result);
        }

        [TestMethod]
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
