using PresentationLayer.Model.API;

namespace PresentationLayer.Model.Implementation
{

    public class Employee: IEmployee
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string EmployeeId { get; set; }


        public Employee(string employeeId, string name, string address, string phoneNumber, string email, string surname) 
        {
            EmployeeId = employeeId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Surname = surname;
        }
    }

    public class Reader : IReader
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string ReaderId { get; set; }


        public Reader(string readerId, string name, string address, string phoneNumber, string email, string surname)
        {
            ReaderId = readerId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Surname = surname;
        }
    }

    public class Supplier: ISupplier
    {
        public Supplier(string supplierId, string name, string address, string phoneNumber, string email) 
        {
            SupplierId = supplierId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public string SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

    }
}
