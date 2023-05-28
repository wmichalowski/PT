using DataLayer.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class Rent_Return : IRent_Return
    {
        [Key]
        public int RentReturnId { get; set; }
        public string ReaderId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Intent { get; set; }

        public Rent_Return(int rentReturnId, string readerId, string bookId, string employeeId, string intent, DateTime timestamp)
        {
            RentReturnId = rentReturnId;
            ReaderId = readerId;
            BookId = bookId;
            EmployeeId = employeeId;
            Intent = intent;
            Timestamp = timestamp;
        }
    }

    public class BookAcquisition : IBookAcquisition
    {   
        public int BookAcquisitionId { get; set; }
        public string SupplierId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookAcquisition(int bookAcquisitionId, string supplierId, string bookId, string employeeId, DateTime timestamp)
        {
            BookAcquisitionId = bookAcquisitionId;
            SupplierId = supplierId;
            BookId = bookId;
            EmployeeId = employeeId;
            Timestamp = timestamp;

        }
    }

    public class BookDeletion: IBookDeletion
    {
        public int BookDeletionId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        public BookDeletion(int bookDeletionId, string bookId, string employeeId, DateTime timestamp)
        {
            BookDeletionId = bookDeletionId;
            BookId = bookId;
            EmployeeId = employeeId;
            Timestamp = timestamp;
        }
    }
}
