using System;
namespace DataLayer.API;

public interface IUsers
{
    string Id { get; set; }
    string Name { get; set; }
    string Address { get; set; }
    string PhoneNumber { get; set; }
    string Email { get; set; }

}