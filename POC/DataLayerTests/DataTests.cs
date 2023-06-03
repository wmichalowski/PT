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
            _context = IDataContext.DataContextFactory(("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\university\\PT\\POC\\DataLayerTests\\TestDB\\Database1.mdf;Integrated Security=True"));
        }


        [TestMethod]
        public void AddBook_Should_AddBookToContext()
        {
            // Arrange
                int id = 1;
                string name = "Book 1";

                // Act
                _context.AddBook(id, name);

                // Assert
                Assert.AreEqual(1, _context.Books.Count());
                Assert.AreEqual(id, _context.Books.First().Id);
                Assert.AreEqual(name, _context.Books.First().Title);
        }

        [TestMethod]
        public void RemoveBook_Should_RemoveBookFromContext()
        {

                int id = 1;
                string name = "Book 1";
                _context.AddBook(id, name);

                // Act
                _context.RemoveBook(id);

                // Assert
                Assert.AreEqual(0, _context.Books.Count());
        }

        [TestMethod]
        public void GetBookById_Should_ReturnBookWithMatchingId()
        {

                int id = 1;
                string name = "Book 1";
                _context.AddBook(id, name);

                // Act
                var book = _context.GetBookById(id);

                // Assert
                Assert.IsNotNull(book);
                Assert.AreEqual(id, book.Id);
                Assert.AreEqual(name, book.Title);
        }

        [TestMethod]
        public void GetBookById_Should_ThrowException_WhenBookNotFound()
        {


                int id = 1;

                // Act and Assert
                Assert.ThrowsException<ArgumentException>(() => _context.GetBookById(id));

        }

        [TestMethod]
        public void GetAllBooks_Should_ReturnAllBooksInContext()
        {

                int id1 = 1;
                string name1 = "Book 1";
                _context.AddBook(id1, name1);

                int id2 = 2;
                string name2 = "Book 2";
                _context.AddBook(id2, name2);

                // Act
                var books = _context.GetAllBooks().ToList();

                // Assert
                Assert.AreEqual(2, books.Count);
                Assert.AreEqual(id1, books[0].Id);
                Assert.AreEqual(name1, books[0].Title);
                Assert.AreEqual(id2, books[1].Id);
                Assert.AreEqual(name2, books[1].Title);
        }
}

}