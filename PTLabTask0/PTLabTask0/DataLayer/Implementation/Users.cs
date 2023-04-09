using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public abstract class User
    {
        
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        protected User(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Person : User 
    {
        public string PersonId { get; set; }
        public string Surname { get; set; }
        public string Role { get; set; }

        public Person(string personId, string name, string address, string phoneNumber, string email, string surname, string role) 
            : base(name, address, phoneNumber, email)
        {
            Surname = surname;
            PersonId = personId;
            Role = role;
        }
    }

    public class Supplier: User
    {
        public Supplier(string supplierId, string name, string address, string phoneNumber, string email) 
            : base(name, address, phoneNumber, email)
        {
            SupplierId = supplierId;
        }

        public string SupplierId { get; set; }

    }
}
