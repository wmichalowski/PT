using System;
namespace DataLayer.API;

public interface IUsers
{
    string Name { get; set; }
    string Address { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }

}