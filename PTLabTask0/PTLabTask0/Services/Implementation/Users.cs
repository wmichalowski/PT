using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementation
{
    internal abstract class User : IUsers
    {

        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        protected User(string name, string address, string phoneNumber, string email)
        {
            Name = name;
            Address = address;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }

    internal class Person : User, IPerson
    {
        public IPerson.PersonIdType PersonId { get; set; }
        public string Surname { get; set; }
        public IPerson.RoleType Role { get; set; }

        public Person(IPerson.PersonIdType personId, string name, string address, string phoneNumber, string email, string surname, IPerson.RoleType role)
            : base(name, address, phoneNumber, email)
        {
            Surname = surname;
            PersonId = personId;
            Role = role;
        }
    }

    internal class Supplier : User, ISupplier
    {
        public Supplier(string supplierId, string name, string address, string phoneNumber, string email)
            : base(name, address, phoneNumber, email)
        {
            SupplierId = supplierId;
        }

        public string SupplierId { get; set; }

    }

    public async Task AddAsync()
    {
    public void AddReader(IPerson person)
    {
        if (_dataRepository.GetReaderById(person.PersonId) == null)
        {
            _dataRepository.AddReader(person);
        }
    }

    public void UpdateReader(IPerson person)
    {
        if (_dataRepository.GetReaderById(person.PersonId) != null)
        {
            _dataRepository.UpdateReader(person);
        }
    }

    public void DeleteReader(IPerson.PersonIdType personId)
    {
        if (_dataRepository.GetReaderById(personId) != null)
        {
            _dataRepository.DeleteReader(personId);
        }
    }

    public IPerson? GetReaderById(IPerson.PersonIdType personId)
    {
        var person = _dataRepository.GetReaderById(personId);
        return person ?? throw new ArgumentException("Person not found");
    }

    public void AddEmployee(IPerson person)
    {
        if (_dataRepository.GetReaderById(person.PersonId) == null)
        {
            _dataRepository.AddEmployee(person);
        }
    }

    public void UpdateEmployee(IPerson person)
    {
        if (_dataRepository.GetReaderById(person.PersonId) != null)
        {
            _dataRepository.UpdateEmployee(person);
        }
    }

    public void DeleteEmployee(IPerson.PersonIdType personId)
    {
        if (_dataRepository.GetEmployeeById(personId) != null)
        {
            _dataRepository.DeleteEmployee(personId);
        }
    }

    public IPerson? GetEmployeeById(IPerson.PersonIdType personId)
    {
        var employee = _dataRepository.GetEmployeeById(personId);
        return employee ?? throw new ArgumentException("no such employee");
    }

    public void AddSupplier(ISupplier supplier)
    {
        if (_dataRepository.GetSupplierById(supplier.SupplierId) == null)
        {
            _dataRepository.AddSupplier(supplier);
        }
    }

    public void UpdateSupplier(ISupplier supplier)
    {
        if (_dataRepository.GetSupplierById(supplier.SupplierId) != null)
        {
            _dataRepository.UpdateSupplier(supplier);
        }
    }

    public void DeleteSupplier(string supplierId)
    {
        if (_dataRepository.GetSupplierById(supplierId) != null)
        {
            _dataRepository.DeleteSupplier(supplierId);
        }
    }

    public ISupplier? GetSupplierById(string supplierId)
    {
        var supplier = _dataRepository.GetSupplierById(supplierId);
        return supplier ?? throw new ArgumentException("no such supplier");
    }
}
}
