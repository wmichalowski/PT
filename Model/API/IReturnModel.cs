using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IReturnModel
    {
        string BookId { get; set; }
        string ReaderId { get; set; }
        string EmployeeId { get; set; }
        string ReturnId { get; set; }

        void AddReturn(string bookId, string readerId, string employeeId, string returnId);
        void RemoveReturn(string returnId);
        IEnumerable<IReturnModel> GetAllReturns();
    }
}