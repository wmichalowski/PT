using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Data.Linq.DataContext;

namespace DataLayer.API
{
    public interface IDataContext
    {
        public IQueryable<IBook> Books { get; }
        public IQueryable<IReader> Readers { get; }
        public IQueryable<IEmployee> Employees { get; }
        public IQueryable<ISupplier> Suppliers { get; }
        public IQueryable<IRent_Return> Event_RentsReturns { get; }
        public IQueryable<IBookDeletion> Event_BookDeletions { get; }
        public IQueryable<IBookAcquisition> Event_BookAcquisitions { get; }
    }
}
