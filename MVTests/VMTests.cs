using LogicLayer.API;
using Model.API;
using MVVMTests;
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
            //  string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\documents\\university\\PT\\projects\\git2\\PT\\PT\\DataLayerTests\\TestDB\\Database1.mdf;Integrated Security=True";
            //  IDataContext dataContext = IDataContext.DataContextFactory(connectionString);
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

        [TestMethod]
        public void LoadBooks_Should_SetBooksProperty_WithMockData()
        {
            // Arrange
            var businessLogic = new TestBusinessLogic();
          //  var books = new List<IBook>
        {
          //  new MockBook( 1,"Book 1","Author 1", "Category 1","Publisher 1" ),
          //  new MockBook { Id = 2, Title = "Book 2", Author = "Author 2", Category = "Category 2", Publisher = "Publisher 2" }
        };
          //  businessLogic.AddBook(books[0].Id, books[0].Title, books[0].Author, books[0].Category, books[0].Publisher);
          //  businessLogic.AddBook(books[1].Id, books[1].Title, books[1].Author, books[1].Category, books[1].Publisher);

          //  var viewModel = new BookViewModel(businessLogic);

            // Act
         //   viewModel.LoadBooks();

            // Assert
          //  CollectionAssert.AreEqual(books, viewModel.Books.ToList());
        }

    }

}
