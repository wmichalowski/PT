using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.API;

namespace Model.Implementation
{
    public class RentModel : IRentModel
    {
        public string BookId { get; set; }
        public string ReaderId { get; set; }
        public string EmployeeId { get; set; }
        public string RentId { get; set; }

        private List<IRentModel> rentList;

        public RentModel()
        {
            rentList = new List<IRentModel>();
        }

        public void AddRent(string bookId, string readerId, string employeeId, string rentId)
        {
            rentList.Add(new RentModel
            {
                BookId = bookId,
                ReaderId = readerId,
                EmployeeId = employeeId,
                RentId = rentId
            });
        }

        public void RemoveRent(string rentId)
        {
            var rentToRemove = rentList.Find(rent => rent.RentId == rentId);
            if (rentToRemove != null)
                rentList.Remove(rentToRemove);
        }

        public IEnumerable<IRentModel> GetAllRents()
        {
            return rentList;
        }
    }
}
