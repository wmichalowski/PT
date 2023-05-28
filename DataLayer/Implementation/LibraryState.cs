using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class LibraryState: ILibraryState, IEventsRecording
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IEmployee> Employees { get; set; }
        public List<IReader> Readers { get; set; }

        public LibraryState()
        {
            Books = new List<IBook>();
            Suppliers = new List<ISupplier>();
            Employees = new List<IEmployee>();
            Readers = new List<IReader>();
        }

        public void RecordBookAcquisition(IBook book, string supplierId, string employeeId, DateTime timestamp)
        {
           // Events.Add(new BookAcquisition(supplierId, book.BookId, book, employeeId, timestamp));
        }

        public void RecordBookDeletion(string bookId, string employeeId, DateTime timestamp)
        {
          //  Events.Add(new BookDeletion(bookId, employeeId, timestamp));
        }

        public void RecordBookCheckout(string bookId, string readerId, string employeeId, DateTime timestamp)
        {
          //  Events.Add(new BookRent(bookId, readerId, employeeId, timestamp));
        }

        public void RecordBookReturn(string bookId, string readerId, string employeeId, DateTime timestamp)
        {
         //   Events.Add(new BookReturn(bookId, readerId, employeeId, timestamp));
        }

    }
}
