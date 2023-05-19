using System;
namespace Services.API
{
	public interface IEvent
	{
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }

        Task AddAsync();
    }

    public interface IRent_Return : IEvent
    {
        public string ReaderId { get; set; }
    }

    public interface IBookAcquisition : IEvent
    {
        public string SupplierId { get; set; }
        public IBook Book { get; set; }

    }

    public interface IBookDeletion : IEvent { }

    public interface IEventsRecording
    {
        void RecordBookAcquisition(IBook book, string supplierId, string employeeId, DateTime timestamp);
        void RecordBookDeletion(string bookId, string employeeId, DateTime timestamp);
        void RecordBookCheckout(string bookId, string readerId, string employeeId, DateTime timestamp);
        void RecordBookReturn(string bookId, string readerId, string employeeId, DateTime timestamp);
    }
}

