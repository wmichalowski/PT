using LogicLayer.API;
using Model.API;

namespace Model.Implementation
{
    public class RentModel : IRentModel
    {
        private readonly IBusinessLogic _businessLogic;

        public RentModel()
        {
            _businessLogic = IBusinessLogic.BusinessLogicFactory();
        }

        public RentModel(IBusinessLogic bl)
        {
            _businessLogic = bl;
        }

        public int BookId { get; set; }
        public int RentId { get; set; }
        public int ReaderId { get; set; }
        public int EmployeeId { get; set; }

        public void AddRent(int bookId, int rentId, int readerId, int employeeId)
        {
            BookId = bookId;
            RentId = rentId;
            ReaderId = readerId;
            EmployeeId = employeeId;

            _businessLogic.AddRent(bookId, rentId, readerId, employeeId);
        }

        public void RemoveRent(int rentId)
        {
            _businessLogic.RemoveRent(rentId);
        }

        public IEnumerable<IRentModel> GetAllRents()
        {
            var rents = _businessLogic.GetAllRents();

            var rentModels = rents.Select(rent => new RentModel()
            {
                BookId = rent.BookId,
                RentId = rent.RentId,
                ReaderId = rent.ReaderId,
                EmployeeId = rent.EmployeeId
            });

            return rentModels;
        }
    }
}
