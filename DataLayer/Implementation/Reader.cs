using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class Reader: IReader
    {
        public Reader(int readerId, string name, string surname, string address, string phoneNumber, string email)
        {
            ReaderId = readerId;
            Name = name;
            Surname = surname;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public int ReaderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
