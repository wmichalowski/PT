using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;
using DataLayer.Implementation;

namespace DataLayer.Implementation
{
    internal class LibraryState: ILibraryState
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IPerson> Employees { get; set; }
        public List<IPerson> Readers { get; set; }

        public LibraryState(List<IBook> books, List<ISupplier> suppliers, List<IPerson> employees, List<IPerson> readers)
        {
            Books = books;
            Suppliers = suppliers;
            Employees = employees;
            Readers = readers;
        }
    }
}
