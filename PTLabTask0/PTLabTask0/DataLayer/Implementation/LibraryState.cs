using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;
using DataLayer.Implementation;

namespace DataLayer.Implementation
{
    public class LibraryState: ILibraryState, IEventsRecording
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IPerson> Employees { get; set; }
        public List<IPerson> Readers { get; set; }
        public List<IEvent> Events { get; set; }

        public LibraryState()
        {
            Books = new List<IBook>();
            Suppliers = new List<ISupplier>();
            Employees = new List<IPerson>();
            Readers = new List<IPerson>();
            Events = new List<IEvent>();
        }

        public void RecordBookAcquisition(IBook book, string supplierId, string employeeId, DateTime timestamp)
        {
            Events.Add(new BookAcquisition(book.BookId, supplierId, employeeId, timestamp));
        }

        public void RecordBookDeletion(string bookId, string employeeId, DateTime timestamp)
        {
            Events.Add(new BookDeletionEvent(bookId, employeeId, timestamp));
        }

        public void RecordBookCheckout(string bookId, string readerId, string employeeId, DateTime timestamp)
        {
            Events.Add(new BookCheckoutEvent(bookId, readerId, employeeId, timestamp));
        }

        public void RecordBookReturn(string bookId, string readerId, string employeeId, DateTime timestamp)
        {
            Events.Add(new BookReturnEvent(bookId, readerId, employeeId, timestamp));
        }

    }
}
