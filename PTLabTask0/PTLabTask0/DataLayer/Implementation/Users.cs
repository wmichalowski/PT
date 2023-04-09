using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public abstract class User
    {
        public virtual string Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        protected User(string id, string name, string address, string phoneNumber, string email)
        {
            Id = id;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    public class Person : User 
    {
        public override string Id { get; set; }
        public string Surname { get; set; }

        public Person(string id, string name, string address, string phoneNumber, string email, string surname) 
            : base(id, name, address, phoneNumber, email)
        {
            Surname = surname;
            Id = id;
        }
    }

    public class Supplier: User
    {
        public Supplier(string id, string name, string address, string phoneNumber, string email) 
            : base(id, name, address, phoneNumber, email)
        {
            Id = id;
        }

        public override string Id { get; set; }

    }
}
