using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class Supplier:ISupplier
    {
        public Supplier(int supplierId, string name, string address, string phoneNumber, string email)
        {
            SupplierId = supplierId;
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
