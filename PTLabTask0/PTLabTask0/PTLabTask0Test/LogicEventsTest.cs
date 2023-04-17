using System;
using LogicLayer.Implementation;
using DataLayer.API;
using DataLayer.Implementation;

namespace LogicLayer.Tests
{
    [TestClass]
    public class BookRentTests
    {
        [TestMethod]
        public void BookRent_Constructor_InitializesProperties()
        {
            // Arrange
            string readerId = "Reader1";
            string bookId = "100"; 
            string employeeId = "Employee1";
            DateTime timestamp = DateTime.Now;
            IBook newBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            Assert.IsTrue(newBook.Available);

            // Act
            BookRent bookRent = new BookRent(readerId, bookId, employeeId, timestamp);

            // Assert
            Assert.IsTrue(newBook.Available);
            Assert.AreEqual(readerId, bookRent.ReaderId);
            Assert.AreEqual(bookId, bookRent.BookId);
            Assert.AreEqual(employeeId, bookRent.EmployeeId);
            Assert.AreEqual(timestamp, bookRent.Timestamp);
        }
    }

    [TestClass]
    public class BookReturnTests
    {
        [TestMethod]
        public void TestBookReturn()
        {
            // Arrange
            string readerId = "reader1";
            string bookId = "book1";
            string employeeId = "employee1";
            DateTime timestamp = new DateTime(2023, 4, 15);
            IBook book = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);

            Assert.IsTrue(book.Available);


            // Act
            BookReturn bookReturn = new BookReturn(readerId, bookId, employeeId, timestamp);

            // Assert
            Assert.IsTrue(book.Available);

            Assert.AreEqual("reader1", bookReturn.ReaderId);
            Assert.AreEqual("book1", bookReturn.BookId);
            Assert.AreEqual("employee1", bookReturn.EmployeeId);
            Assert.AreEqual(new DateTime(2023, 4, 15), bookReturn.Timestamp);
        }
    }

    [TestClass]
    public class BookAcquisitionTests
    {
        [TestMethod]
        public void TestBookAcquisition()
        {
            // Arrange
            string supplierId = "Supplier1";
            string bookId = "100";
            IBook newBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
            string employeeId = "Employee1";
            DateTime timestamp = new DateTime(2023, 4, 15);

            // Act
            BookAcquisition bookAcquisition = new BookAcquisition(supplierId, bookId, newBook, employeeId, timestamp);

            // Assert
            Assert.AreEqual("Supplier1", bookAcquisition.SupplierId);
            Assert.AreEqual("100", bookAcquisition.BookId);
            Assert.AreEqual("Employee1", bookAcquisition.EmployeeId);
            Assert.AreEqual(new DateTime(2023, 4, 15), bookAcquisition.Timestamp);
            Assert.AreEqual("Dogs", bookAcquisition.Book.Title);
        }
    }
}

        
    
