using DataLayer.API;
using LogicLayer.API;
using Model.API;
using System.Collections.ObjectModel;

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

            _businessLogic.AddEmployee(employeeId, name, surname, phoneNumber, address, email);

        }

        public void RemoveEmployee(int employeeId)
        {
            _businessLogic.RemoveEmployee(employeeId);
        }

        public IEnumerable<IEmployeeModel> GetAllEmployees()
        {

            try
            {
                var employees = _businessLogic.GetAllEmployees();

                var employeeModels = employees.Select(employee => new EmployeeModel()
                {
                    Name = employee.Name,
                    Surname = employee.Surname,
                    EmployeeId = employee.EmployeeId,
                    PhoneNumber = employee.PhoneNumber,
                    Address = employee.Address,
                    Email = employee.Email
                });

                return employeeModels;
            } catch (Exception)
            {
                return GetExampleEmployees();
            }
        }

        private IEnumerable<IEmployeeModel> GetExampleEmployees()
        {
            // Create example book data
            var exampleEmployees = new ObservableCollection<IEmployeeModel>
            {
             new EmployeeModel
    {
        Name = "John",
        Surname = "Doe",
        EmployeeId = 1,
        PhoneNumber = "555-1234",
        Address = "123 Main St",
        Email = "john.doe@example.com"
    },
    new EmployeeModel
    {
        Name = "Jane",
        Surname = "Smith",
        EmployeeId = 2,
        PhoneNumber = "555-5678",
        Address = "456 Elm St",
        Email = "jane.smith@example.com"
    }
        };

            return exampleEmployees;
        }
    }
}
