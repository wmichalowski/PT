using Model.API;
using Model.Implementation;

namespace MVTests
{
        [TestClass]
        public class BookModelTests
        {
            private IBookModel bookModel;

            [TestInitialize]
            public void Setup()
            {
                bookModel = new BookModel("1", "Test Book");
            }

            [TestMethod]
            public void AddBook_ValidInput_AddsBook()
            {
                // Arrange
                int id = 1;
                string name = "New Book";

                // Act
                bookModel.AddBook(id, name);

            }

            [TestMethod]
            public void RemoveBook_ExistingBook_RemovesBook()
            {
                // Arrange
                int id = 1;

                // Act
               // bookModel.RemoveBook(id);

                // Assert
                // Add your assertions here to verify that the book was removed successfully
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentException))]
            public void RemoveBook_NonExistingBook_ThrowsException()
            {
                // Arrange
                int id = 2;

                // Act
                bookModel.RemoveBook(id);

                // Assert
                // This test is expecting an ArgumentException to be thrown
            }
        }

}