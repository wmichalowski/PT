using Castle.DynamicProxy;
using DataLayer.API;
using System.Data.Linq;

namespace DataLayer.Implementation
{
    internal class DataContext : System.Data.Linq.DataContext, IDataContext
    {

        public DataContext(string connectionString) : base(connectionString)
        {
            // Initialize the table properties with the corresponding database tables
            Books = GetTable<Book>();
            // Initialize more table properties as needed
        }

       // public IQueryable<IUsers> Users => throw new NotImplementedException();

        public Table<Book> Books { get; private set; }

       // public IQueryable<IEvent> Events => throw new NotImplementedException();

        public void addBook() {
            var newBook = new Book("Sample Book", "John Doe", "Bok12",  "ABC Publisher", "Fiction", true);

            // Add the new book to the Books table
            this.Books.InsertOnSubmit(newBook);

            try
            {
                // Persist the changes to the database
                this.SubmitChanges();

                Console.WriteLine("New book added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occurred while adding the book: " + ex.Message);
            }
        }
    }

}
