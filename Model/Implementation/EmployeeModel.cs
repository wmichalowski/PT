using LogicLayer.API;
using Model.API;

namespace Model.Implementation
{
    public class EmployeeModel : IEmployeeModel { 

    private readonly IBusinessLogic _businessLogic;

    public EmployeeModel()
    {
        _businessLogic = IBusinessLogic.BusinessLogicFactory();
    }

    public EmployeeModel(IBusinessLogic bl)
    {
        _businessLogic = bl;
    }

        public string Name { get; set; }
        public string Surname { get; set; }
        public int EmployeeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public void AddEmployee(string name, string surname, int employeeId, string phoneNumber, string address, string email)
        {
            Name = name;
            Surname = surname;
            EmployeeId = employeeId;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;

                _businessLogic.AddEmployee(name, surname, employeeId, phoneNumber, address, email);

        }

        public void RemoveEmployee(int employeeId)
        {
            _businessLogic.RemoveEmployee(employeeId);
        }

        public IEnumerable<IEmployeeModel> GetAllEmployees()
        {
            var employees = _businessLogic.GetAllBooks();

            var employeeModels = employees.Select(employee => new EmployeeModel()
            {
                Name = employee.name,
                Surname = employee.surname,
                EmployeeId = employee.employeeId,
                PhoneNumber = employee.phoneNumber,
                Address = employee.address,
                Email = employee.email
            });

            return employeeModels;
        }
    }
}
