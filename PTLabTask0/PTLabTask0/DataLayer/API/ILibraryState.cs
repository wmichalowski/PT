

namespace DataLayer.API
{
    public interface ILibraryState
    {
        public List<IBook> Books { get; set; }
        public List<ISupplier> Suppliers { get; set; }
        public List<IPerson> Employees { get; set; }
        public List<IPerson> Readers { get; set; }
        public List<IEvent> Events { get; set; }

    }
}