using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.API
{
    public interface IAddBookModel
    {
        string BookId { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string Category { get; set; }
        string Publisher { get; set; }

        Task AddBookAsync();
    }
}
