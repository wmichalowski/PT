using DataLayer.API;
using LogicLayer.API;

namespace LogicLayerTests
{
    [TestClass]
    public class BusinessLogicTests
    {
        [TestMethod]
        public void UpdateBook_Should_UpdateBook_WhenBookExists()
        {
            // Arrange
            int id = 1;
            string title = "New Title";

            // Create an instance of the MockContext
            MockContext mockContext = new MockContext();

            // Add a book to the context
            mockContext.AddBook(id, "Old Title");

            // Create an instance of the BusinessLogic class with the mock context
            IBusinessLogic businessLogic = IBusinessLogic.BusinessLogicFactory(mockContext);

            // Act
            businessLogic.updateBook(id, title);

            // Assert
            Assert.AreEqual(1, mockContext.Books.Count());
            Assert.AreEqual(id, mockContext.Books.First().Id);
            Assert.AreEqual(title, mockContext.Books.First().Title);
        }

        [TestMethod]
        public void UpdateBook_Should_ThrowException_WhenBookDoesNotExist()
        {
            // Arrange
            int id = 1;
            string title = "New Title";

            // Create an empty instance of the MockContext
            MockContext mockContext = new MockContext();

            // Create an instance of the BusinessLogic class with the empty mock context
            IBusinessLogic businessLogic = IBusinessLogic.BusinessLogicFactory(mockContext);

            // Act and Assert
            Assert.ThrowsException<Exception>(() => businessLogic.updateBook(id, title));
        }
    }
}