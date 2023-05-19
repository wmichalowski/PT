using DataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.API
{
    public interface ILibraryState
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IPerson> Employees { get; set; }
        public List<IPerson> Readers { get; set; }
        public List<IEvent> Events { get; set; }

        Task AddAsync();
        Task DeleteAsync();

    }
}
