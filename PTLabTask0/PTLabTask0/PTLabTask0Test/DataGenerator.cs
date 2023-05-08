using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;
using LogicLayer.Implementation;

namespace PTLabTask0Test
{
    internal class DataGenerator: IDataGenerator
    {
        public override void Generate(IDataRepository dataRepository)
        {
            //generate users

            dataRepository.AddEmployee(new Person(IPerson.PersonIdType.EmployeeId, "John", "23 Street", "+48395139211", "john@mail.com", "Smith", IPerson.RoleType.Employee));
            dataRepository.AddReader(new Person(IPerson.PersonIdType.ReaderId, "Jan", "44 Street", "+42227742738", "jan@onet.pl", "Kowalski", IPerson.RoleType.Reader));
            dataRepository.AddSupplier(new Supplier("2211", "Bechtle", "Bechtle Platz", "+4420343743", "bechtle@bechtle.de"));

            //generate books

            dataRepository.AddBook(new Book("Harry Potter", "J.K. Rowling", "2333", "Nowa Era", "Fantasy", true));

        }
    }
}
