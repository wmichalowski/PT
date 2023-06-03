using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IBookModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public abstract void AddBook(int id, string name);
        public abstract void RemoveBook(int id);
    }
}
