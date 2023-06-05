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
            int id = 1;
            string title = "New Title";
            string author = "John Doe";
            string category = "Fiction";
            string publisher = "ABC Publishers";

            MockContext mockContext = new MockContext();
            mockContext.AddBook(id, "Old Title", "Old Author", "Old Category", "Old Publisher");

            IBusinessLogic businessLogic = IBusinessLogic.BusinessLogicFactory(mockContext);

            businessLogic.updateBook(id, title, author, category, publisher);

            Assert.AreEqual(1, mockContext.Books.Count());
            Assert.AreEqual(id, mockContext.Books.First().Id);
            Assert.AreEqual(title, mockContext.Books.First().Title);
            Assert.AreEqual(author, mockContext.Books.First().Author);
            Assert.AreEqual(category, mockContext.Books.First().Category);
            Assert.AreEqual(publisher, mockContext.Books.First().Publisher);
        }

        [TestMethod]
        public void UpdateBook_Should_ThrowException_WhenBookDoesNotExist()
        {
            int id = 1;
            string title = "New Title";
            string author = "John Doe";
            string category = "Fiction";
            string publisher = "ABC Publishers";

            MockContext mockContext = new MockContext();

            IBusinessLogic businessLogic = IBusinessLogic.BusinessLogicFactory(mockContext);

            Assert.ThrowsException<Exception>(() => businessLogic.updateBook(id, title, author, category, publisher));
        }
    }
}