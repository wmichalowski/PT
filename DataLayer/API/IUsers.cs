using System;
namespace DataLayer.API {

    public interface IUsers
    {
        string Name { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }

    }

    public interface IPerson : IUsers
    {
        PersonIdType PersonId { get; set; }
        string Surname { get; set; }
        RoleType Role { get; set; }

        public enum PersonIdType
        {
            ReaderId,
            EmployeeId
        }

        public enum RoleType
        {
            Reader,
            Employee
        }

    }

    public interface ISupplier : IUsers
    {
        public string SupplierId { get; set; }
    }
}