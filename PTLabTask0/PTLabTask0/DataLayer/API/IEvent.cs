using System;
namespace DataLayer.API
{
	public interface IEvent
	{
        public string BookId { get; set; }
        public string EmployeeId { get; set; }
        public DateTime Timestamp { get; set; }
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
}

