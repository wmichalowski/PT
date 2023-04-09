using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Implementation;

namespace DataLayer.Implementation
{
    internal class LibraryState
    {
        public List<Book> Books { get; set; }
        public List<Person> Suppliers { get; set; }
        public List<Person> Employees { get; set; }
        public List<Person> Readers { get; set; }


        public LibraryState(List<Book> books, List<Person> suppliers, List<Person> employees, List<Person> readers)
        {
            Books = books;
            Suppliers = suppliers;
            Employees = employees;
            Readers = readers;
        }
    }
}
