using LogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestClass]
    public class MockContextTests
    {
        [TestMethod]
        public void AddBook_Should_AddBookToList()
        {
            MockContext context = new MockContext();
            int id = 1;
            string name = "Book 1";
            string author = "John Doe";
            string category = "Fiction";
            string publisher = "ABC Publishers";

            context.AddBook(id, name, author, category, publisher);

            Assert.AreEqual(1, context.Books.Count());
            Assert.AreEqual(id, context.Books.First().Id);
            Assert.AreEqual(name, context.Books.First().Title);
        }

        [TestMethod]
        public void GetAllBooks_Should_ReturnAllBooks()
        {
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1", "Author 1", "Category 1", "Publisher 1");
            context.AddBook(2, "Book 2", "Author 2", "Category 2", "Publisher 2");
            context.AddBook(3, "Book 3", "Author 3", "Category 3", "Publisher 3");

            var allBooks = context.GetAllBooks();

            Assert.AreEqual(3, allBooks.Count());
            CollectionAssert.AreEquivalent(context.Books.ToList(), allBooks.ToList());
        }

        [TestMethod]
        public void GetBookById_Should_ReturnCorrectBook()
        {
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1", "Author 1", "Category 1", "Publisher 1");
            context.AddBook(2, "Book 2", "Author 2", "Category 2", "Publisher 2");
            context.AddBook(3, "Book 3", "Author 3", "Category 3", "Publisher 3");
            int idToFind = 2;

            var book = context.GetBookById(idToFind);

            Assert.IsNotNull(book);
            Assert.AreEqual(idToFind, book.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetBookById_Should_ThrowException_WhenBookNotFound()
        {
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1", "Author 1", "Category 1", "Publisher 1");
            context.AddBook(2, "Book 2", "Author 2", "Category 2", "Publisher 2");
            int idToFind = 3;

            var book = context.GetBookById(idToFind);

            Assert.IsNull(book);
        }

        [TestMethod]
        public void RemoveBook_Should_RemoveBookFromList()
        {
            MockContext context = new MockContext();
            context.AddBook(1, "Book 1", "Author 1", "Category 1", "Publisher 1");
            context.AddBook(2, "Book 2", "Author 2", "Category 2", "Publisher 2");
            int idToRemove = 1;

            context.RemoveBook(idToRemove);

            Assert.AreEqual(1, context.Books.Count());
            Assert.IsFalse(context.Books.Any(b => b.Id == idToRemove));
        }
    }
}
