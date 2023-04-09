using System;
namespace DataLayer.API
{
	public interface IPerson : IUsers
	{
        RoleType Role { get; set; } 
        string Surname { get; set; }
    }

    public enum RoleType
    {
        Reader,
        Employee
    }
}

