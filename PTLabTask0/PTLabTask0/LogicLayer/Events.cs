using DataLayer;
using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{

    public class BookRent: IRent_Return
    {
        public string ReaderId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookRent(string readerId, string bookId, string employeeId, DateTime timestamp)
        {
            ReaderId = readerId;
            BookId = bookId;
            EmployeeId = employeeId;
            Timestamp = timestamp;
        }
    }

    public class BookReturn: IRent_Return
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

    public class BookAcquisition: IBookAcquisition
    {
        public string SupplierId { get; set; }
        public string BookId { get; set; }
        public IBook Book { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookAcquisition(string supplierId, string bookId, IBook book, string employeeId, DateTime timestamp)
        {
            SupplierId = supplierId;
            BookId = bookId;
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
