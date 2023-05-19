using Service.API;

namespace Services .Model
{
	internal class UsersModel : Services.API.IUsers
	{
		public UsersModel(string name, string address, string phoneNumber, string email, IService service)
		{
			Name = name;
			Address = address;
			PhoneNumber = phoneNumber;
			Email = email;
		}

		public IService Servicee { get; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Id { get; set; }

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
			await Servicee.AddUser(Id, FirstName, LastName);
		}

		public async Task DeleteAsync()
		{
			await Servicee.DeleteUser(Id);
		}
	}
}