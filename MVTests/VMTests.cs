using DataLayer.API;
using LogicLayer.API;
using Model.API;
using Model.Implementation;
using System.Data.Linq;

namespace MVTests
{
    [TestClass]
    public class BookModelTests
    {
        [TestMethod]
        public void PrintBookDetails_Should_PrintBookFromDatabase()
        {
            // Arrange
          //  string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\university\\PT\\projects\\git2\\PT\\PT\\DataLayerTests\\TestDB\\Database1.mdf;Integrated Security=True";
          //  IDataContext dataContext = IDataContext.DataContextFactory(connectionString);
            IBookModel bookModel = new BookModel();

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
