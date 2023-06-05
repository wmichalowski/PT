using LogicLayer.Implementation;
using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.API
{
    public interface IBusinessLogic
    {
        public static IBusinessLogic BusinessLogicFactory(IDataContext dataContext) => new BusinessLogic(dataContext);
        public static IBusinessLogic BusinessLogicFactory() => new BusinessLogic(IDataContext.DataContextFactory());

        public void updateBook(int Id, string Title, string Author, string Category, string Publisher);
        public void AddBook(int Id, string Title, string Author, string Category, string Publisher);
        public void RemoveBook(int Id);
        public IEnumerable<IBook> GetAllBooks();

    }
}
