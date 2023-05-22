using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace DataLayer.Implementation
{
    [Table(Name = "Employees")]
    public class Person: IPerson
    {
        [Column(Name = "Name")]
        public string Name { get; set; }
        [Column(Name = "Surname")]
        public string Surname { get; set; }
        [Column(Name = "Address")]
        public string Address { get; set; }
        [Column(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column(Name = "Email")]
        public string Email { get; set; }
        [Column(Name = "EmployeeId")]
        public string PersonId { get; set; }


        public Person(string personId, string name, string address, string phoneNumber, string email, string surname) 
        {
            PersonId = personId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
            Surname = surname;
        }
    }

    [Table(Name = "Employees")]
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
