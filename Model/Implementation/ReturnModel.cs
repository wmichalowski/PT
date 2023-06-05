using LogicLayer.API;
using Model.API;

namespace Model.Implementation
{
    public class ReturnModel : IReturnModel
    {
        private readonly IBusinessLogic _businessLogic;

        public ReturnModel()
        {
            _businessLogic = IBusinessLogic.BusinessLogicFactory();
        }

        public ReturnModel(IBusinessLogic bl)
        {
            _businessLogic = bl;
        }

        public int ReturnId { get; set; }
        public int BookId { get; set; }
        public int EmployeeId { get; set; }
        public int ReaderId { get; set; }

        public void AddReturn(int returnId, int bookId, int employeeId, int readerId)
        {
            ReturnId = returnId;
            BookId = bookId;
            EmployeeId = employeeId;
            ReaderId = readerId;

            _businessLogic.AddReturn(returnId, bookId, employeeId, readerId);
        }

        public void RemoveReturn(int returnId)
        {
            _businessLogic.RemoveReturn(returnId);
        }

        public IEnumerable<IReturnModel> GetAllReturns()
        {
            var returns = _businessLogic.GetAllReturns();

            var returnModels = returns.Select(returnData => new ReturnModel()
            {
                ReturnId = returnData.ReturnId,
                BookId = returnData.BookId,
                EmployeeId = returnData.EmployeeId,
                ReaderId = returnData.ReaderId
            });

            return returnModels;
        }
    }
}
