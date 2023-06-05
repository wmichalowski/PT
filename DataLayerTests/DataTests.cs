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
            Assert.AreEqual(1, _context.Books.Count());
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
            Assert.AreEqual(0, _context.Books.Count());
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
            Assert.AreEqual(2, books.Count());
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
    }

}