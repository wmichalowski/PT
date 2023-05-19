using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal abstract class User: IUsers
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

    internal class Person : User, IPerson
    {
        public IPerson.PersonIdType PersonId { get; set; }
        public string Surname { get; set; }
        public IPerson.RoleType Role { get; set; }

        public Person(IPerson.PersonIdType personId, string name, string address, string phoneNumber, string email, string surname, IPerson.RoleType role) 
            : base(name, address, phoneNumber, email)
        {
            Surname = surname;
            PersonId = personId;
            Role = role;
        }
    }

    internal class Supplier: User, ISupplier
    {
        public Supplier(string supplierId, string name, string address, string phoneNumber, string email) 
            : base(name, address, phoneNumber, email)
        {
            SupplierId = supplierId;
        }

        public string SupplierId { get; set; }

    }
}
