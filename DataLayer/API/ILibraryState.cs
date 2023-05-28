

namespace DataLayer.API
{
    public interface ILibraryState
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IEmployee> Employees { get; set; }
        public List<IReader> Readers { get; set; }

    }
}