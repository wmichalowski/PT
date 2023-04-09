using System;
namespace DataLayer.API
{
	public interface IPerson : IUsers
	{
        PersonIdType PersonId { get; set; }
        string Surname { get; set; }
        RoleType Role { get; set; } 
    }

    public enum PersonIdType
    {
        ReaderId,
        EmployeeId
    }

    public enum RoleType
    {
        Reader,
        Employee
    }
}

