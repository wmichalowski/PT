using System;
using System.Data.Linq.Mapping;

namespace DataLayer.API {

    public interface IPerson
    {
        string PersonId { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }

    }

    public interface ISupplier
    {
        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}