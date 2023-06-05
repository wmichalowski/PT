using DataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IBook
    {
        int Id { get; }
        string Title { get; }
        string Author { get; }
        string Category { get; }
        string Publisher { get; }
    }
}
