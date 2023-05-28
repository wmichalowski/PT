using DataLayer.API;
using DataLayer.Implementation;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net;

namespace DataLayer.Tests
{ 
[TestClass]
public class DataRepositoryTests
{
    private IDataRepository _dataRepository;
    public ILibraryState _libraryState;
    string connString; 
    DbContextOptions<DataContext> options;
    DataContext _context;

        [TestInitialize]
    public void Initialize()
    {
        _libraryState = new LibraryState();
        connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=D:\\DOCUMENTS\\UNIVERSITY\\PT\\PROJECTS\\GIT2\\PT\\PT\\DATALAYER\\DB\\LIBRARY.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        options = new DbContextOptionsBuilder<DataContext>()
        .UseSqlServer(connString)
        .Options;
        _context = new DataContext(options, connString);
        _dataRepository = new DataRepository(_context);
        }

     [TestCleanup()]
        public void Cleanup()
        {

            if (_context.Books.Any(b => b.BookId == "100") == true)
            {
                _dataRepository.DeleteBook("100");
            }
           
        }

    [TestMethod]
    public void AddBook_ShouldAddBookToLibraryState()
    {
        // Arrange
        IBook newBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
        IBook newBook2 = new Book("Gods", "Alce Smeth", "101", "PoolCublisher", "Encyclopenia", true);

            // Act
            _dataRepository.AddBook(newBook);
            _dataRepository.AddBook(newBook2);

            // Assert
            Assert.IsNotNull(_dataRepository.GetBookById("100"));

            _dataRepository.DeleteBook("100");
        }

    [TestMethod]
    public void UpdateBook_ShouldUpdateExistingBook()
    {
        // Arrange
        IBook existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
         _dataRepository.AddBook(existingBook);

        IBook updatedBook = new Book("Cats", "Alice", "100", "BigPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.UpdateBook(updatedBook);

        IBook bookFromDb = _dataRepository.GetBookById("100");

        // Assert
        Assert.AreEqual(bookFromDb.Author, updatedBook.Author);
        Assert.AreEqual(bookFromDb.Title, updatedBook.Title);
        Assert.AreEqual(bookFromDb.Category, updatedBook.Category);
        Assert.AreEqual(bookFromDb.Publisher, updatedBook.Publisher);
            _dataRepository.DeleteBook("100");
        }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateBook_ShouldThrowArgumentException_WhenBookNotFound()
    {
        // Arrange
        IBook notExistingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.UpdateBook(notExistingBook);
    }

    [TestMethod]
    public void DeleteBook_ShouldRemoveBookFromLibraryState()
    {
        // Arrange
        IBook existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
            _dataRepository.AddBook(existingBook);

        // Act
        _dataRepository.DeleteBook("100");

            // Assert
        Assert.IsFalse(_context.Books.Any(b => b.BookId == "100"));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DeleteBook_ShouldThrowArgumentException_WhenBookNotFound()
    {
        // Act
        _dataRepository.DeleteBook("12310");
    }

    [TestMethod]
    public void GetBookById_ShouldReturnCorrectBook()
    {
        // Arrange
        IBook existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
        _dataRepository.AddBook(existingBook);

            // Act
            IBook retrievedBook = _dataRepository.GetBookById("100");

            Console.WriteLine(retrievedBook.BookId);
            Console.WriteLine(retrievedBook.Category);
            Console.WriteLine(retrievedBook.Author);

            Console.WriteLine(existingBook.BookId);
            Console.WriteLine(existingBook.Category);
            Console.WriteLine(existingBook.Author);


            // Assert
            Assert.IsTrue(existingBook.Equals(retrievedBook));

            _dataRepository.DeleteBook("100");
        }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetBookById_ShouldThrowArgumentException_WhenBookNotFound()
    {
        // Act
        _dataRepository.GetBookById("1090600");
    }
}

}