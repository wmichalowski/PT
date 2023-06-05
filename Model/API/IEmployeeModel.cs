using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Model.API
{
    public interface IEmployeeModel
    {
        string Name { get; set; }
        string Surname { get; set; }
        int EmployeeId { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Email { get; set; }

        void AddEmployee(string name, string surname, int employeeId, string phoneNumber, string address, string email);
        void RemoveEmployee(int employeeId);
        IEnumerable<IEmployeeModel> GetAllEmployees();
    }
}
