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
        public string Intent { get; set; }
        public DateTime Date { get; set; }

        public void AddReturn(int returnId, int bookId, int employeeId, int readerId, string intent, DateTime date)
        {
            ReturnId = returnId;
            BookId = bookId;
            EmployeeId = employeeId;
            ReaderId = readerId;
            Intent = intent;
            Date= date;

            _businessLogic.AddReturn(returnId, bookId, employeeId, readerId, intent, date);
        }

        public void RemoveReturn(int returnId)
        {
          //  _businessLogic.RemoveReturn(returnId);
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
