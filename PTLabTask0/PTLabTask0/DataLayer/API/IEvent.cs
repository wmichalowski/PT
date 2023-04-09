using System;
namespace DataLayer.API
{
	public interface IEvent
	{
        public string BookId { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

