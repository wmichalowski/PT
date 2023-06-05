using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IReader
    {
        int ReaderId { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        string Address { get; set; }
        string PhoneNumber { get; set; }
        string Email { get; set; }

    }
}
