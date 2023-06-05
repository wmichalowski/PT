using LogicLayer.API;
using Model.API;
using System.Data.Linq;
using ViewModel;

namespace MVTests
{
    [TestClass]
    public class BookModelTests
    {
        [TestMethod]
        public void PrintBookDetails_Should_PrintBookFromDatabase()
        {
            // Arrange
          
            IBookModel bookModel = IBookModel.BookModelFactory();

            // Act
            var books = bookModel.GetAllBooks();

            // Assert
            Assert.IsTrue(books.Any());

            // Print book details
            foreach (var book in books)
            {
                Console.WriteLine($"Book Id: {book.BookId}");
                Console.WriteLine($"Title: {book.Title}");
                Console.WriteLine($"Author: {book.Author}");
                Console.WriteLine($"Category: {book.Category}");
                Console.WriteLine($"Publisher: {book.Publisher}");
                Console.WriteLine();
            }
        }

        [TestMethod]
        public void AssemblyInfo() {
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Console.WriteLine(assemblyName);
        }

    }

}
