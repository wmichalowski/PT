using LogicLayer.API;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementation
{
    public class AddEmployeeModel : IAddEmployeeModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmployeeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public async Task AddEmployeeAsync()
        {   
        }
    }
}
