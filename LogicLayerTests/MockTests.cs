using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestFixture]
    public class MockContextTests
    {
        [Test]
        public void AddBook_Should_AddBookToList()
        {
            // Arrange
            MockContext context = new MockContext();
            int id = 1;
            string name = "Book 1";

            // Act
            context.AddBook(id, name);

            // Assert
            Assert.AreEqual(1, context.Books.Count());
            Assert.AreEqual(id, context.Books.First().Id);
            Assert.AreEqual(name, context.Books.First().Name);
        }

        [Test]
        public void GetAllBooks_Should_ReturnAllBooks()
        {
            // Arrange
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1");
            context.AddBook(2, "Book 2");
            context.AddBook(3, "Book 3");

            // Act
            var allBooks = context.GetAllBooks();

            // Assert
            Assert.AreEqual(3, allBooks.Count());
            CollectionAssert.AreEquivalent(context.Books.ToList(), allBooks.ToList());
        }

        [Test]
        public void GetBookById_Should_ReturnCorrectBook()
        {
            // Arrange
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1");
            context.AddBook(2, "Book 2");
            context.AddBook(3, "Book 3");
            int idToFind = 2;

            // Act
            var book = context.GetBookById(idToFind);

            // Assert
            Assert.IsNotNull(book);
            Assert.AreEqual(idToFind, book.Id);
        }

        [Test]
        public void GetBookById_Should_ReturnNull_WhenBookNotFound()
        {
            // Arrange
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1");
            context.AddBook(2, "Book 2");
            int idToFind = 3;

            // Act
            var book = context.GetBookById(idToFind);

            // Assert
            Assert.IsNull(book);
        }

        [Test]
        public void RemoveBook_Should_RemoveBookFromList()
        {
            // Arrange
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1");
            context.AddBook(2, "Book 2");
            int idToRemove = 1;

            // Act
            context.RemoveBook(idToRemove);

            // Assert
            Assert.AreEqual(1, context.Books.Count());
            Assert.IsFalse(context.Books.Any(b => b.Id == idToRemove));
        }
    }
}
