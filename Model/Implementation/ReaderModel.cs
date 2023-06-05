using LogicLayer.API;
using Model.API;

namespace Model.Implementation
{
    public class ReaderModel : IReaderModel
    {
        private readonly IBusinessLogic _businessLogic;

        public ReaderModel()
        {
            _businessLogic = IBusinessLogic.BusinessLogicFactory();
        }

        public ReaderModel(IBusinessLogic bl)
        {
            _businessLogic = bl;
        }

        public int ReaderId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        public void AddReader(int readerId, string name, string surname, string phoneNumber, string address, string email)
        {
            ReaderId = readerId;
            Name = name;
            Surname = surname;
            PhoneNumber = phoneNumber;
            Address = address;
            Email = email;

            _businessLogic.AddReader(readerId, name, surname, phoneNumber, address, email);
        }

        public void RemoveReader(int readerId)
        {
            _businessLogic.RemoveReader(readerId);
        }

        public IEnumerable<IReaderModel> GetAllReaders()
        {
            var readers = _businessLogic.GetAllReaders();

            var readerModels = readers.Select(reader => new ReaderModel()
            {
                ReaderId = reader.Id,
                Name = reader.Name,
                Surname = reader.Surname,
                PhoneNumber = reader.PhoneNumber,
                Address = reader.Address,
                Email = reader.Email
            });

            return readerModels;
        }
    }
}
