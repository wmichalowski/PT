using Model.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IReaderModel
    {
        string Name { get; set; }
        string Surname { get; set; }
        string ReaderId { get; set; }
        string PhoneNumber { get; set; }
        string Address { get; set; }
        string Email { get; set; }

        void AddReader(string name, string surname, string employeeId, string phoneNumber, string address, string email);
        void RemoveReader(string employeeId);
        IEnumerable<IReaderModel> GetAllReaders();
    }
}
