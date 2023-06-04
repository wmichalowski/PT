using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IRentModel
    {
        string BookId { get; set; }
        string ReaderId { get; set; }
        string EmployeeId { get; set; }
        string RentId { get; set; }

        void AddRent(string bookId, string readerId, string employeeId, string rentId);
        void RemoveRent(string rentId);
        IEnumerable<IRentModel> GetAllRents();
    }
}
