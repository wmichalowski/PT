using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{

    public class BookCheckout
    {
        public string ReaderId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookCheckout(string readerId, string bookId, string employeeId, DateTime timestamp)
        {
            ReaderId = readerId;
            BookId = bookId;
            EmployeeId = employeeId;
            Timestamp = timestamp;
        }
    }

    public class BookReturn
    {
        public string ReaderId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookReturn(string readerId, string bookId, string employeeId, DateTime timestamp)
        {
            ReaderId = readerId;
            BookId = bookId;
            EmployeeId = employeeId;
            Timestamp = timestamp;
        }
    }

    public class BookAcquisition
    {
        public string SupplierId { get; set; }
        public Book Book { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookAcquisition(string supplierId, Book book, string employeeId, DateTime timestamp)
        {
            SupplierId = supplierId;
            Book = book;
            EmployeeId = employeeId;
            Timestamp = timestamp;
        }
    }

    internal class BookDeletion
    {
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookDeletion(string bookId, string employeeId, DateTime timestamp)
        {
            BookId = bookId;
            EmployeeId = employeeId;
            Timestamp = timestamp;
        }
    }
}
