using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IAddEmployeeModel
    {
        string Name { get; set; }
        string Surname { get; set; }
        string EmployeeId { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Email { get; set; }

        Task AddEmployeeAsync();
    }
}
