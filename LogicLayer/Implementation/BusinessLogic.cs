using DataLayer.API;
using LogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementation
{
    internal class BusinessLogic: IBusinessLogic
    {

        private IDataContext dataContext;

        internal BusinessLogic(IDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void AddBook(int Id, string title, string author, string category, string publisher)
        {
            dataContext.AddBook(Id, title, author, category, publisher);
        }

        public IEnumerable<IBook> GetAllBooks()
        {
           return dataContext.GetAllBooks();
        }

        public void RemoveBook(int Id)
        {
            dataContext.RemoveBook(Id);
        }

        public void updateBook(int Id, string title, string author, string category, string publisher)
        {
            IEnumerable<IBook> allBooks = dataContext.GetAllBooks();
            if (allBooks.Any(b => b.Id == Id))
            {
                dataContext.RemoveBook(Id);
                dataContext.AddBook(Id, title, author, category, publisher);
            }
            else {
                throw new Exception("book does not exist!!!");
            }
                
        }
    }
}
