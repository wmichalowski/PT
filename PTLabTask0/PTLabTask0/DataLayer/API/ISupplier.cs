using System;
namespace DataLayer.API
{
	public interface ISupplier : IUsers
	{
        public string SupplierId { get; set; }
    }
}

