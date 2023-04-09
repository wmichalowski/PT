using System;
namespace DataLayer.API
{
	public interface IRent_Return : IEvent
	{
        public string PersonId { get; set; }
    }
}

