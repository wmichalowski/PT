using System;
namespace DataLayer.API
{
	public interface IBookAcquisition : IEvent
	{
        public string SupplierId { get; set; }

    }
}

