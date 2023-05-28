using DataLayer.API;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Implementation
{
    public class DataContext : DbContext, IDataContext
    {

        public DbSet<Book> Books { get; set; }
        IQueryable<IBook> IDataContext.Books => Books;
        public DbSet<Employee> Employees { get; set; }
        IQueryable<IEmployee> IDataContext.Employees => Employees;
        public DbSet<Reader> Readers { get; set; }
        IQueryable<IReader> IDataContext.Readers => Readers;
        public DbSet<Supplier> Suppliers { get; set;}
        IQueryable<ISupplier> IDataContext.Suppliers => Suppliers;
        public DbSet<Rent_Return> Event_RentsReturns { get; set; }
        IQueryable<IRent_Return> IDataContext.Event_RentsReturns => Event_RentsReturns;
        public DbSet<BookDeletion> Event_BookDeletions { get; set; }
        IQueryable<IBookDeletion> IDataContext.Event_BookDeletions => Event_BookDeletions;
        public DbSet<BookAcquisition> Event_BookAcquisitions { get; set; }
        IQueryable<IBookAcquisition> IDataContext.Event_BookAcquisitions => Event_BookAcquisitions;

        private readonly string _connString;

        public DataContext(DbContextOptions<DataContext> options, string connString): base (options)
        {
          _connString = connString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
            base.OnConfiguring(optionsBuilder);
        }

    }

}
