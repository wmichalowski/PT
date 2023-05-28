using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Implementation;
using DataLayer.API;
using Microsoft.EntityFrameworkCore;

namespace PTLabTask0Test
{
    [TestClass]
    public class DatabaseConnectionTester
    {
        public static bool TestConnection(string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    // Handle any exceptions or log the error
                    Console.WriteLine("Error occurred while testing the connection: " + ex.Message);
                    return false;
                }
            }


        }

        [TestMethod]
        public void AddBook()
        {
            string connString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=D:\\DOCUMENTS\\UNIVERSITY\\PT\\PROJECTS\\GIT2\\PT\\PT\\DATALAYER\\DB\\LIBRARY.MDF;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            DbContextOptions<DataContext> options = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(connString)
            .Options;
            DataContext _context = new DataContext(options, connString);
            DataRepository repository = new DataRepository(_context);


            IBook newBook = new Book("Dogs", "Alice Smith", "100", "CoolPublisher", "Encyclopedia", true);
            repository.AddBook(newBook);

            IBook addedBook = repository.GetBookById("100");

            Assert.IsNotNull(addedBook);
            Assert.AreEqual("Dogs", addedBook.Title);
            Assert.AreEqual("Alice Smith", addedBook.Author);
            Assert.AreEqual("CoolPublisher", addedBook.Publisher);
            Assert.AreEqual("Encyclopedia", addedBook.Category);
            Assert.IsTrue(addedBook.Available);

            repository.DeleteBook("100");
        }

    }
}
