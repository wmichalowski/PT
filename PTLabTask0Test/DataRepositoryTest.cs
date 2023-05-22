using DataLayer.API;
using DataLayer.Implementation;
using System.Net;

namespace DataLayer.Tests
{ 
[TestClass]
public class DataRepositoryTests
{
    private IDataRepository _dataRepository;
    public ILibraryState _libraryState;
    DataContext _context = new DataContext("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=D:\\DOCUMENTS\\UNIVERSITY\\PT\\PROJECTS\\GIT2\\PT\\PT\\DATALAYER\\DB\\LIBRARY.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False");

        [TestInitialize]
    public void Initialize()
    {
        _libraryState = new LibraryState();
       
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
        Book newBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.AddBook(newBook);

            // Assert
            Assert.IsNotNull(_dataRepository.GetBookById("100"));

            _dataRepository.DeleteBook("100");
        }

    [TestMethod]
    public void UpdateBook_ShouldUpdateExistingBook()
    {
        // Arrange
        Book existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
         _dataRepository.AddBook(existingBook);

        Book updatedBook = new Book("Cats", "Alice", "100", "BigPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.UpdateBook(updatedBook);

        existingBook = _dataRepository.GetBookById("100");

        // Assert
        Assert.AreEqual(existingBook.Author, updatedBook.Author);
        Assert.AreEqual(existingBook.Title, updatedBook.Title);
        Assert.AreEqual(existingBook.Category, updatedBook.Category);
        Assert.AreEqual(existingBook.Publisher, updatedBook.Publisher);
            _dataRepository.DeleteBook("100");
        }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void UpdateBook_ShouldThrowArgumentException_WhenBookNotFound()
    {
        // Arrange
        Book notExistingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.UpdateBook(notExistingBook);
    }

    [TestMethod]
    public void DeleteBook_ShouldRemoveBookFromLibraryState()
    {
        // Arrange
        Book existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
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
        Book existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
        _dataRepository.AddBook(existingBook);

            // Act
            Book retrievedBook = _dataRepository.GetBookById("100");

        // Assert
        Assert.AreEqual(existingBook, retrievedBook);

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