using DataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Linq.DataContext;

namespace DataLayer.API
{
    public interface IDataContext
    {
        public Table<Book> Books { get; }
        public Table<Person> Readers { get; }
        public Table<Person> Employees { get; }
        public Table<Supplier> Suppliers { get; }

    }
}
