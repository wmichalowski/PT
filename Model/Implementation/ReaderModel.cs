using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementation
{
    public class ReaderModel : IReaderModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string ReaderId { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }

        private List<IReaderModel> readerList;

        public ReaderModel()
        {
            readerList = new List<IReaderModel>();
        }

        public void AddReader(string name, string surname, string readerId, string phoneNumber, string address, string email)
        {
            readerList.Add(new ReaderModel
            {
                Name = name,
                Surname = surname,
                ReaderId = readerId,
                PhoneNumber = phoneNumber,
                Address = address,
                Email = email
            });
        }

        public void RemoveReader(string readerId)
        {
            var readerToRemove = readerList.Find(reader => reader.ReaderId == readerId);
            if (readerToRemove != null)
                readerList.Remove(readerToRemove);
        }

        public IEnumerable<IReaderModel> GetAllReaders()
        {
            return readerList;
        }
    }
}
