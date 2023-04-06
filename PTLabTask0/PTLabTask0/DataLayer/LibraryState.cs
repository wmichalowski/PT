using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    internal class LibraryState
    {
        public List<Book> Books { get; set; }
        public List<Supplier> Suppliers { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Reader> Readers { get; set; }

        public LibraryState(List<Book> books, List<Supplier> suppliers, List<Employee> employees, List<Reader> readers)
        {
            Books = books;
            Suppliers = suppliers;
            Employees = employees;
            Readers = readers;
        }
    }
}
