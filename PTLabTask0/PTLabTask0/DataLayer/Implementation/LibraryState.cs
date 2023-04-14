using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;
using DataLayer.Implementation;

namespace DataLayer.Implementation
{
    internal class LibraryState: ILibraryState, IEvent
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IPerson> Employees { get; set; }
        public List<IPerson> Readers { get; set; }
        public List<IEvent> Events { get; set; }

        public LibraryState()
        {
            Books = new List<IBook>();
            Suppliers = new List<ISupplier>();
            Employees = new List<IPerson>();
            Readers = new List<IPerson>();
            Events = new List<IEvent>();
        }
    }
}
