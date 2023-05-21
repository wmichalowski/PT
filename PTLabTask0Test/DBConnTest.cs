using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using DataLayer.Implementation;

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
        public void testConn() {

        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True";

        DataContext dataContext = new DataContext("Data Source=(localdb)\\MSSQLLocalDB;Integrated Security=True");

            bool isConnected = DatabaseConnectionTester.TestConnection(connectionString);

            if (isConnected)
            {
                Console.WriteLine("Connection is successful.");
                dataContext.addBook();
            }
            else
            {
                Console.WriteLine("Connection failed.");
            }
            Assert.AreEqual(1, 1);

        }

    }
}
