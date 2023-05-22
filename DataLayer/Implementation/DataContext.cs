using Castle.DynamicProxy;
using DataLayer.API;
using System.Data.Linq;

namespace DataLayer.Implementation
{
    public class DataContext : System.Data.Linq.DataContext, IDataContext
    {

        public Table<Book> Books { get; private set; }
        public Table<Person> Readers { get; private set; }
        public Table<Person> Employees { get; private set; }
        public Table<Supplier> Suppliers { get; private set; } 

        public DataContext(string connectionString) : base(connectionString)
        {
            Books = GetTable<Book>();
            Readers = GetTable<Person>();
            Employees = GetTable<Person>();
            Suppliers = GetTable<Supplier>();
        }

    }

}
