using DataLayer.API;
using DataLayer.Implementation;

namespace DataLayer.Tests
{ 
[TestClass]
public class DataRepositoryTests
{
    private IDataRepository _dataRepository;
    private ILibraryState _libraryState;

    [TestInitialize]
    public void Initialize()
    {
        _libraryState = new LibraryState();
        _dataRepository = new DataRepository(_libraryState);
    }

    [TestMethod]
    public void AddBook_ShouldAddBookToLibraryState()
    {
        // Arrange
        IBook newBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.AddBook(newBook);

        // Assert
        Assert.IsTrue(_libraryState.Books.Contains(newBook));
    }

    [TestMethod]
    public void UpdateBook_ShouldUpdateExistingBook()
    {
        // Arrange
        IBook existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
        _libraryState.Books.Add(existingBook);

        IBook updatedBook = new Book("Cats", "Alice", "100", "BigPublisher", "Encyclopedia", true);

        // Act
        _dataRepository.UpdateBook(updatedBook);

        // Assert
        Assert.AreEqual(existingBook.Author, updatedBook.Author);
        Assert.AreEqual(existingBook.Title, updatedBook.Title);
        Assert.AreEqual(existingBook.Category, updatedBook.Category);
        Assert.AreEqual(existingBook.Publisher, updatedBook.Publisher);
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
        _libraryState.Books.Add(existingBook);

        // Act
        _dataRepository.DeleteBook("100");

        // Assert
        Assert.IsFalse(_libraryState.Books.Contains(existingBook));
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void DeleteBook_ShouldThrowArgumentException_WhenBookNotFound()
    {
        // Act
        _dataRepository.DeleteBook("100");
    }

    [TestMethod]
    public void GetBookById_ShouldReturnCorrectBook()
    {
        // Arrange
        IBook existingBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
        _libraryState.Books.Add(existingBook);

        // Act
        IBook retrievedBook = _dataRepository.GetBookById("100");

        // Assert
        Assert.AreEqual(existingBook, retrievedBook);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public void GetBookById_ShouldThrowArgumentException_WhenBookNotFound()
    {
        // Act
        _dataRepository.GetBookById("100");
    }
}

}