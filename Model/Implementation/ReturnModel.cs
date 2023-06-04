using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.API;

namespace Model.Implementation
{
    public class ReturnModel : IReturnModel
    {
        public string BookId { get; set; }
        public string ReaderId { get; set; }
        public string EmployeeId { get; set; }
        public string ReturnId { get; set; }

        private List<IReturnModel> returnList;

        public ReturnModel()
        {
            returnList = new List<IReturnModel>();
        }

        public void AddReturn(string bookId, string readerId, string employeeId, string returnId)
        {
            returnList.Add(new ReturnModel
            {
                BookId = bookId,
                ReaderId = readerId,
                EmployeeId = employeeId,
                ReturnId = returnId
            });
        }

        public void RemoveReturn(string returnId)
        {
            var returnToRemove = returnList.Find(returned => returned.ReturnId == ReturnId);
            if (returnToRemove != null)
                returnList.Remove(returnToRemove);
        }

        public IEnumerable<IReturnModel> GetAllReturns()
        {
            return returnList;
        }
    }
}
