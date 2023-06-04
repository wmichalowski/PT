using LogicLayer.API;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementation
{
    public class EmployeeModel : IEmployeeModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string EmployeeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        private List<IEmployeeModel> employeeList;

        public EmployeeModel()
        {
            employeeList = new List<IEmployeeModel>();
        }

        public void AddEmployee(string name, string surname, string employeeId, string phoneNumber, string address, string email)
        {
            employeeList.Add(new EmployeeModel
            {
                Name = name,
                Surname = surname,
                EmployeeId = employeeId,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email
            });
        }

        public void RemoveEmployee(string employeeId)
        {
            var employeeToRemove = employeeList.Find(employee => employee.EmployeeId == employeeId);
            if (employeeToRemove != null)
                employeeList.Remove(employeeToRemove);
        }

        public IEnumerable<IEmployeeModel> GetAllEmployees()
        {
            return employeeList;
        }
    }
}
