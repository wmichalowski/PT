using DataLayer.API;
using System.Data.Linq.Mapping;

namespace DataLayer.Implementation
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

    [Table(Name = "Suppliers")]
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

        [Column(Name = "SupplierId")]
        public string SupplierId { get; set; }
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name = "Address")]
        public string Address { get; set; }
        [Column(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column(Name = "Email")]
        public string Email { get; set; }

    }
}
