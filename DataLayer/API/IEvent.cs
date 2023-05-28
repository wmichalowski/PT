using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.API
{
    public interface IRent_Return
    {
        public int RentReturnId { get; set; }
        public string ReaderId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public string Intent { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public interface IBookAcquisition
    {
        public int BookAcquisitionId { get; set; }
        public string SupplierId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

    }

    public interface IBookDeletion{
        public int BookDeletionId { get; set; }
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public interface IEventsRecording
    {
        void RecordBookAcquisition(IBook book, string supplierId, string employeeId, DateTime timestamp);
        void RecordBookDeletion(string bookId, string employeeId, DateTime timestamp);
        void RecordBookCheckout(string bookId, string readerId, string employeeId, DateTime timestamp);
        void RecordBookReturn(string bookId, string readerId, string employeeId, DateTime timestamp);
    }
}

