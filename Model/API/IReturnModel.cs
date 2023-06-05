using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IReturnModel
    {
        int BookId { get; set; }
        int ReaderId { get; set; }
        int EmployeeId { get; set; }
        int ReturnId { get; set; }

        void AddReturn(int bookId, int readerId, int employeeId, int returnId);
        void RemoveReturn(int returnId);
        IEnumerable<IReturnModel> GetAllReturns();
    }
}