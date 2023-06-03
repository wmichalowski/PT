using LogicLayer.API;
using Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Implementation
{
    public class BookModel : IBookModel
    {
        public BookModel(string id, string title)
        {
            Id = id;
            Title = title;

            _service = IBusinessLogic.BusinessLogicFactory();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        IBusinessLogic _service { get; }

        public void AddBook(int id, string name)
        {
          _service.AddBook(id, name);
        }

        public void RemoveBook(int id)
        {
            _service.RemoveBook(id);
        }

    }
}
